using SftEngGP.Database.Models;
using SftEngGP.ViewModels;

namespace SftEngGP.Test;

public class AllSensorViewModelsTest: IClassFixture<DatabaseFixture>, IDisposable
{
    DatabaseFixture _fixture;
    private AllSensorsViewModel _viewModel;
    private Sensor _selectedSensor;
    
    public AllSensorViewModelsTest(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _fixture.Seed();
        _selectedSensor = fixture._testDbContext.Sensors.First();
    }

    public void Dispose()
    {
        _fixture._testDbContext.Database.EnsureDeleted();
    }
}