import {Route, Switch} from "react-router-dom";

import Layout from "./components/layout/Layout";
import StartPage from "./pages/Start";
import RegisterPage from "./pages/Register";
import LoginPage from "./pages/Login";
import HomePage from "./pages/Home";
import GamesLibraryPage from "./pages/GamesLibrary";
import AddGamePage from "./pages/AddGame";

function App() {
  return <Layout>
    <Switch>
      <Route path='/' exact>
        <StartPage />
      </Route>
      <Route path='/register'>
        <RegisterPage />
      </Route>
      <Route path='/login'>
        <LoginPage />
      </Route>
      <Route path='/home'>
        <HomePage />
      </Route>
      <Route path='/games-library'>
        <GamesLibraryPage />
      </Route>
      <Route path='/add-game'>
        <AddGamePage />
      </Route>
    </Switch>
  </Layout>
}

export default App;
