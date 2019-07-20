using ParkAndRide.Common.CQRS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Services.Rides.CQRS.Commands
{
    public class CreateRide :ICommand
    {
        public Guid Id { get; set; }
        [Required]
        public string CarType { get; set; }
        [Required]
        public int NumPassengers { get; set; }
        [Required]
        public string DriverName { get; set; }
        [Required]
        public DateTime RideDate { get; set; }
        [Required]
        public decimal Cost { get; set; }
        //public Driver Driver { get; set; }
        //public Location LocationFrom { get; set; }
        //public Location LocationTo { get; set; }
        //public DateTimeOffset DriveTime { get; set; }
        public CreateRide()
        {

        }
    }
}
