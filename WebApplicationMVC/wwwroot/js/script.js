console.log("Default menu site loaded successfully!");
var email= document.getElementById("exampleInputEmail1");
var password= document.getElementById("exampleInputPassword1");
var button = document.getElementById("submitBtn");
button.addEventListener("click", function(){
    event.preventDefault();
    console.log("email: ",email.value);
    console.log("password: ",password.value);
    
    
})

