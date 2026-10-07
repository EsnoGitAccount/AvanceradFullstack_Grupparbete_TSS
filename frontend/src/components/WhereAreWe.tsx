export default function WhereAreWe({onComplete} : {onComplete: (score: number) => void}) {

    return(
        <>
            <button onClick={() => {onComplete(10)}}> Var är vi? </button>
        </>
    )
}