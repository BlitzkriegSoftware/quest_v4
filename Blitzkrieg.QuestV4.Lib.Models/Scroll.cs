using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models;


/// <summary>
/// Scroll information
/// </summary>
public class Scroll
{
    /// <summary>
    /// Name of the scroll
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string Name { get; set; }
    /// <summary>
    /// Effect of the scroll
    /// </summary>
    [JsonProperty(nameof(Effect))]
    public string Effect { get; set; }
    /// <summary>
    /// Impact factor of the scroll
    /// </summary>
    [JsonProperty(nameof(Impact))]
    public int Impact { get; set; }
    /// <summary>
    /// Radius of the scroll's effect
    /// </summary>
    [JsonProperty(nameof(Radius))]
    public int Radius { get; set; }

    /// <summary>
    /// Minimum level required to use the scroll
    /// </summary>
    [JsonProperty(nameof(MinLevel))]
    public int MinLevel { get; set; }

    /// <summary>
    /// Maximum level to use the scroll
    /// </summary>
    [JsonProperty(nameof(MaxLevel))]
    public int MaxLevel { get; set; }

    /// <summary>
    /// Debug string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{Name} [Lvl {MinLevel}-{MaxLevel}] (Effect: {Effect}, Impact: {Impact}, Radius: {Radius})";
    }   
}
