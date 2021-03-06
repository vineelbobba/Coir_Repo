using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coir_ERP.VehicleTypes
{
    [Table("VehicleTypes")]
   public class VehicleType: FullAuditedEntity
    {
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
    }
}
