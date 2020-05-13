using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalAITourAR.Luis.Models
{
    public class Destinations
    {
        private IList<Destination> _list;
        public Destinations()
        {
            _list = new List<Destination>();

            _list.Add(new Destination() { Name = "Leon", DestinationType = "playa" });
            _list.Add(new Destination() { Name = "Cancun", DestinationType = "playa" });
            _list.Add(new Destination() { Name = "Colima", DestinationType = "playa" });
            _list.Add(new Destination() { Name = "Oaxaca", DestinationType = "playa" });

            _list.Add(new Destination() { Name = "Chihuahua", DestinationType = "ciudad" });
            _list.Add(new Destination() { Name = "Zacatecas", DestinationType = "ciudad" });
            _list.Add(new Destination() { Name = "Tepic", DestinationType = "ciudad" });
            _list.Add(new Destination() { Name = "Ciudad de Mexico", DestinationType = "ciudad" });



        }
        public string[] GetDestination(string destinationType) {

            return _list.Where(x => x.DestinationType == destinationType).Select(p => p.Name).ToArray();
        }
    }

    public class Destination {
        public string Name { get; set; }
        public string DestinationType { get; set; }
    }
}
