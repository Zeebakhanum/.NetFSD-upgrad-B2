// Store a number
let number = 7;   // Change this value to test

// Check Positive or Negative using ternary operator
let result = (number >= 0) ? "Positive" : "Negative";
console.log("Number: " + number);
console.log("Sign: " + result);

// Check Even or Odd using if–else
if (number % 2 === 0) {
    console.log("Parity: Even");
} else {
    console.log("Parity: Odd");
}

// Print numbers from 1 to the given number using loop
console.log("Numbers from 1 to " + number + ":");

for (let i = 1; i <= number; i++) {
    console.log(i);
}