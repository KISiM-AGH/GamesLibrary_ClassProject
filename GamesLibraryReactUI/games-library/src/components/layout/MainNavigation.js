import {Link} from "react-router-dom";

import classes from "./MainNavigation.module.css";
import {useContext} from "react";
import UserContext from "../../store/user-context";
import jwtDecode from "jwt-decode";

function MainNavigation() {
  const userCtx = useContext(UserContext);

  let token = jwtDecode(userCtx.getUserToken());

  return <header className={classes.header}>
    <div className={classes.logo}>{token.nameid}</div>
    <nav>
      <ul>
        <li>
          <Link to='/home'>Home</Link>
        </li>
        <li>
          <Link to='/add-game'>Add Game</Link>
        </li>
        <li>
          <Link to='/'>LogOut</Link>
        </li>
      </ul>
    </nav>
  </header>
}

export default MainNavigation;