using System;
using Rent.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rent.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
    }

    public interface IRentRepository : IRepository<Rental>
    {
        //Methods for interacting with data layer
    }

    public interface IVideoGameRepository : IRepository<VideoGame>
    {

    }

    public interface IPersonRepository : IRepository<Person>
    {

    }
}
