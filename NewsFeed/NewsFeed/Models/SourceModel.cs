using Newtonsoft.Json;

namespace NewsFeed.Models
{
    public class SourceModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}