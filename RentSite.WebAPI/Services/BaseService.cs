using AutoMapper;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class BaseService<T, TSearch, TDatabase> : IService<T, TSearch> where TDatabase : class
    {
        protected readonly RentSiteContext _rentSiteContext;
        protected readonly IMapper _mapper;

        public BaseService(RentSiteContext rentSiteContext, IMapper mapper)
        {
            _rentSiteContext = rentSiteContext;
            _mapper = mapper;
        }

        public virtual List<T> GetAll(TSearch search)
        {
            var list = _rentSiteContext.Set<TDatabase>().ToList();
            return _mapper.Map<List<T>>(list);
        }

        public virtual T GetById(int id)
        {
            var entity = _rentSiteContext.Set<TDatabase>().Find(id);
            return _mapper.Map<T>(entity);
        }
    }
}
