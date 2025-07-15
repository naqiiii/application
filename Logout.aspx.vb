Imports System
Imports System.Web
Imports System.Web.Security

Partial Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Session.Clear()
            Session.Abandon()

            FormsAuthentication.SignOut()


            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Cache.SetNoStore()

            Response.AppendHeader("pragma", "no-cache")
            Response.AppendHeader("Cache-Control", "no-store, no-cache, must-revalidate, post-check=0, pre-check=0")

            Dim cookie As New HttpCookie("ASP.NET_SessionId", "")
            cookie.Expires = DateTime.Now.AddYears(-1)
            Response.Cookies.Add(cookie)

        End If
    End Sub
End Class