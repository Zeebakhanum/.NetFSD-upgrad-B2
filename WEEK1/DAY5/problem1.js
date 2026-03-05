function generateGreeting(name) {

    // Greeting message variable declared inside function
    var message = "Hello, " + name + "! Welcome to our website.";

    // Display greeting inside <p>
    document.getElementById("greeting").textContent = message;
}


// This function will be called on button click
function handleClick() {
    var userName = document.getElementById("username").value;
    generateGreeting(userName);
}