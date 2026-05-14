using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CreditRatingSystem
{
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSubjects();
            }
        }

        void LoadSubjects()
        {
            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SubjectId, SubjectName FROM Subjects", con);
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
                ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                string query = @"
SELECT 
    T.TopicName,T.TopicId,

    CAST(
        SUM(
            (
                (0.4 * (ISNULL(U.Attendance,0) / 100.0)) +
                (0.6 * (ISNULL(U.CPI,0) / 10.0))
            ) * R.Rating
        )
        /
        NULLIF(
            SUM(
                (0.4 * (ISNULL(U.Attendance,0) / 100.0)) +
                (0.6 * (ISNULL(U.CPI,0) / 10.0))
            ),
        0)
    AS DECIMAL(5,2)
    ) AS WeightedRating,

    CASE 
        WHEN 
        CAST(
            SUM(
                (
                    (0.4 * (ISNULL(U.Attendance,0) / 100.0)) +
                    (0.6 * (ISNULL(U.CPI,0) / 10.0))
                ) * R.Rating
            )
            /
            NULLIF(
                SUM(
                    (0.4 * (ISNULL(U.Attendance,0) / 100.0)) +
                    (0.6 * (ISNULL(U.CPI,0) / 10.0))
                ),
            0)
        AS DECIMAL(5,2)
        ) < 2
        THEN 'You have to reschedule this topic'
        ELSE 'Good'
    END AS Status

FROM Topics T
LEFT JOIN Ratings R 
    ON T.TopicId = R.TopicId
LEFT JOIN Users U 
    ON R.StudentId = U.UserId 
    AND U.Role = 'Student'
WHERE 
    T.SubjectId = @sid
GROUP BY T.TopicName,T.TopicId";






                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@sid", ddlSubjects.SelectedValue);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvRatings.DataSource = dt;
                gvRatings.DataBind();
            }
        }

        protected void gvRatings_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = e.Row.Cells[2].Text;

                if (status.Contains("reschedule"))
                {
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[2].Font.Bold = true;
                }
                else if (status.Contains("Good"))
                {
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[2].Font.Bold = true;
                }
            }
        }
        protected void gvRatings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Reschedule")
            {
                string topicName = e.CommandArgument.ToString();

                // Check Session
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                int teacherId = Convert.ToInt32(Session["UserId"]);

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    string query = @"INSERT INTO RescheduledTopics
                            (TopicName, SubjectId, TeacherId)
                            VALUES (@topic, @subject, @teacher)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@topic", topicName);
                    cmd.Parameters.AddWithValue("@subject", ddlSubjects.SelectedValue);
                    cmd.Parameters.AddWithValue("@teacher", teacherId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "msg",
                    "alert('Topic Rescheduled Successfully');",
                    true);
            }
        }
    }
}
