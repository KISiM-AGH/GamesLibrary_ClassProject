import MainNavigation from "./MainNavigation";
import classes from './Layout.module.css';
import Footer from "./Footer";
import StartNavigation from "./StartNavigation";

function Layout(props) {
  return <div>
    <StartNavigation />
    <main className={classes.main}>
      {props.children}
    </main>
    <Footer />
  </div>
}

export default Layout;