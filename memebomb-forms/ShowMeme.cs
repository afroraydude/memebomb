using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memebomb_forms
{
    public partial class ShowMeme : Form
    {
        public ShowMeme(string url)
        {
            InitializeComponent();
            pictureBox1.Load(url);
            this.Show();
            MessageBox.Show(url);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
