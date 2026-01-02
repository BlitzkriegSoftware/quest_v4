
using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models;

/// <summary>
/// Monster information
/// </summary>
public class Monster
{
    /// <summary>
    /// DO NOT CHANGE ORDER OF THIS STRING WITHOUT UPDATING THE LOGIC THAT USES IT!
    /// <list type="bullet">
    /// <item>a = acid (target armor reduced by...)</item>
    /// <item>f = fire (damage increased by ...)</item>
    /// <item>m = magic (magic damage reduced by ...)</item>
    /// <item>p = poison (constant damage of ...)</item>
    /// <item>t = thief (inventory reduced on %...)</item>
    /// </list>
    /// </summary>
    public const string ALLOWED_SPECIALS = "afmpt";

    /// <summary>
    /// Symbol representing the monster
    /// </summary>
    [JsonProperty(nameof(Symbol))]
    public string Symbol { get; set; }

    /// <summary>
    /// Display name of the monster
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string Name { get; set; }

    /// <summary>
    /// Minimum level of the monster
    /// </summary>
    [JsonProperty(nameof(MinLevel))]
    public int MinLevel { get; set; }

    /// <summary>
    /// Maximum level of the monster
    /// </summary>
    [JsonProperty(nameof(MaxLevel))]
    public int MaxLevel { get; set; }

    /// <summary>
    /// Attack Strength of the monster
    /// </summary>
    [JsonProperty(nameof(Attack))]
    public string Attack { get; set; }

    /// <summary>
    /// Defense Strength of the monster
    /// </summary>
    [JsonProperty(nameof(Defense))]
    public int Defense { get; set; }

    /// <summary>
    /// Movement per turn of the monster
    /// </summary>
    [JsonProperty(nameof(Movement))]
    public int Movement { get; set; }

    /// <summary>
    /// Base Hit Points of the monster
    /// </summary>
    [JsonProperty(nameof(Hits))]
    public int Hits { get; set; }

    /// <summary>
    /// Special abilities of the monster
    /// </summary>
    [JsonProperty(nameof(Special))]
    public string Special { get; set; }

    /// <summary>
    /// Level modifier for the monster
    /// </summary>
    [JsonProperty(nameof(LevelMod))]
    public double LevelMod { get; set; }


    public static int HitPointsAdjusted(int level, int baseHits, double levelMod)
    {
        return (int)Math.Round(baseHits + (baseHits * (level * levelMod)), 0);
    }

    /// <summary>
    /// Monster Debug String
    /// </summary>
    /// <returns>A string containing the object's name, minimum and maximum levels, attack, defense, movement, hit points,
    /// and speed modifier.</returns>
    public override string ToString()
    {
        return $"{Name} (Lvl {MinLevel}-{MaxLevel}) ATK:{Attack} DEF:{Defense} MOV:{Movement} HP:{Hits} SPD:{LevelMod}";
    }
}
