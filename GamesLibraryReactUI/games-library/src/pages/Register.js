import RegisterForm from "../components/elements/RegisterForm";
import {useHistory} from "react-router-dom";
import {useEffect, useState} from "react";
import Modal from "../components/ui/Modal";
import Backdrop from "../components/ui/Backdrop";


function RegisterPage() {
  const history = useHistory();
  const [error, setError] = useState();
  const [loading, setLoading] = useState(false);

  function closeModalHandler() {
    setError(null);
  }

  function registerHandler(userRegisterData) {
    setError(null);
    setLoading(true);
      fetch(
        'https://localhost:7166/account/register',
        {
          method: 'POST',
          body: JSON.stringify(userRegisterData),
          headers: {
            'Content-Type': 'application/json; charset=utf-8'
          }
        }
      ).then((response) => {
        return response.json();
      }).then((data) => {
        if (data.error === true) {
          setLoading(false);
          setError(data.message);
        }else {
          setLoading(false);
          history.replace('/');
        }
      });
  }

  return <section>
    <RegisterForm onRegister={registerHandler} />
    {loading && <Modal title='Loading...' />}
    {error && <Modal button={true} title='Incorrect user information' text={error} onClose={closeModalHandler} />}
    {error && <Backdrop onClose={closeModalHandler} />}
  </section>
}

export default RegisterPage;