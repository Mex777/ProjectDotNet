import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { register } from "../Login/auth";
import Header from "../Header";

export default function Register() {
  const navigate = useNavigate();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState(0);

  const handleUsername = (e) => {
    setUsername(e.target.value);
  };

  const handlePassword = (e) => {
    setPassword(e.target.value);
  };

  const handleCheckBox = () => {
    setRole(!role);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const status = await register(username, password, role);
    if (status) {
      navigate("/login");
    } else {
      alert("User with same name");
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

          <div className="checkbox">
            <label>Admin</label>
            <input
              type="checkbox"
              checked={role}
              onChange={handleCheckBox}
            ></input>
          </div>
          <button onClick={handleSubmit}>Register</button>
          <p>Already have an account?</p>
          <a href="/register" className="auth-anchor">
            Login
          </a>
        </form>
      </div>
    </>
  );
}
