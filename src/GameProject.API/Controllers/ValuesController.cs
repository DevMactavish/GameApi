using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using GameProject.Business.Concrete;
using GameProject.Common.RequestEntities;
using GameProject.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace GameProject.API.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpPost]
        [Route("api/gamer/create")]
        public string AddGamer([FromBody]Gamer gamer)
        {
            GamerManager gamerManager = new GamerManager();
            string logMessage = gamerManager.CreateGamer(gamer);
            return logMessage;
        }

        [HttpPost]
        [Route("api/war/begin")]
        public string AddWar([FromBody]Gamer gamer)
        {
            WarManager warManager = new WarManager();
            string logMessage = warManager.CreateWar(gamer);
            return logMessage;
        }

        [HttpPost]
        [Route("api/war/makemove")]
        public string MakeMove([FromBody]MoveClass moveClass)
        {
            WarManager warManager = new WarManager();
            string resultMessage = warManager.MakeMove(moveClass);
            return resultMessage;
        }

        [HttpGet]
        [Route("api/war/getlog/{warId}")]
        public string GetWarLog(int warId)
        {
            WarManager warManager = new WarManager();
            string resultMessage = warManager.GetWarLogs(warId);
            return resultMessage;
        }
    }
}
