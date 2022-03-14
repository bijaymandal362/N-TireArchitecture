import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Home from "./views/home/Home";
import User from "./views/user/User";
import Layout from "./views/shared/Layout";
import NotFound from "./views/shared/errors/NotFound";
import { makeStyles, ThemeProvider } from "@material-ui/core/styles";
import Theme from "./assets/theme/theme";
import { Box, Container, Toolbar } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  root: {
    width: "100vw",
    height: "100vh",
    backgroundColor: theme.palette.grey[300],
  },
  main: {
    paddingLeft: 200,
  },
  content: {
    padding: theme.spacing(3),
  },
}));
export default function App() {
  const classes = useStyles();
  return (
    <ThemeProvider theme={Theme}>
      <Router>
        <Container className={classes.root} maxWidth="xl" disableGutters>
          <Layout />
          <Toolbar />
          <Box className={classes.main}>
            <Box className={classes.content}>
              <Switch>
                <Route exact path="/" component={Home}></Route>
                <Route exact path="/users" component={User}></Route>
                <Route component={NotFound}></Route>
              </Switch>
            </Box>
          </Box>
        </Container>
      </Router>
    </ThemeProvider>
  );
}
