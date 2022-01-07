import {useEffect, useState} from "react";
import {Autocomplete, Box, Card, CardContent, CardMedia, TextField, Typography} from "@mui/material";

export default function SingleComponent({title, endpoint}) {
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
    return (<div style={{marginTop: "20px", display: 'flex'}}>
        <Autocomplete
            disablePortal
            options={allComponents}
            sx={{width: 300, marginRight: 10, alignSelf: 'center'}}
            renderInput={(params) => <TextField {...params} label={title}/>}
            onChange={(_, value) => {
                setComponent(value);
                console.log(value);
            }}
        />
        <Card sx={{maxHeight: 151, minHeight: 151, display: 'flex'}}>

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
            </Box>
        </Card>
    </div>)
}