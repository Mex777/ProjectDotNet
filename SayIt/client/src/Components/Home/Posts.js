import { getToken, getUser, isAdmin } from "../Login/auth";

export default function Posts({ posts, deletePost }) {
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

  return (
    <div className="posts">
      {posts.map((post, ind) => {
        return (
          <div key={ind} className="post">
            <h4>Author: {post.author}</h4>
            <p>{post.text}</p>
            <button>Like</button>
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
      })}
    </div>
  );
}
