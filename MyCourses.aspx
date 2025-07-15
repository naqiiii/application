<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MyCourses.aspx.vb" Inherits="MyCourses" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>My Courses</title>
    
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>My Courses</h1>
        </header>
        
        <main>
            <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false" />
            
            
         <asp:GridView ID="gvEnrolledCourses" runat="server" AutoGenerateColumns="False" CssClass="course-details">
    <Columns>
        <asp:BoundField DataField="course_id" HeaderText="Course ID" ReadOnly="true" />
        <asp:BoundField DataField="course_name" HeaderText="Course Name" />
        <asp:BoundField DataField="course_description" HeaderText="Description" />
        <asp:BoundField DataField="Enroll_Date" HeaderText="Enrollment Date" DataFormatString="{0:yyyy-MM-dd}" />
    </Columns>
</asp:GridView>

        </main>
    </form>
</body>
</html>