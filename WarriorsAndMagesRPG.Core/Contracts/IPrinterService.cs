namespace WarriorsAndMagesRPG.Core.Contracts
{
    public interface IPrinterService
    {
        void Print(string text);
        void PrintLine();
        void PrintLine(string text);
        void Clear();
    }
}
