import { useNavigate } from "react-router-dom";
import { getToken, logout } from "../Login/auth";
import { useEffect, useState } from "react";
import Posts from "./Posts";
import AddPost from "./AddPost";

export default function Home() {
  const navigate = useNavigate();
  const [posts, setPosts] = useState([]);
  const [newPost, setNewPost] = useState(false);

  const handleLogout = () => {
    logout();
    navigate("/login");
  };

  useEffect(() => {
    const getPosts = async () => {
      const myHeaders = new Headers();
      myHeaders.append(
        "Authorization",
        `Bearer ${getToken()}`
      );
      myHeaders.append("Content-Type", "application/json");

      const requestOptions = {
        method: "GET",
        headers: myHeaders,
        redirect: "follow",
      };

      const res = await fetch("/posts", requestOptions);
      if (res.status !== 200) {
        return;
      }
      
      const json = await res.json();
      setPosts(json)
    };

    getPosts();
  }, [newPost]);

  return (
    <>
      <h1>hello world</h1>
      <button onClick={handleLogout}>Sign out</button>

      <AddPost newPost={() => setNewPost(!newPost)} />

      <Posts posts={posts} deletePost={() => setNewPost(!newPost)}/>
    </>
  );
}
