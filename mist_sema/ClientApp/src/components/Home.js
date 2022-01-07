import React, {Component} from 'react';
import SingleComponent from "./SingleComponent";
import MultipleComponent from "./MultipleComponent";

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (<>
                <SingleComponent endpoint={'processors'} title={"Процессор"}/>
                <SingleComponent endpoint={'graphic_cards'} title={"Графический процессор"}/>
                <SingleComponent endpoint={'system_boards'} title={"Материнская плата"}/>
                <SingleComponent endpoint={'power_supplies'} title={"Блок питания"}/>
                <MultipleComponent endpoint={'rams'} title={"Оперативная память"}/>
                <MultipleComponent endpoint={'storage_devices'} title={"Жёсткие диски или SSD"}/>
            </>
        );
    }
}
