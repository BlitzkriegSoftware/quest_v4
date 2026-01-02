using System.Numerics;

namespace Blitzkrieg.QuestV4.Lib.Models;

/// <summary>
/// Hero
/// </summary>
public class Hero
{
    #region "Constants"
    private const double HP_EXP_BASE = 1.1;
    private const double ST_BONUS = 1.1;
    private const double EN_BONUS = 1.3;
    private const int SCORE_PER_LEVEL = 1000;
    private const int SCORE_PER_EXPERIENCE = 10;
    private const int SCORE_PER_POTION = 2;
    private const int SCORE_PER_SCROLL = 3;
    private const int SCORE_PER_GOLD = 1;
    private const int SCORE_PER_JEWEL = 9;
    private const int SCORE_PER_DEATH = -500;
    private const int STAT_INITIAL_VALUE = 4;
    private readonly string[] STAT_LIST = ["st", "en", "iq"];
    private readonly InventoryItem[] INVENTORY_LIST = [
        new() { Id =  40, Name = "heal", Quantity = 3},
        new() { Id =  40, Name = "mana", Quantity = 3},
        new() { Id =  41, Name = "candle", Quantity = 5},
        new() { Id =  41, Name = "find-stair", Quantity = 2},
        new() { Id =  42, Name = "gold", Quantity = 10},
        new() { Id =  43, Name = "jewel", Quantity = 1},
    ];
    #endregion

    /// <summary>
    /// CTOR
    /// </summary>
    private Hero() { }

    /// <summary>
    /// CTOR
    /// </summary>
    /// <param name="name">Player Name</param>
    public Hero(string name)
    {
        this.PlayerName = name;
        this.Stats = [];
        foreach (string stat in STAT_LIST) this.Stats.Add(stat, STAT_INITIAL_VALUE);
        this.Inventory = [.. INVENTORY_LIST];
    }

    /// <summary>
    /// Player Name
    /// </summary>
    public string PlayerName { get; set; } = "Hero";

    /// <summary>
    /// Player Level
    /// </summary>
    public int Level { get; set; } = 1;

    /// <summary>
    /// Dungeon Depth
    /// </summary>
    public int Depth { get; set; } = 1;

    /// <summary>
    /// Place in row
    /// </summary>
    public int X { get; set; } = -1;

    /// <summary>
    /// Place in col
    /// </summary>
    public int Y { get; set; } = -1;

    /// <summary>
    /// Computed Damage
    /// </summary>
    public int Damage { get; set; } = 0;

    /// <summary>
    /// How many times have we died
    /// </summary>
    public int Deaths { get; set; } = 0;

    /// <summary>
    /// Experience
    /// </summary>
    public int Experience { get; set; } = 0;

    /// <summary>
    /// Stats
    /// </summary>
    public Dictionary<string, int> Stats { get; set; }

    /// <summary>
    /// Compute hit points
    /// </summary>
    /// <returns></returns>
    public int ComputeHitPoints()
    {
        int hp = 0;
        foreach (var s in Stats)
        {
            switch (s.Key)
            {
                case "st": hp += (int)(s.Value * ST_BONUS); break;
                case "en": hp += (int)(s.Value * EN_BONUS); break;
            }
        }

        hp = (int)(hp * Math.Pow(HP_EXP_BASE, this.Level));

        return hp;
    }

    /// <summary>
    /// Inventory
    /// </summary>
    public List<InventoryItem> Inventory { get; set; }

    /// <summary>
    /// ComputeScore (compute)
    /// </summary>
    /// <returns>Tuple: Score, Score Summary Text</returns>
    public (BigInteger grandTotal, List<string> display) ComputeScore()
    {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
        int score = 0;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        BigInteger grand = 0;
        var l = new List<string>
        {
            $"Player: {PlayerName}"
        };

        score = this.Level * SCORE_PER_LEVEL;
        grand += score;

        l.Add($"Level: {Level} -> {score}");

        score = (int)(this.Experience * SCORE_PER_EXPERIENCE);
        grand += score;
        l.Add($"Experience: {Experience} -> {score}");

        score = 0;
        foreach (var item in Inventory)
        {
            switch (item.Id)
            {
                case 40: // Potion
                    score += item.Quantity * SCORE_PER_POTION;
                    break;
                case 41: // Scroll
                    score += item.Quantity * SCORE_PER_SCROLL;
                    break;
                case 42: // Gold
                    score += item.Quantity * SCORE_PER_GOLD;
                    break;
                case 43: // Jewel
                    score += item.Quantity * SCORE_PER_JEWEL;
                    break;
            }
        }

        grand += score;
        l.Add($"Inventory Items: {Inventory.Count} -> {score}");

        score = this.Deaths * SCORE_PER_DEATH;
        grand += score;
        l.Add($"Deaths: {Deaths} -> {score}");

        l.Add(new string('=', 30));

        l.Add($"Grand Total ComputeScore: {grand}");

        return (grand, l);
    }

    /// <summary>
    /// Factory: Create Hero from SaveGame
    /// </summary>
    /// <param name="saveGame">SaveGameRoot</param>
    /// <returns>Hero</returns>
    public static Hero FromSaveGame(SaveGameRoot saveGame)
    {
        Hero hero = new()
        {
            PlayerName = saveGame.PlayerName,
            Damage = 0,
            Deaths = saveGame.Deaths,
            Depth = saveGame.Depth,
            Experience = saveGame.Experience,
            Inventory = saveGame.Inventory,
            Level = saveGame.Level,
            Stats = saveGame.Stats,
            X = -1,
            Y = -1,
        };
        return hero;
    }

    /// <summary>
    /// Hero is valid
    /// <para>Does not validate location</para>
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(this.PlayerName) &&
            this.Stats != null && this.Stats.Count > 0 &&
            this.Inventory != null && this.Inventory.Count > 0 &&
            this.Level > 0 &&
            this.Depth > 0 &&
            this.Experience > 0 &&
            this.ComputeHitPoints() > 0
            ;
    }

    /// <summary>
    /// Debug String
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{PlayerName} Lvl:{Level} XP:{Experience}, HP: {ComputeHitPoints()}";
    }

}
