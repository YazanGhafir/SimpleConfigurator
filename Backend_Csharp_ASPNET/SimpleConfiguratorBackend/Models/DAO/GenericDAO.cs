using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleConfiguratorBackend.Models.DAO
{
    public class GenericDAO
    {
        ConfiguratorDataModel cdm = new ConfiguratorDataModel();
        public T FindByID<T> (int OBJECT_ID, string TableName)
        {
            return (T)cdm.getEntityManager(TableName).Find(OBJECT_ID);
        }

        public List<T> FindAll<T>(string TableName)
        {
            List<T> TableContent = new List<T>();
            foreach (T item in cdm.getEntityManager(TableName))
            {
                TableContent.Add(item);
            }
            return TableContent;
        }

        public int GetDisParamIdOfValueId(int Value_id)
        {
            return cdm.DISALLOWED_VALUE
                .Where(a => a.PARAMETER_VALUE_ID == Value_id)
                .Single()
                .DISALLOWED_PARAMETER_ID;
        }

        public int GetDisValueIdOfParamId(int Param_id)
        {
            return cdm.DISALLOWED_VALUE
                .Where(a => a.DISALLOWED_PARAMETER_ID == Param_id)
                .Single()
                .PARAMETER_VALUE_ID;
        }


        public int GetDisRuleIdOfParamId(int Param_id)
        {
            return cdm.DISALLOWED_PARAMETER
                .Where(a => a.OBJECT_ID == Param_id)
                .Single()
                .DISALLOWED_RULE_ID;
        }

        public IQueryable<DISALLOWED_PARAMETER> GetParamWhoAreSiblingsInRule(int rule_id)
        {
            return cdm.DISALLOWED_PARAMETER
                .Where(a => a.DISALLOWED_RULE_ID == rule_id);
        }

        public List<int> GetRuleIds()
        {
            IQueryable<int> RuleIDs = from a in cdm.DISALLOWED_RULE select a.OBJECT_ID;
            return RuleIDs.ToList();
        }

        public List<int> GetParamsofRule(int Rule_id)
        {
            IQueryable<int> ParamObjectIDs = from a 
                                             in cdm.DISALLOWED_PARAMETER 
                                             where a.DISALLOWED_RULE_ID == Rule_id
                                             select a.OBJECT_ID;
            return ParamObjectIDs.ToList();
        }

        public List<int> GetValuesOfParams(int Param_id)
        {
            IQueryable<int> Value_id = from a
                                             in cdm.DISALLOWED_VALUE
                                             where a.DISALLOWED_PARAMETER_ID == Param_id
                                             select a.PARAMETER_VALUE_ID;
            return Value_id.ToList();
        }

    }
}