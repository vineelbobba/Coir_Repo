using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Web.Mvc.Controllers;
using Coir_ERP.Generics;
using Coir_ERP.Web.Models.Common.Modals;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Coir_ERP.Web.Controllers
{
    public class MasterPageControllerBase<TEntityDto,TCreateOrUpdateInputDto,TCreateOrUpdateOutPutDto,TEntity,TEntityInput>:AbpController
        where TEntity:class,IEntity<int>
        where TEntityDto:class,new()
        where TCreateOrUpdateInputDto:class,new()
        where TCreateOrUpdateOutPutDto:class,new()
    {
        #region GLOBAL VARIABLE
        public readonly IGenericAppService<TEntityDto, TCreateOrUpdateInputDto, TCreateOrUpdateOutPutDto, TEntity, TEntityInput> _genericAppService;
        #endregion

        #region CONSTRUCTOR
        public MasterPageControllerBase(IGenericAppService<TEntityDto,TCreateOrUpdateInputDto,TCreateOrUpdateOutPutDto,TEntity,TEntityInput> genericAppService)
        {
            _genericAppService = genericAppService;
        }
        #endregion

        #region Index
        public virtual ActionResult Index()
        {
            var modal = this.GetIndexViewModal();
            return View(modal);
        }
        #endregion

        #region GET INDEX VIEW MODAL
        public virtual CommonIndexViewModal<TCreateOrUpdateOutPutDto> GetIndexViewModal()
        {
            var modal = new CommonIndexViewModal<TCreateOrUpdateOutPutDto>();
            modal.viewModal = new TCreateOrUpdateOutPutDto();
            PropertyInfo propertyInfo = modal.GetType().GetProperties().FirstOrDefault(f => f.Name.ToLower() == "isTenantView");
            //propertyInfo.SetValue(modal, AbpSession.TenantId.HasValue, null);
            return (modal);
        }
        #endregion

        #region GET CREATE OR UPDATE VIEW MODAL

        public virtual CommonCreateOrEditViewModal<TCreateOrUpdateOutPutDto> GetCreateOrUpdateViewModal(int? id)
        {
            var outPut = _genericAppService.GetEntityForEdit(new NullableIdDto { Id = id });
            var model = new CommonCreateOrEditViewModal<TCreateOrUpdateOutPutDto>(outPut);

            return model;
        }

        #endregion

        public string GetJsonResult(object model)
        {
            return JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ContractResolver= new CamelCasePropertyNamesContractResolver()

            });
        }
    }
}