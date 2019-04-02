using memebomb_forms.Internal;
using Newtonsoft.Json.Linq;
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
    public partial class Form1 : Form
    {

        List<Image> memes = new List<Image>();
        static Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            memes.Add(images._920x920);
            memes.Add(images.maxresdefault);
            memes.Add(images.Screen_Shot_2018_02_10_at_2_07_27_PM);
            memes.Add(images.VegNewsMeme);

            progressBar1.Value = 10;

            JObject x = RedditMemesParser.Json("");
            int y = x["data"]["children"].Children().Count();
            JToken[] z = x["data"]["children"].Children().ToArray();
            
            var list = RedditMemesParser.Urls(z);

            progressBar1.Value = 50;

            fuckinImages(list.ToArray());
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {
            int c = rnd.Next(1, 25);
            for (int i = 0; i < c; i++)
            {
                Task.Run(() =>
                {
                    MessageBomb bomb = new MessageBomb();
                });
            }
        }

        private void fuckinImages(string[] list)
        {
            int c = rnd.Next(1, list.Length) - 1;
            for (int i = 0; i < c; i++)
            {
                Task.Run(() =>
                {
                    int c = rnd.Next(1, list.Length) - 1;
                    ShowMeme memeShower = new ShowMeme(list[c]);
                });
            }
            this.Hide();
        }
    }
}
