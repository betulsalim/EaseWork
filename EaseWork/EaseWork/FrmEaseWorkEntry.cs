using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EaseWork
{
    public partial class FrmEaseWorkEntry : Form
    {
        Connections connection = new Connections();
        public FrmEaseWorkEntry()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                // İlk SQL komutunu çalıştırıyoruz (E-posta ve şifre kontrolü)
                SqlCommand command = new SqlCommand("SELECT * FROM Tbl_Workers WHERE worker_mail = @worker_mail AND worker_password = @worker_password", connection.connect());
                command.Parameters.AddWithValue("@worker_mail", TxtEmail.Text);
                command.Parameters.AddWithValue("@worker_password", TxtPassword.Text);

                SqlDataReader reader = command.ExecuteReader();

                // Eğer veri varsa (çalışan doğrulandıysa)
                if (reader.Read())
                {
                    // Reader'ı kapatıyoruz çünkü yeni bir komut çalıştıracağız
                    reader.Close();

                    // Şimdi departman bilgisini almak için yeni bir komut oluşturuyoruz
                    SqlCommand departmentCommand = new SqlCommand("SELECT worker_department FROM Tbl_Workers WHERE worker_mail = @worker_mail", connection.connect());
                    departmentCommand.Parameters.AddWithValue("@worker_mail", TxtEmail.Text);

                    // Departman bilgisini alıyoruz
                    var workerDepartment = departmentCommand.ExecuteScalar();


                    if (workerDepartment.ToString() == "Human Resources")
                    {
                        FrmHumanResources frmHumanResources = new FrmHumanResources();
                        frmHumanResources.workerEmail = TxtEmail.Text;
                        frmHumanResources.Show();
                        this.Hide();
                    }
                    else if (workerDepartment.ToString() =="IT")
                    {
                        FrmIT frmIT = new FrmIT();
                        frmIT.workerMail = TxtEmail.Text;
                        frmIT.Show();
                        this.Hide();
                    }

                }
                


            }
            catch (Exception ex)
            {
                // Hata durumunda mesajı yazdıralım
                MessageBox.Show("Hata: " + ex.Message);
            }
            connection.connect().Close();
        }

       

        private void BtnSignIn_MouseEnter(object sender, EventArgs e)
        {
            BtnSignIn.BackColor = Color.DarkBlue; // Hover rengi
            BtnSignIn.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnSignIn_MouseLeave(object sender, EventArgs e)
        {
            BtnSignIn.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnSignIn.ForeColor = Color.White; // Varsayılan yazı rengi
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
