import {
  Container,
  Typography,
  ButtonGroup,
  Button,
  Alert,
  AlertTitle,
  List,
  ListItem,
  ListItemText,
} from "@mui/material";
import { useState } from "react";
import agent from "../../app/api/agent";
export default function AboutPage() {
  const [validationErrors, setValidationErrors] = useState<string[]>([]);

  function getValidationError() {
    agent.TextErrors.getValidationError()
      .then(() => console.log("dsadas"))
      .catch((error) => setValidationErrors(error));
  }
  return (
    <Container>
      <Typography gutterBottom variant="h2">
        error for test
      </Typography>

      <ButtonGroup>
        <Button
          variant="contained"
          onClick={() =>
            agent.TextErrors.get400Error().catch((error) => console.log(error))
          }
        >
          test 400 error
        </Button>
        <Button
          variant="contained"
          onClick={() =>
            agent.TextErrors.get401Error().catch((error) => console.log(error))
          }
        >
          test 401 error
        </Button>
        <Button
          variant="contained"
          onClick={() =>
            agent.TextErrors.get404Error().catch((error) => console.log(error))
          }
        >
          test 404 error
        </Button>
        <Button
          variant="contained"
          onClick={() =>
            agent.TextErrors.get500Error().catch((error) => console.log(error))
          }
        >
          test 500 error
        </Button>
        <Button variant="contained" onClick={getValidationError}>
          test Validation error
        </Button>
      </ButtonGroup>
      {validationErrors.length > 0 && (
        <Alert severity="error">
          <AlertTitle>Validation Errors</AlertTitle>
          <List>
            {validationErrors.map((error, i) => (
              <ListItem key={i}>
                <ListItemText>{error}</ListItemText>
              </ListItem>
            ))}
          </List>
        </Alert>
      )}
    </Container>
  );
}
