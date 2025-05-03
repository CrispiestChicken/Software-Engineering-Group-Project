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
        private System.Timers.Timer _mapUpdateTimer { get; set; }


        public Location Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Alert { get; set; }
        public string IncidenceType { get; set; }
        public DateTime DateOfEvent { get; set; }

        public MapViewModel()
        {
            _context = new GpDbContext();
            _allIncidents = _context.Incidences.ToList();
            _allSensors = _context.Sensors.ToList();

            AllBreaches = new ObservableCollection<Breach>();
            foreach (var incident in _allIncidents)
            {
                var sensor = _allSensors.FirstOrDefault(s => s.SensorId == incident.SensorId);
                if (sensor != null)
                {
                    AllBreaches.Add(new Breach(incident, sensor));
                }
            }

            // Timer for updating the map.
            _mapUpdateTimer = new System.Timers.Timer(5000);
            _mapUpdateTimer.Elapsed += async (sender, e) =>
            {
                await UpdateMap();
            };
            _mapUpdateTimer.Start();
        }



        private async Task UpdateMap()
        {
            // Checking for new incidents.
            List<Incidence> newIncidenceList = _context.Incidences.ToList();
            
            if (newIncidenceList.Count == _allIncidents.Count)
            {
                return;
            }

            // If there's new incidents add them to the incidents list.
            _allIncidents = newIncidenceList;

            // Can't make UI changes on a second thread.
            MainThread.BeginInvokeOnMainThread(() =>
            {
                AllBreaches.Clear();
            });


            foreach (var incident in _allIncidents)
            {
                var sensor = _allSensors.FirstOrDefault(s => s.SensorId == incident.SensorId);
                if (sensor != null)
                {
                    // Can't make UI changes on a second thread.
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        AllBreaches.Add(new Breach(incident, sensor));
                    });
                }
            }


        }


    }
}
