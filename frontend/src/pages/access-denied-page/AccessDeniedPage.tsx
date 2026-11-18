import { Card } from "../../components/ui/Card";

export default function AccessDeniedPage() {
  return (
    <section className="access-denied-page status-page" aria-label="Åtkomst nekad">
      <Card className="status-page__card">
        <h1 className="page-title">Här får bara lokförare vara</h1>
        {/* Add the illustration and animation here. */}
      </Card>
    </section>
  );
}
