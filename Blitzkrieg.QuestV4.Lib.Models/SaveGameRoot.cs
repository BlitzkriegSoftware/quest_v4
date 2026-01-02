using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models;


/// <summary>
/// Save Game Root Model
/// <para>
/// On load will find a stair to start on regardless of where saved
/// </para>
/// </summary>
public class SaveGameRoot
{
    /// <summary>
    /// Player Name
    /// </summary>
    [JsonProperty(nameof(PlayerName))]
    public string PlayerName { get; set; } = "Hero";

    /// <summary>
    /// Player Level
    /// </summary>
    [JsonProperty(nameof(Level))]
    public int Level { get; set; } = 1;
    /// <summary>
    /// Dungeon Depth
    /// </summary>
    [JsonProperty(nameof(Depth))]
    public int Depth { get; set; } = 1;

    /// <summary>
    /// How many times have we died
    /// </summary>
    [JsonProperty(nameof(Deaths))]
    public int Deaths { get; set; } = 0;

    /// <summary>
    /// Experience
    /// </summary>
    [JsonProperty(nameof(Experience))]
    public int Experience { get; set; } = 0;

    /// <summary>
    /// Map File Name
    /// </summary>
    [JsonProperty(nameof(MapFileName))]
    public string MapFileName { get; set; } = string.Empty;

    /// <summary>
    /// Stats
    /// </summary>
    [JsonProperty(nameof(Stats))]
    public Dictionary<string, int> Stats { get; set; }

    /// <summary>
    /// Inventory
    /// </summary>
    [JsonProperty(nameof(Inventory))]
    public List<InventoryItem> Inventory { get; set; }

    /// <summary>
    /// Debug String
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{PlayerName} Lvl:{Level} XP:{Experience} Map:{MapFileName}";
    }

    /// <summary>
    /// Valid save game?
    /// </summary>
    /// <returns>True if so</returns>
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(PlayerName)
            && Level > 0
            && Experience >= 0
            && !string.IsNullOrWhiteSpace(MapFileName)
            && Stats != null
            && Inventory != null;
    }
}
