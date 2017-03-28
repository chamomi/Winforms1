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
    public partial class Stats : Form
    {
        int[][] scores;
        public Stats(int[][] a)
        {
            scores = new int[2][];
            scores[0] = new int[Int32.Parse(Form2.num)];
            scores[1] = new int[Int32.Parse(Form2.num)];
            InitializeComponent();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < Int32.Parse(Form2.num); j++)
                    scores[i][j] = a[i][j];
            Chart();
        }

        private void Chart()
        {
            for (int i = 0; i < Int32.Parse(Form2.num); i++)
            {
                //chart1.Series.Add("user");
                //chart1.Series.Add("cpu");
                //chart1.Series["user"].Name = Form2.uname;
               // chart1.Series["cpu"].Name = Form2.cname;
                chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(Form2.num);
                //chart1.Series[0].Points.DataBindY(scores[0]);
                //chart1.Series[0].Points.DataBindY(scores[1]);
                chart1.Series[0].Points.AddXY(i,scores[0][i]);
                //chart1.Series[1].Points.AddXY(i,scores[1][i]);
            }
        }

        private void Stats_Load(object sender, EventArgs e)
        {

        }
    }
}
