Imports System.Windows.Forms

Public Class MainForm
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim reg As New registr
        Dim clask As New publicKoneksi
        Dim x As Integer
        Dim y As Integer
        x = Me.Width - 181
        y = Me.Height - 20
        ProgressBar1.Location = New Point(x, y)


            If txStatus.Text = "User : -" Then
                LoginForm.MdiParent = Me
                LoginForm.Show()
            End If

    End Sub


End Class
