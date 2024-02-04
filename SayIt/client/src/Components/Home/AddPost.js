import { useState } from "react";
import { getToken, getUser } from "../Login/auth";

export default function AddPost({ newPost }) {
  const [value, setValue] = useState("");

  const handleChange = (e) => {
    setValue(e.target.value);
  };

  const handlePost = async (e) => {
    e.preventDefault();

    var myHeaders = new Headers();
    myHeaders.append(
      "Authorization",
      `Bearer ${getToken()}` 
    );
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({
      text: value,
      author: getUser(),
      id: "40b1b211-a510-4a8d-add6-e9e05d332d1b",
    });

    var requestOptions = {
      method: "POST",
      headers: myHeaders,
      body: raw,
      redirect: "follow",
    };

    const res = await fetch("/posts", requestOptions);
    if (res.status !== 200) {
      console.log(res);
    } else {
      newPost();
    }
  };

  return (
    <form>
      <textarea
        placeholder="What's on your mind?"
        value={value}
        onChange={handleChange}
      />
      <button onClick={handlePost}>Post</button>
    </form>
  );
}
