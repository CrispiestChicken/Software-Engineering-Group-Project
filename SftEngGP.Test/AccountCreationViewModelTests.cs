using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;
using SftEngGP.Models;

namespace SftEngGP.Test
{
    public class AccountCreationViewModelTests
    {
        private AccountCreationViewModel _viewModel;
        public AccountCreationViewModelTests()
        {
            var options = new DbContextOptionsBuilder<GpDbContext>()
            .UseInMemoryDatabase("testgpdb")
            .Options;

            var context = new GpDbContext(options);

            _viewModel = new AccountCreationViewModel(context);
        }

        [Fact]
        public void AccountCreationViewModelConstructorTest()
        {
            var options = new DbContextOptionsBuilder<GpDbContext>()
            .UseInMemoryDatabase("testgpdb")
            .Options;

            var context = new GpDbContext(options);

            var viewModel = new AccountCreationViewModel(context);

            Assert.NotNull(viewModel);
            Assert.NotEqual(null, viewModel.Account);
            Assert.Equal("Create", viewModel.CreateOrUpdate);
            Assert.Equal(true, viewModel.CreatingAccount);
            Assert.Equal("", viewModel.ErrorMessage);
        }


        [Fact]
        public void TestCreateNormalData()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 2;


            _viewModel.CreateCommand.Execute(null);

            // Blank because there is no error.
            Assert.Empty(_viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreateExtremeData()
        {
            _viewModel.Account.Email = "a@a";
            _viewModel.Account.FName = "a";
            _viewModel.Account.LName = "a";
            _viewModel.Account.Address = "a";
            _viewModel.Account.Password = "12345678";
            _viewModel.Account.RoleId = 1;


            _viewModel.CreateCommand.Execute(null);

            // Blank because there is no error.
            Assert.Empty(_viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreateEmailEmpty()
        {
            _viewModel.Account.Email = "";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 2;


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert an Email", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreateEmailInvalid()
        {
            _viewModel.Account.Email = "a@";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 2;


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR:Please Enter a Valid Email", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreateFNameEmpty()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 2;


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert a First Name", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreateLNameEmpty()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 2;


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert a Surname", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreateAddressEmpty()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 2;


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert an Address", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreatePasswordEmpty()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "";
            _viewModel.Account.RoleId = 2;


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert a Password", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreatePasswordOneTooShort()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "1234567";
            _viewModel.Account.RoleId = 2;


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR:Password Must Be Atleast 8 Characters Long", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreateRoleNotSelected()
        {
            _viewModel.Account.Email = "Test@Test.com";
            _viewModel.Account.FName = "Test";
            _viewModel.Account.LName = "Test";
            _viewModel.Account.Address = "Test";
            _viewModel.Account.Password = "123456789";
            _viewModel.Account.RoleId = 0;


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR:Please Select a Role", _viewModel.ErrorMessage);
        }
    }
}
