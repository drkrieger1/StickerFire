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
    public class Tests
    {
        private readonly UserManager<ApplicationUser> userManager;

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
        public void CampaignImgPath()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                ImgPath = "img/test/path/",
            };
            //Act
            string testImgPath = campaign.ImgPath;

            //Assert
            Assert.Equal(testImgPath, "img/test/path/");
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
        public void CampaignPublished()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Published = true,
            };
            //Act
            bool testPublish = campaign.Published;

            //Assert
            Assert.Equal(testPublish, true);
        }

        [Fact]
        public void CampaignIsActive()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Active = true,
            };
            //Act
            bool testActive = campaign.Active;

            //Assert
            Assert.Equal(testActive, true);
        }


        [Fact]
        public void CampaignDescription()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Description = "Test Description",
            };
            //Act
            string testDescription = campaign.Description;

            //Assert
            Assert.Equal(testDescription, "Test Description");
        }

        [Fact]
        public void CampaignVotes()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Votes = 25,
            };
            //Act
            int testVotes = campaign.Votes;

            //Assert
            Assert.Equal(testVotes, 25);
        }

        [Fact]
        public void CampaignViews()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Views = 25,
            };
            //Act
            int testVotes = campaign.Views;

            //Assert
            Assert.Equal(testVotes, 25);
        }

        [Fact]
        public void CampaignOwnderId()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                OwnerID = "1",
            };
            //Act
            string testOwnerId = campaign.OwnerID;

            //Assert
            Assert.Equal(testOwnerId, "1");
        }

        [Fact]
        public void UserHasName()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser
            {
                UserName = "TestUser",
            };
            //Act
            string testUser = user.UserName;

            //Assert
            Assert.Equal(testUser, "TestUser");
        }

        [Fact]
        public void RegisterLoginEmailsMatch()
        {
            RegisterViewModel register = new RegisterViewModel
            {
                Email = "test@email.com"
            };

            LoginViewModel login = new LoginViewModel
            {
                Email = "test@email.com"
            };

            Assert.Equal(register.Email, login.Email);
        }

        [Fact]
        public void RegisterLoginPasswordsMatch()
        {
            RegisterViewModel register = new RegisterViewModel
            {
                Password = "12345"
            };

            LoginViewModel login = new LoginViewModel
            {
                Password = "12345"
            };

            Assert.Equal(register.Password, login.Password);
        }

        [Fact]
        public void HomeIndexResultView()
        {

            HomeController home = new HomeController();

            IActionResult result = home.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void HomeAboutResultView()
        {

            HomeController home = new HomeController();

            IActionResult result = home.About();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void FileUploadControlleTestUploadView()
        {
            var file = new FileUploadController();

            IActionResult result = file.TestUpload();

            Assert.IsType<ViewResult>(result);

        }

        [Theory]
        public void CampaignTestView()
        {
            var options = new DbContextOptionsBuilder<StickerFireDbContext>()
                .UseInMemoryDatabase(databaseName: "getStatusCode")
                .Options;

            using ( var context = new StickerFireDbContext(options))
            {
            var campaign = new CampaignController(userManager, context);

                var result = campaign.Create();

            }
        }
    }
}
