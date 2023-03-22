using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using NuGet.Protocol;
using ShiipingAPI.Controllers;
using ShiipingAPI.Data;
using ShiipingAPI.Models;
using ShiipingAPI.RespnseModels;
using ShiipingAPI.Services;
using ShiipingAPI.Tests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace ShiipingAPI.Tests.Controllers
{
    public class TestShipController
    {
        private readonly Mock<IShipService> shipService;
        public TestShipController()
        {
            shipService = new Mock<IShipService>();
        }

        [Fact]
        public async void GetShipList_ShipList()
        {
           // arrange
            var shipList = ShipMockData.GetShips();
            shipService.Setup(x => x.GetShipList())
                .ReturnsAsync(shipList);
            var shipsController = new ShipsController(shipService.Object);

            //act
            var shipResult = await shipsController.GetShip();
            var result = shipResult.Result as OkObjectResult;
            var response = result.Value as Response<Ship>;


            //assert
            Assert.NotNull(response);
            Assert.Equal(ShipMockData.GetShips().Count(), response.IsSuccess ? response.ResponseData.Count() : 0);
            Assert.Equal(ShipMockData.GetShips().ToString(), response.IsSuccess ? response.ResponseData.ToString() : null);
            Assert.True(shipList[0].Equals(response.IsSuccess ? response.ResponseData.First() : null));
            Assert.True(shipList[1].Equals(response.IsSuccess ? response.ResponseData.ToList()[1] : null));
            Assert.True(shipList[2].Equals(response.IsSuccess ? response.ResponseData.ToList()[2] : null));
            Assert.True(shipList[3].Equals(response.IsSuccess ? response.ResponseData.ToList()[3] : null));
        }

        [Fact]
        public async void GetShipByID_Ship()
        {
            //arrange
            var shipList = ShipMockData.GetShips();
            var shipPortResponse = new ShipPortResponse
            {
                Id = shipList[1].Id,
                Name = shipList[1].Name,
                Description = shipList[1].Description,
                Velocity = shipList[1].Velocity,
                Latitude = shipList[1].Latitude,
                Longitude = shipList[1].Longitude,
            };
            shipService.Setup(x => x.GetShipById(2))
                .ReturnsAsync(shipPortResponse);
            var shipsController = new ShipsController(shipService.Object);

            //act
            var shipResult = await shipsController.GetShip(2);
            var result = shipResult.Result as OkObjectResult;
            var response = result.Value as Response<ShipPortResponse>;
            var responseData = response.ResponseData.FirstOrDefault();


            //assert
            Assert.NotNull(response);
            Assert.Equal(shipList[1].Id, responseData.Id);
            Assert.True(shipList[1].Id == responseData.Id);
        }


        [Fact]
        public async void AddShip_Ship()
        {
            //arrange
            var shipList = ShipMockData.GetShips();
 
            var shipRequest = new ShipRequest
            {
                Name= shipList[2].Name,
                Description = shipList[2].Description,
                Latitude= shipList[2].Latitude,
                Longitude= shipList[2].Longitude,
                Velocity = shipList[2].Velocity
            };
                      

            shipService.Setup(x => x.AddShip(shipRequest))
                .ReturnsAsync(shipList[2]);
            var shipsController = new ShipsController(shipService.Object);

            //act
            var shipResult = await shipsController.PostShip(shipRequest);
            var result = shipResult.Result as OkObjectResult;
            var response = result.Value as Response<Ship>;
            var responseData = response.ResponseData.FirstOrDefault();

            //assert
            Assert.NotNull(shipResult);
            Assert.Equal(shipRequest.Name, responseData.Name);
            Assert.True(shipRequest.Name == responseData.Name);
        }

    }
}
