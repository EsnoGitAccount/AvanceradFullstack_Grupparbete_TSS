import type { DailyChallenge } from '@/models/DailyChallenge'
import aldorPortrait from '@/assets/images/aldor.png'

// Byt ledtrådar, frågor och bild här när ni vill anpassa Aldor-läget.
// Programmeringsfrågorna är exempel, inte påståenden om Aldors privatliv.
export const ALDOR_PORTRAIT = aldorPortrait

export const ALDOR_CHALLENGE: DailyChallenge = {
  challangeDate: '',
  cityDetails: {
    cityName: 'Aldor',
    cityPicture: undefined,
    clues: [
      { pointValue: 10, clueText: 'Den här gången söker vi en person i stället för en stad.' },
      { pointValue: 8, clueText: 'Det är en lärare som ni känner från utbildningen.' },
      { pointValue: 6, clueText: 'Personen syns på bilden bredvid ledtrådarna.' },
      { pointValue: 4, clueText: 'Namnet börjar på A och har fem bokstäver.' },
      { pointValue: 2, clueText: 'Förnamnet slutar på bokstaven R.' },
    ],
    questions: [
      {
        questionText: 'Aldors kodquiz: Vad används ett interface till i C#?',
        options: [
          { optionText: 'Att beskriva ett kontrakt som klasser kan implementera', isCorrect: true },
          { optionText: 'Att automatiskt skapa en databas', isCorrect: false },
          { optionText: 'Att ändra färgen på alla knappar', isCorrect: false },
          { optionText: 'Att starta om servern', isCorrect: false },
        ],
      },
      {
        questionText: 'Aldors kodquiz: Vad används useState till i React?',
        options: [
          { optionText: 'Att spara filer i Git', isCorrect: false },
          { optionText: 'Att hantera en komponents tillstånd', isCorrect: true },
          { optionText: 'Att skapa en SQL-tabell', isCorrect: false },
          { optionText: 'Att installera npm-paket', isCorrect: false },
        ],
      },
    ],
  },
}
