using System;
using System.Data.SqlClient;

namespace Lecture_Rating_Analysis_System
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlStudent.Visible = false;
            }
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedValue == "Student")
                pnlStudent.Visible = true;
            else
                pnlStudent.Visible = false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Password check
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblMsg.Text = "Passwords do not match!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Student validation
            if (ddlRole.SelectedValue == "Student")
            {
                if (txtCPI.Text == "" || txtAttendance.Text == "")
                {
                    lblMsg.Text = "Enter CPI and Attendance!";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }

            string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RatingDb;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // Check username
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE Username=@u", con);
                checkCmd.Parameters.AddWithValue("@u", txtUsername.Text);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    lblMsg.Text = "Username already exists!";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Users (Username,Password,Role,CPI,Attendance) " +
                    "VALUES (@u,@p,@r,@c,@a)", con);

                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
              
                cmd.Parameters.AddWithValue("@r", ddlRole.SelectedValue);

                if (ddlRole.SelectedValue == "Student")
                {
                    cmd.Parameters.AddWithValue("@c", txtCPI.Text);
                    cmd.Parameters.AddWithValue("@a", txtAttendance.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@c", DBNull.Value);
                    cmd.Parameters.AddWithValue("@a", DBNull.Value);
                }

                cmd.ExecuteNonQuery();
                con.Close();

                lblMsg.Text = "Registration Successful!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}
