import { Card, CardContent } from "@/components/ui/Card";
import { AchievementIcon } from "@/components/achievement-icon/AchievementIcon";
import { type AchievementDto } from "@/services/ProfileService";
import { useState } from "react";
import { Button } from "@/components/ui/Button";

interface AchievementsSectionProps {
  achievements: AchievementDto[];
  unachievedAchievements: AchievementDto[];
}

export function AchievementsSection({
  achievements,
  unachievedAchievements,
}: AchievementsSectionProps) {
  const [showAllEarned, setShowAllEarned] = useState(false);
  const [showAllUnearned, setShowAllUnearned] = useState(false);

  return (
    <Card className="mt-8 bg-[var(--card)] border-[var(--card-border)] rounded-[20px] p-6 md:p-8 shadow-[0_2px_8px_rgba(0,0,0,0.02)]">
      <CardContent className="p-0">
        <h2 className="text-[1.75rem] font-extrabold text-[var(--foreground)] mb-6">
          Dina utmärkelser
        </h2>

        <div className="achievements-grid">
          {achievements.length > 0 ? (
            achievements.map((ach, index) => (
              <div
                key={index}
                className={`achievement-tile bg-[var(--green-card)] rounded-2xl p-5 ${index >= 4 && !showAllEarned ? "achievement-tile--mobile-hidden" : ""}`}
              >
                <div className="flex items-start gap-4">
                  <AchievementIcon
                    imageKey={ach.imageKey}
                    name={ach.name}
                    achieved={true}
                  />
                  <div>
                    <h4 className="text-base font-bold text-[var(--foreground)] mb-1">
                      {ach.name}
                    </h4>
                    <p className="text-[0.825rem] text-[var(--chart-4)] leading-snug m-0">
                      {ach.description}
                    </p>
                  </div>
                </div>
              </div>
            ))
          ) : (
            <p className="text-sm text-[var(--chart-4)]">
              Inga utmärkelser ännu.
            </p>
          )}
        </div>

        {achievements.length > 4 && (
          <Button
            type="button"
            variant="outline"
            className="achievements-toggle"
            aria-expanded={showAllEarned}
            onClick={() => setShowAllEarned((prev) => !prev)}
          >
            {showAllEarned ? "Visa färre" : "Visa alla"}
          </Button>
        )}

        <h3 className="text-[1.5rem] font-bold text-[var(--foreground)] mt-8 mb-6">
          Kvar att uppnå
        </h3>
        <div className="achievements-grid">
          {unachievedAchievements.length > 0 ? (
            unachievedAchievements.map((ach, index) => (
              <div
                key={index}
                className={`achievement-tile bg-[var(--green-card)] rounded-2xl p-5 ${index >= 4 && !showAllUnearned ? "achievement-tile--mobile-hidden" : ""}`}
              >
                <div className="flex items-start gap-4">
                  <AchievementIcon
                    imageKey={ach.imageKey}
                    name={ach.name}
                    achieved={false}
                  />
                  <div>
                    <h4 className="text-base font-bold text-[var(--foreground)] mb-1">
                      {ach.name}
                    </h4>
                    <p className="text-[0.825rem] text-[var(--chart-4)] leading-snug m-0">
                      {ach.description}
                    </p>
                  </div>
                </div>
              </div>
            ))
          ) : (
            <p className="text-sm text-[var(--chart-4)]">
              Inga utmärkelser ännu.
            </p>
          )}
        </div>

        {unachievedAchievements.length > 4 && (
          <Button
            type="button"
            variant="outline"
            className="achievements-toggle"
            aria-expanded={showAllUnearned}
            onClick={() => setShowAllUnearned((prev) => !prev)}
          >
            {showAllUnearned ? "Visa färre" : "Visa alla"}
          </Button>
        )}
      </CardContent>
    </Card>
  );
}
