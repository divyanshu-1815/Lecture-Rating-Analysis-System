<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="CreditRatingSystem.Teacher" %>

<!DOCTYPE html>
<html>
<head>
    <title>Teacher Dashboard</title>
</head>
<body style="margin:0; padding:0; font-family:Arial; background:#d7f3ff;">

<form id="form1" runat="server">

    <div style="
        width:80%;
        margin:40px auto;
        background:white;
        padding:25px;
        border-radius:12px;
        box-shadow:0 0 18px rgba(0,0,0,0.15);
    ">

        <h2 style="text-align:center; color:#333;">
            Teacher Dashboard – Topic Ratings
        </h2>

        <label style="font-size:16px; font-weight:bold;">Select Subject:</label><br />

        <asp:DropDownList ID="ddlSubjects" runat="server"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlSubjects_SelectedIndexChanged"
            style="
                width:300px;
                padding:10px;
                margin-top:10px;
                margin-bottom:25px;
                font-size:15px;
                border-radius:6px;
            ">
        </asp:DropDownList>

        <asp:GridView ID="gvRatings" runat="server"
            AutoGenerateColumns="false"
            OnRowDataBound="gvRatings_RowDataBound"
            GridLines="None"
            CellPadding="10"
            style="width:100%; font-size:15px;">

            <Columns>
                <asp:BoundField DataField="TopicName" HeaderText="Topic Name" />
                <asp:BoundField DataField="WeightedRating" HeaderText="Average Rating" DataFormatString="{0:F2}" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>

            <HeaderStyle BackColor="#4A90E2" ForeColor="White" />
            <RowStyle BackColor="#ffffff" />
            <AlternatingRowStyle BackColor="#f2f6fc" />

        </asp:GridView>

    </div>

</form>

</body>
</html>
