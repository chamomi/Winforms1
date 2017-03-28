using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Win_Forms1
{
    public partial class Form1 : Form
    {
        int round = 0, n=10;
        int rounds = 0;
        Form parent;
        bool stop = false;
        static int[][] history;
        public Form1(Form par)
        {
            InitializeComponent();
            label9.Text = Form2.cname;
            label10.Text = Form2.uname;
            label8.Text = Form2.num;
            n = Int32.Parse(Form2.num);
            parent = par;
            history = new int[2][];
            history[0] = new int[n];
            history[1] = new int[n];
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Hide();
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
            button3.Text = u.ToString();
            button2.Text = c.ToString();
            history[0][round-1] = u;
            history[1][round-1] = c;
            if (u > c)
            {
                button3.BackColor = Color.Green;
                button2.BackColor = Color.Red;

                label3.Text = (Int32.Parse(label3.Text) + 1).ToString();
            }
            else if (c > u)
            {
                button3.BackColor = Color.Red;
                button2.BackColor = Color.Green;

                label4.Text = (Int32.Parse(label4.Text) + 1).ToString();
            }
            else
            {
                button3.BackColor = Color.Orange;
                button2.BackColor = Color.Orange;
            }
            if (round == n)
            {
                //write to file
                File.AppendAllText(@".\highsc.highs", label10.Text + "," + label3.Text + "," + label8.Text + "\n");
                DialogResult dires = MessageBox.Show("Show postgame stats?", "Stats", MessageBoxButtons.YesNo);
                if (dires == DialogResult.No)
                {
                }
                else if (dires == DialogResult.Yes)
                {
                    //show stats
                    var stat = new Stats(history.ToArray());
                    stat.ShowDialog();
                }

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
                    this.Close();
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
                e.Cancel = true;
        }

        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //read file
            var high = new Highscores();
            high.ShowDialog();
        }

        //save-load
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.Filter = "wargame files (*.wargame)|*.wargame";
            if (saveFile1.ShowDialog() == DialogResult.OK)
            {
                String path = saveFile1.FileName;
                File.AppendAllText(path, Form2.uname + "," + label3.Text + "," + Form2.cname + "," + label4.Text + "," + n + "," + label6.Text +"\n");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            openFile1.DefaultExt = "*.wargame";
            openFile1.Filter = "wargame Files(.wargame)|*.wargame";


            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile1.FileName.Length > 0)
            {
                String path = openFile1.FileName;

                string text = System.IO.File.ReadAllText(path);
                string[] data = text.Split(',');
                button2.BackColor = Color.Transparent;
                button3.BackColor = Color.Transparent;
                label10.Text = data[0];
                label3.Text = data[1];
                label9.Text = data[2];
                label4.Text = data[3];
                label8.Text = data[4];
                label6.Text = data[5];
                n = Int32.Parse(data[4]);
            }
        }

        //autoplay
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Stop") stop = true;
            button5.Text = "Stop";
            Timer timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = trackBar1.Value;
            rounds = Int32.Parse(textBox1.Text)- Int32.Parse(label6.Text);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((rounds == 0)||(stop == true)||(Int32.Parse(label6.Text)== Int32.Parse(label8.Text)))
            {
                timer1.Stop();
                rounds = 0;
                stop = false;
                button5.Text = "Start";
            }
            else
            {
                timer1.Stop();
                button4.PerformClick();
                rounds--;
                timer1.Interval = trackBar1.Value;
            }
        }

        public static bool CloseCancel()
        {
            var result = MessageBox.Show("Close app?", "Exit",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
    }
    
}
