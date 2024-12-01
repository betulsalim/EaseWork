namespace EaseWork
{
    partial class FrmEaseWorkWorkerInformations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEaseWorkWorkerInformations));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblPosition = new System.Windows.Forms.Label();
            this.LblMail = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.progressBarPassword = new System.Windows.Forms.ProgressBar();
            this.CmbDepartment = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtPosition = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnDeleteWorker = new System.Windows.Forms.Button();
            this.BtnUpdateWorkerInformation = new System.Windows.Forms.Button();
            this.BtnAddNewWorker = new System.Windows.Forms.Button();
            this.TxtNewWorkerPassword = new System.Windows.Forms.TextBox();
            this.TxtNewWorkerMail = new System.Windows.Forms.TextBox();
            this.MskTxtNewWorkerPhone = new System.Windows.Forms.MaskedTextBox();
            this.MskTxtNewWorkerIdentity = new System.Windows.Forms.MaskedTextBox();
            this.TxtNewWorkerSurname = new System.Windows.Forms.TextBox();
            this.TxtNewWorkerName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnGetBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 535);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 195);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(349, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Worker Informations";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.progressBarPassword);
            this.groupBox1.Controls.Add(this.CmbDepartment);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TxtPosition);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.BtnDeleteWorker);
            this.groupBox1.Controls.Add(this.BtnUpdateWorkerInformation);
            this.groupBox1.Controls.Add(this.BtnAddNewWorker);
            this.groupBox1.Controls.Add(this.TxtNewWorkerPassword);
            this.groupBox1.Controls.Add(this.TxtNewWorkerMail);
            this.groupBox1.Controls.Add(this.MskTxtNewWorkerPhone);
            this.groupBox1.Controls.Add(this.MskTxtNewWorkerIdentity);
            this.groupBox1.Controls.Add(this.TxtNewWorkerSurname);
            this.groupBox1.Controls.Add(this.TxtNewWorkerName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 467);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Worker";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LblPosition);
            this.groupBox2.Controls.Add(this.LblMail);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(594, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 167);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "My Informations";
            // 
            // LblPosition
            // 
            this.LblPosition.AutoSize = true;
            this.LblPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.LblPosition.Location = new System.Drawing.Point(124, 115);
            this.LblPosition.Name = "LblPosition";
            this.LblPosition.Size = new System.Drawing.Size(88, 31);
            this.LblPosition.TabIndex = 23;
            this.LblPosition.Text = "label12";
            // 
            // LblMail
            // 
            this.LblMail.AutoSize = true;
            this.LblMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.LblMail.Location = new System.Drawing.Point(124, 44);
            this.LblMail.Name = "LblMail";
            this.LblMail.Size = new System.Drawing.Size(88, 31);
            this.LblMail.TabIndex = 1;
            this.LblMail.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 31);
            this.label13.TabIndex = 22;
            this.label13.Text = "Position:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 31);
            this.label11.TabIndex = 0;
            this.label11.Text = "Mail:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(466, 385);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "label10";
            // 
            // progressBarPassword
            // 
            this.progressBarPassword.Location = new System.Drawing.Point(12, 395);
            this.progressBarPassword.Name = "progressBarPassword";
            this.progressBarPassword.Size = new System.Drawing.Size(448, 10);
            this.progressBarPassword.TabIndex = 19;
            // 
            // CmbDepartment
            // 
            this.CmbDepartment.FormattingEnabled = true;
            this.CmbDepartment.Items.AddRange(new object[] {
            "Human Resources",
            "IT"});
            this.CmbDepartment.Location = new System.Drawing.Point(201, 195);
            this.CmbDepartment.Name = "CmbDepartment";
            this.CmbDepartment.Size = new System.Drawing.Size(259, 39);
            this.CmbDepartment.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 31);
            this.label9.TabIndex = 17;
            this.label9.Text = "Department:";
            // 
            // TxtPosition
            // 
            this.TxtPosition.Location = new System.Drawing.Point(201, 250);
            this.TxtPosition.Name = "TxtPosition";
            this.TxtPosition.Size = new System.Drawing.Size(259, 38);
            this.TxtPosition.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 31);
            this.label8.TabIndex = 15;
            this.label8.Text = "Position:";
            // 
            // BtnDeleteWorker
            // 
            this.BtnDeleteWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.BtnDeleteWorker.Location = new System.Drawing.Point(679, 414);
            this.BtnDeleteWorker.Name = "BtnDeleteWorker";
            this.BtnDeleteWorker.Size = new System.Drawing.Size(313, 38);
            this.BtnDeleteWorker.TabIndex = 14;
            this.BtnDeleteWorker.Text = "Delete Worker";
            this.BtnDeleteWorker.UseVisualStyleBackColor = false;
            this.BtnDeleteWorker.Click += new System.EventHandler(this.BtnDeleteWorker_Click);
            this.BtnDeleteWorker.MouseEnter += new System.EventHandler(this.BtnDelete_MouseEnter);
            this.BtnDeleteWorker.MouseLeave += new System.EventHandler(this.BtnDelete_MouseLeave);
            // 
            // BtnUpdateWorkerInformation
            // 
            this.BtnUpdateWorkerInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BtnUpdateWorkerInformation.Location = new System.Drawing.Point(679, 313);
            this.BtnUpdateWorkerInformation.Name = "BtnUpdateWorkerInformation";
            this.BtnUpdateWorkerInformation.Size = new System.Drawing.Size(313, 82);
            this.BtnUpdateWorkerInformation.TabIndex = 13;
            this.BtnUpdateWorkerInformation.Text = "Update And List Worker Informations";
            this.BtnUpdateWorkerInformation.UseVisualStyleBackColor = false;
            this.BtnUpdateWorkerInformation.Click += new System.EventHandler(this.BtnUpdateWorkerInformation_Click);
            this.BtnUpdateWorkerInformation.MouseEnter += new System.EventHandler(this.BtnUpdate_MouseEnter);
            this.BtnUpdateWorkerInformation.MouseLeave += new System.EventHandler(this.BtnUpdate_MouseLeave);
            // 
            // BtnAddNewWorker
            // 
            this.BtnAddNewWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BtnAddNewWorker.Location = new System.Drawing.Point(679, 244);
            this.BtnAddNewWorker.Name = "BtnAddNewWorker";
            this.BtnAddNewWorker.Size = new System.Drawing.Size(313, 42);
            this.BtnAddNewWorker.TabIndex = 12;
            this.BtnAddNewWorker.Text = "Add And List New Worker ";
            this.BtnAddNewWorker.UseVisualStyleBackColor = false;
            this.BtnAddNewWorker.Click += new System.EventHandler(this.BtnAddNewWorker_Click);
            this.BtnAddNewWorker.MouseEnter += new System.EventHandler(this.BtnAdd_MouseEnter);
            this.BtnAddNewWorker.MouseLeave += new System.EventHandler(this.BtnAdd_MouseLeave);
            // 
            // TxtNewWorkerPassword
            // 
            this.TxtNewWorkerPassword.Location = new System.Drawing.Point(201, 347);
            this.TxtNewWorkerPassword.Name = "TxtNewWorkerPassword";
            this.TxtNewWorkerPassword.Size = new System.Drawing.Size(259, 38);
            this.TxtNewWorkerPassword.TabIndex = 11;
            this.TxtNewWorkerPassword.UseSystemPasswordChar = true;
            this.TxtNewWorkerPassword.TextChanged += new System.EventHandler(this.TxtNewWorkerPassword_TextChanged);
            // 
            // TxtNewWorkerMail
            // 
            this.TxtNewWorkerMail.Location = new System.Drawing.Point(201, 300);
            this.TxtNewWorkerMail.Name = "TxtNewWorkerMail";
            this.TxtNewWorkerMail.Size = new System.Drawing.Size(259, 38);
            this.TxtNewWorkerMail.TabIndex = 10;
            // 
            // MskTxtNewWorkerPhone
            // 
            this.MskTxtNewWorkerPhone.Location = new System.Drawing.Point(201, 416);
            this.MskTxtNewWorkerPhone.Mask = "(999) 000-0000";
            this.MskTxtNewWorkerPhone.Name = "MskTxtNewWorkerPhone";
            this.MskTxtNewWorkerPhone.Size = new System.Drawing.Size(259, 38);
            this.MskTxtNewWorkerPhone.TabIndex = 9;
            // 
            // MskTxtNewWorkerIdentity
            // 
            this.MskTxtNewWorkerIdentity.Location = new System.Drawing.Point(201, 139);
            this.MskTxtNewWorkerIdentity.Mask = "00000000000";
            this.MskTxtNewWorkerIdentity.Name = "MskTxtNewWorkerIdentity";
            this.MskTxtNewWorkerIdentity.Size = new System.Drawing.Size(259, 38);
            this.MskTxtNewWorkerIdentity.TabIndex = 8;
            this.MskTxtNewWorkerIdentity.ValidatingType = typeof(int);
            // 
            // TxtNewWorkerSurname
            // 
            this.TxtNewWorkerSurname.Location = new System.Drawing.Point(201, 84);
            this.TxtNewWorkerSurname.Name = "TxtNewWorkerSurname";
            this.TxtNewWorkerSurname.Size = new System.Drawing.Size(259, 38);
            this.TxtNewWorkerSurname.TabIndex = 7;
            // 
            // TxtNewWorkerName
            // 
            this.TxtNewWorkerName.Location = new System.Drawing.Point(201, 33);
            this.TxtNewWorkerName.Name = "TxtNewWorkerName";
            this.TxtNewWorkerName.Size = new System.Drawing.Size(259, 38);
            this.TxtNewWorkerName.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 31);
            this.label7.TabIndex = 5;
            this.label7.Text = "Phone:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 31);
            this.label6.TabIndex = 4;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 31);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mail:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 31);
            this.label4.TabIndex = 2;
            this.label4.Text = "Identity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "Surname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // BtnGetBack
            // 
            this.BtnGetBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BtnGetBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGetBack.Location = new System.Drawing.Point(12, 12);
            this.BtnGetBack.Name = "BtnGetBack";
            this.BtnGetBack.Size = new System.Drawing.Size(75, 28);
            this.BtnGetBack.TabIndex = 3;
            this.BtnGetBack.Text = "Get Back";
            this.BtnGetBack.UseVisualStyleBackColor = false;
            this.BtnGetBack.Click += new System.EventHandler(this.BtnGetBack_Click);
            this.BtnGetBack.MouseEnter += new System.EventHandler(this.BtnGetBack_MouseEnter);
            this.BtnGetBack.MouseLeave += new System.EventHandler(this.BtnGetBack_MouseLeave);
            // 
            // FrmEaseWorkWorkerInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1032, 742);
            this.Controls.Add(this.BtnGetBack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FrmEaseWorkWorkerInformations";
            this.Text = "Worker Informations";
            this.Load += new System.EventHandler(this.FrmEaseWorkWorkerInformations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNewWorkerPassword;
        private System.Windows.Forms.TextBox TxtNewWorkerMail;
        private System.Windows.Forms.MaskedTextBox MskTxtNewWorkerPhone;
        private System.Windows.Forms.MaskedTextBox MskTxtNewWorkerIdentity;
        private System.Windows.Forms.TextBox TxtNewWorkerSurname;
        private System.Windows.Forms.TextBox TxtNewWorkerName;
        private System.Windows.Forms.Button BtnDeleteWorker;
        private System.Windows.Forms.Button BtnUpdateWorkerInformation;
        private System.Windows.Forms.Button BtnAddNewWorker;
        private System.Windows.Forms.TextBox TxtPosition;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar progressBarPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnGetBack;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblMail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblPosition;
        private System.Windows.Forms.Label label13;
    }
}