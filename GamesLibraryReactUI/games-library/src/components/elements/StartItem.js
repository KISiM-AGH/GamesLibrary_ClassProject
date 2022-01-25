import MainCard from "../ui/MainCard";
import classes from "./StartItem.module.css";
import {Link} from "react-router-dom";

function StartItem() {
  return <MainCard>
    <div className={classes.content}>
      <h3>Games Library</h3>
    </div>
    <div className={classes.actions}>
          <Link to='/login'>
            <button>
              Login
            </button>
          </Link>
          <Link to='/register'>
            <button>
              Register
            </button>
          </Link>
    </div>
  </MainCard>
}

export default StartItem;