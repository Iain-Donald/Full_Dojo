import React, { useEffect, useState } from 'react';
import axios from 'axios';
import {
  BrowserRouter,
  Link,
  Switch,
  Route
} from "react-router-dom";
    
import { useParams } from "react-router";
  
// SWAPI API
const SWAPI = (subRoute) => {
  //Note the second argument is an empty array.
  const [responseData, setResponseData] = useState(null);
  var routeString = 'https://swapi.dev/api/' + subRoute;
  useEffect(()=>{
      axios.get(routeString) //'https://swapi.dev/api/'
          .then(response=>{setResponseData(response.data)})
  }, []);
  var returnArray = [0, 1, 2];
  if(responseData === null){
    return returnArray;
  } else {
    return responseData;
  }
  return responseData;
}

// RETURN PEOPLE
const People = (props) => {
  const { id } = useParams();

  var LocalSWAPI = SWAPI("people");
  var displayName;
  var height;
  var mass;
  var hairColor;
  var skinColor;

  if(LocalSWAPI.toString() != "0,1,2"){
    console.log("success: " + LocalSWAPI.results);
    displayName = LocalSWAPI.results[id].name.toString();
    height = LocalSWAPI.results[id].height.toString();
    mass = LocalSWAPI.results[id].mass.toString();
    hairColor = LocalSWAPI.results[id].hair_color.toString();
    skinColor = LocalSWAPI.results[id].skin_color.toString();
  } else {
    console.log("error: SWAPI returned null");
    displayName = "null";
    height = "null";
    mass = "null";
    hairColor = "null";
    skinColor = "null";
  }

  return (
    <div>
      <h1>{displayName}</h1>
      <p><b>Height: </b>{height} cm</p>
      <p><b>Mass: </b>{mass} kg</p>
      <p><b>Hair Color: </b>{hairColor}</p>
      <p><b>Skin Color: </b>{skinColor}</p>
    </div>
  );
}

// RETURN PEOPLE
const Planets = (props) => {
  const { id } = useParams();

  var displayString = SWAPI("planets");

  if(displayString.toString() != "0,1,2"){
    console.log("success: " + displayString.results[id].name);
    displayString = displayString.results[id].name.toString();
  } else {
    console.log("error: SWAPI returned null");
    displayString = "null";
  }

  return (
    <div>
      <h1>Welcome to { id }!</h1>
      <p>{displayString}</p>
    </div>
  );
}
    
function App() {
  //console.log(SWAPI("people")); //explorer
  return (
    <BrowserRouter>
      <p>
        <Link to="/people/0">0</Link>
        &nbsp;|&nbsp;
        <Link to="/people/1">1</Link>
        &nbsp;|&nbsp;
        <Link to="/people/2">2</Link>
        &nbsp;|&nbsp;
        <Link to="/people/3">3</Link>
      </p>
      <Switch>
        <Route path="/people/:id">
          <People />
        </Route>
      </Switch>
    </BrowserRouter>
  );
}
    
export default App;