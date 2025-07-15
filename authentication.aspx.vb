Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class authentication
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        Dim connString As String = WebConfigurationManager.ConnectionStrings("iaddatabase").ConnectionString
        Dim query As String = "SELECT Role FROM USER4 WHERE Username=@Username AND Password=@Password"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", password)

                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    If reader.HasRows Then
                        ddlRoles.Items.Clear()
                        While reader.Read()
                            ddlRoles.Items.Add(reader("Role").ToString())
                        End While
                        ddlRoles.Visible = True
                        btnSelectRole.Visible = True
                        Session("Username") = username
                        Session("Password") = password
                        lblError.Text = "Select your role to continue."
                    Else
                        lblError.Text = "Invalid username or password."
                    End If

                Catch ex As Exception
                    lblError.Text = "Error: " & ex.Message
                End Try
            End Using
        End Using
    End Sub

    Protected Sub btnSelectRole_Click(sender As Object, e As EventArgs) Handles btnSelectRole.Click
        Dim selectedRole As String = ddlRoles.SelectedValue
        Dim username As String = Session("Username").ToString()
        Dim password As String = Session("Password").ToString()

        Dim connString As String = WebConfigurationManager.ConnectionStrings("iaddatabase").ConnectionString
        Dim query As String = "SELECT UserID FROM USER4 WHERE Username=@Username AND Password=@Password AND Role=@Role"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", password)
                cmd.Parameters.AddWithValue("@Role", selectedRole)

                Try
                    conn.Open()
                    Dim userID = cmd.ExecuteScalar()

                    If userID IsNot Nothing Then
                        Session("UserID") = userID.ToString()
                        Session("Role") = selectedRole.ToLower()

                        Select Case selectedRole.ToLower()
                            Case "admin"
                                Response.Redirect("Admin.aspx")
                            Case "student"
                                Response.Redirect("home.aspx")
                            Case "tutor"
                                Response.Redirect("updateattendance.aspx")
                            Case Else
                                lblError.Text = "Unknown role selected."
                        End Select
                    Else
                        lblError.Text = "User with selected role not found."
                    End If

                Catch ex As Exception
                    lblError.Text = "Error: " & ex.Message
                End Try
            End Using
        End Using
    End Sub
End Class
