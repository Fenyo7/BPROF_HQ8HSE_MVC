using Rent.Data;
using Rent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rent.Logic
{
    public class RentLogic : IRentLogic
    {
        IRentRepository rentRepo;

        public RentLogic(IRentRepository rentRepo)
        {
            this.rentRepo = rentRepo;
        }

        public IList<Rental> GetAllRentals()
        {
            return rentRepo.GetAll().ToList();
        }

        public Rental GetRentById(int id)
        {
            return rentRepo.GetOne(id);
        }
    }

    public class PersonLogic : IPersonLogic
    {
        IPersonRepository personRepo;

        public PersonLogic(IPersonRepository personRepo)
        {
            this.personRepo = personRepo;
        }

        public void ChangePersonName(int id, string newName)
        {
            personRepo.ChangeName(id, newName);
        }

        public IList<Person> GetAllPeople()
        {
            return personRepo.GetAll().ToList();
        }

        public Person GetPersonById(int id)
        {
            return personRepo.GetOne(id);
        }
    }

    public class VideoGameLogic : IVideoGameLogic
    {
        IVideoGameRepository gameRepo;

        public VideoGameLogic(IVideoGameRepository gameRepo)
        {
            this.gameRepo = gameRepo;
        }

        public IList<VideoGame> GetAllGames()
        {
            return gameRepo.GetAll().ToList();
        }

        public VideoGame GetGameById(int id)
        {
            return gameRepo.GetOne(id);
        }
    }
}
