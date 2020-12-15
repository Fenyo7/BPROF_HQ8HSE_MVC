using Rent.Data;
using Rent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rent.Logic
{
    public class PersonLogic : IPersonLogic
    {
        IPersonRepository personRepo;

        public PersonLogic(IPersonRepository personRepo)
        {
            this.personRepo = personRepo;
        }

        public void ChangePersonBirthDate(int id, DateTime newBirthDate)
        {
            personRepo.ChangePersonBirthDate(id, newBirthDate);
        }

        public void ChangePersonName(int id, string newName)
        {
            personRepo.ChangePersonName(id, newName);
        }

        public void DeletePerson(int id)
        {
            personRepo.DeleteOne(id);
        }

        public IList<Person> GetAllPeople()
        {
            return personRepo.GetAll().ToList();
        }

        public Person GetPersonById(int id)
        {
            return personRepo.GetOne(id);
        }

        public void NewPerson(string name, DateTime birthDate)
        {
            personRepo.NewPerson(name, birthDate);
        }
    }
}
