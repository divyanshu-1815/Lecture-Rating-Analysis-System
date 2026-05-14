using System;
using System.Data.SqlClient;

namespace CreditRatingSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            // 🔴 ADMIN LOGIN (Predefined)
            if (username == "admin" && password == "admin123")
            {
                Session["Username"] = "Admin";
                Session["Role"] = "Admin";

                Response.Redirect("Admin.aspx");
                return;
            }

            // 🔵 NORMAL USERS (DB LOGIN)
            using (SqlConnection con = new SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Users WHERE Username=@u AND Password=@p", con);

                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Session["Username"] = dr["Username"].ToString();
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
