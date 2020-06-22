import React from "react";

import { makeStyles } from "@material-ui/core/styles";
import Icon from "@material-ui/core/Icon";
import Warning from "@material-ui/icons/Warning";
import Danger from "components/Typography/Danger.js";

import GridItem from "components/Grid/GridItem.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardIcon from "components/Card/CardIcon.js";
import CardFooter from "components/Card/CardFooter.js";

import styles from "assets/jss/material-dashboard-react/views/dashboardStyle.js";
const useStyles = makeStyles(styles);

const CardMachine = ({
  nome,
  ip,
  antiVirusName,
  hasAntiVirus,
  hds,
  firewall,
  winVersion,
  dotNetVersion,
}) => {
  const classes = useStyles();
  return (
    <GridItem xs={12} sm={6} md={4}>
      <Card>
        <CardHeader color="warning" stats icon>
          <CardIcon color="warning">
            <Icon>content_copy</Icon>
          </CardIcon>
          <p className={classes.cardCategory}>{nome}</p>
          <h3 className={classes.cardTitle}>
            <small>IP:</small> {ip}
          </h3>
          <h3 className={classes.cardTitle}>
            <small>Anti Virus:</small>{hasAntiVirus} {antiVirusName}
          </h3>
          <h3 className={classes.cardTitle}>
            <small>HDs:</small> {hds} 
          </h3>
          <h3 className={classes.cardTitle}>
            <small>Firewall:</small> {firewall} 
          </h3>
          <h3 className={classes.cardTitle}>
            <small>Versão do Windows:</small> {winVersion} 
          </h3>
          <h3 className={classes.cardTitle}>
            <small>Versão do .Net:</small> {dotNetVersion}
          </h3>
        </CardHeader>
        <CardFooter stats>
          <div className={classes.stats}>
            <Danger>
              <Warning />
            </Danger>
            <a href="" onClick={(e) => e.preventDefault()}>
              Button toggle Machine state
            </a>
          </div>
        </CardFooter>
      </Card>
    </GridItem>
  );
};

export default CardMachine;