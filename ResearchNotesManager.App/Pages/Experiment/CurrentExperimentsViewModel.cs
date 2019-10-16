using ResearchNotesManager.App.General;
using ResearchNotesManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.App.Pages.Experiment
{
    public class CurrentExperimentsViewModel : BaseViewModel
    {
        public CurrentExperimentsViewModel()
        {
            DataProvider = new DataProvider();
            var currentDate = DateTime.Now.Date;
            experiments = new ObservableCollection<Model.Entities.Experiment>(
                    DataProvider.GetEntities<Model.Entities.Experiment>().Where(pr => pr.Date >= currentDate).ToList()
                );
        }

        ObservableCollection<Model.Entities.Experiment> experiments;
        public virtual ICollection<Model.Entities.Experiment> Experiments => experiments;

        public override Command DiscardChanges => new Command(p => { });

        public void OpenEntityPage(object entity)
        {
            if (entity is Model.Entities.Experiment experiment)
                OpenEntityPage(experiment);
        }

        public void OpenEntityPage(Model.Entities.Experiment experiment)
        {
            var pageId = "Experiment:" + experiment.Guid;
            if (UIManager.PageManager.IsPageAlreadyOpened(pageId))
                UIManager.PageManager.SetCurrentPage(pageId);
            else
                UIManager.PageManager.AddPage(new ExperimentPage(new ExperimentViewModel(experiment, DataProvider)));
        }

        public override bool CanClose() => true;
    }
}
