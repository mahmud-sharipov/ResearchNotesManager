﻿using ResearchNotesManager.App.BusinessLogic.Entityes;
using System.Data.Entity;

namespace ResearchNotesManager.App.BusinessLogic
{
    public class DbModelBuilderManager
    {
        public static string ModelPrefix => "";
        public static string UIPrefix => "";
        public static void BuildModels(DbModelBuilder modelBuilder)
        {
            EntityBaseConfiguration.Configure(modelBuilder, ModelPrefix);

            //general
            UinitOfMesuareConfiguration.Configure(modelBuilder, ModelPrefix);
            ProductConfiguration.Configure(modelBuilder, ModelPrefix);
            ProductLotConfiguration.Configure(modelBuilder, ModelPrefix);
            ExperimentConfiguration.Configure(modelBuilder, ModelPrefix);

        }
    }
}
