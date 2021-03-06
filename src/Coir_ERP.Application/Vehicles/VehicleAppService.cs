using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Coir_ERP.Generics;
using Coir_ERP.Vehicles.Dto;

namespace Coir_ERP.Vehicles
{
   public class VehicleAppService:GenericAppService<VehicleDto,VehicleInputDto,VehicleOutPutDto,Vehicle,GetVehicleInputDto>,IVehicleAppService
    {
        public VehicleAppService(IRepository<Vehicle> genericRepository, Abp.ObjectMapping.IObjectMapper objectMapper) : base(genericRepository, objectMapper)
        {

        }
    }
}
