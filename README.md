# 🧙‍♂️ Warriors And Mages RPG
### 💻 Console RPG Game for hunting monsters

## 🕹️ Gameplay
### Players navigate through a matrix 10x10 hunting a monster

## 🎯 Features
- Player class select
- Player stats buff
- Player moves in every direction (up, down, left, right and diagonals)
- Player can attack monsters
- Monster followes behind the player at every step. (Make wise decisions)
- If player is in monster's range the player is being attacked and loses his health
- A successful attack is only when monster is in player's range
- Each attack is wasted if there is no monster nearby and for mages mana is lost
- If player manages to kill the monster, he wins
- If player loses his health before killing the monster, player looses

## 🎮 Functionalities:
- Menus: Main menu, Character select menu, In game menu and Exit menu
- Character classes: Mage, Warrior, Archer

## 🏛️ Architecture
*N-tier Architecture*

- Engine handles game logic
- Infrastructure layer provides entities for database character logs
- Core layer game logic

### Tools: 
Microsoft.DependencyInjection, EntityFrameworkCore, Microsoft SQL Server
