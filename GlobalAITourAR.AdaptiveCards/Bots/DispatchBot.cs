// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdaptiveCards;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GlobalAITourAR.AdaptiveCards
{
    public class DispatchBot : ActivityHandler 
    {
        
        private IBotServices _botServices;

        public DispatchBot(IBotServices botServices)
        {
           
            _botServices = botServices;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {            
            if (turnContext.Activity.Value != null || turnContext.Activity.Value != string.Empty)
            {

                    var cardData = JsonConvert.DeserializeObject<JsonDataAux>(turnContext.Activity.Value.ToString());
                    var helper = new HelperCards();

                    var response = ((Activity)turnContext.Activity).CreateReply();
                    AdaptiveCard reply;

                    if (cardData.Action == "GALLERYIMAGES")
                    {
                        var cardResult = helper.GetGalleryCard(Guid.Parse(cardData.Selected));
                        reply = cardResult.GetCard();
                    }else if (cardData.Action == "VIDEOCARD"){
                        var cardResult = helper.GetVideoCard(Guid.Parse(cardData.Selected));
                        reply = cardResult.GetCard();
                    }
                    else if (cardData.Action == "FORM")
                    {
                        var cardResult = helper.GetFormCard(Guid.Parse(cardData.Selected));
                        reply = cardResult.GetCard();
                    }
                    else if (cardData.Action == "MDZFORM")
                    {
                        var _formInfo = JsonConvert.DeserializeObject<FormMDZModel>(turnContext.Activity.Value.ToString());
                        var cardResult = helper.GetStandardCard(Guid.Parse("d92c1ecb-1752-4ae3-97de-7b4aef61ee6b"));
                        reply = cardResult.GetCard();
                    }                
                    else {
                            var cardResult = helper.GetStandardCard(Guid.Parse(cardData.Selected));
                            reply = cardResult.GetCard();
                    }
                    
                    var result = new Attachment()
                    {
                        ContentType = "application/vnd.microsoft.card.adaptive",
                        Content = reply
                    };

                    response.Attachments = new List<Attachment>() { result };

                    await turnContext.SendActivityAsync(response, cancellationToken);

            };

        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {

            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {

                    var adaptiveCardJson = File.ReadAllText(Path.Combine(".", "Cards", "WelcomeCard.json"));
                    var responseCardJson = ((Activity)turnContext.Activity).CreateReply();
                    responseCardJson.Attachments = new List<Attachment>()
                            {
                                new Attachment()
                                {
                                    ContentType = "application/vnd.microsoft.card.adaptive",
                                    Content = JsonConvert.DeserializeObject(adaptiveCardJson)
                                }
                            };

                    await turnContext.SendActivityAsync(responseCardJson, cancellationToken);

                    var helper = new HelperCards();
                    var welcomeCard = helper.GetWelcomeCard();

                    var response = ((Activity)turnContext.Activity).CreateReply();
                    var reply = welcomeCard.GetCard();

                    var result = new Attachment()
                    {
                        ContentType = "application/vnd.microsoft.card.adaptive",
                        Content = reply
                    };

                    response.Attachments = new List<Attachment>() { result };

                    await turnContext.SendActivityAsync(response, cancellationToken);

                }
            }
        }


    }
}
