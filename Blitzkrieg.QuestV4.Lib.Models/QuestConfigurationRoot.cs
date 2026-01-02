
using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models;

/// <summary>
/// ROOT Quest Configuration Model
/// </summary>
public class QuestConfigurationRoot
{
    /// <summary>
    /// (sic)
    /// </summary>
    [JsonProperty(nameof(MapInfo))]
    public MapInfo MapInfo { get; set; }

    /// <summary>
    /// (sic)
    /// </summary>
    [JsonProperty(nameof(SaveGameInfo))]
    public SaveGameInfo SaveGameInfo { get; set; }

    /// <summary>
    /// (sic)
    /// </summary>
    [JsonProperty(nameof(Things))]
    public List<Thing> Things { get; } = [];
    /// <summary>
    /// (sic)
    /// </summary>
    [JsonProperty(nameof(Scrolls))]
    public List<Scroll> Scrolls { get; } = [];
    /// <summary>
    /// (sic)
    /// </summary>
    [JsonProperty(nameof(Potions))]
    public List<Potion> Potions { get; } = [];
    /// <summary>
    /// (sic)
    /// </summary>
    [JsonProperty(nameof(Monsters))]
    public List<Monster> Monsters { get; } = [];
    /// <summary>
    /// (sic)
    /// </summary>
    [JsonProperty(nameof(Stats))]
    public List<Stat> Stats { get; } = [];
}
