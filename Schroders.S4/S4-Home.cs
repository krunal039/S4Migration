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
    public partial class S4_Home : Form
    {
        Conductor _conductor;
        SpoGraphClient _spoGraphClient;

        public S4_Home()
        {
            _conductor = new Conductor();
            _spoGraphClient = new SpoGraphClient();
            InitializeComponent();
        }

        private void S4_Home_Load(object sender, EventArgs e)
        {
            try
            { 
                webViewS4.Source = new Uri("https://agreeable-grass-097851c03.3.azurestaticapps.net/index-S4.html");
            
                _conductor.MergeAndSaveBookmark();
            }
            catch
            {
            }

           
        }
    }
}
