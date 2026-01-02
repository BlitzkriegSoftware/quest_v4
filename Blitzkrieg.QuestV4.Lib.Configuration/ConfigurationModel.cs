using System.Numerics;

using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Configuration
{
    // QuestConfigurationRoot myDeserializedClass = JsonConvert.DeserializeObject<QuestConfigurationRoot>(myJsonResponse);

    /// <summary>
    /// Map information for the quest
    /// </summary>
    public class MapInfo
    {
        /// <summary>
        /// Map rows
        /// </summary>
        [JsonProperty(nameof(Rows))]
        public int Rows { get; set; }

        /// <summary>
        /// Map columns
        /// </summary>
        [JsonProperty(nameof(Cols))]
        public int Cols { get; set; }

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
    }

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
    /// <summary>
    /// (base) Stat information
    /// </summary>
    public class Stat
    {
        /// <summary>
        /// Points to give initially to distribute among stats
        /// </summary>
        public const int INITIAL_STAT_POINTS = 5;

        /// <summary>
        /// Short Id
        /// </summary>
        [JsonProperty(nameof(Id))]
        public string Id { get; set; }

        /// <summary>
        /// Long name
        /// </summary>
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }
        /// <summary>
        /// Minimum value
        /// </summary>
        [JsonProperty(nameof(Min))]
        public int Min { get; set; }
        /// <summary>
        /// Maximum value
        /// </summary>
        [JsonProperty(nameof(Max))]
        public int Max { get; set; }
    }

    /// <summary>
    /// Thing
    /// </summary>
    public class Thing
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        /// <summary>
        /// Rendered Unicode character
        /// </summary>
        [JsonProperty(nameof(Unicode))]
        public string Unicode { get; set; }

        /// <summary>
        /// Kind code
        /// </summary>
        [JsonProperty(nameof(Kind))]
        public int Kind { get; set; }
    }

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

    /// <summary>
    /// ROOT Quest Configuration Model
    /// </summary>
    public class QuestConfigurationRoot
    {
        /// <summary>
        /// (sic)
        /// </summary>
        [JsonProperty(nameof(MapInfo))]
        public MapInfo MapInfo { get; set; }

        /// <summary>
        /// (sic)
        /// </summary>
        [JsonProperty(nameof(SaveGameInfo))]
        public SaveGameInfo SaveGameInfo { get; set; }

        /// <summary>
        /// (sic)
        /// </summary>
        [JsonProperty(nameof(Things))]
        public List<Thing> Things { get; } = [];
        /// <summary>
        /// (sic)
        /// </summary>
        [JsonProperty(nameof(Scrolls))]
        public List<Scroll> Scrolls { get; } = [];
        /// <summary>
        /// (sic)
        /// </summary>
        [JsonProperty(nameof(Potions))]
        public List<Potion> Potions { get; } = [];
        /// <summary>
        /// (sic)
        /// </summary>
        [JsonProperty(nameof(Monsters))]
        public List<Monster> Monsters { get; } = [];
        /// <summary>
        /// (sic)
        /// </summary>
        [JsonProperty(nameof(Stats))]
        public List<Stat> Stats { get; } = [];
    }

    public class InventoryItem
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Name))]
        public string Name { get; set; }
        [JsonProperty(nameof(Quantity))]
        public int Quantity { get; set; }
    }

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
                && File.Exists(MapFileName)
                && Stats != null
                && Inventory != null;
        }
    }

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

}