using Microsoft.EntityFrameworkCore;
using StickerFire.Data;
using StickerFire.Controllers;
using StickerFire.Models;
using System;
using System.Net;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StickerFireUnitTests
{
    //public class UnitTest1
    //{
    //    private readonly UserManager<ApplicationUser> _userManager;
    //    private readonly SignInManager<ApplicationUser> _signInManager;
    //    private UserDbContext context;

    //    public UnitTest1(UserDbContext context)
    //    {
    //        this.context = context;
    //    }

    //    public UnitTest1(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
    //    {
    //        _userManager = usermanager;
    //        _signInManager = signInManager;
    //    }
    //    [Fact]
    //    public void Test1()
    //    {
          
    //        var options = new DbContextOptionsBuilder<UserDbContext>()
    //          .UseInMemoryDatabase(databaseName: "UserTestDB")
    //          .Options;


    //        //Arrange
    //        using (var context = new UserDbContext(options))
    //        {
    //            var controller = new UnitTest1(context);

    //            //Act
                


    //        }
    //    }
    //}

    public class UnitTest2
    {
        [Fact]
        public void UserNameIsValid()
        {
            //Arrange
            RegisterViewModel register = new RegisterViewModel
            {
                Email = "test@mail.com",
            };
            //Act
            string testMail = register.Email;

            //Assert
            Assert.Equal(testMail, "test@mail.com");
        }

        [Theory]
        [InlineData("password1")]

        public void UserPasswordLengthIsValid(string value)
        {
            //Arrange
            RegisterViewModel register = new RegisterViewModel
            {
                Password = (value)
            };
            //Act
            string testPw = register.Password;

            //Assert
            Assert.InRange(testPw.Length, 8, 100);
        }

        [Theory]
        [InlineData("password1")]
        public void LoginPassWordLength(string value)
        {
            LoginViewModel login = new LoginViewModel() { Password = (value) };

            string testPw = login.Password;

            Assert.InRange(testPw.Length, 8, 100);
        }

        [Fact]
        public void LoginEmailIsValid()
        {
            //Arrange
            LoginViewModel register = new LoginViewModel
            {
                Email = "test@mail.com",
            };
            //Act
            string testMail = register.Email;

            //Assert
            Assert.Equal(testMail, "test@mail.com");
        }

        [Fact]
        public void CampaignTitle()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Title = "Test Campaign Title",
            };
            //Act
            string testTitle = campaign.Title;

            //Assert
            Assert.Equal(testTitle, "Test Campaign Title");
        }

        [Fact]
        public void CampaignDenyMessage()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                DenyMessage = "Test Deny Message",
            };
            //Act
            string testDeny = campaign.DenyMessage;

            //Assert
            Assert.Equal(testDeny, "Test Deny Message");
        }



        [Fact]
        public void StickerFireDbContent()
        {
            var options = new DbContextOptionsBuilder<StickerFireDbContext>()
                .UseInMemoryDatabase(databaseName: "getStatusCode")
                .Options;

            using (var context = new StickerFireDbContext(options))
            {
                var controller = new CampaignController(context);

                Campaign campaign = new Campaign();
                campaign.ID = 1;
                campaign.OwnerID = 1;
                campaign.Title = "Awesome Sauce Campaign";

                var result = controller.Create(campaign);

                var find = context.Campaign.FirstOrDefaultAsync(t => t.ID == campaign.ID);

                int number = context.Campaign.Local.Count;

                Assert.Equal(1, number);
            }
        }

        [Fact]
        public void StickerFireDbStatus()
        {
            var options = new DbContextOptionsBuilder<StickerFireDbContext>()
                .UseInMemoryDatabase(databaseName: "getStatusCode")
                .Options;

            using (var context = new StickerFireDbContext(options))
            {
                var controller = new CampaignController(context);

                Campaign campaign = new Campaign();
                campaign.ID = 1;
                campaign.OwnerID = 1;
                campaign.Title = "Awesome Sauce Campaign";

                var result = controller.Create(campaign);

                CreatedAtActionResult Caar = (CreatedAtActionResult)result.Result;

                Assert.StrictEqual(HttpStatusCode.Created, (HttpStatusCode)Caar.StatusCode.Value);


            }
        }


    }
}
