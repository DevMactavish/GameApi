using GameProject.Common.Repository.EntityFramework;
using GameProject.DataAccess.Abstract;
using GameProject.DataAccess.Context;
using GameProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.DataAccess.EntityFramework
{
    public class EfAbilityDal: EfEntityRepositoryBase<Ability, GameProjectContext>,IAbilityDal
    {
    }
}
