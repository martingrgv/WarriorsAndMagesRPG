namespace WarriorsAndMagesRPG.Core
{
    public static class Constants
    {
        public const string MAIN_MENU_TEXT =
            "Welcome!\n" +
            "Press any key to play.";

        public const string CHARACTER_SELECT_MENU_TEXT =
            "Choose character type:\n" +
            "Options:\n" +
            "1) Warrior\n" +
            "2) Archer\n" +
            "3) Mage\n" +
            "Your pick:";

        public const string STATS_ADD_TEXT =
            "Would you like to buff up your stats before starting?\n" +
            "Response (Y\\N):";

        public const string EXIT_TEXT =
            "Thank you for playing! Good bye.";

        public const int BUFF_LIMIT_POINTS = 3;

        public const char EMPTY_FIELD_SYMBOL = '▒';

        public const char MAGE_SYMBOL = '*';
        public const char WARRIOR_SYMBOL = '@';
        public const char ARCHER_SYMBOL = '#';
        public const char MONSTER_SYMBOL = 'M';

        public const int MAGE_STRENGTH = 2;
        public const int MAGE_AGILITY = 1;
        public const int MAGE_INTELLIGENCE = 3;
        public const int MAGE_RANGE = 3;

        public const int WARRIOR_STRENGTH = 3;
        public const int WARRIOR_AGILITY = 3;
        public const int WARRIOR_INTELLIGENCE = 0;
        public const int WARRIOR_RANGE = 1;

        public const int ARCHER_STRENGTH = 2;
        public const int ARCHER_AGILITY = 4;
        public const int ARCHER_INTELLIGENCE = 0;
        public const int ARCHER_RANGE = 2;

        public const int MONSTER_STATUS_MIN_RANDOM = 1;
        public const int MONSTER_STATUS_MAX_RANDOM = 3;
        public const int MONSTER_RANGE = 1;

        public const int GAME_FIELD_SIZE = 10;
        public const int START_CHARACTER_POSX = 1;
        public const int START_CHARACTER_POSY = 1;

        public static readonly string[] GAME_ACTIONS = { "Attack", "Move" };
        public static readonly char[] MOVEMENT_KEYS = { 'w', 'a', 's', 'd', 'e', 'q', 'x', 'z' };
    }
}
