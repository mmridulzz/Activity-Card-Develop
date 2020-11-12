import React, { useState } from "react";

function Home(props) {
    const [authTokens, setAuthTokens] = useState();
    const setTokens = (data) => {
        localStorage.setItem("tokens", JSON.stringify(data));
        setAuthTokens(data);
    }
    return (
       <div>Land Page</div>
    );
}

export default Home;