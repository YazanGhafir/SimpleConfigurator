using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleConfiguratorBackend.Models.DAO;

namespace SimpleConfiguratorBackend.Controllers
{
    public class ValuesController : ApiController
    {

        RulesDAO rulesDAO = new RulesDAO();
        // GET api/values
        public IList Get()
        {
            return rulesDAO.printRules();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
