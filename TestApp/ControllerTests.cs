using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using HometaskEntity.Controllers;
using HometaskEntity.BLL.Service;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL.Models;
using HometaskEntity.BLL.DTOs;
using Xunit;
using Moq;

namespace TestApp
{
    public class ControllerTests
    {
        private AviatorService service;
        private async void Initialize()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unit => unit.Aviators.GetAll().Result).Returns(GetTestAviators());
            service = new AviatorService(mock.Object);

            MapperInitializator.Initialize();
        }
        public ControllerTests()
        {
        }

        private List<Aviator> GetTestAviators()
        {
            var aviators = new List<Aviator>
            {
                new Aviator { Id = 1, Name = "Jacob", Surname = "Fernandes", Experience = 3, DateOfBirthday = DateTime.MinValue},
                new Aviator { Id = 2, Name = "Natalie", Surname = "Lust", Experience = 2, DateOfBirthday = DateTime.Now},
                new Aviator { Id = 3, Name = "Sebastian", Surname = "Perairo", Experience = 1, DateOfBirthday = DateTime.MaxValue}
            };
            return aviators;
        }

        [Fact]
        public async Task Not_Null_And_Empty_Result()
        {
            //Arrange
            AviatorsController controller = new AviatorsController(service);
            //Act
            var result = await controller.Get();
            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Invalid_Id_In_The_Get_Request()
        {
            //Arrange
            AviatorsController controller = new AviatorsController(service);
            //Act
            Action result = () => 
            {
                controller.Get(-1).Wait();
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public async Task Reply_HttpRequest_When_Model_Is_Invalid()
        {
            //Arrange
            AviatorsController controller = new AviatorsController(service);
            Aviator aviator = null;
            //Act
            var result = await controller.Post(Mapper.Map<AviatorDTO>(aviator));
            //Assert
            Assert.Equal(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest).StatusCode, result.StatusCode);
        }

        [Fact]
        public async Task Reply_HttpRequest_When_Model_Is_Valid()
        {
            //Arrange
            AviatorsController controller = new AviatorsController(service);
            Aviator aviator = new Aviator { Id = 46, Name = "Nikita", Surname = "Gribiwe", Experience = 34, DateOfBirthday = DateTime.Now.AddHours(13)};
            //Act
            var result = await controller.Post(Mapper.Map<AviatorDTO>(aviator));
            //Assert
            Assert.Equal(new HttpResponseMessage(System.Net.HttpStatusCode.OK).StatusCode, result.StatusCode);
        }

        [Fact]
        public async Task Invalid_Id_In_The_Delete_Request()
        {
            //Arrange
            AviatorsController controller = new AviatorsController(service);
            //Act
            Action result = () =>
            {
                controller.Delete(-1).Wait();
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }
    }
}