using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models;


/// <summary>
/// Potion information
/// </summary>
public class Potion
{
    /// <summary>
    /// Name of the potion
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string Name { get; set; }

    /// <summary>
    /// Effect of the potion
    /// </summary>
    [JsonProperty(nameof(Effect))]
    public string Effect { get; set; }

    /// <summary>
    /// Impact factor of the potion
    /// </summary>
    [JsonProperty(nameof(Impact))]
    public int Impact { get; set; }

    /// <summary>
    /// Radius of the potion's effect
    /// </summary>
    [JsonProperty(nameof(Radius))]
    public int Radius { get; set; }

    [JsonProperty(nameof(Chance))]
    public double Chance { get; set; } = 0.0;

    /// <summary>
    /// Debug String
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"{Name} (Effect: {Effect}, Impact: {Impact}, Radius: {Radius}, Chance: {Chance:n2})";
}
