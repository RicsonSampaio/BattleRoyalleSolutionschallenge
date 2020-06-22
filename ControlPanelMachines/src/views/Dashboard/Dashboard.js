import React, { useState, useEffect } from 'react';
import axios from 'axios';
import GridContainer from "components/Grid/GridContainer.js";
import CardMachine from "components/CardMachine/CardMachine.js";
import Terminal from "terminal-in-react";


export default function Dashboard() {

  const [machines, setMachines] = useState([]);
  const [captura, setCaptura] = useState("");
  const showMsg = () => "Hello World";

  useEffect(() => {
    axios.get(`http://localhost:5000/monitoring-machines/getAll`)
        .then(res => {
          const machines = res.data;
          console.log(machines)
          setMachines(machines);
        })
  }, [setMachines]);

  // state = {
  //   name: '',
  // }

  // handleSubmit = event => {
  //   event.preventDefault();

  //   const user = {
  //     name: this.state.name
  //   };

  //   axios.post(`https://jsonplaceholder.typicode.com/users`, { user })
  //     .then(res => {
  //       console.log(res);
  //       console.log(res.data);
  //     })
  // }

  // handleChange = event => {
  //   this.setState({ name: event.target.value });
  // }

  return (
    <>

      {/* <div>
        <form onSubmit={this.handleSubmit}>
          <label>
            Person Name:
            <input type="text" name="name" onChange={this.handleChange} />
          </label>
          <button type="submit">Add</button>
        </form>
      </div> */}
      
      <GridContainer>
      {machines.map(machine => {
        return <CardMachine
                key={machine.id}
                nome={machine.name}
                ip={machine.address}
                antiVirusName={machine.antivirus.name}
                hasAntiVirus={machine.antivirus.hasAntivirus}
                hds={machine.hardDrive.map(hd => (` [Nome: ${hd.name}, | FreeSpace: ${hd.freeSpace}, | TotalSpace: ${hd.usedSpace} ] `))}
                firewall={machine.antivirus.hasAntivirus}
                winVersion={machine.osVersion}
                dotNetVersion={machine.dotNetVersion}
              />
      })}
        
      </GridContainer>

      <GridContainer>
      <div>Comando digitado - {captura}</div>
      <div
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          height: "100vh",
        }}
      >
        <Terminal
          color="green"
          backgroundColor="black"
          barColor="black"
          style={{ fontWeight: "bold", fontSize: "1em" }}
          commands={{
            showmsg: () => {
              setCaptura("showmsg");
              showMsg();
            },
            popup: () => {
              setCaptura("popup");
              alert("Terminal in React");
            },
            test: () => {
              setCaptura("test");
            },
          }}
          descriptions={{
            showmsg: "shows a message",
            alert: "alert",
            popup: "alert",
            test: "Comando de teste",
          }}
          msg="You can write anything here. Example - Hello! My name is Foo and I like Bar."
        />
      </div>
      </GridContainer>
    </>
  );
}