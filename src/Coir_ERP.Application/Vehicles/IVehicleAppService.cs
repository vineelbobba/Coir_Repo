using Coir_ERP.Generics;
using Coir_ERP.Vehicles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coir_ERP.Vehicles
{
   public interface IVehicleAppService:IGenericAppService<VehicleDto,VehicleInputDto,VehicleOutPutDto,Vehicle,GetVehicleInputDto>
    {
    }
}
