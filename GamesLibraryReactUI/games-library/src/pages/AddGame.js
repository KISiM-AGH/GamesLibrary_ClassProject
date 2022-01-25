import {useContext, useEffect, useState} from "react";
import UserContext from "../store/user-context";
import Modal from "../components/ui/Modal";
import Backdrop from "../components/ui/Backdrop";
import AddGamesList from "../components/elements/AddGameList";


function AddGamePage() {
  const [isLoading, setIsLoading] = useState(true);
  const [loadedGames, setLoadedGames] = useState([]);
  const [error, setError] = useState(null);

  const userCtx = useContext(UserContext);

  useEffect(() => {
    setIsLoading(true);
    setError(null);
    fetch(
      'https://localhost:7166/game',
      {
        method: 'GET',
        headers: {
          'Authorization': 'Bearer ' + userCtx.getUserToken()
        }
      }
    ).then((response) => {
      return response.json();
    }).then((data) => {
      const games = [];
      if (data.error === true) {
        setError(data.message);
      } else {
        for (const key in data) {
          const game = {
            id: key,
            ...data[key]
          };
          games.push(game);
        }
      }
      setIsLoading(false);
      setLoadedGames(games);
    })
  }, [userCtx]);

  function addGameHandler(newUserGameData) {
    setIsLoading(true);
    setError(null)

    fetch(
      'https://localhost:7166/game/user',
      {
        method: 'POST',
        body: JSON.stringify(newUserGameData),
        headers: {
          'Content-Type': 'application/json; charset=utf-8',
          'Authorization': 'Bearer ' + userCtx.getUserToken()
        }
      }
    ).then((response) => {
      return response.json();
    }).then((data) => {
      if (data.error === true) {
        setIsLoading(false);
        setError(data.message);
      } else {
        setIsLoading(false);
      }
    });
  }

  return <section>
    <AddGamesList games={loadedGames} onAddGame={addGameHandler} />
    {error && <h3>{error}</h3>}
    {isLoading && <Modal button={false} title='Loading...' />}
    {isLoading && <Backdrop />}
  </section>
}

export default AddGamePage;