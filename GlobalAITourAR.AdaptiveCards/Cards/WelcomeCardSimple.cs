using System;
using AdaptiveCards;

namespace GlobalAITourAR.AdaptiveCards
{
    public class WelcomeCardSimple : CardBase
    {
        public string UrlImage { get; set; }
        public string BotName { get; set; }

        public WelcomeCardSimple() { }

        public AdaptiveCard GetCard()
        {
            var _cardResult = SetCard();
            return _cardResult;
        }

        private AdaptiveCard SetCard()
        {

            AdaptiveCard _card = new AdaptiveCard("1.0");
            var _container = new AdaptiveContainer();
            _card.Body.Add(_container);
            _card.Actions.AddRange(this.GetAdaptiveActions());

            return _card;
        }
    }
}
