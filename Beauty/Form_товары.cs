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
    public partial class Form_товары : Form
    {
        public Form_товары()
        {
            InitializeComponent();
        }

        private void Form_товары_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautyDataSet.Товары_и_материалы". При необходимости она может быть перемещена или удалена.
            this.товары_и_материалыTableAdapter.Fill(this.beautyDataSet.Товары_и_материалы);

        }
    }
}
