import TeacherBonusGame from '@/components/teacher-bonus-game/TeacherBonusGame'
import { JOHAN_CHALLENGE, JOHAN_PORTRAIT } from '@/constants/johanChallenge'

export default function JohanPage() {
  return (
    <TeacherBonusGame
      key="johan"
      name="Johan"
      description="Gissa läraren och testa dina kunskaper i agilt arbete."
      challenge={JOHAN_CHALLENGE}
      portrait={JOHAN_PORTRAIT}
    />
  )
}
