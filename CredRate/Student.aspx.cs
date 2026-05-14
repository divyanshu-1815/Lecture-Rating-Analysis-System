using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CreditRatingSystem
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadStudentDetails();
                LoadSubjects();
            }
        }
        void LoadStudentDetails()
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                string query = @"SELECT Username, CPI, Attendance
                         FROM Users
                         WHERE UserId=@uid";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uid", Session["UserId"]);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblStudentName.Text = "Welcome, " + dr["Username"].ToString();

                    lblCPI.Text = dr["CPI"] == DBNull.Value
                        ? "Not Available"
                        : dr["CPI"].ToString();

                    lblAttendance.Text = dr["Attendance"] == DBNull.Value
                        ? "Not Available"
                        : dr["Attendance"].ToString() + "%";
                }

                con.Close();
            }
        }

        void LoadSubjects()
        {
            using (SqlConnection con = new SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Subjects", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlSubjects.DataSource = dt;
                ddlSubjects.DataTextField = "SubjectName";
                ddlSubjects.DataValueField = "SubjectId";
                ddlSubjects.DataBind();
            }
        }

        protected void ddlSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT TopicId, TopicName FROM Topics WHERE SubjectId=" + ddlSubjects.SelectedValue, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvTopics.DataSource = dt;
                gvTopics.DataBind();
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int studentId = int.Parse(Session["UserId"].ToString());

            using (SqlConnection con = new SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                con.Open();

                foreach (GridViewRow row in gvTopics.Rows)
                {
                    int topicId = int.Parse(gvTopics.DataKeys[row.RowIndex]?.Value.ToString() ?? "0");

                    TextBox txt = (TextBox)row.FindControl("txtRating");

                    if (txt == null || string.IsNullOrWhiteSpace(txt.Text))
                    {
                        lblMsg.Text = "Please enter all ratings!";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    int rating;

                    // VALIDATION
                    if (!int.TryParse(txt.Text, out rating) || rating <= 0 || rating > 5)
                    {
                        lblMsg.Text = "Rating must be between 1 and 5!";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    // 🔴 CHECK IF ALREADY SUBMITTED
                    SqlCommand checkCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Ratings WHERE StudentId=@s AND TopicId=@t", con);

                    checkCmd.Parameters.AddWithValue("@s", studentId);
                    checkCmd.Parameters.AddWithValue("@t", topicId);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        lblMsg.Text = "You have already submitted ratings for this subject!";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    // ✅ INSERT
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Ratings(StudentId, TopicId, Rating) VALUES(@s,@t,@r)", con);

                    cmd.Parameters.AddWithValue("@s", studentId);
                    cmd.Parameters.AddWithValue("@t", topicId);
                    cmd.Parameters.AddWithValue("@r", rating);

                    cmd.ExecuteNonQuery();
                }
            }

            lblMsg.Text = "Ratings submitted successfully!";
            lblMsg.ForeColor = System.Drawing.Color.Green;
        }
    }
}