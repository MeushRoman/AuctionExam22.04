using AutoMapper;
using E_Auction.BLL.Mappers;
using E_Auction.BLL.Services;
using E_Auction.Core.DataModels;
using E_Auction.Core.Exceptions;
using E_Auction.Core.ViewModels;

using E_Auction.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.ClientUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddTypeOrganization();
            //int organizationID = CreateOrganization();            
            //CreateUser(organizationID, createUserPosition());
            //CreateCategoryAuction();
            //OpenAuction(organizationID);


            UserInfo();
            OrganizationInfo();
        }
        public static void UserInfo()
        {
            UserManagementService service = new UserManagementService();
            UserInfoVm user = service.UserInfo(1);
            Console.WriteLine($"{user.Adress}\n{user.Email}\n{user.FirstName}\n{user.LastName}\n{user.PositionId}");
        }
        public static int createUserPosition()
        {
            UserManagementService service = new UserManagementService();
            return service.CreateUserPosition("Director");
        }
        public static int CreateUser(int organizationId, int positionId)
        {
            RegistrationNewUserVm reg = new RegistrationNewUserVm()
            {
                Email = "test2@mail.ru",
                Password = "1234",
                FirstName = "Director1",
                Address = "testAdress",
                LastName = "lname",
                PositionId = positionId,
                OrganizationId = organizationId
            };

            UserManagementService userService = new UserManagementService();
            return userService.RegistrationUser(reg);
        }
        public static int CreateOrganization()
        {
            OrganizationManagementService organizationService = new OrganizationManagementService();

            OpenOrganizationRequestVm openOrganization = new OpenOrganizationRequestVm()
            {
                FullName = "TestOrganization",
                IdentificationNumber = "1111-2222-3333",
                OrganizationType = "TOO",
                Adress = "testAdress",
                PhoneNumber = "870000000",
                Email = "test",
                LinkToSite = "LINK"
            };
            return organizationService.OpenOrganization(openOrganization);
        }
        public static int OpenAuction(int organizationId)
        {

            OpenAuctionRequestVm openAuction = new OpenAuctionRequestVm()
            {
                Category = "NameCategory",
                Description = "TestDiscription",
                FinishDateExpected = DateTime.Now.AddDays(5),
                PriceAtMinimum = 300000,
                PriceAtStart = 500000,
                PriceChangeStep = 50000,
                ShippingAddress = "TestShippingAdress",
                ShippingConditions = "TestShippingConditions",
                StartDate = DateTime.Now
            };

            AuctionManagementService auctionService = new AuctionManagementService();
            return auctionService.OpenAuction(openAuction, organizationId);
        }
        public static int CreateCategoryAuction()
        {
            CreateAuctionCategoryVm newCategory = new CreateAuctionCategoryVm()
            {
                Name = "NameCategory",
                Discription = "TestDiscription"
            };

            AuctionManagementService service = new AuctionManagementService();
            return service.CreateAuctionCategory(newCategory);
        }
        public static int AddTypeOrganization()
        {
            CreateOrganizationTypeVm model = new CreateOrganizationTypeVm()
            {
                Name = "TOO"
            };

            OrganizationManagementService service = new OrganizationManagementService();
            return service.AddTypeOrganization(model);
        }
        public static void OrganizationInfo()
        {
            OrganizationManagementService service = new OrganizationManagementService();
            Console.WriteLine(service.FullOrganizationInfo(1));

        }
        public static void restartAuction()
        {
            AuctionManagementService auctionService = new AuctionManagementService();
            auctionService.RestartAuction(1, DateTime.Now.AddDays(8));
        }
    }
}
