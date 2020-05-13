using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalAITourAR.Luis.Models
{
    public class Jokes
    {

        public string GetJokes()
        {

            var rnd = new Random();
            string[] listJokes = {
                "¿Por qué las focas del circo miran siempre hacia arriba? Porque es donde están los focos.",
                "¿Sabes cómo se queda un mago después de comer? Magordito",
                "¿Dónde cuelga Superman su supercapa? En superchero",
                "Abuelo, ¿por qué estás delante del ordenador con los ojos cerrados? Es que Windows me ha dicho que cierre las pestañas.",
                "¿Por qué se suicidó el libro de matemáticas? Porque tenía muchos problemas.",
                "¿Qué le dice un espagueti a otro? ¡El cuerpo me pide salsa!",
                "¿Qué hace una abeja en el gimnasio? Zumba",
                "¿Sabes que le dice un .gif a un .jpg? ¡Anímate hombre!",
                " Ramón, si supieras que voy a morir mañana, ¿qué me dirías hoy? ¿Me prestas 1000 euros, y mañana te los devuelvo?"
            };

            var gIndex = rnd.Next(listJokes.Length);

            return listJokes[gIndex];
        }

    }
}
