# Warriors And Mages RPG
### Simple RPG game implemented for console app
### ! Created for extending to other project

## Gameplay
### Players navigate through a matrix 10x10 hunting a monster
1. Player class select
2. (Optional) Player stats buff
3. Player can move or attack
- Player moves in every direction (up, down, left, right and diagonals)
- In the meantime monster followes the player behind his every move
- If player is in monster's range the player is being attack and loses his health
- A successful attack is only when monster is in player's range
- Each attack is wasted if there is no monster nearby and for mages mana is lost
4. Game completion
- If player manages to kill the monster, he wins
- If player loses his health before killing the monster, player looses

## Game Includes:
- Menus: Main menu, Character select menu, In game menu and Exit menu
- Character classes: Mage, Warrior, Archer
- Log files for player creation in database using Entity Framework Core
- Engine made for console app using IoC for DI (for other projects like ASP.Net or WinForms preferably implement your own engine)

### What to expect
- Code documentation
