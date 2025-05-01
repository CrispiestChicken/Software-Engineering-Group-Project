using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Collections.ObjectModel;
using SftEngGP.Models;

namespace SftEngGP.ViewModels
{
    internal class MapViewModel
    {
        private GpDbContext _context;
        public ObservableCollection<Breach> AllBreaches { get; set; }
        private List<Sensor> _allSensors { get; set; }
        private List<Incidence> _allIncidents { get; set; }

        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string IncidenceType { get; set; }
        public DateTime DateOfEvent { get; set; }

        public MapViewModel()
        {
            _context = new GpDbContext();
            _allIncidents = _context.Incidences.ToList();
            _allSensors = _context.Sensors.ToList();


            List<Breach> breaches = new List<Breach>();
            foreach (var incident in _allIncidents)
            {
                var sensor = _allSensors.FirstOrDefault(s => s.SensorId == incident.SensorId);
                if (sensor != null)
                {
                    breaches.Add(new Breach(incident, sensor));
                }
            }

            AllBreaches = new ObservableCollection<Breach>(breaches);


        }


    }
}
