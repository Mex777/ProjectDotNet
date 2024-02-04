import { useEffect, useState } from "react";
import { getToken, getUser, getUserId, isAdmin } from "./Login/auth";
import { useNavigate } from "react-router-dom";

export default function Post({ post, ind, deletePost }) {
  const [like, setLike] = useState(false);
  const navigate = useNavigate();

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

    const res = await fetch(
      `/Like?userId=${getUserId()}&postId=${post.id}`,
      requestOptions
    );
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

    const res = await fetch(
      `/Like?userId=${getUserId()}&postId=${post.id}`,
      requestOptions
    );
    if (res.status === 200) {
      setLike(false);
    }
  };

  const handleProfile = (username) => {
    navigate(`/profile/${username}`);
  };

  return (
    <div key={ind} className="post">
      <h4 onClick={() => handleProfile(post.author)}>{post.author}</h4>
      <p>{post.text}</p>
      <div className="buttons">
        {like ? (
          <button onClick={handleRemoveLike} className="unlike">
            Remove Like
          </button>
        ) : (
          <button onClick={handleLike} className="like">
            Like
          </button>
        )}
        {(isAdmin() || post.author === getUser()) && (
          <button
            className="delete"
            onClick={() => {
              handleDelete(post.id);
            }}
          >
            delete
          </button>
        )}
      </div>
    </div>
  );
}
