using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beauty
{
    public partial class Form_зп : Form
    {
        public Form_зп()
        {
            InitializeComponent();
        }

        private void Form_зп_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Connection = new SqlConnection(Data.ConnectionString);
                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;
                Command.CommandText = "Select b.Табельный_номер_сотрудника as [Табельный номер сотрудника],Фамилия,Имя,Отчество,Оплата_руб_в_час as Ставка,Количество as [Количество обслуженных клиентов],(Оплата_руб_в_час*Количество)*0.87 as [Заработная плата] From Сотрудники_Обслужили_За(@startDate,@endDate) b inner join Сотрудники_Тариф ON Сотрудники_Тариф.Табельный_номер_сотрудника = b.Табельный_номер_сотрудника";
                SqlParameter p1 = new SqlParameter("startDate", dateTimePicker1.Value.ToShortDateString());
                SqlParameter p2 = new SqlParameter("endDate", dateTimePicker2.Value.ToShortDateString());
                Command.Parameters.Add(p1);
                Command.Parameters.Add(p2);
                SqlDataAdapter adapter = new SqlDataAdapter(Command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Assist assist = new Assist();
            assist.WriteExcel(dataGridView1);
        }
    }
}
