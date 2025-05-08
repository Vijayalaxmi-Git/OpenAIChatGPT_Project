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
    /// Generate Stripe international payment API in one sentence
    /// </summary>
    public class StripeCharge : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciCode;
        private readonly string _prompt = "\\\"\\\"\\\"\\nUtil exposes the following:\\\\n\\\\nutil.stripe() -> authenticates & returns the stripe module; usable as stripe.Charge.create etc\\n\\\"\\\"\\\"\nimport util\n\\\"\\\"\\\"\nUse a credit card 500000000 to create a Stripe token\n\\\"\\\"\\\"";

        public StripeCharge(OpenAISetting openAISetting)
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
                temperature: 0.3,
                top_p: 1,
                presencePenalty: 0,
                frequencyPenalty: 0
                ));
            AnsiConsole.Markup(result.ToString());
            return 1;
        }
    }
}
