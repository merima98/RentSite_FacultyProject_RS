using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public interface IService <T, TSearch>
    {
        List<T> GetAll(TSearch search);
        T GetById(int id);
    }
}
