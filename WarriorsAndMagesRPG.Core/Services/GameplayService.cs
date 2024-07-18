using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models;
using static WarriorsAndMagesRPG.Core.Common.Constants;

namespace WarriorsAndMagesRPG.Core.Services
{
    public class GameplayService : IGameplayService
    {
        private IPrinterService _printerService;
        private IReaderService _readerService;

        public GameplayService(IPrinterService printerService, IReaderService readerService)
        {
            _printerService = printerService;
            _readerService = readerService;
        }

        public void StartGame(int[,] gameField, Character character)
        {
            Monster monster = new Monster();
            CheckMonsterLocation(character, monster);

            while (character.Health > 0 && monster.Health > 0)
            {
                try
                {
                    _printerService.Clear();

                    PrintPlayerStats(character);
                    PrintField(gameField, character, monster);
                    PrintAction();

                    monster.FollowCharacter(character);
                    monster.Attack(character);
                    HandleAction(character, monster);
                }
                catch (ArgumentException e)
                {
                    ShowException(e.Message);
                }
                catch(InvalidOperationException e)
                {
                    ShowException(e.Message);
                }
                catch(Exception e)
                {
                    ShowException(e.Message);
                }
            }

            _printerService.PrintLine();

            if (character.Health <= 0)
            {
                _printerService.PrintLine(LOST_TEXT);
            }
            else if (monster.Health <= 0)
            {
                _printerService.PrintLine(WON_TEXT);
            }

            _printerService.PrintLine("Press any key to continue...");
            _readerService.ReadKey();
        }


        private void HandleAction(Character character, Monster monster)
        {
            char act = _readerService.ReadKey();

            if (act != '1' && act != '2')
            {
                throw new ArgumentException("Invalid action! Try again.");
            }

            if (act == '1')
            {
                character.Attack(monster);
                return;
            }

            if (act == '2')
            {
                _printerService.PrintLine();
                _printerService.PrintLine($"Choose direction ({string.Join(", ", MOVEMENT_KEYS)}):");
                char key = char.ToLower(_readerService.ReadKey());

                if (IsValidKey(key))
                {
                    character.Move(key);
                    monster.Move(key);
                    return;
                }
                
                throw new ArgumentException($"{key} is not a valid key!");
            }
        }

        private bool IsValidKey(char key)
        {
            return MOVEMENT_KEYS.Any(k => k != key);
        }

        private void Attack(Character character, Monster monster)
        {
            character.Attack(monster);
        }

        private void Move(Character character, char key)
        {
            character.Move(key);
        }

        private void CheckMonsterLocation(Character character, Monster monster)
        {
            while (monster.PosX == character.PosX && monster.PosY == character.PosY)
            {
                Random rnd = new Random();
                monster.PosX = rnd.Next(0, GAME_FIELD_SIZE);
                monster.PosY = rnd.Next(0, GAME_FIELD_SIZE);
            }
        }


        private void PrintPlayerStats(Character character)
        {
            _printerService.Print($"Health: {character.Health} ");

            if (character as Mage != null)
            {
                Mage mage = (Mage)character;
                _printerService.Print($"Mana: {mage.Mana}");
            }

            _printerService.PrintLine();
        }

        private void PrintField(int[,] gameField, Character character, Monster monster)
        {
            for (int y = 0; y < gameField.GetLength(0); y++)
            {
                for (int x = 0; x < gameField.GetLength(1); x++)
                {
                    if (x == character.PosX && y == character.PosY)
                    {
                        _printerService.Print(character.CharacterSymbol);
                        continue;
                    }

                    if (x == monster.PosX && y == monster.PosY)
                    {
                        _printerService.Print(monster.CharacterSymbol);
                        continue;
                    }


                    _printerService.Print(EMPTY_FIELD_SYMBOL);
                }

                _printerService.PrintLine();
            }
        }

        private void PrintAction()
        {
            for (int i = 0; i < GAME_ACTIONS.Length; i++)
            {
                _printerService.PrintLine($"{i + 1} ) {GAME_ACTIONS[i]}");
            }
        }

        private void ShowException(string message)
        {
            _printerService.PrintLine();
            _printerService.PrintLine(message);

            _printerService.PrintLine("Press any key to continue...");
            _readerService.ReadKey();
        }
    }
}
