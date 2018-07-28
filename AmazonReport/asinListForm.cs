using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonReport
{
    public partial class asinListForm : Form
    {
        public string asinAnItems { get; set; }
        public string asinItemses { get; set; }

        public asinListForm()
        {
            InitializeComponent();
        }

        private void asinListForm_Load(object sender, EventArgs e)
        {
            anIntemText.Text = asinAnItems;
            itemsText.Text = asinItemses;
        }
    }
}
