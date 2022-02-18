import classes from "./GameItem.module.css";
import GameCard from "../ui/GameCard";

function GameItem(props) {
  return <li className={classes.item}>
    <GameCard>
      <div className={classes.image}>
        <img src={props.image} alt={props.title} />
      </div>
      <div className={classes.content}>
        <h3>{props.title}</h3>
        <address>{props.dev}</address>
        <h2>{props.platform}</h2>
      </div>
      <div className={classes.actions}>
        <button>More</button>
      </div>
    </GameCard>
  </li>
}

export default GameItem;