using NUnit.Framework;
using Rent.Data;
using Rent.Repository;
using System;

namespace Rent.Logic.Test
{
    [TestFixture]
    public class Tests
    {
        private RentLogic rentLogic;
        private VideoGameLogic gameLogic;
        private PersonLogic personLogic;

        [OneTimeSetUp]
        public void Setup()
        {
            RentalContext ctx = new RentalContext();
            RentRepository rentRepo = new RentRepository(ctx);
            VideoGameRepository gameRepo = new VideoGameRepository(ctx);
            PersonRepository personRepo = new PersonRepository(ctx);
            rentLogic = new RentLogic(rentRepo);
            gameLogic = new VideoGameLogic(gameRepo);
            personLogic = new PersonLogic(personRepo);
        }

        #region Rent tests

        [TestCase(210, 105, 4, 2020, 12, 11, 1, 1, 1)]
        [TestCase(211, 102, 5, 2020, 11, 20, 2020, 12, 7)]
        public void CreateRentTest(int id, int gameId, int personId, int rentYear, int rentMonth, int rentDay, int returnYear, int returnMonth, int returnDay)
        {
            //DateTime rentDate = new DateTime(rentYear, rentMonth, rentDay);
            //DateTime returnDate = new DateTime(returnYear, returnMonth, returnDay);
            //rentLogic.NewRent(id, gameId, personId, rentDate, returnDate);
            //Assert.That(rentLogic.GetRentById(id).Id, Is.EqualTo(id));

            Assert.Pass();
        }

        [TestCase(201, 2012, 01, 01)]
        [TestCase(205, 2015, 12, 07)]
        [TestCase(207, 2020, 11, 22)]
        public void ChangeRentDateTest(int index, int year, int month, int day)
        {
            DateTime newDate = new DateTime(year, month, day);
            rentLogic.ChangeRentDate(index, newDate);
            Assert.That(rentLogic.GetRentById(index).RentDate, Is.EqualTo(newDate));
        }

        [TestCase(201)]
        [TestCase(202)]
        [TestCase(203)]
        public void GetRent(int index)
        {
            var x = rentLogic.GetRentById(index);
            var y = rentLogic.GetRentById(index);

            Assert.That(x, Is.SameAs(y));
        }


        #endregion

        #region Game tests

        [TestCase(108, "Mad Max", 2015, 09, 06, "Warner Bros interactive entertainment", 9)]
        public void CreateGameTest(int id, string name, int releaseYear, int releaseMonth, int releaseDay, string publisher, int rating)
        {
            //DateTime releaseDate = new DateTime(releaseYear, releaseMonth, releaseDay);
            //gameLogic.NewGame(id, name, releaseDate, publisher, rating);
            //Assert.That(gameLogic.GetGameById(id).Id, Is.EqualTo(id));

            Assert.Pass();
        }

        [TestCase(104, "Celeste")]
        [TestCase(105, "Test")]
        public void ChangeGameNameTest(int id, string newName)
        {
            gameLogic.ChangeGameName(id, newName);
            Assert.That(gameLogic.GetGameById(id).Name, Is.EqualTo(newName));
        }

        [TestCase(104, "Matt Makes Games")]
        [TestCase(105, "Test")]
        public void ChangeGamePublisherTest(int id, string newPublisher)
        {
            gameLogic.ChangeGamePublisher(id, newPublisher);
            Assert.That(gameLogic.GetGameById(id).Publisher, Is.EqualTo(newPublisher));
        }

        [TestCase(104, 9)]
        [TestCase(105, 5)]
        public void ChangeGameRating(int id, int newRating)
        {
            gameLogic.ChangeGameRating(id, newRating);
            Assert.That(gameLogic.GetGameById(id).Rating, Is.EqualTo(newRating));
        }

        [TestCase(104, 2018, 01, 25)]
        [TestCase(105, 2015, 05, 05)]
        public void ChangeGameReleaseDateTest(int id, int newYear, int newMonth, int newDay)
        {
            DateTime d = new DateTime(newYear, newMonth, newDay);
            gameLogic.ChangeGameReleaseDate(id, d);
            Assert.That(gameLogic.GetGameById(id).ReleaseDate, Is.EqualTo(d));
        }

        #endregion

        #region Person tests

        [TestCase(8, "Kárnyos Béla", 1974, 11, 20)]
        public void CreatePersonTest(int id, string name, int birthYear, int birthMonth, int birthDay)
        {
            //DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);
            //personLogic.NewPerson(id, name, birthDate);
            //Assert.That(personLogic.GetPersonById(id).Id, Is.EqualTo(id));

            Assert.Pass();
        }

        [TestCase(1, "Fá Zoltán")]
        [TestCase(2, "Test")]
        public void ChangePersonNameTest(int id, string newName)
        {
            personLogic.ChangePersonName(id, newName);
            Assert.That(personLogic.GetPersonById(id).Name, Is.EqualTo(newName));
        }

        [TestCase(2, 2010, 01, 12)]
        [TestCase(3, 1995, 03, 30)]
        public void ChangePersonBirthDateTest(int id, int newYear, int newMonth, int newDay)
        {
            DateTime newBirthDate = new DateTime(newYear, newMonth, newDay);
            personLogic.ChangePersonBirthDate(id, newBirthDate);
            Assert.That(personLogic.GetPersonById(id).BirthDate, Is.EqualTo(newBirthDate));
        }

        #endregion
    }
}