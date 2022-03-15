using Harmony;
using StardewModdingAPI;

namespace PurrplingCore.Patching
{
    internal interface IPatch
    {
        string Name { get; }
        bool Applied { get; }
        void Apply(HarmonyInstance harmony, IMonitor monitor);
    }
}
