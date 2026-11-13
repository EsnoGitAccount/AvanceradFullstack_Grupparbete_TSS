import { useState, useEffect, type SubmitEvent } from 'react';
import { changeUsername, changePassword, deleteAccount } from '@/services/AccountService';
import { Button } from "@/components/ui/Button";
import { X, Eye, EyeOff, CheckCircle2 } from 'lucide-react';

// Define the props for the EditAccountModal component
interface EditAccountModalProps {
    isOpen: boolean;
    currentUsername: string;
    onClose: () => void;
    onUsernameUpdated: (newUsername: string) => void;
    onAccountDeleted: () => void;
}

export function EditAccountModal({
    isOpen,
    currentUsername,
    onClose,
    onUsernameUpdated,
    onAccountDeleted,
}: EditAccountModalProps) {
    const [newUsername, setNewUsername] = useState<string>(currentUsername);
    const [currentPassword, setCurrentPassword] = useState<string>('');
    const [newPassword, setNewPassword] = useState<string>('');
    const [showCurrentPassword, setShowCurrentPassword] = useState<boolean>(false);
    const [showNewPassword, setShowNewPassword] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);
    const [message, setMessage] = useState<string | null>(null);
    const [loading, setLoading] = useState<boolean>(false);
    const [showDeleteConfirm, setShowDeleteConfirm] = useState<boolean>(false);
    const [isDeleted, setIsDeleted] = useState<boolean>(false);

    useEffect(() => {
        if (!message) return;

        const timer = setTimeout(() => {
            setMessage(null);
        }, 3000);

        return () => clearTimeout(timer);
    }, [message]);

    if (!isOpen) return null;

    // Handle form submissions for username and password changes, as well as account deletion
    const handleUsernameSubmit = async (e: SubmitEvent) => {
        e.preventDefault();
        setError(null);
        setMessage(null);
        setLoading(true);
        try {
            await changeUsername(newUsername);
            setMessage('Användarnamn uppdaterat!');
            onUsernameUpdated(newUsername);
        } catch {
            setError('Kunde inte uppdatera användarnamnet.');
        } finally {
            setLoading(false);
        }
    };

    const handlePasswordSubmit = async (e: SubmitEvent) => {
        e.preventDefault();
        setError(null);
        setMessage(null);
        setLoading(true);
        try {
            await changePassword(currentPassword, newPassword);
            setMessage('Lösenordet har ändrats!');
            setCurrentPassword('');
            setNewPassword('');
        } catch {
            setError('Kunde inte byta lösenord.');
        } finally {
            setLoading(false);
        }
    };

    const handleConfirmDelete = async () => {
        setError(null);
        setLoading(true);
        try {
            await deleteAccount();
            setIsDeleted(true);
            setTimeout(() => {
                onAccountDeleted();
            }, 2500);
        } catch {
            setError('Kunde inte ta bort kontot.');
            setShowDeleteConfirm(false);
            setLoading(false);
        }
    };

    return (
        <div className='fixed inset-0 bg-black/50 flex items-center justify-center z-50 p-4'>
            {isDeleted ? (
                <div className='bg-white rounded-[20px] p-6 max-w-sm w-full space-y-4 text-center shadow-lg'>
                    <CheckCircle2 className='w-12 h-12 text-green-600 mx-auto' />
                    <div className='space-y-1'>
                        <h3 className='text-lg font-bold text-[var(--foreground)] m-0'>
                            Ditt konto har raderats
                        </h3>
                        <p className='text-sm text-[var(--muted-foreground)] m-0'>
                            Du omdirigeras nu till startsidan...
                        </p>
                    </div>
                </div>
            ) : showDeleteConfirm ? (
                <div className='bg-white rounded-[20px] p-6 max-w-sm w-full space-y-6 text-center shadow-lg'>
                    <div className='space-y-2'>
                        <h6 className='text-lg font-bold text-[var(--foreground)] m-0'>
                            Är du säker på att du vill radera kontot?
                        </h6>
                        <p className='text-sm text-[var(--muted-foreground)] m-0'>
                            Detta kan inte ångras och all din data kommer att raderas permanent.
                        </p>
                    </div>

                    <div className='flex items-center justify-center gap-3'>
                        <Button
                            type='button'
                            onClick={handleConfirmDelete}
                            disabled={loading}
                            variant='destructive'
                        >
                            {loading ? 'Raderar...' : 'Ja, radera'}
                        </Button>
                        <Button
                            type='button'
                            onClick={() => setShowDeleteConfirm(false)}
                            disabled={loading}
                            variant='outline'
                        >
                            Avbryt
                        </Button>
                    </div>
                </div>
            ) : (
                <div className='bg-white rounded-[20px] p-6 max-w-md w-full space-y-6'>
                    <div className='flex justify-between items-center'>
                        <h2 className='text-xl font-bold m-0'>Kontoinställningar</h2>
                        <button
                            type='button'
                            onClick={onClose}
                            aria-label='Stäng'
                            className='p-1.5 rounded-lg text-[var(--muted-foreground)] hover:text-[var(--foreground)] hover:bg-black/5 transition-colors cursor-pointer'
                        >
                            <X className='w-7 h-7' />
                        </button>
                    </div>

                    {error && <p className='text-red-600 text-sm m-0'>{error}</p>}
                    {message && <p className='text-green-600 text-sm m-0'>{message}</p>}

                    <form onSubmit={handleUsernameSubmit} className='space-y-2'>
                        <label className='block text-sm font-semibold'>Byt användarnamn</label>
                        <input
                            type='text'
                            value={newUsername}
                            onChange={(e) => setNewUsername(e.target.value)}
                            className='w-full border rounded-lg p-2'
                            required
                        />
                        <Button type='submit' disabled={loading}>
                            Spara användarnamn
                        </Button>
                    </form>

                    <hr />

                    <form onSubmit={handlePasswordSubmit} className='space-y-2'>
                        <label className='block text-sm font-semibold'>Byt lösenord</label>
                        <div className='relative w-full'>
                            <input
                                type={showCurrentPassword ? 'text' : 'password'}
                                placeholder='Nuvarande lösenord'
                                value={currentPassword}
                                onChange={(e) => setCurrentPassword(e.target.value)}
                                className='w-full border rounded-lg p-2 pr-10'
                                required
                            />
                            <button
                                type='button'
                                onClick={() => setShowCurrentPassword(!showCurrentPassword)}
                                className='absolute right-3 top-1/2 -translate-y-1/2 text-[var(--primary)] hover:text-[var(--foreground)] transition-colors cursor-pointer'
                                tabIndex={-1}
                                aria-label={showCurrentPassword ? 'Dölj lösenord' : 'Visa lösenord'}
                            >
                                {showCurrentPassword ? (
                                    <EyeOff className='w-5 h-5' />
                                ) : (
                                    <Eye className='w-5 h-5' />
                                )}
                            </button>
                        </div>

                        <div className='relative w-full'>
                            <input
                                type={showNewPassword ? 'text' : 'password'}
                                placeholder='Nytt lösenord'
                                value={newPassword}
                                onChange={(e) => setNewPassword(e.target.value)}
                                className='w-full border rounded-lg p-2 pr-10'
                                required
                            />
                            <button
                                type='button'
                                onClick={() => setShowNewPassword(!showNewPassword)}
                                className='absolute right-3 top-1/2 -translate-y-1/2 text-[var(--primary)] hover:text-[var(--foreground)] transition-colors cursor-pointer'
                                tabIndex={-1}
                                aria-label={showNewPassword ? 'Dölj lösenord' : 'Visa lösenord'}
                            >
                                {showNewPassword ? (
                                    <EyeOff className='w-5 h-5' />
                                ) : (
                                    <Eye className='w-5 h-5' />
                                )}
                            </button>
                        </div>
                        <Button type='submit' disabled={loading}>
                            Uppdatera lösenord
                        </Button>
                    </form>

                    <hr />

                    <div>
                        <Button
                            type='button'
                            onClick={() => setShowDeleteConfirm(true)}
                            disabled={loading}
                            variant='destructive'
                        >
                            Radera konto
                        </Button>
                    </div>
                </div>
            )}
        </div>
    );
}