namespace PurrplingCore.Lexing.LexTokens
{
    /**
     * Original code by PathosChild.
     * Original source: https://github.com/Pathoschild/StardewMods/blob/develop/ContentPatcher/Framework/Lexing/LexTokens/ILexToken.cs
     * Licensed under MIT
     */

    /// <summary>A lexical token within a string, which combines one or more <see cref="LexBit"/> patterns into a cohesive part.</summary>
    internal interface ILexToken
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The lexical token type.</summary>
        LexTokenType Type { get; }


        /*********
        ** Public methods
        *********/
        /// <summary>Get a text representation of the lexical token.</summary>
        string ToString();
    }
}
