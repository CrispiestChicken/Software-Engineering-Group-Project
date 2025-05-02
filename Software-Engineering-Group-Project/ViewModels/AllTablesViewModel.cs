using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using SftEngGP.Views;

namespace SftEngGP.ViewModels
{
    
    /// <summary>
    /// Holds an observable collection of the names of all the tables in the database
    /// </summary>
    public class AllTablesViewModel
    {
        private GenericGPDbContext _context;
        public ObservableCollection<string?> TableNames { get; set; }
        
        public ICommand SelectTableCommand { get; }
        
        public AllTablesViewModel(GenericGPDbContext context)
        {
            _context = context;
            TableNames = new ObservableCollection<string?>(_context.Model.GetEntityTypes().ToList().Select(p => p.GetTableName()));
            SelectTableCommand = new AsyncRelayCommand<string>(SelectTableAsync);
        }
        
        /// <summary>
        /// Directs the user to a page containing the selected table
        /// </summary>
        /// <param name="tableName">The name of the selected table</param>
        internal async Task SelectTableAsync(string tableName)
        {
            TableViewModel table;
            
            // Yes I know the DRY principle
            // but I've spent days trying to find a way of doing this without repeating myself
            // and I just cant find anything
            if (tableName == "Configuration")
            {
                table = new TableViewModel(_context, GetTableArray<Configuration>());
            } else if (tableName == "Sensor_Reading") {
                table = new TableViewModel(_context, GetTableArray<SensorReading>());
            }
            else if (tableName == "FrequencyOffset") {
                table = new TableViewModel(_context, GetTableArray<FrequencyOffset>());
            }
            else if (tableName == "Incidence") {
                table = new TableViewModel(_context, GetTableArray<Incidence>());
            }
            else if (tableName == "Measurand") {
                table = new TableViewModel(_context, GetTableArray<Measurand>());
            }
            else if (tableName == "Role") {
                table = new TableViewModel(_context, GetTableArray<Role>());
            }
            else if (tableName == "Sensor") {
                table = new TableViewModel(_context, GetTableArray<Sensor>());
            }
            else if (tableName == "Update") {
                table = new TableViewModel(_context, GetTableArray<Update>());
            }
            else if (tableName == "Users") {
                table = new TableViewModel(_context, GetTableArray<User>());
            }
            else
            {
                table = new TableViewModel(_context, null);
            }

            await App.Current.MainPage.Navigation.PushAsync(new TablePage(table));
        }

        /// <summary>
        /// Coverts a database dbset into a list of dictonaries with each property being stored as a generic object
        /// </summary>
        /// <typeparam name="T">The entity type that the dbset belongs to</typeparam>
        private List<Dictionary<string, object?>> GetTableArray<T>() where T : class
        {
            List<string> properties = new List<string>(_context.Set<T>().EntityType.GetProperties().Select(p => p.Name));

            return new List<Dictionary<string, object?>>(
                _context.Set<T>().ToList().Select(
                    t => new Dictionary<string, object?>(
                        properties.Select(
                            p => new KeyValuePair<string, object?>(
                                p, t.GetType().GetProperty(p).GetValue(t)
                            )
                        ).ToList()
                    )
                )
            );

            //return new List<Dictionary<string, object?>>
            //(
            //    _context.Set<T>().Select(
            //        s => new Dictionary<string, object?>(
            //            s.GetType().GetProperties().Select(
            //                p =>
            //                {
            //                    object? val = p.GetValue(p);
            //                    KeyValuePair<string, object?> keyval = new KeyValuePair<string, object?>(p.Name, val);
            //                    return keyval;
            //                }
            //                )
            //            )
            //        )
            //    );
        }
    }
}