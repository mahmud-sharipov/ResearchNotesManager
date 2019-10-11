using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.Model.Entityes
{

    // таблитса барои воҳиди ченаки маҳсулот (продуктҳо)

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    public class UnitOfMeasures : EntityBase
    {
        public UnitOfMeasures(EntityContext context) : base(context) { }

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
    }

    public class UinitOfMesuareConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder, string prefix)
        {
            var config = modelBuilder.Entity<UnitOfMeasures>();
            config.ToTable(prefix + "UnitOfMeasures").HasKey(uom => uom.Guid);
        }
    }
}
