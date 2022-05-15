import React from "react";
import { Header } from "./Components/Header";
import { GlobalStyle } from "./styles/global";
import axios from "axios";


function App() {

  const data = axios.get("https://localhost:7162/api/items") 
  console.log(data);


  return (
    <>
      <Header/>
      <GlobalStyle/>
    </>
      
  );
}

export default App;
