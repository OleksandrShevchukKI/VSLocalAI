using Newtonsoft.Json;
using System.Collections.Generic;

namespace L_AI.TextGeneration.Providers.LlamaCpp.Models
{
    internal class LlamaCppGenerationResponse
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        public class Result
        {
            [JsonProperty("text")]
            public string Text { get; set; }
        }
    }
}
