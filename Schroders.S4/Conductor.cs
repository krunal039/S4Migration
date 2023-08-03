using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Schroders.S4
{
    internal class Conductor
    {
        private SpoGraphClient _graphClient;
        private BookmarkManager _bookmarkManager;
        public Conductor()
        {
            _graphClient = new SpoGraphClient();
            _bookmarkManager = new BookmarkManager();
        }

        internal string GetUserName()
        {
            return Environment.UserName;
        }

        internal bool IsUserBookmarkCopiedToSpo(string userName)
        {
            return _graphClient.GetUserDateFromSpoAsync(userName).Result != null;
        }

        internal bool AddUserBookmarkToSpo(MigrationUser user)
        {
            var userData = GetUserBookmarkFromSpo(user.User);
            if (userData == null)
            {
                return _graphClient.AddUserDataAsync(user.User, user.IsBookMarkUpdate, user.IsS3, user.IsS4,
                    user.LocalFileCopy, user.ChromeBookMarks, user.EdgeBookMarks).Result != null;
            }
            else
            {
                return _graphClient.UpdateUserDataAsync(userData.UserId, user.User, user.IsBookMarkUpdate, user.IsS4, user.IsS4,
                    user.LocalFileCopy, user.ChromeBookMarks, user.EdgeBookMarks).Result != null;
            }
        }

        internal MigrationUser? GetUserBookmarkFromSpo(string userName)
        {
           return _graphClient.GetUserDateFromSpoAsync(userName).Result;
        }

        internal bool UpdateUserBookmarkToSpo(MigrationUser user)
        {
            if (user.User == null) return false;
            var userData = GetUserBookmarkFromSpo(user.User);
            return  _graphClient.UpdateUserDataAsync(userData.UserId, user.User, user.IsBookMarkUpdate, user.IsS4, user.IsS4,
                user.LocalFileCopy, user.ChromeBookMarks, user.EdgeBookMarks).Result != null;
        }

        internal void SaveUserBookmarkS3()
        {
            var migrationUser = new MigrationUser()
            {
                User = GetUserName(),
                Title = GetUserName(),
                IsS4 = false,
                IsBookMarkUpdate = false,
                EdgeBookMarks = Newtonsoft.Json.JsonConvert.SerializeObject(_bookmarkManager.GetEdgeBookmark()),
                ChromeBookMarks = Newtonsoft.Json.JsonConvert.SerializeObject(_bookmarkManager.GetChromeBookmark()),
                IsS3 = true,
                LocalFileCopy = false,
            };

            AddUserBookmarkToSpo(migrationUser);
        }

        internal void MergeAndSaveBookmark()
        {
            try
            {
                var userData = GetUserBookmarkFromSpo(GetUserName());
                _bookmarkManager.SaveEdgeBookmark(_bookmarkManager.MergeChromeEdgeBookmark(userData.ChromeBookMarks, Newtonsoft.Json.JsonConvert.SerializeObject(_bookmarkManager.GetEdgeBookmark())));
                userData.IsS4 = true;
                userData.IsBookMarkUpdate = true;
                UpdateUserBookmarkToSpo(userData);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
