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

        public void ChangeRentDate(int id, DateTime newRentDate)
        {
            rentRepo.ChangeRentDate(id, newRentDate);
        }

        public void DeleteRent(int id)
        {
            rentRepo.DeleteOne(id);
        }

        public IList<Rental> GetAllRentals()
        {
            return rentRepo.GetAll().ToList();
        }

        public Rental GetRentById(int id)
        {
            try
            {
                return rentRepo.GetOne(id);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Data on this index does not exist.");
            }
        }

        public string MostFine()
        {
            return rentRepo.MostFine();
        }

        public string MostRentedGame()
        {
            return rentRepo.MostRentedGame();
        }

        public string MostRentsByPerson()
        {
            return rentRepo.MostRentsByPerson();
        }

        public void NewRent(int gameId, int personId, DateTime rentDate, DateTime returnDate)
        {
            rentRepo.NewRent(gameId, personId, rentDate, returnDate);
        }
    }
}
