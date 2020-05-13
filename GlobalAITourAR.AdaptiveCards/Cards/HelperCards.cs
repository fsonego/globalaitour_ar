using AdaptiveCards;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GlobalAITourAR.AdaptiveCards
{
    public class HelperCards
    {
        private aibotContext _db;

        public HelperCards()
        {
            _db = new aibotContext();
        }
        public WelcomeCardSimple GetWelcomeCard() {
            
            var randomizer = new Random();

            OptionCardModel cardResult = (from opt in _db.Options
                                          where opt.Type == "WELCOME"
                                          let rand = randomizer.Next()
                                          orderby rand
                                          select new OptionCardModel()
                                          {
                                              Title = opt.Title,
                                              Description = opt.Body,
                                              OptionId = opt.OptionId,
                                              ParentOptionId = opt.ParentOptionId,
                                              Result = opt.Result,
                                              Options = (from opt2 in _db.Options where opt2.ParentOptionId == opt.OptionId select opt2).ToList()
                                          }).Take(1).SingleOrDefault();



            var welcomeCard = new WelcomeCardSimple();
            welcomeCard.BotName = "Brainy";
            welcomeCard.Title = cardResult.Title;
            welcomeCard.UrlImage = "http://localhost:3978/img/bot-avatar_4.png";
            welcomeCard.Description = cardResult.Description;

            var listActions = GetListActions(cardResult.Options);
            welcomeCard.Actions.AddRange(listActions);

            return welcomeCard;
        }

        public StandardCard GetStandardCard(Guid OptionId) {
           
            OptionCardModel cardResult = (from opt in _db.Options
                                          where opt.OptionId == OptionId                                                       
                                          select new OptionCardModel()
                                          {
                                              Title = opt.Title,
                                              Description = opt.Body,
                                              OptionId = opt.OptionId,
                                              ParentOptionId = opt.ParentOptionId,
                                              Result = opt.Result,
                                              Options = (from opt2 in _db.Options where opt2.ParentOptionId == opt.OptionId select opt2).ToList()
                                          }).SingleOrDefault();

            var standardCard = new StandardCard();
            standardCard.BotName = "Brainy";
            standardCard.Title = cardResult.Title;
            standardCard.UrlImage = "http://localhost:3978/img/bot-avatar_5.png";
            standardCard.Description = cardResult.Description;

            var listActions = GetListActions(cardResult.Options);
            standardCard.Actions.AddRange(listActions);

            return standardCard;
        }

        public GalleryCard GetGalleryCard(Guid OptionId)
        {

            OptionCardModel cardResult = (from opt in _db.Options
                                          where opt.OptionId == OptionId
                                          select new OptionCardModel()
                                          {
                                              Title = opt.Title,
                                              Description = opt.Body,
                                              OptionId = opt.OptionId,
                                              ParentOptionId = opt.ParentOptionId,
                                              Result = opt.Result,
                                              Options = (from opt2 in _db.Options where opt2.ParentOptionId == opt.OptionId select opt2).ToList()
                                          }).SingleOrDefault();

            var galleryCard = new GalleryCard();
            galleryCard.BotName = "Brainy";
            galleryCard.Title = cardResult.Title;
            galleryCard.UrlImage = "http://localhost:3978/img/bot-avatar_5.png";
            galleryCard.Description = cardResult.Description;

            var listActions = GetListActions(cardResult.Options);
            galleryCard.Actions.AddRange(listActions);

            return galleryCard;
        }

        public FormMendozaCard GetFormCard(Guid OptionId)
        {

            OptionCardModel cardResult = (from opt in _db.Options
                                          where opt.OptionId == OptionId
                                          select new OptionCardModel()
                                          {
                                              Title = opt.Title,
                                              Description = opt.Body,
                                              OptionId = opt.OptionId,
                                              ParentOptionId = opt.ParentOptionId,
                                              Result = opt.Result,
                                              Options = (from opt2 in _db.Options where opt2.ParentOptionId == opt.OptionId select opt2).ToList()
                                          }).SingleOrDefault();

            var formCard = new FormMendozaCard();
            formCard.BotName = "Brainy";
            formCard.Title = cardResult.Title;
            formCard.UrlImage = "http://localhost:3978/img/bot-avatar_5.png";
            formCard.Description = cardResult.Description;

            var listActions = GetListActions(cardResult.Options);
            formCard.Actions.AddRange(listActions);

            return formCard;
        }

        public VideoCard GetVideoCard(Guid OptionId)
        {

            OptionCardModel cardResult = (from opt in _db.Options
                                          where opt.OptionId == OptionId
                                          select new OptionCardModel()
                                          {
                                              Title = opt.Title,
                                              Description = opt.Body,
                                              OptionId = opt.OptionId,
                                              ParentOptionId = opt.ParentOptionId,
                                              Result = opt.Result,
                                              Options = (from opt2 in _db.Options where opt2.ParentOptionId == opt.OptionId select opt2).ToList()
                                          }).SingleOrDefault();

            var videoCard = new VideoCard();
            videoCard.BotName = "Brainy";
            videoCard.Title = cardResult.Title;
            videoCard.UrlImage = "http://localhost:3978/img/bot-avatar_5.png";
            videoCard.Description = cardResult.Description;

            var listActions = GetListActions(cardResult.Options);
            videoCard.Actions.AddRange(listActions);

            return videoCard;
        }


        private IList<Action> GetListActions(IList<Options> list)
        {

            var result = from l in list
                         select new Action()
                         {
                             Title = l.Title,
                             ActionId = l.OptionId,
                             TypeCard = (TypeCards)TypeCards.Parse(typeof(TypeCards), l.Type, true),
                             Result = l.Result
                         };

            return result.ToList();

        }

        private IEnumerable<AdaptiveAction> GetListAdaptiveActions(IList<Options> list)
        {

            var result = from l in list
                         select new AdaptiveSubmitAction()
                         {                             
                             Title = l.Title,
                             Data = l.Type
                         };

            return result;

        }
    }

}
