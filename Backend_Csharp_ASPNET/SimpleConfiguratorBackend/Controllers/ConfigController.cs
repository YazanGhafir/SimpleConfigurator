using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using SimpleConfiguratorBackend.Models.BusinessLogic;
using SimpleConfiguratorBackend.Models.DAO;
using static SimpleConfiguratorBackend.Models.BusinessLogic.RulesHandler;

namespace SimpleConfiguratorBackend.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class ConfigController : ApiController
    {
        public DataToSend Get()
        {
            return new DataToSend();
        }
    }
}
