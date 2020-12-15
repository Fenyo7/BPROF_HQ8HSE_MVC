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
        void NewRent(int gameId, int personId, DateTime rentDate, DateTime returnDate);
        void ChangeRentDate(int id, DateTime newRentDate);
        void DeleteRent(int id);
    }
}
