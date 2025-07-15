Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System

Partial Class MyCourses
    Inherits System.Web.UI.Page

    Private ReadOnly connString As String = ConfigurationManager.ConnectionStrings("iaddatabase").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("student_id") Is Nothing Then
                Response.Redirect("Login.aspx")
            Else
                LoadEnrolledCourses()
            End If
        End If
    End Sub

    Private Sub LoadEnrolledCourses()
        Try
            Dim studentId As Integer = Convert.ToInt32(Session("student_id"))

            Using conn As New SqlConnection(connString)
                Dim query As String = "SELECT c.course_id, c.course_name, c.course_description, ec.Enroll_Date " &
                                      "FROM ENROLLED_COURSES ec " &
                                      "JOIN COURSE9 c ON ec.course_id = c.course_id " &
                                      "WHERE ec.student_id = @StudentID " &
                                      "ORDER BY ec.Enroll_Date DESC"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@StudentID", studentId)

                    conn.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    gvEnrolledCourses.DataSource = dt
                    gvEnrolledCourses.DataBind()
                End Using
            End Using
        Catch ex As Exception
            lblError.Text = "Error loading courses: " & ex.Message
            lblError.Visible = True
        End Try
    End Sub
End Class
