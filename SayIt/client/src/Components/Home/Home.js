import { useNavigate } from "react-router-dom";
import { logout } from "../Login/auth"

export default function Home() {
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate("/login");
  }

  return (<>
  <h1>hello world</h1>
    <button onClick={handleLogout}>Sign out</button>
  
  </>)
}