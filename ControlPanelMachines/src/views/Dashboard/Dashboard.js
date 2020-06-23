import React, { useState, useEffect } from 'react';
import axios from 'axios';
import GridContainer from "components/Grid/GridContainer.js";
import CardMachine from "components/CardMachine/CardMachine.js";


export default function Dashboard() {

  const [machines, setMachines] = useState([]);

  useEffect(() => {
    axios.post(`http://localhost:5000/monitoring-machines/registerLocalMachine`)
    .then(() => {
      axios.get(`http://localhost:5000/monitoring-machines/getAll`)
      .then(res => {
        const machines = res.data;
        setMachines(machines);
      })
    })
    .catch(function () {
      console.log('Couldnt contact the service. Are u sure that is running?');
      alert('Couldnt contact the service. Are u sure that is running?');
    })
  }, [setMachines]);

  return (
    <>
      <GridContainer>
        {machines.map(machine => {
          return <CardMachine
                  key={machine.id}
                  nome={machine.name}
                  ip={machine.address}
                  antiVirusName={machine.antivirus.name}
                  hds={machine.hardDrive.map(hd => (` [Nome: ${hd.name} | FreeSpace: ${hd.freeSpace}, | TotalSpace: ${hd.usedSpace} ] `))}
                  firewallIsOn={String(machine.antivirus.hasAntivirus)}
                  winVersion={machine.osVersion}
                  dotNetVersion={machine.dotNetVersion}
                />
        })}
      </GridContainer>
    </>
  );
}