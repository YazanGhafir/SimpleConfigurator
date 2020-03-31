using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleConfiguratorBackend.Models.DAO
{
    public class RulesDAO
    {
        ConfiguratorDataModel cdm = new ConfiguratorDataModel();

        public IList printRules ()
        {
            IList rules = new ArrayList();
            foreach (var item in cdm.DISALLOWED_RULE)
            {
                Console.WriteLine(item.ToString());
                rules.Add(item.NAME.ToString());
            }
            return rules;
        }
    }
}