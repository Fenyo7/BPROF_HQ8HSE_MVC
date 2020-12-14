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

        public abstract T GetOne(int id);
    }

    public class RentRepository : Repository<Rental>, IRentRepository
    {
        public RentRepository(DbContext ctx) : base(ctx) { }

        public override Rental GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }
    }

    public class VideoGameRepository : Repository<VideoGame>, IVideoGameRepository
    {
        public VideoGameRepository(DbContext ctx) : base(ctx) { }

        public override VideoGame GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }
    }

    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext ctx) : base(ctx) { }

        public override Person GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
