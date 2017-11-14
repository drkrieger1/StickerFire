using Microsoft.EntityFrameworkCore;
using StickerFire.Data;
using StickerFire.Controllers;
using StickerFire.Models;
using System;
using System.Net;
using Xunit;
using Microsoft.AspNetCore.Identity;

namespace StickerFireUnitTests
{
    public class UnitTest1
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private UserDbContext context;

        public UnitTest1(UserDbContext context)
        {
            this.context = context;
        }

        public UnitTest1(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }
        [Fact]
        public void Test1()
        {
          
            var options = new DbContextOptionsBuilder<UserDbContext>()
              .UseInMemoryDatabase(databaseName: "UserTestDB")
              .Options;


            //Arrange
            using (var context = new UserDbContext(options))
            {
                var controller = new UnitTest1(context);

                //Act
                


            }
        }
    }
}
