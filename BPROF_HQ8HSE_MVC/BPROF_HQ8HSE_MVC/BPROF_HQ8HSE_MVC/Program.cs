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
        }
    }
}
