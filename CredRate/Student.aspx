<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="CreditRatingSystem.Student" %>

<!DOCTYPE html>
<html>
<head>
    <title>Student Rating</title>
</head>
<body style="font-family: Arial; margin:0; padding:0; background:#d7f3ff;">

    <form id="form1" runat="server">

        <div style="
            width: 450px;
            margin: 60px auto;
            background: white;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0 0 18px rgba(0,0,0,0.15);
            text-align: center;
        ">

            <h2 style="color:#333; margin-bottom:20px;">
                Rate Topics
            </h2>

            <!-- SUBJECT DROPDOWN -->
            <asp:DropDownList ID="ddlSubjects" runat="server"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlSubjects_SelectedIndexChanged"
                style="
                    width: 100%;
                    padding: 10px;
                    border: 1px solid #ccc;
                    border-radius: 5px;
                    margin-bottom: 20px;
                    font-size: 15px;
                ">
            </asp:DropDownList>

            <!-- TOPICS GRID -->
            <asp:GridView ID="gvTopics" runat="server" AutoGenerateColumns="false" DataKeyNames="TopicId"
                style="
                    width: 100%;
                    border: 1px solid #ddd;
                    border-collapse: collapse;
                    margin-bottom:20px;
                    font-size: 15px;
                ">

                <Columns>
                    <asp:BoundField DataField="TopicName" HeaderText="Topic" />

                    <asp:TemplateField HeaderText="Rating (1–5)">
                        <ItemTemplate>
                            <asp:TextBox ID="txtRating" runat="server"
                                style="
                                    width: 45px;
                                    padding: 5px;
                                    border: 1px solid #ccc;
                                    border-radius: 4px;
                                    text-align:center;
                                ">
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <HeaderStyle BackColor="Blue" ForeColor="white" Font-Bold="true" />
                <RowStyle BackColor="#fafafa" />
                <AlternatingRowStyle BackColor="#f0f0f0" />
                
               

            </asp:GridView>

            <!-- SUBMIT BUTTON -->
            <asp:Button ID="btnSubmit" runat="server"
                Text="Submit Rating"
                OnClick="btnSubmit_Click"
                style="
                    background:blue;
                    color:white;
                    padding:12px 20px;
                    border:none;
                    width:100%;
                    border-radius:5px;
                    cursor:pointer;
                    font-size:16px;
                    margin-bottom:10px;
                " />

            <!-- MESSAGE LABEL -->
            <asp:Label ID="lblMsg" runat="server"
                ForeColor="blue"
                style="font-size:14px; margin-top:10px; display:block;">
            </asp:Label>

        </div>

    </form>
</body>
</html>
