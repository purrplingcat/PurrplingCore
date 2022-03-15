using PurrplingCore.Events;
using StardewModdingAPI;

namespace PurrplingCore
{
    public interface IPurrplingCoreApi
    {
        IPurrplingCoreProxy CreateProxy(Mod forMod);
    }
}
