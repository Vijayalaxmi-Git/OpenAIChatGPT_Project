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
    /// Categorize a piece of information
    /// </summary>
    public class Classification : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciText;
        private readonly string _prompt = "It seems to be singing a beautiful song.:";


        public Classification(OpenAISetting openAISetting)
        {
            _openAISetting = openAISetting;
        }

        public async Task<int> Run()
        {
            var api = new OpenAI_API.OpenAIAPI(_openAISetting.ApiKey);
            var result = await api.Completions.CreateCompletionAsync(
                new CompletionRequest(_prompt,
                model: CHATGPT_MODEL,
                max_tokens: 100,
                temperature: 0,
                top_p: 1,
                presencePenalty: 0,
                frequencyPenalty: 0
                ));
            AnsiConsole.Markup(result.ToString());
            return 1;
        }
    }
}
