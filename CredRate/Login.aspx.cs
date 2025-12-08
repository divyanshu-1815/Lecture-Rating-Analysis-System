using System;
using System.Data.SqlClient;

namespace CreditRatingSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Users WHERE Username=@u AND Password=@p", con);

                cmd.Parameters.AddWithValue("@u", txtUser.Text);
                cmd.Parameters.AddWithValue("@p", txtPass.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Session["UserId"] = dr["UserId"].ToString();
                    Session["Role"] = dr["Role"].ToString();

                    if (dr["Role"].ToString() == "Student")
                        Response.Redirect("Student.aspx");

                    else if (dr["Role"].ToString() == "Teacher")
                        Response.Redirect("Teacher.aspx");
                }
                else
                {
                    lblMsg.Text = "Invalid Username or Password";
                }
            }
        }
    }
}
