Imports System.Data.SqlClient
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class LoginForm
    Dim classKonek As New publicKoneksi
    Dim forms As New keyPress
    Dim conn As MySqlConnection = classKonek.retKon
    Dim dr As MySqlDataReader
    Dim cmd As MySqlCommand


    Private Sub txPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Try
                classKonek.cekKon()
                'MsgBox(My.Settings.strConn)
                cmd = New MySqlCommand("select * from tb_user where lower(_username)='" & txUsername.Text.ToLower & "'", conn)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    If txPassword.Text.Equals(dr(1).ToString) And dr(5).ToString = "Active" Then
                        MainForm.txStatus.Text = "User : " & txUsername.Text
                        MainForm.txSession.Text = dr(4).ToString
                        MainForm.txUsername.Text = dr(0).ToString
                        Me.Close()
                        mainMenu.MdiParent = MainForm
                        mainMenu.Dock = DockStyle.Fill
                        mainMenu.Show()
                    ElseIf txPassword.Text.Equals(dr(1).ToString) And dr(5).ToString = "Inactive" Then
                        MsgBox("Account Suspended")
                    Else
                        MsgBox("Wrong Password")
                    End If
                Else
                    MsgBox("Username not Found")
                End If
            Catch ex As Exception
                MsgBox("Server Configuration Error !")
                forms.callForm("setting", "", "", vbNull).Show()
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        forms.callForm("setting", "", "", vbNull).Show()
    End Sub
End Class