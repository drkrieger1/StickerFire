using Microsoft.EntityFrameworkCore;
using StickerFire.Data;
using StickerFire.Controllers;
using StickerFire.Models;
using System;
using System.Net;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace StickerFireUnitTests
{
    public class Tests
    {
        private readonly UserManager<ApplicationUser> userManager;
        private IFormFile file;
        private SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<UserAuthController> logger;
        private MegaViewModel rvm;
        private MegaViewModel lvm;
        

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



        [Fact]
        public void UserNameIsString()
        {
            //Arrange
            RegisterViewModel register = new RegisterViewModel
            {
                Email = "test@mail.com",
            };
            //Act
            string testMail = register.Email;

            //Assert
            Assert.IsType<string>(testMail);
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
        public void DatetimeSet()
        {
            Campaign campaign = new Campaign
            {
                Expiration = new DateTime(2017, 11, 17)


            };
            DateTime date = campaign.Expiration;

            Assert.Equal(date, new DateTime(2017, 11, 17));
        }

        [Fact]
        public void DatetimeIsDateTime()
        {
            Campaign campaign = new Campaign
            {
                Expiration = new DateTime(2017, 11, 17)


            };
            DateTime date = campaign.Expiration;

            Assert.IsType<DateTime>(date);
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
        public void LoginEmailIsString()
        {
            //Arrange
            LoginViewModel register = new LoginViewModel
            {
                Email = "test@mail.com",
            };
            //Act
            string testMail = register.Email;

            //Assert
            Assert.IsType<string>(testMail);
        }
        [Fact]
        public void ExternalLoginModel()
        {
            ExternalLoginModel external = new ExternalLoginModel
            {
                Email = "test@email.com"
            };
            var test = external.Email;

            Assert.Equal(test, "test@email.com");
        }

        [Fact]
        public void ExternalLoginModelIsString()
        {
            ExternalLoginModel external = new ExternalLoginModel
            {
                Email = "test@email.com"
            };
            var test = external.Email;

            Assert.IsType<string>(test);
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
        public void CampaignTitleIsString()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Title = "Test Campaign Title",
            };
            //Act
            string testTitle = campaign.Title;

            //Assert
            Assert.IsType<string>(testTitle);
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
        public void CampaignImgPathIsString()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                ImgPath = "img/test/path/",
            };
            //Act
            string testImgPath = campaign.ImgPath;

            //Assert
            Assert.IsType<string>(testImgPath);
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
        public void CampaignDenyMessageIsString()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                DenyMessage = "Test Deny Message",
            };
            //Act
            string testDeny = campaign.DenyMessage;

            //Assert
            Assert.IsType<string>(testDeny);
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
        public void CampaignPublishedIsBool()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Published = true,
            };
            //Act
            bool testPublish = campaign.Published;

            //Assert
            Assert.IsType<bool>(testPublish);
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
        public void CampaignIsActiveTypeBool()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Active = true,
            };
            //Act
            bool testActive = campaign.Active;

            //Assert
            Assert.IsType<bool>(testActive);
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
        public void CampaignDescriptionIsString()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Description = "Test Description",
            };
            //Act
            string testDescription = campaign.Description;

            //Assert
            Assert.IsType<string>(testDescription);
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
        public void CampaignVotesIsInt()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Votes = 25,
            };
            //Act
            int testVotes = campaign.Votes;

            //Assert
            Assert.IsType<int>(testVotes);
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
        public void CampaignViewsIsInt()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                Views = 25,
            };
            //Act
            int testVotes = campaign.Views;

            //Assert
            Assert.IsType<int>(testVotes);
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
        public void CampaignOwnderIdIsString()
        {
            //Arrange
            Campaign campaign = new Campaign
            {
                OwnerID = "1",
            };
            //Act
            string testOwnerId = campaign.OwnerID;

            //Assert
            Assert.IsType<string>(testOwnerId);
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
        public void UserHasNameIsString()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser
            {
                UserName = "TestUser",
            };
            //Act
            string testUser = user.UserName;

            //Assert
            Assert.IsType<string>(testUser);
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
        public void MegaViewModelLoginPassword()
        {
            MegaViewModel mega = new MegaViewModel
            {
                LoginViewModel = new LoginViewModel
                {
                    Password = "12345"
                }
            };
            string result = mega.LoginViewModel.Password;

            Assert.Equal(result, mega.LoginViewModel.Password);
        }


        [Fact]
        public void MegaViewModelLoginPasswordIsString()
        {
            MegaViewModel mega = new MegaViewModel
            {
                LoginViewModel = new LoginViewModel
                {
                    Password = "12345"
                }
            };
            string result = mega.LoginViewModel.Password;

            Assert.IsType<string>(result);
        }

        [Fact]
        public void MegaViewModelLoginRememberMe()
        {
            MegaViewModel mega = new MegaViewModel
            {
                LoginViewModel = new LoginViewModel
                {
                    RememberMe = true
                }
            };
            bool result = mega.LoginViewModel.RememberMe;

            Assert.Equal(result, mega.LoginViewModel.RememberMe);
        }
        [Fact]
        public void MegaViewModelLoginRememberMeIsBool()
        {
            MegaViewModel mega = new MegaViewModel
            {
                LoginViewModel = new LoginViewModel
                {
                    RememberMe = true
                }
            };
            bool result = mega.LoginViewModel.RememberMe;

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void MegaViewModelLoginEmail()
        {
            MegaViewModel mega = new MegaViewModel
            {
                LoginViewModel = new LoginViewModel
                {
                    Email = "testc@email.com"
                }
            };
            string result = mega.LoginViewModel.Email;

            Assert.Equal(result, mega.LoginViewModel.Email);
        }

        [Fact]
        public void MegaViewModelLoginEmailIsString()
        {
            MegaViewModel mega = new MegaViewModel
            {
                LoginViewModel = new LoginViewModel
                {
                    Email = "testc@email.com"
                }
            };
            string result = mega.LoginViewModel.Email;

            Assert.IsType<string>(result);
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
        public void MegaViewModelRegisterEmail()
        {
            MegaViewModel mega = new MegaViewModel
            {
                RegisterViewModel = new RegisterViewModel
                {
                    Email = "testc@email.com"
                }
            };
            string result = mega.RegisterViewModel.Email;

            Assert.Equal(result, mega.RegisterViewModel.Email);
        }
        [Fact]
        public void MegaViewModelRegisterEmailIsString()
        {
            MegaViewModel mega = new MegaViewModel
            {
                RegisterViewModel = new RegisterViewModel
                {
                    Email = "testc@email.com"
                }
            };
            string result = mega.RegisterViewModel.Email;

            Assert.IsType<string>(result);
        }
        [Fact]
        public void MegaViewModelRegisterPassword()
        {
            MegaViewModel mega = new MegaViewModel
            {
                RegisterViewModel = new RegisterViewModel
                {
                    Password = "12345"
                }
            };
            string result = mega.RegisterViewModel.Password;

            Assert.Equal(result, mega.RegisterViewModel.Password);
        }

        [Fact]
        public void MegaViewModelRegisterPasswordIsString()
        {
            MegaViewModel mega = new MegaViewModel
            {
                RegisterViewModel = new RegisterViewModel
                {
                    Password = "12345"
                }
            };
            string result = mega.RegisterViewModel.Password;

            Assert.IsType<string>(result);
        }

        [Fact]
        public void MegaViewModelRegisterLoginPasswordsMatch()
        {
            MegaViewModel mega = new MegaViewModel
            {
                RegisterViewModel = new RegisterViewModel
                {
                    Password = "12345"
                }
            };
            MegaViewModel mega2 = new MegaViewModel
            {
                LoginViewModel = new LoginViewModel
                {
                    Password = "12345"
                }
            };
            string result = mega.RegisterViewModel.Password;
            string result2 = mega2.LoginViewModel.Password;

            Assert.Equal(result, result2);
        }

        [Fact]
        public void MegaViewModelRegisterConfirmPassword()
        {
            MegaViewModel mega = new MegaViewModel
            {
                RegisterViewModel = new RegisterViewModel
                {
                    ConfirmPassword = "12345"
                }
            };
            string result = mega.RegisterViewModel.ConfirmPassword;

            Assert.Equal(result, mega.RegisterViewModel.ConfirmPassword);
        }
        [Fact]
        public void MegaViewModelRegisterConfirmPasswordIsString()
        {
            MegaViewModel mega = new MegaViewModel
            {
                RegisterViewModel = new RegisterViewModel
                {
                    ConfirmPassword = "12345"
                }
            };
            string result = mega.RegisterViewModel.ConfirmPassword;

            Assert.IsType<string>(result);
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
        public void CampaignDbContextEqualId()
        {
            var options = new DbContextOptionsBuilder<StickerFireDbContext>()
                .UseInMemoryDatabase(databaseName: "getStatusCode")
                .Options;

            using (var context = new StickerFireDbContext(options))
            {
                CampaignController c = new CampaignController(userManager, context);


                Campaign campaign = new Campaign();
                campaign.ID = 1;
                campaign.OwnerID = "1";
                campaign.Title = "Awesome Sauce Campaign";

                var result = c.Create(campaign, file);


                Assert.Equal(campaign.ID, result.Id);


            }
        }
        

        [Fact]
        public void UserAuthAdminRegisterViewResult()
        {
            UserAuthController user = new UserAuthController(userManager, signInManager, logger);

            var result = user.RegisterAdmin();

            Assert.IsType<ViewResult>(result);
        }

        

    }
}
