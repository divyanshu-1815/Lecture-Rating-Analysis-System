<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="CreditRatingSystem.Teacher" %>

<!DOCTYPE html>
<html>
<head>
    <title>Teacher Dashboard</title>
</head>
<body style="margin:0; padding:0; font-family:Arial; background:#d7f3ff;">

<form id="form1" runat="server">

    <div style="
        width: 80%;
        margin: 40px auto;
        background: white;
        padding: 25px;
        border-radius: 12px;
        box-shadow: 0 0 18px rgba(0,0,0,0.15);
    ">

        <!-- Header -->
        <h2 style="text-align:center; color:#333; margin-bottom:25px;">
            Teacher Dashboard – View Ratings
        </h2>

        <!-- Subject Dropdown -->
        <label style="font-size:16px; font-weight:bold; color:#444;">Select Subject:</label><br/>

        <asp:DropDownList ID="ddlSubjects" runat="server"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlSubjects_SelectedIndexChanged"
            style="
                width: 250px;
                padding: 10px;
                margin-top: 10px;
                margin-bottom: 30px;
                border: 1px solid #ccc;
                border-radius: 6px;
                font-size: 15px;
            ">
        </asp:DropDownList>

        <br /><br />

        <!-- Ratings Grid -->
        <div style="
            margin-top: 10px;
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 10px;
        ">
            <asp:GridView 
                ID="gvRatings" 
                runat="server" 
                AutoGenerateColumns="true"
                HeaderStyle-BackColor="#4A90E2"
                HeaderStyle-ForeColor="White"
                RowStyle-BackColor="#f7f7f7"
                AlternatingRowStyle-BackColor="#e9eef5"
                BorderColor="#ccc"
                CellPadding="6"
                GridLines="None"
                style="width:100%; font-size:15px; border-radius:8px; overflow:hidden;">
            </asp:GridView>
        </div>

    </div>

</form>

</body>
</html>
