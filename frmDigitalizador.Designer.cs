namespace DigitalizadorRG
{
    partial class frmDigitalizador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.btnImportCSV = new System.Windows.Forms.Button();
            this.btnDigitalizar = new System.Windows.Forms.Button();
            this.imgSection = new System.Windows.Forms.PictureBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.imgSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCaminho
            // 
            this.txtCaminho.Location = new System.Drawing.Point(12, 12);
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.ReadOnly = true;
            this.txtCaminho.Size = new System.Drawing.Size(428, 23);
            this.txtCaminho.TabIndex = 0;
            this.txtCaminho.Click += new System.EventHandler(this.txtCaminho_Click);
            // 
            // btnImportCSV
            // 
            this.btnImportCSV.Location = new System.Drawing.Point(536, 11);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(106, 23);
            this.btnImportCSV.TabIndex = 1;
            this.btnImportCSV.Text = "IMPORTAR CSV";
            this.btnImportCSV.UseVisualStyleBackColor = true;
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
            // 
            // btnDigitalizar
            // 
            this.btnDigitalizar.Location = new System.Drawing.Point(446, 12);
            this.btnDigitalizar.Name = "btnDigitalizar";
            this.btnDigitalizar.Size = new System.Drawing.Size(84, 23);
            this.btnDigitalizar.TabIndex = 2;
            this.btnDigitalizar.Text = "DIGITALIZAR";
            this.btnDigitalizar.UseVisualStyleBackColor = true;
            this.btnDigitalizar.Click += new System.EventHandler(this.btnDigitalizar_Click);
            // 
            // imgSection
            // 
            this.imgSection.BackColor = System.Drawing.SystemColors.Window;
            this.imgSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgSection.Location = new System.Drawing.Point(12, 41);
            this.imgSection.Name = "imgSection";
            this.imgSection.Size = new System.Drawing.Size(630, 354);
            this.imgSection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgSection.TabIndex = 3;
            this.imgSection.TabStop = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 404);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.Size = new System.Drawing.Size(630, 172);
            this.dgvData.TabIndex = 13;
            // 
            // frmDigitalizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 591);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.imgSection);
            this.Controls.Add(this.btnDigitalizar);
            this.Controls.Add(this.btnImportCSV);
            this.Controls.Add(this.txtCaminho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDigitalizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digitalizador de RG [Version 3 - DEV]";
            ((System.ComponentModel.ISupportInitialize)(this.imgSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtCaminho;
        private Button btnImportCSV;
        private Button btnDigitalizar;
        private PictureBox imgSection;
        private DataGridView dgvData;
    }
}