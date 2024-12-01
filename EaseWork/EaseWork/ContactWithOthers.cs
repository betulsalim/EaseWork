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

namespace EaseWork
{
    public partial class ContactWithOthers : Form
    {
        public ContactWithOthers()
        {
            InitializeComponent();
        }
        public string mail;
        Connections Connections = new Connections();
        private void ContactWithOthers_Load(object sender, EventArgs e)
        {
            LblMail.Text = mail;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select worker_mail, worker_phone from Tbl_Workers", Connections.connect());
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand cmd = new SqlCommand("Select worker_mail from Tbl_Workers where worker_mail = @worker_mail",Connections.connect());
            cmd.Parameters.AddWithValue("@worker_mail", LblMail.Text);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                LblMail.Text = sqlDataReader["worker_mail"].ToString();
            }
            Connections.connect().Close();
        }

        private void BtnGetBack_Click(object sender, EventArgs e)
        {

            SqlCommand departmentCommand = new SqlCommand("SELECT worker_department FROM Tbl_Workers WHERE worker_mail = @worker_mail", Connections.connect());
            departmentCommand.Parameters.AddWithValue("@worker_mail", LblMail.Text);

            // Departman bilgisini alıyoruz
            var workerDepartment = departmentCommand.ExecuteScalar();


            if (workerDepartment.ToString() == "Human Resources")
            {
                FrmHumanResources frmHumanResources = new FrmHumanResources();
                frmHumanResources.workerEmail = LblMail.Text;
                frmHumanResources.Show();
                this.Hide();
            }
            else if (workerDepartment.ToString() == "IT")
            {
                FrmIT frmIT = new FrmIT();
                frmIT.workerMail = LblMail.Text;
                frmIT.Show();
                this.Hide();
            }

            Connections.connect().Close();

            
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
