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
            InitializeComponent();
            for (int i = 0; i < Int32.Parse(Form2.num); i++)
                for (int j = 0; j < Int32.Parse(Form2.num); j++)
                    scores[i][j] = a[i][j];
            Chart();
        }

        private void Chart()
        {
            //historyElement a;
            for (int i = 0; i < Int32.Parse(Form2.num); i++)
            {
                //a = scores[i];
                chart1.Series[0].Name = Form2.uname;
                chart1.Series[1].Name = Form2.cname;
                chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(Form2.num);
                //chart1.ChartAreas[0].AxisY.Maximum = 10 * Form1.sets;
                chart1.Series[0].Points.AddXY(i,2);
                chart1.Series[1].Points.AddXY(i, 3);
            }
        }

        private void Stats_Load(object sender, EventArgs e)
        {

        }
    }
}
