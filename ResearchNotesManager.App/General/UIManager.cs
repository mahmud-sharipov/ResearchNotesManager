using MaterialDesignThemes.Wpf;
using ResearchNotesManager.App.Controls;
using ResearchNotesManager.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.App.General
{
    public static class UIManager
    {
        public static class PageManager
        {
            static List<string> OpenedPages { get; } = new List<string>();

            public static BasePage HomePage { get; set; }

            public static AdvancedTabablzControl PagesControl;

            public static void AddPage(BasePage page) => PagesControl.AddPage(page);

            public static void AddPages(List<BasePage> pages) => PagesControl.AddPages(pages);

            public static void SetCurrentPage(string id) => PagesControl.SetSelectedItem(id);

            public static bool IsPageAlreadyOpened(string id) => PagesControl.IsPageAlreadyOpened(id);

            public static void AddToOpenedPages(string pageId)
            {
                if (!OpenedPages.Any(id => id == pageId))
                    OpenedPages.Add(pageId);
            }

            public static void RemoveFromOpenedPages(string pageId) => OpenedPages.Remove(pageId);
        }

        //public static class LoginManager
        //{
        //    public static string GetHash(string input) => User.GetHash(input);

        //    // Verify a hash against a string.
        //    public static bool VerifyMd5Hash(string input, string hash) => User.VerifyMd5Hash(input, hash);

        //    public static bool Login(string username, string password, DataProvider dataProvider)
        //    {
        //        var passwordHash = GetHash(password);
        //        var user = dataProvider.GetEntities<User>().SingleOrDefault(u => u.Username == username && u.Password == passwordHash);
        //        return user != null;
        //    }

        //    public static bool IsUserExists(string username, DataProvider dataProvider) => dataProvider.GetEntities<User>().Any(u => u.Username == username);

        //    public static bool CanChangePassword(string username, string oldPassword, DataProvider dataProvider)
        //    {
        //        var passwordHash = GetHash(oldPassword);
        //        var user = dataProvider.GetEntities<User>().SingleOrDefault(u => u.Username == username);
        //        if (user == null)
        //            throw new Exception($"The user with '{user}' username not found");
        //        return (user.Password == passwordHash || user.ChangePasswordLogs.Any(l => l.OldPassword == passwordHash));
        //    }

        //    public static void ChangePassword(string username, string newPassword, DataProvider dataProvider)
        //    {
        //        var passwordHash = GetHash(newPassword);
        //        var user = dataProvider.GetEntities<User>().SingleOrDefault(u => u.Username == username);
        //        if (user == null)
        //            throw new Exception($"The user with '{user}' username not found");
        //        var log = new ChangePasswordLogItem(user.Context) { OldPassword = user.Password, User = user };
        //        user.Password = passwordHash;
        //        dataProvider.SaveChanges();
        //    }
        //}

        public static class MessageManager
        {
            static Snackbar _snackbar;

            public static void SetSnackbar(Snackbar snackbar) => _snackbar = snackbar;

            public static void ShowMessage(string message, string actionContent = "Ok")
            {
                _snackbar.MessageQueue.Enqueue(message, actionContent,
                param => { }, message, false, true);
            }
        }

        //public static int GetNumberOfOpenedWindows() => BootStrap.Application.Windows.Count;
    }
}
