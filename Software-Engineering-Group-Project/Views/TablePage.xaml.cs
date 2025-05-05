using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SftEngGP.ViewModels;

namespace SftEngGP.Views
{
    public partial class TablePage : ContentPage
    {
        private TableViewModel _viewModel;
        public TablePage(TableViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = viewModel;
            InitializeComponent();
        }

        public List<string> GetColumn(string name)
        {
            List<string> column = new List<string>();
            int index = _viewModel.TableColumns.IndexOf(_viewModel.TableColumns.First(c => c == name));
            column.Add(_viewModel.TableColumns[index]);
            foreach (var row in _viewModel.TableRows)
            {
                column.Add(row.RowCells[index].ToString());
            }

            return column;
        }
    }
}