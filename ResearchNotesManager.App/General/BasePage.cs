using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ResearchNotesManager.App.General
{
    public class BasePage : UserControl, INotifyPropertyChanged
    {
        public BaseViewModel ViewModel { get; protected set; }

        #region Title

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title))); }
        }


        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(BasePage));

        #endregion

        public string Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
