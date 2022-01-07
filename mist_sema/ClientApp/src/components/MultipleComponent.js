import {useEffect, useState} from "react";
import {Autocomplete, Box, Card, CardContent, CardMedia, Stack, TextField, Typography} from "@mui/material";
import NumericInput from 'react-numeric-input';

export default function MultipleComponent({title, endpoint}) {
    let [components, setComponents] = useState([]);
    let [allComponents, setAllComponents] = useState([]);
    let [idToCount, setIdToCount] = useState({})

    useEffect(() => {
        fetch(endpoint)
            .then((response) => response.json())
            .then((components) => components.map((component_) => ({label: component_.manufacturer + " " + component_.name, ...component_})))
            .then((json) => {
                console.log(json);
                return json
            })
            .then((components) => setAllComponents(components))
    }, [])
    return (<div style={{display: 'flex'}}>
        <Stack direction={"row"} spacing={2}>
            <Autocomplete
                multiple
                disablePortal
                options={allComponents}
                style={{minWidth: 300}}
                sx={{minWidth: 300}}
                renderInput={(params) => <TextField {...params} label={title}/>}
                onChange={(_, value) => {
                    setComponents(value);
                    console.log(value);
                }}
            />
            <Stack spacing={1}>
                {
                    components.map(component => <Card sx={{maxHeight: 151, minHeight: 151, display: 'flex'}}>
                        <CardMedia
                            component="img"
                            sx={{maxWidth: 151, minWidth: 151, backgroundSize: "contain"}}
                            image={component?.imageLink}
                            alt={component?.label}
                        />
                        <Box sx={{display: 'flex', flexDirection: 'column'}}>
                            <CardContent sx={{flex: '1 0 auto'}}>
                            <Typography component="div" variant="h5">
                                {component?.name}
                            </Typography>
                            <Typography variant="subtitle1" component="div">
                                {component?.manufacturer}
                            </Typography>
                        </CardContent>
                        <Box sx={{display: 'flex', alignItems: 'center', pl: 1, pb: 1, justifyContent: "flex-end"}}>
                            <NumericInput
                                mobile
                                min={1}
                                value={idToCount[component?.id] ?? 1}
                                onChange={(_, value) => idToCount[component?.id] = value}
                            />
                        </Box>
                        </Box>
                    </Card>)
                }
            </Stack>
        </Stack>
    </div>)
}