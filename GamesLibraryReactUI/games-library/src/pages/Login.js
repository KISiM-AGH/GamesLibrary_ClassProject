import LoginForm from "../components/elements/LoginForm";
import {useContext, useEffect, useState} from "react";
import {useHistory} from "react-router-dom";
import Modal from "../components/ui/Modal";
import Backdrop from "../components/ui/Backdrop";
import UserContext from "../store/user-context";

function LoginPage() {
  const [isLoading, setIsLoading] = useState(false);
  const history = useHistory();
  const [error, setError] = useState();

  const userCtx = useContext(UserContext);

  function closeModalHandler() {
    setError(null);
  }

  function loginHandler(userLoginData) {
    setIsLoading(true);
    setError(null)

    fetch(
      'https://localhost:7166/account/authenticate',
      {
        method: 'POST',
        body: JSON.stringify(userLoginData),
        headers: {
          'Content-Type': 'application/json; charset=utf-8'
        }
      }
    ).then((response) => {
      return response.json();
    }).then((data) => {
      if (data.error === true) {
        setIsLoading(false);
        setError(data.message);
      }else {
        setIsLoading(false);
        userCtx.setUserToken(data.jwtToken);
        history.replace('/home');
      }
    });
  }

  return <section>
    <LoginForm onLogin={loginHandler} />
    {isLoading && <Modal button={false} title='Loading...' />}
    {isLoading && <Backdrop onClose={closeModalHandler} />}
    {error && <Modal button={true} title='Login Error' text={error} onClose={closeModalHandler} />}
    {error && <Backdrop onClose={closeModalHandler} />}
  </section>
}

export default LoginPage;
