<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Online Tutoring Platform - Home</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }
        header {
            background-color: #007bff;
            color: white;
            padding: 20px;
            text-align: center;
        }
        nav {
            background-color: #0056b3;
            padding: 10px;
            text-align: center;
        }
        nav a {
            color: white;
            margin: 0 15px;
            text-decoration: none;
            font-weight: bold;
        }
        nav a:hover {
            text-decoration: underline;
        }
        main {
            padding: 30px;
            text-align: center;
        }
        .course-item {
            background-color: #e9ecef;
            padding: 10px;
            margin-bottom: 8px;
            border-radius: 5px;
            text-align: left;
        }
        .session-item {
            background-color: #f0f8ff;
            padding: 10px;
            margin-bottom: 8px;
            border-radius: 5px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Online Tutoring Platform</h1>
        </header>
        <nav>
            <a href="Register.aspx">create account</a>
            <a href="Login.aspx">Login to start</a>
            <a href="Courses.aspx"> available Courses</a>
            <a href="Tutor.aspx"> available Tutors</a>
              <a href="MyCourses.aspx">my Courses</a>
                <a href="checkattendance.aspx">check attendance</a>    
           
        <a href="Logout.aspx" class="logout-link">Logout</a>
    
            <nav>
    
  

</nav>
        </nav>
        <main>
            <h2>Welcome!</h2>
            <p>Select an option from the menu to begin.</p>

            <div id="studentContent" runat="server" visible="false">
                <h3>Your Enrolled Courses:</h3>
                <div id="studentCourses" runat="server"></div>

                <h3>Your Upcoming Sessions:</h3>
                <div id="studentSessions" runat="server"></div>
            </div> 

            <div id="tutorContent" runat="server" visible="false">
                <h3>Your Teaching Courses:</h3>
                <div id="tutorCourses" runat="server"></div>

                <h3>Your Upcoming Sessions:</h3>
                <div id="tutorSessions" runat="server"></div>
            </div> 
        </main>
    </form>
</body>
</html>
