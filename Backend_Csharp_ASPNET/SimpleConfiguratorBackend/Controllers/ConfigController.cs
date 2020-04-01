using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SimpleConfiguratorBackend.Models.BusinessLogic;
using SimpleConfiguratorBackend.Models.DAO;
using static SimpleConfiguratorBackend.Models.BusinessLogic.RulesHandler;

namespace SimpleConfiguratorBackend.Controllers
{
    public class ConfigController : ApiController
    {
        GenericDAO Gdao = new GenericDAO();
        RulesHandler RHandler = new RulesHandler();
        
        public string[] Get(int id)
        {
            //return RHandler.ConstraintsList;
            return RHandler.test();
        }

        public void Get()
        {
            new DataCombiner().Main();
        }
    }
}
