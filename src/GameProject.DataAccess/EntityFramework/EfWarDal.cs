using GameProject.Common.Repository;
using GameProject.Common.Repository.EntityFramework;
using GameProject.DataAccess.Abstract;
using GameProject.DataAccess.Context;
using GameProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.DataAccess.EntityFramework
{
    public class EfWarDal : EfEntityRepositoryBase<War,GameProjectContext>,IWarDal
    {
        public War GetExistingWarr(State state, int gamerId)
        {
            using (GameProjectContext context = new GameProjectContext())
            {
                var entity = context.Wars.Where(row => row.State == state).Include("Gamer");
                var war = entity.Where(row => row.Gamer.Id == gamerId).FirstOrDefault();
                return war;
            }
        }
    }
}
