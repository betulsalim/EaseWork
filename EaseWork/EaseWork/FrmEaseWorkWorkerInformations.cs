using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EaseWork
{
    public partial class FrmEaseWorkWorkerInformations : Form
    {
        public FrmEaseWorkWorkerInformations()
        {
            InitializeComponent();
        }
        Connections connection = new Connections();
        public string mail,position;
        private void FrmEaseWorkWorkerInformations_Load(object sender, EventArgs e)
        {
            LblPosition.Text = position;
            LblMail.Text = mail;
            label10.Visible = false;
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Tbl_Workers", connection.connect());
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            SqlCommand cmd = new SqlCommand("Select worker_mail,worker_position From Tbl_Workers where worker_mail=@worker_mail", connection.connect());
            cmd.Parameters.AddWithValue("@worker_mail", LblMail.Text);
            
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                LblMail.Text = sqlDataReader["worker_mail"].ToString();
                LblPosition.Text = sqlDataReader["worker_position"].ToString();
            }
            connection.connect().Close();

            if(LblPosition.Text.ToLower() == "intern")
            {
                BtnDeleteWorker.Enabled = false; 
                BtnDeleteWorker.Visible = false;
            }


        }

        
        public void Clear()
        {
            TxtNewWorkerMail.Clear();
            TxtNewWorkerName.Clear();
            TxtNewWorkerPassword.Clear();
            TxtNewWorkerSurname.Clear();
            TxtPosition.Clear();
            MskTxtNewWorkerIdentity.Clear();
            MskTxtNewWorkerPhone.Clear();
            CmbDepartment.Text = "";
            progressBarPassword.Value = 0;  
            progressBarPassword.ForeColor = Color.Gray;
            label10.Visible = false;
        }


        private void BtnAddNewWorker_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNewWorkerName.Text) ||
                string.IsNullOrWhiteSpace(TxtNewWorkerSurname.Text) ||
                string.IsNullOrWhiteSpace(TxtNewWorkerPassword.Text) ||
                string.IsNullOrWhiteSpace(MskTxtNewWorkerIdentity.Text) ||
                string.IsNullOrWhiteSpace(MskTxtNewWorkerPhone.Text) ||
                string.IsNullOrWhiteSpace(CmbDepartment.Text) ||
                string.IsNullOrWhiteSpace(TxtPosition.Text))
            {
                // Eğer herhangi bir alan boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = TxtNewWorkerName.Text.ToLower() + "." + TxtNewWorkerSurname.Text.ToLower() + "@easework.com";

            // Aynı e-posta veya şifre olup olmadığını kontrol et
            SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM Tbl_Workers WHERE worker_mail = @worker_mail OR worker_password = @worker_password", connection.connect());
            checkCommand.Parameters.AddWithValue("@worker_mail", TxtNewWorkerMail.Text);
            checkCommand.Parameters.AddWithValue("@worker_password", TxtNewWorkerPassword.Text);

            int exists = (int)checkCommand.ExecuteScalar();  // Eğer kayıt varsa, sonuç 0'dan büyük olacaktır

            if (exists > 0)
            {
                // Eğer aynı e-posta veya şifre varsa uyarı ver
                MessageBox.Show("Bu e-posta veya şifre zaten kullanılıyor. Lütfen farklı bir e-posta veya şifre giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // İşlemi durdur
            }

            if (TxtPosition.Text.ToLower() == "manager")
            {
                // Pozisyon Manager ise Manager tablosuna ekleme yap
                SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Managers (manager_name, manager_surname, manager_email, manager_department, manager_position) VALUES (@manager_name, @manager_surname, @manager_mail, @manager_department, @manager_position)", connection.connect());
                cmd.Parameters.AddWithValue("@manager_name", TxtNewWorkerName.Text);
                cmd.Parameters.AddWithValue("@manager_surname", TxtNewWorkerSurname.Text);
                cmd.Parameters.AddWithValue("@manager_mail", email);  // Yöneticinin e-posta adresi
                cmd.Parameters.AddWithValue("@manager_department", CmbDepartment.Text);  // Yönetici departmanı
                cmd.Parameters.AddWithValue("@manager_position", TxtPosition.Text);  // Yönetici pozisyonu

                cmd.ExecuteNonQuery();  // Manager tablosuna ekleme

                MessageBox.Show("Yeni Yönetici başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Pozisyon Manager değilse Worker tablosuna ekleme yap
                SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Workers (worker_name, worker_surname, worker_mail, worker_password, worker_identity, worker_phone, worker_department, worker_position) VALUES (@worker_name, @worker_surname, @worker_mail, @worker_password, @worker_identity, @worker_phone, @worker_department, @worker_position)", connection.connect());
                cmd.Parameters.AddWithValue("@worker_name", TxtNewWorkerName.Text);
                cmd.Parameters.AddWithValue("@worker_surname", TxtNewWorkerSurname.Text);
                cmd.Parameters.AddWithValue("@worker_mail", email);
                cmd.Parameters.AddWithValue("@worker_password", TxtNewWorkerPassword.Text);
                cmd.Parameters.AddWithValue("@worker_identity", MskTxtNewWorkerIdentity.Text);
                cmd.Parameters.AddWithValue("@worker_phone", MskTxtNewWorkerPhone.Text);
                cmd.Parameters.AddWithValue("@worker_department", CmbDepartment.Text);
                cmd.Parameters.AddWithValue("@worker_position", TxtPosition.Text);

                cmd.ExecuteNonQuery();  // Worker tablosuna ekleme
            }

            // Departman IT ise, IT tablosuna da ekleme yapılacak
            if (CmbDepartment.Text.ToLower() == "it")
            {
                SqlCommand itCmd = new SqlCommand("INSERT INTO Tbl_ITWorkers (ıtWorkerName, ıtWorkerSurname, ıtWorkerIdentity, ıtWorkerMail,ıtWorkerDepartment,ıtWorkerPosition,ıtWorkerPhone,ıtWorkerPassword) VALUES (@p1, @p2, @p3, @p4,@p5,@p6,@p7,@p8)", connection.connect());
                itCmd.Parameters.AddWithValue("@p1", TxtNewWorkerName.Text);
                itCmd.Parameters.AddWithValue("@p2", TxtNewWorkerSurname.Text);
                itCmd.Parameters.AddWithValue("@p3", MskTxtNewWorkerIdentity.Text);
                itCmd.Parameters.AddWithValue("@p4", email);
                itCmd.Parameters.AddWithValue("@p5",CmbDepartment.Text);
                itCmd.Parameters.AddWithValue("@p6", TxtPosition.Text);
                itCmd.Parameters.AddWithValue("@p7", MskTxtNewWorkerPhone.Text);
                itCmd.Parameters.AddWithValue("@p8", TxtNewWorkerPassword.Text);

                itCmd.ExecuteNonQuery();  // IT tablosuna ekleme
            }

            // DataGridView'e güncel verileri yükle
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Tbl_Workers", connection.connect());
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.connect().Close();  // Bağlantıyı kapat
            Clear();  // Alanları temizle
        }




        private void BtnUpdateWorkerInformation_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Update Tbl_Workers Set worker_name=@worker_name, worker_surname=@worker_surname, worker_mail=@worker_mail, worker_password=@worker_password, worker_phone=@worker_phone,worker_department=@worker_department, worker_position=@worker_position Where worker_identity = @worker_identity", connection.connect());
            sqlCommand.Parameters.AddWithValue("@worker_name", TxtNewWorkerName.Text);
            sqlCommand.Parameters.AddWithValue("@worker_surname", TxtNewWorkerSurname.Text);
            sqlCommand.Parameters.AddWithValue("@worker_mail", TxtNewWorkerMail.Text);
            sqlCommand.Parameters.AddWithValue("@worker_password", TxtNewWorkerPassword.Text);
            sqlCommand.Parameters.AddWithValue("@worker_identity", MskTxtNewWorkerIdentity.Text);
            sqlCommand.Parameters.AddWithValue("@worker_phone", MskTxtNewWorkerPhone.Text);
            sqlCommand.Parameters.AddWithValue("@worker_department", CmbDepartment.Text);
            sqlCommand.Parameters.AddWithValue("@worker_position", TxtPosition.Text);
            sqlCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Tbl_Workers", connection.connect());
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.connect().Close();
            Clear();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Selected = dataGridView1.SelectedCells[0].RowIndex;
            TxtNewWorkerName.Text = dataGridView1.Rows[Selected].Cells[1].Value.ToString();
            TxtNewWorkerSurname.Text = dataGridView1.Rows[Selected].Cells[2].Value.ToString();
            TxtNewWorkerMail.Text = dataGridView1.Rows[Selected].Cells[3].Value.ToString();
            TxtNewWorkerPassword.Text = dataGridView1.Rows[Selected].Cells[4].Value.ToString();
            MskTxtNewWorkerIdentity.Text = dataGridView1.Rows[Selected].Cells[5].Value.ToString();
            MskTxtNewWorkerPhone.Text = dataGridView1.Rows[Selected].Cells[6].Value.ToString();
            CmbDepartment.Text = dataGridView1.Rows[Selected].Cells[7].Value.ToString();
            TxtPosition.Text = dataGridView1.Rows[Selected].Cells[8].Value.ToString();
        }

        private void BtnDeleteWorker_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete  From Tbl_Workers Where worker_identity = @worker_identity", connection.connect());
            sqlCommand.Parameters.AddWithValue("@worker_identity", MskTxtNewWorkerIdentity.Text);
            sqlCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Tbl_Workers", connection.connect());
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.connect().Close();
            Clear();
        }

        private void TxtNewWorkerPassword_TextChanged(object sender, EventArgs e)
        {
            string password = TxtNewWorkerPassword.Text;
            int passwordStrength = GetPasswordStrength(password);

            // ProgressBar'ın değerini şifre gücüne göre ayarla
            progressBarPassword.Maximum = 100;  // Maksimum değeri 100 olarak ayarla
            progressBarPassword.Value = Math.Min(passwordStrength, 100);
            label10.Visible = true;
            // İleriye dönük uyumlu bir renk gösterimi
            if (passwordStrength <= 25)
            {
                label10.BackColor = Color.Red;
                label10.Text = "Weak Password";
            }
            else if (passwordStrength <= 50)
            {
                label10.BackColor = Color.Orange;
                label10.Text = "Medium Password";
            }
            else if (passwordStrength <= 75)
            {
                label10.BackColor = Color.YellowGreen;
                label10.Text = "Good Password";
            }
            else
            {
                label10.BackColor = Color.Green;
                label10.Text = "Strong Password";
            }
            progressBarPassword.Refresh();
        }
        // Şifrenin gücünü hesaplama fonksiyonu
        private int GetPasswordStrength(string password)
        {
            int score = 0;

            // Şifrenin uzunluğu
            if (password.Length >= 8) score++;

            // Büyük harf kontrolü
            if (Regex.IsMatch(password, @"[A-Z]")) score++;

            // Küçük harf kontrolü
            if (Regex.IsMatch(password, @"[a-z]")) score++;

            // Rakam kontrolü
            if (Regex.IsMatch(password, @"[0-9]")) score++;

            // Özel karakter kontrolü
            if (Regex.IsMatch(password, @"[\W]")) score++;

            // Güçlü/orta/zayıf olarak sınıflandırma
            if (score == 1) return 25;   // Zayıf
            if (score == 2) return 50;   // Orta
            if (score == 3) return 75;   // İyi
            return 100;                  // Güçlü
        }

        private void BtnGetBack_Click(object sender, EventArgs e)
        {
            FrmHumanResources frmHumanResources = new FrmHumanResources();
            frmHumanResources.workerEmail = LblMail.Text;
            frmHumanResources.Show();
            this.Hide();
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
        private void BtnAdd_MouseEnter(object sender, EventArgs e)
        {
            BtnAddNewWorker.BackColor = Color.DarkBlue; // Hover rengi
            BtnAddNewWorker.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnAdd_MouseLeave(object sender, EventArgs e)
        {
            BtnAddNewWorker.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnAddNewWorker.ForeColor = Color.White; // Varsayılan yazı rengi
        }
        private void BtnUpdate_MouseEnter(object sender, EventArgs e)
        {
            BtnUpdateWorkerInformation.BackColor = Color.DarkBlue; // Hover rengi
            BtnUpdateWorkerInformation.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnUpdate_MouseLeave(object sender, EventArgs e)
        {
            BtnUpdateWorkerInformation.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnUpdateWorkerInformation.ForeColor = Color.White; // Varsayılan yazı rengi
        }
        private void BtnDelete_MouseEnter(object sender, EventArgs e)
        {
            BtnDeleteWorker.BackColor = Color.DarkBlue; // Hover rengi
            BtnDeleteWorker.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnDelete_MouseLeave(object sender, EventArgs e)
        {
            BtnDeleteWorker.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnDeleteWorker.ForeColor = Color.White; // Varsayılan yazı rengi
        }
    }
}
