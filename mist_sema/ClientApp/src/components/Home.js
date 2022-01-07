import React, {Component} from 'react';
import Processor from "./Processor";

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <Processor/>
        );
    }
}
