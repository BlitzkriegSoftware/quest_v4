using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models;

/// <summary>
/// (base) Stat information
/// </summary>
public class Stat
{
    /// <summary>
    /// Points to give initially to distribute among stats
    /// </summary>
    public const int INITIAL_STAT_POINTS = 5;

    /// <summary>
    /// Short Id
    /// </summary>
    [JsonProperty(nameof(Id))]
    public string Id { get; set; }

    /// <summary>
    /// Long name
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string Name { get; set; }
    /// <summary>
    /// Minimum value
    /// </summary>
    [JsonProperty(nameof(Min))]
    public int Min { get; set; }
    /// <summary>
    /// Maximum value
    /// </summary>
    [JsonProperty(nameof(Max))]
    public int Max { get; set; }

    /// <summary>
    /// Debug string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{Id}: {Name} (Min={Min}, Max={Max})";
    }
}
