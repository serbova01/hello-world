using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
        }

        private void bADD_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\Львова\ЛБ2_КРПП\Price-list.txt");
            if (checkBox1.Checked)
            {
                sw.WriteLine($"{textBox1}.{textBox2}.{textBox3}.да");
            }
            else sw.WriteLine($"{textBox1}.{textBox2}.{textBox3}.нет");
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader fs = new StreamReader(@"C:\Львова\ЛБ2_КРПП\Price-list.txt", Encoding.Default);
            string s = fs.ReadToEnd();
            string[] things = s.Split('|');
            for (int i = 0; i < things.Length; i++)
            {
                string[] inf = things[i].Split('.');
                if (inf[3] == "да")
                {
                    dgvTableThing.Rows.Add(inf[0], inf[1], inf[2], true);
                }

                else
                    dgvTableThing.Rows.Add(inf[0], inf[1], inf[2], false);
            }
            fs.Close();
        }
    }
}
