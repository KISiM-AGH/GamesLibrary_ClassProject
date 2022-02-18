import {Link} from "react-router-dom";

import classes from "./MainNavigation.module.css";

function StartNavigation() {
  return <header className={classes.header}>
    <div className={classes.logo}>GameLibrary</div>
    <nav>
      <ul>
        <li>
          <Link to='/games-library'>LogIn</Link>
        </li>
        <li>
          <Link to='/add-game'>Register</Link>
        </li>
      </ul>
    </nav>
  </header>
}

export default StartNavigation;