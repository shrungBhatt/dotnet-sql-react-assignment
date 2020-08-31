import * as actionTypes from '../actions/actionTypes';
import {updateObject} from '../utility';

const initialState = {
    services: []
};

const filterServices = (services) => {
    //Remove the redundant services
    return services.filter((service, index, self) =>
        index === self.findIndex((t) => (
            t.id === service.id
        ))
    )
}

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.SET_SERVICES :
            return updateObject(state, {services: filterServices(action.result)});
        default:
            return state;
    }
};

export default reducer;