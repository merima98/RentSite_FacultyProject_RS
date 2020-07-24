using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using RentSite.WebAPI.Security;
using RentSite.WebAPI.Services;

namespace RentSite.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);  //ovo cemo kasnije jos vidjeti

            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme , Id = "basicAuth"}
                        },
                        new string[]{ }
                    }
                });
            });

            services.AddAuthentication("BasicAuthentication")
             .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);



            var connection = Configuration.GetConnectionString("RentSite");
            services.AddDbContext<RentSiteContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IService<Model.TypeOfUser, object>, BaseService<Model.TypeOfUser, object, Database.TypeOfUser>>();
            services.AddScoped<IService<Model.ResidentialBuilding, object>, ApartmentsUserService>(); 
            services.AddScoped<ICRUDService<Model.ResidentialBuilding, ApartmentSearchRequest, ApartmentsInsertRequest, ApartmentsInsertRequest>, ApartmentsService>();
            services.AddScoped<ICRUDService<Model.Room, RoomSearchRequest, RoomInsertRequest, RoomInsertRequest>, RoomService>();
            services.AddScoped<IService<Model.AttractiveObjects, object>, BaseService<Model.AttractiveObjects, object, Database.AttractiveObjects>>();
            services.AddScoped<IService<Model.City, object>, BaseService<Model.City, object, Database.City>>();
            services.AddScoped<IService<Model.LineOfTransportResidentialBuilding, object>, BaseService<Model.LineOfTransportResidentialBuilding, object, Database.LineOfTransportResidentialBuilding>>();
            services.AddScoped<IService<Model.LineOfTransport, object>, BaseService<Model.LineOfTransport, object, Database.LineOfTransport>>();
            services.AddScoped<IService<Model.TypeOfResidentialBuilding, object>, BaseService<Model.TypeOfResidentialBuilding, object, Database.TypeOfResidentialBuilding>>();
            services.AddScoped<IService<Model.TypeOfRoom, object>, BaseService<Model.TypeOfRoom, object, Database.TypeOfRoom>>();
            services.AddScoped<IService<Model.RentedRooms, RoomSearchRequest>,RentedRoomsService>();
            services.AddScoped<IService<Model.RentedRooms, RoomUserSearchRequest>,RentedRoomUserService>();
            services.AddScoped<IService<Model.RentedResidentalBuilding, ApartmentSearchRequest>,RentedResidentialBuildingService>();
            services.AddScoped<IService<Model.Room, RoomUserSearchRequest>,RoomUserService>();  
            services.AddScoped<ICRUDService<Model.RentedRooms, RoomUserSearchRequest, RoomUserRent_InsertRequest, RoomUserUpdateRequest>, RoomUserRentService>();
            services.AddScoped<IService<Model.ResidentialBuilding, ApartmentUserSearchRequest>, UserApartmentService>();
            services.AddScoped<ICRUDService<Model.RentedResidentalBuilding, ApartmentUserSearchRequest, ApartmentUserRent_InsertRequest, ApartmentUserUpdateRequest>, ApartmentUserRentService>();
            services.AddScoped<ISimilarRooms, RoomUserSimilarService>();
            services.AddScoped<ISimilarApartments, ApartmentsUserSimilarService>();
            services.AddScoped<ICRUDService<Model.RoomReview, object, Model.RoomReview, object>, RoomAddMarkService>();
            services.AddScoped<ICRUDService<Model.ResidentialBuildingReview, object, Model.ResidentialBuildingReview, object>, ApartmentAddMarkService>();


            //kreiranje izvjestaja:
            services.AddScoped<IService<Model.ResidentalBuildingReport, YearSearchRequest>, ResidentalBuildingReportService>();
            services.AddScoped<IService<Model.ResidentalBuildingReportNoFiltered, object>, ApartmentNoFilteredReportService>();

            //rooms
            services.AddScoped<IService<Model.RoomsReport, YearSearchRequest>, RoomsReportService>();
            services.AddScoped<IService<Model.RoomsNoFilterReport, object>, RoomsNoFilterReportService>();

            //exam: 
            services.AddScoped<IService<Model.Room, Exam_FreeRooms_FROM_TO>, Exam_FreeRoomsService>();
            services.AddScoped<IService<Model.RentedRooms, Exam_RentedRoomsUsers_FROM_TO>, Exam_RentedRoomsUsers_Service>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "";
            });

            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
