# TrawnKit
Game framework for the Phillytron

## What's the Phillytron
The Philltron is Philly's own community-created arcade cabinet. 
It is an ongoing project of the [Philly Game Mechanics] (https://phillygamemechanics.com). 
It should be called the Phillytrawn.

## What TrawnKit does
- Input mappings to Phillytron's controls
- Helper methods for getting input using player and control
- Player select logic and UI (configurable for any number of minimum and maximum players from 1-4)
- Menu navigation and backing out to Phillytron launcher
- Pausing logic and UI
- UI for associating players and controls (uses control top paint colors and location) - so people can tell which player they are
- Simple editable launch screen and optional pre-game instructions

## How to use
I will create some better docs at some point. But for now, there is an example game starting point.

In the top-level folder "Example Game", there are two sub-folders. 
One folder contains a Game scene, a Launch (Splash) scene and a ScriptableObject with game metadata. 
Modify these as needed, but don't delete them. The Game scene should be the starting scene for you game.
Change the fields in GameInfo for your game.

The other folder contains some examples to illustrate how to use the input and get which players are playing.
Feel free to delete these once you understand what they are doing.

## Questions
If you have any questions, hit me up on the [Philly Game Mechanics Slack] (https://phillygamemechanics.com/slack/) at @jakeo

