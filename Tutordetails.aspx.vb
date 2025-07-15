Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System

Partial Class Tutors
    Inherits System.Web.UI.Page

    Private ReadOnly connString As String = ConfigurationManager.ConnectionStrings("iaddatabase").ConnectionString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadTutorList()
            pnlTutorDetails.Visible = False
        End If
    End Sub

    Private Sub LoadTutorList(Optional searchName As String = "")
        Using conn As New SqlConnection(connString)
            conn.Open()

            Dim query As String = "SELECT tutor_id, tutor_name, bio, hourly_rate, experience FROM TUTORS WHERE tutor_name LIKE @SearchName"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SearchName", "%" & searchName & "%")

                Dim adapter As New SqlDataAdapter(cmd)
                Dim dtTutors As New DataTable()
                adapter.Fill(dtTutors)

                gvTutorList.DataSource = dtTutors
                gvTutorList.DataBind()
            End Using
        End Using
    End Sub

    Protected Sub LoadTutorDetails(tutorId As Integer)
        Using conn As New SqlConnection(connString)
            conn.Open()

            Dim tutorQueryBasic As String = "SELECT tutor_id, tutor_name, email, bio, hourly_rate, experience FROM TUTORS WHERE tutor_id = @TutorID"
            Using tutorCmdBasic As New SqlCommand(tutorQueryBasic, conn)
                tutorCmdBasic.Parameters.AddWithValue("@TutorID", tutorId)
                Using reader = tutorCmdBasic.ExecuteReader()
                    If reader.Read() Then
                        pnlTutorDetails.Visible = True
                        lblError.Visible = False

                        lblTutorIDDetail.Text = reader("tutor_id").ToString()
                        lblNameDetail.Text = "Name: " & reader("tutor_name").ToString()
                        lblEmailDetail.Text = "Email: " & reader("email").ToString()
                        lblBioDetail.Text = "Bio: " & reader("bio").ToString()
                        lblRateDetail.Text = "Hourly Rate: $" & reader("hourly_rate").ToString()
                        lblExperienceDetail.Text = "Experience: " & reader("experience").ToString() & " years"
                    Else
                        ShowNoTutorFound()
                        Return
                    End If
                End Using
            End Using

            Dim courseQuery As String = "SELECT DISTINCT C.course_name AS CourseName, " &
                                        "C.course_description AS CourseDescription " &
                                        "FROM COURSE9 C " &
                                        "INNER JOIN TUTOR_COURSE_LANGUAGE TCL ON C.course_id = TCL.Course_ID " &
                                        "INNER JOIN TUTORS T ON TCL.Tutor_ID = T.tutor_id " &
                                        "WHERE T.tutor_id = @TutorID"

            Using courseCmd As New SqlCommand(courseQuery, conn)
                courseCmd.Parameters.AddWithValue("@TutorID", tutorId)
                Dim courseAdapter As New SqlDataAdapter(courseCmd)
                Dim dtCourses As New DataTable()
                courseAdapter.Fill(dtCourses)
                gvCoursesDetail.DataSource = dtCourses
                gvCoursesDetail.DataBind()
            End Using


            Dim langQuery As String = "SELECT DISTINCT L.language_name AS LanguageName, " &
                                      "L.language_description AS Description " &
                                      "FROM LANGUAGE1 L " &
                                      "INNER JOIN TUTOR_COURSE_LANGUAGE TCL ON L.language_id = TCL.Language_ID " &
                                      "INNER JOIN TUTORS T ON TCL.Tutor_ID = T.tutor_id " &
                                      "WHERE T.tutor_id = @TutorID"

            Using langCmd As New SqlCommand(langQuery, conn)
                langCmd.Parameters.AddWithValue("@TutorID", tutorId)
                Dim langAdapter As New SqlDataAdapter(langCmd)
                Dim dtLangs As New DataTable()
                langAdapter.Fill(dtLangs)
                gvLanguagesDetail.DataSource = dtLangs
                gvLanguagesDetail.DataBind()
            End Using
        End Using
    End Sub

    Private Sub ShowNoTutorFound()
        pnlTutorDetails.Visible = False
        lblError.Text = "No tutor found with that name."
        lblError.Visible = True
        gvTutorList.DataSource = Nothing
        gvTutorList.DataBind()
        gvCoursesDetail.DataSource = Nothing
        gvCoursesDetail.DataBind()
        gvLanguagesDetail.DataSource = Nothing
        gvLanguagesDetail.DataBind()
    End Sub

    Protected Sub txtSearchTutor_TextChanged(sender As Object, e As EventArgs) Handles txtSearchTutor.TextChanged

        LoadTutorList(txtSearchTutor.Text.Trim())
        pnlTutorDetails.Visible = False
    End Sub

    Protected Sub gvTutorList_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvTutorList.RowCommand
        If e.CommandName = "ViewDetails" Then
            Dim tutorId As Integer = Convert.ToInt32(e.CommandArgument)
            LoadTutorDetails(tutorId)
        End If
    End Sub
End Class