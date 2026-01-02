using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models;

/// <summary>
/// (Sic)
/// </summary>
public static class ConfigurationJsonReader
{
    /// <summary>
    /// Read and parse configuration
    /// </summary>
    /// <param name="filename">(sic)</param>
    /// <returns>QuestConfigurationRoot configuration object</returns>
    /// <exception cref="FileNotFoundException">(sic)</exception>
    public static QuestConfigurationRoot FromFile(string filename)
    {
        if (!File.Exists(filename)) throw new FileNotFoundException(filename);
        string text = File.ReadAllText(filename);
        QuestConfigurationRoot questConfig = JsonConvert.DeserializeObject<QuestConfigurationRoot>(text);
        return questConfig is null ? throw new NullReferenceException("No configuration parsed") : questConfig;
    }
}
