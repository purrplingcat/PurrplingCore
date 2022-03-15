using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PurrplingCore.Events;
using PurrplingCore.Framework.Events;
using PurrplingCore.Framework.Proxy;
using PurrplingCore.Patching;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Monsters;
using StardewValley.Quests;

namespace PurrplingCore
{
    /// <summary>The mod entry point.</summary>
    public class PurrplingCoreMod : Mod, IPurrplingCoreApi
    {
        internal EventManager EventManager { get; private set; }

        public ICoreModEvents Events { get; private set; }

        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.EventManager = new EventManager();
            this.Events = new CoreModEvents(this.EventManager);

            // var patches = new GamePatcher(this.ModManifest.UniqueID, this.Monitor);

            helper.Events.GameLoop.SaveLoaded += this.GameLoop_SaveLoaded;
        }

        private void GameLoop_SaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            IPurrplingCoreProxy proxy = new PurrplingCoreProxy(this, this);

            proxy.RegisterDataType<Quest>();
            proxy.RegisterDataType<Monster>();

            proxy.Data.WriteJsonFile("test/quests.json", Game1.player.questLog);
            var data = proxy.Data.ReadJsonFile<List<Quest>>("test/quests.json");
        }

        public override object GetApi()
        {
            return this;
        }

        public IPurrplingCoreProxy CreateProxy(Mod forMod)
        {
            return new PurrplingCoreProxy(this, forMod);
        }
    }
}