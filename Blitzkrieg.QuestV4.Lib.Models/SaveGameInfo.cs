using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models;

/// <summary>
/// Save Game information
/// </summary>
public class SaveGameInfo
{
    /// <summary>
    /// Relative folder path for maps
    /// </summary>
    [JsonProperty(nameof(Folder))]
    public string Folder { get; set; } = @".\saves";

    /// <summary>
    /// Map file extension
    /// </summary>
    [JsonProperty(nameof(FileExt))]
    public string FileExt { get; set; } = ".sav";
}
