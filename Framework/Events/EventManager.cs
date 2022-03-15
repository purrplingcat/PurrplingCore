using PurrplingCore.Events;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurrplingCore.Framework.Events
{
    internal class EventManager
    {
        public ManagedEvent<SellItemArgs> OnSellItem { get; }

        public EventManager()
        {
            this.OnSellItem = new ManagedEvent<SellItemArgs>(nameof(ICoreModEvents.OnSellItem));
        }
    }
}
