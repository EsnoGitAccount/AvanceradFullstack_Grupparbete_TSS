import React from "react";
import { Navigate } from "react-router";
import { useAuth } from "../context/auth/UseAuth";
import AccessDeniedPage from "../pages/access-denied-page/AccessDeniedPage";

type ProtectedRouteProps = {
  children: React.ReactNode;
  requiredRole?: string;
};

export default function ProtectedRoute({ children, requiredRole }: ProtectedRouteProps) {
  const { user, loading } = useAuth();

  if (loading) {
    return <div></div>;
  }

  if (!user) {
    return <Navigate to="/login" replace />;
  }

  if (requiredRole && !user.roles.includes(requiredRole)) {
    return <AccessDeniedPage />;
  }

  return <>{children}</>;
}
