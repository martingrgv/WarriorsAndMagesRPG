using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models;
using static WarriorsAndMagesRPG.Core.Constants;

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
            List<Monster> monsters = new List<Monster>() { new Monster() };

            while (true)
            {
                try
                {
                    _printerService.Clear();


                    foreach (var monster in monsters)
                    {
                        CheckMonsterLocation(character, monster);
                    }

                    PrintPlayerStats(character);
                    PrintField(gameField, character, monsters);
                    PrintAction();

                    HandleAction(character);

                    //CreateMonster(character, monsters);
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
        }


        private void HandleAction(Character character)
        {
            char act = _readerService.ReadKey();

            if (act != '1' && act != '2')
            {
                throw new ArgumentException("Invalid action! Try again.");
            }

            _printerService.PrintLine();
            _printerService.PrintLine($"Choose direction ({string.Join(", ", MOVEMENT_KEYS)}):");
            char key = char.ToLower(_readerService.ReadKey());

            CheckKey(key);

            if (act == '1')
            {
                //character.Attack();
            }
            else if (act == '2')
            {
                character.Move(key);
            }
        }

        private void CheckKey(char key)
        {
            if (!MOVEMENT_KEYS.Any(k => k != key))
            {
                throw new ArgumentException($"{key} is not a valid key!");
            }
        }

        private void Attack(Character character)
        {
            //character.Attack();
        }

        private void Move(Character character, char key)
        {
            character.Move(key);
        }

        private void CreateMonster(Character character, List<Monster> monsters)
        {
            monsters.Add(new Monster());
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

        private void PrintField(int[,] gameField, Character character, List<Monster> monsters)
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

                    if (monsters.Any(m => m.PosX == x && m.PosY == y))
                    {
                        Monster? monster = monsters.FirstOrDefault();
                        
                        if (monster != null)
                        {
                            _printerService.Print(monster.CharacterSymbol);
                        }
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
