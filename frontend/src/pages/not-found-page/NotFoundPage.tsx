import { Card } from "../../components/ui/Card";
import pageNotFoundTrain from "../../assets/illustrations/PageNotFoundTrain.svg";

export default function NotFoundPage() {
  return (
    <section className="not-found-page status-page" aria-label="Sidan hittades inte">
      <Card className="status-page__card">
        <h1 className="page-title">Här finns inga spår</h1>
        <img
          className="status-page__image"
          src={pageNotFoundTrain}
          alt="Ett tåg som har hamnat vid fel spår"
        />
      </Card>
    </section>
  );
}
