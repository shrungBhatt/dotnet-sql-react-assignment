import React from "react";

import Provider from './provider/Provider';

const providers = (props) => {
    if(props.data.length !== 0){
        return props.data.map(provider => (
            <Provider title={provider.attributes.name} image={provider.attributes['card-image']}
                      subspecialties={provider.attributes.subspecialties}/>
        ));
    }else{
        const labelStyle = {
            marginLeft: 20,
        };

        return <label style={labelStyle}>No providers available for this service</label>
    }

};

export default providers;