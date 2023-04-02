# Fantasy Cycling

Windows Forms app for using your exercise bike for game inputs.

## Getting Started

### Setting up the bike
* Wire your Arduino to your bike's reed switch
    ![My electornics setup](https://cdn.discordapp.com/attachments/963695606914768906/1092043241756573696/bike_electronics_lowres.png)
    * [Example by another person](https://www.youtube.com/watch?v=ndbpvDJJjTA)
* Flash Arduino using Arduino IDE
* Clone source and build the form application
* Setup app:
    1. Set corret COM port (check device manager for which port Arduino is using)
    2. (Optional) Write a GameInput class for wanted game that inherits GameInput base class
    3. Set wanted GameInput profile at Program.cs:247 by creating a GameInput object
    4. (Optional) Configure BikeInputs' variables to preference
* Build and run app
* Have fun cycling!

## Authors
* Programming: Junnu
* Arduino Programming: Olavi M.
* Orc Cyclist image: [Ted Helms](https://www.artstation.com/helmsartcreations)

## Acknowledgments
Helpful tutorial: [Unity racing game](https://www.youtube.com/watch?v=ndbpvDJJjTA)
