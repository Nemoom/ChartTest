using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChartTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        class chartPoints
        {
            public chartPoints(int mx,double my)
            {
                x = mx;
                y = my;
            }
            public double x { get; set; }
            public double y { get; set; }
        }
        Queue<chartPoints> q = new Queue<chartPoints>();
        int n=0;
        private void Button2_Click(object sender, EventArgs e)
        {
            if (true)
            {
                Random rd = new Random();
                if (q.Count>120)
                {
                    q.Dequeue();
                }
                q.Enqueue(new chartPoints(n++, (rd.NextDouble() *((double)numericUpDown2.Value- (double)numericUpDown1.Value) + (double)numericUpDown1.Value) * Math.Sin(Math.PI * 2 * n / (double)numericUpDown3.Value)));
               
                
                chart1.DataSource = q.ToList<chartPoints>(); //将listp绑定给chart1

                chart1.Series[0].XValueMember = "x";//将listp中所有Name元素作为X轴

                chart1.Series[0].YValueMembers = "y";//将listp中所有Value元素作为Y轴

                chart1.DataBind(); //绑定数据
                //button2.Text = "End";
            }
            else
            {
                //button2.Text = "Start";
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Button2_Click(sender, e);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                timer1.Enabled = true;
                button1.Text = "End";
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "Start";
            }
        }
    }
}
