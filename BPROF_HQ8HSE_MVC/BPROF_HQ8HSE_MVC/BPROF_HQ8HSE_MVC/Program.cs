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

            Console.WriteLine(ctx.People.Count());
            Console.WriteLine(ctx.Games.Count());
            Console.WriteLine(ctx.Rentals.Count());
        }
    }
}
