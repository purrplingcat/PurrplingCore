namespace PurrplingCore.Lexing.LexTokens
{
    /**
     * Original code by PathosChild.
     * Original source: https://github.com/Pathoschild/StardewMods/blob/develop/ContentPatcher/Framework/Lexing/LexTokens/LexTokenType.cs
     * Licensed under MIT
     */

    /// <summary>A lexical token type.</summary>
    internal enum LexTokenType
    {
        /// <summary>A literal string.</summary>
        Literal,

        /// <summary>A Content Patcher token.</summary>
        Token,

        /// <summary>The input arguments to a Content Patcher token.</summary>
        TokenInput
    }
}
