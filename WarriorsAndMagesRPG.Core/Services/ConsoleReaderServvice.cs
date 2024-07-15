using WarriorsAndMagesRPG.Core.Contracts;

namespace WarriorsAndMagesRPG.Core.Services
{
    public class ConsoleReaderService : IReaderService
    {
        public string Read()
        {
            return Console.ReadLine()!;
        }

        public string ReadKey()
        {
            return Console.ReadKey().Key
                .ToString()!;
        }
    }
}
