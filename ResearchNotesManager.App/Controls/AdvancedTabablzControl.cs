using Dragablz;
using ResearchNotesManager.App.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.App.Controls
{
    public class AdvancedTabablzControl : TabablzControl, IPagesControl
    {
        public List<BasePage> pages = new List<BasePage>();

        public AdvancedTabablzControl() : base()
        {
            UIManager.PageManager.PagesControl = this;
            ClosingItemCallback = OnClosingItem;
            Visibility = System.Windows.Visibility.Hidden;
        }

        public void AddPage(BasePage page)
        {
            if (pages.Any(p => p.Id == page.Id))
                SelectedItem = (pages.Single(p => p.Id == page.Id));
            else
            {
                Items.Add(page);
                pages.Add(page);
                SelectedItem = page;
            }
            Visibility = System.Windows.Visibility.Visible;
        }

        public void AddPages(IEnumerable<BasePage> _pages)
        {
            if (!_pages.Any()) return;

            foreach (var page in pages)
                AddPage(page);
        }

        public void SetSelectedItem(string id)
        {
            var page = pages.SingleOrDefault(p => p.Id == id);
            if (page != null)
                SelectedItem = page;
        }

        public bool IsPageAlreadyOpened(string id) => pages.Any(p => p.Id == id);

        void OnClosingItem(ItemActionCallbackArgs<TabablzControl> e)
        {
            var tab = (e.DragablzItem.DataContext as BasePage);
            if (tab.ViewModel.CanClose())
            {
                pages.Remove(tab);
                Items.Remove(tab);
            }
            if (Items.Count == 0) Visibility = System.Windows.Visibility.Hidden;
            e.Cancel();
        }
    }
}
