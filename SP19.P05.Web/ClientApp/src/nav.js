import React, { Component } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';

const reserve = {
  'display': 'in-line',
  'flex-direction': 'row'
  };
export const URL = 'https://fancypos-sp19-p05-g01-lopsided-desk.azurewebsites.net';


export default class NavBar extends Component {
        constructor(props, context) {
            super(props, context);
        
            this.handleShow = this.handleShow.bind(this);
            this.handleClose = this.handleClose.bind(this);
        
            this.state = {
              show: false,
              reservation: []
            };
          }
        
          handleClose() { 
            this.setState({ show: false });
          }
        
          handleShow() {
            this.setState({ show: true });
          }

componentDidMount = () => {
  fetch(URL+'/api/Tables/GetReservation')
        .then(response => response.json())
        .then(data => {
            console.log(data)
            this.setState({reservation: data});
        });
}

fillThatReservation = () => {
  let reservationData = this.state.reservation;
  if(reservationData.length == 0) {
      return (
          <h1 >Loading...</h1>
      )
  } else {
      return reservationData.map(x => {
             return(
               <div>
              <ul style ={reserve}>
                  <li>Name: {x.name}</li>
                  <li>Date: {x.dateTime} </li>
                  </ul>
                  </div>
                  )})}}
    render() {
        return (
            <div>
            <nav className="navbar navbar-expand-lg navbar-dark bg-primary">
            <>

        <Modal show={this.state.show} onHide={this.handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Reservation</Modal.Title>
          </Modal.Header>
          <Modal.Body>{this.fillThatReservation()}</Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={this.handleClose}>
              Close
            </Button>
          </Modal.Footer>
        </Modal>
      </>
                <a className="navbar-brand" href="#">HappyTite</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button> 
                <div className="collapse navbar-collapse" id="navbarText">
                    <ul className="navbar-nav mr-auto">
                    <li className="nav-item active">
                        <a className="nav-link" href="#"> <span className="sr-only">(current)</span></a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" data-toggle="modal" data-target=".bd-example-modal-lg" onClick={this.handleShow}>Reservations</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="#">Servers</a>
                    </li>
                    </ul>
                    <span className="navbar-text">
                    In Progress....
                    </span>
                </div>
            </nav>

</div>
        )
    }
}