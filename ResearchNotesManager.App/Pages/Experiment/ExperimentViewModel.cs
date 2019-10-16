using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResearchNotesManager.App.General;

namespace ResearchNotesManager.App.Pages.Experiment
{
    public class ExperimentViewModel : BaseViewModel
    {
        public ExperimentViewModel(Model.Entities.Experiment experiment, Model.DataProvider dataProvider)
        {
            DataProvider = dataProvider;
            Experiment = experiment;
            NewDetail = new Model.Entities.ExperimentDetail();
        }

        private Model.Entities.Experiment experiment;
        public Model.Entities.Experiment Experiment
        {
            get => experiment;
            set
            {
                experiment = value;
                RaisePropertyChanged();
            }
        }

        private Model.Entities.ExperimentDetail newDetail;
        public Model.Entities.ExperimentDetail NewDetail
        {
            get => newDetail;
            set
            {
                newDetail = value;
                RaisePropertyChanged();
            }
        }

        public override Command DiscardChanges => new Command(p => { });

        public Command AddNewDetail => new Command(p =>
        {
            if (NewDetail.Quantity <= 0)
                UIManager.MessageManager.ShowMessage("Пожалуйста, введите использованное количество продкта");
            else
            {
                NewDetail.Experiment = Experiment;
                NewDetail.DateTime = DateTime.Now;
                DataProvider.Add(NewDetail);
                NewDetail = new Model.Entities.ExperimentDetail();
            }
        });

        public override bool CanClose()
        {
            DataProvider.SaveChanges();
            return true;
        }
    }
}
