<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs"
    Inherits="Lecture_Rating_Analysis_System.Register" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>User Registration</title>

    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Arial, sans-serif;
            background: linear-gradient(135deg, #e3f2fd, #bbdefb);
            margin: 0;
            padding: 0;
        }

        .container {
            width: 420px;
            margin: 80px auto;
            background: #ffffff;
            padding: 30px 35px;
            border-radius: 10px;
            box-shadow: 0 8px 20px rgba(0,0,0,0.15);
        }

        h2 {
            text-align: center;
            color: #0d47a1;
            margin-bottom: 25px;
        }

        label {
            font-weight: 600;
            color: #0d47a1;
            display: block;
            margin-bottom: 6px;
        }

        .input-box {
            width: 100%;
            padding: 10px 12px;
            border: 1px solid #90caf9;
            border-radius: 5px;
            font-size: 14px;
            margin-bottom: 18px;
        }

        .input-box:focus {
            outline: none;
            border-color: #1e88e5;
            box-shadow: 0 0 5px rgba(30,136,229,0.4);
        }

        .btn-register {
            width: 100%;
            background: #1e88e5;
            color: white;
            padding: 12px;
            border: none;
            border-radius: 6px;
            font-size: 16px;
            font-weight: 600;
            cursor: pointer;
            transition: background 0.3s ease;
        }

        .btn-register:hover {
            background: #1565c0;
        }

        .message {
            text-align: center;
            margin-top: 15px;
            font-weight: 600;
        }

        .student-panel {
            background: #f5faff;
            padding: 15px;
            border-radius: 6px;
            border: 1px solid #bbdefb;
            margin-bottom: 18px;
        }
    </style>
</head>

<body>
<form id="form1" runat="server">

    <div class="container">

        <h2>User Registration</h2>

        <label>Username</label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="input-box" />

        <label>Password</label>
        <asp:TextBox ID="txtPassword" runat="server"
            TextMode="Password" CssClass="input-box" />

        <label>Confirm Password</label>
        <asp:TextBox ID="txtConfirmPassword" runat="server"
            TextMode="Password" CssClass="input-box" />

        <label>Role</label>
        <asp:DropDownList ID="ddlRole" runat="server"
            AutoPostBack="true"
            CssClass="input-box"
            OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
            <asp:ListItem Text="-- Select Role --" />
            <asp:ListItem Text="Student" />
            <asp:ListItem Text="Teacher" />
        </asp:DropDownList>

        <!-- STUDENT ONLY -->
        <asp:Panel ID="pnlStudent" runat="server" CssClass="student-panel">

            <label>CPI</label>
            <asp:TextBox ID="txtCPI" runat="server" CssClass="input-box" />

            <label>Attendance (%)</label>
            <asp:TextBox ID="txtAttendance" runat="server" CssClass="input-box" />

        </asp:Panel>

        <asp:Button ID="btnRegister" runat="server"
            Text="Register"
            CssClass="btn-register"
            OnClick="btnRegister_Click" />

        <asp:Label ID="lblMsg" runat="server" CssClass="message" />

    </div>

</form>
</body>
</html>
