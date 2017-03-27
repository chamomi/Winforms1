using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Win_Forms1
{
    public partial class Highscores : Form
    {
        int counter = 0;
        public Highscores()
        {
            InitializeComponent();
            string line;
            string[] it;
            ListViewItem item;
            System.IO.StreamReader file = new System.IO.StreamReader(@".\highsc.highs");
            while ((line = file.ReadLine()) != null)
            {
                it = line.Split(',');
                item = new ListViewItem(it[0]);
                listView1.Items.Add(item);
                item = new ListViewItem(it[1]);
                listView2.Items.Add(item);
                item = new ListViewItem(it[2]);
                listView3.Items.Add(item);
                counter++;
            }

            file.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
