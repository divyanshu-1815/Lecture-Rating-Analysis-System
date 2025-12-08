<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SplashScreen.aspx.cs" Inherits="CreditRatingSystem.SplashScreen" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>RateWiz - Splash</title>

    <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />

    <style>
        body {
            background: #d7f3ff;
            font-family: 'Segoe UI', sans-serif;
        }

        .left-section {
            padding: 100px 80px;
        }

        .main-title {
            font-size: 55px;
            font-weight: 700;
            color: #003366;
        }

        .sub-title {
            font-size: 35px;
            font-weight: 700;
            color: #00bfa5;
        }

        .desc {
            margin-top: 25px;
            font-size: 18px;
            width: 90%;
            color: #333;
        }

        .btn-custom {
            margin-top: 30px;
            padding: 12px 35px;
            border-radius: 30px;
            font-size: 18px;
            cursor: pointer;
        }

        .btn-about {
            background: transparent;
            border: 2px solid #007bff;
            color: #007bff;
            margin-left: 10px;
        }

        .right-section {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .hero-img {
            width: 80%;
            max-width: 500px;
            border-radius: 8px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="container-fluid">
            <div class="row">

                <!-- LEFT SIDE -->
                <div class="col-md-6 left-section">
                    <h1 class="main-title">Lecture Rating Analysis System</h1>
                    <!--<h6 class="sub-title">(Weightage Based Rating System)</h6>-->

                    <p class="desc">
                        Welcome to Lecture Rating Analysis System, A comprehensive lecture ranking framework based on attendence,CPI, and 
                        regulatory matrics.
                    </p>

                    <!-- Buttons placed INSIDE the form -->
                    <asp:Button ID="btnGetStarted" runat="server" Text="Get Started"
                        CssClass="btn btn-primary btn-custom" OnClick="btnGetStarted_Click" />

                    <asp:Button ID="btnAbout" runat="server" Text="About Us"
                        CssClass="btn btn-about btn-custom" OnClick="btnAbout_Click" />
                </div>

                <!-- RIGHT SIDE -->
                <div class="col-md-6 right-section">
                    <img src="image/credrat.jpg" class="hero-img" alt="Landing Image" />
                </div>

            </div>
        </div>

    </form>
</body>
</html>

