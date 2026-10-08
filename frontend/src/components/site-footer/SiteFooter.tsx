import {
  PenLineIcon,
  RouteIcon,
  SunIcon,
  TrophyIcon,
} from '@/assets/icons/Icons'

import './SiteFooter.css'

const footerItems = [
  { label: 'Bara svenska städer', Icon: RouteIcon },
  { label: 'Gissa snabbast för högts poäng', Icon: PenLineIcon },
  { label: 'Lär dig nya saker', Icon: TrophyIcon },
  { label: 'En ny resa varje dag', Icon: SunIcon },
]

function SiteFooter() {
  return (
    <footer className="site-footer">
      <h2 className="site-footer__title">Så fungerar Sverigeresan</h2>
      <div className="site-footer__inner">
        {footerItems.map(({ label, Icon }) => (
          <div className="site-footer__item" key={label}>
            <Icon className="site-footer__icon" aria-hidden="true" />
            <span>{label}</span>
          </div>
        ))}
      </div>
    </footer>
  )
}

export default SiteFooter
