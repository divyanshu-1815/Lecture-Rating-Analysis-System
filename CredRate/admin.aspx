<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Admin.aspx.cs"
    Inherits="CreditRatingSystem.Admin" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Admin Panel – CredRate</title>

    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', Arial;
            background: #eef2f7;
        }

        .wrapper {
            width: 90%;
            max-width: 1100px;
            margin: 40px auto;
            background: #ffffff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 6px 15px rgba(0,0,0,0.1);
        }

        h2 {
            text-align: center;
            color: #003366;
            margin-bottom: 25px;
        }

        .subtitle {
            text-align: center;
            color: #666;
            font-size: 14px;
            margin-bottom: 30px;
        }

        .grid {
            width: 100%;
            border-collapse: collapse;
        }

        .grid th {
            background: #003366;
            color: #ffffff;
            padding: 12px;
            text-align: center;
        }

        .grid td {
            padding: 10px;
            text-align: center;
            border-bottom: 1px solid #ddd;
        }

        .grid tr:hover {
            background: #f5f9ff;
        }

        .btn-change {
            padding: 6px 14px;
            background: #dc3545;
            color: #ffffff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 13px;
        }

        .btn-change:hover {
            background: #b52a37;
        }

        .footer {
            text-align: center;
            margin-top: 25px;
            font-size: 12px;
            color: #888;
        }
    </style>
</head>

<body>
<form runat="server">

    <div class="wrapper">

        <h2>Admin – Rescheduled Subjects</h2>
        <div class="subtitle">
            Lecture Rating Analysis System | Admin Control Panel
        </div>

        <asp:GridView ID="gvAdmin" runat="server"
            CssClass="grid"
            AutoGenerateColumns="False"
            OnRowCommand="gvAdmin_RowCommand">

            <Columns>

                <asp:BoundField DataField="SubjectName" HeaderText="Subject" />

                <asp:BoundField DataField="TotalTopics" HeaderText="Total Topics" />

                <asp:BoundField DataField="RescheduledTopics" HeaderText="Rescheduled Topics" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnChangeTeacher"
                            runat="server"
                            Text="Change Teacher"
                            CssClass="btn-change"
                            CommandName="ChangeTeacher"
                            CommandArgument='<%# Eval("SubjectId") %>'
                            Visible='<%# Convert.ToBoolean(Eval("CanChange")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

        <div class="footer">
            ©  Weightage Based Rating System
        </div>

    </div>

</form>
</body>
</html>
