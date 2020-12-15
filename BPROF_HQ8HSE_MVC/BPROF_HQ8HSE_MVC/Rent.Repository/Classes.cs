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
        protected DbContext ctx;

        public Repository(DbContext ctx)
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
        public RentRepository(DbContext ctx) : base(ctx) { }

        public void ChangeRentDate(int id, DateTime newRentDate)
        {
            var rent = GetOne(id);
            rent.RentDate = newRentDate;
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

        public void NewRent(int gameId, int personId, DateTime rentDate, DateTime returnDate)
        {
            Rental r = new Rental()
            {
                GameRef = gameId,
                PersonRef = personId,
                RentDate = rentDate,
                ReturnDate = returnDate
            };
            ctx.Set<Rental>().Add(r);
            ctx.SaveChanges();
        }
    }

    public class VideoGameRepository : Repository<VideoGame>, IVideoGameRepository
    {
        public VideoGameRepository(DbContext ctx) : base(ctx) { }

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
            RentRepository rentRepo = new RentRepository(ctx);
            List<int> refs = new List<int>();

            foreach (var item in toRemove.Rentals)
            {
                refs.Add(item.Id);
            }

            foreach (var item in refs)
            {
                rentRepo.DeleteOne(item);
            }

            ctx.Set<VideoGame>().Remove(GetOne(id));
            ctx.SaveChanges();
        }
    }

    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext ctx) : base(ctx) { }

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
            RentRepository rentRepo = new RentRepository(ctx);
            List<int> refs = new List<int>();

            foreach (var item in toRemove.Rentals)
            {
                refs.Add(item.Id);
            }

            foreach (var item in refs)
            {
                rentRepo.DeleteOne(item);
            }

            ctx.Set<Person>().Remove(GetOne(id));
            ctx.SaveChanges();
        }
    }
}
