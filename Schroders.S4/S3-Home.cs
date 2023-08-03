using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schroders.S4
{
    public partial class S3_Home : Form
    {
        Conductor _conductor;
        SpoGraphClient _spoGraphClient;

        public S3_Home()
        {
            InitializeComponent();
            _conductor = new Conductor();
        }

        private void S3_Home_Load(object sender, EventArgs e)
        {
            webViewS3.Source = new Uri("https://agreeable-grass-097851c03.3.azurestaticapps.net/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _spoGraphClient = new SpoGraphClient();
            _conductor.SaveUserBookmarkS3();
        }
    }
}
