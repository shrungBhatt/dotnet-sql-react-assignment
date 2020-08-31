import React from "react";

import './Provider.css'
import avatar from '../../../images/avatar.png'

const provider = (props) => {

    let imageSrc = props.image;
    if(imageSrc === null){
        imageSrc = avatar;
    }

    return (
        <div className="Provider">
            <img className="img" src={imageSrc} alt="Avatar"/>
            <div className="DetailsDiv">
                <h4 className="h4"><b>{props.title}</b></h4>
                <ul className="ul">
                    {props.subspecialties.map(x => (
                        <li className="li">{x}</li>
                    ))}
                </ul>
            </div>
        </div>
    );
};

export default provider;