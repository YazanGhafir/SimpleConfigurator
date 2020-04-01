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
        public T find<T> (int OBJECT_ID, string TableName)
        {
            return (T)cdm.getEntityManager(TableName).Find(OBJECT_ID);
        }

        public List<T> findAll<T>(string TableName)
        {
            List<T> TableContent = new List<T>();
            foreach (T item in cdm.getEntityManager(TableName))
            {
                TableContent.Add(item);
            }
            return TableContent;
        }
    }
}