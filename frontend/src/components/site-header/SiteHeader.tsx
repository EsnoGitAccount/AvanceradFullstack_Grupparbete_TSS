import { Link, useNavigate } from "react-router";
import { useAuth } from "../../context/auth/UseAuth";
import { useEffect, useState } from "react";
import { Menu, X } from "lucide-react";

import logo from "@/assets/logos/logo-transparent.svg";
import { Button } from "@/components/ui/Button";

import "./SiteHeader.css";

function SiteHeader() {
  const navigate = useNavigate();
  const { user, loading, logout } = useAuth();
  const [loggingOut, setLoggingOut] = useState(false);
  const [logoutError, setLogoutError] = useState("");
  const [menuOpen, setMenuOpen] = useState(false);

  useEffect(() => {
    if (!menuOpen) {
      return;
    }

    const handleKeyDown = (event: KeyboardEvent) => {
      if (event.key === "Escape") {
        setMenuOpen(false);
      }
    };

    document.addEventListener("keydown", handleKeyDown);
    return () => document.removeEventListener("keydown", handleKeyDown);
  }, [menuOpen]);

  const handleLogout = async () => {
    setMenuOpen(false);
    setLoggingOut(true);
    setLogoutError("");

    try {
      await logout();
      navigate("/homepage");
    } catch {
      setLogoutError("Misslyckades att logga ut. Försök igen.");
    } finally {
      setLoggingOut(false);
    }
  };

  return (
    <header className="site-header">
      <div className="site-header__inner">
        <Link
          to="/homepage"
          className="site-header__logo-link"
          aria-label="Vart är vi? – startsida"
        >
          <img src={logo} alt="Vart är vi?" className="site-header__logo" />
        </Link>

        <div className="site-header__actions">
          {!loading &&
            (user ? (
              <>
                <Button
                  variant="ghost"
                  className="site-header__account-button"
                  onClick={() => navigate("/game")}
                >
                  Dagens Resa
                </Button>
                <Button
                  variant="ghost"
                  className="site-header__account-button"
                  onClick={() => navigate("/leaderboard")}
                >
                  Topplista
                </Button>

                <Button
                  variant="ghost"
                  className="site-header__login-button"
                  onClick={() => navigate("/profile")}
                >
                  Min profil
                </Button>

                <Button
                  variant="ghost"
                  className="site-header__account-button"
                  onClick={handleLogout}
                  disabled={loggingOut}
                >
                  {loggingOut ? "Loggar ut..." : "Logga ut"}
                </Button>
              </>
            ) : (
              <>
                <Button
                  variant="ghost"
                  className="site-header__login-button"
                  onClick={() => navigate("/login")}
                >
                  Logga in
                </Button>
                <Button
                  className="site-header__account-button"
                  onClick={() => navigate("/register")}
                >
                  Skapa konto
                </Button>
              </>
            ))}
        </div>

        {!loading && (
          <Button
            variant="ghost"
            size="icon"
            className="site-header__menu-toggle"
            onClick={() => setMenuOpen((isOpen) => !isOpen)}
            aria-label={menuOpen ? "Stäng meny" : "Öppna meny"}
            aria-expanded={menuOpen}
            aria-controls="site-header-mobile-menu"
          >
            {menuOpen ? <X /> : <Menu />}
          </Button>
        )}
      </div>

      {!loading && menuOpen && (
        <nav
          id="site-header-mobile-menu"
          className="site-header__mobile-menu"
          aria-label="Mobil navigering"
        >
          {user ? (
            <>
              <Button
                variant="ghost"
                className="site-header__mobile-menu-button"
                onClick={() => {
                  setMenuOpen(false);
                  navigate("/game");
                }}
              >
                Dagens Resa
              </Button>
              <Button
                variant="ghost"
                className="site-header__mobile-menu-button"
                onClick={() => {
                  setMenuOpen(false);
                  navigate("/leaderboard");
                }}
              >
                Topplista
              </Button>
              <Button
                variant="ghost"
                className="site-header__mobile-menu-button"
                onClick={() => {
                  setMenuOpen(false);
                  navigate("/profile");
                }}
              >
                Min profil
              </Button>
              <Button
                variant="ghost"
                className="site-header__mobile-menu-button"
                onClick={handleLogout}
                disabled={loggingOut}
              >
                {loggingOut ? "Loggar ut..." : "Logga ut"}
              </Button>
            </>
          ) : (
            <>
              <Button
                variant="ghost"
                className="site-header__mobile-menu-button"
                onClick={() => {
                  setMenuOpen(false);
                  navigate("/login");
                }}
              >
                Logga in
              </Button>
              <Button
                className="site-header__mobile-menu-button"
                onClick={() => {
                  setMenuOpen(false);
                  navigate("/register");
                }}
              >
                Skapa konto
              </Button>
            </>
          )}
        </nav>
      )}

      {logoutError && <p role="alert">{logoutError}</p>}
    </header>
  );
}

export default SiteHeader;
