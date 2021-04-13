using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cubik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        int val1, val2;

        private void lucky(int val1, int val2)
        {
            if (val1 == val2)
                label3.Visible = true;
            else
                label3.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string loc_img1, loc_img2;
            
            button1.Enabled = false;
            for (int i = 0; i < 5; i++)
            {
                val1 = rnd.Next(1, 7);
                val2 = rnd.Next(1, 7);
                loc_img1 = val1.ToString() + ".png";
                pictureBox1.Image = Image.FromFile(loc_img1);
                loc_img2 = val2.ToString() + ".png";
                pictureBox2.Image = Image.FromFile(loc_img2);
                Wait(0.2);
            }
            button1.Enabled = true;
            if (comboBox1.SelectedIndex == 1)
                lucky(val1, val2);

            int sum;
            sum = val1 + val2;
            label2.Text = ("Сумма = " + Convert.ToString(sum));
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            button1.Enabled = true;
            switch (index)
            {
                case 0:
                    pictureBox1.Location = new Point(105, 55);
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                    label2.Visible = false;
                    
                    break;
                case 1:
                    pictureBox1.Location = new Point(36, 55);
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    label2.Visible = true;
                    
                    break;
            }
            
        }
        private void Wait(double seconds)
        {
            int ticks = System.Environment.TickCount + (int)Math.Round(seconds * 1000.0);
            while (System.Environment.TickCount < ticks)
            {
                Application.DoEvents();
            }
        }
    }
}
