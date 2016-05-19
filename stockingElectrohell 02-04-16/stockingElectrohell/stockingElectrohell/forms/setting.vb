Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Win32
Imports System.IO

Public Class setting
    Dim clask As New publicKoneksi
    Dim regs As New registr
    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click
        Application.Exit()
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        'clask.ConnectionStr = "server=" & txServer.Text & ";Database=" & txDatabase.Text & ";user id=" & txUser.Text & _
        '      ";password=" & txPass.Text & ";"
        Dim xconn As New MySqlConnection("server=" & txServer.Text & ";Database=" & txDatabase.Text & ";user id=" & txUser.Text & _
                ";password=" & txPass.Text & ";")
        Try
            xconn.Open()
            MsgBox("OK")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Try
            'regs.Write("server", txServer.Text)
            'regs.Write("database", txDatabase.Text)
            'regs.Write("username", txUser.Text)
            'regs.Write("password", txPass.Text)
            My.Settings.strConn = "server=" & txServer.Text & ";Database=" & txDatabase.Text & ";user id=" & txUser.Text & _
                ";password=" & txPass.Text & ";"
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        Application.Restart()
    End Sub

    Private Sub setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class