using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign2part3.Models
{
    public interface IMockGamesRepository
    {
        IQueryable<Game> Games { get; }
        Game Save(Game game);
        void Delete(Game game);
    }
}
