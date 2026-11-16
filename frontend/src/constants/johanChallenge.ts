import type { DailyChallenge } from '@/models/DailyChallenge'
import johanPortrait from '@/assets/images/johan.png'

export const JOHAN_PORTRAIT = johanPortrait

// Anpassa ledtrådar, frågor och bild här.
// Scrum-frågorna utgår från https://scrumguides.org/scrum-guide.html
export const JOHAN_CHALLENGE: DailyChallenge = {
  challangeDate: '',
  cityDetails: {
    cityName: 'Johan',
    cityPicture: undefined,
    clues: [
      { pointValue: 10, clueText: 'Vi söker en person som lär er om samarbete och förbättring av arbetssätt.' },
      { pointValue: 8, clueText: 'Det är er lärare i agilt arbete.' },
      { pointValue: 6, clueText: 'Läraren syns på bilden bredvid ledtrådarna.' },
      { pointValue: 4, clueText: 'Förnamnet börjar på J och har fem bokstäver.' },
      { pointValue: 2, clueText: 'Förnamnet slutar på bokstaven N.' },
    ],
    questions: [
      {
        questionText: 'Johans agila quiz: Vad är syftet med Sprint Retrospective i Scrum?',
        options: [
          { optionText: 'Att visa sprintens resultat för intressenter', isCorrect: false },
          { optionText: 'Att planera förbättringar av kvalitet och effektivitet', isCorrect: true },
          { optionText: 'Att fördela all arbetstid för resten av året', isCorrect: false },
          { optionText: 'Att bestämma vem som ska få skulden för problem', isCorrect: false },
        ],
      },
      {
        questionText: 'Johans agila quiz: Vad är en Product Backlog i Scrum?',
        options: [
          { optionText: 'En lista med enbart färdiga uppgifter', isCorrect: false },
          { optionText: 'En fast projektplan som aldrig får ändras', isCorrect: false },
          { optionText: 'En framväxande, ordnad lista över det som behövs för att förbättra produkten', isCorrect: true },
          { optionText: 'Ett protokoll från senaste Daily Scrum', isCorrect: false },
        ],
      },
    ],
  },
}
