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
            return rentRepo.GetOne(id);
        }

        public void NewRent(int id, int gameId, int personId, DateTime rentDate, DateTime returnDate)
        {
            rentRepo.NewRent(id, gameId, personId, rentDate, returnDate);
        }
    }
}
