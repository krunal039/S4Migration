using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schroders
{
    internal class MigrationUser
    {
        public string? UserId { get; set; }
        public string? User { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsBookMarkUpdate { get; set; }
        public bool IsS3 { get; set; }
        public bool IsS4 { get; set; }
        public bool LocalFileCopy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string? ChromeBookMarks { get; set; }
        public string? EdgeBookMarks { get; set; }


    }

    internal class MigationQuestion {
        public string? Question { get; set; }
        public int Order{ get; set; }
        public bool IsActive { get; set; }
    }
}
