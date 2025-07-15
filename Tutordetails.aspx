<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Tutordetails.aspx.vb" Inherits="Tutors" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tutor Search</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f6f8;
            margin: 0;
            padding: 10px;
        }

        h2, h3, h4 {
            color: #2c3e50;
            border-bottom: 2px solid #3498db;
            padding-bottom: 4px;
            font-size: 18px;
        }

        .panel {
            background-color: #ffffff;
            padding: 15px;
            margin-bottom: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 6px rgba(0, 0, 0, 0.08);
        }

        .label {
            display: block;
            font-weight: 600;
            margin: 4px 0;
            color: #34495e;
            font-size: 13px;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
            font-size: 13px;
        }

        .gridview th, .gridview td {
            border: 1px solid #ccc;
            padding: 6px 10px;
            text-align: left;
        }

        .gridview th {
            background-color: #ecf0f1;
            color: #2c3e50;
        }

        .gridview tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .error {
            color: #e74c3c;
            font-weight: bold;
            margin-top: 10px;
        }

        input[type="text"] {
            padding: 8px;
            width: 100%;
            max-width: 300px;
            font-size: 14px;
            border: 1px solid #aaa;
            border-radius: 6px;
            margin-top: 6px;
        }

      
        .scrollable-grid {
            max-height: 300px;
            overflow-y: auto;
            margin-top: 10px;
        }

        
        @media (max-width: 768px) {
            .label {
                font-size: 12px;
            }

            input[type="text"] {
                width: 100%;
            }

            .panel {
                padding: 10px;
            }

            h2, h3, h4 {
                font-size: 16px;
            }
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="panel">
            <h2>Search Tutor by name given list</h2>
            <h4>search for teacher to see how much a teacher can charge or see tutor details of that specific course</h4>
            <asp:TextBox ID="txtSearchTutor" runat="server" AutoPostBack="True" placeholder="Enter tutor name" />
            <asp:Label ID="lblError" runat="server" CssClass="error" Visible="False" />
        </div>

        <div class="panel">
            <h3>Available Tutors</h3>
            <div class="scrollable-grid">
                <asp:GridView ID="gvTutorList" runat="server" CssClass="gridview" AutoGenerateColumns="True" 
                    EmptyDataText="No tutors found matching your search" />
            </div>
        </div>

        <asp:Panel ID="pnlTutorDetails" runat="server" CssClass="panel" Visible="False">
            <h3>Tutor Details</h3>
            <div class="detail-section">
                <asp:Label ID="lblTutorIDDetail" runat="server" CssClass="label" Visible="false" />
                <asp:Label ID="lblNameDetail" runat="server" CssClass="label" />
                <asp:Label ID="lblEmailDetail" runat="server" CssClass="label" />
                <asp:Label ID="lblCountryDetail" runat="server" CssClass="label" Visible="false" />
                <asp:Label ID="lblCityDetail" runat="server" CssClass="label" Visible="false" />
                <asp:Label ID="lblStateDetail" runat="server" CssClass="label" Visible="false" />
                <asp:Label ID="lblPostalCodeDetail" runat="server" CssClass="label" Visible="false" />
                <asp:Label ID="lblBioDetail" runat="server" CssClass="label" />
                <asp:Label ID="lblRateDetail" runat="server" CssClass="label" />
                <asp:Label ID="lblExperienceDetail" runat="server" CssClass="label" />
            </div>

            <div class="courses-section">
                <asp:Label ID="lblCoursesHeader" runat="server" CssClass="section-header" Text="Courses Taught" />
                <div class="scrollable-grid">
                    <asp:GridView ID="gvCoursesDetail" runat="server" CssClass="gridview" 
                        AutoGenerateColumns="True" ShowHeaderWhenEmpty="true"
                        EmptyDataText="No courses assigned to this tutor">
                        <EmptyDataRowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>

            <div class="languages-section">
                <asp:Label ID="lblLanguagesHeader" runat="server" CssClass="section-header" Text="Languages Known" />
                <div class="scrollable-grid">
                    <asp:GridView ID="gvLanguagesDetail" runat="server" CssClass="gridview" 
                        AutoGenerateColumns="True" ShowHeaderWhenEmpty="true"
                        EmptyDataText="No languages specified for this tutor">
                        <EmptyDataRowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </form>
</body>