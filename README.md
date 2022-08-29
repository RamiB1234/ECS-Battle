# ECS-Battle
![ecs-battle](https://raw.githubusercontent.com/RamiB1234/ECS-Battle/master/ecs.gif "ecs-battle")
## Introduction

This is a small Unity demo that demonstrates working with Unity DOTS and ECS. It is a battle simulator where two teams battle. Unit attributes and properties are configured in a JSON configuration file.

## Documentation

Please refer to the [Technical Documentatuin & Installation Guide](https://raw.githubusercontent.com/RamiB1234/ECS-Battle/master/documentation/ECS%20Battle%20-%20Documentation%20%26%20Installation%20Guide.pdf) for details on how to install the game and to know more about the technical details

## Installation

### Installation Guide - Unity Project

- Clone the repository to your Windows/Mac machine
- Download Unity 2021.3.7f1 LTS using Unity Hub
- Add and locate the unity project from the downloaded repository. Path of the project folder is ECS-Battle\unity_project\ECSBattle
- Launch the project from the Unity Hub projects tab


### Installation Guide - Android APK

- Clone the repository to your Windows/Mac machine
- Copy the binary file called ECSBattle.apk from ECS-Battle\binary\android to your Android device
- Install the apk and run the game

## Unity ECS

The Entity Component System (ECS) is the core of the Unity Data-Oriented Tech Stack. As the name indicates, ECS has three principal parts:

- Entities — the entities, or things, that populate your game or program.
- Components — the data associated with your entities, but organized by the data itself rather than by entity. (This difference in organization is one of the key differences between an object-oriented and a data-oriented design.)
- Systems — the logic that transforms the component data from its current state to its next state— for example, a system might update the positions of all moving entities by their velocity times the time interval since the previous frame.
