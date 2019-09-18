using GameProject.Common.Repository.EntityFramework;
using GameProject.DataAccess.Abstract;
using GameProject.DataAccess.Context;
using GameProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.DataAccess.EntityFramework
{
    public class EfGamerDal : EfEntityRepositoryBase<Gamer, GameProjectContext>, IGamerDal
    {
       
    }
}
