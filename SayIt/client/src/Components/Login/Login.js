import { useState } from "react";
import { isAuthenticated, login } from "./auth";
import { useNavigate } from "react-router-dom";
import Header from "../Header";

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
      <Header />
      <div className="login">
        <form className="login-content">
          <div className="input-field">
            <label>Username</label>
            <input value={username} onChange={handleUsername}></input>
          </div>

          <div className="input-field">
            <label>Password</label>
            <input
              type="password"
              value={password}
              onChange={handlePassword}
            ></input>
          </div>

          <button onClick={handleSubmit}>Login</button>
          <p>Don't have an account?</p>
          <a href="/register" className="auth-anchor">
            Register
          </a>
        </form>
      </div>
    </>
  );
}
