import {useEffect, useState} from "react";
import {Autocomplete, Box, Card, CardContent, CardMedia, Stack, TextField, Typography} from "@mui/material";

export default function SingleComponent({title, endpoint, configIds, setConfigIds}) {
    let [component, setComponent] = useState(null);
    let [allComponents, setAllComponents] = useState([]);
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
    const updateConfigIds = function (old_value, new_value) {
        setConfigIds([...configIds.filter(id => id !== old_value?.id), new_value?.id]
            .filter(id => id !== null)
            .filter(id => id !== undefined))
    }
    return (<div style={{display: 'flex'}}>
        <Stack direction={"row"} spacing={2}>
            <Autocomplete
                disablePortal

                options={allComponents}
                sx={{width: 300, alignSelf: 'center'}}
                renderInput={(params) => <TextField {...params} label={title}/>}
                onChange={(_, value) => {
                    updateConfigIds(component, value)
                    setComponent(value);
                    console.log(value);
                }}
            />
            <Card sx={{maxHeight: 151, minHeight: 151, display: 'flex', opacity: !component ? 0 : 1}}>

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
                        <Typography variant="h6" component="div">
                            {"Цена: " + component?.price + "₽"}
                        </Typography>
                    </CardContent>
                </Box>
            </Card>
        </Stack>
    </div>)
}