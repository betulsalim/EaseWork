namespace EaseWork
{
    partial class MyAims
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyAims));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.RchTxtAimDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnOnHold = new System.Windows.Forms.Button();
            this.BtnFinished = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.BtnGetBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 259);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 471);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(418, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "My Aims";
            // 
            // RchTxtAimDescription
            // 
            this.RchTxtAimDescription.Location = new System.Drawing.Point(12, 139);
            this.RchTxtAimDescription.Name = "RchTxtAimDescription";
            this.RchTxtAimDescription.Size = new System.Drawing.Size(488, 114);
            this.RchTxtAimDescription.TabIndex = 3;
            this.RchTxtAimDescription.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Aim Description:";
            // 
            // BtnOnHold
            // 
            this.BtnOnHold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BtnOnHold.Location = new System.Drawing.Point(811, 196);
            this.BtnOnHold.Name = "BtnOnHold";
            this.BtnOnHold.Size = new System.Drawing.Size(201, 44);
            this.BtnOnHold.TabIndex = 6;
            this.BtnOnHold.Text = "On Hold";
            this.BtnOnHold.UseVisualStyleBackColor = false;
            this.BtnOnHold.Click += new System.EventHandler(this.BtnOnHold_Click);
            this.BtnOnHold.MouseEnter += new System.EventHandler(this.BtnOnHold_MouseEnter);
            this.BtnOnHold.MouseLeave += new System.EventHandler(this.BtnOnHold_MouseLeave);
            // 
            // BtnFinished
            // 
            this.BtnFinished.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BtnFinished.Location = new System.Drawing.Point(569, 196);
            this.BtnFinished.Name = "BtnFinished";
            this.BtnFinished.Size = new System.Drawing.Size(201, 44);
            this.BtnFinished.TabIndex = 7;
            this.BtnFinished.Text = "Finished";
            this.BtnFinished.UseVisualStyleBackColor = false;
            this.BtnFinished.Click += new System.EventHandler(this.BtnFinished_Click);
            this.BtnFinished.MouseEnter += new System.EventHandler(this.BtnFinished_MouseEnter);
            this.BtnFinished.MouseLeave += new System.EventHandler(this.BtnFinished_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(563, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mail:";
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.LblEmail.Location = new System.Drawing.Point(631, 139);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(73, 31);
            this.LblEmail.TabIndex = 9;
            this.LblEmail.Text = "label4";
            // 
            // BtnGetBack
            // 
            this.BtnGetBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BtnGetBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGetBack.Location = new System.Drawing.Point(5, 5);
            this.BtnGetBack.Name = "BtnGetBack";
            this.BtnGetBack.Size = new System.Drawing.Size(75, 27);
            this.BtnGetBack.TabIndex = 10;
            this.BtnGetBack.Text = "Get Back";
            this.BtnGetBack.UseVisualStyleBackColor = false;
            this.BtnGetBack.Click += new System.EventHandler(this.BtnGetBack_Click);
            this.BtnGetBack.MouseEnter += new System.EventHandler(this.BtnGetBack_MouseEnter);
            this.BtnGetBack.MouseLeave += new System.EventHandler(this.BtnGetBack_MouseLeave);
            // 
            // MyAims
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1032, 742);
            this.Controls.Add(this.BtnGetBack);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnFinished);
            this.Controls.Add(this.BtnOnHold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RchTxtAimDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "MyAims";
            this.Text = "My Aims";
            this.Load += new System.EventHandler(this.MyAims_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RchTxtAimDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnOnHold;
        private System.Windows.Forms.Button BtnFinished;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Button BtnGetBack;
    }
}