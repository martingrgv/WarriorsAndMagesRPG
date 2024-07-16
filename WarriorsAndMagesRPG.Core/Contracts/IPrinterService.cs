namespace WarriorsAndMagesRPG.Core.Contracts
{
    public interface IPrinterService
    {
        void Print(char character);
        void Print(string text);
        void PrintLine();
        void PrintLine(char character);
        void PrintLine(int number);
        void PrintLine(string text);
        void Clear();
    }
}
