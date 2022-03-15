﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurrplingCore.Events
{
    public interface IManagedEvent
    {
        /// <summary>A human-readable name for the event.</summary>
        string EventName { get; }
    }
}
