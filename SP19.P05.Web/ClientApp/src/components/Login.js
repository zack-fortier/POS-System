// Login page
import React, { Component } from 'react';
import {
  Container, Form,
  FormGroup, Label, Input,
  Button
} from 'reactstrap';
import { Redirect } from "react-router-dom";
import auth from "./auth";
import './LoginStyles.css';
import './images/Avatar.png';

export class Login extends Component {
  // Constructor for email, password, redirecting routes, and email validation
  constructor(props) {
    super(props);
      this.state = {
      "username": "",
      "password": "",
      redirect: false,
      redirectToReferrer: false
    }
    this.handleChange = this.handleChange.bind(this);
    //this.login = this.login.bind(this);
  }

  // Function for onChange events
  handleChange = async (event) => {
    const { target } = event;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const { name } = target;
    await this.setState({
      [ name ]: value,
    });
  }

  // Function for onSubmit events
  submitForm(e) {
    e.preventDefault();
    if (this.state.username === "avash" && this.state.password === "avash100"){
      this.setState({redirect: true});
        auth.login(() => {
          /*if (this.state.redirect) {
            this.props.history.push("/dashboard");
          }*/
          this.props.history.push("/dashboard");
        });
        /*// Protects /dashboard from being easily accessed
        auth.authenticate(() => { 
        if (this.state.redirectToReferrer === false) {
          this.setState({ redirectToReferrer: true })
        }
      //this.setState({ redirectToReferrer: true })
      //clearTimeout();
    })*/
      }
      else {
        alert('Invalid username or password! Please try again')
      }

    /*// Protects /dashboard from being easily accessed
    auth.authenticate(() => { 
      if (this.state.redirectToReferrer == false) {
        this.setState({ redirectToReferrer: true })
      }
      //this.setState({ redirectToReferrer: true })
      //clearTimeout();
    })*/
  }
  
  // Render function
  renderRedirect = () => {
    if (this.state.redirect) {
      return <Redirect to="/dashboard" />
    }
  }
  
  // Function for protecting /dashboard
  /*login() {
    // Protects /dashboard from being easily accessed
    auth.authenticate(() => { 
      this.setState({ redirectToReferrer: true })
    })
  }*/
  
  /*componentWillUnmount() {
    //this.setState({ redirectToReferrer: false});
    //this.setState({ redirect: false});

    //auth.authenticate(() => { 
      //this.setState({ redirectToReferrer: false })
    //})

    clearTimeout(auth.authenticate());
    
  }*/
  
  render() {
    // Variables being declared
    const { username, password } = this.state;
    /*const { from } = this.props.location.state || { from: { pathname: '/dashboard' } }
    const { redirectToReferrer } = this.state;

    // If user has not been logged in, redirect them back to login
    if (redirectToReferrer) {
      return (
        <Redirect to={from} />
      )
    }*/

    return (
      <Container className="background">
        <div className="login-form">
          {/* Entire form */}
          <Form className="form" onSubmit={ (e) => this.submitForm(e) }>
            <div className="avatar">
              <img src={require('./images/Avatar.png')} alt="Avatar" />
            </div>
            <h2 className="text-center">Sign In</h2>
            
              {/* Username field */}
              <FormGroup>
                <Label>Username</Label>
                <Input
                  className="form-control"
                  type="username"
                  name="username"
                  placeholder="username"
                  value={ username }
                  required
                  onChange={ (e) => {
                    this.handleChange(e)
                  } }
                />
              </FormGroup>
          
              {/* Password field */}
              <FormGroup>
                <Label for="examplePassword">Password</Label>
                <Input
                  className="form-control"
                  type="password"
                  name="password"
                  id="examplePassword"
                  placeholder="password123"
                  value={ password }
                  required
                  onChange={ (e) => this.handleChange(e) }
                />
              </FormGroup>
              
              {/* Login Button */}
              <div className="text-center">
                {/*this.renderRedirect()*/}  
                <Button>Login</Button>
              </div>
      </Form>
      </div>
      </Container>
    );
  }
}

/* An authentication function */
/*export const auth = {

  isAuthenticated: false,
  authenticate(cb) {
    this.isAuthenticated = true
     setTimeout(cb, 100)
     //clearTimeout(cb);/
  },
  signout(cb) {
    this.isAuthenticated = false;
    setTimeout(cb, 100);
  }
} */

export default Login;