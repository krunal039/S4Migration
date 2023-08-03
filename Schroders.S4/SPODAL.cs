using Microsoft.Graph;
using Microsoft.Graph.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Schroders.S4
{
    public class SpoGraphClient : GraphClientProviderBase
    {
        readonly string _siteId = "kmpdev.sharepoint.com,642775f6-57da-4191-bec1-6e9d86d491e2,42964a66-38cd-4f27-aadd-2630824fbdab";
        readonly string _bookmarkListId = "ba548eae-8800-439b-8eea-8cb7df755be3";
        readonly string _questionListId = "ab57f787-5031-4f14-8d85-9bdfce863375";

        public SpoGraphClient() => SchrodersGraphClient = CreateServiceContext();

        public GraphServiceClient SchrodersGraphClient { get; }

        private MigrationUser? GetUserDateFromSpo(string userName)
        {
            MigrationUser? migrationUser = null;
            if (userName == null) throw new ArgumentNullException(nameof(userName));

            var results = SchrodersGraphClient.Sites[_siteId].Lists[_questionListId].Items.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Filter = $"Fields/User eq '{userName}'";
                requestConfiguration.QueryParameters.Expand = new string[] { $"Fields" };
            }).Result?.Value;

            if (results is not { Count: > 0 }) return migrationUser;
            var tempS4MigrationItem = results[0];
            migrationUser = new
                MigrationUser
            {
                ChromeBookMarks = tempS4MigrationItem.Fields?.AdditionalData["Bookmark"].ToString(),
                EdgeBookMarks = tempS4MigrationItem.Fields?.AdditionalData["EdgeBookmark"].ToString(),
                UserId = tempS4MigrationItem.Id,
                Created = tempS4MigrationItem.CreatedDateTime.Value.UtcDateTime,
                IsBookMarkUpdate = Convert.ToBoolean(tempS4MigrationItem.Fields?.AdditionalData["IsBookMarkUpdate"]),
                IsS3 = Convert.ToBoolean(tempS4MigrationItem.Fields?.AdditionalData["_x0049_sS3"]),
                IsS4 = Convert.ToBoolean(tempS4MigrationItem.Fields?.AdditionalData["_x0049_sS4"]),
                LocalFileCopy = Convert.ToBoolean(tempS4MigrationItem.Fields?.AdditionalData["LocalFileCopy"]),
                Modified = tempS4MigrationItem.CreatedDateTime.Value.UtcDateTime,
                Title = tempS4MigrationItem.Fields?.AdditionalData["Title"].ToString(),
                User = tempS4MigrationItem.Fields?.AdditionalData["User"].ToString(),
            };

            return migrationUser;

        }

        internal Task<ListItem?> AddUserDataAsync(string user, bool isBookMarkUpdate, bool isS3, bool isS4,
            bool localFileCopy,
            string chromeBookmark, string edgeBookmark)
        {
            return Task.Run(() => AddUserData(user, isBookMarkUpdate, isS3, isS4, localFileCopy, chromeBookmark, edgeBookmark));
        }

        private FieldValueSet? UpdateUserData(string itemId, string user, bool isBookMarkUpdate, bool isS3, bool isS4, bool localFileCopy, string chromeBookmark, string edgeBookmark)
        {
            var requestBody = new FieldValueSet
            {
                AdditionalData = new Dictionary<string, object>
                {
                    {
                        "Title", user
                    },
                    {
                        "User", user
                    },
                    {
                        "_x0049_sS3", isS3
                    },
                    {
                        "_x0049_sS4", isS4
                    },
                    {
                        "IsBookMarkUpdate", localFileCopy
                    },
                    {
                        "LocalFileCopy", localFileCopy
                    },
                    {
                        "Bookmark", chromeBookmark
                    },
                    {
                        "EdgeBookmark", edgeBookmark
                    }
                }
            };

            var results = SchrodersGraphClient.Sites[_siteId].Lists[_bookmarkListId].Items[itemId].Fields.PatchAsync(requestBody).Result;
            return results;
        }

        internal Task<FieldValueSet?> UpdateUserDataAsync(string itemId, string user, bool isBookMarkUpdate, bool isS3, bool isS4,
            bool localFileCopy,
            string chromeBookmark, string edgeBookmark)
        {
            return Task.Run(() => UpdateUserData(itemId, user, isBookMarkUpdate, isS3, isS4, localFileCopy, chromeBookmark, edgeBookmark));
        }

        private ListItem? AddUserData(string user, bool isBookMarkUpdate, bool isS3, bool isS4, bool localFileCopy, string chromeBookmark, string edgeBookmark)
        {
            var requestBody = new ListItem
            {
                Fields = new FieldValueSet
                {
                    AdditionalData = new Dictionary<string, object>
                    {
                        {
                            "Title" , user
                        },
                        {
                            "User" , user
                        },
                        {
                            "_x0049_sS3" , isS3
                        },{
                            "_x0049_sS4" , isS4
                        },{
                            "IsBookMarkUpdate" , localFileCopy
                        },{
                            "LocalFileCopy" , localFileCopy
                        },{
                            "Bookmark" , chromeBookmark
                        },{
                            "EdgeBookmark" , edgeBookmark
                        }
                    },
                },
            };

            var results = SchrodersGraphClient.Sites[_siteId].Lists[_bookmarkListId].Items.PostAsync(requestBody).Result;
            return results;
        }


        internal async Task<List<MigationQuestion?>> GetQuestionsSpoAsync()
        {
            return await Task.Run(() => GetQuestionsFromSpo());

        }

        private List<MigationQuestion?> GetQuestionsFromSpo()
        {
            var migrationQuestions = new List<MigationQuestion?>();
            var results = SchrodersGraphClient.Sites[_siteId].Lists[_questionListId].Items.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Expand = new string[] { "fields" };
            }).Result?.Value;

            if (results is not { Count: > 0 }) return migrationQuestions;
            migrationQuestions.AddRange(results.Select(result => new MigationQuestion { Question = result.Fields?.AdditionalData["Title"].ToString(), IsActive = Convert.ToBoolean(result.Fields?.AdditionalData["IsActive"]), Order = Convert.ToInt32(result.Fields?.AdditionalData["Order0"]), }));

            return migrationQuestions;

        }

        internal async Task<MigrationUser?> GetUserDateFromSpoAsync(string userName)
        {
            if (userName == null) throw new ArgumentNullException(nameof(userName));
            return await Task.Run(() => GetUserDateFromSpo(userName));

        }

    }
}
