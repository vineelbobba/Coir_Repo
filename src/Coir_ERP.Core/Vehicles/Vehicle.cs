using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Coir_ERP.VehicleTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coir_ERP.Vehicles
{
    [Table("Vehicles")]
   public class Vehicle: FullAuditedEntity
    {
        public int VehicleId { get; set; }

        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }
        public string VehicleNumber { get; set; }
        public string CustomerName { get; set; }
        public string DriverName { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }

    }

    
}
