import React, { Component } from 'react';
import * as signalR from "@aspnet/signalr";
import ServerStatus from './serverStatus';
import Navbar from './nav.js';
import Dropdown from 'react-bootstrap/Dropdown'
import water from './water.png';
import sauce from './sauce.png';

const paddingTop = {
    'paddingTop': '15px'
}

const badgeFont = {
    'fontSize' : 'larger'
}

const TableSettings = {
    'borderRadius': '0',
    'margin': '17px',
}
const serverStatus = {
    'alignment' : 'center', 
    'height' : '600px',
    'width' : '200px',
    'overflow-y': 'auto',
    'background': 'lightgray',
    'border' : '5px',
    'margin-top': '60px',
    'margin-right': '20px',
    'float': 'right'
}
const mainContainer = {
    'float': 'left',
    'margin-right': '30px'
}


var status = {
    'r' : 'primary',
    'w' : 'warning',
    'o' : 'success',
    'n' : 'danger',
    'd' : 'dark',
}
var imageSrc = {
    'w' : water,
    's' : sauce
};

export const URL = 'https://fancypos-sp19-p05-g01-lopsided-desk.azurewebsites.net';

export class TablesStatus extends Component {
    constructor() {
        super();
        this.state = {
            tables: [],
            hubConnection: null

        }
        this.fillThatTable = this.fillThatTable.bind(this);
    }

    componentDidMount = () => {
        fetch(URL+'/api/Tables/GetTables')
        .then(response => response.json())
        .then(data => {
            console.log(data)
            this.setState({tables: data});
        });
var id = 2;
        const hubConnection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();
        this.setState({ hubConnection}, () => {
            this.state.hubConnection
              .start()
              .then(() => console.log('Connection started!'))
              .catch(err => console.log('Error while establishing connection!'));
              if (this.state.hubConnection  != null){
                this.state.hubConnection.on("checkIn", (checkInDto) => {
                    const newTables = this.state.tables.map(x => x.id !== checkInDto.tableId ? x : Object.assign({},x,{tableStatus: 'w'}))
                    this.setState({tables: newTables})  
                });
                this.state.hubConnection.on("needAttention", (tableId) => {
                    const newTables = this.state.tables.map(x => x.id !== tableId ? x : Object.assign({},x,{tableStatus: 'n'}))
                    this.setState({tables: newTables})  
                });
                this.state.hubConnection.on("needRefil", (tableId, refil) => {
                    const newTables = this.state.tables.map(x => x.id !== tableId ? x : Object.assign({},x,{tableReq: refil}))
                    this.setState({tables: newTables})  
                });
                this.state.hubConnection.on("orderFood", (tableId) => {
                    const newTables = this.state.tables.map(x => x.id !== tableId ? x : Object.assign({},x,{tableStatus: 'o'}))
                    this.setState({tables: newTables})  
                });
                this.state.hubConnection.on("checkedOut", (tableId) => {
                    const newTables = this.state.tables.map(x => x.id !== tableId ? x : Object.assign({},x,{tableStatus: 'd'}))
                    this.setState({tables: newTables})  
                });

            }
            

             
       
        // const connection = new HubConnectionBuilder()
        // .withUrl(URL + "/NotificationHub")
        // .build();

        // connection.start().then(function () {
        //     console.log("connected");
        // });

        // connection.invoke("sendAll", '1').catch(err => console.error(err.toString()));

    });
  
    }
reqFulfiled = (id) => {
    console.log("Hited")
    console.log(id);
    const newTables = this.state.tables.map(x => x.id !== id ? x : Object.assign({},x,{tableReq: ''}))
    this.setState({tables: newTables})

}
  
    
fillThatTable = () => {
        let tableData = this.state.tables;
        if(tableData.length === 0) {
            return (
                <h1 >Loading...</h1>
            )
        } else {
            return tableData.map(x => {
                console.log(x.tableStatus);
                   return(
                    
                    <div style={TableSettings} className={"col-md-2 card bg-" + status[x.tableStatus]}>
                        <p>Table {x.id}</p>
                        <p>No Of Seats : {x.numberOfSeats}</p>
                        <img style={{width: '20px', height: '30px', outline: 'none', border: '0' }} src = {imageSrc[x.tableReq]}/>
                        <Dropdown>
                    <Dropdown.Toggle variant={status[x.tableStatus]}>
                        </Dropdown.Toggle>
                    <Dropdown.Menu>
    <Dropdown.Item><p onClick={() => {this.reqFulfiled(x.id)}}>Request Fulfilled</p></Dropdown.Item>
  </Dropdown.Menu>
</Dropdown>
                    </div> 
                    
                   )  
                })
        }
    }
    // checkSignalR = () => {
    //     let hubConnection= this.state.hubConnection;
    //     if(!hubConnection){
    //     hubConnection.invoke("SetTable", 2).catch(function (err) {
    //         console.error(err.toString()
    //         )});
    //        hubConnection.on("sendToAll", function (tableId) {
    //             console.log(tableId);
    //         });
    //     }
    // }


    render() { 
        return ( 
            <div style={paddingTop}>
                <Navbar />
                <div className="container" style={mainContainer}>
                    <div className="card">
                        <div className="card-body">
                            <div className="card">
                                <div className="card-body text-center text-light" >
                                    <strong>Index : </strong>
                                    <span style={badgeFont} className="badge badge-primary">Open</span> &nbsp;&nbsp;&nbsp;
                                    <span style={badgeFont} className="badge badge-warning">Checked In</span> &nbsp;&nbsp;&nbsp;
                                    <span style={badgeFont} className="badge badge-success">Received Order</span> &nbsp;&nbsp;&nbsp;
                                    <span style={badgeFont} className="badge badge-danger">Need Attention</span> &nbsp;&nbsp;&nbsp;
                                    <span style={badgeFont} className="badge badge-dark">Dirty</span>
                                </div>
                            </div>
                            <br/>
                            <div className="card">
                                <div style={{'textAlign': 'center'}} className = 'card-header'>
                                    <h1>Tables</h1>
                                </div>
                    
                                <div className="card-body text-center card text-light">
                                    <div className="row" id="tablesContainer">
                                        {this.fillThatTable()}
                                    {/* <button onClick = {this.checkSignalR()}>checkSignalR</button> */}
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style={serverStatus}>
                <ServerStatus/>
                </div>
            </div>
        );
    }
}