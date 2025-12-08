<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CredRate.About" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>About Lecture Rating Analysis System</title>

    <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />

    <style>
        body {
            background: #eef4f7;
            font-family: 'Segoe UI', sans-serif;
        }

        .header-section {
            background: linear-gradient(135deg, #004e92, #000428);
            padding: 50px 0;
            color: white;
            text-align: center;
        }

        .header-title {
            font-size: 45px;
            font-weight: 700;
        }

        .header-subtitle {
            font-size: 18px;
            opacity: 0.8;
        }

        .about-card {
            background: white;
            border-radius: 12px;
            padding: 30px;
            margin-top: -40px;
            box-shadow: 0 0 18px rgba(0,0,0,0.1);
        }

        .team-img {
            width: 140px;
            height: 140px;
            border-radius: 50%;
            object-fit: cover;
            border: 4px solid #0d6efd;
        }

        .section-title {
            margin-top: 40px;
            font-size: 26px;
            font-weight: 600;
            color: #003366;
        }

        .footer {
            background: #0d1b2a;
            padding: 18px;
            text-align: center;
            color: #fff;
            margin-top: 50px;
        }

        .developer-box {
            background: #f0f7ff;
            border-left: 5px solid #0d6efd;
            padding: 20px;
            margin-top: 30px;
            border-radius: 8px;
        }
    </style>

</head>
<body>

    <form id="form1" runat="server">

        <!-- HEADER SECTION -->
        <div class="header-section">
            <h1 class="header-title">About Lecture Rating Analysis System</h1>
           <!-- <p class="header-subtitle">Weightage Based Rating System</p>-->
        </div>

        <div class="container">

            <!-- MAIN ABOUT CARD -->
            <div class="about-card">

                <h3 class="text-primary" style="font-weight:600;">What is Lecture Rating Analysis System?</h3>
                <p style="font-size:18px; margin-top:15px;">
                    Lecture Rating Analysis System is a smart weightage-based evaluation and feedback system that helps institutions
                    measure student opinions with fairness.  
                    Using weightage and topic-based ratings, it ensures more accurate results.
                </p>

                <h3 class="section-title">Why We Built Lecture Rating Analysis System?</h3>
                <p style="font-size:18px;">
                    Many rating systems fail to include factors like attendance, participation and subject/topic-based
                    feedback. CredRate solves this problem by:
                    <ul style="font-size:17px; margin-left:20px;">
                        <li>Collecting ratings for each topic</li>
                        <li>Weighting feedback using attendance credits</li>
                        <li>Providing teachers with transparent results</li>
                        <li>Reducing bias and increasing accuracy</li>
                    </ul>
                </p>

                <h3 class="section-title">Our Vision</h3>
                <p style="font-size:18px;">
                    To create a smart academic environment where student feedback becomes more meaningful,
                    systematic, and impactful.
                </p>

                <!-- TEAM -->
                <h3 class="section-title">Meet The Team</h3>

                <div class="developer-box">
                    <h4 style="font-weight:600; color:#003366;">Developed By:</h4>

                    <ul style="font-size:18px; margin-top:10px; line-height:30px;">
                        <li>Divyanshu Pandey</li>
                        <li>Deepa Kushwaha</li>
                        <li>Shiv Pratap Singh</li>
                        <li>Neha Sharma</li>
                        <li>Naveen Yadav</li>
                    </ul>
                </div>

            </div>
        </div>

        <div class="footer">
            © 2025 Lecture Rating Analysis System | Designed for Academic Evaluation
        </div>

    </form>

</body>
</html>
