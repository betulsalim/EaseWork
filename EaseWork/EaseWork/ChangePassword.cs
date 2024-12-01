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
    public partial class ChangePassword : Form
    {
        
        public ChangePassword()
        {
            InitializeComponent();
             
        }
        Connections connections = new Connections();
        
        private void BtnChange_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan gelen mail ve mevcut şifre
            string userMail = TxtEmail.Text;
            string currentPassword = TxtCurrentPassword.Text;
            string newPassword = TxtNewPassword.Text;


            if (newPassword == currentPassword)
            {
                MessageBox.Show("Yeni şifre mevcut şifreyle aynı olamaz. Lütfen farklı bir şifre girin.");
                return;
            }

          


            // Kullanıcının mail ve mevcut şifresi doğru mu kontrol ediyoruz
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM Tbl_Workers WHERE worker_mail=@mail AND worker_password=@password", connections.connect());
            sqlCommand.Parameters.AddWithValue("@mail", userMail);
            sqlCommand.Parameters.AddWithValue("@password", currentPassword);

            try
            {
                int count = (int)sqlCommand.ExecuteScalar();  // Kullanıcı var mı diye kontrol ediyoruz

                if (count == 1)
                {
                    // Kullanıcı mevcut mail ve şifre ile bulunduysa, yeni şifreyi güncelle
                    SqlCommand updateCommand = new SqlCommand("UPDATE Tbl_Workers SET worker_password=@newPassword WHERE worker_mail=@mail", connections.connect());
                    updateCommand.Parameters.AddWithValue("@newPassword", newPassword);
                    updateCommand.Parameters.AddWithValue("@mail", userMail);

                    int rowsAffected = updateCommand.ExecuteNonQuery();  // Şifreyi güncelliyoruz

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Şifre başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Şifre güncellenemedi, lütfen tekrar deneyin.");
                    }
                }
                else
                {
                    MessageBox.Show("Mevcut şifreniz veya mail adresiniz hatalı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connections.connect().Close();  // Bağlantı kapatılıyor
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mevcutSifre = ""; // Mevcut şifreyi saklamak için bir değişken
            bool sifreDegisti = false;

            SqlCommand command = new SqlCommand("SELECT worker_password FROM Tbl_Workers WHERE worker_mail = @worker_mail", connections.connect());
            command.Parameters.AddWithValue("@worker_mail", TxtEmail.Text);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                mevcutSifre = reader["worker_password"].ToString(); // Mevcut şifreyi al
            }

            // Reader ve bağlantıyı kapat
            reader.Close();
            command.Dispose();

            // Kullanıcının girdiği yeni şifrenin eski şifreyle aynı olup olmadığını kontrol et
            if (string.IsNullOrEmpty(TxtNewPassword.Text))
            {
                MessageBox.Show("Yeni şifre boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connections.connect().Close();
                return;
            }
            
            else
            {
                sifreDegisti = true;
            }

            // Eğer şifre değiştirildiyse, yeni şifreyi ve emaili InformationAboutMe formuna aktar
            if (sifreDegisti)
            {



                InformationAboutMe informationAboutMe = new InformationAboutMe();
                informationAboutMe.password = TxtNewPassword.Text;
                informationAboutMe.mail = TxtEmail.Text;

                informationAboutMe.Show();
            }

            connections.connect().Close();
            this.Close();

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void BtnGetBack_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkBlue; // Hover rengi
            button1.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnGetBack_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            button1.ForeColor = Color.White; // Varsayılan yazı rengi
        }

        private void BtnChangePassword_MouseEnter(object sender, EventArgs e)
        {
            BtnChange.BackColor = Color.DarkBlue; // Hover rengi
            BtnChange.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnChangePassword_MouseLeave(object sender, EventArgs e)
        {
            BtnChange.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnChange.ForeColor = Color.White; // Varsayılan yazı rengi
        }
    }
}
