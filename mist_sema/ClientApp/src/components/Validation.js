import {useEffect, useState} from "react";
import {Accordion, AccordionDetails, AccordionSummary, Alert, Badge, Stack, Typography} from "@mui/material";
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import {styled} from '@mui/material/styles';

const StyledBadge = styled(Badge)(({theme}) => ({
    '& .MuiBadge-badge': {
        right: -10,
        top: 17,
        border: `2px solid ${theme.palette.background.paper}`,
        padding: '0 4px',
    },
}));

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

    return <Accordion>
        <AccordionSummary
            expandIcon={<ExpandMoreIcon/>}
        >
            <StyledBadge badgeContent={errors.length} color={errors.length === 0 ? "success" : "error"}>
                <Typography variant={"h6"}>Ошибки в совместимости сборки</Typography>
            </StyledBadge>
        </AccordionSummary>
        <AccordionDetails>
            <Stack spacing={1}>
                {errors.map((error) => <Alert severity={"error"}>{error}</Alert>)}
            </Stack>
        </AccordionDetails>
    </Accordion>;
}