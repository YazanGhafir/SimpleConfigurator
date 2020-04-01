using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleConfiguratorBackend.Models.DAO;

namespace SimpleConfiguratorBackend.Models.BusinessLogic
{
    public class RulesHandler
    {
        GenericDAO Gdao;
        public List<Rule> RuleList;
        public List<List<int>> ConstraintsList = new List<List<int>>();
        public RulesHandler()
        {
            this.Gdao = new GenericDAO();
            this.RuleList = FillUpRules();
            CreateAllCostrins();
        }


        public List<int> GetSiblingsInRule(int Value_id)
        {
            int ParentParam = Gdao.GetDisParamIdOfValueId(Value_id);
            int ParentRule = Gdao.GetDisRuleIdOfParamId(ParentParam);
            IQueryable <DISALLOWED_PARAMETER> SiblingsParam= Gdao.GetParamWhoAreSiblingsInRule(ParentRule);
            List<int> SiblingsInRule = new List<int>();
            List<int> DisallowedInValue = new List<int>();
            foreach (DISALLOWED_PARAMETER Sib_Param in SiblingsParam)
            {
                SiblingsInRule.Add(Sib_Param.OBJECT_ID);
            }
            foreach (int Sib_Param_obj_id in SiblingsInRule)
            {
                DisallowedInValue.Add(Gdao.GetDisValueIdOfParamId(Sib_Param_obj_id));
            }
            return DisallowedInValue;
        }

        void pairRule(int value_id)
        {
        }

        public class Rule
        {
            public int Rule_id;
            public List<Parameter> ParamList;
            public Rule(int Rule_id, List<Parameter> ParamList) 
            { 
                this.Rule_id = Rule_id;
                this.ParamList = ParamList;
            }
        }

        public class Parameter
        {
            public int Param_id;
            public List<Value> ValueList;
            public Parameter(int Param_id, List<Value> ValueList)
            {
                this.Param_id = Param_id;
                this.ValueList = ValueList;
            }
        }

        public class Value
        {
            public int Val_id;
            public Value(int Val_id) { this.Val_id = Val_id; }
        }

        List<Rule> FillUpRules()
        {
            List<Rule> tmpRuleList = new List<Rule>();
            foreach (int Rule_id in Gdao.GetRuleIds())
            {
                tmpRuleList.Add(new Rule(Rule_id, FillUpParams(Rule_id)));
            }
            return tmpRuleList;
        }

        List<Parameter> FillUpParams(int Rule_id)
        {
            List<Parameter> ParamList = new List<Parameter>();
            foreach (int Param_id in Gdao.GetParamsofRule(Rule_id))
            {
                ParamList.Add(new Parameter(Param_id, FillUpValues(Param_id)));
            }
            return ParamList;
        }

        List<Value> FillUpValues(int Param_id)
        {
            List<Value> ValueList = new List<Value>();
            foreach (int Value_id in Gdao.GetValuesOfParams(Param_id))
            {
                ValueList.Add(new Value(Value_id));
            }
            return ValueList;
        }

        bool IsRuleOf2Pram(Rule RuleToCheck)
        {
            return (RuleToCheck.ParamList.Count == 2);
        }

        void Create2ParamConstraints(Rule Rule_)
        {
            foreach(Value V1 in Rule_.ParamList[0].ValueList)
            {
                foreach(Value V2 in Rule_.ParamList[1].ValueList)
                {
                    CreateSingleConstrain(V1.Val_id, V2.Val_id);
                }
            }

            foreach (Value V1 in Rule_.ParamList[1].ValueList)
            {
                foreach (Value V2 in Rule_.ParamList[0].ValueList)
                {
                    CreateSingleConstrain(V1.Val_id, V2.Val_id);
                }
            }
        }

        void CreateSingleConstrain(int V1_id, int V2_id)
        {
            List<int> VList = new List<int>();
            VList.Add(V1_id);
            VList.Add(V2_id);
            this.ConstraintsList.Add(VList);
        }

        void CreateAllCostrins()
        {
            foreach (Rule Rule_ in this.RuleList)
            {
                if (IsRuleOf2Pram(Rule_))
                {
                    Create2ParamConstraints(Rule_);
                }
            }
        }
  
    }
}
