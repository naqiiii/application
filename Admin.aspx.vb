Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class AdminDashboard
    Inherits System.Web.UI.Page

    Dim connString As String = WebConfigurationManager.ConnectionStrings("iaddatabase").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindStudents()
            BindTutors()
        End If
    End Sub

    Private Sub BindStudents()
        Dim query As String = "SELECT UserID, Username, Role FROM USER4 WHERE Role='student'"
        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                gvStudents.DataSource = cmd.ExecuteReader()
                gvStudents.DataBind()
            End Using
        End Using
    End Sub

    Private Sub BindTutors()
        Dim query As String = "SELECT UserID, Username, Role FROM USER4 WHERE Role='tutor'"
        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                gvTutors.DataSource = cmd.ExecuteReader()
                gvTutors.DataBind()
            End Using
        End Using
    End Sub

    Protected Sub gvStudents_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim userID As Integer = Convert.ToInt32(gvStudents.DataKeys(e.RowIndex).Value)
        DeleteUser(userID)
        lblMessage.Text = "Student deleted successfully."
        BindStudents()
    End Sub

    Protected Sub gvTutors_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim userID As Integer = Convert.ToInt32(gvTutors.DataKeys(e.RowIndex).Value)
        DeleteUser(userID)
        lblMessage.Text = "Tutor deleted successfully."
        BindTutors()
    End Sub

    Private Sub DeleteUser(userID As Integer)
        Dim query As String = "DELETE FROM USER4 WHERE UserID=@UserID"
        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", userID)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
