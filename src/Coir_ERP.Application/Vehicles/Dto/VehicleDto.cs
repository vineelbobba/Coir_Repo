using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coir_ERP.Vehicles;
using Abp.Application.Services.Dto;

namespace Coir_ERP.Vehicles.Dto
{
    [AutoMap(typeof(Vehicle))]
   public class VehicleDto:EntityDto
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleNumber { get; set; }
        public string CustomerName { get; set; }
        public string DriverName { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
    }
}
