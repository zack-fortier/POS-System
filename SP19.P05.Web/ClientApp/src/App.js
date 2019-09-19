import React, { Component } from 'react';
//import Navbar from './nav.js';
import { BrowserRouter as Router, Route, Switch, Redirect } from "react-router-dom";
import { TablesStatus } from './tablestatus';
import Login from './components/Login';
//import { auth } from './components/Login';
import { ProtectedRoute } from "./components/protected.route";

/* SecretRoute component definition */
/*const SecretRoute = ({component: Component, authed, ...rest}) => {
  return (
    <Route
      {...rest}
      render={(props) => authed === true
        ? //<Redirect to={{pathname: "/dashboard", state: {from: props.location}}} /> 
        <Component {...props} />
        : <Redirect to={{pathname: "/", state: {from: props.location}}} />} />
  )
} */

class App extends Component {
  render() {
    return (
      <div>
        <Router>
          <Switch>
            <Route path="/" exact component={Login} />
            <Route path="/dashboard" exact component={TablesStatus}/>
            {/*<SecretRoute authed={auth.isAuthenticated} exact path="/dashboard" component={TablesStatus} />*/}
            {/*<Route exact path="/" render={() => (
              auth.isAuthenticated ? (
                <Redirect to="/dashboard" />
              ) : (
                <Redirect to="/" />
              )
              )} />*/}
            {/*<ProtectedRoute exact path="/dashboard" component={TablesStatus} />*/}
          </Switch>
        </Router>
      </div>
    );
  }
}

export default App;