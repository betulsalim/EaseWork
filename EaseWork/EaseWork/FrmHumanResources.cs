using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EaseWork
{
    public partial class FrmHumanResources : Form
    {
        public FrmHumanResources()
        {
            InitializeComponent();
        }

        // workerEmail formlar arasında veri aktarımı için public olarak tanımlandı
        public string workerEmail;

        Connections connections = new Connections();  // Veritabanı bağlantısı

        private void FrmHumanResources_Load(object sender, EventArgs e)
        {
            // workerEmail'i form yüklenmeden önce doğru şekilde alıp, LblEmail'e atıyoruz
            LblEmail.Text = workerEmail;

            // worker_email'e göre çalışan bilgilerini veritabanından çekiyoruz
            try
            {
                SqlCommand command = new SqlCommand("SELECT worker_name, worker_surname, worker_position, worker_mail FROM Tbl_Workers WHERE worker_mail = @worker_mail", connections.connect());
                command.Parameters.AddWithValue("@worker_mail", LblEmail.Text);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Çalışanın ismi, soyismi ve pozisyonunu etiketlere ekliyoruz
                    LblNameSurname.Text = reader[0].ToString() + " " + reader[1].ToString();
                    LblPosition.Text = reader[2].ToString();

                    // Eğer pozisyon bilgisi boş ise, pozisyonu boş bırakıyoruz
                    if (string.IsNullOrEmpty(LblPosition.Text))
                    {
                        LblPosition.Text = "No Position Assigned";  // Veya istediğiniz başka bir metin
                    }
                }
                reader.Close();

                // Çalışanın departmanına göre yöneticisini buluyoruz
                SqlCommand sqlCommand = new SqlCommand("SELECT m.manager_name, m.manager_surname FROM Tbl_Workers w INNER JOIN Tbl_Managers m ON w.worker_department = m.manager_department WHERE w.worker_mail = @worker_mail", connections.connect());
                sqlCommand.Parameters.AddWithValue("@worker_mail", LblEmail.Text);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    // Yöneticinin adını ve soyadını etiketlere yazıyoruz
                    LblManager.Text = sqlDataReader[0].ToString() + " " + sqlDataReader[1].ToString();
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Veritabanı bağlantısını kapatıyoruz
                connections.connect().Close();
            }
        }

        // Çalışan bilgileri sayfasına gitmek için buton
        private void BtnWorkerInformations_Click(object sender, EventArgs e)
        {
            FrmEaseWorkWorkerInformations frmEaseWorkWorkerInformations = new FrmEaseWorkWorkerInformations();
            frmEaseWorkWorkerInformations.mail = LblEmail.Text;
            frmEaseWorkWorkerInformations.position = LblPosition.Text;
            frmEaseWorkWorkerInformations.Show();
            this.Hide();  // Bu sayfayı gizliyoruz
        }

        // Amaçlar sayfasına gitmek için buton
        private void BtnAimInformations_Click(object sender, EventArgs e)
        {
            FrmEaseWorkAimInformations frmEaseWorkAimInformations = new FrmEaseWorkAimInformations();
            frmEaseWorkAimInformations.workerMail = LblEmail.Text;
            frmEaseWorkAimInformations.Show();
            this.Hide();  // Bu sayfayı gizliyoruz
        }

        // Kendi bilgileri sayfasına gitmek için buton
        private void button1_Click(object sender, EventArgs e)
        {
            InformationAboutMe informationAboutMe = new InformationAboutMe();
            informationAboutMe.mail = LblEmail.Text;  // mail bilgisini InformationAboutMe formuna geçiriyoruz
            informationAboutMe.Show();
            this.Hide();  // Bu sayfayı gizliyoruz
        }

        // MyAims sayfasına gitmek için buton
        private void button2_Click(object sender, EventArgs e)
        {
            MyAims myAims = new MyAims();
            myAims.mail = LblEmail.Text;  // mail bilgisini MyAims formuna geçiriyoruz
            myAims.Show();
            this.Hide();  // Bu sayfayı gizliyoruz
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ContactWithOthers contactWithOthers = new ContactWithOthers();
            contactWithOthers.mail = LblEmail.Text;
            contactWithOthers.Show();
            this.Hide();
        }

        private void BtnManagerInformations_Click(object sender, EventArgs e)
        {
            ManagerInformations managerInformations = new ManagerInformations();
            managerInformations.workerMail = LblEmail.Text;
            managerInformations.Show();
            this.Hide();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            // Uygulamanın tüm pencerelerini kapatır ve uygulamayı sonlandırır
            Application.Exit();
        }

        private void BtnInformationAboutMe_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkBlue; // Hover rengi
            button1.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnInformationAboutMe_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            button1.ForeColor = Color.White; // Varsayılan yazı rengi
        }
        private void BtnMyAims_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkBlue; // Hover rengi
            button2.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnMyAims_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            button2.ForeColor = Color.White; // Varsayılan yazı rengi
        }
        private void BtnContact_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkBlue; // Hover rengi
            button3.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnContact_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            button3.ForeColor = Color.White; // Varsayılan yazı rengi
        }
        private void BtnWorkerInformations_MouseEnter(object sender, EventArgs e)
        {
            BtnWorkerInformations.BackColor = Color.DarkBlue; // Hover rengi
            BtnWorkerInformations.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnWorkerInformations_MouseLeave(object sender, EventArgs e)
        {
            BtnWorkerInformations.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnWorkerInformations.ForeColor = Color.White; // Varsayılan yazı rengi
        }
        private void BtnManagerInformations_MouseEnter(object sender, EventArgs e)
        {
            BtnManagerInformations.BackColor = Color.DarkBlue; // Hover rengi
            BtnManagerInformations.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnManagerInformations_MouseLeave(object sender, EventArgs e)
        {
            BtnManagerInformations.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnManagerInformations.ForeColor = Color.White; // Varsayılan yazı rengi
        }
        private void BtnAimInformations_MouseEnter(object sender, EventArgs e)
        {
            BtnAimInformations.BackColor = Color.DarkBlue; // Hover rengi
            BtnAimInformations.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnAimInformations_MouseLeave(object sender, EventArgs e)
        {
            BtnAimInformations.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnAimInformations.ForeColor = Color.White; // Varsayılan yazı rengi
        }
        private void BtnLogOut_MouseEnter(object sender, EventArgs e)
        {
            BtnLogOut.BackColor = Color.DarkBlue; // Hover rengi
            BtnLogOut.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnLogOut_MouseLeave(object sender, EventArgs e)
        {
            BtnLogOut.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnLogOut.ForeColor = Color.White; // Varsayılan yazı rengi
        }

    }
}
