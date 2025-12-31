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
    /// Thing Kinds
    /// </summary>
    public class ThingKind
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        [JsonProperty(nameof(Value))]
        public int Value { get; set; }
        /// <summary>
        /// Note
        /// </summary>
        [JsonProperty(nameof(Note))]
        public string Note { get; set; }
        /// <summary>
        /// Kind
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
        [JsonProperty(nameof(ThingKinds))]
        public List<ThingKind> ThingKinds { get; } = [];
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

}