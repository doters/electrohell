Public Class FormSponsor
    Dim dt As DataTable
    Dim clasq As New gridQueries

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormAddSponsor Then
                F.BringToFront()
                Return
            End If
        Next
        Dim a As New FormAddSponsor
        a.MdiParent = MainForm
        a.Show()
    End Sub

    Private Sub FormSponsor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtView.DataSource = clasq.loadDataTable("nama as Sponsor_Name, Address, Phone", "tb_sponsor", "1")
    End Sub

    Private Sub txFilter_TextChanged(sender As Object, e As EventArgs) Handles txFilter.TextChanged
        dtView.DataSource = clasq.loadDataTable("nama as Sponsor_Name, Address, Phone", "tb_sponsor", "nama like '%" & _
                                 txFilter.Text & "%' or alamat like '%" & txFilter.Text & "%' or tlp like '%" & _
                                 txFilter.Text & "%'")
    End Sub
End Class