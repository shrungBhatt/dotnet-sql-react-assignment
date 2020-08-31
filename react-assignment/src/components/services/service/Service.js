import React from "react";

import './Service.css'

const service = (props) => {

    let styleClass = "Service";
    if(props.highlightBackgound){
        styleClass = "ServiceToggled"
    }

    return (
        <div className={styleClass} onClick={props.click}>{props.title}</div>
    )
}


export default service;