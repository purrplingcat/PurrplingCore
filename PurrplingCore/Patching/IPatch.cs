using HarmonyLib;
using StardewModdingAPI;

namespace PurrplingCore.Patching
{
    internal interface IPatch
    {
        string Name { get; }
        bool Applied { get; }
        void Apply(Harmony harmony, IMonitor monitor);
    }
}
