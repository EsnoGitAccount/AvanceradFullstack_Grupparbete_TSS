
import { AchievementIcon } from "@/components/achievement-icon/AchievementIcon";
import "./AchievementToast.css";

interface AchievementToastProps {
  achievement: {
    title: string;
    description: string;
    icon: string;
  };
}

const AchievementToast = ({ achievement }: AchievementToastProps) => {
  return (
    <div className="achievement-toast">
      <AchievementIcon imageKey={achievement.icon} name={achievement.title} achieved={true} />
      <div className="achievement-toast__content">
        <h4 className="achievement-toast__title">{achievement.title}</h4>
        <p className="achievement-toast__description">
          {achievement.description}
        </p>
      </div>
    </div>
  );
};

export default AchievementToast;
