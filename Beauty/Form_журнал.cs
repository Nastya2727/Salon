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
    public partial class Form_журнал : Form
    {
        public Form_журнал()
        {
            InitializeComponent();
        }
        public bool Off = false;

        private void loadDT()
        {
            SqlConnection Connection = new SqlConnection(@"data source=LAPTOP-5B5LI774\SQLEXPRESS;initial catalog=Beauty;Integrated Security =true");
            var Command = new SqlCommand();
            Command.CommandText = "SELECT        Записи.Код_записи as Код, Записи.Дата_визита as [Дата визита], Записи.Время_начала as [Время начала], Записи.Код_услуги as [Код услуги], Услуги.Наименование_услуги as Услуга, Записи.Табельный_номер_сотрудника as [Код сотрудника], Сотрудники.Фамилия as [Фамилия сотрудника], Записи.Код_клиента as [Код клиента], Клиенты.Фамилия AS [Фамилия клиента], Записи.Посещение FROM Записи INNER JOIN   Клиенты ON Записи.Код_клиента = Клиенты.Код_клиента INNER JOIN   Сотрудники ON Записи.Табельный_номер_сотрудника = Сотрудники.Табельный_номер_сотрудника INNER JOIN   Услуги ON Записи.Код_услуги = Услуги.Код_услуги";
            Command.Connection = Connection;
            SqlDataAdapter s = new SqlDataAdapter(Command);
            DataTable dt = new DataTable();
            s.Fill(dt);
            dataGridView1.DataSource = dt;
        } 
        private void Form_журнал_Load(object sender, EventArgs e)
        {
            loadDT();
        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
                this.textBox1.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.textBox2.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.textBox3.Text = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.textBox4.Text = this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                this.textBox5.Text = this.dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                this.comboBox1.Text = this.dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime dateOfVisit = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                //int codeOfService = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                //int codeOfWorker = Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                //int codeOfClient = Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value.ToString());

                //string startAt = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //string[] time = startAt.Split(':');
                //TimeSpan timeOfStart = new TimeSpan(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), Convert.ToInt32(time[2]));
                //string attendance = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                //записиTableAdapter1.Update(dateOfVisit, codeOfService, codeOfWorker, codeOfClient, timeOfStart, attendance, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), dateOfVisit, codeOfService, codeOfWorker, codeOfClient, timeOfStart, "Да");

                int code = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlConnection Connection = new SqlConnection(@"data source=LAPTOP-5B5LI774\SQLEXPRESS;initial catalog=Beauty;Integrated Security =true");
                var Command = new SqlCommand();
                Command.CommandText = "Update Записи Set Посещение='Да' Where Код_записи=@code";
                SqlParameter p1 = new SqlParameter("code", code);
                Command.Parameters.Add(p1);
                Command.Connection = Connection;
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();

                MessageBox.Show("Изменения сохранены");
                loadDT();
            }
            catch (Exception ex)
            {
                if (Off == true)
                {

                }
                else
                    MessageBox.Show("" + ex.Message);
            }
           

        }
    }
}
