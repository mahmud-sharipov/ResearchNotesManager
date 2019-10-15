using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.Model.Entities
{
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Data.Entity;
    public class Product : EntityBase
    {
        public Product() { }

        public Product(EntityContext context) : base(context)
        {
            Lots.CollectionChanged += MakeDirtyNetQuantity;
            Experiments.CollectionChanged += MakeDirtyNetQuantity;
        }

        private void MakeDirtyNetQuantity(object sender, NotifyCollectionChangedEventArgs e) => RaisePropertyChanged(nameof(NetQuantity));

        public string Sku => Name.Substring(0, 2).ToUpper();

        string _name = "";
        public string Name
        {
            get => _name;
            set
            {
                OnPropertySetting(nameof(Name), value, ref _name);
                RaisePropertyChanged(nameof(Sku));
            }
        }

        string _description = "";
        public string Description
        {
            get => _description;
            set => OnPropertySetting(nameof(Description), value, ref _description);
        }

        public virtual decimal NetQuantity => Lots.Sum(l => l.Quantity) - Experiments.Sum(e => e.TotalQuantity);

        UnitOfMeasures _uom;
        public virtual UnitOfMeasures UOM
        {
            get => _uom;
            set => OnPropertySetting(nameof(UOM), value, ref _uom);
        }

        private ObservableCollection<ProductLot> _lots = new ObservableCollection<ProductLot>();
        public virtual ObservableCollection<ProductLot> Lots
        {
            get => _lots;
            set => OnPropertySetting(nameof(Lots), value, ref _lots);
        }

        private ObservableCollection<Experiment> _experriments = new ObservableCollection<Experiment>();
        public virtual ObservableCollection<Experiment> Experiments
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
            config.Ignore(p => p.NetQuantity);
            config.Ignore(p => p.Sku);
            config.HasMany(p => p.Lots).WithRequired(pl => pl.Product).WillCascadeOnDelete(true);
            config.HasRequired(p => p.UOM);
            config.HasMany(p => p.Experiments).WithRequired(e => e.Product).WillCascadeOnDelete(true);

        }
    }
}
