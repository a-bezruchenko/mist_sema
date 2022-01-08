import {useEffect, useState} from "react";
import {Paper, Typography} from "@mui/material";

export default function TotalPrice({configIds}) {
    const [price, setPrice] = useState(0)
    useEffect(() => {
        fetch('configuration_summary', {
            method: "POST",
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(configIds)
        }).then(res => {
            return res.json()
        }).then(res => {
            console.log(res)
            setPrice(res?.totalPrice ? parseInt(res?.totalPrice) : 0);
        })
    }, [configIds])

    return <Paper>
        <Typography variant={"h3"}>Общая сумма:</Typography>
        <Typography variant={"h4"}>{price + "₽"}</Typography>
    </Paper>
}