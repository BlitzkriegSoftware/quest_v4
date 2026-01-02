using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models;

/// <summary>
/// Inventory Item Model
/// </summary>
public class InventoryItem
{
    /// <summary>
    /// Id Matches Kind Id
    /// </summary>
    [JsonProperty(nameof(Id))]
    public int Id { get; set; }

    /// <summary>
    /// Must match name of item exactly
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string Name { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty(nameof(Quantity))]
    public int Quantity { get; set; }
}
