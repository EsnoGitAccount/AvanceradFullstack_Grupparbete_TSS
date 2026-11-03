import './AchievementIcon.css';

const achievementImages = import.meta.glob('../../assets/achievements/*.svg', {
    eager: true,
    import: 'default',
    query: '?url',
}) as Record<string, string>;

interface AchievementIconProps {
    imageKey: string;
    name: string;
    achieved?: boolean;
}

export function AchievementIcon({
    imageKey,
    name,
    achieved = false,
}: AchievementIconProps) {
    const image = (
        <img
            src={achievementImages[`../../assets/achievements/${imageKey}.svg`]}
            alt={name}
            className={[
                'w-16 h-16 shrink-0 object-contain transition-all',
                achieved ? 'achievement-glow' : 'grayscale opacity-40',
                achieved ? 'relative z-10' : ''
            ].join(' ')}
        />
    );

    return achieved ? (
        <span className='achievement-icon-wrapper relative inline-flex w-16 h-16 shrink-0'>
            <img
                src={achievementImages['../../assets/achievements/AchievementGlow.svg']}
                alt=''
                aria-hidden='true'
                className='achievement-icon-effect'
            />
            {image}
        </span>
    ) : (
        image
    );
}