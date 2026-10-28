export interface City {
  cityName: string;
  cityPicture: string | null;
  questions: Question[];
  clues: Clue[];
}

// TO DO: This is to match the object type used in cityDetailDto. Either this or City type should probably be removed
export interface CityDetail {
  cityName: string;
  cityPicture:string | undefined;
  questions: Question[];
  clues: Clue[];
}

export interface Question {
  questionText: string;
  options: Option[];
}

export interface Clue {
  clueText: string;
  pointValue: number;
}

export interface Option {
  optionText: string;
  isCorrect: boolean;
}

export const testCity: City = {
  cityName: "Stockholm",
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
      pointValue: 10
    },
    {
      clueText: "Här finns en kunglig bostad och byggnaden där Nobelbanketten hålls.",
      pointValue: 8
    },
    {
      clueText: "Ett välbevarat krigsskepp från 1600-talet finns på ett museum här.",
      pointValue: 6
    },
    {
      clueText: "Gamla stan och Djurgården är välkända delar av staden.",
      pointValue: 4
    },
    {
      clueText: "Vi söker Sveriges huvudstad.",
      pointValue: 2
    }
  ]
}