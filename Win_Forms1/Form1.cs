using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Forms1
{
    public partial class Form1 : Form
    {
        int round = 0;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm2 = new Form2();
            frm2.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var abt = new About();
            abt.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int u, c;
            u = r.Next(1, 10);
            c = r.Next(1, 10);
            round++;
            label6.Text = (Int32.Parse(label6.Text) + 1).ToString();
            if (u>c)
            {
                button3.BackColor = Color.Green;
                button3.Text = u.ToString();
                button2.BackColor = Color.Red;
                button2.Text = c.ToString();

                label3.Text = (Int32.Parse(label3.Text) + 1).ToString();
            }
            else if(c>u)
            {
                button3.BackColor = Color.Red;
                button3.Text = u.ToString();
                button2.BackColor = Color.Green;
                button2.Text = c.ToString();

                label4.Text = (Int32.Parse(label4.Text) + 1).ToString();
            }
            else
            {
                button3.BackColor = Color.Orange;
                button3.Text = u.ToString();
                button2.BackColor = Color.Orange;
                button2.Text = c.ToString();
            }
            if (round == 10)
            {
                string s;
                if (Int32.Parse(label3.Text) > Int32.Parse(label4.Text)) s = "Win! Start new game?";
                else s = "Lose! Start new game?";
                DialogResult dialogResult = MessageBox.Show(s, "End", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    round = 0;
                    label3.Text = 0.ToString();
                    label4.Text = 0.ToString();
                    button2.BackColor = Color.Transparent;
                    button3.BackColor = Color.Transparent;
                    label6.Text = "0";
                    button3.Text = "";
                    button2.Text = "";
                }
                else if (dialogResult == DialogResult.No)
                {
                    button4.Enabled = false;
                }
                //var end = new End();
                //end.ShowDialog();
                //button4.Enabled = false;
                //this.Close();
            }
        }
    }
}
