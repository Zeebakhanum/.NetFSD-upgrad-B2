/* 🔹 CUSTOM ALERT (Better than alert()) */
function showAlert(message){
let alertBox = document.createElement("div")
alertBox.innerText = message

alertBox.style.position = "fixed"
alertBox.style.top = "20px"
alertBox.style.right = "20px"
alertBox.style.background = "#1e94dc"
alertBox.style.color = "white"
alertBox.style.padding = "10px 20px"
alertBox.style.borderRadius = "8px"
alertBox.style.boxShadow = "0px 0px 10px gray"
alertBox.style.zIndex = "1000"

document.body.appendChild(alertBox)

setTimeout(()=>{
    alertBox.remove()
},2000)

}

/*  REGISTER EVENT */
function registerEvent(e){
e.preventDefault()
showAlert("Registered successfully!")
}

/*  LOGIN */
function loginUser(e){
e.preventDefault()

let email = document.getElementById("email").value
let password = document.getElementById("password").value

if(email=="admin@upgrad.com" && password=="12345"){
    localStorage.setItem("adminLogin", "true")
    window.location="events.html"
}else{
    showAlert("Invalid login credentials")
}

}

/*  CHECK LOGIN */
function checkLogin(){
let isLoggedIn = localStorage.getItem("adminLogin")

if(isLoggedIn !== "true"){
    showAlert("Please login first")
    window.location="login.html"
}

}

/*  LOGOUT */
function logout(){
localStorage.removeItem("adminLogin")
showAlert("Logged out successfully")
setTimeout(()=>{
window.location="login.html"
},1000)
}

/*  ADD EVENT */
function addEvent(e){
e.preventDefault()

let event = {
    id: eventId.value,
    name: eventName.value,
    category: category.value,
    date: date.value,
    time: time.value,
    url: url.value
}

let events = JSON.parse(localStorage.getItem("events")) || []
events.push(event)

localStorage.setItem("events", JSON.stringify(events))

showAlert("Event added successfully!")

e.target.reset()
displayEvents()

}

/*  DISPLAY EVENTS */
function displayEvents(){

let events = JSON.parse(localStorage.getItem("events")) || []
let container = document.getElementById("eventList")

if(!container) return

container.innerHTML = ""

events.forEach((e,i)=>{

    container.innerHTML += `
    <div class="col-md-4 fade-in">
    <div class="card m-2">
    <div class="card-body">

    <h5>${e.name}</h5>
    <p>ID: ${e.id}</p>
    <p>${e.category}</p>
    <p>${e.date} | ${e.time}</p>

    <a href="${e.url}" class="btn btn-primary w-100 mb-2">Join</a>
    <button onclick="deleteEvent(${i})" class="btn btn-danger w-100">Delete</button>

    </div>
    </div>
    </div>
   
</div>
    `
})

}

/*  DELETE EVENT */
function deleteEvent(i){
let events = JSON.parse(localStorage.getItem("events"))
events.splice(i,1)
localStorage.setItem("events", JSON.stringify(events))

showAlert("Event deleted")
displayEvents()

}

/*  LOAD HOME EVENTS */
function loadHomeEvents(){

let events = JSON.parse(localStorage.getItem("events")) || []
let container = document.getElementById("homeEvents")

if(!container) return

container.innerHTML = ""

if(events.length === 0){
    container.innerHTML = "<p class='text-center'>No events available</p>"
    return
}

events.forEach(e => {

    container.innerHTML += `
    <div class="col-md-4 fade-in">
    <div class="card m-2">
    <div class="card-body text-center">

    <h5>${e.name}</h5>
    <p>${e.category}</p>
    <p>${e.date} | ${e.time}</p>

    <a href="#" onclick="registerEvent(event)" 
    class="btn btn-primary w-100">
    Register Now
    </a>

    </div>
    </div>
    </div>
    `
})

}

/*  SEARCH EVENT */
function searchEvent(){

let keyword = document.getElementById("search").value.toLowerCase()
let category = document.getElementById("filterCategory").value

let events = JSON.parse(localStorage.getItem("events")) || []
let container = document.getElementById("eventList")

container.innerHTML = ""

let filtered = events.filter(e =>
    (e.name.toLowerCase().includes(keyword) ||
    e.category.toLowerCase().includes(keyword) ||
    e.id.includes(keyword))
    &&
    (category === "" || e.category === category)
)

filtered.forEach((e,i)=>{
    container.innerHTML += `
    <div class="col-md-4 fade-in">
    <div class="card m-2">
    <div class="card-body">

    <h5>${e.name}</h5>
    <p>ID: ${e.id}</p>
    <p>${e.category}</p>
    <p>${e.date}</p>

    <a href="${e.url}" class="btn btn-primary w-100 mb-2">Join</a>
    <button onclick="deleteEvent(${i})" class="btn btn-danger w-100">Delete</button>

    </div>
    </div>
    </div>
    `
})

}

/*  CONTACT */
function submitContact(e){
e.preventDefault()
showAlert("Query submitted successfully!")
}