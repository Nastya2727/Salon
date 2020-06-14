using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Beauty
{
    public partial class Form_сотрудники : Form
    {
        public Form_сотрудники()
        {
            InitializeComponent();
        }

        private void Form_сотрудники_Load(object sender, EventArgs e)
        {
            //Если во время аутентификации пользователя ему присвоено значение 2, то у него будет появляться эта кнопка.
           // if (Data.Logged == 2)
             //   button2.Visible = true;
           // else
             //   button2.Visible = false;
            //У тебя же типо будет доступ к добавлению пользователей у любой работнице которая типо на рецепции сидит и "главная" или как? 
            //Просто логин admin подразумевает что видеть пользователей и различать их удобно не получится, поэтому admin - типо для 1 главного человека.
            //Или как ты там сделала, короче напишешь. Коменты после того как прочитала удаляй) Доброе утро :D

            SqlConnection Connection = new SqlConnection(@"data source=LAPTOP-5B5LI774\SQLEXPRESS;initial catalog=Beauty;Integrated Security =true");
            var Command = new SqlCommand();
            Command.CommandText = "SELECT Сотрудники.Табельный_номер_сотрудника as [Код сотрудника],  Сотрудники.Фамилия, Сотрудники.Имя, Сотрудники.Отчество, Сотрудники.Дата_рождения as [Дата Рождения], Сотрудники.Адрес, Сотрудники.Телефон,  Специальности.Название_специальности as Специальность FROM  Сотрудники INNER JOIN Специальности ON Сотрудники.Код_специальности = Специальности.Код_специальности";
            Command.Connection = Connection;
            SqlDataAdapter s = new SqlDataAdapter(Command);
            DataTable dt = new DataTable();
            s.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox9.Text = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.textBox2.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.textBox3.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.textBox4.Text = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.textBox5.Text = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.textBox6.Text = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            this.textBox7.Text = this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            this.textBox8.Text = this.dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Beauty.Form_добавить_сотрудника f = new Form_добавить_сотрудника();
            f.Show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Assist assist = new Assist();
            assist.WriteExcel(dataGridView1);
        }
    }
}
