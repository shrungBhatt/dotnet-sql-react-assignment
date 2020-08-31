import React, {Component} from 'react';
import {connect} from 'react-redux';

import Services from '../../components/services/Services';
import Providers from '../../components/providers/Providers';
import '../layout/Layout.css';
import * as actionCreators from '../../store/actions/index';

class Layout extends Component {

    componentDidMount() {
        this.props.fetchServices();
        this.props.fetchProviders();
    }

    render() {
        return (
            <div>
                <h3 className="h3">Services</h3>
                <div className="Services">
                    <Services data={this.props.services} click={this.props.filterProviders}
                              selectedServiceId={this.props.selectedServiceId}/>
                </div>
                <h3 className="h3">Providers</h3>
                <div className="Providers">
                    <Providers data={this.props.providers}/>
                </div>
            </div>
        )
    }

}

const mapStateToProps = state => {
    return {
        services: state.servicesReducer.services,
        providers: state.providersReducer.providers,
        selectedServiceId: state.providersReducer.selectedServiceId
    }
};

const mapDispatchToProps = dispatch => {
    return {
        fetchServices: () => dispatch(actionCreators.getServices()),
        fetchProviders: () => dispatch(actionCreators.getProviders()),
        filterProviders: (id) => dispatch(actionCreators.filterProviders(id))
    }
};


export default connect(mapStateToProps, mapDispatchToProps)(Layout);