import {useEffect, useState} from "react";
import {Alert} from "@mui/material";

export default function Validation({configIds}) {
    const [isValid, setIsValid] = useState(null)
    const [errors, setErrors] = useState([])
    useEffect(() => {
        fetch('validate_configuration', {
            method: "POST",
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(configIds)
        }).then(res => {
            return res.json()
        }).then(res => {
            setIsValid(res.isValid);
            setErrors(res.message.split('\n').filter(error => error !== ""))
        })
    }, [configIds])
    
    if (isValid) {
        return <Alert severity="success">Ваша сборка не имеет проблем!</Alert>
    }

    return errors.map((error) => <Alert severity={"error"}>{error}</Alert>);
}