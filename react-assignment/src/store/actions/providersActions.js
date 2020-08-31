import * as actionTypes from '../actions/actionTypes';

export const getProviders = () => {
    return(dispatch, getState) => {
        fetch("https://api.inquickerstaging.com/v3/winter.inquickerstaging.com/providers?include=locations%2Cschedules.location&page%5Bnumber%5D=1&page%5Bsize%5D=10")
            .then(response => response.json())
            .then(data => dispatch(setProviders(data)));
    }
}

export const setProviders = (result) => {
    return {
        type: actionTypes.SET_PROVIDERS,
        result: result.data
    };
}

export const filterProviders = (id) => {
    return {
        type: actionTypes.FILTER_PROVIDERS,
        result: id
    }
}