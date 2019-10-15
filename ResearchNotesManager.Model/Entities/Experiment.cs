using System;
using System.Linq;

namespace ResearchNotesManager.Model.Entities
{
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Data.Entity;
    public class Experiment : EntityBase
    {
        public Experiment()
        {
            Details.CollectionChanged += Details_CollectionChanged;
        }

        private void Details_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(TotalQuantity));
            RaisePropertyChanged(nameof(TotalResult));
        }

        public Experiment(EntityContext context) : base(context) { }

        DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => OnPropertySetting(nameof(Date), value, ref _date);
        }

        public virtual decimal TotalResult => Details.Sum(d => d.Result);

        public virtual decimal TotalQuantity => Details.Sum(d => d.Quantity);

        public virtual bool IsClosed => Date.Date != DateTime.Now.Date;

        Product _product;
        public virtual Product Product
        {
            get => _product;
            set => OnPropertySetting(nameof(Product), value, ref _product);
        }

        private ObservableCollection<ExperimentDetail> _details = new ObservableCollection<ExperimentDetail>();
        public virtual ObservableCollection<ExperimentDetail> Details
        {
            get => _details;
            set => OnPropertySetting(nameof(Details), value, ref _details);
        }
    }

    public class ExperimentConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder, string prefix)
        {
            var config = modelBuilder.Entity<Experiment>();
            config.ToTable(prefix + "Experiments").HasKey(e => e.Guid);
            config.Ignore(p => p.TotalQuantity);
            config.Ignore(p => p.TotalResult);
            config.HasRequired(e => e.Product).WithMany(p => p.Experiments).WillCascadeOnDelete(true);
            config.HasMany(e => e.Details).WithRequired(p => p.Experiment).WillCascadeOnDelete(true);
        }
    }
}
