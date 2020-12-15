using Rent.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Logic
{
    public interface IPersonLogic
    {
        Person GetPersonById(int id);
        IList<Person> GetAllPeople();
        void NewPerson(string name, DateTime birthDate);
        void ChangePersonName(int id, string newName);
        void ChangePersonBirthDate(int id, DateTime newBirthDate);
        void DeletePerson(int id);
    }
}
