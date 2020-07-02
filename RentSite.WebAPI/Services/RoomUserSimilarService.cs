using AutoMapper;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class RoomUserSimilarService :ISimilarRooms
    {

        protected readonly RentSiteContext _rentSiteContext;
        protected readonly IMapper _mapper;

        public RoomUserSimilarService(RentSiteContext rentSiteContext, IMapper mapper)
        {
            _rentSiteContext = rentSiteContext;
            _mapper = mapper;
        }

        Dictionary<int, List<Database.RoomReview>> products = new Dictionary<int, List<RoomReview>>();

        public  List<Model.Room> GetAll(int  id)
        {

            LoadProducts(id);   
            List<Database.RoomReview> ratingsOfObservedProducts = _rentSiteContext.RoomReview.Where(x => x.RoomId == id).OrderBy(x => x.UserId).ToList();

            List<Database.RoomReview> commonMarks1 = new List<RoomReview>();
            List<Database.RoomReview> commonMarks2 = new List<RoomReview>();


            List<Database.Room> recommendedProducts = new List<Room>();


            foreach (var item in products)
            {
                foreach (RoomReview o in ratingsOfObservedProducts)
                {
                    if (item.Value.Where(x=> x.UserId== o.UserId).Count()>0)
                    {
                        commonMarks1.Add(o);  
                        commonMarks2.Add(item.Value.Where(x => x.UserId == o.UserId).First());  
                    }
                }

                double similarity = GetSimilarity(commonMarks1, commonMarks2);

                if (similarity > 0.5)
                {
                    recommendedProducts.Add(_rentSiteContext.Room.Where(x => x.Id == item.Key).FirstOrDefault());
                }
                commonMarks1.Clear();
                commonMarks2.Clear();
            }
            
            return _mapper.Map<List<Model.Room>>(recommendedProducts);
        }

        private double GetSimilarity(List<RoomReview> commonMarks1, List<RoomReview> commonMarks2)
        {

            if (commonMarks1.Count!=commonMarks2.Count)
            {
                return 0;
            }

            double counter = 0 , denominator1 = 0, denominator2=0;

            for (int i = 0; i < commonMarks1.Count; i++)
            {
                counter += double.Parse(commonMarks1[i].Mark.ToString()) * double.Parse(commonMarks2[i].Mark.ToString());
                denominator1 += double.Parse(commonMarks1[i].Mark.ToString()) * double.Parse(commonMarks1[i].Mark.ToString());
                denominator2 += double.Parse(commonMarks2[i].Mark.ToString()) * double.Parse(commonMarks2[i].Mark.ToString());
            }

            denominator1 = Math.Sqrt(denominator1);
            denominator2 = Math.Sqrt(denominator2);

            double counter1 = denominator1 * denominator2;

            if ( counter1 ==0)
            {
                return 0;
            }
            return counter/counter1;
        }

        private void LoadProducts(int id)
        {

            Database.Room room = _rentSiteContext.Room.Find(id);
            if (room == null)
            {
                return;  
            }
            List<Database.Room> listOfSimilarRooms = _rentSiteContext.Room.Where(x => x.Rented == false && x.Id!=id  && x.CityId == room.CityId).ToList();  //oni koji su razlicii i oni koji dolaze iz istog grada

            List<Database.RoomReview> marks;

            foreach (Database.Room room1 in listOfSimilarRooms)
            {
                marks = _rentSiteContext.RoomReview.Where(x => x.RoomId == room1.Id).OrderBy(x => x.UserId).ToList();
                if (marks.Count>0)
                {
                    products.Add(room1.Id, marks);
                }
            }

        }
    }
}
