using ShiipingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiipingAPI.Tests.MockData
{
    public class PortMockData
    {
        public static List<Port> GetPorts()
        {
            return new List<Port>{
                new Port
                {
                    Name = "Mumbai Port",
                    Description = "Mumbai, India",
                    Latitude = 19.298350,
                    Longitude = 72.870584,
                    Status = 1
                },
                new Port
                {
                    Name = "Singapore Port",
                    Description = "Singapore",
                    Latitude = 1.268087,
                    Longitude = 103.841283,
                    Status = 1
                },
                new Port
                {
                    Name = "South Korea Port",
                    Description = "South Korea",
                    Latitude = 34.274665,
                    Longitude = 126.639220,
                    Status = 1
                },

                new Port
                {
                    Name = "Mumbai Port",
                    Description = "Japan",
                    Latitude = 35.453730,
                    Longitude = 140.830014,
                    Status = 1
                }
         };
        }
    }
}
