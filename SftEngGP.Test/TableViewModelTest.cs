using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;

namespace SftEngGP.Test;

public class TableViewModelTest
{
    private DatabaseFixture _fixture;
    private TableViewModel _viewModel;
    
    public TableViewModelTest()
    {
        _fixture = _fixture = new DatabaseFixture();;
        AllTablesViewModel allTables = new AllTablesViewModel(_fixture._testDbContext);
        _viewModel = new TableViewModel(_fixture._testDbContext, allTables.GetTableArray<Sensor>());
    }

    [Fact]
    public void TestTableRow_AllValuesNotNull()
    {
        foreach (var row in _viewModel.TableRows.Select(r=> r.RowCells.ToList()))
        {
            foreach (var cell in row)
            {
                Assert.NotNull(cell);
            }
        }
    }
}