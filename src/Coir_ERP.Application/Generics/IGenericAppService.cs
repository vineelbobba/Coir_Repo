using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace Coir_ERP.Generics
{
  public interface IGenericAppService<TEntityDto,TEntityInputDto,TEntityOutPutDto,TEntity,TGetEntityInputDto>:IApplicationService
    {
        PagedResultDto<TEntityOutPutDto> GetByFilter(TGetEntityInputDto Input);
        Task<TEntityOutPutDto> Insert(TEntityInputDto tentity);
        Task<TEntityOutPutDto> Update(TEntityInputDto updatetentity);

        //Task Delete(int id);
        IQueryable<TEntity> GetAll();
        TEntityOutPutDto GetEntityForEdit(NullableIdDto input);
    }
}
