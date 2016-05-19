Public Class FormAllUser
    Dim clasg As New gridQueries
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormAddUser Then
                F.BringToFront()
                Return
            End If
        Next
        Dim a As New FormAddUser
        a.MdiParent = MainForm
        a.Show()
    End Sub

    Private Sub dtView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dtView_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dtView.MouseDoubleClick
        For Each F As Form In MainForm.MdiChildren
            If TypeOf F Is FormEditUser Then
                F.BringToFront()
                Return
            End If
        Next
        Dim x As New FormEditUser
        x.MdiParent = MainForm
        x.txUser.Text = dtView.CurrentRow.Cells(0).Value
        x.Show()
    End Sub

    Private Sub FormAllUser_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        dtView.DataSource = clasg.loadDataTable("_username as Username, _password as Password, Nama as Name, Section, Privilege, Status", "tb_user", "1")
    End Sub

End Class