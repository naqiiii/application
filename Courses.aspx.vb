Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.UI.WebControls
Imports System

Partial Class Courses
    Inherits System.Web.UI.Page

    Private ReadOnly connString As String = ConfigurationManager.ConnectionStrings("iaddatabase").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadAvailableCourses()
        End If
    End Sub

    Private Sub LoadAvailableCourses()
        Try
            Using conn As New SqlConnection(connString)
                Dim query As String = "SELECT course_id, course_name, course_description FROM COURSE9 ORDER BY course_name"
                Using cmd As New SqlCommand(query, conn)
                    conn.Open()
                    gvCourseDetails.DataSource = cmd.ExecuteReader()
                    gvCourseDetails.DataBind()
                    gvCourseDetails.Visible = True
                End Using
            End Using
        Catch ex As Exception
            lblError.Text = "Error loading courses: " & ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Try
            Dim searchTerm As String = txtSearch.Text.Trim()

            Using conn As New SqlConnection(connString)
                Dim query As String = "SELECT course_id,course_name,course_description FROM COURSE9 " &
                                      "WHERE course_name LIKE @SearchTerm OR course_description LIKE @SearchTerm " &
                                      "ORDER BY course_name"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" & searchTerm & "%")
                    conn.Open()

                    Dim reader = cmd.ExecuteReader()
                    gvCourseDetails.DataSource = reader
                    gvCourseDetails.DataBind()
                    gvCourseDetails.Visible = True

                    If Not reader.HasRows Then
                        lblMessage.Text = "No courses found matching your search."
                        lblMessage.Visible = True
                    Else
                        lblMessage.Text = ""
                        lblMessage.Visible = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblError.Text = "Search Error: " & ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Protected Sub gvCourseDetails_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "Enroll" Then
            If Session("student_id") IsNot Nothing Then
                Try
                    Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                    Dim courseId As Integer = Convert.ToInt32(gvCourseDetails.DataKeys(rowIndex).Value)
                    Dim studentId As Integer = Convert.ToInt32(Session("student_id"))

                    Using conn As New SqlConnection(connString)

                        Dim checkQuery As String = "SELECT COUNT(*) FROM ENROLLED_COURSES WHERE student_id = @S_ID AND course_id = @C_ID"
                        Using checkCmd As New SqlCommand(checkQuery, conn)
                            checkCmd.Parameters.AddWithValue("@S_ID", studentId)
                            checkCmd.Parameters.AddWithValue("@C_ID", courseId)
                            conn.Open()
                            Dim existingCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                            If existingCount > 0 Then
                                lblMessage.Text = "You are already enrolled in this course."
                                lblMessage.Visible = True
                                Return
                            End If
                        End Using


                        Dim insertQuery As String = "INSERT INTO ENROLLED_COURSES (student_id,course_id, Enroll_Date) VALUES (@S_ID, @C_ID, GETDATE())"
                        Using cmd As New SqlCommand(insertQuery, conn)
                            cmd.Parameters.AddWithValue("@S_ID", studentId)
                            cmd.Parameters.AddWithValue("@C_ID", courseId)
                            cmd.ExecuteNonQuery()
                            lblMessage.Text = "Successfully enrolled in course!"
                            lblMessage.Visible = True
                        End Using
                    End Using
                Catch ex As Exception
                    lblError.Text = "Error enrolling in course: " & ex.Message
                    lblError.Visible = True
                End Try
            Else
                lblError.Text = "Please log in to enroll in a course."
                lblError.Visible = True
            End If
        End If
    End Sub
End Class
