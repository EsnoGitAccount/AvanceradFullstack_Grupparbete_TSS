import { Card } from "../../components/ui/Card";

export default function NotFoundPage() {
  return (
    <section className="not-found-page status-page" aria-label="Sidan hittades inte">
      <Card className="status-page__card">
        <h1 className="page-title">404</h1>
        {/* Add the illustration and animation here. */}
      </Card>
    </section>
  );
}
