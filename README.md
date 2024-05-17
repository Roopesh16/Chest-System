
#  CHEST RUMBLE

Inspired by **Clash of Clans** chest system, this is an attempt to build it implement Design patterns and OOPS.  

##  Goal
The goal for this project was - 
1. Implement Design patterns and OOPS
2. Spawn Random chests
3. Add Timer to each chest for unlocking
4. Generate random coins and Gems on completion

##  Working
1. Click on **Generate!** button to generate random chest, only 4 slots available
2. You can choose to either use gems to unlock directly or run timer to unlock them
3. Once completed, you can collect from chest

![Simple](https://github.com/Roopesh16/Chest-System/blob/main/Pics/Simple.png)

![Unlocking](https://github.com/Roopesh16/Chest-System/blob/main/Pics/Unlocking.png)

![Unlocked](https://github.com/Roopesh16/Chest-System/blob/main/Pics/Unlocked.png)

## Architecture
In this project, I have implemented  - 
1. MVC for each entity
2. Service Locator manage all services
3. State Machine for Chest States
4. Command Pattern to undo Gem transaction  

Looking at the folder structure you can see the order in which I have arranged scripts. The whole idea was make codebase modular and easy to use.  

##  Conclusion

This was a extensive learning project, where I got to implement 4 design pattern simultaneously and learn and how to manage code base and establish script communication.