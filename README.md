# TrawnKit
Game framework for the Phillytron

## What's the Phillytron
The Philltron is Philly's own community-created arcade cabinet. 
It is an ongoing project of the [Philly Game Mechanics](https://phillygamemechanics.com). 
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
Most of the above just works out of the box. The things you will need to access in your game are input and getting which players are playing.

The ExampleGame folder is a starting point for building a game. It contains two folders.

One folder contains a Game scene, a Launch (Splash) scene and a ScriptableObject with game metadata. 
Modify these as needed, but don't delete them. The Game scene should be the starting scene for you game.
Change the fields in GameInfo to match the needs of your game.

The other folder contains some examples to illustrate how to use the input and how to get which players are playing.
Feel free to delete these once you understand what they are doing.

I will create better docs for this soon, but in the mean time...
 
## Questions
If you have any questions, hit me up on the [Philly Game Mechanics Slack](https://phillygamemechanics.com/slack/) at @jakeo

