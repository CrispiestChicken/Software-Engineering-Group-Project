using SftEngGP.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SftEngGP.Models
{
    /// <summary>
    /// Represents a breach of the system.
    /// </summary>
    public class Breach
    {
        /// <summary>
        /// The location of the breach.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// The latitude of the breach.
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// The longitude of the breach.
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// The thing that happened to cause the breach.
        /// </summary>
        public string IncidenceType { get; set; }

        /// <summary>
        /// The date of the breach.
        /// </summary>
        public DateTime DateOfEvent { get; set; }

        /// <summary>
        /// The message associated with the breach.
        /// </summary>
        public string Alert { get; set; }


        /// <summary>
        /// Uses a incident and sensor to create a breach object.
        /// </summary>
        /// <param name="incident"></param>
        /// <param name="sensor"></param>
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
