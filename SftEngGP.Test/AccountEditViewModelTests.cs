using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;
using SftEngGP.Models;
using System.Diagnostics;

namespace SftEngGP.Test
{
    public class AccountEditViewModelTests
    {
        private AccountEditViewModel _viewModel;
        public AccountEditViewModelTests()
        {
            var options = new DbContextOptionsBuilder<GpDbContext>()
            .UseInMemoryDatabase("testgpdb")
            .Options;

            var context = new GpDbContext(options);
            var user = new User();

            _viewModel = new AccountEditViewModel(context, user);
        }


        [Fact]
        public void TestUpdateNormalData()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 2;


            _viewModel.UpdateCommand.Execute(null);

            // Blank because there is no error.
            Assert.Empty(_viewModel.ErrorMessage);
        }

        [Fact]
        public void TestUpdateExtremeData()
        {
            _viewModel.Account.Email = "a@a";
            _viewModel.Account.FName = "a";
            _viewModel.Account.LName = "a";
            _viewModel.Account.Address = "a";
            _viewModel.Account.Password = "12345678";
            _viewModel.Account.RoleId = 1;


            _viewModel.UpdateCommand.Execute(null);

            // Blank because there is no error.
            Assert.Empty(_viewModel.ErrorMessage);
        }

        [Fact]
        public void TestUpdateFNameEmpty()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 2;


            _viewModel.UpdateCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert a First Name", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestUpdateLNameEmpty()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 2;


            _viewModel.UpdateCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert a Surname", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestUpdateAddressEmpty()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 2;


            _viewModel.UpdateCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert an Address", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestUpdatePasswordEmpty()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "";
            _viewModel.Account.RoleId = 2;


            _viewModel.UpdateCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert a Password", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestUpdatePasswordOneTooShort()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "1234567";
            _viewModel.Account.RoleId = 2;


            _viewModel.UpdateCommand.Execute(null);

            Assert.Equal("ERROR:Password Must Be Atleast 8 Characters Long", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestUpdateRoleNotSelected()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 0;


            _viewModel.UpdateCommand.Execute(null);

            Assert.Equal("ERROR:Please Select a Role", _viewModel.ErrorMessage);
        }
    }
}
