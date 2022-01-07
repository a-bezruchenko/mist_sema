import React, {Component} from 'react';
import SingleComponent from "./SingleComponent";

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <SingleComponent endpoint={'processors'} title={"Процессор"}/>
        );
    }
}
