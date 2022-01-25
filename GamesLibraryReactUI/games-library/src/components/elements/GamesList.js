import classes from './GamesList.module.css';
import GameItem from "./GameItem";

function GamesList(props) {
  return <ul className={classes.list}>
    {props.games.map((game) => (
      <GameItem
        key={game.id}
        id={game.id}
        image={game.photoUrl}
        title={game.title}
        platforms={game.platforms}
        dev={game.companyName}
        description={game.desc}
        premiere={game.premiere}
        price={game.price}
        genres={game.genres}
        platform={game.userGamePlatform}
      />))}
  </ul>
}

export default GamesList;