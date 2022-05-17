import React, { useState } from  'react';
    
    
const UserForm = (props) => {
    const [firstname, setFN] = useState("");
    const [lastname, setLN] = useState("");
    const [email, setEmail] = useState("");
    const [PW, setPW] = useState("");
    const [CPW, confPW] = useState("");
    
    const createUser = (e) => {
        e.preventDefault();
        let errorThrown = false;

        if(firstname.length < 2){
            document.getElementById("FNError").innerHTML = "First name must be at least 2 characters";
            errorThrown = true;
        } else {
            document.getElementById("FNError").innerHTML = "";
        }

        if(lastname.length < 2){
            document.getElementById("LNError").innerHTML = "Last name must be at least 2 characters";
            errorThrown = true;
        } else {
            document.getElementById("LNError").innerHTML = "";
        }

        if(email.length < 2){
            document.getElementById("EmailError").innerHTML = "Email must be at least 2 characters";
            errorThrown = true;
        } else {
            document.getElementById("EmailError").innerHTML = "";
        }
        
        if (PW.length < 8){
            document.getElementById("PWError").innerHTML = "Password must be at least 8 characters";
            errorThrown = true;
        } else {
            document.getElementById("PWError").innerHTML = "";
        }

        if(PW != CPW) {
            document.getElementById("PWValidation").innerHTML = "Passwords do not match";
            errorThrown = true;
        } else {
            document.getElementById("PWValidation").innerHTML = "";
        }
        
        
        if(!errorThrown) {
            const newUser = { firstname, lastname, email, PW };
            console.log("Welcome", newUser);
        }
    };
    
    return(
        <form onSubmit={ createUser }>
            <div>
                <label>First Name: </label> 
                <input type="text" onChange={ (e) => setFN(e.target.value) } />
                <p id="FNError"></p>
            </div>
            <div>
                <label>Last Name: </label> 
                <input type="text" onChange={ (e) => setLN(e.target.value) } />
                <p id="LNError"></p>
            </div>
            <div>
                <label>Email: </label>
                <input type="text" onChange={ (e) => setEmail(e.target.value) } />
                <p id="EmailError"></p>
            </div>
            <div>
                <label>Password: </label>
                <input type="text" onChange={ (e) => setPW(e.target.value) } />
                <p id="PWError"></p>
            </div>
            <div>
                <label>Confirm Password: </label>
                <input type="text" onChange={ (e) => confPW(e.target.value) } />
                <p id="PWValidation"></p>
            </div>
            <input type="submit" value="Create User" />
        </form>
    );
};
    
export default UserForm;