using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.Model.Entities
{
    public class ExperimentDetail : EntityBase
    {
        public ExperimentDetail()
        {

        }

        public ExperimentDetail(EntityContext context) : base(context) { }

        DateTime _dateTime;
        public DateTime DateTime
        {
            get => _dateTime;
            set => OnPropertySetting(nameof(DateTime), value, ref _dateTime);
        }

        string _description = "";
        public string Description
        {
            get => _description;
            set => OnPropertySetting(nameof(Description), value, ref _description);
        }

        decimal _result;
        public decimal Result
        {
            get => _result;
            set
            {
                OnPropertySetting(nameof(Result), value, ref _result);
                if (Experiment != null)
                    Experiment.RaisePropertyChanged(nameof(Experiment.TotalResult));
            }
        }

        decimal _quantity;
        public decimal Quantity
        {
            get => _quantity;
            set
            {
                OnPropertySetting(nameof(Quantity), value, ref _quantity);
                if (Experiment != null)
                    Experiment.RaisePropertyChanged(nameof(Experiment.TotalQuantity));
            }
        }

        Experiment _experiment;
        public virtual Experiment Experiment
        {
            get => _experiment;
            set => OnPropertySetting(nameof(Experiment), value, ref _experiment);
        }
    }

    public class ExperimentDetailConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder, string prefix)
        {
            var config = modelBuilder.Entity<ExperimentDetail>();
            config.ToTable(prefix + "ExperimentDetails").HasKey(e => e.Guid);

            config.HasRequired(e => e.Experiment).WithMany(p => p.Details).WillCascadeOnDelete(true);
        }
    }
}
