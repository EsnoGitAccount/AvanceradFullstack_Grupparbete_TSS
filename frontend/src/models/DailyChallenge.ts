export type DailyChallenge = {
  cityDetails: {
    cityName: string;
    clues: {
        clueText: string;
        pointValue: number;
    }[];
    questions: {
      questionText: string;
      options: {
        optionText: string;
        isCorrect: boolean;
      }[];
    }[];
  };
  challangeDate: string;
};