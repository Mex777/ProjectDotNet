import { useEffect, useState } from "react";
import { getToken, logout } from "../Login/auth";
import { useNavigate, useParams } from "react-router-dom";
import Posts from "../Home/Posts";
import Header from "../Header";

export default function Profile() {
  const { username } = useParams();
  const navigate = useNavigate();
  const [userInfo, setUserInfo] = useState({});
  const [deletePost, setDeletePost] = useState(false);
  const [posts, setPosts] = useState([]);

  const handleLogout = () => {
    logout();
    navigate("/login");
  };

  useEffect(() => {
    const fetchProfile = async () => {
      let myHeaders = new Headers();
      myHeaders.append("Authorization", `Bearer ${getToken()}`);
      let requestOptions = {
        method: "GET",
        headers: myHeaders,
        redirect: "follow",
      };

      let res = await fetch(`/Profile/${username}`, requestOptions);
      if (res.status === 200) {
        const resJson = await res.json();
        setUserInfo(resJson);
      } else {
        navigate("/404");
      }

      myHeaders = new Headers();
      myHeaders.append("Authorization", `Bearer ${getToken()}`);
      myHeaders.append("Content-Type", "application/json");

      requestOptions = {
        method: "GET",
        headers: myHeaders,
        redirect: "follow",
      };

      res = await fetch(`/users/${username}/likes`, requestOptions);
      if (res.status !== 200) {
        return;
      }

      const json = await res.json();
      setPosts(json);
    };

    fetchProfile();
  }, [username, navigate, deletePost]);

  return (
    <>
      <Header />
      <button class="sign-out" onClick={handleLogout}>
        Sign out
      </button>
      <div>
        <h1>Profile of {userInfo.username}</h1>
        <div className="description">
          <h2>Description</h2>
          <p>{userInfo.description}</p>
        </div>

        <div className="liked-posts">
          <h2>Liked posts</h2>
          <Posts posts={posts} deletePost={() => setDeletePost(!deletePost)} />
        </div>
      </div>
    </>
  );
}
