import {useRef} from 'react';

import MainCard from "../ui/MainCard";
import classes from './LoginForm.module.css';

function LoginForm(props) {
  const usernameInputRef = useRef();
  const passwordInputRef = useRef();

  function submitHandler(event) {
    event.preventDefault();

    const enteredUsername = usernameInputRef.current.value;
    const enteredPassword = passwordInputRef.current.value;

    const userLoginData = {
      username: enteredUsername,
      password: enteredPassword
    };

    props.onLogin(userLoginData);
  }

  return <MainCard>
    <form className={classes.form} onSubmit={submitHandler}>
      <div className={classes.control}>
        <label htmlFor="login">Username</label>
        <input type="text" required id="login" ref={usernameInputRef} />
      </div>
      <div className={classes.control}>
        <label htmlFor="password">Password</label>
        <input type="password" required id="password" ref={passwordInputRef} />
      </div>
      <div className={classes.actions}>
        <button>Login</button>
      </div>
    </form>
  </MainCard>
}

export default LoginForm;