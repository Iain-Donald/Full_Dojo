import React, { useState } from 'react'
import axios from 'axios';
import { Link } from 'react-router-dom';
import '../App.css';
export default () => {
    //keep track of what is being typed via useState hook
    const [pirateName, setName] = useState(""); 
    const [imageURL, setURL] = useState("");
    const [chests, setChests] = useState("");
    const [piratePhrase, setPhrase] = useState("");
    let [crewPosition, setPosition] = useState("");
    let [pegLeg, setPegLeg] = useState("");
    let [eyePatch, setEyePatch] = useState("");
    let [hookHand, setHookHand] = useState("");
    const onSubmitHandler = e => {
        e.preventDefault();

        if(!pegLeg) pegLeg = false;
        if(!eyePatch) eyePatch = false;
        if(!hookHand) hookHand = false;
        if(crewPosition == "") crewPosition = "First Mate";

        axios.post('http://localhost:8000/api/people', {
            pirateName,
            imageURL,
            chests,
            piratePhrase,
            crewPosition,
            pegLeg,
            eyePatch,
            hookHand
        })
            .then(res=>console.log(res))
            .catch(err=>console.log(err))
    }

    return (
        <div>
            <div id='inline'>
                <h1 class='header'>Add Pirate</h1>
                <button className='blueButton'>
                <Link to="/">Crew Board</Link>
                </button>
            </div>
                <form onSubmit={onSubmitHandler}>
                    <div class='displayCenter'>
                    <p>
                        <label>Pirate Name:</label><br/>
                        <input type="text" onChange={(e)=>setName(e.target.value)} value={pirateName}/>
                    </p>
                    <p>
                        <label>Image URL:</label><br/>
                        <input type="text" onChange={(e)=>setURL(e.target.value)} value={imageURL}/>
                    </p>
                    <p>
                        <label># of Treasure Chests:</label><br/>
                        <input type="number" onChange={(e)=>setChests(e.target.value)} value={chests}/>
                    </p>
                    <p>
                        <label>Pirate Catch Phrase:</label><br/>
                        <input type="text" onChange={(e)=>setPhrase(e.target.value)} value={piratePhrase}/>
                    </p>
                    <p>
                        <label>Crew Position:</label><br/>
                        <select onChange={(e)=>setPosition(e.target.value)} value={crewPosition}>
                            <option value="First Mate">First Mate</option>
                            <option value="Quarter Master">Quarter Master</option>
                            <option value="Boatswain">Boatswain</option>
                            <option value="Powder Monkey">Powder Monkey</option>
                        </select>
                    </p>
                    <p>
                        <label>Peg Leg:</label><br/>
                        <input type="checkbox" onChange={(e)=>setPegLeg(e.target.checked)} value="true"/>
                    </p>
                    <p>
                        <label>Eye Patch:</label><br/>
                        <input type="checkbox" onChange={(e)=>setEyePatch(e.target.checked)} value="true"/>
                    </p>
                    <p>
                        <label>Hook Hand:</label><br/>
                        <input type="checkbox" onChange={(e)=>setHookHand(e.target.checked)} value="true"/>
                    </p>
                    <input type="submit" value="Add Pirate"/>
                    </div>
                </form>
                <p>Example img URL: https://www.w3schools.com/html/pic_trulli.jpg</p>
        </div>
    )
}

/* 
<p>
                <Link to="/">Crew Board</Link>
            </p>




            <p>
                <label>Crew Position:</label><br/>
                <input type="text" onChange={(e)=>setPosition(e.target.value)} value={crewPosition}/>
            </p>
*/