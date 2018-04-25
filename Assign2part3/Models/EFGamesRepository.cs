using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assign2part3.Models
{
    public class EFGamesRepository : IMockGamesRepository
    {
        private GameStoreHere db = new GameStoreHere();
        public IQueryable<Game> Games
        {
            get { return db.Games; }
        }

public void Delete(Game game)
        {
            db.Games.Remove(game);
            db.SaveChanges();
        }

        public Game Save(Game game)
        {
            if (game.GameId != null)
            {
                db.Entry(game).State = EntityState.Modified;
            }
            else
            {
                db.Games.Add(game);
            }
            db.SaveChanges();
            return game;
        }
    }
}