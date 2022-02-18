import classes from './GamesList.module.css';
import AddGameItem from "./AddGameItem";

function AddGamesList(props) {
  return <ul className={classes.list}>
    {props.games.map((game) => (
      <AddGameItem
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
        onAddGame={props.onAddGame}
      />))}
  </ul>
}

export default AddGamesList;