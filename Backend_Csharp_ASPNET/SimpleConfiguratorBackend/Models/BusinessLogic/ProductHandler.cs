using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleConfiguratorBackend.Models.DAO;

namespace SimpleConfiguratorBackend.Models.BusinessLogic
{
    public class ProductHandler
    {
        public Dictionary<string, Dictionary<int, string>> Parameters;
        private GenericDAO Gdao;
        public ProductHandler()
        {
            this.Gdao = new GenericDAO();
            this.Parameters = Gdao.getParameters();
        }
    }
}