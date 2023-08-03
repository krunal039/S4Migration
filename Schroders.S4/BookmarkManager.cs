using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schroders.S4
{
    internal class BookmarkManager
    {
        readonly string _userAppDateLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        internal BookmarkFile? GetChromeBookmark()
        {
            var chromeBookmarkFilePath = $@"{_userAppDateLocation}\Google\Chrome\User Data\Default\Bookmarks";
            var content = File.ReadAllText(chromeBookmarkFilePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<BookmarkFile>(content);

        }

        internal void SaveChromeBookmark(BookmarkFile file)
        {
            var chromeBookmarkFilePath = $@"{_userAppDateLocation}\Google\Chrome\User Data\Default\Bookmarks";
            File.WriteAllText(Newtonsoft.Json.JsonConvert.SerializeObject(file), chromeBookmarkFilePath);
        }

        internal void SaveEdgeBookmark(BookmarkFile file)
        {
            var edgeBookmarkFilePath = $@"{_userAppDateLocation}\Microsoft\Edge\User Data\Default\Bookmarks";
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(file);
            File.WriteAllText(edgeBookmarkFilePath,content);
            File.WriteAllText($@"{_userAppDateLocation}\Microsoft\Edge\User Data\Default\Bookmarks.bak", content);
            File.WriteAllText($@"{_userAppDateLocation}\Microsoft\Edge\User Data\Default\Bookmarks.msbak", content);
        }

        internal BookmarkFile? GetEdgeBookmark()
        {
            var edgeBookmarkFilePath = $@"{_userAppDateLocation}\Microsoft\Edge\User Data\Default\Bookmarks";
            var content = File.ReadAllText(edgeBookmarkFilePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<BookmarkFile>(content);
        }

        internal bool RemoveEdgeMSBookmarkBackup()
        {
            File.Delete(($@"{_userAppDateLocation}\Microsoft\Edge\User Data\Default\Bookmarks.bak"));
            File.Delete(($@"{_userAppDateLocation}\Microsoft\Edge\User Data\Default\Bookmarks.msbak"));

            return true;
        }

        internal BookmarkFile MergeChromeEdgeBookmark(string chromeBookmark, string edgeBoomark)
        {
            RemoveEdgeMSBookmarkBackup();
            var chromeBm = Newtonsoft.Json.JsonConvert.DeserializeObject<BookmarkFile>(chromeBookmark);
            var edgeBm = Newtonsoft.Json.JsonConvert.DeserializeObject<BookmarkFile>(edgeBoomark);

            var chromeImportBookmarkBar = chromeBm?.roots.bookmark_bar;

            edgeBm?.roots.bookmark_bar.children.Add(new Child()
            {
                guid = chromeImportBookmarkBar?.guid,
                children = chromeImportBookmarkBar?.children,
                date_added = chromeImportBookmarkBar.date_added,
                date_last_used = chromeImportBookmarkBar.date_last_used,
                date_modified = chromeImportBookmarkBar.date_last_used,
                id = chromeImportBookmarkBar.id,
                name = "S3 - Chrome Bookmarkbar import",
                type = chromeImportBookmarkBar.type,
            });

            var chromeImportSynced = chromeBm.roots.synced;

            edgeBm?.roots.synced.children.Add(new Child()
            {
                guid = chromeImportSynced.guid,
                children = chromeImportSynced.children,
                date_added = chromeImportSynced.date_added,
                date_last_used = chromeImportSynced.date_last_used,
                date_modified = chromeImportSynced.date_last_used,
                id = chromeImportSynced.id,
                name = "S3 - Chrome Synced import",
                type = chromeImportSynced.type,
            });

            var chromeImportOther = chromeBm.roots.other;

            edgeBm?.roots.synced.children.Add(new Child()
            {
                guid = chromeImportOther.guid,
                children = chromeImportOther.children,
                date_added = chromeImportOther.date_added,
                date_last_used = chromeImportOther.date_last_used,
                date_modified = chromeImportOther.date_last_used,
                id = chromeImportOther.id,
                name = "S3 - Chrome Other import",
                type = chromeImportOther.type,
            });
            return edgeBm;
        }

    }
}
