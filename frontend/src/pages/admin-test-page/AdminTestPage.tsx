import { useState } from "react";
import { useAuth } from "../../context/auth/UseAuth";
import type { AdminCity } from "@/models/AdminModels";
import ListAdminCities from "../../components/admin-tasks/ListAdminCities";
import CreateCity from "../../components/admin-tasks/CreateCity";
import UpdateCity from "../../components/admin-tasks/UpdateCity";
import ArchiveCity from "../../components/admin-tasks/ArchiveCity";

export default function AdminTestPage() {
  const { user } = useAuth();
  const [cities, setCities] = useState<AdminCity[]>([]);

  const handleCityCreated = (createdCity: AdminCity) => {
    setCities((currentCities) => [...currentCities, createdCity]);
  };

  const handleCityUpdated = (updatedCity: AdminCity) => {
    setCities((currentCities) =>
      currentCities.map((city) =>
        city.cityId === updatedCity.cityId ? updatedCity : city,
      ),
    );
  };

  const handleCityArchived = (cityId: number) => {
    setCities((currentCities) =>
      currentCities.map((city) =>
        city.cityId === cityId ? { ...city, isArchived: true } : city,
      ),
    );
  };

  return (
    <div>
      <h1>Admin tester</h1>

      <p>Du är inloggad som: {user?.username}</p>

      <p>Ändringar här påverkar data i databasen.</p>

      <section>
        <h2>Städer</h2>

        <ListAdminCities cities={cities} onCitiesLoaded={setCities} />

        <CreateCity onCityCreated={handleCityCreated} />

        <UpdateCity cities={cities} onCityUpdated={handleCityUpdated} />

        <ArchiveCity cities={cities} onCityArchived={handleCityArchived} />
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
