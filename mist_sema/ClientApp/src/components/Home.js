import React, {Component} from 'react';
import SingleComponent from "./SingleComponent";
import MultipleComponent from "./MultipleComponent";
import {Grid, Stack} from "@mui/material";

export let configurationIds = []

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (<>
                <Grid container>
                    <Grid item xs={"auto"}>
                        <Stack spacing={2}>
                            <SingleComponent endpoint={'processors'} title={"Процессор"}/>
                            <SingleComponent endpoint={'graphic_cards'} title={"Графический процессор"}/>
                            <SingleComponent endpoint={'system_boards'} title={"Материнская плата"}/>
                            <SingleComponent endpoint={'power_supplies'} title={"Блок питания"}/>
                            <MultipleComponent endpoint={'rams'} title={"Оперативная память"}/>
                            <MultipleComponent endpoint={'storage_devices'} title={"Жёсткие диски или SSD"}/>
                        </Stack>
                    </Grid>
                    <Grid item xs={3}>
                        <Stack/>
                    </Grid>
                </Grid>
            </>
        );
    }
}
