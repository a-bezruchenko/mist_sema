import React, {Component} from 'react';
import SingleComponent from "./SingleComponent";

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (<>
                <SingleComponent endpoint={'processors'} title={"Процессор"}/>
                <SingleComponent endpoint={'graphic_cards'} title={"Графический процессор"}/>
                <SingleComponent endpoint={'system_boards'} title={"Материнская плата"}/>
                <SingleComponent endpoint={'power_supplies'} title={"Блок питания"}/>
            </>
        );
    }
}
