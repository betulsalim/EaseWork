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
    public partial class FrmEaseWorkAimInformations : Form
    {
        public FrmEaseWorkAimInformations()
        {
            InitializeComponent();
        }
        public string workerMail;
        Connections connection = new Connections();
        private void FrmEaseWorkAimInformations_Load(object sender, EventArgs e)
        {
            
            try
            {
                LblEmail.Text = workerMail;
                // Tbl_Aims tablosunu DataGridView'e yükle
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Tbl_Aims", connection.connect());
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                // Kullanıcının mailini al ve LblEmail'e ata
                SqlCommand sqlCommand = new SqlCommand("SELECT worker_mail FROM Tbl_Workers WHERE worker_mail = @worker_mail", connection.connect());
                sqlCommand.Parameters.AddWithValue("@worker_mail", LblEmail.Text);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    LblEmail.Text = sqlDataReader["worker_mail"].ToString();
                }

                sqlDataReader.Close(); // Okuyucuyu kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapat
                connection.connect().Close();
            }

        }
          
        



       

        private void BtnList_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Tbl_Aims where aim_worker_mail = @aim_worker_mail", connection.connect());
            adapter.SelectCommand.Parameters.AddWithValue("@aim_worker_mail", TxtMail.Text);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

           
         
        }

        private void TxtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnGetBack_Click(object sender, EventArgs e)
        {
            FrmHumanResources frmHumanResources = new FrmHumanResources();
            frmHumanResources.workerEmail = LblEmail.Text;
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
        private void BtnList_MouseEnter(object sender, EventArgs e)
        {
            BtnList.BackColor = Color.DarkBlue; // Hover rengi
            BtnList.ForeColor = Color.White; // Yazı rengi
        }

        private void BtnList_MouseLeave(object sender, EventArgs e)
        {
            BtnList.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnList.ForeColor = Color.White; // Varsayılan yazı rengi
        }
    }
}
