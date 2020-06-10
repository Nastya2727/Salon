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
    public partial class Form_добавить_клиента : Form
    {
        public Form_добавить_клиента()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            { MessageBox.Show("Заполните все поля"); }
            else
            {
                try
                {
                    клиентыTableAdapter1.Insert(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    клиентыTableAdapter1.Update(this.beautyDataSet1.Клиенты);
                    MessageBox.Show("Запись успешно добавлена!");
                }
                catch
                {

                }

            }
        }
    }
}
