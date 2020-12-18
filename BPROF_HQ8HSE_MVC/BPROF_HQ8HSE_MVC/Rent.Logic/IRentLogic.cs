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
        void NewRent(Rental r);
        void ChangeRentDate(int id, DateTime newRentDate);
        void ChangeReturnDate(int id, DateTime newReturnDate);
        void ChangeGameRef(int id, int newGameRef);
        void ChangePersonRef(int id, int newPersonRef);
        void DeleteRent(int id);
        string MostFine();
        string MostRentedGame();
        string MostRentsByPerson();
    }
}
