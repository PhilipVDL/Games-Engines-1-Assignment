# Games-Engines-1-Assignment
Procedural generation assignment for Games Engines 1  
Gerhardus van der Linde, c18357866, DT508


## What it does
This project aims to procedurally react to the player's location and movements in order to generate a seemingly infinite cityscape of buildings with a non-euclidean interior layout.  
In simpler terms:  
-No matter how far you walk, there will be more cityscape  
-No matter how many times you go up a flight of stairs, or walk to the next room over, there will be more rooms  
-The color and rotation of rooms will be based on what direction you traveled to reach them, even if you go back to the room you just came from  
-The furniture in each room is randomly selected and placed

## What I did VS what I borrowed
### Borrowed:
-First person controller from "Standard Assets" on the Unity asset store.  
-Various free 3D textures from [https://3dtextures.me/](https://3dtextures.me/)  

### DIY:
-All buildings, building segments, and furniture  
-Code for spawning/despawning building segements  
-Code for color changing based on direction of rooms  
-Code for randomising furniture in each room  

## What I'm most proud of
-I'm proud of the fact that the scripts can instantiate so many things so quickly without causing a drop in framerate, or creating overlapping buildings.  
-I'm also proud of the fact that they can keep the hierarchy tidy, and avoid missing anything that needs to be deleted, by reassigning the parents and children of objects to keep organised.  

## Instructions for running
To run in Unity editor:  
-Simply download the project from the Final-submission branch and open in Unity  
-Press the play button in the editor  

To run as a standalone executable (.exe):  
-Download the compressed build from the Downloadable-build branch  
-Unzip the file  
-Run the executable file in the folder  

## Controls
-Pressing Esc will quit the application  
-W,A,S,D for movement  
-Space to jump  
-Mouse to look around

## Video
[![YouTube](https://img.youtube.com/vi/0xyRtCJrhMY/0.jpg)](https://youtu.be/0xyRtCJrhMY)