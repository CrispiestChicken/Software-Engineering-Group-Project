using SftEngGP.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SftEngGP.Models
{
    internal class Breach
    {
        public Location Location { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string IncidenceType { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string Alert { get; set; }

        public Breach(Incidence incident, Sensor sensor)
        {
            Location = new Location(sensor.Latitude, sensor.Longitude);
            Latitude = sensor.Latitude;
            Longitude = sensor.Longitude;
            IncidenceType = incident.IncidenceType;
            DateOfEvent = incident.DateOfEvent;
            Alert = incident.Alert;
        }

    }
}
