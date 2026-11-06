import { useState } from "react";
import { useAuth } from "../../context/auth/UseAuth";
import type {
  AdminCity,
  AdminGameResult,
  AdminUser,
  CityQuestionsUpdate,
} from "@/models/AdminModels";
import ListAdminCities from "../../components/admin-tasks/ListAdminCities";
import CreateCity from "../../components/admin-tasks/CreateCity";
import UpdateCity from "../../components/admin-tasks/UpdateCity";
import ArchiveCity from "../../components/admin-tasks/ArchiveCity";
import RestoreCity from "../../components/admin-tasks/RestoreCity";
import GetCityQuestions from "../../components/admin-tasks/GetCityQuestions";
import UpdateCityQuestions from "../../components/admin-tasks/UpdateCityQuestions";
import ListAdminUsers from "../../components/admin-tasks/ListAdminUsers";
import ArchiveUser from "../../components/admin-tasks/ArchiveUser";
import RestoreUser from "../../components/admin-tasks/RestoreUser";
import ListAdminGames from "../../components/admin-tasks/ListAdminGames";
import DeleteGame from "../../components/admin-tasks/DeleteGame";

export default function AdminTestPage() {
  const { user } = useAuth();

  const [users, setUsers] = useState<AdminUser[]>([]);

  const [cities, setCities] = useState<AdminCity[]>([]);

  const [questionCityId, setQuestionCityId] = useState<number | null>(null);

  const [games, setGames] = useState<AdminGameResult[]>([]);

  const [cityQuestions, setCityQuestions] =
    useState<CityQuestionsUpdate | null>(null);

  const [questionDraft, setQuestionDraft] =
    useState<CityQuestionsUpdate | null>(null);

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

  const handleCityRestored = (cityId: number) => {
    setCities((currentCities) =>
      currentCities.map((city) =>
        city.cityId === cityId ? { ...city, isArchived: false } : city,
      ),
    );
  };

  const handleQuestionsLoaded = (
    cityId: number,
    questions: CityQuestionsUpdate,
  ) => {
    setQuestionCityId(cityId);
    setCityQuestions(questions);
    setQuestionDraft(structuredClone(questions));
  };

  const handleUserArchived = (userId: number) => {
    setUsers((currentUsers) =>
      currentUsers.map((user) =>
        user.userId === userId ? { ...user, isArchived: true } : user,
      ),
    );
  };

  const handleUserRestored = (userId: number) => {
    setUsers((currentUsers) =>
      currentUsers.map((user) =>
        user.userId === userId ? { ...user, isArchived: false } : user,
      ),
    );
  };

  const handleGameDeleted = (gameId: number) => {
    setGames((currentGames) =>
      currentGames.filter((game) => game.gameId !== gameId),
    );
  };

  return (
    <div>
      <h1>Administration</h1>

      <p>Inloggad som: {user?.username}</p>

      <p>Ändringar sparas direkt.</p>

      <section>
        <h2>Städer</h2>

        <ListAdminCities cities={cities} onCitiesLoaded={setCities} />

        <CreateCity onCityCreated={handleCityCreated} />

        <UpdateCity cities={cities} onCityUpdated={handleCityUpdated} />

        <ArchiveCity cities={cities} onCityArchived={handleCityArchived} />

        <RestoreCity cities={cities} onCityRestored={handleCityRestored} />
      </section>

      <section>
        <h2>Frågor</h2>

        <GetCityQuestions
          cities={cities}
          loadedCityId={questionCityId}
          questions={cityQuestions}
          onQuestionsLoaded={handleQuestionsLoaded}
        />

        <UpdateCityQuestions
          cityId={questionCityId}
          questions={questionDraft}
          onQuestionsChange={setQuestionDraft}
          onQuestionsSaved={handleQuestionsLoaded}
        />
      </section>

      <section>
        <h2>Användare</h2>

        <ListAdminUsers users={users} onUsersLoaded={setUsers} />

        <ArchiveUser users={users} onUserArchived={handleUserArchived} />

        <RestoreUser users={users} onUserRestored={handleUserRestored} />
      </section>

      <section>
        <h2>Spelresultat</h2>

        <ListAdminGames games={games} onGamesLoaded={setGames} />

        <DeleteGame games={games} onGameDeleted={handleGameDeleted} />
      </section>

      <section>
        <h2>Bilder</h2>
      </section>
    </div>
  );
}
