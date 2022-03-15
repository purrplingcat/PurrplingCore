using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurrplingCore.Events
{
    public interface ICoreModEvents
    {
        event EventHandler<SellItemArgs> OnSellItem;
    }
}
