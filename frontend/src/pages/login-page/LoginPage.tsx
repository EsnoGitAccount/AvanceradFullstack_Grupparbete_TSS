import SiteHeader from '@/components/site-header/SiteHeader'
import SiteFooter from '@/components/site-footer/SiteFooter'
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/Card'
import { Button } from '@/components/ui/Button'
import { ArrowLeft } from 'lucide-react'
import TrainIllustration from "../../assets/illustrations/trainillustration"
import { useNavigate } from 'react-router'
import { getTimeOfDay } from '@/models/TimeOfDay'

import "./LoginPage.css"
import { LoginForm } from '@/components/login/LoginForm'

function LoginPage() {
    const navigate = useNavigate();
    const time = getTimeOfDay();
    return (
        <div className="login-page">
            <SiteHeader />

            <main className="login-page__main">
                <section className="login-page__hero">

                    <Button
                        type="button"
                        onClick={() => navigate('/homepage')}
                        className="login-page__back-link"
                    >
                        <a href="/" className="login-page__back-link">
                            <ArrowLeft className="w-4 h-4 mr-1 inline" /> Tillbaka till startsidan
                        </a>
                    </Button>

                    <div className="login-page__grid">

                        {/* Left column */}
                        <div className="login-page__left-column">
                            <span className="login-page__eyebrow ">VÄLKOMMEN TILLBAKA</span>
                            <h1 className="login-page__title">Redo för nästa stopp?</h1>
                            <p className="login-page__subtitle">
                                Logga in och fortsätt din resa. Dagens 3 ledtrådar väntar på dig.
                            </p>

                            <div className={`login-page__illustration train-illustration--${time}`}>
                                <TrainIllustration />
                            </div>

                            <div className="login-page__badge">
                                En ny Sverigeresa varje dag
                            </div>
                        </div>

                        {/* Right column (Login card) */}
                        <div className="login-page__right-column">
                            <Card className="login-card">
                                <CardHeader>
                                    <CardTitle className="login-card__title w-[85%] mx-auto text-left mt-4" >
                                        Logga in
                                    </CardTitle>
                                </CardHeader>
                                <CardContent className="login-card__content">
                                    <LoginForm />
                                </CardContent>
                            </Card>
                        </div>

                    </div>
                </section>
            </main>

            <SiteFooter />
        </div>
    );
}

export default LoginPage;