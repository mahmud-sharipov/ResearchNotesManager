using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.App.General
{
    interface IPagesControl
    {
        void AddPage(BasePage page);

        void AddPages(IEnumerable<BasePage> pages);

        void SetSelectedItem(string id);

        bool IsPageAlreadyOpened(string id);
    }
}
