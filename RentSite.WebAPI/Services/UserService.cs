using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly RentSiteContext _rentSiteContext;
        private readonly IMapper _mapper;
        public UserService(RentSiteContext rentSiteContext, IMapper mapper)
        {
            _rentSiteContext = rentSiteContext;
            _mapper = mapper;
        }
        public List<Model.User> GetAll(UsersSearchRequest request)
        {

            var query = _rentSiteContext.User.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.FirstName) || !string.IsNullOrWhiteSpace(request?.LastName))
            {
                query = query.Where(x => x.FirstName == request.FirstName || x.LastName == request.LastName);
            }

            var entities = query.ToList();

            var result = _mapper.Map<List<Model.User>>(entities);

            return result;
        }

        public Model.User GetById(int id)
        {
            var entity = _rentSiteContext.User.Find(id);
            return _mapper.Map<Model.User>(entity);
        }

        public Model.User Insert(UsersInsertRequest request)
        {
            var entity = _mapper.Map<User>(request);
            if (request.PasswordHash != request.PasswordSalt)
            {
                throw new Exception("Passwords must be equale!");
            }
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.PasswordSalt);
            entity.TypeOfUserId = request.TypeOfUserId;

         
            _rentSiteContext.User.Add(entity);
            _rentSiteContext.SaveChanges();



            return _mapper.Map<Model.User>(entity);
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.User Authenticate(string username, string pass)
        {
            var user = _rentSiteContext.User.FirstOrDefault(x => x.Username == username);  

            if (user!=null)
            {
                var newHash = GenerateHash(user.PasswordSalt, pass);
                if (newHash==user.PasswordHash)
                {
                    return _mapper.Map<Model.User>(user);
                }
            }
            return null;   
        }

        //public Model.User Update(int id, UsersInsertRequest request)
        //{
        //    var entity = _rentSiteContext.User.Find(id);

        //    _mapper.Map(request, entity);
        //    _rentSiteContext.SaveChanges();


        //    if (!string.IsNullOrWhiteSpace(request.PasswordHash))
        //    {
        //        if (request.PasswordHash != request.PasswordSalt)
        //        {
        //            throw new Exception("Passwords must be equale!");
        //        }
        //    }
        //    _rentSiteContext.SaveChanges();

        //    return _mapper.Map<Model.User>(entity);
        //}

        public Model.User Update(int id, UsersInsertRequest request)  //napravljena izmjena nad update i u recommenderu isto
        {
            var entity = _rentSiteContext.User.Find(id);


            _mapper.Map(request, entity);

            if (!string.IsNullOrWhiteSpace(request.PasswordHash) && !string.IsNullOrWhiteSpace(request.PasswordSalt))
            {
                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.PasswordSalt);
            }
            else
            {
                throw new Exception("Can not change!");
            }
            _rentSiteContext.SaveChanges();


            if (!string.IsNullOrWhiteSpace(request.PasswordHash))
            {
                if (request.PasswordHash != request.PasswordSalt)
                {
                    throw new Exception("Passwords must be equale!");
                }
            }
            _rentSiteContext.SaveChanges();

            return _mapper.Map<Model.User>(entity);
        }
    }
}
