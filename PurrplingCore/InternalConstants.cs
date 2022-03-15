using System;
using System.Collections.Generic;
using System.Text;

namespace PurrplingCore
{
    internal static class InternalConstants
    {
        /// <summary>The character used as a separator between the token name and positional input arguments.</summary>
        public const string PositionalInputArgSeparator = ":";

        /// <summary>The character used as a separator between the token name (or positional input arguments) and named input arguments.</summary>
        public const string NamedInputArgSeparator = "|";

        /// <summary>The character used as a separator between the mod ID and token name for a mod-provided token.</summary>
        public const string ModTokenSeparator = "/";

        /// <summary>A prefix for player names when specified as an input argument.</summary>
        public const string PlayerNamePrefix = "@";
    }
}
