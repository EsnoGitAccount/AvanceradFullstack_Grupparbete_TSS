import { useState, type ReactNode } from "react";
import { Button } from "@/components/ui/Button";
import TrainLoading from "@/components/train-loading/TrainLoading";
import { useAdminData } from "@/hooks/useAdminData";
import { getAdminCities, getAdminUsers, getAdminGames } from "@/services/AdminService";
import { useAuth } from "../../context/auth/UseAuth";
import type {
  AdminCity,
  CityQuestionsUpdate,
} from "@/models/AdminModels";
import CreateCityContent from "../../components/admin-tasks/CreateCityContent";
import CreateCity from "../../components/admin-tasks/CreateCity";
import UpdateCity from "../../components/admin-tasks/UpdateCity";
import ArchiveCity from "../../components/admin-tasks/ArchiveCity";
import RestoreCity from "../../components/admin-tasks/RestoreCity";
import GetCityQuestions from "../../components/admin-tasks/GetCityQuestions";
import UpdateCityQuestions from "../../components/admin-tasks/UpdateCityQuestions";
import ArchiveUser from "../../components/admin-tasks/ArchiveUser";
import RestoreUser from "../../components/admin-tasks/RestoreUser";
import DeleteGame from "../../components/admin-tasks/DeleteGame";
import UploadImage from "../../components/admin-tasks/UploadImage";
import DeleteImage from "../../components/admin-tasks/DeleteImage";
import "./AdminPage.css";

const adminTabs = [
  { id: "cities", label: "Städer" },
  { id: "questions", label: "Frågor & ledtrådar" },
  { id: "users", label: "Användare" },
  { id: "games", label: "Spelresultat" },
  { id: "images", label: "Bilder" },
] as const;

type AdminTab = (typeof adminTabs)[number]["id"];

function AdminDataState({ loading, error, retry, children }: {
  loading: boolean;
  error: string | null;
  retry: () => void;
  children: ReactNode;
}) {
  if (loading) {
    return (
      <div className="admin-page__loading">
        <TrainLoading label="Laddar administrationsdata" />
      </div>
    );
  }
  if (error) {
    return (
      <div className="admin-page__load-error">
        <p role="alert">{error}</p>
        <Button type="button" onClick={retry}>Försök igen</Button>
      </div>
    );
  }
  return children;
}

export default function AdminPage() {
  const { user } = useAuth();

  const [activeTab, setActiveTab] = useState<AdminTab>("cities");

  const usersData = useAdminData(getAdminUsers);
  const { data: users, setData: setUsers } = usersData;

  const citiesData = useAdminData(getAdminCities);
  const { data: cities, setData: setCities } = citiesData;

  const [questionCityId, setQuestionCityId] = useState<number | null>(null);

  const gamesData = useAdminData(getAdminGames);
  const { data: games, setData: setGames } = gamesData;

  const [questionsBusy, setQuestionsBusy] = useState(false);
  const [questionRevision, setQuestionRevision] = useState(0);
  const [imageBusy, setImageBusy] = useState(false);

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
    setQuestionRevision((revision) => revision + 1);
    setQuestionCityId(cityId);
    setCityQuestions(questions);
    setQuestionDraft(structuredClone(questions));
  };

  const questionsDirty = JSON.stringify(questionDraft) !== JSON.stringify(cityQuestions);

  const handleQuestionsSaved = (cityId: number, questions: CityQuestionsUpdate) => {
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

        <AdminDataState {...citiesData}>
          <div className="admin-page__grid">
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
        </AdminDataState>
      </section>

      <section
        id="admin-panel-questions"
        className="admin-page__section"
        role="tabpanel"
        aria-labelledby="admin-tab-questions"
        hidden={activeTab !== "questions"}
      >
        <h2>Frågor &amp; ledtrådar</h2>

        <AdminDataState {...citiesData}>
          <div className="admin-page__grid">
            <div className="admin-page__card admin-page__card--wide admin-page__card--compact">
              <GetCityQuestions
                cities={cities}
                disabled={questionsBusy}
                onLoadingChange={setQuestionsBusy}
                onQuestionsLoaded={handleQuestionsLoaded}
              />
            </div>

            <div className="admin-page__card admin-page__card--wide admin-page__card--editor">
              {questionCityId !== null && cityQuestions && (cityQuestions.questions.length !== 2 || cityQuestions.clues.length !== 5 || cityQuestions.questions.some((question) => question.options.length !== 4)) ? (
                <CreateCityContent
                  key={questionRevision}
                  cityId={questionCityId}
                  initialContent={cityQuestions}
                  cityName={cities.find((city) => city.cityId === questionCityId)?.name}
                  busy={questionsBusy}
                  onLoadingChange={setQuestionsBusy}
                  onContentCreated={handleQuestionsLoaded}
                />
              ) : (
                <UpdateCityQuestions
                  key={questionRevision}
                  cityId={questionCityId}
                  cityName={cities.find((city) => city.cityId === questionCityId)?.name}
                  busy={questionsBusy}
                  dirty={questionsDirty}
                  onLoadingChange={setQuestionsBusy}
                  questions={questionDraft}
                  onQuestionsChange={setQuestionDraft}
                  onQuestionsSaved={handleQuestionsSaved}
                />
              )}
            </div>
          </div>
        </AdminDataState>
      </section>

      <section
        id="admin-panel-users"
        className="admin-page__section"
        role="tabpanel"
        aria-labelledby="admin-tab-users"
        hidden={activeTab !== "users"}
      >
        <h2>Användare</h2>

        <AdminDataState {...usersData}>
          <div className="admin-page__grid">
            <div className="admin-page__card admin-page__card--destructive">
              <ArchiveUser users={users} onUserArchived={handleUserArchived} />
            </div>

            <div className="admin-page__card admin-page__card--success">
              <RestoreUser users={users} onUserRestored={handleUserRestored} />
            </div>
          </div>
        </AdminDataState>
      </section>

      <section
        id="admin-panel-games"
        className="admin-page__section"
        role="tabpanel"
        aria-labelledby="admin-tab-games"
        hidden={activeTab !== "games"}
      >
        <h2>Spelresultat</h2>

        <AdminDataState {...gamesData}>
          <div className="admin-page__grid">
            <div className="admin-page__card admin-page__card--destructive">
              <DeleteGame games={games} onGameDeleted={handleGameDeleted} />
            </div>
          </div>
        </AdminDataState>
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
            <UploadImage onImageUploaded={setImageBlobName} busy={imageBusy} onLoadingChange={setImageBusy} />
          </div>

          <div className="admin-page__card admin-page__card--destructive">
            <DeleteImage
              busy={imageBusy}
              onLoadingChange={setImageBusy}
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
