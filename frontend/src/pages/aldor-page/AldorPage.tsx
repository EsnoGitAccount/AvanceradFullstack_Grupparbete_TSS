import TeacherBonusGame from '@/components/teacher-bonus-game/TeacherBonusGame'
import { ALDOR_CHALLENGE, ALDOR_PORTRAIT } from '@/constants/aldorChallenge'

export default function AldorPage() {
  return (
    <TeacherBonusGame
      key="aldor"
      name="Aldor"
      description="Gissa läraren och testa dina programmeringskunskaper."
      challenge={ALDOR_CHALLENGE}
      portrait={ALDOR_PORTRAIT}
    />
  )
}
