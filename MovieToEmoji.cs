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
    /// Text to emoticon, encoding text into emoticon service
    /// </summary>
    public class MovieToEmoji : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciText;
        private readonly string _prompt = "Convert text to emoticon. \nI am very angry now：";
        private readonly string _endToken = "\n";


        public MovieToEmoji(OpenAISetting openAISetting)
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
                temperature: 0.8,
                top_p: 1,
                presencePenalty: 0,
                frequencyPenalty: 0,
                stopSequences: new string[] { _endToken }
                ));
            AnsiConsole.Markup(result.ToString());
            return 1;
        }
    }
}
