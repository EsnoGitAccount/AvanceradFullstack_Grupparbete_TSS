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
import { Label } from "@/components/ui/label";
import { validateEmail } from "@/lib/validateEmail";
import { useState } from "react";
import { Link, useNavigate } from "react-router";
import type { RegisterDto } from "@/models/RegisterDto";
import { useAuth } from "@/context/auth/UseAuth";


type RegisterError = {
  userName?: string;
  userEmail?: string;
  password?: string;
  confirmPassword?: string;
};

function RegisterPage() {
  /*Register form data*/
  const [user, setUser] = useState({
    userName: "",
    userEmail: "",
    password: "",
    confirmPassword: "",
  });

  const {register}= useAuth();
  const navigate = useNavigate();
  const [errors, setErrors] = useState<RegisterError>({});

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
    if (password.length < 12) {
      return "Lösenordet måste innehålla minst 12 tecken.";
    }

    /*Check uppercase*/
    if (!/[A-Z]/.test(password)) {
      return "Lösenordet måste innehålla minst en stor bokstav";
    }
    /*Check lowercase*/
    if (!/[a-z]/.test(password)) {
      return "Lösenordet måste innehålla minst en liten bokstav.";
    }
    /*Check number*/
    if (!/\d/.test(password)) {
      return "Lösenordet måste innehålla minst en siffra.";
    }

    return "";
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
    <>
      <Card className="w-full max-w-[26rem] rounded-3xl">
        <CardHeader>
          <CardTitle>Skapa ditt konto</CardTitle>
        </CardHeader>

        <form onSubmit={handleSubmit} noValidate className="grid gap-6 pt-2">
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
                <p className="text-sm text-destructive"> {errors.userName}</p>
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
                <p className="text-sm text-destructive"> {errors.userEmail}</p>
              )}
            </div>
            {/* Password */}
            <div className="grid gap-2">
              <Label htmlFor="password">Lösenord</Label>
              <Input
                id="password"
                name="password"
                type="password"
                placeholder="Lösenord"
                value={user.password}
                onChange={handleInput}
                aria-invalid={!!errors.password}
                required
              />
              {errors.password && (
                <p className="text-sm text-destructive">{errors.password}</p>
              )}
            </div>
            {/*Confirm password*/}

            <div className="grid gap-2">
              <Label htmlFor="confirmPassword">Bekräfta lösenord</Label>
              <Input
                id="confirmPassword"
                name="confirmPassword"
                type="password"
                placeholder="Ange lösenordet igen"
                value={user.confirmPassword}
                onChange={handleInput}
                aria-invalid={!!errors.confirmPassword}
                required
              />
              {errors.confirmPassword && (
                <p className="text-sm text-destructive">
                  {errors.confirmPassword}
                </p>
              )}
            </div>
          </CardContent>

          <CardFooter className="flex flex-col gap-4">
            {/* Skapa konto button */}
            <Button type="submit" className="w-full h-[2.625rem] text-base">
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
    </>
  );
}

export default RegisterPage;
