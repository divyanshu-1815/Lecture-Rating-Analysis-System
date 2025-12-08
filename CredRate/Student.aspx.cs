using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CreditRatingSystem
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadSubjects();
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
                    int rating = int.Parse(((TextBox)row.FindControl("txtRating")).Text);

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Ratings(StudentId, TopicId, Rating) VALUES(@s,@t,@r)", con);

                    cmd.Parameters.AddWithValue("@s", studentId);
                    cmd.Parameters.AddWithValue("@t", topicId);
                    cmd.Parameters.AddWithValue("@r", rating);

                    cmd.ExecuteNonQuery();
                }
            }

            lblMsg.Text = "Ratings submitted successfully!";
        }
    }
}
