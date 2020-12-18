using Microsoft.EntityFrameworkCore;
using Rent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rent.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected RentalContext ctx;

        public Repository(RentalContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public abstract void DeleteOne(int id);
        public abstract T GetOne(int id);
    }

    public class RentRepository : Repository<Rental>, IRentRepository
    {
        public RentRepository(RentalContext ctx) : base(ctx) { }

        public void ChangeGameRef(int id, int newGameRef)
        {
            var rent = GetOne(id);
            rent.GameRef = newGameRef;
            ctx.SaveChanges();
        }

        public void ChangePersonRef(int id, int newPersonRef)
        {
            var rent = GetOne(id);
            rent.PersonRef = newPersonRef;
            ctx.SaveChanges();
        }

        public void ChangeRentDate(int id, DateTime newRentDate)
        {
            var rent = GetOne(id);
            rent.RentDate = newRentDate;
            ctx.SaveChanges();
        }

        public void ChangeReturnDate(int id, DateTime newReturnDate)
        {
            var rent = GetOne(id);
            rent.ReturnDate = newReturnDate;
            ctx.SaveChanges();
        }

        public override void DeleteOne(int id)
        {
            ctx.Set<Rental>().Remove(GetOne(id));
            ctx.SaveChanges();
        }

        public override Rental GetOne(int id)
        {
            try
            {
                return GetAll().SingleOrDefault(x => x.Id.Equals(id));
            }
            catch(ArgumentException)
            {
                throw new ArgumentException("Data on this index does not exist.");
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Data on this index does not exist.");
            }
        }

        public string MostFine()
        {
            string r = "";

            var all = GetAll();
            int maxFine = 0;
            int id = 0;
            string name = "";
            foreach (var item in all)
            {
                if (item.DelayFine > maxFine)
                {
                    maxFine = item.DelayFine;
                    id = item.Id;
                    name = item.Person.Name;
                }
            }
            var rent = GetOne(id);
            r += $"{name} has the biggest fine of ${rent.DelayFine}.";

            return r;
        }

        public string MostRentedGame()
        {
            string r = "";
            //VideoGameRepository gRepo = new VideoGameRepository();
            //var all = gRepo.GetAll();

            //int maxCount = 0;
            //int id = 0;
            //foreach (var item in all)
            //{
            //    if(item.Rentals.Count() > maxCount)
            //    {
            //        maxCount = item.Rentals.Count();
            //        id = item.Id;
            //    }
            //}

            //var games = from x in all
            //         group x by x.Rentals.Count into g
            //         select new
            //         {
            //             _GROUP = g.Key,
            //             _COUNT =g.Count()
            //         };

            //var games2 = from x in games
            //             orderby x._COUNT
            //             select x;
            
            //int key = gameKey._GROUP;
            //int count = maxCount._COUNT;

            //r += $"{gRepo.GetOne(id).Name} has been rented the most times, a total of {maxCount} times.";

            return r;
        }

        public string MostRentsByPerson()
        {
            string r = "";

            //var all = GetAll();
            //List<Person> p = new List<Person>();
            //int[] Counts = new int[all.Count()];
            //int id = 0;
            //foreach (var item in all)
            //{
            //    id = 0;
            //    foreach (var reference in all)
            //    {
            //        if (p.Contains(item.Person))
            //        {
            //            Counts[id]++;
            //        }
            //    }
            //    id++;
            //}

            //int maxCount = 0;
            //for (int i = 0; i < Counts.Length; i++)
            //{
            //    if(Counts[i] > maxCount)
            //    {
            //        maxCount = Counts[i];
            //        id = i;
            //    }
            //}

            //r += $"{GetOne(id).Person.Name} has the most rents, a total of {maxCount} rents.";
            return r;
        }

        public void NewRent(Rental r)
        {
            ctx.Set<Rental>().Add(r);
            ctx.SaveChanges();
        }
    }

    public class VideoGameRepository : Repository<VideoGame>, IVideoGameRepository
    {
        public VideoGameRepository(RentalContext ctx) : base(ctx) { }

        public void ChangeGameName(int id, string newName)
        {
            var game = GetOne(id);
            game.Name = newName;
            ctx.SaveChanges();
        }

        public void ChangeGamePublisher(int id, string newPublisher)
        {
            var game = GetOne(id);
            game.Publisher = newPublisher;
            ctx.SaveChanges();
        }

        public void ChangeGameRating(int id, int newRating)
        {
            var game = GetOne(id);
            game.Rating = newRating;
            ctx.SaveChanges();
        }

        public void ChangeGameReleaseDate(int id, DateTime newReleaseDate)
        {
            var game = GetOne(id);
            game.ReleaseDate = newReleaseDate;
            ctx.SaveChanges();
        }

        public override VideoGame GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }

        public void NewGame(string name, DateTime releaseDate, string publisher, int rating)
        {
            VideoGame v = new VideoGame()
            {
                Name = name,
                ReleaseDate =
                releaseDate,
                Publisher =
                publisher,
                Rating = rating
            };
            ctx.Set<VideoGame>().Add(v);
            ctx.SaveChanges();
        }

        public override void DeleteOne(int id)
        {
            var toRemove = GetOne(id);

            foreach (var item in toRemove.Rentals)
            {
                ctx.Set<Rental>().Remove(item);
            }

            ctx.Set<VideoGame>().Remove(GetOne(id));
            ctx.SaveChanges();
        }
    }

    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(RentalContext ctx) : base(ctx) { }

        public override Person GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }

        public void ChangeName(int id, string newName)
        {
            var person = GetOne(id);
            person.Name = newName;
            ctx.SaveChanges();
        }

        public void NewPerson( string name, DateTime birthDate)
        {
            Person p = new Person()
            { 
                Name = name,
                BirthDate = birthDate
            };
            ctx.Set<Person>().Add(p);
            ctx.SaveChanges();
        }

        public void ChangePersonName(int id, string newName)
        {
            var person = GetOne(id);
            person.Name = newName;
            ctx.SaveChanges();
        }

        public void ChangePersonBirthDate(int id, DateTime newBirthDate)
        {
            var person = GetOne(id);
            person.BirthDate = newBirthDate;
            ctx.SaveChanges();
        }

        public override void DeleteOne(int id)
        {
            var toRemove = GetOne(id);

            foreach (var item in toRemove.Rentals)
            {
                ctx.Set<Rental>().Remove(item);
            }

            ctx.Set<Person>().Remove(GetOne(id));
            ctx.SaveChanges();
        }
    }
}
