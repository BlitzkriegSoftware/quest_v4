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
}
