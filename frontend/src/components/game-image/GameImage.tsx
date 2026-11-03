import { useState } from 'react'
import TrainLoading from '@/components/train-loading/TrainLoading'
import placeholder from '@/assets/images/photo-example.jpg'
import './GameImage.css'

type GameImageProps = {
  src: string
  alt: string
  className?: string
}

export default function GameImage(props: GameImageProps) {
  return <ImageWithLoading key={props.src} {...props} />
}

function ImageWithLoading({ src, alt, className = '' }: GameImageProps) {
  const [status, setStatus] = useState<'loading' | 'loaded' | 'error'>('loading')
  const [usePlaceholder, setUsePlaceholder] = useState(false)

  return (
    <div className={`game-image ${className}`} aria-busy={status === 'loading'}>
      {status === 'loading' && (
        <div className="game-image__fallback"><TrainLoading /></div>
      )}
      {status === 'error' && <p role="status">Bilden kunde inte laddas.</p>}
      <img
        className="game-image__photo"
        src={usePlaceholder ? placeholder : src}
        alt={alt}
        style={{ visibility: status === 'loaded' ? 'visible' : 'hidden' }}
        onLoad={() => setStatus('loaded')}
        onError={() => {
          if (!usePlaceholder && src !== placeholder) {
            setUsePlaceholder(true)
          } else {
            setStatus('error')
          }
        }}
      />
    </div>
  )
}
