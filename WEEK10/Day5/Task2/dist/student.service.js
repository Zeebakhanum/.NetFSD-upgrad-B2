"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.getGrade = getGrade;
exports.getTopper = getTopper;
function getGrade(marks) {
    if (marks >= 90)
        return "A";
    if (marks >= 75)
        return "B";
    if (marks >= 40)
        return "C";
    return "Fail";
}
function getTopper(students) {
    let topper = students[0];
    for (let student of students) {
        if (student.marks > topper.marks) {
            topper = student;
        }
    }
    return topper;
}
