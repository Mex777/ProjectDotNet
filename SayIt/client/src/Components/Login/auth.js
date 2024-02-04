import { jwtDecode } from "jwt-decode";
const tokenKey = "jwt";

export const login = async (username, password) => {
  let myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  let raw = JSON.stringify({
    username: username,
    password: password,
  });

  let requestOptions = {
    method: "POST",
    headers: myHeaders,
    body: raw,
    redirect: "follow",
  };

  const req = await fetch("/Security/login", requestOptions);
  if (req.status === 200) {
    const token = await req.text();
    localStorage.setItem(tokenKey, token);
  }
};

export const logout = () => {
  localStorage.removeItem(tokenKey);
};

export const register = async (username, password, role) => {
  const myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  const raw = JSON.stringify({
    username,
    password,
    role: + role
  });

  var requestOptions = {
    method: "POST",
    headers: myHeaders,
    body: raw,
    redirect: "follow",
  };

  const res = await fetch("/Security/register", requestOptions);
  if (res.status !== 200) {
    return false;
  }

  return true;
};

export const getToken = () => {
  return localStorage.getItem(tokenKey);
};

export const isAuthenticated = () => {
  const token = getToken();
  if (!token) {
    return false;
  }

  try {
    const decodedToken = jwtDecode(token);

    // Check if the token is expired
    const currentTime = Math.floor(Date.now() / 1000);
    if (decodedToken.exp && decodedToken.exp < currentTime) {
      logout();
      return false; // Token is expired
    }

    return true; // Token is valid
  } catch (error) {
    console.error("Error decoding token:", error);
    return false; // Error decoding token
  }
};

export const getUser = () => {
  try {
    const decodedToken = jwtDecode(getToken());

    return decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]; // Token is valid
  } catch (error) {
    console.error("Error decoding token:", error);
    return false; // Error decoding token
  }
}

export const isAdmin = () => {
  try {
    const decodedToken = jwtDecode(getToken());
    console.log(decodedToken);

    return decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === "Admin";
  } catch (error) {
    console.error("Error decoding token:", error);
    return false; // Error decoding token
  }
}

export const getUserId = () => {
  try {
    const decodedToken = jwtDecode(getToken());
    console.log(decodedToken);

    return decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber"];
  } catch (error) {
    console.error("Error decoding token:", error);
    return false; // Error decoding token
  }
}
