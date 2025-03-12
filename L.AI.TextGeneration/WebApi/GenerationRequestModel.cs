namespace L_AI.TextGeneration.WebApi
{
    public class GenerationRequestModel
    {
        public int ContextLength { get; set; }
        public string[] Stop { get; set; }
        public string Prompt { get; set; }
    }
}
