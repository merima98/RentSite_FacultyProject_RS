using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Database
{
    public partial class RentSiteContext
    {
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

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {


            WebAPI.Database.City city = new WebAPI.Database.City()
            {
                Id = 1,
                Name = "Blagaj"
            };
            modelBuilder.Entity<City>().HasData(city);



            WebAPI.Database.City city1 = new WebAPI.Database.City()
            {
                Id = 2,
                Name = "Mostar"
            };
            modelBuilder.Entity<City>().HasData(city1);




            WebAPI.Database.City city2 = new WebAPI.Database.City()
            {
                Id = 3,
                Name = "Stolac"
            };
            modelBuilder.Entity<City>().HasData(city2);



            WebAPI.Database.City city3 = new WebAPI.Database.City()
            {
                Id = 4,
                Name = "Pocitelj"
            };
            modelBuilder.Entity<City>().HasData(city3);


            WebAPI.Database.LineOfTransport lineOfTransport = new LineOfTransport()
            {
                Id = 1,
                Name = "10"
            };
            modelBuilder.Entity<LineOfTransport>().HasData(lineOfTransport);




            WebAPI.Database.LineOfTransport lineOfTransport1 = new LineOfTransport()
            {
                Id = 2,
                Name = "11"
            };
            modelBuilder.Entity<LineOfTransport>().HasData(lineOfTransport1);




            WebAPI.Database.LineOfTransport lineOfTransport2 = new LineOfTransport()
            {
                Id = 3,
                Name = "12"
            };
            modelBuilder.Entity<LineOfTransport>().HasData(lineOfTransport2);



            WebAPI.Database.LineOfTransport lineOfTransport3 = new LineOfTransport()
            {
                Id = 4,
                Name = "13"
            };
            modelBuilder.Entity<LineOfTransport>().HasData(lineOfTransport3);


            WebAPI.Database.LineOfTransport lineOfTransport4 = new LineOfTransport()
            {
                Id = 5,
                Name = "6"
            };
            modelBuilder.Entity<LineOfTransport>().HasData(lineOfTransport4);



            WebAPI.Database.LineOfTransport lineOfTransport5 = new LineOfTransport()
            {
                Id = 6,
                Name = "2"
            };
            modelBuilder.Entity<LineOfTransport>().HasData(lineOfTransport5);





            WebAPI.Database.TypeOfResidentialBuilding typeOfResidentialBuilding = new TypeOfResidentialBuilding()
            {
                Id = 1,
                Name = "Home"
            };
            modelBuilder.Entity<TypeOfResidentialBuilding>().HasData(typeOfResidentialBuilding);


            WebAPI.Database.TypeOfResidentialBuilding typeOfResidentialBuilding1 = new TypeOfResidentialBuilding()
            {
                Id = 2,
                Name = "Flat"
            };
            modelBuilder.Entity<TypeOfResidentialBuilding>().HasData(typeOfResidentialBuilding1);

            WebAPI.Database.TypeOfResidentialBuilding typeOfResidentialBuilding2 = new TypeOfResidentialBuilding()
            {
                Id = 3,
                Name = "Cottage"
            };
            modelBuilder.Entity<TypeOfResidentialBuilding>().HasData(typeOfResidentialBuilding2);



            WebAPI.Database.TypeOfRoom typeOfRoom = new TypeOfRoom()
            {
                Id = 1,
                Name = "Jednokrevetna",
                NumberOfBeds = 1
            };
            modelBuilder.Entity<TypeOfRoom>().HasData(typeOfRoom);

            WebAPI.Database.TypeOfRoom typeOfRoom1 = new TypeOfRoom()
            {
                Id = 2,
                Name = "Dvokrevetna",
                NumberOfBeds = 2
            };
            modelBuilder.Entity<TypeOfRoom>().HasData(typeOfRoom1);

            WebAPI.Database.TypeOfRoom typeOfRoom2 = new TypeOfRoom()
            {
                Id = 3,
                Name = "Trokrevetna",
                NumberOfBeds = 3
            };
            modelBuilder.Entity<TypeOfRoom>().HasData(typeOfRoom2);



            WebAPI.Database.TypeOfUser typeOfUser = new TypeOfUser()
            {
                Id = 1,
                Name = "Administrator"
            };
            modelBuilder.Entity<TypeOfUser>().HasData(typeOfUser);

            WebAPI.Database.TypeOfUser typeOfUser1 = new TypeOfUser()
            {
                Id = 2,
                Name = "User"
            };
            modelBuilder.Entity<TypeOfUser>().HasData(typeOfUser1);


            WebAPI.Database.User user = new User()
            {
                Id = 1,
                TypeOfUserId = 1,
                Status = true,


                FirstName = "Desktop name",
                LastName = "Desktop last name",
                Email = "user@gmail.com",
                PhoneNumber = "0322 - 564 -456",
                Username = "desktop"
            };
            user.PasswordSalt = GenerateSalt();
            user.PasswordHash = GenerateHash(user.PasswordSalt, "test");

            modelBuilder.Entity<User>().HasData(user);



            WebAPI.Database.User user1 = new User()
            {
                Id = 2,
                TypeOfUserId = 2,
                Status = true,
                FirstName = "Merima",
                LastName = "Ceranic",
                Email = "mobile@gmail.com",
                PhoneNumber = "0322 - 564 -456",
                Username = "mobile"
            };
            user1.PasswordSalt = GenerateSalt();
            user1.PasswordHash = GenerateHash(user1.PasswordSalt, "test");
            modelBuilder.Entity<User>().HasData(user1);


            WebAPI.Database.User user2 = new User()
            {
                Id = 3,
                TypeOfUserId = 2,
                Status = true,
                FirstName = "Jimm",
                LastName = "Tommy",
                Email = "jimm@gmail.com",
                PhoneNumber = "0322 - 564 -456",
                Username = "jimm"
            };
            user2.PasswordSalt = GenerateSalt();
            user2.PasswordHash = GenerateHash(user2.PasswordSalt, "test");
            modelBuilder.Entity<User>().HasData(user2);


            WebAPI.Database.User user3 = new User()
            {
                Id = 4,
                TypeOfUserId = 2,
                Status = true,
                FirstName = "Ammy",
                LastName = "Tomphson",
                Email = "ammy@gmail.com",
                PhoneNumber = "0322 - 564 -456",
                Username = "ammy"
            };
            user3.PasswordSalt = GenerateSalt();
            user3.PasswordHash = GenerateHash(user3.PasswordSalt, "test");

            modelBuilder.Entity<User>().HasData(user3);


            WebAPI.Database.Room room = new Room()
            {
                Id = 1,
                Address = "Mladena Balorde 5",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 1,
                DateOfPublication = new DateTime(2020, 02, 02),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Jednokrevetna soba za studenta",
                Floor = 1,
                NewlyBuilt = true,
                Picture = File.ReadAllBytes("img/slikaSobe.jpg"),
                Price = 100,
                Rented = false,
                TypeOfHeating = "Grijanje na struju",
                TypeOfRoomId = 1
            };

            modelBuilder.Entity<Room>().HasData(room);

            WebAPI.Database.Room room1 = new Room()
            {
                Id = 2,
                Address = "Mladena Balorde 7",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 1,
                DateOfPublication = new DateTime(2020, 02, 02),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Jednokrevetna soba za studenta u blizini fakulteta",
                Floor = 1,
                NewlyBuilt = true,
                Picture = File.ReadAllBytes("img/slikaSobaRS.jpg"),
                Price = 100,
                Rented = false,
                TypeOfHeating = "Grijanje na struju",
                TypeOfRoomId = 1
            };
            modelBuilder.Entity<Room>().HasData(room1);


            WebAPI.Database.Room room2 = new Room()
            {
                Id = 3,
                Address = "Mladena Balorde 9",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 1,
                DateOfPublication = new DateTime(2020, 02, 02),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Jednokrevetna soba za studenta u blizini zdravstvene ustanove",
                Floor = 1,
                NewlyBuilt = true,
                Picture = File.ReadAllBytes("img/slikasobe1.jpg"),
                Price = 100,
                Rented = false,
                TypeOfHeating = "Grijanje na struju",
                TypeOfRoomId = 1
            };
            modelBuilder.Entity<Room>().HasData(room2);

            WebAPI.Database.Room room3 = new Room()
            {
                Id = 4,
                Address = "Blagaj bb",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 1,
                DateOfPublication = new DateTime(2020, 02, 02),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Jednokrevetna soba za studenta u Blagaju",
                Floor = 1,
                NewlyBuilt = true,
                Picture = File.ReadAllBytes("img/slikasobe1.jpg"),
                Price = 100,
                Rented = false,
                TypeOfHeating = "Grijanje na struju",
                TypeOfRoomId = 1
            };
            modelBuilder.Entity<Room>().HasData(room3);


            WebAPI.Database.Room room4 = new Room()
            {
                Id = 5,
                Address = "Titova bb",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 2,
                DateOfPublication = new DateTime(2020, 02, 02),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Dvokrevetna soba u blizini FIT-a",
                Floor = 1,
                NewlyBuilt = true,
                Picture = File.ReadAllBytes("img/slikasobe1.jpg"),
                Price = 100,
                Rented = false,
                TypeOfHeating = "Grijanje na struju",
                TypeOfRoomId = 2
            };
            modelBuilder.Entity<Room>().HasData(room4);

            WebAPI.Database.Room room5 = new Room()
            {
                Id = 6,
                Address = "Titova 45",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 2,
                DateOfPublication = new DateTime(2020, 02, 02),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Dvokrevetna soba u blizini UNMO-a",
                Floor = 1,
                NewlyBuilt = true,
                Picture = File.ReadAllBytes("img/slikasobe1.jpg"),
                Price = 100,
                Rented = false,
                TypeOfHeating = "Grijanje na struju",
                TypeOfRoomId = 2
            };
            modelBuilder.Entity<Room>().HasData(room5);

            WebAPI.Database.Room room6 = new Room() //for rented
            {
                Id = 7,
                Address = "Titova 45",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 2,
                DateOfPublication = new DateTime(2020, 02, 02),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Dvokrevetna soba u blizini UNMO-a",
                Floor = 1,
                NewlyBuilt = true,
                Picture = File.ReadAllBytes("img/slikasobe1.jpg"),
                Price = 100,
                Rented = true,
                TypeOfHeating = "Grijanje na struju",
                TypeOfRoomId = 2
            };
            modelBuilder.Entity<Room>().HasData(room6);

            WebAPI.Database.Room room7 = new Room()
            {
                Id = 8,
                Address = "Blagaj bb",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 1,
                DateOfPublication = new DateTime(2020, 02, 02),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Jednokrevetna soba u Blagaju",
                Floor = 1,
                NewlyBuilt = true,
                Picture = File.ReadAllBytes("img/slikasobe1.jpg"),
                Price = 100,
                Rented = true,
                TypeOfHeating = "Grijanje na struju",
                TypeOfRoomId = 1
            };
            modelBuilder.Entity<Room>().HasData(room7);

            //adding to rented
            WebAPI.Database.RentedRooms rented1 = new RentedRooms()
            {
                BeginRentalDate = new DateTime(2020, 06, 28),
                EndRentalDate = new DateTime(9999, 12, 31),
                Id = 1,
                RoomId = 8,
                UserId = 2,
                Year = 2020
            };

            modelBuilder.Entity<RentedRooms>().HasData(rented1);

            WebAPI.Database.RentedRooms rented2 = new RentedRooms()
            {
                BeginRentalDate = new DateTime(2020, 06, 28),
                EndRentalDate = new DateTime(9999, 12, 31),
                Id = 2,
                RoomId = 7,
                UserId = 2,
                Year = 2020
            };
            modelBuilder.Entity<RentedRooms>().HasData(rented2);


            //adding apartments
            WebAPI.Database.ResidentialBuilding residential = new ResidentialBuilding()
            {
                Id = 1,
                Address = "Dzemala Bijedica bb",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 2,
                DateOfPublication = new DateTime(2020, 12, 12),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Kuca u gradu",
                Floor = 5,
                NewlyBuilt = true,
                NubmerOfFloors = 5,
                NumberOfRooms = 4,
                Picture = File.ReadAllBytes("img/slikastana1.jpg"),
                Price = 150,
                Rented = false,
                TypeOfHeating = "Grijanje na struju",
                TypeOfResidentialBuildingId = 1
            };
            modelBuilder.Entity<ResidentialBuilding>().HasData(residential);



            WebAPI.Database.ResidentialBuilding residential1 = new ResidentialBuilding()
            {
                Id = 2,
                Address = "Dzemala Bijedica 23",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 1,
                DateOfPublication = new DateTime(2020, 12, 12),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Jednosoban stan u gradu",
                Floor = 5,
                NewlyBuilt = true,
                NubmerOfFloors = 5,
                NumberOfRooms = 4,
                Picture = File.ReadAllBytes("img/slikastana1.jpg"),
                Price = 150,
                Rented = false,
                TypeOfHeating = "Grijanje na struju",
                TypeOfResidentialBuildingId = 2
            };
            modelBuilder.Entity<ResidentialBuilding>().HasData(residential1);


            WebAPI.Database.ResidentialBuilding residential2 = new ResidentialBuilding()
            {
                Id = 3,
                Address = "Mladena Balorde 45",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 1,
                DateOfPublication = new DateTime(2020, 12, 12),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Dvosoban stan u gradu",
                Floor = 5,
                NewlyBuilt = true,
                NubmerOfFloors = 5,
                NumberOfRooms = 4,
                Picture = File.ReadAllBytes("img/slikastana2.jpg"),
                Price = 150,
                Rented = false,
                TypeOfHeating = "Grijanje na struju",
                TypeOfResidentialBuildingId = 2
            };
            modelBuilder.Entity<ResidentialBuilding>().HasData(residential2);

            WebAPI.Database.ResidentialBuilding residential3 = new ResidentialBuilding()
            {
                Id = 4,
                Address = "Mladena Balorde 45",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 2,
                DateOfPublication = new DateTime(2020, 12, 12),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Kuca u gradu sa pogledom na Neretvu",
                Floor = 5,
                NewlyBuilt = true,
                NubmerOfFloors = 5,
                NumberOfRooms = 4,
                Picture = File.ReadAllBytes("img/slikastana2.jpg"),
                Price = 150,
                Rented = false,
                TypeOfHeating = "Grijanje na struju",
                TypeOfResidentialBuildingId = 1
            };
            modelBuilder.Entity<ResidentialBuilding>().HasData(residential3);


            WebAPI.Database.ResidentialBuilding residential4 = new ResidentialBuilding()
            {
                Id = 5,
                Address = "Mladena Balorde 45",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 1,
                DateOfPublication = new DateTime(2020, 12, 12),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Kuca u gradu sa pogledom na Bunu",
                Floor = 5,
                NewlyBuilt = true,
                NubmerOfFloors = 5,
                NumberOfRooms = 4,
                Picture = File.ReadAllBytes("img/slikastana2.jpg"),
                Price = 150,
                Rented = true,
                TypeOfHeating = "Grijanje na struju",
                TypeOfResidentialBuildingId = 1
            };
            modelBuilder.Entity<ResidentialBuilding>().HasData(residential4);

            WebAPI.Database.ResidentialBuilding residential5 = new ResidentialBuilding()
            {
                Id = 6,
                Address = "Mladena Balorde 45",
                Area = "Mostar",
                ArmoredDoor = true,
                CityId = 2,
                DateOfPublication = new DateTime(2020, 12, 12),
                DateOfRenewal = new DateTime(2020, 01, 01),
                Description = "Jednosoban stan u Mostaru",
                Floor = 5,
                NewlyBuilt = true,
                NubmerOfFloors = 5,
                NumberOfRooms = 4,
                Picture = File.ReadAllBytes("img/slikastana2.jpg"),
                Price = 150,
                Rented = true,
                TypeOfHeating = "Grijanje na struju",
                TypeOfResidentialBuildingId = 2
            };
            modelBuilder.Entity<ResidentialBuilding>().HasData(residential5);

            //dodavanje rentanih apartmana:
            WebAPI.Database.RentedResidentialBuilding rentedResidentialBuilding = new RentedResidentialBuilding()
            {
                Id = 1,
                BeginRentalDate = new DateTime(2020, 02, 02),
                EndRentalDate = new DateTime(9999, 12, 31),
                ResidentialBuildingId = 6,
                UserId = 2,
                Year = 2020
            };
            modelBuilder.Entity<RentedResidentialBuilding>().HasData(rentedResidentialBuilding);

            WebAPI.Database.RentedResidentialBuilding rentedResidentialBuilding1 = new RentedResidentialBuilding()
            {
                Id = 2,
                BeginRentalDate = new DateTime(2020, 02, 02),
                EndRentalDate = new DateTime(9999, 12, 31),
                ResidentialBuildingId = 5,
                UserId = 2,
                Year = 2020
            };
            modelBuilder.Entity<RentedResidentialBuilding>().HasData(rentedResidentialBuilding1);


            //dodavanje review-a za apartmane:

            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview = new ResidentialBuildingReview()
            {
                Id = 1,
                Mark = 5,
                ResidentialBuildingId = 1,
                UserId = 1
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview);


            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview1 = new ResidentialBuildingReview()
            {
                Id = 2,
                Mark = 5,
                ResidentialBuildingId = 1,
                UserId = 3
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview1);

            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview2 = new ResidentialBuildingReview()
            {
                Id = 3,
                Mark = 5,
                ResidentialBuildingId = 1,
                UserId = 4
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview2);

            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview3 = new ResidentialBuildingReview()
            {
                Id = 4,
                Mark = 5,
                ResidentialBuildingId = 2,
                UserId = 4
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview3);

            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview4 = new ResidentialBuildingReview()
            {
                Id = 5,
                Mark = 5,
                ResidentialBuildingId = 2,
                UserId = 3
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview4);

            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview5 = new ResidentialBuildingReview()
            {
                Id = 6,
                Mark = 5,
                ResidentialBuildingId = 2,
                UserId = 1
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview5);

            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview6 = new ResidentialBuildingReview()
            {
                Id = 7,
                Mark = 5,
                ResidentialBuildingId = 3,
                UserId = 1
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview6);


            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview7 = new ResidentialBuildingReview()
            {
                Id = 8,
                Mark = 5,
                ResidentialBuildingId = 3,
                UserId = 3
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview7);

            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview8 = new ResidentialBuildingReview()
            {
                Id = 9,
                Mark = 5,
                ResidentialBuildingId = 3,
                UserId = 4
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview8);

            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview9 = new ResidentialBuildingReview()
            {
                Id = 10,
                Mark = 5,
                ResidentialBuildingId = 4,
                UserId = 1
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview9);

            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview10 = new ResidentialBuildingReview()
            {
                Id = 11,
                Mark = 5,
                ResidentialBuildingId = 4,
                UserId = 3
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview10);


            WebAPI.Database.ResidentialBuildingReview residentialBuildingReview11 = new ResidentialBuildingReview()
            {
                Id = 12,
                Mark = 5,
                ResidentialBuildingId = 4,
                UserId = 4
            };
            modelBuilder.Entity<ResidentialBuildingReview>().HasData(residentialBuildingReview11);

            //dodavanje podataka za review soba:

            WebAPI.Database.RoomReview roomReview = new RoomReview()
            {
                Id = 1,
                Mark = 5,
                RoomId = 1,
                UserId = 1
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview);

            WebAPI.Database.RoomReview roomReview1 = new RoomReview()
            {
                Id = 2,
                Mark = 5,
                RoomId = 1,
                UserId = 3
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview1);

            WebAPI.Database.RoomReview roomReview2 = new RoomReview()
            {
                Id = 3,
                Mark = 5,
                RoomId = 1,
                UserId = 4
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview2);


            WebAPI.Database.RoomReview roomReview3 = new RoomReview()
            {
                Id = 4,
                Mark = 5,
                RoomId = 2,
                UserId = 1
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview3);

            WebAPI.Database.RoomReview roomReview4 = new RoomReview()
            {
                Id = 5,
                Mark = 5,
                RoomId = 2,
                UserId = 3
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview4);

            WebAPI.Database.RoomReview roomReview5 = new RoomReview()
            {
                Id = 6,
                Mark = 5,
                RoomId = 2,
                UserId = 4
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview5);

            WebAPI.Database.RoomReview roomReview6 = new RoomReview()
            {
                Id = 7,
                Mark = 5,
                RoomId = 3,
                UserId = 1
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview6);

            WebAPI.Database.RoomReview roomReview7 = new RoomReview()
            {
                Id = 8,
                Mark = 5,
                RoomId = 3,
                UserId = 3
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview7);

            WebAPI.Database.RoomReview roomReview8 = new RoomReview()
            {
                Id = 9,
                Mark = 5,
                RoomId = 3,
                UserId = 4
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview8);

            WebAPI.Database.RoomReview roomReview9 = new RoomReview()
            {
                Id = 10,
                Mark = 5,
                RoomId = 4,
                UserId = 1
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview9);


            WebAPI.Database.RoomReview roomReview10 = new RoomReview()
            {
                Id = 11,
                Mark = 5,
                RoomId = 4,
                UserId = 3
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview10);

            WebAPI.Database.RoomReview roomReview11 = new RoomReview()
            {
                Id = 12,
                Mark = 5,
                RoomId = 4,
                UserId = 4
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview11);

            WebAPI.Database.RoomReview roomReview13 = new RoomReview()
            {
                Id = 14,
                Mark = 5,
                RoomId = 5,
                UserId = 1
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview13);

            WebAPI.Database.RoomReview roomReview14 = new RoomReview()
            {
                Id = 15,
                Mark = 5,
                RoomId = 5,
                UserId = 3
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview14);

            WebAPI.Database.RoomReview roomReview15 = new RoomReview()
            {
                Id = 16,
                Mark = 5,
                RoomId = 5,
                UserId = 4
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview15);

            WebAPI.Database.RoomReview roomReview16 = new RoomReview()
            {
                Id = 17,
                Mark = 5,
                RoomId = 6,
                UserId = 1
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview16);


            WebAPI.Database.RoomReview roomReview17 = new RoomReview()
            {
                Id = 18,
                Mark = 5,
                RoomId = 6,
                UserId = 3
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview17);

            WebAPI.Database.RoomReview roomReview18 = new RoomReview()
            {
                Id = 19,
                Mark = 5,
                RoomId = 6,
                UserId = 4
            };
            modelBuilder.Entity<RoomReview>().HasData(roomReview18);

        }
    }
}
