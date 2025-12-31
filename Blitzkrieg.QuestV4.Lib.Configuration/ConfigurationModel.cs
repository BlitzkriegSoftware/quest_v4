using Blitzkrieg.QuestV4.Lib.Configuration;
using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Configuration
{
    // QuestConfigurationRoot myDeserializedClass = JsonConvert.DeserializeObject<QuestConfigurationRoot>(myJsonResponse);
    public class MapInfo
    {
        [JsonProperty(nameof(Rows))]
        public int Rows { get; set; }

        [JsonProperty(nameof(Cols))]
        public int Cols { get; set; }

        [JsonProperty(nameof(MinLevel))]
        public int MinLevel { get; set; }

        [JsonProperty(nameof(MaxLevel))]
        public int MaxLevel { get; set; }

        [JsonProperty(nameof(Folder))]
        public string Folder { get; set; }

        [JsonProperty(nameof(FileExt))]
        public string FileExt { get; set; }
    }

    public class Monster
    {
        [JsonProperty(nameof(Symbol))]
        public string Symbol { get; set; }

        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(MinLevel))]
        public int MinLevel { get; set; }

        [JsonProperty(nameof(MaxLevel))]
        public int MaxLevel { get; set; }

        [JsonProperty(nameof(Attack))]
        public string Attack { get; set; }

        [JsonProperty(nameof(Defense))]
        public int Defense { get; set; }

        [JsonProperty(nameof(Movement))]
        public int Movement { get; set; }

        [JsonProperty(nameof(Hits))]
        public int Hits { get; set; }

        [JsonProperty(nameof(Special))]
        public string Special { get; set; }

        [JsonProperty(nameof(LevelMod))]
        public double LevelMod { get; set; }
    }

    public class Potion
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Effect))]
        public string Effect { get; set; }

        [JsonProperty(nameof(Impact))]
        public int Impact { get; set; }

        [JsonProperty(nameof(Radius))]
        public int Radius { get; set; }
    }


    public class Scroll
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Effect))]
        public string Effect { get; set; }

        [JsonProperty(nameof(Impact))]
        public int Impact { get; set; }

        [JsonProperty(nameof(Radius))]
        public int Radius { get; set; }
    }

    public class Stat
    {
        [JsonProperty(nameof(Id))]
        public string Id { get; set; }

        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Min))]
        public int Min { get; set; }

        [JsonProperty(nameof(Max))]
        public int Max { get; set; }
    }

    public class Thing
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Unicode))]
        public string Unicode { get; set; }

        [JsonProperty(nameof(Kind))]
        public int Kind { get; set; }
    }

    public class ThingKind
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Value))]
        public int Value { get; set; }

        [JsonProperty(nameof(Note))]
        public string Note { get; set; }

        [JsonProperty(nameof(Kind))]
        public int Kind { get; set; }
    }



    public class QuestConfigurationRoot
    {
        [JsonProperty(nameof(MapInfo))]
        public MapInfo MapInfo { get; set; }

        [JsonProperty(nameof(ThingKinds))]
        public List<ThingKind> ThingKinds { get; } = [];

        [JsonProperty(nameof(Things))]
        public List<Thing> Things { get; } = [];

        [JsonProperty(nameof(Scrolls))]
        public List<Scroll> Scrolls { get; } = [];

        [JsonProperty(nameof(Potions))]
        public List<Potion> Potions { get; } = [];

        [JsonProperty(nameof(Monsters))]
        public List<Monster> Monsters { get; } = [];

        [JsonProperty(nameof(Stats))]
        public List<Stat> Stats { get; } = [];
    }

}