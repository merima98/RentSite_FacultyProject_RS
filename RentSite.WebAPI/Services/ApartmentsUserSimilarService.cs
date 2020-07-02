using AutoMapper;
using RentSite.Model;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class ApartmentsUserSimilarService : ISimilarApartments
    {
        protected readonly RentSiteContext _rentSiteContext;
        protected readonly IMapper _mapper;


        public ApartmentsUserSimilarService(RentSiteContext rentSiteContext, IMapper mapper)
        {
            _rentSiteContext = rentSiteContext;
            _mapper = mapper;
        }

        Dictionary<int, List<Database.ResidentialBuildingReview>> products = new Dictionary<int, List<Database.ResidentialBuildingReview>>();


        public List<Model.ResidentialBuilding> GetAll(int id)
        {
            LoadProducts(id);  

            List<Database.ResidentialBuildingReview> ratingsOfObservedProducts = _rentSiteContext.ResidentialBuildingReview.Where(x => x.ResidentialBuildingId == id).OrderBy(x => x.UserId).ToList();

            List<Database.ResidentialBuildingReview> similarMarks = new List<Database.ResidentialBuildingReview>();
            List<Database.ResidentialBuildingReview> similarMarks1 = new List<Database.ResidentialBuildingReview>();

            List<Database.ResidentialBuilding> recommendedProducts = new List<Database.ResidentialBuilding>();


            foreach (var item in products)
            {
                foreach (Database.ResidentialBuildingReview o in ratingsOfObservedProducts)
                {
                    if (item.Value.Where(x => x.UserId == o.UserId).Count() > 0)
                    {
                        similarMarks.Add(o);  
                        similarMarks1.Add(item.Value.Where(x => x.UserId == o.UserId).First());  
                    }
                }

                double similarity = GetSimilarity(similarMarks, similarMarks1);

                if (similarity > 0.5)
                {
                    recommendedProducts.Add(_rentSiteContext.ResidentialBuilding.Where(x => x.Id == item.Key).FirstOrDefault());
                }
                similarMarks.Clear();
                similarMarks1.Clear();
            }

            return _mapper.Map<List<Model.ResidentialBuilding>>(recommendedProducts);

        }

        private double GetSimilarity(List<Database.ResidentialBuildingReview> commonMarks1, List<Database.ResidentialBuildingReview> commonMarks2)
        {
            if (commonMarks1.Count != commonMarks2.Count)
            {
                return 0;
            }

            double counter = 0, denominator1 = 0, denominator2 = 0;

            for (int i = 0; i < commonMarks1.Count; i++)
            {
                counter += double.Parse(commonMarks1[i].Mark.ToString()) * double.Parse(commonMarks2[i].Mark.ToString());
                denominator1 += double.Parse(commonMarks1[i].Mark.ToString()) * double.Parse(commonMarks1[i].Mark.ToString());
                denominator2 += double.Parse(commonMarks2[i].Mark.ToString()) * double.Parse(commonMarks2[i].Mark.ToString());
            }

            denominator1 = Math.Sqrt(denominator1);
            denominator2 = Math.Sqrt(denominator2);

            double counter1 = denominator1 * denominator2;

            if (counter1 == 0)
            {
                return 0;
            }
            return counter / counter1;
        }

        private void LoadProducts(int id)
        {
            Database.ResidentialBuilding apartment = _rentSiteContext.ResidentialBuilding.Find(id);
            if (apartment == null)
            {
                return;  
            }
            List<Database.ResidentialBuilding> listOfSimilarApartments = _rentSiteContext.ResidentialBuilding.Where(x => x.Rented == false && x.Id != id && x.CityId == apartment.CityId).ToList();  
            List<Database.ResidentialBuildingReview> marks;

            foreach (Database.ResidentialBuilding apartment1 in listOfSimilarApartments)
            {
                marks = _rentSiteContext.ResidentialBuildingReview.Where(x => x.ResidentialBuildingId == apartment1.Id).OrderBy(x => x.UserId).ToList();
                if (marks.Count > 0)
                {
                    products.Add(apartment1.Id, marks);
                }
            }
        }
    }
}
