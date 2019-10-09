using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.Model.Entityes
{

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    public class Experiment : EntityBase
    {
        public Experiment(EntityContext context) : base(context) { }

        DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => OnPropertySetting(nameof(Date), value, ref _date);
        }

        decimal _result;
        public decimal Result
        {
            get => _result;
            set => OnPropertySetting(nameof(Result), value, ref _result);
        }

        decimal _quantity;
        public decimal Quantity
        {
            get => _quantity;
            set => OnPropertySetting(nameof(Quantity), value, ref _quantity);
        }

        string _description;
        public string Description
        {
            get => _description;
            set => OnPropertySetting(nameof(Description), value, ref _description);
        }

        Product _product;
        public virtual Product Product
        {
            get => _product;
            set => OnPropertySetting(nameof(Product), value, ref _product);
        }

    }

    public class ExperimentConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder, string prefix)
        {
            var config = modelBuilder.Entity<Experiment>();
            config.ToTable(prefix + "Experiments").HasKey(e => e.Guid);
            config.HasRequired(e => e.Product).WithMany(p => p.Experiments).WillCascadeOnDelete(true);
        }
    }
}
