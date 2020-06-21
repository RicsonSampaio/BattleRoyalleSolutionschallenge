import React, { useState } from "react";
import Terminal from "terminal-in-react";
import "./App.css";

function App() {
  const [captura, setCaptura] = useState("");

  const showMsg = () => "Hello World";

  return (
    <>
      <div>Comando digitado - {captura}</div>
      <div
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          height: "100vh",
        }}
      >
        <Terminal
          color="green"
          backgroundColor="black"
          barColor="black"
          style={{ fontWeight: "bold", fontSize: "1em" }}
          commands={{
            showmsg: () => {
              setCaptura("showmsg");
              showMsg();
            },
            popup: () => {
              setCaptura("popup");
              alert("Terminal in React");
            },
            test: () => {
              setCaptura("test");
            },
          }}
          descriptions={{
            showmsg: "shows a message",
            alert: "alert",
            popup: "alert",
            test: "Comando de teste",
          }}
          msg="You can write anything here. Example - Hello! My name is Foo and I like Bar."
        />
      </div>
    </>
  );
}

export default App;