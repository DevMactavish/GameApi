using GameProject.Common.Repository;
using GameProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.DataAccess.Abstract
{
    public interface IGamerAbilityDal: IEntityRepository<GamerAbility>
    {
    }
}
