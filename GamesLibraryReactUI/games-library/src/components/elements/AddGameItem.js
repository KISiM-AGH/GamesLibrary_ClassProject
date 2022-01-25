import classes from "./GameItem.module.css";
import GameCard from "../ui/GameCard";
import {useRef} from "react";

function AddGameItem(props) {
  const platformChooseRef = useRef();

  function submitHandler(event) {
    event.preventDefault();

    const chosenPlatform = platformChooseRef.current.value;

    const newUserGameData = {
      id: props.id,
      title: props.title,
      platform: chosenPlatform
    }

    console.log(newUserGameData);

    props.onAddGame(newUserGameData);
  }

  let platforms = props.platforms.map((item, i) => {
    return (
      <option key={i} value={i}>{item}</option>
    )
  });

  return <li className={classes.item}>
    <GameCard> <form onSubmit={submitHandler}>
      <div className={classes.image}>
        <img src={props.image} alt={props.title} />
      </div>
      <div className={classes.content}>
        <h3>{props.title}</h3>
        <address>{props.dev}</address>
        <select required id='platform' ref={platformChooseRef}>
          {platforms}
        </select>
      </div>
      <div className={classes.actions}>
        <button>Add</button>
      </div>
      </form>
    </GameCard>
  </li>
}

export default AddGameItem;