using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Events;

namespace PurrplingCore.Internal
{
    internal interface IUpdateable
    {
        void Update(UpdateTickedEventArgs e);
    }
}
