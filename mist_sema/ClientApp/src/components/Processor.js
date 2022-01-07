import {useEffect, useState} from "react";
import {Autocomplete, Box, Card, CardContent, CardMedia, TextField, Typography} from "@mui/material";

export default function Processor() {
    let [processor, setProcessor] = useState(null);
    let [allProcessors, setAllProcessors] = useState([]);
    useEffect(() => {
        fetch('processors')
            .then((response) => response.json())
            .then((processors) => processors.map((processor) => ({ label: processor.manufacturer + " " + processor.name, ...processor })))
            .then((json) => { console.log(json); return json })
            .then((processors) => setAllProcessors(processors))
    }, [])
    return (<div style={{marginTop: "20px", display: 'flex'}}>
        <Autocomplete
            disablePortal
            id={"processor-selector"}
            options={allProcessors}
            sx={{ width: 300, marginRight: 10, alignSelf: 'center' }}
            renderInput={(params) => <TextField {...params} label="Процессор" />}
            onChange={(_, value) => { setProcessor(value); console.log(value); }}
            />
        <Card sx={{ maxHeight: 151, minHeight: 151, display: 'flex' }}>
            
            <CardMedia
                component="img"
                sx={{ maxWidth: 151, minWidth: 151, backgroundSize: "contain" }}
                image={processor?.imageLink}
                alt={processor?.label}
            />
            <Box sx={{ display: 'flex', flexDirection: 'column' }}>
                <CardContent sx={{ flex: '1 0 auto' }}>
                    <Typography component="div" variant="h5">
                        { processor?.name }
                    </Typography>
                    <Typography variant="subtitle1"  component="div">
                        {processor?.manufacturer}
                    </Typography>
                </CardContent>
            </Box>
        </Card>
    </div>)
}