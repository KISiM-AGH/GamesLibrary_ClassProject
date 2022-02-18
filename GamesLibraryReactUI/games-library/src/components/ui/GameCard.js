import classes from './GameCard.module.css';

function GameCard(props) {
  return <div className={classes.card}>{props.children}</div>
}

export default GameCard;
