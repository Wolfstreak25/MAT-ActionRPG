# MAT-ActionRPG
This project will be submitted as MAT2 for assessment. 
the base implementation of this project is in the main branch but since that was created way back whwn i was learning the unity basics so the code architecture is not feasible.
# The Drawbacks of base Implementation
1. The code was not modular
2. The Game loop was not complete
3 Were bugs while while enemis died before quest.
# New Implementation
1. MVC pattern is being used in order to manage PLAYERS, ENEMIES, NPC's, QUEST and DIALOGUE.
2. SINGLETON pattern is used in order to keep single instances of the Services such as PLAYER,ENEMY and also the <amagers such as UI manager and Game Manager
3. Observer pattern is being used for event management as in to when to spawn enemies and updating the quest data is done using it.
# The project is still under maintainance but the Implementation of the QUEST SYSTEM, DIALOGUE SYSTEM and INVENTORY SYSTEM is working. In order to make the game playable it needs more time
