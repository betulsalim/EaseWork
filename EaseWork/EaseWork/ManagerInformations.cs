using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EaseWork
{
    public partial class ManagerInformations : Form
    {
        public ManagerInformations()
        {
            InitializeComponent();
        }
        public string workerMail;
        Connections Connections = new Connections();
        private void ManagerInformations_Load(object sender, EventArgs e)
        {
            LblMail.Text = workerMail;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Tbl_Managers",Connections.connect());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            SqlCommand sqlCommand = new SqlCommand("Select worker_mail from Tbl_Workers where worker_mail = @worker_mail", Connections.connect());
            sqlCommand.Parameters.AddWithValue("@worker_mail", LblMail.Text);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                LblMail.Text = reader["worker_mail"].ToString();
            }
            Connections.connect().Close();
        }

        private void BtnGetBack_Click(object sender, EventArgs e)
        {
            FrmHumanResources frmHumanResources = new FrmHumanResources();
            frmHumanResources.workerEmail = LblMail.Text;
            frmHumanResources.Show();
            this.Close();
        }

        private void BtnGetBack_MouseEnter(object sender, EventArgs e)
        {
            BtnGetBack.BackColor = Color.DarkBlue; // Hover rengi
            BtnGetBack.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnGetBack_MouseLeave(object sender, EventArgs e)
        {
            BtnGetBack.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnGetBack.ForeColor = Color.White; // Varsayılan yazı rengi
        }
    }
}
