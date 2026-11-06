import React from "react";
import { Navigate } from "react-router";
import { useAuth } from "../context/auth/UseAuth";

type ProtectedRouteProps = {
  children: React.ReactNode;
  requiredRole?: string;
};

export default function ProtectedRoute({ children, requiredRole }: ProtectedRouteProps) {
  const { user, loading } = useAuth();

  if (loading) {
    return <div>Laddar...</div>;
  }

  if (!user) {
    return <Navigate to="/login" replace />;
  }

  if (requiredRole && !user.roles.includes(requiredRole)) {
    return (
      <div role="alert">
        <h1>Åtkomst nekad</h1>
      </div>
    );
  }

  return <>{children}</>;
}
