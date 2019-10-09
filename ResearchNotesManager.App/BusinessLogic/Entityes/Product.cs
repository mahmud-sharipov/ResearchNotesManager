using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.App.BusinessLogic.Entityes
{

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    public class Product : EntityBase
    {
        public Product(EntityContext context) : base(context) { }

        string _name;
        public string Name
        {
            get => _name;
            set => OnPropertySetting(nameof(Name), value, ref _name);
        }

        string _description;
        public string Description
        {
            get => _description;
            set => OnPropertySetting(nameof(Description), value, ref _description);
        }

        public virtual decimal NetQuantity => 0;

        UnitOfMeasures _uom;
        public virtual UnitOfMeasures UOM
        {
            get => _uom;
            set => OnPropertySetting(nameof(UOM), value, ref _uom);
        }

        private ICollection<ProductLot> _lots = new ObservableCollection<ProductLot>();
        public virtual ICollection<ProductLot> Lots
        {
            get => _lots;
            set => OnPropertySetting(nameof(Lots), value, ref _lots);
        }

        private ICollection<Experiment> _experriments = new ObservableCollection<Experiment>();
        public virtual ICollection<Experiment> Experiments
        {
            get => _experriments;
            set => OnPropertySetting(nameof(Experiments), value, ref _experriments);
        }

    }

    public class ProductConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder, string prefix)
        {
            var config = modelBuilder.Entity<Product>();
            config.ToTable(prefix + "Products").HasKey(p => p.Guid);
            config.HasMany(p => p.Lots).WithRequired(pl => pl.Product).WillCascadeOnDelete(true);
            config.HasRequired(p => p.UOM);
            config.HasMany(p => p.Experiments).WithRequired(e => e.Product).WillCascadeOnDelete(true);

        }
    }
}
