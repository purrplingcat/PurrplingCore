namespace PurrplingCore.Lexing.LexTokens
{
    /**
     * Original code by PathosChild.
     * Original source: https://github.com/Pathoschild/StardewMods/blob/develop/ContentPatcher/Framework/Lexing/LexTokens/LexBit.cs
     * Licensed under MIT
     */

    /// <summary>A low-level character pattern within a string/</summary>
    internal class LexBit
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The lexical character pattern type.</summary>
        public LexBitType Type { get; }

        /// <summary>The raw matched text.</summary>
        public string Text { get; }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="type">The lexical character pattern type.</param>
        /// <param name="text">The raw matched text.</param>
        public LexBit(LexBitType type, string text)
        {
            this.Type = type;
            this.Text = text;
        }
    }
}
