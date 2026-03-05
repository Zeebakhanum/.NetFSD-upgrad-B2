// This function will be called when button is clicked
function handleButtonClick() {

    // Create user object
    var user = {
        name: "Rahul",
        age: 25,
        city: "Hyderabad"
    };

    // Pass object to function
    displayUserInfo(user);
}


// Function that accepts object as parameter
function displayUserInfo(userObj) {

    // Access properties using dot notation
    document.getElementById("name").textContent = "Name: " + userObj.name;
    document.getElementById("age").textContent = "Age: " + userObj.age;
    document.getElementById("city").textContent = "City: " + userObj.city;
}