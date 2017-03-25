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
    public partial class Form2 : Form
    {
        public static String uname="user", cname="cpu", num="10";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text=="")|| (textBox2.Text == "")|| (textBox3.Text == ""))
            {
                DialogResult dialogResult = MessageBox.Show("Fill all the fields", "Error", MessageBoxButtons.OK);
            }
            else
            {
                uname = textBox1.Text;
                cname = textBox3.Text;
                num = textBox2.Text;
                var frm1 = new Form1();
                frm1.FormClosed += new FormClosedEventHandler(frm1_FormClosed);
                frm1.Show();
                this.Hide();
            }
        }

        private void frm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
                e.Cancel = true;
        }

        public static bool CloseCancel()
        {
            const string message = "Close app?";
            const string caption = "Exit";
            var result = MessageBox.Show(message, caption,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
    }
}
