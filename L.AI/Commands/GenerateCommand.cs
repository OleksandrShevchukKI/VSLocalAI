using Microsoft.VisualStudio.Shell;
using LocalLlmAutocomplete.CodeGeneration;
using Community.VisualStudio.Toolkit;
using System.Threading.Tasks;

namespace L_AI.Commands
{
    [Command("620889b3-cd41-43ff-8786-020fd2c48b28", 4131)]
    internal sealed class GenerateCommand : BaseCommand<GenerateCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await GenerationHelper.StartNewAndShowAsync();
        }
    }
}
