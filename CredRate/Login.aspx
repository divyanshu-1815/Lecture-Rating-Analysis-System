<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CreditRatingSystem.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
</head>
<body style="margin:0; padding:0; font-family:Arial; background: #d7f3ff; height:100vh;">

    <form id="form1" runat="server">

        <div style="
            width: 350px;
            margin: 80px auto;
            background: white;
            padding: 30px;
            border-radius: 12px;
            box-shadow: 0 0 20px rgba(0,0,0,0.2);
            text-align: center;
        ">

            <h2 style="margin-bottom: 20px; color:#333;">Login</h2>

            <!-- Username -->
            <asp:TextBox ID="txtUser" runat="server" Placeholder="Username"
                style="
                    width: 100%;
                    padding: 12px;
                    margin-bottom: 15px;
                    border: 1px solid #ccc;
                    border-radius: 6px;
                    font-size: 15px;
                ">
            </asp:TextBox>

            <!-- Password -->
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Placeholder="Password"
                style="
                    width: 100%;
                    padding: 12px;
                    margin-bottom: 20px;
                    border: 1px solid #ccc;
                    border-radius: 6px;
                    font-size: 15px;
                ">
            </asp:TextBox>

            <!-- Login Button -->
            <asp:Button ID="btnLogin" runat="server" Text="Login"
                OnClick="btnLogin_Click"
                style="
                    width: 100%;
                    padding: 12px;
                    background: #4A90E2;
                    color: white;
                    border: none;
                    border-radius: 6px;
                    font-size: 16px;
                    cursor: pointer;
                    transition: 0.3s;
                "
                onmouseover="this.style.background='#357ABD'"
                onmouseout="this.style.background='#4A90E2'"
            />

            <!-- Message Label -->
            <asp:Label ID="lblMsg" runat="server"
                ForeColor="Red"
                style="margin-top:15px; display:block; font-size:14px;">
            </asp:Label>
                        <!-- Message Label -->
            <asp:Label ID="Label1" runat="server"
                ForeColor="Red"
                style="margin-top:15px; display:block; font-size:14px;">
            </asp:Label>

            <!-- Register Link -->
            <div style="margin-top:20px; font-size:14px;">
                <span style="color:#666;">New user?</span>
                <a href="Register.aspx"
                   style="
                        color:#4A90E2;
                        text-decoration:none;
                        font-weight:600;
                        margin-left:5px;
                   "
                   onmouseover="this.style.textDecoration='underline'"
                   onmouseout="this.style.textDecoration='none'">
                    Register here
                </a>
            </div><div style="margin-top:20px; font-size:14px;">
    <span style="color:#666;"></span>
    <a href="admin.aspx"
       style="
            color:#4A90E2;
            text-decoration:none;
            font-weight:600;
            margin-left:5px;
       "
       onmouseover="this.style.textDecoration='underline'"
       onmouseout="this.style.textDecoration='none'">
        Status
    </a>


        </div>





    </form>

</body>
</html>
