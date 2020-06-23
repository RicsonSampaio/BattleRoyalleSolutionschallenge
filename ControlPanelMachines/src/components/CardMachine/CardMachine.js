import React from "react";
import axios from 'axios';
import { makeStyles } from "@material-ui/core/styles";
import Icon from "@material-ui/core/Icon";
import Terminal from "terminal-in-react";

import GridItem from "components/Grid/GridItem.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardIcon from "components/Card/CardIcon.js";

import styles from "assets/jss/material-dashboard-react/views/dashboardStyle.js";
const useStyles = makeStyles(styles);

const CardMachine = ({
  nome,
  ip,
  antiVirusName,
  hds,
  firewallIsOn,
  winVersion,
  dotNetVersion,
}) => {
  const classes = useStyles();
  return (
      <>
        <GridItem xs={12} sm={6} md={6}>
            <Card> 
                <CardHeader color="primary" stats icon>
                <CardIcon color="primary">
                    <Icon>computer</Icon>
                </CardIcon>
                <p className={classes.cardCategory}>{nome}</p>
                <h3 className={classes.cardTitle}>
                    <small>IP:</small> <br />
                    {ip}
                </h3>
                <h3 className={classes.cardTitle}>
                    <small>Anti Virus:</small><br />
                    {antiVirusName}
                </h3>
                <h3 className={classes.cardTitle}>
                    <small>HDs:</small> <br />
                    {hds} 
                </h3>
                <h3 className={classes.cardTitle}>
                    <small>Firewall:</small> <br />
                    {firewallIsOn} 
                </h3>
                <h3 className={classes.cardTitle}>
                    <small>Versão do Windows:</small> <br />
                    {winVersion} 
                </h3>
                <h3 className={classes.cardTitle}>
                    <small>Versão do .Net:</small> <br />
                    {dotNetVersion}
                </h3>
                </CardHeader>
            </Card>
        </GridItem>
        <GridItem xs={12} sm={6} md={6}>
            <div
                style={{
                    display: "absolute",
                    justifyContent: "center",
                    alignItems: "center",
                    height: "0px",
                    marginTop: "30px"
                }}
            >
            <Terminal
                color="green"
                backgroundColor="black"
                barColor="black"
                style={{ fontWeight: "bold", fontSize: "1em" }}
                commands={{
                    run: (args, print, runCommand) => {
 
                        let cmdCommand = '';
                        for (let index = 0; index < args.length; index++) {
                            if(index != 0){
                                cmdCommand +=' ' + args[index]
                            }
                        }
                        
                        axios.post(`http://localhost:5000/command-cmd?CMDCommand=${cmdCommand}&MachineId=1`)
                        .then(res => {
                            print(res.data);
                        }).catch(function () {
                            print('Couldnt contact this machine. It is probably off');
                        })
                    }
                }}
                msg="To run a command: 'run' + cmdcommand. Example: run ipconfig | run dir | run ping www.google.com | "
            />
        </div>
    </GridItem>
  </>
  );
};

export default CardMachine;