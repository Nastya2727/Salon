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
    public partial class Form_запись : Form
    {
        public object k_s = 0;
        public Form_запись()
        {
            InitializeComponent();
        }
        public bool Off = false;
        private void Form_запись_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautyDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.beautyDataSet.Клиенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautyDataSet.Услуги". При необходимости она может быть перемещена или удалена.
            this.услугиTableAdapter.Fill(this.beautyDataSet.Услуги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautyDataSet.Специальности". При необходимости она может быть перемещена или удалена.
            this.специальностиTableAdapter.Fill(this.beautyDataSet.Специальности);

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(@"data source=LAPTOP-5B5LI774\SQLEXPRESS;initial catalog=Beauty;Integrated Security =true");
            var Command = new SqlCommand();
            Command.CommandText = "SELECT  Сотрудники.Фамилия FROM Сотрудники INNER JOIN  Специальности ON Сотрудники.Код_специальности = Специальности.Код_специальности WHERE Специальности.Код_специальности = @Код_специальности";
            string str = Convert.ToString(comboBox1.SelectedValue);
            SqlParameter q = new SqlParameter("Код_специальности", str);
            Command.Parameters.Add(q);
            try
            {
                Command.Connection = Connection;
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                List<string> Titles = new List<string>();
                while (reader.Read())
                {
                    Titles.Add(reader.GetString(0));
                }
                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(Titles.ToArray());
                comboBox2.SelectedIndex = 0;
                Connection.Close();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            Код_сотрудника();
            try
            {
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(this.textBox1.Text);
                записиTableAdapter1.Insert(dateTimePicker1.Value.Date, Convert.ToInt32(comboBox3.SelectedValue), Convert.ToInt32(k_s), Convert.ToInt32(comboBox4.SelectedValue), dt.TimeOfDay, "");
                записиTableAdapter1.Update(this.beautyDataSet.Записи);
                MessageBox.Show("Запись добавлена");
            }
            catch
            {
                MessageBox.Show("Время занято");
            }
        }

        private void Код_сотрудника()
        {
            SqlConnection Connection = new SqlConnection(@"data source=LAPTOP-5B5LI774\SQLEXPRESS;initial catalog=Beauty;Integrated Security =true");
            var Command = new SqlCommand();
            Command.CommandText = "select Табельный_номер_сотрудника from Сотрудники where Фамилия = @f";
            SqlParameter q = new SqlParameter("f", comboBox2.SelectedItem.ToString());
            Command.Parameters.Add(q);
            try
            {
                Command.Connection = Connection;
                Connection.Open();
                SqlDataReader reade = Command.ExecuteReader();

                while (reade.Read())
                {
                    k_s = reade.GetValue(0);
                }
                Connection.Close();
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
        private void Загрузка_времени()
        {
            SqlConnection Connection = new SqlConnection(@"data source=LAPTOP-5B5LI774\SQLEXPRESS;initial catalog=Beauty;Integrated Security =true");
            var Command = new SqlCommand();

            Command.CommandText = "SELECT  Услуги.Наименование_услуги as Услуга, Записи.Время_начала as [Время записи] FROM Услуги INNER JOIN      Записи ON Услуги.Код_услуги = Записи.Код_услуги INNER JOIN   Сотрудники ON Записи.Табельный_номер_сотрудника = Сотрудники.Табельный_номер_сотрудника  Where Сотрудники.Табельный_номер_сотрудника = @d and Записи.Дата_визита = @data";
            SqlParameter datat = new SqlParameter("data", dateTimePicker1.Value.ToShortDateString());
            Command.Parameters.Add(datat);
            //  MessageBox.Show("" + DateTime.Now.ToShortDateString());
            SqlParameter ds = new SqlParameter("d", Convert.ToInt32(k_s));
            Command.Parameters.Add(ds);
            Command.Connection = Connection;
            SqlDataAdapter s = new SqlDataAdapter(Command);

            DataTable dt = new DataTable();
            s.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Код_сотрудника();
            Загрузка_времени();
            
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Код_сотрудника();
            Загрузка_времени();
        }
    }
}
