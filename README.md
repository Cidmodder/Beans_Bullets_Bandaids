# Beans_Bullets_Bandaids
This is a set of scripts I am using in a minimilistic, Mini Metro style logistics game that will involve keeping troops supplied with Beans (morale), Bullets (ammo\damage), and Bandaids (health).
The current two scripts are for the pathing tools I want to use. You will find in the Assets folder two scripts a two prefabs that I am using in Unity to make this drawing tool.

# Installation
To install, simply import the assets folder into a blank scene in unity. Add two primitatives you would like to be the points of interest that you want to connect betwee.
Attach the point_Snapper.cs scripts to these points of interest. On the main camera, attach the path_Drawing.cs script and have it facing straight down and at y=10 for the position.
Be sure the prefabs are attached to their appropriate variables on the scripts in the inspector.
Hit play and run

# Expected Behavior
You should be able to only start drawing a path when you highlight over a point of interest. It will turn green indicating you can now draw and you can start drawing by clicking and holding the left mouse button.
You can then draw a path to any location you would like and when you release the left mouse button it will either spawn an endpoint prefab, or snap to a point of interest and spawn the endpoint there.
You can then draw a new path from any of these endpoints or points of interest as you go.
These can then be sued to make paths to tell your logistics where to go in the game.
