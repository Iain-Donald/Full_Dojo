import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
export default () => {
    const [ message, setMessage ] = useState("Loading...")
    const { id } =  useParams();
    useEffect(()=>{
        axios.get("http://localhost:8000/api/getByID/" + id)
            .then(res=>{
                setMessage(res.data.user)
            })       
    }, [id]);
    
    return (
        <div>
            <h2>{message.title}</h2>
            <h3>Price: ${message.price}</h3>
            <h3>Description: {message.description}</h3>
        </div>
    )
}