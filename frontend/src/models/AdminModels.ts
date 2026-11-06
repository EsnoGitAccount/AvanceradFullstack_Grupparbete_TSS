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
