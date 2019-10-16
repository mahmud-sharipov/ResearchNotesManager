using ResearchNotesManager.App.General;
using ResearchNotesManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ResearchNotesManager.App.Pages.Experiment
{
    public class ExperimentsViewModel : BaseViewModel
    {
        public ExperimentsViewModel()
        {
            DataProvider = new DataProvider();
            products = new ObservableCollection<Model.Entities.Product>(DataProvider.GetEntities<Model.Entities.Product>().OrderBy(pr => pr.Name).ToList());
        }

        ObservableCollection<Model.Entities.Product> products;
        public virtual ICollection<Model.Entities.Product> Products => products;

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
