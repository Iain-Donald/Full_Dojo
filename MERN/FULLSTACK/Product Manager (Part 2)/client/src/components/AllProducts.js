import React, { useEffect, useState } from 'react'
import axios from 'axios';
import {
    BrowserRouter,
    Routes,
    Route,
    Link 
} from "react-router-dom";
export default () => {
    const [ message, setMessage ] = useState("Loading...")
    useEffect(()=>{
        axios.get("http://localhost:8000/api")
            .then(res=>setMessage(res.data.message))       
    }, []);
    var display = new Array;
    for(var i = 0; i < message.length; i++){
        display.push(message[i]);
    }
    const listItems = display.map((thing) => 
        <tr><Link to={"/details/" + thing._id}>{thing.title}</Link><Link to={"/delete/" + thing._id}>   (Delete)</Link><Link to={"/edit/" + thing._id}>   (Edit)</Link></tr>
    );
    return (
        <div>
            <h2>All Products</h2>
            <table>{listItems}</table>
        </div>
    )
}