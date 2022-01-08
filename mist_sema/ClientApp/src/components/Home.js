import React, {useState} from 'react';
import SingleComponent from "./SingleComponent";
import MultipleComponent from "./MultipleComponent";
import {Grid, Stack} from "@mui/material";
import Validation from "./Validation";

export function Home() {
    const [configIds, setConfigIds] = useState([])
    
    return (<>
            <Grid container>
                <Grid item xs={8}>
                    <Stack spacing={2}>
                        <SingleComponent endpoint={'processors'} title={"Процессор"} configIds={configIds}
                                         setConfigIds={setConfigIds}/>
                        <SingleComponent endpoint={'graphic_cards'} title={"Графический процессор"}
                                         configIds={configIds} setConfigIds={setConfigIds}/>
                        <SingleComponent endpoint={'system_boards'} title={"Материнская плата"} configIds={configIds}
                                         setConfigIds={setConfigIds}/>
                        <SingleComponent endpoint={'power_supplies'} title={"Блок питания"} configIds={configIds}
                                         setConfigIds={setConfigIds}/>
                        <MultipleComponent endpoint={'rams'} title={"Оперативная память"} configIds={configIds}
                                           setConfigIds={setConfigIds}/>
                        <MultipleComponent endpoint={'storage_devices'} title={"Жёсткие диски или SSD"}
                                           configIds={configIds} setConfigIds={setConfigIds}/>
                    </Stack>
                </Grid>
                <Grid item xs={2}>
                    <Validation configIds={configIds}/>
                </Grid>
            </Grid>
        </>
    );
}