using WarriorsAndMagesRPG.Core.Models;
using WarriorsAndMagesRPG.Infrastructure;

namespace WarriorsAndMagesRPG.Core.Contracts
{
    public interface ICharacterLoggerService
    {
        void Log(WarriorsAndMagesContext context, Character character);
    }
}
