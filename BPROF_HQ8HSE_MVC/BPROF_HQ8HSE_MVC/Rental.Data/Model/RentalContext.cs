using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Data
{
    public class RentalContext : DbContext
    {
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<VideoGame> Games { get; set; }
        public virtual DbSet<Person> People { get; set; }

        public RentalContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            if (!opt.IsConfigured)
            {
                opt.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;MultipleActiveResultSets=true;AttachDbFilename=|DataDirectory|\RentalDatabase.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            #region Data 

            Person p0 = new Person() { Id = 1, Name = "Mérleg Csaba", BirthDate = new DateTime(1982, 11, 05) };
            Person p1 = new Person() { Id = 2, Name = "Kertész Enikő", BirthDate = new DateTime(1994, 04, 22) };
            Person p2 = new Person() { Id = 3, Name = "Kárpáti Géza", BirthDate = new DateTime(1999, 10, 03) };
            Person p3 = new Person() { Id = 4, Name = "Fali Eliot", BirthDate = new DateTime(2003, 02, 28) };
            Person p4 = new Person() { Id = 5, Name = "Taps Éva", BirthDate = new DateTime(2000, 08, 22) };
            Person p5 = new Person() { Id = 6, Name = "Tali Gergő", BirthDate = new DateTime(1974, 06, 19) };
            Person p6 = new Person() { Id = 7, Name = "Földi Ramóna", BirthDate = new DateTime(1991, 07, 11) };
            Person p7 = new Person() { Id = 8, Name = "Kocsis Jácint", BirthDate = new DateTime(1950, 12, 03) };
            Person p8 = new Person() { Id = 9, Name = "Pécsi Zétény", BirthDate = new DateTime(2001, 01, 29) };
            Person p9 = new Person() { Id = 10, Name = "Bakáts Emília Lilla", BirthDate = new DateTime(1997, 04, 16) };
            Person p10 = new Person() { Id = 11, Name = "Nyári András Örs", BirthDate = new DateTime(1999, 11, 02) };
            Person p11 = new Person() { Id = 12, Name = "Szilvádi Róbert", BirthDate = new DateTime(1987, 07, 17) };

            VideoGame vg0 = new VideoGame() { Id = 101, Name = "Kerbal Space Program", ReleaseDate = new DateTime(2011, 06, 20), Publisher = "Squad", Rating = 7 };
            VideoGame vg1 = new VideoGame() { Id = 102, Name = "Far Cry 3", ReleaseDate = new DateTime(2012, 11, 29), Publisher = "Ubisoft", Rating = 10 };
            VideoGame vg2 = new VideoGame() { Id = 103, Name = "Far Cry 4", ReleaseDate = new DateTime(2014, 11, 18), Publisher = "Ubisoft", Rating = 9 };
            VideoGame vg3 = new VideoGame() { Id = 104, Name = "Far Cry 5", ReleaseDate = new DateTime(2018, 03, 27), Publisher = "Ubisoft", Rating = 6 };
            VideoGame vg4 = new VideoGame() { Id = 105, Name = "Oxygen not Included", ReleaseDate = new DateTime(2019, 07, 30), Publisher = "Klei Entertainment", Rating = 8 };
            VideoGame vg5 = new VideoGame() { Id = 106, Name = "Minecraft", ReleaseDate = new DateTime(2011, 11, 18), Publisher = "Mojang Studios", Rating = 9 };
            VideoGame vg6 = new VideoGame() { Id = 107, Name = "Don't Starve", ReleaseDate = new DateTime(2013, 04, 23), Publisher = "Klei Entertainment", Rating = 10 };
            VideoGame vg7 = new VideoGame() { Id = 108, Name = "Subnautica", ReleaseDate = new DateTime(2014, 12, 16), Publisher = "Unknown Worlds", Rating = 7 };
            VideoGame vg8 = new VideoGame() { Id = 109, Name = "Overcooked", ReleaseDate = new DateTime(2016, 08, 02), Publisher = "Ghost Town Games", Rating = 4 };
            VideoGame vg9 = new VideoGame() { Id = 110, Name = "Raft", ReleaseDate = new DateTime(2015, 05, 23), Publisher = "Redbeet interactive", Rating = 5 };

            Rental r0 = new Rental() { Id = 201, RentDate = new DateTime(2020, 02, 15), ReturnDate = new DateTime(2020, 03, 02) };
            Rental r1 = new Rental() { Id = 202, RentDate = new DateTime(2020, 03, 02), ReturnDate = new DateTime(2020, 05, 10) };
            Rental r2 = new Rental() { Id = 203, RentDate = new DateTime(2020, 05, 10), ReturnDate = new DateTime(2020, 05, 25) };
            Rental r3 = new Rental() { Id = 204, RentDate = new DateTime(2020, 03, 15), ReturnDate = new DateTime(2020, 04, 09) };
            Rental r4 = new Rental() { Id = 205, RentDate = new DateTime(2020, 06, 07), ReturnDate = new DateTime(2020, 06, 19) };
            Rental r5 = new Rental() { Id = 206, RentDate = new DateTime(2020, 10, 03), ReturnDate = new DateTime(2020, 12, 14) };
            Rental r6 = new Rental() { Id = 207, RentDate = new DateTime(2020, 11, 24) };
            Rental r7 = new Rental() { Id = 208, RentDate = new DateTime(2020, 11, 29) };
            Rental r8 = new Rental() { Id = 209, RentDate = new DateTime(2020, 12, 01) };
            Rental r9 = new Rental() { Id = 210, RentDate = new DateTime(2019, 01, 12), ReturnDate = new DateTime(2019, 02, 03) };
            Rental r10 = new Rental() { Id = 211, RentDate = new DateTime(2019, 01, 25), ReturnDate = new DateTime(2019,01,27) };
            Rental r11 = new Rental() { Id = 212, RentDate = new DateTime(2019, 02, 03) };
            Rental r12 = new Rental() { Id = 213, RentDate = new DateTime(2019, 02, 04), ReturnDate = new DateTime(2019, 02, 19) };
            Rental r13 = new Rental() { Id = 214, RentDate = new DateTime(2019, 02, 19), ReturnDate = new DateTime(2019, 06, 02) };
            Rental r14 = new Rental() { Id = 215, RentDate = new DateTime(2019, 04, 15), ReturnDate = new DateTime(2019, 07, 01) };
            Rental r15 = new Rental() { Id = 216, RentDate = new DateTime(2019, 05, 09), ReturnDate = new DateTime(2019, 05, 28) };
            Rental r16 = new Rental() { Id = 217, RentDate = new DateTime(2019, 08, 29), ReturnDate = new DateTime(2019, 10, 11) };
            Rental r17 = new Rental() { Id = 218, RentDate = new DateTime(2019, 11, 12), ReturnDate = new DateTime(2019, 12, 29) };

            r0.PersonRef = p0.Id;
            r1.PersonRef = p0.Id;
            r2.PersonRef = p0.Id;
            r3.PersonRef = p1.Id;
            r4.PersonRef = p2.Id;
            r5.PersonRef = p3.Id;
            r6.PersonRef = p4.Id;
            r7.PersonRef = p5.Id;
            r8.PersonRef = p6.Id;
            r9.PersonRef = p4.Id;
            r10.PersonRef = p11.Id;
            r11.PersonRef = p1.Id;
            r12.PersonRef = p10.Id;
            r13.PersonRef = p6.Id;
            r14.PersonRef = p9.Id;
            r15.PersonRef = p9.Id;
            r16.PersonRef = p8.Id;
            r17.PersonRef = p7.Id;

            r0.GameRef = vg0.Id;
            r1.GameRef = vg1.Id;
            r2.GameRef = vg2.Id;
            r3.GameRef = vg3.Id;
            r4.GameRef = vg4.Id;
            r5.GameRef = vg3.Id;
            r6.GameRef = vg5.Id;
            r7.GameRef = vg5.Id;
            r8.GameRef = vg6.Id;
            r9.GameRef = vg4.Id;
            r10.GameRef = vg7.Id;
            r11.GameRef = vg6.Id;
            r12.GameRef = vg6.Id;
            r13.GameRef = vg8.Id;
            r14.GameRef = vg8.Id;
            r15.GameRef = vg9.Id;
            r16.GameRef = vg3.Id;
            r17.GameRef = vg2.Id;

            #endregion

            mb.Entity<Rental>(entity =>
            {
                entity.HasOne(rental => rental.Game)
                .WithMany(game => game.Rentals)
                .HasForeignKey(rental => rental.GameRef)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            mb.Entity<Rental>(entity =>
            {
                entity.HasOne(rental => rental.Person)
                .WithMany(person => person.Rentals)
                .HasForeignKey(rental => rental.PersonRef)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            mb.Entity<Person>().HasData(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
            mb.Entity<VideoGame>().HasData(vg0, vg1, vg2, vg3, vg4, vg5, vg6, vg7, vg8, vg9);
            mb.Entity<Rental>().HasData(r0, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17);
        }
    }
}
