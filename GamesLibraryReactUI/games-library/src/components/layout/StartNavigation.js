import {Link} from "react-router-dom";

import classes from "./MainNavigation.module.css";

function StartNavigation() {
  return <header className={classes.header}>
    <div className={classes.logo}>GamesLibrary</div>
    <nav>
      <ul>
        <li>
          <Link to='/login'>LogIn</Link>
        </li>
        <li>
          <Link to='/register'>Register</Link>
        </li>
      </ul>
    </nav>
  </header>
}

export default StartNavigation;