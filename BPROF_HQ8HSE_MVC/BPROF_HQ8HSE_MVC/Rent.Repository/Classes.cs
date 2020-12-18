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
            int maxCount = 0;
            Rental rent = new Rental();

            foreach (var item in all)
            {
                if(item.DelayFine > maxCount)
                {
                    maxCount = item.DelayFine;
                    rent = item;
                }
            }

            r += $"{rent.Person.Name} has the biggest one time fine of ${maxCount}.";
            return r;
        }

        public string MostRentedGame()
        {
            string r = "";
            var all = GetAll();
            VideoGame game = new VideoGame();
            int maxRents = 0;
            foreach (var item in all)
            {
                if(item.Game.Rentals.Count() > maxRents)
                {
                    maxRents = item.Game.Rentals.Count();
                    game = item.Game;
                }
            }
            r += $"{game.Name} was rented the most times, a total of {maxRents} times.";
            return r;
        }

        public string MostRentsByPerson()
        {
            string r = "";

            var all = GetAll();
            Person p = new Person();
            int maxCount = 0;

            foreach (var item in all)
            {
                if(item.Person.Rentals.Count() > maxCount)
                {
                    maxCount = item.Person.Rentals.Count();
                    p = item.Person;
                }
            }

            r += $"{p.Name} has the most rents, a total of {maxCount} rents.";
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
