using WarriorsAndMagesRPG.Core.Contracts;

namespace WarriorsAndMagesRPG.Core.Services
{
    public class ConsoleReaderService : IReaderService
    {
        public string Read()
        {
            return Console.ReadLine()!;
        }

        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
