using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalAITourAR.Luis.Models
{
    public class Grettings
    {
        
        public string GetGreetting() {

            var rnd = new Random();
            string[] listGreetting = {
                "Me encuentro muy bien, puedes preguntarme por tus viajes.",
                "Hola, un gusto conocerte, puedes preguntarme por tus viajes.",
                "Muy buenas tardes, ¿En qué puedo ayudarte?",
                "Hola, ¿En qué puedo ayudarte?"
            };

            var gIndex = rnd.Next(listGreetting.Length);

            return listGreetting[gIndex];
        }
    }
}
