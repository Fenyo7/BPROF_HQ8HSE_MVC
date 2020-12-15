using System;
using System.Linq;
using Rent.Data;
using Rent.Logic;
using Rent.Repository;

namespace BPROF_HQ8HSE_MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalContext ctx = new RentalContext();
            RentRepository rentRepo = new RentRepository(ctx);
            VideoGameRepository gameRepo = new VideoGameRepository(ctx);
            PersonRepository personRepo = new PersonRepository(ctx);
            RentLogic rentLogic = new RentLogic(rentRepo);
            VideoGameLogic gameLogic = new VideoGameLogic(gameRepo);
            PersonLogic personLogic = new PersonLogic(personRepo);

            Console.WriteLine(">List all rents");
            rentLogic.GetAllRentals().ToList().ForEach(x => Console.WriteLine(x.AllData));

            Console.WriteLine("\n\n##################################################\n");

            Console.WriteLine("\n\n>List all games");
            gameLogic.GetAllGames().ToList().ForEach(x => Console.WriteLine(x.AllData));

            Console.WriteLine("\n\n##################################################\n");

            Console.WriteLine("\n\n>List all people");
            personLogic.GetAllPeople().ToList().ForEach(x => Console.WriteLine(x.AllData));

            //##################################################

            rentLogic.ChangeRentDate(201, new DateTime(2012,01,01));
            //rentLogic.NewRent(210, 105, 4, new DateTime(2020, 12, 11), new DateTime());
            rentLogic.DeleteRent(209);

            personLogic.ChangePersonBirthDate(3, new DateTime(2010, 01, 12));
            personLogic.ChangePersonName(1, "Fá Zoltán");
            //personLogic.NewPerson(8, "Kárnyos Béla", new DateTime(1974, 11, 20));
            personLogic.DeletePerson(7);

            gameLogic.ChangeGameName(104, "Celeste");
            gameLogic.ChangeGamePublisher(104, "Matt Makes Games");
            gameLogic.ChangeGameRating(104, 10);
            gameLogic.ChangeGameReleaseDate(104, new DateTime(2018, 01, 25));
            //gameLogic.NewGame(108, "Mad Max", new DateTime(2015, 09, 01), "Warner Bros interactive entertainment", 9);
            gameLogic.DeleteGame(107);

            //##################################################

            Console.WriteLine("\n\n##################################################\n");
            Console.WriteLine(">After changes");
            Console.WriteLine("\n\n##################################################\n");
            Console.WriteLine(">List all rents");
            rentLogic.GetAllRentals().ToList().ForEach(x => Console.WriteLine(x.AllData));

            Console.WriteLine("\n\n##################################################\n");

            Console.WriteLine("\n\n>List all games");
            gameLogic.GetAllGames().ToList().ForEach(x => Console.WriteLine(x.AllData));

            Console.WriteLine("\n\n##################################################\n");

            Console.WriteLine("\n\n>List all people");
            personLogic.GetAllPeople().ToList().ForEach(x => Console.WriteLine(x.AllData));
        }
    }
}
