export interface City {
  name: string;
  cityPicture: string | null;
  questions: Question[];
  clues: Clue[];
}

export interface Question {
  questionText: string;
  options: Option[];
}

export interface Clue {
  clueText: string;
  point: number;
}

export interface Option {
  optionText: string;
  isCorrect: boolean;
}

export const testCity: City = {
  name: "Stockholm",
  cityPicture: "https://start.stockholm/optimized/large/globalassets/stockholms-stadshus-vinter-riddarfjarden.jpg",
  questions: [
    {
      questionText: "Vilken är den äldsta tunnelbane linjen som går igenom staden?",
      options: [
        {
          optionText: "Gröna linjen",
          isCorrect: true
        },
                {
          optionText: "Röda linjen",
          isCorrect: false
        },
                {
          optionText: "Blåa linjen",
          isCorrect: false
        },
                {
          optionText: "Gula linjen",
          isCorrect: false
        }
      ]
    },
    {
      questionText: "På vilken av stockholms öar ligger stadshuset?",
      options: [
        {
          optionText: "Södermalm",
          isCorrect: false
        },
        {
          optionText: "Djurgården",
          isCorrect: false
        },
        {
          optionText: "Skeppsholmen",
          isCorrect: false
        },
        {
          optionText: "Kungsholmen",
          isCorrect: true
        }
      ],
    }
  ],
  clues: [
    {
      clueText: "Vi reser till en stad mellan en stor insjö och Östersjön.",
      point: 10
    },
    {
      clueText: "Här finns en kunglig bostad och byggnaden där Nobelbanketten hålls.",
      point: 8
    },
    {
      clueText: "Ett välbevarat krigsskepp från 1600-talet finns på ett museum här.",
      point: 6
    },
    {
      clueText: "Gamla stan och Djurgården är välkända delar av staden.",
      point: 4
    },
    {
      clueText: "Vi söker Sveriges huvudstad.",
      point: 2
    }
  ]
}