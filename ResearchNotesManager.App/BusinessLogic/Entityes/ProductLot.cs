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
    public class ProductLot : EntityBase
    {
        public ProductLot(EntityContext context) : base(context) { }

        Product _product;
        public virtual Product Product
        {
            get => _product;
            set => OnPropertySetting(nameof(Product), value, ref _product);
        }

        DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => OnPropertySetting(nameof(Date), value, ref _date);
        }

        decimal _quantity;
        public decimal Quantity
        {
            get => _quantity;
            set => OnPropertySetting(nameof(Quantity), value, ref _quantity);
        }
    }

    public class ProductLotConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder, string prefix)
        {
            var config = modelBuilder.Entity<ProductLot>();
            config.ToTable(prefix + "ProductLots").HasKey(pl => pl.Guid);
            config.HasRequired(pl => pl.Product).WithMany(p => p.Lots).WillCascadeOnDelete(true);
        }
    }
}
