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
    public partial class Form_график : Form
    {
        public Form_график()
        {
            InitializeComponent();
        }

        private void Form_график_Load(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(@"data source=LAPTOP-5B5LI774\SQLEXPRESS;initial catalog=Beauty;Integrated Security =true");
            var Command = new SqlCommand();
            Command.CommandText = "SELECT        Сотрудники.Табельный_номер_сотрудника as [Табельный номер сотрудника], Сотрудники.Фамилия as [Фамилия сотрудника], Записи.Дата_визита as [Дата], Записи.Время_начала as [Время], Услуги.Наименование_услуги as Услуга, Клиенты.Фамилия AS [Фамилия клиента] FROM Записи INNER JOIN   Клиенты ON Записи.Код_клиента = Клиенты.Код_клиента INNER JOIN  Сотрудники ON Записи.Табельный_номер_сотрудника = Сотрудники.Табельный_номер_сотрудника INNER JOIN   Услуги ON Записи.Код_услуги = Услуги.Код_услуги";
            Command.Connection = Connection;
            SqlDataAdapter s = new SqlDataAdapter(Command);
            DataTable dt = new DataTable();
            s.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.RowCount; i++)
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

        private void Button2_Click(object sender, EventArgs e)
        {
            Assist assist = new Assist();
            assist.WriteExcel(dataGridView1);
        }
    }
}
