import { useState } from "react";
import { isAuthenticated, login } from "./auth";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const navigate = useNavigate();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleUsername = (e) => {
    setUsername(e.target.value);
  };

  const handlePassword = (e) => {
    setPassword(e.target.value);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await login(username, password);

    if (isAuthenticated()) {
      navigate("/home");
    }
  };

  return (
    <>
      <form>
        <label>Username</label>
        <input value={username} onChange={handleUsername}></input>

        <label>Password</label>
        <input
          type="password"
          value={password}
          onChange={handlePassword}
        ></input>

        <button onClick={handleSubmit}>Login</button>
      </form>
    </>
  );
}
