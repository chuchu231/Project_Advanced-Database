namespace CSDLNC
{
    partial class UC_Dentist
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Content = new System.Windows.Forms.Panel();
            this.cSDLNC05DataSet = new CSDLNC.CSDLNC05DataSet();
            this.dENTISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dENTISTTableAdapter = new CSDLNC.CSDLNC05DataSetTableAdapters.DENTISTTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fIRSTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lASTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pHONENUMBERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDDRESSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSERNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTATUSDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cSDLNC05DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dENTISTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(99, 111);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Size = new System.Drawing.Size(1301, 593);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách thông tin";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.fIRSTNAMEDataGridViewTextBoxColumn,
            this.lASTNAMEDataGridViewTextBoxColumn,
            this.pHONENUMBERDataGridViewTextBoxColumn,
            this.dOBDataGridViewTextBoxColumn,
            this.aDDRESSDataGridViewTextBoxColumn,
            this.uSERNAMEDataGridViewTextBoxColumn,
            this.sTATUSDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.dENTISTBindingSource;
            this.dataGridView1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Location = new System.Drawing.Point(9, 30);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1243, 475);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoRoundedCorners = true;
            this.btnAdd.BorderRadius = 27;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1120, 509);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(173, 56);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Thêm";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1531, 70);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(91, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách nha sĩ";
            // 
            // Content
            // 
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(0, 0);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(1531, 740);
            this.Content.TabIndex = 10;
            // 
            // cSDLNC05DataSet
            // 
            this.cSDLNC05DataSet.DataSetName = "CSDLNC05DataSet";
            this.cSDLNC05DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dENTISTBindingSource
            // 
            this.dENTISTBindingSource.DataMember = "DENTIST";
            this.dENTISTBindingSource.DataSource = this.cSDLNC05DataSet;
            // 
            // dENTISTTableAdapter
            // 
            this.dENTISTTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fIRSTNAMEDataGridViewTextBoxColumn
            // 
            this.fIRSTNAMEDataGridViewTextBoxColumn.DataPropertyName = "FIRSTNAME";
            this.fIRSTNAMEDataGridViewTextBoxColumn.HeaderText = "FIRSTNAME";
            this.fIRSTNAMEDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.fIRSTNAMEDataGridViewTextBoxColumn.Name = "fIRSTNAMEDataGridViewTextBoxColumn";
            // 
            // lASTNAMEDataGridViewTextBoxColumn
            // 
            this.lASTNAMEDataGridViewTextBoxColumn.DataPropertyName = "LASTNAME";
            this.lASTNAMEDataGridViewTextBoxColumn.HeaderText = "LASTNAME";
            this.lASTNAMEDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.lASTNAMEDataGridViewTextBoxColumn.Name = "lASTNAMEDataGridViewTextBoxColumn";
            // 
            // pHONENUMBERDataGridViewTextBoxColumn
            // 
            this.pHONENUMBERDataGridViewTextBoxColumn.DataPropertyName = "PHONENUMBER";
            this.pHONENUMBERDataGridViewTextBoxColumn.HeaderText = "PHONENUMBER";
            this.pHONENUMBERDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.pHONENUMBERDataGridViewTextBoxColumn.Name = "pHONENUMBERDataGridViewTextBoxColumn";
            // 
            // dOBDataGridViewTextBoxColumn
            // 
            this.dOBDataGridViewTextBoxColumn.DataPropertyName = "DOB";
            this.dOBDataGridViewTextBoxColumn.HeaderText = "DOB";
            this.dOBDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.dOBDataGridViewTextBoxColumn.Name = "dOBDataGridViewTextBoxColumn";
            // 
            // aDDRESSDataGridViewTextBoxColumn
            // 
            this.aDDRESSDataGridViewTextBoxColumn.DataPropertyName = "ADDRESS";
            this.aDDRESSDataGridViewTextBoxColumn.HeaderText = "ADDRESS";
            this.aDDRESSDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.aDDRESSDataGridViewTextBoxColumn.Name = "aDDRESSDataGridViewTextBoxColumn";
            // 
            // uSERNAMEDataGridViewTextBoxColumn
            // 
            this.uSERNAMEDataGridViewTextBoxColumn.DataPropertyName = "USERNAME";
            this.uSERNAMEDataGridViewTextBoxColumn.HeaderText = "USERNAME";
            this.uSERNAMEDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.uSERNAMEDataGridViewTextBoxColumn.Name = "uSERNAMEDataGridViewTextBoxColumn";
            // 
            // sTATUSDataGridViewCheckBoxColumn
            // 
            this.sTATUSDataGridViewCheckBoxColumn.DataPropertyName = "STATUS";
            this.sTATUSDataGridViewCheckBoxColumn.HeaderText = "STATUS";
            this.sTATUSDataGridViewCheckBoxColumn.MinimumWidth = 10;
            this.sTATUSDataGridViewCheckBoxColumn.Name = "sTATUSDataGridViewCheckBoxColumn";
            // 
            // UC_Dentist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Content);
            this.Name = "UC_Dentist";
            this.Size = new System.Drawing.Size(1531, 740);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cSDLNC05DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dENTISTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIRSTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lASTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pHONENUMBERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDDRESSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSERNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sTATUSDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource dENTISTBindingSource;
        private CSDLNC05DataSet cSDLNC05DataSet;
        private CSDLNC05DataSetTableAdapters.DENTISTTableAdapter dENTISTTableAdapter;
    }
}
