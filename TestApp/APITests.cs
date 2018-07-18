using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HometaskEntity.Controllers;
using HometaskEntity.BLL.Service;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL;
using HometaskEntity.BLL.DTOs;
using HometaskEntity;
using Xunit;

namespace TestApp
{
    public class APITests
    {
        private static AviatorsController controller;
        private static IService<AviatorDTO> service;
        private static IUnitOfWork unit;
        private static AirportContext context;
        public static void Initialize()
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=AirportDB;Trusted_Connection=True;";
            var options = new DbContextOptionsBuilder<AirportContext>();
            options.UseSqlServer(connectionString);
            context = new AirportContext(options.Options);
            unit = new UnitOfWork(context);
            service = new AviatorService(unit);
            controller = new AviatorsController(service);
            MapperInitializator.Initialize();
        }

        [Fact]
        public async Task Get_All_Aviators()
        {
            //Arrange
            Initialize();
            //Act
            var result = await controller.Get();
            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Get_Aviator_By_Valid_Id()
        {
            //Arrange
            Initialize();
            //Act
            var aviators = await service.GetAll();
            int id = aviators.Last().Id;
            var result = controller.Get(id);
            //Assert
            Assert.Equal(result.Id, id);
        }

        [Fact]
        public async Task Create_Aviator_By_Custom_Values()
        {
            //Arrange
            Initialize();
            Aviator aviator = new Aviator { Name = "Lord", Surname = "Satanus", Experience = 666, DateOfBirthday = DateTime.MinValue };
            //Act
            await controller.Post(Mapper.Map<AviatorDTO>(aviator));
            var aviators = await controller.Get();
            var result = aviators.Where(x => x.Name == "Lord" && x.Surname == "Satanus" && x.Experience == 666);
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Put_Aviator_By_Id()
        {
            //Arrange
            Initialize();
            Aviator aviator = new Aviator { Name = "Lord", Surname = "Andre", Experience = 666, DateOfBirthday = DateTime.MinValue };
            var aviators = await controller.Get();
            int id = aviators.FirstOrDefault(x => x.Name == "Lord" && x.Surname == "Satanus" && x.Experience == 666).Id;
            //Act
            await controller.Put(id, Mapper.Map<AviatorDTO>(aviator));
            var result = aviators.Where(x => x.Name == "Lord" && x.Surname == "Andre" && x.Experience == 666);
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Delete_Aviator_By_Id()
        {
            //Arrange
            Initialize();
            await controller.Post(new AviatorDTO { Id = 34, Name = "34", Surname = "43", DateOfBirthday = DateTime.MinValue.AddHours(43), Experience = 43});
            //Act
            await controller.Delete(34);
            var aviators = await controller.Get();
            var result = aviators.FirstOrDefault(x => x.Id == 34);
            //Assert
            Assert.Null(result);
        }
    }
}