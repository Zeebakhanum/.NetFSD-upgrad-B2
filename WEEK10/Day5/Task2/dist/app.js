"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const constants_1 = require("./constants");
const student_service_1 = require("./student.service");
const utils_1 = require("./utils");
const students = [
    { id: 1, name: "john", marks: 85 },
    { id: 2, name: "david", marks: 92 },
    { id: 3, name: "alex", marks: 76 }
];
for (let student of students) {
    console.log((0, utils_1.formatName)(student.name));
    console.log((0, student_service_1.getGrade)(student.marks));
}
console.log((0, utils_1.calculateAverage)(students));
console.log((0, student_service_1.getTopper)(students));
console.log(constants_1.PASS_MARKS);
