
import {Card, CardContent, CardHeader, CardTitle, CardFooter} from '@/components/ui/Card'
import { Button } from '@/components/ui/Button'
import { Ticket } from 'lucide-react';
import photoExample from '@/assets/images/photo-example.jpg';
import './StartGameTest.css';

const gameInstructions = [
    {id:1,text: "5 oberoende frågor om Sverige – en vid varje stopp."},
    {id:2,text: "Skriv ditt svar själv. Du får en gissning per fråga."},
    {id:3,text: "Varje rätt svar ger 10 poäng. Fel svar ger 0 poäng."},
    {id:4,text: "Efter varje gissning visas rätt svar. Fortsätt sedan till nästa stopp."},
    {id:5,text: "Du kan spela en gång per dag. Nästa resa öppnar i morgon."},
];

function StartGameTest() {

    const currentDate = new Date().toLocaleDateString('sv-SE', {
        day:"numeric",
        month:"long",
        year:"numeric"
    });

  return (


<div className="start-game-test-page">

    <div className="start-game-test"> 

        <header className="start-game-test__header">
            <span className="start-game-test__date">DAGENS SPEL · {currentDate}</span>
            <h1 className='start-game-test__title'>Alla ombord!</h1>

            <p className="start-game-test__description">Fem stopp, fem chanser att visa hur väl du känner Sverige.</p>           
        </header>

        <div className="start-game-test__layout">

        <Card className="start-game-test__card">  
            <CardHeader>
                <div className="start-game-test__ticket"> 
                 <span className="start-game-test__ticket-number">DIN BILJETT · NR 281</span>
                <span className="start-game-test__points">Max 50 poäng</span>
                </div>
                <CardTitle>Så går dagens resa till</CardTitle>
            </CardHeader>

            <CardContent>
            
        <div className="start-game-test__instructions">
            
                {gameInstructions.map((instruction) => (
                    <div key={instruction.id} className="start-game-test__instruction">
                        <div className="flex h-10 w-10 items-center justify-center rounded-full bg-neutral-200 text-teal-700 font-bold">
                            {String(instruction.id).padStart(2, '0')} 
                        </div>
                        <p className="flex-1 text-sm text-cyan">{instruction.text}</p>
                    </div>
                ))}
          
        </div>
            </CardContent>


            <CardFooter className="start-game-test__footer">
                <Button  size="lg" className="h-10 w-full">
                    Starta resan
                </Button>
                <p className="text-xs text-muted-foreground">
                    Ingen tidspress. Din första gissning räknas.
                </p>
            </CardFooter>
        </Card>
       
        

         <div className="start-game-test__sidebar">

        <div className="w-full aspect-video overflow-hidden rounded-3xl">
            <img src={photoExample} alt="Swedish train station" className="start-game-test__image"/>

            
        </div>
       <Card className="start-game-test__info-card">
                <CardHeader className="start-game-test__info-header">
                    <Ticket  size={20}  className="start-game-test__info-icon"/>
                    <CardTitle className="start-game-test__info-title">Res lätt. Tänk stort.</CardTitle>
                </CardHeader>
                
                <div className="start-game-test__ticket-divider" />

                <CardContent>
                    <p className="start-game-test__info-description">
                        Du behöver bara din nyfikenhet.
                        Bokstävernas storlek spelar ingen roll,
                        och vanliga stavningsvarianter godkänns.
                    </p>
                    </CardContent>
        </Card>
         </div>
       
            </div>
        </div>
</div>
  )
}








export default StartGameTest