import { Card } from "../../components/ui/Card";
import restrictedTrain from "../../assets/illustrations/RestrictedTrain.svg";

export default function AccessDeniedPage() {
  return (
    <section className="access-denied-page status-page" aria-label="Åtkomst nekad">
      <Card className="status-page__card">
        <h1 className="page-title">Endast för lokförare</h1>
        <img
          className="status-page__image"
          src={restrictedTrain}
          alt="Ett tåg som står bakom en stängd bom"
        />
      </Card>
    </section>
  );
}
