function changeText(){
    if(login.innerHTML == "Login") login.innerHTML = "Logout";
    else login.innerHTML = "Login";
}

function removeElement(){
    var element = document.getElementById("definition");
    element.remove();
}

function popup(){
    alert("Ninja was liked");
}