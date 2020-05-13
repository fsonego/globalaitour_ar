using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptiveCards;

namespace GlobalAITourAR.AdaptiveCards
{
    public class StandardCard : CardBase
    {
        public string UrlImage { get; set; }
        public string BotName { get; set; }

        public StandardCard() { }

        public AdaptiveCard GetCard()
        {
            var _cardResult = SetCard();
            return _cardResult;
        }

        private AdaptiveCard SetCard()
        {

            AdaptiveCard _card = new AdaptiveCard("1.0");

            var _container = new AdaptiveContainer();

            var colum = new AdaptiveColumnSet();

            var _columnImage = new AdaptiveColumn()
            {
                Width = AdaptiveColumnWidth.Auto
            };

            _columnImage.Items.Add(new AdaptiveImage()
            {
                Url = new Uri(this.UrlImage),
                Size = AdaptiveImageSize.Medium,
                Style = AdaptiveImageStyle.Person,
                AltText = "Brainy"
            });

            var _columnContent = new AdaptiveColumn()
            {
                Width = AdaptiveColumnWidth.Stretch
            };

            _columnContent.Items.Add(new AdaptiveTextBlock()
            {
                Text = "Brainy",
                Size = AdaptiveTextSize.Medium,
                Weight = AdaptiveTextWeight.Default,
                Color = AdaptiveTextColor.Default,
                Wrap = true,
                Spacing = AdaptiveSpacing.Small
            });

            _columnContent.Items.Add(new AdaptiveTextBlock()
            {
                Text = DateTime.Now.ToString(),
                Size = AdaptiveTextSize.Small,
                Color = AdaptiveTextColor.Default,
                Wrap = true,
                IsSubtle = true,
                Spacing = AdaptiveSpacing.Small
            });

            var _textMessage = new AdaptiveTextBlock()
            {
                Text = "Has seleccionado: " + this.Title,
                Size = AdaptiveTextSize.Large,
                Color = AdaptiveTextColor.Default,
                Weight = AdaptiveTextWeight.Bolder,
                Wrap = true,
                IsSubtle = false
            };

            _columnContent.Items.Add(_textMessage);

            var _textMessage2 = new AdaptiveTextBlock()
            {
                Text =this.Description,
                Size = AdaptiveTextSize.Normal,
                Color = AdaptiveTextColor.Default,
                Weight = AdaptiveTextWeight.Default,
                Wrap = true,
                IsSubtle = false
            };

            colum.Columns.Add(_columnContent);
            colum.Columns.Add(_columnImage);
            
            _container.Items.Add(colum);

            _card.Body.Add(_container);
            //_card.Body.Add(_textMessage);
            _card.Body.Add(_textMessage2);
            
            _card.Actions.AddRange(this.GetAdaptiveActions());

            return _card;
        }
    }
}
