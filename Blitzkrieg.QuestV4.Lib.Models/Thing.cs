using Newtonsoft.Json;

namespace Blitzkrieg.QuestV4.Lib.Models
{


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

        /// <summary>
        /// Debug string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Id}: {Name} U+{Unicode} Kind={Kind}";
        }

    }
}
