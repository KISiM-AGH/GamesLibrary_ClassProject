import {useRef} from 'react';

import MainCard from "../ui/MainCard";
import classes from './LoginForm.module.css';

function RegisterForm(props) {
  const nameInputRef = useRef();
  const surnameInputRef = useRef();
  const emailInputRef = useRef();
  const usernameInputRef = useRef();
  const passwordInputRef = useRef();
  const confirmPasswordInputRef = useRef();
  const birthDateInputRef = useRef();

  function submitHandler(event) {
    event.preventDefault();

    const enteredName = nameInputRef.current.value;
    const enteredSurname = surnameInputRef.current.value;
    const enteredEmail = emailInputRef.current.value;
    const enteredUsername = usernameInputRef.current.value;
    const enteredPassword = passwordInputRef.current.value;
    const enteredConfirmPassword = confirmPasswordInputRef.current.value;
    const enteredBirthDate = birthDateInputRef.current.value;

    const userRegisterData = {
      name: enteredName,
      surname: enteredSurname,
      email: enteredEmail,
      username: enteredUsername,
      password: enteredPassword,
      confirmPassword: enteredConfirmPassword,
      dateOfBirth: enteredBirthDate
    };

    props.onRegister(userRegisterData);
  }

  return <MainCard>
    <form className={classes.form} onSubmit={submitHandler}>
      <div className={classes.control}>
        <label htmlFor="name">Name</label>
        <input type="text" required id="name" ref={nameInputRef} />
      </div>
      <div className={classes.control}>
        <label htmlFor="surname">Surname</label>
        <input type="text" required id="surname" ref={surnameInputRef} />
      </div>
      <div className={classes.control}>
        <label htmlFor="email">Email</label>
        <input type="email" required id="email" ref={emailInputRef} />
      </div>
      <div className={classes.control}>
        <label htmlFor="login">Username</label>
        <input type="text" required id="login" ref={usernameInputRef} />
      </div>
      <div className={classes.control}>
        <label htmlFor="password">Password</label>
        <input type="password" required id="password" ref={passwordInputRef} />
      </div>
      <div className={classes.control}>
        <label htmlFor="confirmPassword">Confirm Password</label>
        <input type="password" required id="confirmPassword" ref={confirmPasswordInputRef} />
      </div>
      <div className={classes.control}>
        <label htmlFor="birthDate">Birth Date</label>
        <input type="date" required id="birthDate" ref={birthDateInputRef} />
      </div>
      <div className={classes.actions}>
        <button>Register</button>
      </div>
    </form>
  </MainCard>
}

export default RegisterForm;