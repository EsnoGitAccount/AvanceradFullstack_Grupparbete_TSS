export function validateEmail(value: string): string {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!emailRegex.test(value)) {
        return "Ange en giltig e-postadress.";
    }

    return "";
}