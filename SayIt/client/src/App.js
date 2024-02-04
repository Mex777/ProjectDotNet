import {
  BrowserRouter,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import Home from "./Components/Home/Home";
import Login from "./Components/Login/Login";
import { isAuthenticated } from "./Components/Login/auth";
import Register from "./Components/Register/Register";

const PrivateComponent = (props) => {
  return (isAuthenticated() ? props.component : <Navigate to="/login"/>);
};

const NoAuthRoute = (props) => {
  return (isAuthenticated() ? <Navigate to="/home"/> : props.component);
};

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route
          path="/home"
          element={<PrivateComponent component={<Home />} />}
        />
        <Route path="/login" element={<NoAuthRoute component={<Login />}/>} />
        <Route path="/register" element={<NoAuthRoute component={<Register />}/>} />
      </Routes>
    </BrowserRouter>
  );
}

