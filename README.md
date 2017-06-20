# Alpha Bomberman
Alpha Bomberman is our course work for the C# Advanced Course May 2017 at SoftUni.bg

## Inspiration
The game is inspired by the classic Bomberman.

## Implementation
The levels are modeled as a matrix of char elements.

![Screenshot of a level 30x15 characters.](https://github.com/HakuTeam/AlphaBomberman/game-30x15.png "AlphaBomberman level 30x15")

This implementation is based on exercise 9 – Crossfire from the Matrices exerciser of the C# Advanced Course May 2017.

The implementation of the game interface uses and improves the utility classes from a previous project: [MetaPong](https://github.com/MetaDevTeam/MetaPong/tree/master/MetaPong.Utilities):

![The home screen](https://github.com/HakuTeam/AlphaBomberman/start-screen.png "Home screen")

## Game controls
### Player P
- to move, use keys `W, A, S, D`
- to place a bomb - `SPACE`

### Player K
- to move, use the `arrow keys`
- to place a bomb - `Num Pad 0`

## Team members contributions
- [@badbutcher](https://github.com/badbutcher) - Player logic, keyboard interaction, game engine;
- [@Plotso](https://github.com/Plotso) - Bomb model and explosion logic;
- [@dhtveso](https://github.com/dhtveso) - Level model and generation;
- [@zluzunov](https://github.com/zluzunov) - interface and menus integration, console window size;
- [@HakuTeam/csharpadvanced](https://github.com/orgs/HakuTeam/teams/csharpadvanced/members) - all members contributed to testing, improvements, and refactoring of the code.

