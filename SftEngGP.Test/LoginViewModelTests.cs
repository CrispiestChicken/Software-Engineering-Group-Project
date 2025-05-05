using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;
using SftEngGP.Models;
using BCrypt.Net;

namespace SftEngGP.Test
{
    public class LoginViewModelTests
    {
        private LoginViewModel _viewModel;


        // TO GET THESE TESTS TO WORK YOU NEED TO REMOVE THE MAIN THREAD AND TASK.RUN THINGS IN LOGIN VIEW MODEL.
        public LoginViewModelTests()
        {
            var options = new DbContextOptionsBuilder<GpDbContext>()
                .UseInMemoryDatabase("testgpdb")
                .Options;
            var context = new GpDbContext(options);

            var account = new User
            {
                Email = "email@email.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password123"),
                FName = "Test",
                LName = "Test",
                Address = "Test",
                RoleId = 2
            };
            context.Users.Add(account);
            context.SaveChanges();

            _viewModel = new LoginViewModel(context);
        }

        [Fact]
        public void LoginViewModelConstructorTest()
        {
            var options = new DbContextOptionsBuilder<GpDbContext>()
                .UseInMemoryDatabase("testgpdb")
                .Options;
            var context = new GpDbContext(options);
            var viewModel = new LoginViewModel(context);
            Assert.NotNull(viewModel);
            Assert.Null(viewModel.Account);
            Assert.Equal("", viewModel.ErrorMessage);
        }

        [Fact]
        public void LoginNormalData()
        {
            _viewModel.Email = "email@email.com";
            _viewModel.Password = "Password123";

            _viewModel.LoginCommand.Execute(null);

            Assert.Equal("", _viewModel.ErrorMessage);
        }

        [Fact]
        public void LoginEmailEmpty()
        {
            _viewModel.Email = "";
            _viewModel.Password = "Password123";

            _viewModel.LoginCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert an Email", _viewModel.ErrorMessage);
        }

        [Fact]
        public void LoginEmailNotValid()
        {
            _viewModel.Email = "zbb";
            _viewModel.Password = "Password123";

            _viewModel.LoginCommand.Execute(null);

            Assert.Equal("ERROR:Please Enter a Valid Email", _viewModel.ErrorMessage);
        }

        [Fact]
        public void LoginEmailNotFound()
        {
            _viewModel.Email = "email32423453254@email.com";
            _viewModel.Password = "Password123";

            _viewModel.LoginCommand.Execute(null);

            Assert.Equal("ERROR:Email or Password Incorrect", _viewModel.ErrorMessage);
        }

        [Fact]
        public void LoginPasswordEmpty()
        {
            _viewModel.Email = "email@email.com";
            _viewModel.Password = "";

            _viewModel.LoginCommand.Execute(null);

            Assert.Equal("ERROR:Please Insert a Password", _viewModel.ErrorMessage);
        }

        [Fact]
        public void LoginPasswordWrong()
        {
            _viewModel.Email = "admin@gmail.com";
            _viewModel.Password = "da";

            _viewModel.LoginCommand.Execute(null);

            Assert.Equal("ERROR:Email or Password Incorrect", _viewModel.ErrorMessage);
        }
    }
}
