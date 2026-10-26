export type TimeOfDay = 'dawn' | 'day' | 'dusk' | 'night';

export function getTimeOfDay(): TimeOfDay {
    const currentHour = new Date().getHours();
    if (currentHour >= 5 && currentHour < 10) {
        return 'dawn'
    } else if (currentHour >= 10 && currentHour < 17) {
        return 'day'
    } else if (currentHour >= 17 && currentHour < 22) {
        return 'dusk'
    } else {
        return 'night'
    }
}
