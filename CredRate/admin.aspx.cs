using System;
using System.Data;
using System.Data.SqlClient;

namespace CreditRatingSystem
{
    public partial class Admin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RatingDb;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadAdminData();
        }

        void LoadAdminData()
        {
            string query = @"
WITH TopicRatings AS
(
    SELECT
        S.SubjectId,
        S.SubjectName,
        T.TopicId,
        T.TopicName,

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
                ), 0
            )
        AS DECIMAL(5,2)) AS WeightedRating

    FROM Subjects S
    JOIN Topics T ON S.SubjectId = T.SubjectId
    LEFT JOIN Ratings R ON T.TopicId = R.TopicId
    LEFT JOIN Users U ON R.StudentId = U.UserId AND U.Role='Student'
    GROUP BY
        S.SubjectId, S.SubjectName,
        T.TopicId, T.TopicName
)

SELECT
    SubjectId,
    SubjectName,
    COUNT(TopicId) AS TotalTopics,
    SUM(CASE WHEN WeightedRating < 2 THEN 1 ELSE 0 END) AS RescheduledTopics
FROM TopicRatings
GROUP BY SubjectId, SubjectName;
";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Button visibility logic
            dt.Columns.Add("CanChange", typeof(bool));

            foreach (DataRow row in dt.Rows)
            {
                int total = Convert.ToInt32(row["TotalTopics"]);
                int bad = Convert.ToInt32(row["RescheduledTopics"]);

                row["CanChange"] = (total == bad && total > 0);
            }

            gvAdmin.DataSource = dt;
            gvAdmin.DataBind();
        }


        protected void gvAdmin_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChangeTeacher")
            {
                int subjectId = Convert.ToInt32(e.CommandArgument);

                // For demo: remove teacher
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Subjects SET TeacherId = NULL WHERE SubjectId=@sid", con);

                cmd.Parameters.AddWithValue("@sid", subjectId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                LoadAdminData();
            }
        }
    }
}
