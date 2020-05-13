// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;

namespace GlobalAITourAR.Luis
{
    public class OtherLevelDialog : ComponentDialog
    {
        // Define a "done" response for the company selection prompt.
        private const string DoneOption = "done";

        // Define value names for values tracked inside the dialogs.
        private const string UserInfo = "value-userInfo";
        private readonly ConversationState _conversationState;


        public OtherLevelDialog(ConversationState conversationState)
            : base(nameof(OtherLevelDialog))
        {
            _conversationState = conversationState;

            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new TextPrompt(nameof(TextPrompt)));

            //AddDialog(new ReviewSelectionDialog());

            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                NameStepAsync,
                PassStepAsync,
                PaymentMethodStepAsync,
                EndStepAsync,
            }));

            InitialDialogId = nameof(WaterfallDialog);
        }

        private static async Task<DialogTurnResult> NameStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            // Create an object in which to collect the user's information within the dialog.
            stepContext.Values[UserInfo] = new UserProfile();

            var promptOptions = new PromptOptions { Prompt = MessageFactory.Text("Ingresa tu nombre completo, por favor.") };

            // Ask the user to enter their name.
            return await stepContext.PromptAsync(nameof(TextPrompt), promptOptions, cancellationToken);
            
        }

        private async Task<DialogTurnResult> PassStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {

            // Set the user's name to what they entered in response to the name prompt.
            var userProfile = (UserProfile)stepContext.Values[UserInfo];
            userProfile.Name = (string)stepContext.Result;

            var promptOptions = new PromptOptions { Prompt = MessageFactory.Text("Ingresa tu número de DNI.") };

            //// Ask the user to enter their age.
            return await stepContext.PromptAsync(nameof(TextPrompt), promptOptions, cancellationToken);
        }


        private async Task<DialogTurnResult> PaymentMethodStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {

            var userProfile = (UserProfile)stepContext.Values[UserInfo];
            userProfile.DNI = stepContext.Result.ToString();

            var conversationStateAccessors = _conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            var conversationData = await conversationStateAccessors.GetAsync(stepContext.Context, () => new ConversationData());

            if (conversationData.Payment == string.Empty)
            {
                var promptOptions = new PromptOptions { Prompt = MessageFactory.Text("Ingresa la forma de pago") };
                userProfile.RequestPaymentFromWorkflow = true;
                return await stepContext.PromptAsync(nameof(TextPrompt), promptOptions, cancellationToken);
            }
            else {

                return await stepContext.NextAsync(new List<string>(), cancellationToken);
            }
            

        }


        private async Task<DialogTurnResult> EndStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            
            var userProfile = (UserProfile)stepContext.Values[UserInfo];
            var conversationStateAccessors = _conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            var conversationData = await conversationStateAccessors.GetAsync(stepContext.Context, () => new ConversationData());
            
            if (userProfile.RequestPaymentFromWorkflow) { 
                conversationData.Payment = (string)stepContext.Result;
            }

            // Thank them for participating.
            var nombre = userProfile.Name;
            var dateFrom = System.DateTime.Parse(conversationData.DateFrom).ToString("dddd d 'de' MMMM 'del' yyyy");
            var dateTo = System.DateTime.Parse(conversationData.DateUp).ToString("dddd d 'de' MMMM 'del' yyyy");

            await stepContext.Context.SendActivityAsync(
                MessageFactory.Text($"Gracias por tú reserva { nombre }, DNI: { userProfile.DNI }.\n\n " +
                                    $"El viaje fue programado a { conversationData.Destination } " +
                                    (conversationData.TicketType  != "" ? $"con el tipo de ticket { conversationData.TicketType }. " : "") +
                                    $"desde la fecha { dateFrom } hasta { dateTo }. " +
                                    $"Lo abonara con: { conversationData.Payment }.")
                                    , cancellationToken);
            conversationData.OnDialog = "";
            // Exit the dialog, returning the collected user information.
            return await stepContext.EndDialogAsync(stepContext.Values[UserInfo], cancellationToken);
        }

        //Validation
        private static Task<bool> NamePromptValidatorAsync(PromptValidatorContext<string> promptContext, CancellationToken cancellationToken)
        {
            // This condition is our validation rule. You can also change the value at this point.
            return Task.FromResult(promptContext.Recognized.Succeeded && promptContext.Recognized.Value == "fer");
        }

    }
}
