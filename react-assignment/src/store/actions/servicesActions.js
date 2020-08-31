import * as actionTypes from '../actions/actionTypes';

export const getServices = () => {
    return(dispatch, getState) => {
        fetch("https://api.inquickerstaging.com/v3/winter.inquickerstaging.com/services")
            .then(response => response.json())
            .then(data => dispatch(setServices(data)));
    }
}

export const setServices = (result) => {
    return {
        type: actionTypes.SET_SERVICES,
        result: result.data
    };
}