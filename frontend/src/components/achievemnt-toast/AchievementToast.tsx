import "./AchievementToast.css";
import { toast } from "sonner";

interface AchievementToastProps {
  achievement: {
    title: string;
    description: string;
    icon: string;
  };
}
// TODO: Trigger achievement notifications when the backend
// returns newly unlocked achievements after saving a game.
export const showAchievementToast = (
  achievement: AchievementToastProps["achievement"],
) => {
  toast.custom(() => <AchievementToast achievement={achievement} />, {
    duration: 5000,
  });
};

const AchievementToast = ({ achievement }: AchievementToastProps) => {
  return (
    <div className="achievement-toast">
      <img src={achievement.icon} alt="" className="achievement-toast__icon" />
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
