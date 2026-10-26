import React, { useState } from 'react';
import { AlertCircle, ArrowRight } from 'lucide-react';
import { Input } from "@/components/ui/Input";
import { Button } from '@/components/ui/Button';
import { useAuth } from "@/context/auth/UseAuth";
import { useNavigate } from 'react-router';

export function LoginForm() {
    const { login } = useAuth();
    const navigate = useNavigate();

    const [userName, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState<string | null>(null);
    const [isSubmitting, setIsSubmitting] = useState(false);

    const handleSubmit = async (event: React.SubmitEvent) => {
        event.preventDefault();
        setErrorMessage(null);

        if (!userName.trim() || !password.trim()) {
            setErrorMessage('Användarnamn/e-post och lösenord krävs.');
            return;
        }
        setIsSubmitting(true);

        try {
            await login({ username: userName, password });
            navigate('/profile');
        } catch (err) {
            if (err instanceof Error) {
                setErrorMessage(err.message);
            } else {
                setErrorMessage('Fel användarnamn/e-post eller lösenord.');
            }
        } finally {
            setIsSubmitting(false);
        }
    };

    return (
        <form onSubmit={handleSubmit} className="login-card__form">

            {/* Email & username */}
            <div className="form-group">
                <label htmlFor="username" className="text-left w-[85%]">
                    E-post eller användarnamn
                </label>
                <Input
                    id="username"
                    value={userName}
                    onChange={(e) => setUsername(e.target.value)}
                    placeholder="Exempel@epost.se"
                    className="h-12 w-[85%]"
                />
            </div>

            {/* Password */}
            <div className="form-group">
                <label htmlFor="password" className="text-left w-[85%]">
                    Lösenord
                </label>
                <Input
                    id="password"
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    placeholder="••••••••"
                    className="h-12 w-[85%]"
                />
            </div>

            {/* Error alert */}
            {errorMessage && (
                <div className="login-card__alert">
                    <AlertCircle className="w-5 h-5 text-amber-600 flex-shrink-0" />
                    <div>
                        <p className="font-semibold text-sm">Det gick inte att logga in</p>
                        <p className="text-xs text-muted-foreground">{errorMessage}</p>
                    </div>
                </div>
            )}

            {/* Forgot password */}
            <a
                href="/forgot-password"
                className="login-card__forgot-link"
                style={{ textAlign: "center" }}
            >
                Glömt lösenordet?
            </a>

            {/* Log in button */}
            <Button type="submit" className="login-card__submit-btn">
                {isSubmitting ? 'Loggar in...' : 'Logga in'}  <ArrowRight className="w-4 h-4 ml-2" />
            </Button>

            {/* Create account */}
            <p className="login-card__signup-text">
                Ny här? Skapa ett konto och kliv ombord.
            </p>
            <div className="login-card__signup">
                <Button type="button" variant="outline" className="login-card__signup-btn">
                    Skapa konto
                </Button>
            </div>

        </form>
    )
}
