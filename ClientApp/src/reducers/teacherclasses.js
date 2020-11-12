import { ACTION_TYPES } from "../actions/teacherclasses";
const initialState = {
    list: [],loading:false
}


export const teacherclasses = (state = initialState, action) => {

    switch (action.type) {
        case ACTION_TYPES.FETCHING:
            return {
                ...state,
                list: [],
                loading: true
            }
        case ACTION_TYPES.CLEAR_DATA:
            return {
                undefined
                
            }
       
        case ACTION_TYPES.FETCH_ALL:
            return {
                ...state,
                list: [...action.payload],loading:false
            }
        case ACTION_TYPES.FETCHBYID:

            return {
                ...state,
                list: { ...action.payload }
            }

        case ACTION_TYPES.CREATE:
            return {
                ...state,
                list: [...state.list, action.payload]
            }

        case ACTION_TYPES.UPDATE:
            return {
                ...state,
                list: { ...state.list }
            }

        case ACTION_TYPES.DELETE:
            return {
                ...state,
                list: state.list.filter(x => x.id != action.payload)
            }

        default:
            return state
    }
}