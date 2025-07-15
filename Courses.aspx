<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Courses.aspx.vb" Inherits="Courses" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Course Directory - Online Tutoring</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style>
    
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    background-color: #fafafa;
}


header {
    background-color: #34495e;
    color: white;
    padding: 20px;
    text-align: center;
}


nav {
    background-color: #2c3e50;
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


.section-title {
    font-size: 24px;
    margin-top: 20px;
    text-align: center;
}

.message {
    display: block;
    margin: 10px auto;
    width: 80%;
    padding: 10px;
    text-align: center;
    border-radius: 5px;
    font-weight: bold;
}
.error-message {
    background-color: #f8d7da;
    color: #721c24;
    border: 1px solid #f5c6cb;
}
.info-message {
    background-color: #d1ecf1;
    color: #0c5460;
    border: 1px solid #bee5eb;
}

.search-container {
    text-align: center;
    margin: 20px 0;
}
.search-box {
    padding: 8px;
    width: 250px;
    border: 1px solid #ccc;
    border-radius: 4px;
}
.search-button {
    padding: 8px 15px;
    background-color: #2980b9;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}
.search-button:hover {
    background-color: #1f6391;
}

.course-details {
    width: 90%;
    margin: 0 auto 30px auto;
    border-collapse: collapse;
}
.course-details th,
.course-details td {
    border: 1px solid #ddd;
    padding: 10px;
    text-align: left;
}
.course-details th {
    background-color: #f2f2f2;
}
.course-details tr:hover {
    background-color: #f9f9f9;
}
.course-details .Button {
    background-color: #27ae60;
    color: white;
    padding: 6px 12px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}
.course-details .Button:hover {
    background-color: #1e8449;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Online Tutoring Platform</h1>
        </header>
        <nav>
            <a href="Home.aspx">Home</a>
            <a href="Register.aspx">Create Account</a>
            <a href="Login.aspx">Login to Start</a>
            <a href="Tutor.aspx">Available Tutors</a>
            <a href="MyCourses.aspx">My Courses</a>
            <a href="checkattendance.aspx"> check attendance</a>
        </nav>
        <main>
            <h2 class="section-title">Course Directory</h2>
            <asp:Label ID="lblError" runat="server" CssClass="message error-message" Visible="false" />
            <asp:Label ID="lblMessage" runat="server" CssClass="message info-message" Visible="false" />

            <div class="search-container">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="search-box" placeholder="Search courses..." />
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="search-button" OnClick="btnSearch_Click" />
            </div>

            <asp:GridView ID="gvCourseDetails" runat="server" AutoGenerateColumns="False" CssClass="course-details"
                DataKeyNames="course_id" OnRowCommand="gvCourseDetails_RowCommand">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="Course ID" ReadOnly="true" />
                    <asp:BoundField DataField="course_name" HeaderText="Course Name" />
                    <asp:BoundField DataField="course_description" HeaderText="Description" />
                    <asp:ButtonField CommandName="Enroll" Text="Enroll" ButtonType="Button" />
                </Columns>
            </asp:GridView>
        </main>
    </form>
</body>
</html>
