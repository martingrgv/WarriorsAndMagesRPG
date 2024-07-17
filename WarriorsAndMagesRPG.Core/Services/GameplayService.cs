using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Models;
using static WarriorsAndMagesRPG.Core.Constants;

namespace WarriorsAndMagesRPG.Core.Services
{
    public class GameplayService : IGameplayService
    {
        private IPrinterService _printerService;
        private IReaderService _readerService;

        private CharacterViewModel _character;
        private Monster _monster;
        private int[,] _gameField;

        public GameplayService(IPrinterService printerService, IReaderService readerService)
        {
            _printerService = printerService;
            _readerService = readerService;
        }

        public void StartGame(int[,] gameField, CharacterViewModel character)
        {
            _gameField = gameField;
            _character = character;
            _monster = new Monster();

            PrintPlayerStats();
            CheckMonsterLocation();
            PrintField();
            PrintAction();

            _readerService.ReadKey();
        }

        private void CheckMonsterLocation()
        {
            while (_monster.PosX == 1 && _monster.PosY == 1)
            {
                Random rnd = new Random();
                _monster.PosX = rnd.Next(0, GAME_FIELD_SIZE);
                _monster.PosY = rnd.Next(0, GAME_FIELD_SIZE);
            }
        }

        private void PrintAction()
        {
            for (int i = 0; i < GAME_ACTIONS.Length; i++)
            {
                _printerService.PrintLine($"{i + 1} ) {GAME_ACTIONS[i]}");
            }
        }

        private void PrintPlayerStats()
        {
            _printerService.Print($"Health: {_character.Health} ");

            if (_character as Mage != null)
            {
                Mage mage = (Mage)_character;
                _printerService.Print($"Mana: {mage.Mana}");
            }

            _printerService.PrintLine();
        }

        private void PrintField()
        {
            for (int y = 0; y < _gameField.GetLength(0); y++)
            {
                for (int x = 0; x < _gameField.GetLength(1); x++)
                {
                    if (x == _character.PosX && y == _character.PosY)
                    {
                        _printerService.Print(_character.CharacterSymbol);
                        continue;
                    }

                    if (x == _monster.PosX && y == _monster.PosY)
                    {
                        _printerService.Print(_monster.CharacterSymbol);
                        continue;
                    }

                    _printerService.Print(EMPTY_FIELD_SYMBOL);
                }

                _printerService.PrintLine();
            }
        }
    }
}
