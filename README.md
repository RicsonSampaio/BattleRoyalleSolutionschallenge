# BattleRoyalleSolutionschallenge

Hey there! This is a challenge for a technical exam for IA.

### Prerequisites

Well, To be able to test this projet u must have .NET core SDK and node installed in your machine.

### Installing

After download as a ZIP or "git cloned" this project u should see a file called "PublishMonitoringMachineAPI.exe".
Execute "PublishMonitoringMachineAPI.exe". After some seconds, a windows service called "MonitoringMachinesAPI" was installed and started.

Now, just run 'npm install' and 'npm start' in the project "ControlPanelMachines" to open up a "http://localhost:3000/admin/dashboard".
In this localhost u should something like this:

![alt text](https://github.com/RicsonSampaio/BattleRoyalleSolutionschallenge/blob/master/ExampleReadme.jpeg?raw=true)

## How to test it

U should see a very simple card with your local machine information. On the right side, u should see a cmd component.
To see some cmd code running just type "run [you cmd command]". Example: "run ipconfig" or "run dir"  or "run ping www.google.com"

This card on the left your machine's card. To see some others, just for testing purposes, click in the button located on the top right of the screen.
"Create new random machine". After clicked on it, if u refresh your page u should see another card with a new random machine listed. 
Try it on, click how many times u want.

### What is missing?

-Execute powershell commands<br>
-Execute many commands in many machines in the same time<br>
-Build and deploy automatically<br>
-Git hub integration<br>
-Decent Css<br>
-Create front-end from scratch (I used a template and simply modified for consuming the back-end)<br>

### What is not good as I wanted?

-Unit tests<br>
-Validations<br>

## Authors

* **Me** 
* **Creative Tim** - *SPA template* - (https://www.creative-tim.com/product/material-dashboard-react)

I used this template on Front-end for building this project as fast as possible.

## Acknowledgments

-Check in youy C:// . There's a temp folder with logs.




