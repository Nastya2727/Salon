using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Beauty
{
    public partial class Form_пользователи : Form
    {
        public Form_пользователи()
        {
            InitializeComponent();
        }

        private void Form_пользователи_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautyDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.beautyDataSet.Сотрудники);

        }
        private string Hash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" )
            { MessageBox.Show("Заполните все поля"); }
            else
            {
                try
                {
                    пользователиTableAdapter1.Insert(textBox1.Text, Hash(textBox2.Text), Convert.ToInt32(comboBox1.SelectedValue));
                    пользователиTableAdapter1.Update(this.beautyDataSet.Пользователи);
                    MessageBox.Show("Запись успешно добавлена!");
                }
                catch
                {

                }

            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
