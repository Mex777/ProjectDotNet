import { getToken, getUser, isAdmin } from "../Login/auth";
import Post from "../Post";

export default function Posts({ posts, deletePost }) {
  return (
    <div className="posts">
      {posts.map((post, ind) => {
        return <Post post={post} ind={ind} deletePost={deletePost} />;
      })}
    </div>
  );
}
