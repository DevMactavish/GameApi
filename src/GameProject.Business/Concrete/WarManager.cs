using GameProject.Common.RequestEntities;
using GameProject.DataAccess.EntityFramework;
using GameProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Business.Concrete
{
    public class WarManager
    {
        EfWarDal warDal = new EfWarDal();
        EfLogDal logger = new EfLogDal();
        EfAbilityDal abilityDal = new EfAbilityDal();
        EfGamerDal gamerDal = new EfGamerDal();

        public string CreateWar(Gamer gamer)
        {
            gamer = gamerDal.Get(row => row.Id.Equals(gamer.Id));
            War war = new War();
            war.GamerId = gamer.Id;
            war.Sequence = 2;
            war.State = State.InProcess;
            war.BothHealth = 100;
            var result = warDal.Add(war);

            string logMessage = logger.Add(new Log
            {
                Message = "Savaş Başladı Savaş Id :"+result.Id+"\r\nilk hamle sende " + gamer.Name,
                WarId=result.Id
            }).Message;

            return logMessage;
        }

        public string MakeMove(MoveClass moveClass)
        {
            var gamer = gamerDal.Get(row => row.Id == moveClass.GamerId);
            var ability = abilityDal.Get(row => row.Id == moveClass.AbilityId);
            string resultMessage = "";
            var existingWar = warDal.GetExistingWarr(State.InProcess, gamer.Id);

            #region Oyuncu Hasarı
            existingWar.BothHealth = existingWar.BothHealth - ability.Damage;
            bool isEnd = CheckHealth(existingWar.BothHealth);
            if (isEnd)
            {
                resultMessage = WarOver(gamer, resultMessage, existingWar);
                return resultMessage;
            }
            #endregion

            resultMessage += logger.Add(new Log
            {
                Message = "Oyuncu Hasarı :" + ability.Damage.ToString() + "\r\nBot Kalan Can :" + existingWar.BothHealth.ToString()+"\r\n",
                WarId=existingWar.Id,
            }).Message;

            #region Bot Hasarı
            int randomDamage = GetRandomDamage(abilityDal.GetAll());
            int realDamage = GetRealDamage(randomDamage, gamer.Armor);
            gamer.Health = gamer.Health - realDamage;

            bool isWarEnd = CheckHealth(gamer.Health);

            if (isWarEnd)
            {
                existingWar.State = State.Finished;
                gamer.Health = 100;
                gamerDal.Update(gamer);
                warDal.Update(existingWar);
                resultMessage += logger.Add(new Log
                {
                    Message = "Kazanan Both",
                    WarId=existingWar.Id
                }).Message;
                return resultMessage;
            }
            #endregion

            resultMessage += logger.Add(new Log
            {
                Message = "Bot hasarı :" + realDamage + "\r\nKalan Can :" + gamer.Health+"\r\n",
                WarId=existingWar.Id
            }).Message;
            var updatedGamer = gamerDal.Update(gamer);
            var updatedWar = warDal.Update(existingWar);
            return resultMessage;
        }

        public string GetWarLogs(int warId)
        {
            var logs = logger.GetAll();
            logs = logs.Where(row => row.WarId.Equals(warId)).ToList();
            List<string> messages = logs.Select(row => row.Message).ToList();
            return String.Join("\r\n", messages);
        }

        private string WarOver(Gamer gamer, string resultMessage, War existingWar)
        {
            existingWar.State = State.Finished;
            warDal.Update(existingWar);
            resultMessage += logger.Add(new Log
            {
                Message = "Kazanan " + gamer.Name,
                WarId=existingWar.Id
            }).Message;
            return resultMessage;
        }

        private bool CheckHealth(int health)
        {
            return health > 0 ? false : true;
        }

        private int GetRealDamage(int randomDamage, int armor)
        {
            if (randomDamage > armor)
                return randomDamage - armor;
            else
                return armor - randomDamage;
        }

        private int GetRandomDamage(List<Ability> list)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 3);
            var item = list.FirstOrDefault(row => row.Id == randomNumber);
            return item.Damage;
        }

    }
}
