import classes from "./MainCard.module.css";

function MainCard(props) {
  return <div className={classes.card}>{props.children}</div>
}

export default MainCard