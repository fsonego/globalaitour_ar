﻿// <auto-generated>
// Code generated by LUISGen entity.json -cs Luis.LuisReconizedModel -o 
// Tool github: https://github.com/microsoft/botbuilder-tools
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
namespace GlobalAITourAR.Luis.Models
{
    public partial class LuisReconizedModel : IRecognizerConvert
    {
        [JsonProperty("text")]
        public string Text;

        [JsonProperty("alteredText")]
        public string AlteredText;

        public enum Intent
        {
            getGreetings,
            getInsults,
            getJokes,
            None,
            purchaseTicket,
            searchDestinations
        };
        [JsonProperty("intents")]
        public Dictionary<Intent, IntentScore> Intents;

        public class _Entities
        {

            // Built-in entities
            public Age[] age;

            public DateTimeSpec[] datetime;

            public Dimension[] dimension;

            public string[] email;

            public string[] keyPhrase;

            public Money[] money;

            public double[] number;

            public double[] ordinal;

            public double[] percentage;

            public string[] phoneNumber;

            public Temperature[] temperature;

            public string[] url;

            // Lists
            public string[][] city;

            public string[][] destinationType;

            public string[][] paymentMethod;

            public string[][] ticketType;

            // Instance
            public class _Instance
            {
                public InstanceData[] age;
                public InstanceData[] city;
                public InstanceData[] datetime;
                public InstanceData[] destinationType;
                public InstanceData[] dimension;
                public InstanceData[] email;
                public InstanceData[] keyPhrase;
                public InstanceData[] money;
                public InstanceData[] number;
                public InstanceData[] ordinal;
                public InstanceData[] paymentMethod;
                public InstanceData[] percentage;
                public InstanceData[] phoneNumber;
                public InstanceData[] temperature;
                public InstanceData[] ticketType;
                public InstanceData[] url;
            }
            [JsonProperty("$instance")]
            public _Instance _instance;
        }
        [JsonProperty("entities")]
        public _Entities Entities;

        [JsonExtensionData(ReadData = true, WriteData = true)]
        public IDictionary<string, object> Properties { get; set; }

        public void Convert(dynamic result)
        {
            var app = JsonConvert.DeserializeObject<LuisReconizedModel>(JsonConvert.SerializeObject(result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            Text = app.Text;
            AlteredText = app.AlteredText;
            Intents = app.Intents;
            Entities = app.Entities;
            Properties = app.Properties;
        }

        public (Intent intent, double score) TopIntent()
        {
            Intent maxIntent = Intent.None;
            var max = 0.0;
            foreach (var entry in Intents)
            {
                if (entry.Value.Score > max)
                {
                    maxIntent = entry.Key;
                    max = entry.Value.Score.Value;
                }
            }
            return (maxIntent, max);
        }
    }
}