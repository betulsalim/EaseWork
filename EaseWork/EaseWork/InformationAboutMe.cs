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
using System.Data.SqlClient;

namespace EaseWork
{
    public partial class InformationAboutMe : Form
    {
        
        public InformationAboutMe()
        {
            InitializeComponent();
        }
        public string mail,password;
        Connections connections = new Connections();



        private void InformationAboutMe_Load(object sender, EventArgs e)
        {
            LblMail.Text = mail;
            SqlCommand sqlCommand = new SqlCommand(" SELECT  w.worker_name, w.worker_surname, w.worker_mail, w.worker_password,  w.worker_phone, w.worker_position, w.worker_department, w.worker_identity,   m.manager_name, m.manager_email FROM Tbl_Workers w LEFT JOIN Tbl_Managers m ON w.worker_department = m.manager_department WHERE w.worker_mail = @worker_mail", connections.connect());
            sqlCommand.Parameters.AddWithValue("@worker_mail", LblMail.Text);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                // Okunan verileri ilgili alanlara doldurabilirsiniz
                LblName.Text = reader[0].ToString();        // worker_name
                LblSurname.Text = reader[1].ToString();     // worker_surname                
                LblPassword.Text = reader[3].ToString();    // worker_password
                LblPhone.Text = reader[4].ToString();       // worker_phone
                LblPosition.Text = reader[5].ToString();    // worker_position
                LblDepartment.Text = reader[6].ToString();  // worker_department
                LblIdentity.Text = reader[7].ToString();

                LblManagerName.Text = reader[8].ToString(); // manager_name
                LblManagerEmail.Text = reader[9].ToString();
            }
           
            connections.connect().Close();


        }
       public void Refresh()
        {
           
            LblPassword.Text = password;
            LblMail.Text = mail;
            SqlCommand sqlCommand = new SqlCommand(" SELECT  w.worker_name, w.worker_surname, w.worker_mail, w.worker_password,  w.worker_phone, w.worker_position, w.worker_department, w.worker_identity,   m.manager_name, m.manager_email FROM Tbl_Workers w LEFT JOIN Tbl_Managers m ON w.worker_department = m.manager_department WHERE w.worker_mail = @worker_mail", connections.connect());
            sqlCommand.Parameters.AddWithValue("@worker_mail", LblMail.Text);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                // Okunan verileri ilgili alanlara doldurabilirsiniz
                LblName.Text = reader[0].ToString();        // worker_name
                LblSurname.Text = reader[1].ToString();     // worker_surname                
                LblPassword.Text = reader[3].ToString();    // worker_password
                LblPhone.Text = reader[4].ToString();       // worker_phone
                LblPosition.Text = reader[5].ToString();    // worker_position
                LblDepartment.Text = reader[6].ToString();  // worker_department
                LblIdentity.Text = reader[7].ToString();

                LblManagerName.Text = reader[8].ToString(); // manager_name
                LblManagerEmail.Text = reader[9].ToString();
            }

            connections.connect().Close();


        }

        private void BtnGetBack_Click(object sender, EventArgs e)
        {

            SqlCommand departmentCommand = new SqlCommand("SELECT worker_department FROM Tbl_Workers WHERE worker_mail = @worker_mail", connections.connect());
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

            connections.connect().Close();

           
        }

        private void LnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            
            changePassword.Show();
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
        private void LnkChangePassword_MouseEnter(object sender, EventArgs e)
        {
            LnkChangePassword.BackColor = Color.DarkBlue; // Hover rengi
            LnkChangePassword.ForeColor = Color.White; // Yazı rengi
        }

        private void LnkChangePassword_MouseLeave(object sender, EventArgs e)
        {
            LnkChangePassword.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            LnkChangePassword.ForeColor = Color.White; // Varsayılan yazı rengi
        }


    }
}
