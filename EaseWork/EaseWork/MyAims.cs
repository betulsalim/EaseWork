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
    public partial class MyAims : Form
    {
        public MyAims()
        {
            InitializeComponent();
        }

        Connections connections = new Connections();


        

        private void BtnFinished_Click(object sender, EventArgs e)
        {
            LblEmail.Text = mail;

            // Ensure a row is selected
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    // Get the selected row's index and the aim_id (assuming it's in the first column)
                    int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    int aimId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);  // Primary key or unique ID is assumed to be in the first column.

                    // Define the query to update the aim_status column to "finished"
                    string updateQuery = "UPDATE Tbl_Aims SET aim_status = @aimStatus WHERE aim_id = @aimId";

                    // Create a command to execute the update
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connections.connect());
                    updateCommand.Parameters.AddWithValue("@aimStatus", "finished");
                    updateCommand.Parameters.AddWithValue("@aimId", aimId);

                    // Execute the update command
                    updateCommand.ExecuteNonQuery();
                    MessageBox.Show("Aim status updated to 'finished'.");

                    // Now, refresh the DataGridView to show only the logged-in user's aims with updated status
                    DataTable dataTable = new DataTable();
                    string query = "SELECT a.aim_id, a.aim_description, a.aim_status " +
                                   "FROM Tbl_Aims a " +
                                   "JOIN Tbl_Workers w ON a.aim_worker_mail = w.worker_mail " +
                                   "WHERE w.worker_mail = @aim_worker_mail";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connections.connect());
                    adapter.SelectCommand.Parameters.AddWithValue("@aim_worker_mail", LblEmail.Text);
                    adapter.Fill(dataTable);

                    // Bind the refreshed data to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Handle any errors that may occur
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Close the database connection
                    connections.connect().Close();
                }
            }
            else
            {
                // No cell is selected, show an error message
                MessageBox.Show("Please select a row to mark as finished.");
            }

        }

        private void BtnOnHold_Click(object sender, EventArgs e)
        {
            LblEmail.Text = mail;

    // Ensure a row is selected
    if (dataGridView1.SelectedCells.Count > 0)
    {
        try
        {
            // Get the selected row's index and the aim_id (assuming it's in the first column)
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int aimId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);  // Primary key or unique ID is assumed to be in the first column.

            // Define the query to update the aim_status column to "onhold"
            string updateQuery = "UPDATE Tbl_Aims SET aim_status = @aimStatus WHERE aim_id = @aimId";

            // Create a command to execute the update
            SqlCommand updateCommand = new SqlCommand(updateQuery, connections.connect());
            updateCommand.Parameters.AddWithValue("@aimStatus", "onhold");
            updateCommand.Parameters.AddWithValue("@aimId", aimId);

            // Execute the update command
            updateCommand.ExecuteNonQuery();
            MessageBox.Show("Aim status updated to 'on hold'.");

            // Now, refresh the DataGridView to show only the logged-in user's aims
            DataTable dataTable = new DataTable();
            string query = "SELECT a.aim_id, a.aim_description, a.aim_status " +
                           "FROM Tbl_Aims a " +
                           "JOIN Tbl_Workers w ON a.aim_worker_mail = w.worker_mail " +
                           "WHERE w.worker_mail = @aim_worker_mail";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connections.connect());
            adapter.SelectCommand.Parameters.AddWithValue("@aim_worker_mail", LblEmail.Text);
            adapter.Fill(dataTable);

            // Bind the refreshed data to the DataGridView
            dataGridView1.DataSource = dataTable;
        }
        catch (Exception ex)
        {
            // Handle any errors that may occur
            MessageBox.Show("Error: " + ex.Message);
        }
        finally
        {
            // Close the database connection
            connections.connect().Close();
        }
    }
    else
    {
        // No cell is selected, show an error message
        MessageBox.Show("Please select a row to mark as on hold.");
    }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Selected = dataGridView1.SelectedCells[0].RowIndex;
            RchTxtAimDescription.Text = dataGridView1.Rows[Selected].Cells[1].Value.ToString();
            
        }
        public string mail;
        private void MyAims_Load(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("Mail bilgisi alınamadı!"); // mail bilgisi alınmadıysa uyarı ver
                return;
            }
            LblEmail.Text = mail;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT a.aim_id,a.aim_description, aim_status FROM Tbl_Aims a  JOIN Tbl_Workers w ON a.aim_worker_mail = w.worker_mail WHERE w.worker_mail = @aim_worker_mail", connections.connect());
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@aim_worker_mail", LblEmail.Text);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            // DataTable'ı DataGridView'e bağlıyoruz
            dataGridView1.DataSource = dataTable;

        }

        private void BtnGetBack_Click(object sender, EventArgs e)
        {
            SqlCommand departmentCommand = new SqlCommand("SELECT worker_department FROM Tbl_Workers WHERE worker_mail = @worker_mail", connections.connect());
            departmentCommand.Parameters.AddWithValue("@worker_mail", LblEmail.Text);

            // Departman bilgisini alıyoruz
            var workerDepartment = departmentCommand.ExecuteScalar();


            if (workerDepartment.ToString() == "Human Resources")
            {
                FrmHumanResources frmHumanResources = new FrmHumanResources();
                frmHumanResources.workerEmail = LblEmail.Text;
                frmHumanResources.Show();
                this.Hide();
            }
            else if (workerDepartment.ToString() == "IT")
            {
                FrmIT frmIT = new FrmIT();
                frmIT.workerMail = LblEmail.Text;
                frmIT.Show();
                this.Hide();
            }

            connections.connect().Close();
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

        private void BtnOnHold_MouseEnter(object sender, EventArgs e)
        {
            BtnOnHold.BackColor = Color.DarkBlue; // Hover rengi
            BtnOnHold.ForeColor = Color.White; // Yazı rengi
        }
        private void BtnOnHold_MouseLeave(object sender, EventArgs e)
        {
            BtnOnHold.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnOnHold.ForeColor = Color.White; // Varsayılan yazı rengi
        }

        private void BtnFinished_MouseLeave(object sender, EventArgs e)
        {
            BtnFinished.BackColor = Color.RoyalBlue; // Varsayılan rengi geri yükle
            BtnFinished.ForeColor = Color.White; // Varsayılan yazı rengi
        }
        private void BtnFinished_MouseEnter(object sender, EventArgs e)
        {
            BtnFinished.BackColor = Color.DarkBlue; // Hover rengi
            BtnFinished.ForeColor = Color.White; // Yazı rengi
        }
    }
}
