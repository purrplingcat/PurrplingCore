using PurrplingCore.Events;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurrplingCore.Framework.Events
{
    internal class CoreModEvents : ICoreModEvents
    {
        private readonly EventManager _manager;

        public CoreModEvents(EventManager manager)
        {
            this._manager = manager;
        }

        public event EventHandler<SellItemArgs> OnSellItem
        {
            add => this._manager.OnSellItem.Add(value);
            remove => this._manager.OnSellItem.Remove(value);
        }
    }
}
