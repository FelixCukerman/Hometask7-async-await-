using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HometaskEntity.BLL.Service;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL;
using HometaskEntity.BLL.DTOs;
using HometaskEntity;
using Xunit;

namespace TestApp
{
    public class DBTests
    {
        private static AirportContext context;
        private static IUnitOfWork unit;
        private static AviatorService service;

        private static void Initialize()
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=AirportDB;Trusted_Connection=True;";
            var options = new DbContextOptionsBuilder<AirportContext>();
            options.UseSqlServer(connectionString);
            context = new AirportContext(options.Options);
            unit = new UnitOfWork(context);
            service = new AviatorService(unit);
            MapperInitializator.Initialize();
        }

        [Fact]
        public void Get_Aviator_By_Id_When_Id_Is_Invalid()
        {
            //Arrange
            Initialize();
            //Act
            Action result = () =>
            {
                service.GetById(-1).Wait();
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public async Task Get_Aviator_By_Id_When_Id_Is_Valid()
        {
            //Arrange
            Initialize();
            //Act
            var aviators = await service.GetAll();
            var result = aviators.FirstOrDefault();
            //Assert
            Assert.IsType<AviatorDTO>(result);
        }

        [Fact]
        public async Task Create_Equal_Aviator()
        {
            //Arrange
            Initialize();
            var aviator = new AviatorDTO { Name = "Alex", Surname = "Harper", Experience = 3, DateOfBirthday = DateTime.MinValue };
            //Act
            Action result = () =>
            {
                service.Create(aviator).Wait();
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public async Task Create_Aviator_When_Value_Is_Null()
        {
            //Arrange
            Initialize();
            //Act
            Action result = () =>
            {
                service.Create(null).Wait();
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public async Task Update_Aviator_When_Id_Is_Invalid_And_Model_Is_Null()
        {
            //Arrange
            Initialize();
            //Act
            Action result = () =>
            {
                service.Update(-1, null).Wait();
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public async Task Update_Aviator_To_Equal_Value()
        {
            //Arrange
            Initialize();
            var aviators = await service.GetAll();
            var aviator = aviators.FirstOrDefault();
            int id = aviators.Last().Id;
            //Act
            Action result = () =>
            {
                service.Update(id, aviator).Wait();
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public async Task Update_Aviator_To_Current_Value()
        {
            //Arrange
            Initialize();
            var aviators = await service.GetAll();
            var aviator = aviators.FirstOrDefault();
            int id = aviator.Id;
            //Act
            Action result = () =>
            {
                service.Update(id, aviator).Wait();
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public async Task Delete_Aviator_By_Id_When_Id_Is_Valid()
        {
            //Arrange
            Initialize();
            var aviators = await service.GetAll();
            var id = aviators.FirstOrDefault().Id;
            //Act
            await service.Delete(id);
            //Assert
            Assert.IsType<Exception>(new Exception("Bad request"));
        }

        [Fact]
        public async Task Delete_Aviator_By_Id_When_Id_Is_Invalid()
        {
            //Arrange
            Initialize();
            var aviators = await service.GetAll();
            var id = aviators.Last().Id + 1;
            //Act
            await service.Delete(id);
            //Assert
            Assert.IsType<Exception>(new Exception("Bad request"));
        }

        [Fact]
        public async Task Get_All()
        {
            //Arrange
            Initialize();
            //Act
            var items = await service.GetAll();
            //Assert
            Assert.NotEmpty(items);
        }
    }
}
