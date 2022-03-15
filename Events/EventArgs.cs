using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurrplingCore.Events
{
    public class SellItemArgs : EventArgs
    {
        public ISalable SoldItem { get; }

        internal SellItemArgs(ISalable soldItem)
        {
            this.SoldItem = soldItem;
        }
    }
}
