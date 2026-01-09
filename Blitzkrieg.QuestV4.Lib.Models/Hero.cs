using System.Numerics;

namespace Blitzkrieg.QuestV4.Lib.Models;

/// <summary>
/// Hero
/// </summary>
public class Hero
{
    #region "Constants, Fields, Properties"
    private const double HP_EXP_BASE = 1.1;
    private const double MANA_EXP_BASE = 1.4;
    private const double ST_BONUS = 1.1;
    private const double EN_BONUS = 1.3;
    private const int MANA_BASE = 100;
    private const int SCORE_PER_LEVEL = 1000;
    private const int SCORE_PER_EXPERIENCE = 10;
    private const int SCORE_PER_POTION = 2;
    private const int SCORE_PER_SCROLL = 3;
    private const int SCORE_PER_GOLD = 1;
    private const int SCORE_PER_JEWEL = 9;
    private const int SCORE_PER_DEATH = -500;
    public const int STAT_INITIAL_VALUE = 4;
    public const string NOTHING_HAPPENS = "Nothing happens";
    public readonly string[] STAT_LIST = ["st", "en", "iq"];
    private readonly int[] EventValidKinds = [40, 41];
    private readonly InventoryItem[] INVENTORY_LIST = [
        new() { Id =  40, Name = "heal", Quantity = 3},
        new() { Id =  40, Name = "mana", Quantity = 3},
        new() { Id =  41, Name = "candle", Quantity = 5},
        new() { Id =  41, Name = "find-stair", Quantity = 2},
        new() { Id =  42, Name = "gold", Quantity = 10},
        new() { Id =  43, Name = "jewel", Quantity = 1},
    ];
    private List<EventItem> _events;
    public List<EventItem> Events
    {
        get
        {
            if (_events == null) _events = new List<EventItem>();
            return _events;
        }
    }
    #endregion

    #region "CTOR"
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

    #endregion

    #region "Factories"

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

    #endregion

    #region "Properties"
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
    /// Manu Used
    /// </summary>
    public int ManaUsed { get; set; } = 0;

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
    /// Get value for stat
    /// </summary>
    /// <param name="key">Stat</param>
    /// <returns>Value</returns>
    public int StatValue(string key)
    {
        return Stats[key];
    }

    /// <summary>
    /// Inventory
    /// </summary>
    public List<InventoryItem> Inventory { get; set; }

    #endregion

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
    /// Compute Mana
    /// </summary>
    /// <returns>Computed Mana</returns>
    public int ComputeMana()
    {
        int mana = MANA_BASE;
        var iq = this.Stats.FirstOrDefault(i => i.Key == "iq");
        if (iq.Value > 0)
        {
            mana += mana + (int)(iq.Value * Math.Pow(MANA_EXP_BASE, this.Level));
        }
        return mana;
    }

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
    /// Bump a player stat up or down
    /// </summary>
    /// <param name="config">QuestConfigurationRoot</param>
    /// <param name="name">stat name</param>
    /// <param name="bump">increment (+) or decrement (-)</param>
    public void BumpStat(QuestConfigurationRoot config, string name, int bump = 1)
    {
        var stat = this.Stats.FirstOrDefault(i => i.Key == name);
        var sdef = config.Stats.FirstOrDefault(i => i.Id == name);
        if (stat.Value > 0 && sdef != null)
        {
            if (stat.Value < sdef.Max)
            {
                this.Stats[name] = this.Stats[name] + bump;
            }
        }
    }

    /// <summary>
    /// Illuminate 
    /// </summary>
    /// <param name="row">(sic)</param>
    /// <param name="col">(sic)</param>
    /// <param name="radius">(sic)</param>
    /// <param name="searchThing">If null all</param>
    /// <returns>Message</returns>
    public string Illuminate(int row, int col, int radius = 1, int[] searchThing = null)
    {
        string msg = NOTHING_HAPPENS;


        return msg;
    }

    /// <summary>
    /// Attack
    /// </summary>
    /// <param name="row">(sic)</param>
    /// <param name="col">(sic)</param>
    /// <param name="impact">(sic)</param>
    /// <returns>Message</returns>
    public string Attack(int row, int col, int impact)
    {
        string msg = NOTHING_HAPPENS;


        return msg;
    }

    /// <summary>
    /// Heal
    /// </summary>
    /// <param name="healByPercent">heal by percent (as double)</param>
    /// <returns>Message</returns>
    public string Heal(double healByPercent)
    {
        string msg = NOTHING_HAPPENS;
        if (this.Damage > 0)
        {
            int hp = this.ComputeHitPoints();
            int healBy = (int)Math.Round(hp * healByPercent, 0) + 1;
            this.Damage -= healBy;
            if (this.Damage < 0) this.Damage = 0;
            msg = $"You are healed by {healByPercent} for {healBy} points leaving damage of {this.Damage}";
        }
        return msg;
    }

    /// <summary>
    /// Mana
    /// </summary>
    /// <param name="manalByPercent">mana by percent (as double)</param>
    /// <returns>Message</returns>
    public string Mana(double manalByPercent)
    {
        string msg = NOTHING_HAPPENS;
        if (this.ManaUsed > 0)
        {
            int mana = this.ComputeMana();
            int manaBy = (int)Math.Round(mana * manalByPercent, 0) + 1;
            this.ManaUsed -= manaBy;
            if (this.ManaUsed < 0) this.ManaUsed = 0;
            msg = $"Your mana is refreshed by {manalByPercent} for {manaBy} units leaving mana used of {this.ManaUsed}";
        }
        return msg;
    }

    /// <summary>
    /// Add update event list
    /// </summary>
    /// <param name="kind">EventValidKinds</param>
    /// <param name="name">(sic)</param>
    /// <param name="impact">Duration</param>
    /// <param name="radius">(optional) radius</param>
    public void AddUpdateEvent(int kind, string name, int impact, int radius = 0)
    {
        if (!Array.Exists(EventValidKinds, i => i.Equals(kind))) throw new ArgumentOutOfRangeException(nameof(kind));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (impact < 0) throw new ArgumentOutOfRangeException(nameof(impact));

        EventItem ei = new EventItem(kind, name, impact, radius);
        var sei = this.Events.Where(i => i.Name == name && i.Kind == kind).FirstOrDefault();
        if (sei != null)
        {
            sei.DurationRemaining += impact;
        }
        else
        {
            this.Events.Add(ei);
        }
    }

    /// <summary>
    /// Do one turns worth of events
    /// </summary>
    public void DoEvents()
    {
        if (this.Events.Count <= 0) return;

        foreach (var e in this.Events)
        {
            if (e.DurationRemaining <= 0) continue;

            switch (e.Kind)
            {
                case 40: // potion

                    break;

                case 41: // scroll

                    break;
            }
            e.DurationRemaining--;
        }

        this.Events.RemoveAll(i => i.DurationRemaining <= 0);

    }

    /// <summary>
    /// Use Scroll
    /// </summary>
    /// <param name="config">QuestConfigurationRoot</param>
    /// <param name="name">Scroll name</param>
    /// <returns>Message</returns>
    public string UseScroll(QuestConfigurationRoot config, string name, bool addEvent = true)
    {
        string result = NOTHING_HAPPENS;
        var inventoryItem = this.Inventory.FirstOrDefault(i => i.Id == 41 && i.Quantity > 0 && i.Name == name);
        if (inventoryItem != null)
        {
            var scroll = config.Scrolls.FirstOrDefault(i => i.Name == name);
            if (scroll != null)
            {
                inventoryItem.Quantity--;
                switch (name)
                {
                    case "candle":
                        result = Illuminate(this.X, this.Y, scroll.Radius);
                        if (addEvent) AddUpdateEvent(41, name, scroll.Impact, scroll.Radius);
                        break;
                    case "torch":
                        result = Illuminate(this.X, this.Y, scroll.Radius);
                        if (addEvent) AddUpdateEvent(41, name, scroll.Impact, scroll.Radius);
                        break;
                    case "majik-map":
                        result = Illuminate(this.X, this.Y, scroll.Radius);
                        if (addEvent) AddUpdateEvent(41, name, scroll.Impact, scroll.Radius);
                        break;
                    case "heal":
                        result = Heal(0.1);
                        if (addEvent) AddUpdateEvent(41, name, scroll.Impact, 0);
                        break;
                    case "heal-all":
                        result = Heal(1.0);
                        if (addEvent) AddUpdateEvent(41, name, scroll.Impact, 0);
                        break;
                    case "mana":
                        result = Mana(0.1);
                        if (addEvent) AddUpdateEvent(41, name, scroll.Impact, 0);
                        break;
                    case "mana-all":
                        result = Mana(1.0);
                        if (addEvent) AddUpdateEvent(41, name, scroll.Impact, 0);
                        break;
                    case "find-gold":
                        result = Illuminate(this.X, this.Y, scroll.Radius, [42, 43]);
                        break;
                    case "find-monster":
                        result = Illuminate(this.X, this.Y, scroll.Radius, [42, 43]);
                        break;
                    case "find-majik":
                        result = Illuminate(this.X, this.Y, scroll.Radius, [40, 41]);
                        break;
                    case "find-trap":
                        result = Illuminate(this.X, this.Y, scroll.Radius, [20]);
                        break;
                    case "find-stair":
                        result = Illuminate(this.X, this.Y, scroll.Radius, [30]);
                        break;
                    case "arrow":
                        result = Attack(this.X, this.Y, scroll.Impact);
                        if (addEvent) AddUpdateEvent(41, name, scroll.Impact, 0);
                        break;
                    case "bomb":
                        result = Attack(this.X, this.Y, scroll.Impact);
                        break;
                    case "fireball":
                        result = Attack(this.X, this.Y, scroll.Impact);
                        break;
                    case "zap":
                        result = Attack(this.X, this.Y, scroll.Impact);
                        if (addEvent) AddUpdateEvent(41, name, scroll.Impact, 0);
                        break;
                    case "big-zap":
                        result = Attack(this.X, this.Y, scroll.Impact);
                        break;
                    case "nuke":
                        result = Attack(this.X, this.Y, scroll.Impact);
                        break;
                    case "teleport":
                        result = Attack(this.X, this.Y, scroll.Impact);
                        break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Drink Potion
    /// </summary>
    /// <param name="config">QuestConfigurationRoot</param>
    /// <param name="name">Potion</param>
    /// <returns>Message</returns>
    public string DrinkPotion(QuestConfigurationRoot config, string name)
    {
        string result = NOTHING_HAPPENS;
        var inventoryItem = this.Inventory.FirstOrDefault(i => i.Id == 40 && i.Quantity > 0 && i.Name == name);
        if (inventoryItem != null)
        {
            var potion = config.Potions.FirstOrDefault(i => i.Name == name);
            if (potion != null)
            {
                inventoryItem.Quantity--;

                switch (name)
                {
                    case "heal":
                        result = "You feel rejuvenated!";
                        this.Damage -= potion.Impact;
                        if (this.Damage < 0) this.Damage = 0;
                        break;
                    case "mana":
                        result = "Your magical energies are restored!";
                        this.ManaUsed -= potion.Impact;
                        if (this.ManaUsed < 0) this.ManaUsed = 0;
                        break;
                    case "iq":
                        result = "You feel smarter";
                        BumpStat(config, "iq");
                        break;
                    case "en":
                        result = "You feel tougher";
                        BumpStat(config, "en");
                        break;
                    case "st":
                        result = "Strength flows into you";
                        BumpStat(config, "st");
                        break;
                }
            }
        }
        return result;
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
    /// Geo Location is OK
    /// </summary>
    /// <returns>True if so</returns>
    public bool GeoOk()
    {
        return this.X >= 0 && this.Y >= 0 && this.Level > 0;
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
