using Spectre.Console.Cli;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenAIChatGPTSample
{
    /// <summary>
    /// Among the 49 modes of openapi, it supports a variety of interesting ways to play, 
    /// such as paper creation, code generation, SQL generation, code interpretation, program code translation, etc. Let's play together
    /// </summary>
    internal class OpenAICommand : Command<OpenAICommand.Settings>
    {
        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            IGPTRuner runer = null;
            OpenAISetting openAISetting = new OpenAISetting() { ApiKey = settings.ApiKey, Organization = settings.Organization };
            switch (settings.Mode.ToLowerInvariant())
            {
                case "qna":
                    runer= new QnA(openAISetting);
                    break;
                case "grammarcorrection":
                    runer = new GrammarCorrection(openAISetting);
                    break;
                case "summarize":
                    runer = new Summarize(openAISetting);
                    break;
                case "openapicode":
                    runer = new OpenAPICode(openAISetting);
                    break;
                case "text2command":
                    runer = new TextToCommand(openAISetting);
                    break;
                case "translate2other":
                    runer = new Translate2Other(openAISetting);
                    break;
                case "stripecharge":
                    runer = new StripeCharge(openAISetting);
                    break;
                case "sqltranslate":
                    runer = new SQLTranslate(openAISetting);
                    break;
                case "tablesummarizing":
                    runer = new TableSummarizing(openAISetting);
                    break;
                case "classification":
                    runer = new Classification(openAISetting);
                    break;
                case "movietoemoji":
                    runer = new MovieToEmoji(openAISetting);
                    break;

            }
            return runer.Run().Result;

        }

        public sealed class Settings : CommandSettings
        {
            [Description("mode")]
            [CommandArgument(0, "[mode]")]
            public string? Mode { get; init; }

            [CommandOption("-k|--apikey")]
            public string? ApiKey { get; init; }

            [CommandOption("-o|--organization")]
            public string? Organization { get; init; }
            
        }
    }
}