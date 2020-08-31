import React from "react";

import Service from '../services/service/Service';

const services = (props) => {
    if (props.data.length !== 0) {
        return props.data.map(service => (
            <Service title={service.attributes.name}
                     click={() => props.click(service.attributes.name)}
                     highlightBackgound={service.attributes.name === props.selectedServiceId}/>
        ));
    } else {
        const labelStyle = {
            marginLeft: 20,
        };

        return <label style={labelStyle}><b>Loading data</b></label>
    }

};

export default services;