namespace Beauty
{
    partial class Form_товары
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.beautyDataSet = new Beauty.BeautyDataSet();
            this.товарыиматериалыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.товары_и_материалыTableAdapter = new Beauty.BeautyDataSetTableAdapters.Товары_и_материалыTableAdapter();
            this.кодпродуктаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ценаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beautyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.товарыиматериалыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.кодпродуктаDataGridViewTextBoxColumn,
            this.наименованиеDataGridViewTextBoxColumn,
            this.количествоDataGridViewTextBoxColumn,
            this.ценаDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.товарыиматериалыBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(25, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 189);
            this.dataGridView1.TabIndex = 0;
            // 
            // beautyDataSet
            // 
            this.beautyDataSet.DataSetName = "BeautyDataSet";
            this.beautyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // товарыиматериалыBindingSource
            // 
            this.товарыиматериалыBindingSource.DataMember = "Товары_и_материалы";
            this.товарыиматериалыBindingSource.DataSource = this.beautyDataSet;
            // 
            // товары_и_материалыTableAdapter
            // 
            this.товары_и_материалыTableAdapter.ClearBeforeFill = true;
            // 
            // кодпродуктаDataGridViewTextBoxColumn
            // 
            this.кодпродуктаDataGridViewTextBoxColumn.DataPropertyName = "Код_продукта";
            this.кодпродуктаDataGridViewTextBoxColumn.HeaderText = "Код_продукта";
            this.кодпродуктаDataGridViewTextBoxColumn.Name = "кодпродуктаDataGridViewTextBoxColumn";
            this.кодпродуктаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // наименованиеDataGridViewTextBoxColumn
            // 
            this.наименованиеDataGridViewTextBoxColumn.DataPropertyName = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.Name = "наименованиеDataGridViewTextBoxColumn";
            // 
            // количествоDataGridViewTextBoxColumn
            // 
            this.количествоDataGridViewTextBoxColumn.DataPropertyName = "Количество";
            this.количествоDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.количествоDataGridViewTextBoxColumn.Name = "количествоDataGridViewTextBoxColumn";
            // 
            // ценаDataGridViewTextBoxColumn
            // 
            this.ценаDataGridViewTextBoxColumn.DataPropertyName = "Цена";
            this.ценаDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.ценаDataGridViewTextBoxColumn.Name = "ценаDataGridViewTextBoxColumn";
            // 
            // Form_товары
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_товары";
            this.Text = "Form_товары";
            this.Load += new System.EventHandler(this.Form_товары_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beautyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.товарыиматериалыBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private BeautyDataSet beautyDataSet;
        private System.Windows.Forms.BindingSource товарыиматериалыBindingSource;
        private BeautyDataSetTableAdapters.Товары_и_материалыTableAdapter товары_и_материалыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодпродуктаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименованиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ценаDataGridViewTextBoxColumn;
    }
}