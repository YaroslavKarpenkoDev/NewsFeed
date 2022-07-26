using System;
using Newtonsoft.Json;

namespace NewsFeed.Models
{
    public class ArticleModel
    {
        [JsonProperty("source")]
        public SourceModel Source { get; set; }
        
        [JsonProperty("author")]
        public string Author { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("urlToImage")]
        public string UrlToImage { get; set; }
        
        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }
        
        [JsonProperty("content")]
        public string Content { get; set; }

        
        [JsonIgnore] 
        public string StringDate => PublishedAt.ToString("dd MMM yyyy hh:mm");
    }
}