import MainNavigation from "./MainNavigation";
import classes from './Layout.module.css';
import Footer from "./Footer";
import StartNavigation from "./StartNavigation";
import {useContext} from "react";
import UserContext from "../../store/user-context";

function Layout(props) {
  const userCtx = useContext(UserContext);

  return <div>
    {userCtx.getUserToken() === '' ? <StartNavigation/> : <MainNavigation />}
    <main className={classes.main}>
      {props.children}
    </main>
  </div>
}

export default Layout;