import {toast} from "sonner";
import AchievementToast from "./AchievementToast";



interface AchievementToastProps {
  achievement: {
    title: string;
    description: string;
    icon: string;
  };
}

export const showAchievementToast = (
  achievement: AchievementToastProps["achievement"],
) => {
  toast.custom(() => <AchievementToast achievement={achievement} />, {
    duration: 3000,
  });
};