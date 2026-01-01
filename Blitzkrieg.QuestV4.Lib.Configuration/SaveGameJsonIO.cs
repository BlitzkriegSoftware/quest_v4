using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Configuration
{
    /// <summary>
    /// Save Game JSON Reader
    /// </summary>
    public static class SaveGameJsonIO
    {
        /// <summary>
        /// Read and parse configuration
        /// </summary>
        /// <param name="filename">(sic)</param>
        /// <returns>QuestConfigurationRoot configuration object</returns>
        /// <exception cref="FileNotFoundException">(sic)</exception>
        public static SaveGameRoot FromFile(string filename)
        {
            if (!File.Exists(filename)) throw new FileNotFoundException(filename);
            string text = File.ReadAllText(filename);
            SaveGameRoot questConfig = JsonConvert.DeserializeObject<SaveGameRoot>(text);
            return questConfig is null ? throw new NullReferenceException("No configuration parsed") : questConfig;
        }

        /// <summary>
        /// Save a game to file
        /// </summary>
        /// <param name="filename">(sic)</param>
        /// <param name="saveGame">Game to save</param>
        public static void ToFile(string filename, SaveGameRoot saveGame)
        {
            string text = JsonConvert.SerializeObject(saveGame, Formatting.Indented);
            File.WriteAllText(filename, text);
        }

    }
}
