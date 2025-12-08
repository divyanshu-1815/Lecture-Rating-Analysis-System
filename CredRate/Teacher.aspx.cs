using System;
using System.Data;
using System.Data.SqlClient;

namespace CreditRatingSystem
{
    public partial class Teacher : System.Web.UI.Page
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
                string query = @"
                    SELECT T.TopicName, AVG(R.Rating) AS AverageRating
                    FROM Topics T
                    LEFT JOIN Ratings R ON T.TopicId = R.TopicId
                    WHERE T.SubjectId = @sid
                    GROUP BY T.TopicName";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@sid", ddlSubjects.SelectedValue);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvRatings.DataSource = dt;
                gvRatings.DataBind();
            }
        }
    }
}
