﻿using OpenAI_API.Completions;
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
    /// Generate SQL statements based on the table information in the context
    /// </summary>
    public class SQLTranslate : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciCode;
        private readonly string _prompt = "### Mysql SQL tables, Table Information:\\\n#\\\n# Employee(id, name, department_id)\\\n# Department(id, name, address)\\\n# Salary_Payments(id, employee_id, amount, date)\\\n#\\\n### Syntax\\\n CREATE";

        public SQLTranslate(OpenAISetting openAISetting)
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
                frequencyPenalty: 0
                ));
            AnsiConsole.Markup(result.ToString());
            return 1;
        }
    }
}
