using StardewValley;
using System.Collections.Generic;
using System.Linq;

namespace PurrplingCore.Dialogues
{
    internal class DialogueHelper
    {
        public const char FLAG_RANDOM = '~';
        public const char FLAG_CHANCE = '^';

        /// <summary>
        /// Returns a raw dialogue string as key-value pair from specified dialogue registry
        /// </summary>
        /// <param name="dialogues">A dialogue registry</param>
        /// <param name="key">For which key we want to fetch a dialogue?</param>
        /// <param name="rawDialogue">Fetched dialogue. Value part is <paramref name="key"/> if dialogue not exists for this key</param>
        /// <returns>True if raw dialogue found and returned in <paramref name="rawDialogue"/></returns>
        public static bool GetRawDialogue(Dictionary<string, string> dialogues, string key, out KeyValuePair<string, string> rawDialogue)
        {
            var keys = from _key in dialogues.Keys
                       where _key.StartsWith(key + FLAG_RANDOM) || _key.StartsWith(key + FLAG_CHANCE)
                       select _key;
            var randKeys = keys.Where((k) => k.Contains(FLAG_RANDOM)).ToList();
            var chanceKeys = keys.Where((k) => k.Contains(FLAG_CHANCE)).ToList();

            if (chanceKeys.Count > 0)
            {
                // Chance conditioned dialogue
                foreach (string k in chanceKeys)
                {
                    var s = k.Split(FLAG_CHANCE);
                    float chance = float.Parse(s[1]) / 100;
                    if (Game1.random.NextDouble() <= chance && dialogues.TryGetValue(k, out string chancedText))
                    {
                        rawDialogue = new KeyValuePair<string, string>(k, chancedText);
                        return true;
                    }
                }
            }

            if (randKeys.Count > 0)
            {
                // Randomized dialogue
                int i = Game1.random.Next(0, randKeys.Count() + 1);

                if (i < randKeys.Count() && dialogues.TryGetValue(randKeys[i], out string randomText))
                {
                    rawDialogue = new KeyValuePair<string, string>(randKeys[i], randomText);
                    return true;
                }
            }

            if (dialogues.TryGetValue(key, out string text))
            {
                // Standard dialogue
                rawDialogue = new KeyValuePair<string, string>(key, text);
                return true;
            }

            rawDialogue = new KeyValuePair<string, string>(key, key);

            return false;
        }
    }
}
