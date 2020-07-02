using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentSite.Model;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class ApartmentsService : BaseCRUDService<Model.ResidentialBuilding, ApartmentSearchRequest, Database.ResidentialBuilding, ApartmentsInsertRequest, ApartmentsInsertRequest>
    {
        public ApartmentsService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }
        public override List<Model.ResidentialBuilding> GetAll(ApartmentSearchRequest search)
        {
            var query = _rentSiteContext.Set<Database.ResidentialBuilding>().AsQueryable();

            if (search?.CityId.HasValue == true)
            {
                query = query.Where(x => x.CityId == search.CityId);
            }

            if (search?.TypeOfResidentialBuildingId.HasValue == true)
            {
                query = query.Where(x => x.TypeOfResidentialBuildingId == search.TypeOfResidentialBuildingId);
            }

            query = query.OrderBy(x => x.CityId);

            var list = query.ToList();

            return _mapper.Map<List<Model.ResidentialBuilding>>(list);
        }
        public override Model.ResidentialBuilding Insert(ApartmentsInsertRequest request)
        {
            var entity = _mapper.Map<Database.ResidentialBuilding>(request);

            _rentSiteContext.Add(entity);
            _rentSiteContext.SaveChanges();

            foreach (var line in request.LineOfTransport)  
            {
                Database.LineOfTransportResidentialBuilding lineApartment = new Database.LineOfTransportResidentialBuilding()
                {
                    LineOfTransportId = line,
                    ResidentialBuildingId = entity.Id
                };
                _rentSiteContext.LineOfTransportResidentialBuilding.Add(lineApartment);
                _rentSiteContext.SaveChanges();
            }

            return _mapper.Map<Model.ResidentialBuilding>(entity);
        }

        public override bool Delete(int id)
        {
            var lineOfTransportApartment = _rentSiteContext.LineOfTransportResidentialBuilding.Where(l => l.ResidentialBuildingId == id).ToList();

            var rented = _rentSiteContext.RentedResidentialBuilding.Where(r => r.ResidentialBuildingId == id).ToList();
            var rentedReview = _rentSiteContext.ResidentialBuildingReview.Where(r => r.ResidentialBuildingId == id).ToList();

            foreach (var line in lineOfTransportApartment)
            {
                _rentSiteContext.LineOfTransportResidentialBuilding.Remove(line);
                _rentSiteContext.SaveChanges();
            }

            foreach (var rent in rentedReview)
            {
                _rentSiteContext.ResidentialBuildingReview.Remove(rent);
                _rentSiteContext.SaveChanges();
            }


            foreach (var rent in rented)
            {
                _rentSiteContext.RentedResidentialBuilding.Remove(rent);
                _rentSiteContext.SaveChanges();
            }

            var entity = _rentSiteContext.ResidentialBuilding.Find(id);
            if (entity != null)
            {
                _rentSiteContext.ResidentialBuilding.Remove(entity);
                _rentSiteContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
