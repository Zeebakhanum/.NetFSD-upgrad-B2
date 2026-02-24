// Student Marks Analyzer (ES6 Module)

// Store student marks in an array
const marks = [75, 82, 48, 90, 67];

// Calculate total using reduce()
const calculateTotal = (arr) =>
  arr.reduce((total, mark) => total + mark, 0);

// Calculate average
const calculateAverage = (arr) => {
  const total = calculateTotal(arr);
  return total / arr.length;
};

// Determine pass/fail (Pass if average >= 50)
const getResult = (average) => (average >= 50 ? "PASS ✅" : "FAIL ❌");

// Process marks (using map just to demonstrate array processing)
const processedMarks = marks.map((mark, index) => ({
  subject: `Subject ${index + 1}`,
  mark: mark
}));

// Perform calculations
const totalMarks = calculateTotal(marks);
const averageMarks = calculateAverage(marks);
const result = getResult(averageMarks);

// Display Output using template literals
console.log(`📊 Student Marks Report
-------------------------
Marks: ${marks.join(", ")}

Total Marks: ${totalMarks}
Average Marks: ${averageMarks.toFixed(2)}
Final Result: ${result}
`);