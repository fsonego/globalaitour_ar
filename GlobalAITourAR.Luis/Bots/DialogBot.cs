// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GlobalAITourAR.Luis.Models;
using GlobalAITourAR.Luis.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace GlobalAITourAR.Luis
{
    // This IBot implementation can run any type of Dialog. The use of type parameterization is to allows multiple different bots
    // to be run at different endpoints within the same project. This can be achieved by defining distinct Controller types
    // each with dependency on distinct IBot types, this way ASP Dependency Injection can glue everything together without ambiguity.
    // The ConversationState is used by the Dialog system. The UserState isn't, however, it might have been used in a Dialog implementation,
    // and the requirement is that all BotState objects are saved at the end of a turn.
    public class DialogBot<T> : ActivityHandler where T : Dialog
    {
        protected readonly BotState ConversationState;
        protected readonly Dialog Dialog;
        protected readonly ILogger Logger;
        protected readonly BotState UserState;
        private IBotServices _botServices;
        
        public DialogBot(ConversationState conversationState, UserState userState, T dialog, ILogger<DialogBot<T>> logger, IBotServices botServices)
        {
            ConversationState = conversationState;
            UserState = userState;
            Dialog = dialog;
            Logger = logger;
            _botServices = botServices;
        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.OnTurnAsync(turnContext, cancellationToken);

            // Save any state changes that might have occured during the turn.
            await ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            await UserState.SaveChangesAsync(turnContext, false, cancellationToken);
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Running dialog with Message Activity.");

            var conversationStateAccessors = ConversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            var conversationData = await conversationStateAccessors.GetAsync(turnContext, () => new ConversationData());

            if (conversationData.OnDialog != string.Empty)
            {
                // Run the Dialog with the new message Activity.
                await Dialog.RunAsync(turnContext, ConversationState.CreateProperty<DialogState>(nameof(DialogState)), cancellationToken);
            }
            else {
                var recognizerResult = await _botServices.Dispatch.RecognizeAsync<LuisReconizedModel>(turnContext, cancellationToken);

                //// Top intent tell us which cognitive service to use.
                var topIntent = recognizerResult.TopIntent().intent.ToString();

                //// Next, we call the dispatcher with the top intent.
                await DispatchToTopIntentAsync(turnContext, topIntent, recognizerResult, cancellationToken);
            }
        }

        private async Task DispatchToTopIntentAsync(ITurnContext<IMessageActivity> turnContext, string intent, LuisReconizedModel recognizerResult, CancellationToken cancellationToken)
        {
            switch (intent)
            {
                case "searchDestinations":

                    var destinations = new Destinations();
                    var destinationType = recognizerResult.Entities.destinationType[0][0];
                    var _listDestinations= destinations.GetDestination(destinationType);
                    var messagge = "Estos son los destinos de " + destinationType + " disponibles:\r";

                    foreach (var d in _listDestinations) { messagge += "- " + d + " \r"; }

                    var standardCard = new StandardCard();
                    standardCard.Title = "Destinos disponibles";                    
                    standardCard.Description = messagge;

                    var response = ((Activity)turnContext.Activity).CreateReply();
                    var reply = standardCard.GetCard();

                    var result = new Attachment()
                    {
                        ContentType = "application/vnd.microsoft.card.adaptive",
                        Content = reply
                    };

                    response.Attachments = new List<Attachment>() { result };
                    await turnContext.SendActivityAsync(response, cancellationToken);

                    break;

                case "purchaseTicket":


                    var destination = ParserLuisHelper.GetDestination(recognizerResult);
                    var ticketType = ParserLuisHelper.GetTicketType(recognizerResult);
                    var payment = ParserLuisHelper.GetPaymentMethod(recognizerResult); ;
                    var dates = ParserLuisHelper.GetDates(recognizerResult); ;

                    var conversationStateAccessors = ConversationState.CreateProperty<ConversationData>(nameof(ConversationData));
                    var conversationData = await conversationStateAccessors.GetAsync(turnContext, () => new ConversationData());
                    conversationData.OnDialog = "OtherDialog";
                    conversationData.Destination = destination;
                    conversationData.Payment = payment;
                    conversationData.DateFrom = dates.Start.ToString();
                    conversationData.DateUp = dates.End.ToString();
                    conversationData.TicketType = ticketType;

                    await Dialog.RunAsync(turnContext, ConversationState.CreateProperty<DialogState>(nameof(DialogState)), cancellationToken);

                    break;

                case "getGreetings":

                    await turnContext.SendActivityAsync((new Grettings()).GetGreetting());
                    break;

                case "getJokes":
                    
                    await turnContext.SendActivityAsync((new Jokes()).GetJokes());
                    break;                    

                case "getInsults":
                    
                    await turnContext.SendActivityAsync((new Insults()).GetInsults());
                    break;
                    

                case "getTicketRefund":          
                    await turnContext.SendActivityAsync("Veo que me estas solicitando un devolución. En este momentos no tengo implementada esa funcionalidad.");
                    break;

                case "getTicketInformation":
                    await turnContext.SendActivityAsync("Veo que me estas solicitando información sobre un viaje. En este momentos no tengo implementada esa funcionalidad.");
                    break;

                default:
                    await turnContext.SendActivityAsync("No he logrado comprender lo que me quieres decir. Intenta nuevamente.");
                    break;


            }
        }

    }
}
