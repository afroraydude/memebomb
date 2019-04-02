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

    public partial class MessageBomb : Form
    {
        static Random rnd = new Random();

        public MessageBomb()
        {
            InitializeComponent();
            this.Show();
            MessageBox.Show(RandomString(rnd.Next(50)));
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        private void MessageBomb_Load(object sender, EventArgs e)
        {

        }
    }
}
