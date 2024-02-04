import { useEffect, useState } from "react";
import { getToken, getUser, getUserId, isAdmin } from "./Login/auth";

export default function Post({ post, ind, deletePost }) {
  const [like, setLike] = useState(false);

  useEffect(() => {
    const fetchLikedPost = async () => {
      var myHeaders = new Headers();
      myHeaders.append("Authorization", `Bearer ${getToken()}`);

      var requestOptions = {
        method: "GET",
        headers: myHeaders,
        redirect: "follow",
      };

      const res = await fetch(
        `/like/${getUserId()}/${post.id}`,
        requestOptions
      );

      if (res.status === 200) {
        setLike(true);
      } else {
        setLike(false);
      }
    };

    fetchLikedPost();
  }, []);

  const handleDelete = async (id) => {
    var myHeaders = new Headers();
    myHeaders.append("Authorization", `Bearer ${getToken()}`);

    var requestOptions = {
      method: "DELETE",
      headers: myHeaders,
      redirect: "follow",
    };

    const res = await fetch(`/posts/${id}`, requestOptions);

    if (res.status === 200) {
      deletePost();
    }
  };

  const handleLike = async () => {
    const myHeaders = new Headers();
    myHeaders.append("Authorization", `Bearer ${getToken()}`);

    const requestOptions = {
      method: "POST",
      headers: myHeaders,
      redirect: "follow",
    };

    const res = await fetch(`/Like?userId=${getUserId()}&postId=${post.id}`, requestOptions);
    if (res.status === 200) {
      setLike(true);
    }
  };

  const handleRemoveLike = async () => {
    const myHeaders = new Headers();
    myHeaders.append("Authorization", `Bearer ${getToken()}`);

    const requestOptions = {
      method: "DELETE",
      headers: myHeaders,
      redirect: "follow",
    };

    const res = await fetch(`/Like?userId=${getUserId()}&postId=${post.id}`, requestOptions);
    if (res.status === 200) {
      setLike(false);
    }
  }

  return (
    <div key={ind} className="post">
      <h4>Author: {post.author}</h4>
      <p>{post.text}</p>
      {like ? (
        <button onClick={handleRemoveLike}>Remove Like</button>
      ) : (
        <button onClick={handleLike}>Like</button>
      )}
      {(isAdmin() || post.author === getUser()) && (
        <button
          onClick={() => {
            handleDelete(post.id);
          }}
        >
          delete
        </button>
      )}
    </div>
  );
}
