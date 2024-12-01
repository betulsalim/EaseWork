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
    public partial class FrmIT : Form
    {
        public FrmIT()
        {
            InitializeComponent();
        }
        public string workerMail;
        Connections Connections = new Connections();
        private void FrmIT_Load(object sender, EventArgs e)
        {
            string userPosition = GetUserPositionFromDatabase(LblEmail.Text); // Kullanıcının pozisyonunu al

            // Pozisyonu küçük harfe çevirip "helpdesk" veya "operation" içerip içermediğini kontrol edelim
            if (userPosition.ToLower().Contains("helpdesk") || userPosition.ToLower().Contains("operation"))
            {
                BtnStuff.Visible = true;   // Eğer pozisyon uygun ise butonu göster
                BtnStuff.Enabled = true;   // Butonu işlevsel yap
            }
            else
            {
                BtnStuff.Visible = false;  // Eğer pozisyon uygun değilse butonu gizle
                BtnStuff.Enabled = false;  // Butonu işlevsiz yap
            }

            try
            {
                LblEmail.Text = workerMail;

                // Çalışanın bilgilerini alıyoruz
                SqlCommand sqlCommand = new SqlCommand("SELECT worker_name, worker_surname, worker_position, worker_mail FROM Tbl_Workers WHERE worker_mail = @worker_mail", Connections.connect());
                sqlCommand.Parameters.AddWithValue("@worker_mail", LblEmail.Text);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    LblNameSurname.Text = reader[0].ToString() + " " + reader[1].ToString();
                    LblPosition.Text = reader[2].ToString();

                    if (string.IsNullOrEmpty(LblPosition.Text))
                    {
                        LblPosition.Text = "No Position Assigned";  // Pozisyon yoksa "No Position Assigned" olarak ayarla
                    }
                }
                reader.Close();

                // Yöneticiyi alıyoruz
                SqlCommand command = new SqlCommand("SELECT m.manager_name, m.manager_surname FROM Tbl_Workers w INNER JOIN Tbl_Managers m ON w.worker_department = m.manager_department WHERE w.worker_mail = @worker_mail", Connections.connect());
                command.Parameters.AddWithValue("@worker_mail", LblEmail.Text);
                SqlDataReader sqlDataReader = command.ExecuteReader();

                if (sqlDataReader.Read())
                {
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
                // Bağlantıyı kapatıyoruz
                Connections.connect().Close();
            }
        }

        private string GetUserPositionFromDatabase(string mail)
        {
            string position = "";
            mail = workerMail;
           
           

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT worker_position FROM Tbl_Workers WHERE worker_mail = @Email", Connections.connect());
                cmd.Parameters.AddWithValue("@Email", mail);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    position = reader["worker_position"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching position: " + ex.Message);
            }
            finally
            {
                Connections.connect().Close();
            }
           
            return position;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InformationAboutMe informationAboutMe = new InformationAboutMe();
            informationAboutMe.mail = LblEmail.Text;
            informationAboutMe.Show();
            this.Hide();
        }

        private void BtnContactWithOthers_Click(object sender, EventArgs e)
        {
            ContactWithOthers contactWithOthers = new ContactWithOthers();
            contactWithOthers.mail = LblEmail.Text;
            contactWithOthers.Show();
            this.Hide();
        }

        private void BtnMyAim_Click(object sender, EventArgs e)
        {
            MyAims myAims = new MyAims();
            myAims.mail = LblEmail.Text;
            myAims.Show();
            this.Hide();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnStuff_Click(object sender, EventArgs e)
        {
            TechnologyProductControl technologyProductControl = new TechnologyProductControl();
            technologyProductControl.workerEmail = LblEmail.Text;
            technologyProductControl.workerPosition = LblPosition.Text;
            technologyProductControl.Show();
            this.Hide();
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
            BtnMyAim.BackColor = Color.DarkBlue; // Hover rengi
            BtnMyAim.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnMyAims_MouseLeave(object sender, EventArgs e)
        {
            BtnMyAim.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnMyAim.ForeColor = Color.White; // Varsayılan yazı rengi
        }
        private void BtnContact_MouseEnter(object sender, EventArgs e)
        {
            BtnContactWithOthers.BackColor = Color.DarkBlue; // Hover rengi
            BtnContactWithOthers.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnContact_MouseLeave(object sender, EventArgs e)
        {
            BtnContactWithOthers.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnContactWithOthers.ForeColor = Color.White; // Varsayılan yazı rengi
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
        private void BtnTech_MouseEnter(object sender, EventArgs e)
        {
            BtnStuff.BackColor = Color.DarkBlue; // Hover rengi
            BtnStuff.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnTect_MouseLeave(object sender, EventArgs e)
        {
            BtnStuff.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnStuff.ForeColor = Color.White; // Varsayılan yazı rengi
        }

    }
}
