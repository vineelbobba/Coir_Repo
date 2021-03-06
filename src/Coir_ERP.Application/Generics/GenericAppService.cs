using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Uow;
using Abp.Application.Services;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Compilation;
using Coir_ERP.Dto;

namespace Coir_ERP.Generics
{
   public class GenericAppService<TEntityDto,TEntityInputDto,TEntityOutPutDto,TEntity,TGetEntityInputDto>:ApplicationService, IGenericAppService<TEntityDto,TEntityInputDto,TEntityOutPutDto,TEntity,TGetEntityInputDto>
        where TEntityDto:class,IEntityDto<int>,new()
       where TEntityInputDto:class,IEntityDto<int>,new()
       where TEntityOutPutDto:class , IEntityDto<int>,new()
       where TEntity:class,IFullAudited,IEntity<int>
    {
        #region GLOBAL VARIABLES
        public readonly IRepository<TEntity> _genericRepository;
        public readonly IObjectMapper _objectMapper;
        #endregion

        #region CONSTRUCTOR
        public GenericAppService(IRepository<TEntity> genericRepository, IObjectMapper objectMapper)
        {
            _genericRepository = genericRepository;
            _objectMapper = objectMapper;
        }
        #endregion

        #region INSERT METHOD
        public virtual async Task<TEntityOutPutDto> Insert(TEntityInputDto tentity)
        {
            using(var unitofWork = UnitOfWorkManager.Begin())
            {
                var entity = _objectMapper.Map<TEntity>(tentity);
                var result = await _genericRepository.InsertAndGetIdAsync(entity);
                entity.Id = result;
                unitofWork.Complete();

                return _objectMapper.Map<TEntityOutPutDto>(entity);
            }
        }
        #endregion

        #region UPDATE METHOD
        public virtual async Task<TEntityOutPutDto> Update(TEntityInputDto updatetentity)
        {
            using(var unitofwork = UnitOfWorkManager.Begin())
            {
                var inputEntity = _objectMapper.Map<TEntity>(updatetentity);
                var updateResult = await _genericRepository.UpdateAsync(inputEntity);

                unitofwork.Complete();

                return _objectMapper.Map<TEntityOutPutDto>(updateResult);
            }
        }
        #endregion

        #region GETBYFILTER METHOD
        public virtual PagedResultDto<TEntityOutPutDto> GetByFilter(TGetEntityInputDto input)
        {
            PagedResultDto<TEntityOutPutDto> pagedResult = new PagedResultDto<TEntityOutPutDto>();
            //var skipCount = int.Parse(typeof(TGetEntityInputDto).GetProperties().SingleOrDefault(p => p.Name == "SkipCount").GetValue(input, null)?.ToString());

            List<TEntity> records = null;

            records = _genericRepository.GetAll().ToList();

            pagedResult.Items = _objectMapper.Map<List<TEntityOutPutDto>>(records).ToList();

            pagedResult.TotalCount = records.Count();

            return pagedResult;
        }
        #endregion

        #region DELETE METHOD
        #endregion

        #region GETALL METHOD
        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _genericRepository.GetAll().Where(i => i.IsDeleted == false);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region GET ENTITY FOR EDIT

        public TEntityOutPutDto GetEntityForEdit(NullableIdDto input)
        {
            TEntityOutPutDto createOrUpdateEntityDto;

            if(input.Id.HasValue && input.Id > 0)
            {
                var result = _genericRepository.GetAllIncluding(this.GetPropertyExpression());
                createOrUpdateEntityDto = ObjectMapper.Map<TEntityOutPutDto>(result.Where(i => i.Id == input.Id & i.IsDeleted == false).FirstOrDefault());
            }
            else
            {
                createOrUpdateEntityDto = new TEntityOutPutDto();
            }

            PropertyInfo currentLanguagePropertyInfo = createOrUpdateEntityDto.GetType().GetProperties().FirstOrDefault(f => f.Name.ToLower() == "currentLanguagerequiredfieldvalue");
            //if (currentLanguagePropertyInfo != null)
                //currentLanguagePropertyInfo.SetValue(createOrUpdateEntityDto,Convert.ToInt32(abp))

                return createOrUpdateEntityDto;
        }

        #endregion

        #region GET PROPERTY EXPRESSION
        public Expression<Func<TEntity,Object>>[]GetPropertyExpression(bool includeDependencies = false)
        {
            PropertyInfo[] properties = _objectMapper.Map<PropertyInfo[]>(typeof(TEntity).GetProperties().Where(m => m.PropertyType.IsGenericType && m.PropertyType.GetGenericTypeDefinition() == typeof(List<>) && (includeDependencies == true)));
            List<Filter> propertyFilter = new List<Filter>();

            foreach(PropertyInfo p in properties)
            {
                var property = new Filter();
                property.PropertyName = p.Name;
                propertyFilter.Add(property);
            }

            return this.GetParameterExpression<TEntity>(propertyFilter)?.ToArray();
        }
        #endregion

        private  List<Expression<Func<T,Object>>> GetParameterExpression<T>(IList<Filter> filters)
        {
            if (filters == null || filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");

            List<Expression<Func<T, object>>> expressions = new List<Expression<Func<T, object>>>();

            var properties = typeof(T).GetProperties();

            foreach(var filter in filters)
            {
                Expression propertyExpression = Expression.Property(param, filter.PropertyName);
                expressions.Add(Expression.Lambda<Func<T, object>>(propertyExpression, param));
            }

            return expressions;
        }
    }
}
