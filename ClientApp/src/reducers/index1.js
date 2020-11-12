import { combineReducers } from "redux";
import { teacherclasses } from "./teacherclasses";
import { student } from "./student";
import { classes } from "./classes";

export const reducers1 = combineReducers({
    student, teacherclasses,classes
})