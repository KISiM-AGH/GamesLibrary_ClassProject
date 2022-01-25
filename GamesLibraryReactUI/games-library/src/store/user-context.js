import {createContext, useState} from "react";

const UserContext = createContext({
  userToken: '',
  setUserToken: (token) => {},
  removeUserToken: () => {},
  getUserToken: () => {},
});

export function UserContextProvider(props) {
  const [token, setToken] = useState(
    localStorage.getItem('token')
  );

  function setUserTokenHandler(token) {
    localStorage.setItem('token', token);
    setToken(token);
  }

  function removeUserTokenHandler() {
    localStorage.setItem('token', '');
    setToken('');
  }

  function getUserTokenHandler() {
    return token;
  }

  const context = {
    userToken: token,
    setUserToken: setUserTokenHandler,
    removeUserToken: removeUserTokenHandler,
    getUserToken: getUserTokenHandler
  };

  return <UserContext.Provider value={context} >
    {props.children}
  </UserContext.Provider>

}

export default UserContext;