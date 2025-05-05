using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;
using SftEngGP.Models;
using System.Diagnostics;

namespace SftEngGP.Test
{

    public class LoggedInUserTests
    {
        private DatabaseFixture _fixture;

        private List<User> _allAccounts;

        public LoggedInUserTests()
        {
            _fixture = new DatabaseFixture();
            _allAccounts = _fixture._testDbContext.Users.ToList();
        }

        [Fact]
        public void LoggedInUserLoginSuccessful()
        {
            Assert.NotEmpty(_allAccounts);
            foreach (var account in _allAccounts)
            {
                LoggedInUser.GetInstance().Login(account.Email, account.RoleId);
                Assert.Equal(account.Email, LoggedInUser.GetInstance().Email);
                Assert.Equal(account.RoleId, LoggedInUser.GetInstance().Role);
            }
        }

        [Fact]
        public void LoggedInUserLogoutSuccessful()
        {
            Assert.NotEmpty(_allAccounts);
            foreach (var account in _allAccounts)
            {
                LoggedInUser.GetInstance().Login(account.Email, account.RoleId);
                Assert.Equal(account.Email, LoggedInUser.GetInstance().Email);
                Assert.Equal(account.RoleId, LoggedInUser.GetInstance().Role);
                Assert.Equal("Logged out", LoggedInUser.GetInstance().Logout());
                Assert.Null(LoggedInUser.GetInstance().Email);
                Assert.Equal(0, LoggedInUser.GetInstance().Role);
            }
        }


    }
}
