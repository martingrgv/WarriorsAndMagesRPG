using WarriorsAndMagesRPG.Core.Contracts;

namespace WarriorsAndMagesRPG.Core.Services
{
    public class ConsolePrinterService : IPrinterService
    {
        public void Print(string text)
        {
            Console.Write(text);
        }

        public void PrintLine()
        {
            Console.WriteLine();
        }

        public void PrintLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
