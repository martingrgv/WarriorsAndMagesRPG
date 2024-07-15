using WarriorsAndMagesRPG.Core;
using WarriorsAndMagesRPG.Core.Contracts;
using WarriorsAndMagesRPG.Core.Services;

namespace WarriorsAndMagesRPG
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
