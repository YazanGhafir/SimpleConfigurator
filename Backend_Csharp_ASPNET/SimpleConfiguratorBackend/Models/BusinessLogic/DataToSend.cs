using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleConfiguratorBackend.Models.BusinessLogic
{
    public class DataToSend
    {
        public Dictionary<string, Dictionary<int, string>> Parameters;
        public List<List<int>> ConstraintsList;

        public DataToSend()
        {
            this.ConstraintsList = new RulesHandler().ConstraintsList;
            this.Parameters = new ProductHandler().Parameters;
        }
    }
}