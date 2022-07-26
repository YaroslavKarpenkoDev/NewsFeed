using System.Collections.Generic;
using Newtonsoft.Json;

namespace NewsFeed.Models
{
    public class NewsModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }
        
        [JsonProperty("articles")]
        public List<ArticleModel> Articles { get; set; }
    }
}