using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models;

/// <summary>
/// Map information for the quest
/// </summary>
public class MapInfo
{
    /// <summary>
    /// Minimum level
    /// </summary>
    [JsonProperty(nameof(MinLevel))]
    public int MinLevel { get; set; }

    /// <summary>
    /// Maximum level
    /// </summary>
    [JsonProperty(nameof(MaxLevel))]
    public int MaxLevel { get; set; }

    /// <summary>
    /// Relative folder path for maps
    /// </summary>
    [JsonProperty(nameof(Folder))]
    public string Folder { get; set; } = @".\maps";

    /// <summary>
    /// Map file extension
    /// </summary>
    [JsonProperty(nameof(FileExt))]
    public string FileExt { get; set; }
}
