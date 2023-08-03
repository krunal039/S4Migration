using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Schroders.S4
{

    public class BookmarkBar
    {
        public List<Child> children { get; set; }
        public string date_added { get; set; }
        public string date_last_used { get; set; }
        public string date_modified { get; set; }
        public string guid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Child
    {
        public string date_added { get; set; }
        public string date_last_used { get; set; }
        public string guid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public MetaInfo meta_info { get; set; }
        public List<Child> children { get; set; }
        public string date_modified { get; set; }
    }

    public class MetaInfo
    {
        public string last_visited_desktop { get; set; }
        public string last_visited { get; set; }
    }

    public class Other
    {
        public List<Child> children { get; set; }
        public string date_added { get; set; }
        public string date_last_used { get; set; }
        public string date_modified { get; set; }
        public string guid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class BookmarkFile
    {
        public string checksum { get; set; }
        public Roots roots { get; set; }
        public string sync_metadata { get; set; }
        public int version { get; set; }
    }

    public class Roots
    {
        public BookmarkBar bookmark_bar { get; set; }
        public Other other { get; set; }
        public Synced synced { get; set; }
    }

    public class Synced
    {
        public List<Child> children { get; set; }
        public string date_added { get; set; }
        public string date_last_used { get; set; }
        public string date_modified { get; set; }
        public string guid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}

