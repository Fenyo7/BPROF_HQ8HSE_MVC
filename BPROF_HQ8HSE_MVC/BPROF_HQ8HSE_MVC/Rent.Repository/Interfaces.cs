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
        void NewRent(int id, int gameId, int personId, DateTime rentDate, DateTime returnDate);
        void ChangeRentDate(int id, DateTime newRentDate);
    }

    public interface IVideoGameRepository : IRepository<VideoGame>
    {
        void NewGame(int id, string name, DateTime releaseDate, string publisher, int rating);
        void ChangeGameName(int id, string newName);
        void ChangeGameReleaseDate(int id, DateTime newReleaseDate);
        void ChangeGamePublisher(int id, string newPublisher);
        void ChangeGameRating(int id, int newRating);
    }

    public interface IPersonRepository : IRepository<Person>
    {
        void NewPerson(int id, string name, DateTime birthDate);
        void ChangePersonName(int id, string newName);
        void ChangePersonBirthDate(int id, DateTime newBirthDate);
    }
}
