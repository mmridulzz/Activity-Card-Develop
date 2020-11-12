import { combineReducers } from "redux";
import { admin } from "./admin";
import { teacher } from "./teacher";
import { student } from "./student";
import { user } from "./user";
import { classes } from "./classes";
import { teacherclasses } from "./teacherclasses";
import { schoolyears } from "./schoolyears";
import { email } from "./email";
import { notifications } from "./notification";


 export const reducers = combineReducers({
    admin, teacher, user, classes, teacherclasses, schoolyears,student,email,notifications
})
//const rootReducer = (state, action) => {
    // Clear all data in redux store to initial.
    //if (action.type === ACTION_TYPES.CLEAR_DATA) {
    //    state = undefined;
        
   // }
    

    //return reducers(state, action);
//};
//export default rootReducer;