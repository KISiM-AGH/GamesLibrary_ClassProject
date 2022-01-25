import MainCard from "../components/ui/MainCard";
import StartItem from "../components/elements/StartItem";
import {useContext} from "react";
import UserContext from "../store/user-context";

function StartPage() {
  const userCtx = useContext(UserContext);

  userCtx.removeUserToken();

  return <div>
    <StartItem />
  </div>
}

export default StartPage;