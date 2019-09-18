using GameProject.DataAccess.EntityFramework;
using GameProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Business.Concrete
{
    public class GamerManager
    {
        EfGamerDal gamerDal = new EfGamerDal();
        EfLogDal logger = new EfLogDal();
        EfAbilityDal abilityDal = new EfAbilityDal();


        public string CreateGamer(Gamer gamer)
        {
            gamer.Health = 100;
            gamer.Armor = 10;
            gamer.GamerAbilityId = 1;

            var result = gamerDal.Add(gamer);
            var abilities = abilityDal.GetAll();

            AddAbilities(result, result, abilities);
            string abilityDetail = "";
            abilityDetail = GetAbilityDetail(abilities, abilityDetail);

            string logMessage = logger.Add(new Log
            {
                Message = "Yeni Oyuncu \r\nOyuncu Id:" + result.Id+"\r\n"+"Oyuncu Adı:" + result.Name + "\r\nCan Değeri :" + result.Health + "\r\nZırh :" + result.Armor + "\r\n" +
                "Yenetekleri\r\n" + abilityDetail
            }).Message;

            return logMessage;
        }

        private static string GetAbilityDetail(List<Ability> abilities, string abilityDetail)
        {
            foreach (var item in abilities)
            {
                abilityDetail += item.Type.ToString() + " - Damage : " + item.Damage + "\r\n";
            }

            return abilityDetail;
        }

        private static void AddAbilities(Gamer gamer, Gamer result, List<Ability> abilities)
        {
            foreach (var item in abilities)
            {
                gamer.GamerAbilities.Add(new GamerAbility
                {
                    AbilityId = item.Id,
                    GamerId = result.Id
                });
            }
        }
    }
}
