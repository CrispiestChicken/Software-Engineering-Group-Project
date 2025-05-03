using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Collections.ObjectModel;
using SftEngGP.Models;


namespace SftEngGP.ViewModels
{
    /// <summary>
    /// ViewModel for the Map page.
    /// </summary>
    internal class MapViewModel
    {
        /// <summary>
        /// Database context for accessing the database.
        /// </summary>
        private GpDbContext _context;

        /// <summary>
        /// List of all breaches that is used to add pins to the map and show breaches below.
        /// </summary>
        public ObservableCollection<Breach> AllBreaches { get; set; }

        /// <summary>
        /// List of all sensors in the database.
        /// </summary>
        private List<Sensor> _allSensors { get; set; }

        /// <summary>
        /// List of all incidents in the database.
        /// </summary>
        private List<Incidence> _allIncidents { get; set; }

        /// <summary>
        /// Timer for updating the map every X seconds.
        /// </summary>
        private System.Timers.Timer _mapUpdateTimer { get; set; }



        // All here for the xaml to bind to before actual data is given.
        public Location Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Alert { get; set; }
        public string IncidenceType { get; set; }
        public DateTime DateOfEvent { get; set; }


        /// <summary>
        /// Constructor for the MapViewModel.
        /// </summary>
        public MapViewModel()
        {

            _context = new GpDbContext();
            _allIncidents = _context.Incidences.ToList();
            _allSensors = _context.Sensors.ToList();


            // Getting incidents sensors location information and creating a list of breaches.
            AllBreaches = new ObservableCollection<Breach>();
            foreach (var incident in _allIncidents)
            {
                var sensor = _allSensors.FirstOrDefault(s => s.SensorId == incident.SensorId);
                if (sensor != null)
                {
                    AllBreaches.Add(new Breach(incident, sensor));
                }
            }


            // Timer for updating the map that runs UpdateMap every X seconds (number in timer milliseconds).
            _mapUpdateTimer = new System.Timers.Timer(5000);
            _mapUpdateTimer.Elapsed += async (sender, e) =>
            {
                await UpdateMap();
            };
            _mapUpdateTimer.Start();
        }



        /// <summary>
        /// Updates the map by checking for new incidents in the database and adding them to the map.
        /// </summary>
        /// <returns></returns>
        private async Task UpdateMap()
        {
            // Running in background thread to not block the UI.
            await Task.Run(() =>
            {
                // Checking for new incidents.
                List<Incidence> newIncidenceList = _context.Incidences.ToList();

                if (newIncidenceList.Count == _allIncidents.Count)
                {
                    return;
                }

                // If there's new incidents add them to the incidents list.
                _allIncidents = newIncidenceList;

                // Can't make UI changes on a background thread.
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    AllBreaches.Clear();
                });


                foreach (var incident in _allIncidents)
                {
                    var sensor = _allSensors.FirstOrDefault(s => s.SensorId == incident.SensorId);
                    if (sensor != null)
                    {
                        // Can't make UI changes on a background thread.
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            AllBreaches.Add(new Breach(incident, sensor));
                        });
                    }
                }
            });

        }


    }
}
