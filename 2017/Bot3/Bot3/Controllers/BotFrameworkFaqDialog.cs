using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QnAMakerDialog;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace Bot3.Controllers
{
    [Serializable]
    [QnAMakerService("5fcfe2c94c7c4cafb99a78479baa5a36", "5e6464e4-09c7-4cd9-9f47-b5afee440073")]
    public class BotFrameworkFaqDialog : QnAMakerDialog<object>
    {
        public override async Task NoMatchHandler(IDialogContext context, string originalQueryText)
        {
            await context.PostAsync($"Sorry, I couldn't find an answer for '{originalQueryText}'.");
            context.Wait(MessageReceived);
        }

        [QnAMakerResponseHandler(50)]
        public async Task LowScoreHandler(IDialogContext context, string originalQueryText, QnAMakerResult result)
        {
            await context.PostAsync($"I found an answer that might help...{result.Answer}.");
            context.Wait(MessageReceived);
        }

    }
}