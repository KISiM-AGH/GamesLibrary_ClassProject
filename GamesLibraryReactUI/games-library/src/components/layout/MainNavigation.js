import {Link} from "react-router-dom";

import classes from "./MainNavigation.module.css";

function MainNavigation() {
  return <header className={classes.header}>
    <div className={classes.logo}>GameLibrary</div>
    <nav>
      <ul>
        <li>
          <Link to='/home'>Home</Link>
        </li>
        <li>
          <Link to='/games-library'>Games Library</Link>
        </li>
        <li>
          <Link to='/add-game'>Add Game</Link>
        </li>
      </ul>
    </nav>
  </header>
}

export default MainNavigation;