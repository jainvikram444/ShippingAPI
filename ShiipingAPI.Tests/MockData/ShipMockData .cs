using ShiipingAPI.Models;
using ShiipingAPI.RespnseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiipingAPI.Tests.MockData
{
    public class ShipMockData
    {
      
      
        public static List<Ship> GetShips()
        {
            return new List<Ship>
            {
                new Ship
                {
                    Id = 1,
                    Name = "Ship-1",
                    Description = "Near by Sri Lanka",
                    Latitude = 4.730407,
                    Longitude = 77.477244,
                    Velocity = 30,
                    Status = 1
                },

                new Ship
                {
                    Id = 2,
                    Name = "Ship-2",
                    Description = "Near by Malasia",
                    Latitude = 6.778805,
                    Longitude = 97.0366607,
                    Velocity = 40,
                    Status = 1
                },

                new Ship
                {
                    Id = 3,
                    Name = "Ship-3",
                    Description = "South Taiwan",
                    Latitude = 23.796708,
                    Longitude = 123.639633,
                    Velocity = 45,
                    Status = 1
                },

                new Ship
                {
                    Id = 4,
                    Name = "Ship-4",
                    Description = "Near by Japan",
                    Latitude = 41.422623,
                    Longitude = 148.508807,
                    Velocity = 50,
                    Status = 1
                }
            };
        }       
    }
}
