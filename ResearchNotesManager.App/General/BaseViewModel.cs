using ResearchNotesManager.App;
using ResearchNotesManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ResearchNotesManager.App.General
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public DataProvider DataProvider { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        public ICommand SaveChanges => new Command(p =>
        {
            if (CanClose())
                DataProvider.SaveChanges();
        });

        public abstract Command DiscardChanges { get; }

        public abstract bool CanClose();
    }
}
