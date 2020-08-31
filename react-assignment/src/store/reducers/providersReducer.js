import * as actionTypes from '../actions/actionTypes';
import {updateObject} from '../utility';

const initialState = {
    providers: [],
    cachedProviders: [],
    selectedServiceId: "",
};

const getFilteredProviders = (state, id) => {

    state.selectedServiceId = id;
    if (state.cachedProviders.length === 0) {
        state.cachedProviders = [...state.providers]
    }
    return {
        ...state,
        providers: state.cachedProviders.filter(provider => {
            if (provider.attributes.subspecialties !== undefined) {
                const temp = provider.attributes.subspecialties.filter(x => x === id);
                if (temp.length > 0) {
                    return true;
                }
            } else {
                return false;
            }
        })
    }

}

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.SET_PROVIDERS :
            return updateObject(state, {providers: action.result});
        case actionTypes.FILTER_PROVIDERS:
            return getFilteredProviders(state, action.result);
        default:
            return state;
    }
};

export default reducer;