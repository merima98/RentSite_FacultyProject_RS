using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public interface IUserService
    {
        List<Model.User> GetAll(UsersSearchRequest request);

        Model.User GetById(int id);
        Model.User Insert(UsersInsertRequest request);
        Model.User Update(int id, UsersInsertRequest request);

        Model.User Authenticate(string username, string pass);
    }
}
