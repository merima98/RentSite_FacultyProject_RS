using AutoMapper;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase>, ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase : class
    {
        public BaseCRUDService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }

        public virtual bool Delete(int id)   
        {
            var entity = _rentSiteContext.Set<TDatabase>().Find(id);
            if (entity != null)  
            {
                _rentSiteContext.Set<TDatabase>().Remove(entity);
                _rentSiteContext.SaveChanges();
                return true;
            }
            return false;
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);
            _rentSiteContext.Set<TDatabase>().Add(entity);
            _rentSiteContext.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _rentSiteContext.Set<TDatabase>().Find(id);
            _rentSiteContext.Set<TDatabase>().Attach(entity);
            _rentSiteContext.Set<TDatabase>().Update(entity);

            _mapper.Map(request, entity);
            _rentSiteContext.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }
    }
}
