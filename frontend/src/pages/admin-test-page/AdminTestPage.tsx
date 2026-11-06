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
import UploadImage from "../../components/admin-tasks/UploadImage";
import DeleteImage from "../../components/admin-tasks/DeleteImage";
import "./AdminTestPage.css";

const adminTabs = [
  { id: "cities", label: "Städer" },
  { id: "questions", label: "Frågor" },
  { id: "users", label: "Användare" },
  { id: "games", label: "Spelresultat" },
  { id: "images", label: "Bilder" },
] as const;

type AdminTab = (typeof adminTabs)[number]["id"];

export default function AdminTestPage() {
  const { user } = useAuth();

  const [activeTab, setActiveTab] = useState<AdminTab>("cities");

  const [users, setUsers] = useState<AdminUser[]>([]);

  const [cities, setCities] = useState<AdminCity[]>([]);

  const [questionCityId, setQuestionCityId] = useState<number | null>(null);

  const [games, setGames] = useState<AdminGameResult[]>([]);

  const [imageBlobName, setImageBlobName] = useState("");

  const handleImageDeleted = () => {
    setImageBlobName("");
  };

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
    <div className="admin-page">
      <header className="admin-page__header">
        <h1>Administration</h1>

        <p>Inloggad som: {user?.username}</p>

        <p className="admin-page__warning">Ändringar sparas direkt.</p>
      </header>

      <div className="admin-page__tabs" role="tablist" aria-label="Adminområden">
        {adminTabs.map((tab) => (
          <button
            key={tab.id}
            id={`admin-tab-${tab.id}`}
            className={`admin-page__tab${activeTab === tab.id ? " admin-page__tab--active" : ""}`}
            type="button"
            role="tab"
            aria-selected={activeTab === tab.id}
            aria-controls={`admin-panel-${tab.id}`}
            onClick={() => setActiveTab(tab.id)}
          >
            {tab.label}
          </button>
        ))}
      </div>

      <section
        id="admin-panel-cities"
        className="admin-page__section"
        role="tabpanel"
        aria-labelledby="admin-tab-cities"
        hidden={activeTab !== "cities"}
      >
        <h2>Städer</h2>

        <div className="admin-page__grid">
          <div className="admin-page__fetch admin-page__fetch--wide">
            <ListAdminCities cities={cities} onCitiesLoaded={setCities} />
          </div>

          <div className="admin-page__card">
            <CreateCity onCityCreated={handleCityCreated} />
          </div>

          <div className="admin-page__card">
            <UpdateCity cities={cities} onCityUpdated={handleCityUpdated} />
          </div>

          <div className="admin-page__card admin-page__card--destructive">
            <ArchiveCity cities={cities} onCityArchived={handleCityArchived} />
          </div>

          <div className="admin-page__card admin-page__card--success">
            <RestoreCity cities={cities} onCityRestored={handleCityRestored} />
          </div>
        </div>
      </section>

      <section
        id="admin-panel-questions"
        className="admin-page__section"
        role="tabpanel"
        aria-labelledby="admin-tab-questions"
        hidden={activeTab !== "questions"}
      >
        <h2>Frågor</h2>

        <div className="admin-page__grid">
          <div className="admin-page__card admin-page__card--wide admin-page__card--results">
            <GetCityQuestions
              cities={cities}
              loadedCityId={questionCityId}
              questions={cityQuestions}
              onQuestionsLoaded={handleQuestionsLoaded}
            />
          </div>

          <div className="admin-page__card admin-page__card--wide admin-page__card--editor">
            <UpdateCityQuestions
              cityId={questionCityId}
              questions={questionDraft}
              onQuestionsChange={setQuestionDraft}
              onQuestionsSaved={handleQuestionsLoaded}
            />
          </div>
        </div>
      </section>

      <section
        id="admin-panel-users"
        className="admin-page__section"
        role="tabpanel"
        aria-labelledby="admin-tab-users"
        hidden={activeTab !== "users"}
      >
        <h2>Användare</h2>

        <div className="admin-page__grid">
          <div className="admin-page__fetch admin-page__fetch--wide">
            <ListAdminUsers users={users} onUsersLoaded={setUsers} />
          </div>

          <div className="admin-page__card admin-page__card--destructive">
            <ArchiveUser users={users} onUserArchived={handleUserArchived} />
          </div>

          <div className="admin-page__card admin-page__card--success">
            <RestoreUser users={users} onUserRestored={handleUserRestored} />
          </div>
        </div>
      </section>

      <section
        id="admin-panel-games"
        className="admin-page__section"
        role="tabpanel"
        aria-labelledby="admin-tab-games"
        hidden={activeTab !== "games"}
      >
        <h2>Spelresultat</h2>

        <div className="admin-page__grid">
          <div className="admin-page__fetch admin-page__fetch--wide">
            <ListAdminGames games={games} onGamesLoaded={setGames} />
          </div>

          <div className="admin-page__card admin-page__card--destructive">
            <DeleteGame games={games} onGameDeleted={handleGameDeleted} />
          </div>
        </div>
      </section>

      <section
        id="admin-panel-images"
        className="admin-page__section"
        role="tabpanel"
        aria-labelledby="admin-tab-images"
        hidden={activeTab !== "images"}
      >
        <h2>Bilder</h2>

        <div className="admin-page__grid">
          <div className="admin-page__card">
            <UploadImage onImageUploaded={setImageBlobName} />
          </div>

          <div className="admin-page__card admin-page__card--destructive">
            <DeleteImage
              blobName={imageBlobName}
              onBlobNameChange={setImageBlobName}
              onImageDeleted={handleImageDeleted}
            />
          </div>
        </div>
      </section>
    </div>
  );
}
