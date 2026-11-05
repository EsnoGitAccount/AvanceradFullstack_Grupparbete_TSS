import axios from "axios";
import { Button } from "@/components/ui/Button";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
  CardFooter,
} from "@/components/ui/Card";
import { Input } from "@/components/ui/Input";
import { Label } from "@/components/ui/Label";
import { validateEmail } from "@/lib/validateEmail";
import { useState } from "react";
import { Link, useNavigate } from "react-router";
import type { RegisterDto } from "@/models/RegisterDto";
import { useAuth } from "@/context/auth/UseAuth";
import TrainIllustration from "@/assets/illustrations/trainillustration";
import { getTimeOfDay } from "@/models/TimeOfDay";
import "./RegisterPage.css";
import { Eye, EyeOff } from "lucide-react";

type RegisterError = {
  userName?: string;
  userEmail?: string;
  password?: string;
  confirmPassword?: string;
};

function RegisterPage() {
  const time = getTimeOfDay();
  /*Register form data*/
  const [user, setUser] = useState({
    userName: "",
    userEmail: "",
    password: "",
    confirmPassword: "",
  });

  const { register } = useAuth();
  const navigate = useNavigate();
  const [errors, setErrors] = useState<RegisterError>({});
  const [showPassword, setShowPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false)

  const handleInput = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setUser((prev) => ({
      ...prev,
      [name]: value,
    }));

    setErrors((prev) => ({
      ...prev,
      [name]: "",
    }));
  };

  /*Validate password*/
  const validatePassword = (password: string) => {
    const errors: string[] = []

    if (password.length < 12) {
      errors.push("minst 12 tecken")
    }

    /*Check uppercase*/
    if (!/[A-Z]/.test(password)) {
      errors.push("en stor bokstav")
    }
    /*Check lowercase*/
    if (!/[a-z]/.test(password)) {
      errors.push("en liten bokstav")
    }
    /*Check number*/
    if (!/\d/.test(password)) {
      errors.push("en siffra")
    }

    if (!/[^A-Za-z0-9\s]/.test(password)) {
      errors.push("ett specialtecken")
    }

    if (errors.length === 0) return ""

    if (errors.length === 1) {
      return `Lösenordet måste innehålla ${errors[0]}.`
    }

    const lastError = errors.pop()
    return `Lösenordet måste innehålla ${errors.join(", ")} samt ${lastError}.`
  };

  /*Validate form field*/
  const validateField = (name: string, value: string) => {
    if (!value.trim()) {
      return "Det här fältet är obligatoriskt.";
    }

    if (name === "userEmail") {
      return validateEmail(value);
    }

    if (name === "password") {
      return validatePassword(value);
    }

    return "";
  };

  const handleSubmit = async (e: React.SubmitEvent<HTMLFormElement>) => {
    e.preventDefault();

    const newErrors: RegisterError = {};
    const userNameError = validateField("userName", user.userName);
    if (userNameError) {
      newErrors.userName = userNameError;
    }

    const emailError = validateField("userEmail", user.userEmail);
    if (emailError) {
      newErrors.userEmail = emailError;
    }

    const passwordError = validateField("password", user.password);

    if (passwordError) {
      newErrors.password = passwordError;
    }

    const confirmPasswordError = validateField(
      "confirmPassword",
      user.confirmPassword,
    );

    if (confirmPasswordError) {
      newErrors.confirmPassword = confirmPasswordError;
    } else if (user.password !== user.confirmPassword) {
      newErrors.confirmPassword = "Lösenorden matchar inte.";
    }

    setErrors(newErrors);

    if (Object.keys(newErrors).length > 0) {
      return;
    }
    /*Prepare register data*/
    const registerData: RegisterDto = {
      userName: user.userName,
      email: user.userEmail,
      password: user.password,
    };
    /*Send register request*/
    try {
      await register(registerData);
      navigate("/", { replace: true });
    } catch (error) {
      /* Handle existing user conflicts */
      if (axios.isAxiosError(error) && error.response?.status === 409) {
        const detail = error.response.data?.detail;
        if (detail === "Username already exists.") {
          setErrors((prev) => ({
            ...prev,

            userName: "Det här användarnamnet är redan upptaget.",
          }));
        } else if (detail === "User already exists.") {
          setErrors((prev) => ({
            ...prev,
            userEmail: "Det finns redan ett konto med den här e-postadressen.",
          }));
        }
        return;
      }
      console.error("Register error:", error);
    }
  };

  return (
    <div className="register-page register-page__main">
      <section className="register-page__hero">
        <div className="register-page__grid">
          {/*Left*/}
          <div className="register-page__left-column">
            <span className="register-page__eyebrow">
              ETT SPEL FÖR HELA SVERIGE
            </span>
            <h1 className="register-page__title">
              Ska vi upptäcka Sverige?
            </h1>
            <p className="register-page__subtitle">
              Spara dina poäng, håll koll på din nivå och hitta din plats på
              topplistan.
            </p>
            <div
              className={`register-page__illustration train-illustration--${time}`}
            >
              <TrainIllustration />
            </div>

            <div className="register-page__badge">
              Quiza. Upptäck. Ta dig vidare
            </div>
          </div>
          {/*Right*/}
          <div className="register-page__right-column">
            <Card className="w-full max-w-[26rem] rounded-3xl">
              <CardHeader>
                <CardTitle>Skapa ditt konto</CardTitle>
              </CardHeader>

              <form
                onSubmit={handleSubmit}
                noValidate
                className="grid gap-6 pt-2"
              >
                <CardContent className="grid gap-4">
                  <div className="grid gap-2">
                    {/* Username */}
                    <Label htmlFor="userName">Användarnamn</Label>
                    <Input
                      id="userName"
                      name="userName"
                      type="text"
                      placeholder="Ange ditt användarnamn"
                      value={user.userName}
                      onChange={handleInput}
                      aria-invalid={!!errors.userName}
                      required
                    />
                    {errors.userName && (
                      <p className="text-sm text-destructive">
                        {" "}
                        {errors.userName}
                      </p>
                    )}
                  </div>
                  {/* Email */}
                  <div className="grid gap-2">
                    <Label htmlFor="userEmail">E-post</Label>
                    <Input
                      id="userEmail"
                      name="userEmail"
                      type="email"
                      placeholder="Ange din e-post"
                      value={user.userEmail}
                      onChange={handleInput}
                      aria-invalid={!!errors.userEmail}
                      required
                    />
                    {errors.userEmail && (
                      <p className="text-sm text-destructive">
                        {" "}
                        {errors.userEmail}
                      </p>
                    )}
                  </div>
                  {/* Password */}
                  <div className="grid gap-2">
                    <Label htmlFor="password">Lösenord</Label>

                    <div className="relative w-full">
                      <Input
                        id="password"
                        name="password"
                        type={showPassword ? "text" : "password"}
                        placeholder="Lösenord"
                        value={user.password}
                        onChange={handleInput}
                        aria-invalid={!!errors.password}
                        required
                      />
                      <button
                        type="button"
                        onClick={() => setShowPassword(!showPassword)}
                        className="absolute right-3 top-1/2 -translate-y-1/2 text-[var(--primary)] hover:text-[var(--foreground)] transition-colors"
                        tabIndex={-1}
                        aria-label={showPassword ? "Dölj lösenord" : "Visa lösenord"}
                      >
                        {showPassword ? (
                          <EyeOff className="w-5 h-5" />
                        ) : (
                          <Eye className="w-5 h-5" />
                        )}
                      </button>
                    </div>

                    {errors.password && (
                      <p className="text-sm text-destructive">
                        {errors.password}
                      </p>
                    )}
                  </div>

                  {/*Confirm password*/}
                  <div className="grid gap-2">
                    <Label htmlFor="confirmPassword">Bekräfta lösenord</Label>

                    <div className="relative w-full">
                      <Input
                        id="confirmPassword"
                        name="confirmPassword"
                        type={showConfirmPassword ? "text" : "password"}
                        placeholder="Ange lösenordet igen"
                        value={user.confirmPassword}
                        onChange={handleInput}
                        aria-invalid={!!errors.confirmPassword}
                        required
                      />
                      <button
                        type="button"
                        onClick={() => setShowConfirmPassword(!showConfirmPassword)}
                        className="absolute right-3 top-1/2 -translate-y-1/2 text-[var(--primary)] hover:text-[var(--foreground)] transition-colors"
                        tabIndex={-1}
                        aria-label={showConfirmPassword ? "Dölj lösenord" : "Visa lösenord"}
                      >
                        {showConfirmPassword ? (
                          <EyeOff className="w-5 h-5" />
                        ) : (
                          <Eye className="w-5 h-5" />
                        )}
                      </button>
                    </div>

                    {errors.confirmPassword && (
                      <p className="text-sm text-destructive">
                        {errors.confirmPassword}
                      </p>
                    )}
                  </div>
                </CardContent>

                <CardFooter className="flex flex-col gap-4">
                  {/* Skapa konto button */}
                  <Button
                    type="submit"
                    className="w-full h-[2.625rem] text-base"
                  >
                    Skapa konto
                  </Button>
                  {/* Logga in link */}
                  <p className="text-sm text-muted-foreground">
                    Har du redan ett konto?{" "}
                    <Link to="/login" className="text-primary">
                      Logga in
                    </Link>
                  </p>
                </CardFooter>
              </form>
            </Card>
          </div>
        </div>
      </section>
    </div>
  );
}

export default RegisterPage;
