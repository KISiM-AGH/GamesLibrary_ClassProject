import UserContext from "../store/user-context";
import {useContext, useEffect, useState} from "react";
import GamesList from "../components/elements/GamesList";
import Modal from "../components/ui/Modal";
import Backdrop from "../components/ui/Backdrop";

function HomePage() {
  const [isLoading, setIsLoading] = useState(true);
  const [loadedGames, setLoadedGames] = useState([]);
  const [error, setError] = useState(null);

  const userCtx = useContext(UserContext);

  useEffect(() => {
    setIsLoading(true);
    setError(null);
    fetch(
      'https://localhost:7166/game/user?platform=all',
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

  return <section>
    <GamesList games={loadedGames} />
    {error && <h3>{error}</h3>}
    {isLoading && <Modal button={false} title='Loading...' />}
    {isLoading && <Backdrop />}
  </section>
}

export default HomePage;