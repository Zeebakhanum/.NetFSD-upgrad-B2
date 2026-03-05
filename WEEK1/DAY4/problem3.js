// Store signal color (string value)
let signal = "yellow";   // Change to "red", "green", or any other value

// Traffic signal simulator using switch-case
switch (signal) {
    case "red":
        console.log("Signal: RED");
        console.log("Instruction: Stop");
        break;

    case "yellow":
        console.log("Signal: YELLOW");
        console.log("Instruction: Get Ready");
        break;

    case "green":
        console.log("Signal: GREEN");
        console.log("Instruction: Go");
        break;

    default:
        console.log("Invalid signal color entered.");
        console.log("Please enter red, yellow, or green.");
}