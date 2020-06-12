using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beauty
{
    public partial class Form_auth : Form
    {
        public Form_auth()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlConnection Connection = new SqlConnection(Data.ConnectionString);
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;
            Command.CommandText = "Select * From Пользователи Where Логин = @login";
            SqlParameter p1 = new SqlParameter("login", textBox1.Text);
            Command.Parameters.Add(p1);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                count++;
            }
            reader.Close();
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            if (count == 0)
            {
                MessageBox.Show("Такого пользователя не существует");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            else if (count == 1)
            {
                Command.CommandText = "Select Пароль From Пользователи Where Логин = @login";
                reader = Command.ExecuteReader();
                reader.Read();
                string password = reader.GetString(0);
                string InputedPass = Data.ComputeHash(textBox1.Text, new MD5CryptoServiceProvider());
                if (password == InputedPass && textBox2.Text == "Admin")
                {
                    //Убрать потом или нет, нужно будет по ролям распределять.
                    Data.Logged = 2;
                    this.Dispose();
                }
                else if (password == InputedPass)
                {
                    Data.Logged = 1;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Пароль введён не верно");
                    textBox2.Text = "";
                    textBox2.Focus();
                }
            }

        }

        private void Form_auth_Load(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
