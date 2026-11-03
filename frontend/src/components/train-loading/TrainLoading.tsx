import thomas from '@/assets/icons/thomas.svg'
import thomasCart from '@/assets/icons/thomascart.svg'
import smokePuff from '@/assets/illustrations/SmokePuff.svg'
import './TrainLoading.css'

export default function TrainLoading() {
  return (
    <div className="train-loading" role="status" aria-label="Laddar bilden">
      <div className="train-loading__scene" aria-hidden="true">
        <div className="train-loading__train">
          {[1, 2].map((cart) => (
            <div key={cart} className="train-loading__wagon">
              <img
                className="train-loading__cart"
                src={thomasCart}
                alt=""
                width="80"
              />
            </div>
          ))}
          <div className="train-loading__locomotive">
            {[1, 2, 3].map((puff) => (
              <img
                key={puff}
                className={`train-loading__smoke train-loading__smoke--${puff}`}
                src={smokePuff}
                alt=""
                width="18"
                height="18"
              />
            ))}
            <img className="train-loading__engine" src={thomas} alt="" width="80" />
          </div>
        </div>
        <div className="train-loading__track" />
      </div>
    </div>
  )
}


