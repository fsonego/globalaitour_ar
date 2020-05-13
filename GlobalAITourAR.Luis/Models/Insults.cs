using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalAITourAR.Luis.Models
{
    public class Insults
    {

        public string GetInsults()
        {

            var rnd = new Random();
            string[] listInsults = {
                    "No me faltes el respeto, a pesar de ser una maquina... tengo sentimiento... snif snif, no mentira, respeto por favor.",
                    "OMG! me ha faltado el respeto, por favor no vuelva hacerlo.",
                    "Todo lo que me deesess te deseo el doble.",
                    "Gracias por el insulto, su madre estaría orgullosa de usted."
                };

            var iIndex = rnd.Next(listInsults.Length);

            return listInsults[iIndex];
        }
    }
}
