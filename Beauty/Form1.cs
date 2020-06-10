using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beauty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Beauty.Form_клиенты f = new Form_клиенты();
            f.Show();
        }

        private void СотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Beauty.Form_сотрудники f = new Form_сотрудники();
            f.Show();

        }

        private void УслугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Beauty.Form_услуги f = new Form_услуги();
            f.Show();
        }

        private void ТоварыИМатериалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Beauty.Form_товары f = new Form_товары();
            f.Show();
        }

        private void ГрафикРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Beauty.Form_график f = new Form_график();
            f.Show();
        }

        private void ЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Beauty.Form_запись f = new Form_запись();
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;
            this.Enabled = false;
            Form_auth f = new Form_auth();
            f.ShowDialog();
            if (Data.Logged == 0)
            {
                try
                {
                    this.Dispose();
                }
                catch
                {

                }
            }
            else if (Data.Logged == 1)
            {
                this.Enabled = true;
            }
        }
    }
}
