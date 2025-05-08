using OpenAI_API.Completions;
using OpenAI_API.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAIChatGPTSample
{
    /// <summary>
    /// Generate a program command in one sentence. Currently, it supports more operating system commands.
    /// </summary>
    public class TextToCommand : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciText;
        private readonly string _prompt = "Convert this text to a programmatic command:\\\\n\\\\nExample: Ask Constance if we need some bread\\\\nOutput: send-msg `find constance` Do we need some bread?\\\\n\\\\nAdd a scheduled task for automatic shutdown";

        public TextToCommand(OpenAISetting openAISetting)
        {
            _openAISetting = openAISetting;
        }

        public async Task<int> Run()
        {
            var api = new OpenAI_API.OpenAIAPI(_openAISetting.ApiKey);
            var result = await api.Completions.CreateCompletionAsync(
                new CompletionRequest(_prompt,
                model: CHATGPT_MODEL,
                max_tokens: 1000,
                temperature: 0,
                top_p: 1,
                presencePenalty: 0,
                frequencyPenalty: 0.2
                ));
            AnsiConsole.Markup(result.ToString());
            return 1;
        }
    }
}
