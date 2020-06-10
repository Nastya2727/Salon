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
            Command.CommandText = "SELECT        Сотрудники.Фамилия, Сотрудники.Имя, Специальности.Название_специальности, График.Дата, График.Комментарий FROM График INNER JOIN    Сотрудники ON График.Табельный_номер_сотрудника = Сотрудники.Табельный_номер_сотрудника INNER JOIN Специальности ON Сотрудники.Код_специальности = Специальности.Код_специальности";
            Command.Connection = Connection;
            SqlDataAdapter s = new SqlDataAdapter(Command);
            DataTable dt = new DataTable();
            s.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
