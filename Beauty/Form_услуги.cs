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
    public partial class Form_услуги : Form
    {
        public Form_услуги()
        {
            InitializeComponent();
        }

        private void Form_услуги_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautyDataSet.Услуги". При необходимости она может быть перемещена или удалена.
            this.услугиTableAdapter.Fill(this.beautyDataSet.Услуги);
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            this.label1.Text = "";
            radioButton2.Checked = true;

        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          
            this.textBox2.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.textBox3.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.textBox4.Text = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            this.label1.Text = "Данные новой услуги";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            this.label1.Text = "Редактирование данных";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ( textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            { MessageBox.Show("Заполните все поля"); }
            else
            {
                try
                {
                    услугиTableAdapter.Insert( textBox2.Text, Convert.ToDecimal( textBox3.Text), textBox4.Text);
                    услугиTableAdapter.Update(this.beautyDataSet.Услуги);
                    MessageBox.Show("Запись успешно добавлена!");
                }
                catch
                {

                }

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            { MessageBox.Show("Заполните все поля"); }
            else
            {
                try
                {
                    услугиTableAdapter.Update(textBox2.Text, Convert.ToDecimal(textBox3.Text), textBox4.Text, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), textBox2.Text, Convert.ToDecimal(textBox3.Text), textBox4.Text);

                    
                    //услугиTableAdapter.Update(this.beautyDataSet.Услуги);
                    MessageBox.Show("Изменения сохранены!");
                }
                catch
                {

                }

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                услугиTableAdapter.Delete( Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), textBox2.Text, Convert.ToDecimal(textBox3.Text), textBox4.Text);


                услугиTableAdapter.Update(this.beautyDataSet.Услуги);
                MessageBox.Show("Услуга удалена!");
            }
            catch
            {

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Assist assist = new Assist();
            assist.WriteExcel(dataGridView1);
        }
    }
}
