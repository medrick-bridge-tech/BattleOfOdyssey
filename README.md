# Battle Of Odyssey

## Table Of Contents
- Class names and descriptions
- Class relations
- How to add weapon and ammo
- How to add enemies

## Classes

- **Player:** This script handle player attributes & death, equip weapon and shoot.
- **Character Controller:** This script control character moves and animations.
- **Inventory:** This is player inventory which stores player weapons & ammo.
- **Weapon Property:** This is a scriptable object for weapons.
- **Weapon:** This script makes a connection between weapon and its scriptable object.
- **Ammo Property:** This is a scriptable object for ammos.
- **Ammo:** This script makes a connection between ammo and its scriptable object.
- **Bullet:** This script control bullets behaviour
- **Game Manager:** This script manages game, stores coins & kills and enemies number
- **Input Manager 2D:** This script handles and stores inputs from user, useable for control character movement.
- **Room Manager:** This script activate virtual camera of room which contain player and deactive virtual camera of room which player already left.
- **Button Manager:** This script manages buttons behaviour.
- **Music:** This script manages and stores musics.
- **Mono Behaviour Singleton:** This class makes its children singleton.
- **Raycast:** This class manages special raycast formula for enemies.
- **Room Blocker:** This script blocks exit room until player completes missions.
- **Exit Door:** This script sets exit door which transfrom player to another scene.
- **Cinemachine Shake:** This script shakes camera when player shoots.
- **Enemy:** This script registers enemy and handles its attributes, patrol, detection, shoot and.
- **Enemy Controller:** This script handles enemy death .
- **Enemy Pathconfig:** This is a scriptable object which takes a path of enemy.
- **Enemy Config:**  This is a scriptable object which takes list of all enemy pathes.
- **Enemy Spawner:** This script spawn enemies by their config.
- **Detector Agent:** This script handles enemis detection.
- **Patrol Agent:** This script handles enemies patrol.
- **UI Coin:** This script displays coin from game manager.
- **UI Health Bar:** This script displays health from game manager.
- **UI Kill:** This script displays kill from game manager.
- **UI Message:** This script displays message.
- **UI Time:** This script displays time.
- **UI Weapon Bar:** This script displays weapons in inventroy with their ammos.

## Add weapons and ammos
- Create a weapon property / ammo property asset and fill fields of script.
- Create a game object in scene and add <Weapon> / <Ammo> component. Drag & drop property into its field in Weapon / Ammo component.
    - **!:** Sprite renderer most be attached to game object but you don't need to set its skin. Skin which you set in property will render in run time.

## Add enemy
- Create a path prefab and save it in -> Paths/Prefab/
- Create an Enemy pathconfig asset and fill its field wth your path prefab. Check static option if your enemy doesn't move. Save this config in -> Paths/Path/
- Create Enemy Config if you make new scene, else open Resources/EnemyConfig/Enemies.asset & add your path config into its list.
- Your enemy will spawn in run time.

