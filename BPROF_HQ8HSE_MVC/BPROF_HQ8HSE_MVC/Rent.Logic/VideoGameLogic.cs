using Rent.Data;
using Rent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rent.Logic
{
    public class VideoGameLogic : IVideoGameLogic
    {
        IVideoGameRepository gameRepo;

        public VideoGameLogic(IVideoGameRepository gameRepo)
        {
            this.gameRepo = gameRepo;
        }

        public void ChangeGameName(int id, string newName)
        {
            gameRepo.ChangeGameName(id, newName);
        }

        public void ChangeGamePublisher(int id, string newPublisher)
        {
            gameRepo.ChangeGamePublisher(id, newPublisher);
        }

        public void ChangeGameRating(int id, int newRating)
        {
            gameRepo.ChangeGameRating(id, newRating);
        }

        public void ChangeGameReleaseDate(int id, DateTime newReleaseDate)
        {
            gameRepo.ChangeGameReleaseDate(id, newReleaseDate);
        }

        public void DeleteGame(int id)
        {
            gameRepo.DeleteOne(id);
        }

        public IList<VideoGame> GetAllGames()
        {
            return gameRepo.GetAll().ToList();
        }

        public VideoGame GetGameById(int id)
        {
            return gameRepo.GetOne(id);
        }

        public void NewGame(int id, string name, DateTime releaseDate, string publisher, int rating)
        {
            gameRepo.NewGame(id, name, releaseDate, publisher, rating);
        }
    }
}
