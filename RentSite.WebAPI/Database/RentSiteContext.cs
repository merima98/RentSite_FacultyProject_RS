using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RentSite.WebAPI.Database
{
    public partial class RentSiteContext : DbContext
    {
        public RentSiteContext()
        {
        }

        public RentSiteContext(DbContextOptions<RentSiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttractiveObjects> AttractiveObjects { get; set; }
        public virtual DbSet<AttractiveObjectsRoom> AttractiveObjectsRoom { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<LineOfTransport> LineOfTransport { get; set; }
        public virtual DbSet<LineOfTransportResidentialBuilding> LineOfTransportResidentialBuilding { get; set; }
        public virtual DbSet<LineOfTransportRoom> LineOfTransportRoom { get; set; }
        public virtual DbSet<RentedResidentialBuilding> RentedResidentialBuilding { get; set; }
        public virtual DbSet<RentedRooms> RentedRooms { get; set; }
        public virtual DbSet<ResidentialBuilding> ResidentialBuilding { get; set; }
        public virtual DbSet<ResidentialBuildingReview> ResidentialBuildingReview { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomReview> RoomReview { get; set; }
        public virtual DbSet<TypeOfAttractiveObject> TypeOfAttractiveObject { get; set; }
        public virtual DbSet<TypeOfResidentialBuilding> TypeOfResidentialBuilding { get; set; }
        public virtual DbSet<TypeOfRoom> TypeOfRoom { get; set; }
        public virtual DbSet<TypeOfUser> TypeOfUser { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=RentSite;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttractiveObjects>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.TypeOfAttractiveObject)
                    .WithMany(p => p.AttractiveObjects)
                    .HasForeignKey(d => d.TypeOfAttractiveObjectId)
                    .HasConstraintName("fk_TypeOfAttractiveObjectId");
            });

            modelBuilder.Entity<AttractiveObjectsRoom>(entity =>
            {
                entity.ToTable("AttractiveObjects_Room");

                entity.HasOne(d => d.AttractiveObjects)
                    .WithMany(p => p.AttractiveObjectsRoom)
                    .HasForeignKey(d => d.AttractiveObjectsId)
                    .HasConstraintName("fk_AttractiveObjectsId");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.AttractiveObjectsRoom)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("fk_RoomId");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<LineOfTransport>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<LineOfTransportResidentialBuilding>(entity =>
            {
                entity.ToTable("LineOfTransport_ResidentialBuilding");

                entity.HasOne(d => d.LineOfTransport)
                    .WithMany(p => p.LineOfTransportResidentialBuilding)
                    .HasForeignKey(d => d.LineOfTransportId)
                    .HasConstraintName("fk_LineOfTransportRBId");

                entity.HasOne(d => d.ResidentialBuilding)
                    .WithMany(p => p.LineOfTransportResidentialBuilding)
                    .HasForeignKey(d => d.ResidentialBuildingId)
                    .HasConstraintName("fk_ResidentialBuildingId");
            });

            modelBuilder.Entity<LineOfTransportRoom>(entity =>
            {
                entity.ToTable("LineOfTransport_Room");

                entity.HasOne(d => d.LineOfTransport)
                    .WithMany(p => p.LineOfTransportRoom)
                    .HasForeignKey(d => d.LineOfTransportId)
                    .HasConstraintName("fk_LineOfTransportId");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.LineOfTransportRoom)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("fk_Room_LoTId");
            });

            modelBuilder.Entity<RentedResidentialBuilding>(entity =>
            {
                entity.ToTable("Rented_ResidentialBuilding");

                entity.Property(e => e.BeginRentalDate).HasColumnType("datetime");

                entity.Property(e => e.EndRentalDate).HasColumnType("datetime");

                entity.HasOne(d => d.ResidentialBuilding)
                    .WithMany(p => p.RentedResidentialBuilding)
                    .HasForeignKey(d => d.ResidentialBuildingId)
                    .HasConstraintName("fk_ResidentialBuilding_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RentedResidentialBuilding)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_UserId");
            });

            modelBuilder.Entity<RentedRooms>(entity =>
            {
                entity.ToTable("Rented_Rooms");

                entity.Property(e => e.BeginRentalDate).HasColumnType("datetime");

                entity.Property(e => e.EndRentalDate).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RentedRooms)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("fk_Room_RentedId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RentedRooms)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_User_RoomsId");
            });

            modelBuilder.Entity<ResidentialBuilding>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Area).HasMaxLength(200);

                entity.Property(e => e.DateOfPublication).HasColumnType("datetime");

                entity.Property(e => e.DateOfRenewal).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TypeOfHeating).HasMaxLength(500);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ResidentialBuilding)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("fk_CityRBId");

                entity.HasOne(d => d.TypeOfResidentialBuilding)
                    .WithMany(p => p.ResidentialBuilding)
                    .HasForeignKey(d => d.TypeOfResidentialBuildingId)
                    .HasConstraintName("fk_TypeOfResidentialBuildingIdId");
            });

            modelBuilder.Entity<ResidentialBuildingReview>(entity =>
            {
                entity.HasOne(d => d.ResidentialBuilding)
                    .WithMany(p => p.ResidentialBuildingReview)
                    .HasForeignKey(d => d.ResidentialBuildingId)
                    .HasConstraintName("fk_ResidentialBuildingReviewId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ResidentialBuildingReview)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_UserReviewId");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Area).HasMaxLength(200);

                entity.Property(e => e.DateOfPublication).HasColumnType("datetime");

                entity.Property(e => e.DateOfRenewal).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TypeOfHeating).HasMaxLength(500);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("fk_CityId");

                entity.HasOne(d => d.TypeOfRoom)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.TypeOfRoomId)
                    .HasConstraintName("fk_TypeOfRoomId");
            });

            modelBuilder.Entity<RoomReview>(entity =>
            {
                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomReview)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("fk_RoomReviewId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoomReview)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_RoomUserId");
            });

            modelBuilder.Entity<TypeOfAttractiveObject>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TypeOfResidentialBuilding>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeOfRoom>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeOfUser>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PasswordSalt).HasMaxLength(500);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(100);

                entity.HasOne(d => d.TypeOfUser)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.TypeOfUserId)
                    .HasConstraintName("fk_TypeOfUserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
