import React, { Component } from 'react';
import './NavMenu.css';
import {AppBar, Toolbar, Typography} from "@mui/material";

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <AppBar position="static">
          <Toolbar>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
              Подбор компонентов для ПК
            </Typography>
          </Toolbar>
        </AppBar>
      </header>
    );
  }
}
