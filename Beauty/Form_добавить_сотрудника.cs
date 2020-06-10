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
    public partial class Form_добавить_сотрудника : Form
    {
        public object k_spec = 0;
        public Form_добавить_сотрудника()
        {
            InitializeComponent();
        }
        public bool Off = false;
        private void Button1_Click(object sender, EventArgs e)
        {
            /*SqlConnection Connection = new SqlConnection(@"data source=LAPTOP-5B5LI774\SQLEXPRESS;initial catalog=Beauty;Integrated Security =true");
            var Command = new SqlCommand();

            Command.CommandText = "select Код_специальности from Сотрудники where Название_специальности = @S";
            SqlParameter q = new SqlParameter("S", this.textBox7.Text);
            Command.Parameters.Add(q);
            try
            {
                Command.Connection = Connection;
                Connection.Open();
                SqlDataReader reade = Command.ExecuteReader();

                while (reade.Read())
                {
                    k_spec = reade.GetValue(0);
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
            }*/
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" )
            { MessageBox.Show("Заполните все поля"); }
            else
            {
                try
                {
                    сотрудникиTableAdapter1.Insert(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToString(this.dateTimePicker1.Value.Date), textBox4.Text, textBox6.Text, Convert.ToInt32(comboBox1.SelectedValue));
                    сотрудникиTableAdapter1.Update(this.beautyDataSet1.Сотрудники);
                    MessageBox.Show("Запись успешно добавлена!");
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

        private void Form_добавить_сотрудника_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautyDataSet1.Специальности". При необходимости она может быть перемещена или удалена.
            this.специальностиTableAdapter.Fill(this.beautyDataSet1.Специальности);

        }
    }
}
