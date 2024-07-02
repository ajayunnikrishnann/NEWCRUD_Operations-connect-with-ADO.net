using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace NEWCRUD_Operations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CIGAB59\SQLEXPRESS07;Initial Catalog=UserManagement;Integrated Security=True;TrustServerCertificate=True");

        public int RegistrationID;
        private void Form1_Load(object sender, EventArgs e)
        {
            GetSignupRecord();
        }

        private void GetSignupRecord()
        {
           
            SqlCommand cmd = new SqlCommand("Select * from SignupForm", con);
            DataTable dt = new DataTable();

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            SignupRecordDataGridView.DataSource = dt;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateOfBirth;
            if (!DateTime.TryParse(txtDateofbirth.Text, out dateOfBirth))
            {
                MessageBox.Show("Invalid Date of Birth format", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isValid()) {
                SqlCommand cmd = new SqlCommand("INSERT INTO SignupForm VALUES (@FirstName, @LastName, @DateOfBirth, @Age, @Gender, @PhoneNumber, @EmailAddress, @Address, @State, @City, @Username, @Password)",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastname.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                cmd.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@State", txtState.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New student is successfully saved in the database","saved",MessageBoxButtons.OK,MessageBoxIcon.Information);

                GetSignupRecord();
                ResetFormControls();
            }
        }

        private bool isValid()
        {
            if (txtFirstname.Text == string.Empty)
            {
                MessageBox.Show("First name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
                return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();

        }

        private void ResetFormControls()
        {
            RegistrationID = 0;
            txtFirstname.Clear();
            txtLastname.Clear();
            txtDateofbirth.Clear();
            txtAge.Clear();
            txtGender.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtState.Clear();
            txtCity.Clear();
            txtUsername.Clear();
            txtPassword.Clear();

            txtFirstname.Focus();
        }

        private void SignupRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RegistrationID = Convert.ToInt32(SignupRecordDataGridView.SelectedRows[0].Cells[0].Value);
            txtFirstname.Text = SignupRecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtLastname.Text = SignupRecordDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtDateofbirth.Text = SignupRecordDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtAge.Text = SignupRecordDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            txtGender.Text = SignupRecordDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            txtPhone.Text = SignupRecordDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            txtEmail.Text = SignupRecordDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            txtAddress.Text = SignupRecordDataGridView.SelectedRows[0].Cells[8].Value.ToString();
            txtState.Text = SignupRecordDataGridView.SelectedRows[0].Cells[9].Value.ToString();
            txtCity.Text = SignupRecordDataGridView.SelectedRows[0].Cells[10].Value.ToString();
            txtUsername.Text = SignupRecordDataGridView.SelectedRows[0].Cells[11].Value.ToString();
            txtPassword.Text = SignupRecordDataGridView.SelectedRows[0].Cells[12].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dateOfBirth;
            if (!DateTime.TryParse(txtDateofbirth.Text, out dateOfBirth))
            {
                MessageBox.Show("Invalid Date of Birth format", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (RegistrationID > 0)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE SignupForm SET FirstName= @FirstName, LastName= @LastName, DateOfBirth= @DateOfBirth, Age= @Age, Gender= @Gender, PhoneNumber= @PhoneNumber, EmailAddress= @EmailAddress, Address= @Address, State= @State, City= @City, Username= @Username, Password= @Password WHERE RegistrationID = @ID", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastname.Text);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                        cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@State", txtState.Text);
                        cmd.Parameters.AddWithValue("@City", txtCity.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@ID", this.RegistrationID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("New data is successfully updated in the database", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GetSignupRecord();
                        ResetFormControls();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to update their data", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dateOfBirth;
            if (!DateTime.TryParse(txtDateofbirth.Text, out dateOfBirth))
            {
                MessageBox.Show("Invalid Date of Birth format", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (RegistrationID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM SignupForm WHERE RegistrationID = @ID", con);
               
                cmd.Parameters.AddWithValue("@ID", this.RegistrationID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data is deleted from the database", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetSignupRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please select a user to update their data", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
