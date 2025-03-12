using L_AI.Options;
using L_AI.TextGeneration.WebApi;
using System.Threading;
using System.Threading.Tasks;

namespace L_AI.TextGeneration.Providers
{
    internal interface IGenerationProvider
    {
        Task<ApiResult<string>> GenerateRequest(GenerationRequestModel parameters, CancellationToken cancellationToken, GeneralOptions optionsOverride = null);
        Task<ApiResult<bool>> CancelGeneration(CancellationToken cancellationToken = default);
        Task<ApiResult<int>> CalculateTokens(string prompt, CancellationToken cancellationToken = default);
        Task<ApiResult<int>> GetMaxLength();
        Task<ApiResult<string>> GetModel();
    }
}
