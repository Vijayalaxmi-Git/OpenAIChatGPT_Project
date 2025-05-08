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
    /// Extract features from unstructured data to generate structured tables
    /// </summary>
    public class TableSummarizing : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciText;
        private readonly string _prompt = "A table summarizing, use English:\\nI am a lively and lovely little girl. I have a pair of big watery eyes, curved eyebrows like the moon, and a pink cherry mouth under the high nose.\\n";

        public TableSummarizing(OpenAISetting openAISetting)
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
