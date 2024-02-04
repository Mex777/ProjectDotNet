import { useNavigate } from "react-router-dom";
import { logout } from "./Login/auth";

export default function Header() {
  const navigate = useNavigate();

  const handleLogo = () => {
    navigate("/home");
  };

  return (
    <div className="header">
      <h1 onClick={handleLogo}>SayIt.</h1>
    </div>
  );
}
