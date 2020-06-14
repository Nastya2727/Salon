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
    public partial class Form1 : Form
    {
        Form_клиенты form_Клиенты;
        Form_сотрудники form_Сотрудники;
        Form_услуги form_Услуги;
        Form_товары form_Товары;
        Form_график form_График;
        Form_запись form_Запись;
        Form_журнал form_Журнал;
        Form_зп form_Зп;
        Form_пользователи Form_Пользователи;

        

        public Form1()
        {
            InitializeComponent();
        }

        private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_Клиенты == null || form_Клиенты.IsDisposed)
            {
                form_Клиенты = new Form_клиенты()
                {
                    MdiParent = this
                };
                form_Клиенты.Show();
            }
        }

        private void СотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_Сотрудники == null || form_Сотрудники.IsDisposed)
            {
                form_Сотрудники = new Form_сотрудники()
                {
                    MdiParent = this
                };
                form_Сотрудники.Show();
            }

        }

        private void УслугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_Услуги == null || form_Услуги.IsDisposed)
            {
                form_Услуги = new Form_услуги()
                {
                    MdiParent = this
                };
                form_Услуги.Show();
            }
        }

        private void ТоварыИМатериалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ГрафикРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_График == null || form_График.IsDisposed)
            {
                form_График = new Form_график()
                {
                    MdiParent = this
                };
                form_График.Show();
            }
        }

        private void ЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_Запись == null || form_Запись.IsDisposed)
            {
                form_Запись = new Form_запись()
                {
                    MdiParent = this
                };
                form_Запись.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;
            this.Enabled = false;
            Form_auth f = new Form_auth();
            f.ShowDialog();
            if (Data.Logged == 0)
            {
                try
                {
                    this.Dispose();
                }
                catch
                {

                }
            }
            else if (Data.Logged == 1)
            {
                this.Enabled = true;
                MessageBox.Show("Вы успешно ВОШЛИ!");
            }
        }

        private void ЖурналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_Журнал == null || form_Журнал.IsDisposed)
            {
                form_Журнал = new Form_журнал()
                {
                    MdiParent = this
                };
                form_Журнал.Show();
            }
        }

        private void ЗПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_Зп == null || form_Зп.IsDisposed)
            {
                form_Зп = new Form_зп()
                {
                    MdiParent = this
                };
                form_Зп.Show();
            }
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           /* if (Data.Logged == 1)
                //   button2.Visible = true;
                // else
                //   button2.Visible = false;
                пользователиToolStripMenuItem.Visible = true;
            else
                пользователиToolStripMenuItem.Visible = false;*/
        }

        private void ПользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form_Пользователи == null || Form_Пользователи.IsDisposed)
            {
                Form_Пользователи = new Form_пользователи()
                {
                    MdiParent = this
                };
                Form_Пользователи.Show();
            }
        }
    }
}
