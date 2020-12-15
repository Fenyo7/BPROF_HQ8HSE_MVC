using Rent.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Logic
{
    public interface IVideoGameLogic
    {
        VideoGame GetGameById(int id);
        IList<VideoGame> GetAllGames();
        void NewGame(int id, string name, DateTime releaseDate, string publisher, int rating);
        void ChangeGameName(int id, string newName);
        void ChangeGameReleaseDate(int id, DateTime newReleaseDate);
        void ChangeGamePublisher(int id, string newPublisher);
        void ChangeGameRating(int id, int newRating);
        void DeleteGame(int id);
    }
}
