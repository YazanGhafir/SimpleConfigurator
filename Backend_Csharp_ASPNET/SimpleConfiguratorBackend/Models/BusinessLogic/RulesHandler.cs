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
            Test3NestedConstraints(); //Comment out this line to test the 3 nested constraints
            CreateAllCostrins();
        }


        public List<int> GetSiblingsInRule(int Value_id)
        {
            int ParentParam = Gdao.GetDisParamIdOfValueId(Value_id);
            int ParentRule = Gdao.GetDisRuleIdOfParamId(ParentParam);
            IQueryable<DISALLOWED_PARAMETER> SiblingsParam = Gdao.GetParamWhoAreSiblingsInRule(ParentRule);
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

        bool IsRuleOf3Pram(Rule RuleToCheck)
        {
            return (RuleToCheck.ParamList.Count == 3);
        }

        public List<List<int>> Create2ParamConstraints(Rule Rule_)
        {
            return CreateSingleConstraintsBetween2Param(Rule_.ParamList[0].ValueList, Rule_.ParamList[1].ValueList);
        }


        List<List<int>> Create3ParamConstraints(Rule Rule_)
        {
            return CreatedoubleConstraintsBetween3Param(
                    Rule_.ParamList[0].ValueList,
                    Rule_.ParamList[1].ValueList,
                    Rule_.ParamList[2].ValueList
                    );
        }

        List<List<int>> CreatedoubleConstraintsBetween3Param(List<Value> LV1, List<Value> LV2, List<Value> LV3)
        {
            List<List<int>> TmpdoubleConstraintsList = CreateSingleConstraintsBetween2Param(LV1, LV2);
            List<List<int>> DoubleConstraintsList = new List<List<int>>();
            foreach (Value V3 in LV3)
            {
                foreach (List<int> LV in TmpdoubleConstraintsList)
                {
                    LV.Add(V3.Val_id);
                    List<int> TmpLV = new List<int>();
                    TmpLV.AddRange(LV);
                    DoubleConstraintsList.Add(TmpLV);
                    LV.Remove(V3.Val_id);
                }
            }
            return DoubleConstraintsList;
        }

        List<List<int>> CreateSingleConstraintsBetween2Param(List<Value> LV1, List<Value> LV2)
        {
            List<List<int>> Param2Constraints = new List<List<int>>();
            foreach (Value V1 in LV1)
            {
                foreach (Value V2 in LV2)
                {
                    Param2Constraints.Add(CreateSingleConstrain(V1.Val_id, V2.Val_id));
                }
            }
            return Param2Constraints;
        }

        List<int> CreateSingleConstrain(int V1_id, int V2_id)
        {
            return new List<int> { V1_id, V2_id };
        }


        void CreateAllCostrins()
        {
            this.ConstraintsList.Clear();
            foreach (Rule Rule_ in this.RuleList)
            {
                if (IsRuleOf2Pram(Rule_))
                {
                    this.ConstraintsList.AddRange(Create2ParamConstraints(Rule_));
                } else if (IsRuleOf3Pram(Rule_))
                {
                    this.ConstraintsList.AddRange(Create3ParamConstraints(Rule_));
                }
            }

        }


        /*
         * Tests the 3 nested contrains logic by adding such rules
         * and see if they appear in the ConstraintsList in the 
         * format they should
         */
        void Test3NestedConstraints()
        {
            this.RuleList.Add(new Rule
                (5, new List<Parameter>()
                {
                    new Parameter (9, new List<Value>(){new Value(16), new Value(17), new Value(18)}),
                    new Parameter (10, new List<Value>(){new Value(5), new Value(4)}),
                    new Parameter (11, new List<Value>(){new Value(1), new Value(2)}),
                }
                ));
        }

        string[] res = new string[10];
        public String[] test() { 
            String[] arr = { "A", "B", "C", "D", "E", "F" };
            combinations(arr, 3, 0, new String[3]);
            foreach (var item in res)
            {
                System.Diagnostics.Debug.WriteLine(item.ToString());
            }
            
            return arr;
        }

        void combinations(String[] arr, int len, int startPosition, String[] result)
        {
            if (len == 0)
            {
                res.Concat(result);
                return;
            }
            for (int i = startPosition; i <= arr.Length - len; i++)
            {
                result[result.Length - len] = arr[i];
                combinations(arr, len - 1, i + 1, result);
            }
        }

    }
}
