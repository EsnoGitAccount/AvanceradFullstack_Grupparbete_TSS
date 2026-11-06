import { useAuth } from "../../context/auth/UseAuth";

export default function AdminTestPage() {
  const { user } = useAuth();

  return (
    <div>
      <h1>Admin tester</h1>

      <p>Du är inloggad som: {user?.username}</p>

      <p>Ändringar här påverkar data i databasen.</p>

      <section>
        <h2>Städer</h2>
      </section>

      <section>
        <h2>Frågor</h2>
      </section>

      <section>
        <h2>Användare</h2>
      </section>

      <section>
        <h2>Spelresultat</h2>
      </section>

      <section>
        <h2>Bilder</h2>
      </section>
    </div>
  );
}
