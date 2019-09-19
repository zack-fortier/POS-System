import React, { Component } from 'react';


const server = {
    'margin': 'auto',
    'border' : '3px solid green',
    'padding': '10px',
    'textAlign': 'center', 
    'height' : '100px', 
    'width':'170px', 
    'background': 'white',
    };

class ServerStatus extends Component {
    
    state = { 
        servers : [
         {Id : 1, Name :'Avash Mishra', ServingTable :'4'},
         {Id : 2, Name : 'Uchiha Itachi', ServingTable : '3'},
         {Id : 3, Name : 'Uzumaki Naruto', ServingTable : '2'},
         {Id : 4, Name : 'Uchiha Sasuke', ServingTable : '1'},
         {Id : 5, Name : 'Kakashi Sensei', ServingTable : '5'},
         {Id : 6, Name : 'Uchiha Madara', ServingTable : '6'}
    ]
     }

    getAllServers = () => {
        let serverData = this.state.servers;
        if(serverData.length == 0) {
            return (
                <h1 >Loading...</h1>
            )
        } else {
            return serverData.map(x => {
                   return(
                    <div style =  {server}>
                        <p>{x.Name}</p>
                        <p>Serving Table : {x.ServingTable}</p>
                    </div> 
                   ) 
                })
        }
    }
    render() { 
        return ( 
            <div>
                <div>
                   {this.getAllServers()}
                </div>
            </div>
         );
    }
}
 
export default ServerStatus ;