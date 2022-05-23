import React from "react";
import Main from './views/Main';
import Details from './components/Details';
import Delete from './components/Delete';
import Update from './components/Update';
import EditForm from "./components/EditForm";
import {
  BrowserRouter,
  Routes,
  Route,
  Link 
} from "react-router-dom";
    
import { useParams } from "react-router";
function App() {
  return (
    <div>
      <BrowserRouter>
      <h1>Routing Example</h1>
      <p>
        <Link to="/">Main</Link>
        | 
        <Link to="/details">Details</Link>   
      </p>
      <Routes>
        <Route path='/details/:id' element={<Details/>} />
        <Route path='/' element={<Main/>} />
        <Route path='/delete/:id' element={<Delete/>} />
        <Route path='/update/:id' element={<Update/>} />
        <Route path='/edit/:id' element={<EditForm/>} />
      </Routes>
    </BrowserRouter>
    </div>
  );
}
export default App;