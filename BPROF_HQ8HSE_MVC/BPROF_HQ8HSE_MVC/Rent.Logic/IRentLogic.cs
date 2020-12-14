using Rent.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Logic
{
    public interface IRentLogic
    {
        Rental GetRentById(int id);
        IList<Rental> GetAllRentals();
    }

    public interface IPersonLogic
    {
        Person GetPersonById(int id);
        IList<Person> GetAllPeople();
        void ChangePersonName(int id, string newName);
    }

    public interface IVideoGameLogic
    {
        VideoGame GetGameById(int id);
        IList<VideoGame> GetAllGames();
    }
}
