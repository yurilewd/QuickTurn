## Summary
Adds a new ability for you to use, holding back while on the ground will put you in a skid animation and during that animation you can perform a number of things to turn in different directions.

While in the skid you can choose to either slide, jump, trick, boost trick, or simply wait for it to end. Each variation has a different purpose and returns different amounts of speed.
- Slide retains almost all of you speed and is used to turn or go forwards again.
- Jump retains less speed but will send you backwards instead.
- Trick retains less speed still but you can go in any direction.
- Boost trick retains nearly all of you speed and can go in any direction like the normal trick.


## Installation
 - Ensure you have BepInEx 5.4.21 installed, if you do not have that installed you can find it [here](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.21)
 - Navigate to the Bomb Rush Cyberfunk folder, if you have the steam version it is located at this path "Program Files\Steam\steamapps\common\BombRushCyberfunk"
 - Place the QuickTurn.dll into the \BepInEx\plugins folder, if you have BepInEx installed correctly this folder should already exist
 - Launch the game<br>

 - Alternatively you can use r2modman and let that handle the entire process for you, it can be found [here](https://thunderstore.io/c/bomb-rush-cyberfunk/p/ebkr/r2modman/)

## Configuration
I highly recommend downloading [BepInEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager), this will allow you to edit the config while in game and can be opened once installed by pressing F1. The default settings are what I think feel the best while also being somewhat fair, but feel free to adjust them.

- Speed During Ability is how fast you move during the skid.
- Cooldown is how long you have to wait before performing the skid again.
- Delay is how long you have to wait before you can act during the skid.
- Minimum Speed is the minimum amount of speed required to start the skid.
- Sensitivity determines how far back you have to hold, higher makes it easier but you may perform it on accident.
- Angle is the maximum amount in degrees you can turn, 180 means you can turn anywhere you point.
- Direction is the default direction you will go. For example slide will send you forwards, but jump will send you backwards by default.
- Speed is the amount of speed returned afterwards, keep in mind this is the speed before performing the trick.
