﻿import api from "./api";

export const ACTION_TYPES = {
    CREATE: 'CREATE',
    UPDATE: 'UPDATE',
    DELETE: 'DELETE',
    FETCH_ALL: 'FETCH_ALL',
    FETCHBYID: 'FETCHBYID',
    FETCHING: 'FETCHING',
    CLEAR_DATA:'CLEAR_DATA'
}



export const fetchAll = () => dispatch => {
    dispatch({ type: ACTION_TYPES.FETCHING });
    api.classes().fetchAll()
        .then(response => {
            dispatch({
                type: ACTION_TYPES.FETCH_ALL,
                payload: response.data
            })
        })
        .catch(err => console.log(err))
}
export const cleardata = () => dispatch => {
    dispatch({ type: ACTION_TYPES.CLEAR_DATA });
    
}
export const fetchById = (id) => dispatch => {
    api.classes().fetchById(id)
        .then(response => {
            dispatch({
                type: ACTION_TYPES.FETCHBYID,
                payload: response.data
            })
        })
        .catch(err => console.log(err))
}

export const create = (data, onSuccess) => dispatch => {

    api.classes().create(data)
        .then(res => {
            dispatch({
                type: ACTION_TYPES.CREATE,
                payload: res.data
            })
            onSuccess()
        })
        .catch(err => console.log(err))
}

export const update = (id, data, onSuccess) => dispatch => {

    api.classes().update(id, data)
        .then(res => {
            dispatch({
                type: ACTION_TYPES.UPDATE,
                payload: { id, ...data }
            })
            onSuccess()
        })
        .catch(err => console.log(err))
}

export const Delete = (id, onSuccess) => dispatch => {
    api.classes().delete(id)
        .then(res => {
            dispatch({
                type: ACTION_TYPES.DELETE,
                payload: id
            })
            onSuccess()
        })
        .catch(err => console.log(err))
}