using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using ShiipingAPI.Controllers;
using ShiipingAPI.Data;
using ShiipingAPI.Models;
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
    public class TestPortController
    {
        private readonly Mock<IPortService> portService;
        public TestPortController()
        {
            portService = new Mock<IPortService>();
        }

        [Fact]
        public void GetPortList_PortList()
        {
           // arrange
            var portList = PortMockData.GetPorts();
            portService.Setup(x => x.GetPortList())
                .Returns(portList);
            var portsController = new PortsController(portService.Object);

            //act
            var portResult = portsController.GetPortList();

            //assert
            Assert.NotNull(portResult);
            Assert.Equal(PortMockData.GetPorts().Count(), portResult.Count());
            Assert.Equal(PortMockData.GetPorts().ToString(), portResult.ToString());
            Assert.True(portList.Equals(portResult));

        }

        [Fact]
        public void GetPortByID_Port()
        {
            //arrange
            var PortList = PortMockData.GetPorts();
            portService.Setup(x => x.GetPortById(2))
                .Returns(PortList[1]);
            var portsController = new PortsController(portService.Object);

            //act
            var PortResult = portsController.GetPortById(2);

            //assert
            Assert.NotNull(PortResult);
            Assert.Equal(PortList[1].Id, PortResult.Id);
            Assert.True(PortList[1].Id == PortResult.Id);
        }


        [Fact]
        public void AddPort_Port()
        {
            //arrange
            var PortList = PortMockData.GetPorts();
            portService.Setup(x => x.AddPort(PortList[2]))
                .Returns(PortList[2]);
            var portsController = new PortsController(portService.Object);

            //act
            var PortResult = portsController.PostPort(PortList[2]);

            //assert
            Assert.NotNull(PortResult);
            Assert.Equal(PortList[2].Id, PortResult.Id);
            Assert.True(PortList[2].Id == PortResult.Id);
        }

    }
}
