using Newtonsoft.Json;

namespace L_AI.TextGeneration.Providers.LlamaCpp.Models
{
    internal class LlamaCppTokenCountRequest
    {
        [JsonProperty("prompt")]
        public string Prompt { get; set; }
    }
}
