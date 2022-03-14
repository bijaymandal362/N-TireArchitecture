import {
  AppBar,
  Box,
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  makeStyles,
  Toolbar,
  Typography,
} from "@material-ui/core";
import React from "react";
import { NavLink } from "react-router-dom";
import HomeIcon from "@material-ui/icons/Home";
import GroupIcon from "@material-ui/icons/Group";
const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  appBar: {
    zIndex: theme.zIndex.drawer + 1,
  },
  title: {
    flexGrow: 1,
  },
  // active: {
  //   "&.active": {
  //     background: theme.palette.primary.light,
  //     color: theme.palette.primary.contrastText,
  //   },
  // },
  menuButton: {
    marginRight: theme.spacing(1),
  },
  drawer: {
    width: 200,
  },
}));

export default function Layout() {
  const classes = useStyles();

  return (
    <Box className={classes.root}>
      <Drawer variant="permanent">
        <Toolbar />
        <List disablePadding className={classes.drawer}>
          <ListItem
            button
            component={NavLink}
            to="/"
            exact
            className={classes.active}
          >
            <ListItemIcon>
              <HomeIcon />
            </ListItemIcon>
            <ListItemText primary="Home"></ListItemText>
          </ListItem>
          <ListItem
            button
            color="inherit"
            component={NavLink}
            to="/users"
            className={classes.active}
          >
            <ListItemIcon>
              <GroupIcon />
            </ListItemIcon>
            <ListItemText primary="Users"></ListItemText>
          </ListItem>
        </List>
      </Drawer>
      <AppBar color="primary" position="fixed" className={classes.appBar}>
        <Toolbar>
          <Typography variant="h6" className={classes.title}>
            Project
          </Typography>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
