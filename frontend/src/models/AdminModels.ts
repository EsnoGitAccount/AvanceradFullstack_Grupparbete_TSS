export type AdminCity = {
  cityId: number;
  name: string;
  cityPicture: string;
  isArchived: boolean;
};

export type AdminUser = {
  userId: number;
  username: string;
  email: string;
  isArchived: boolean;
};

export type AdminGameResult = {
  gameId: number;
  userId: number | null;
  userName: string;
  totalScore: number;
  completedAt: string;
  cityName: string;
};

export type CityQuestionsUpdate = {
  clueCount?: number;
  clues?: { clueId: number; clueText: string; point: number }[];
  questions: QuestionUpdate[];
};

export type QuestionUpdate = {
  questionId: number;
  questionText: string;
  options: OptionUpdate[];
};

export type OptionUpdate = {
  optionId: number;
  optionText: string;
  isCorrect: boolean;
};

export type ImageUploadResult = {
  blobName: string;
};

export type CityContentCreate = {
  questions: {
    questionText: string;
    options: { optionText: string; isCorrect: boolean }[];
  }[];
  clues: string[];
};
