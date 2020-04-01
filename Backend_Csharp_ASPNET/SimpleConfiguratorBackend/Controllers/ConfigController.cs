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
    public class ConfigController : ApiController
    {

        GenericDAO gdao = new GenericDAO();
        
        public PRODUCT Get(int id)
        {
            return gdao.find<PRODUCT>(id, "PRODUCT");
        }

        public List<PRODUCT> Get()
        {
            return gdao.findAll<PRODUCT>("PRODUCT");
        }

    }
}
