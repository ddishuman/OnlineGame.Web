using System.Data.Entity;
using System.Linq;

namespace OnlineGame.Web.Models
{
    public class BoardGame
    {
        public Gamer GameHolder
        {
            get
            {
                using (OnlineGameEntities dbContext = new OnlineGameEntities())
                {
                    return dbContext.Gamers.SingleAsync(x => x.Id == 1).Result;
                }
            }
        }
    }
}