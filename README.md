# Joints-Game-Jam

Finalis Joints Game Jam UGM 2023
[Gorilla Galore Itch.io Link](https://chickenncheese.itch.io/gorilla-galore) **(Windows Only)**



(programmer notes ('25))
For my first project after one-month training at my internship, we developed this game for Joints Game Jam 2023 competition by UGM.

For this project I implemented SRP of SOLID principle. 
As for the other principles, I still haven't been able to use it because I still haven't fully grasped on how to use it correctly.

For optimization: I used pooling for spawning the obstacles, used Comparetag for comparing collider.
For game programming pattern: I used singleton for managers and state pattern for the game state control.

It's a platformer game, where in it it has moving platforms and ladders and obstacle that will go down from top like barrel from donkey kong.
Using the 4:3 display to make it feel like retro game.

This was also my first time creating dialogue system and using timeline system. 
The dialogue system was still something that you have to create an object for each set of dialogues, that's why each level still have it's own manager/controller for cutscene.

For the tools and frameworks outside normal framework from unity, we used: Cinemachine & LeanTween
