export default function DestinationQuestion({onComplete} : {onComplete: (score: number) => void}) {

    return(
        <>
            <button onClick={() => {onComplete(10)}}> Svara på destinations frågan </button>
        </>
    )
}