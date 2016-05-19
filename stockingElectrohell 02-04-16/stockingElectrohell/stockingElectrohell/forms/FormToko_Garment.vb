Public Class FormToko_Garment
    Dim tables As String
    Dim clasq As New gridQueries
    Dim x, y, z, xyz As String
    Private Sub Label3_TextChanged(sender As Object, e As EventArgs) Handles Label3.TextChanged
        GroupBox1.Text = Label3.Text & " Listings"
        Me.Text = Label3.Text & " LIST"
        AddToolStripMenuItem.Text = "&Add New " & Label3.Text
    End Sub
    Private Sub cekTabel()
        If Label3.Text = "Store" Then
            x = "tb_stores"
            y = "namaToko as Nama_Toko, Alamat, tlp, coperson as Contact_Person, disc as Konsinyasi, Grade, Status"
            z = "namatoko like '%" & txFilter.Text & "%' or alamat like '%" & txFilter.Text & "%' or tlp like '%" & _
                txFilter.Text & "%' or coperson like'%" & txFilter.Text & "%'"
            xyz = "namatoko"
        ElseIf Label3.Text = "Garment" Then
            x = "tb_garment"
            y = "namaGarmen as Nama_Garment, Alamat, tlp, coperson as Contact_Person, Status"
            z = "namaGarmen like '%" & txFilter.Text & "%' or alamat like '%" & txFilter.Text & "%' or tlp like '%" & _
                txFilter.Text & "%' or coperson like '%" & txFilter.Text & "%'"
            xyz = "namagarmen"
        End If
    End Sub
    Private Sub txFilter_TextChanged(sender As Object, e As EventArgs) Handles txFilter.TextChanged
        cekTabel()
        dtView.DataSource = clasq.loadDataTable(y, x, z)
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        If Label3.Text = "Store" Then
            For Each F As Form In MainForm.MdiChildren
                'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
                If TypeOf F Is FormAddToko Then
                    F.BringToFront()
                    Return
                End If
            Next
            Dim a As New FormAddToko
            a.MdiParent = MainForm
            a.Show()
        Else
            For Each F As Form In MainForm.MdiChildren
                'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
                If TypeOf F Is FormAddGarment Then
                    F.BringToFront()
                    Return
                End If
            Next
            Dim a As New FormAddGarment
            a.MdiParent = MainForm
            a.Show()
        End If
    End Sub

    Public Sub initGrid()
        cekTabel()
        dtView.DataSource = clasq.loadAllData(y, x, xyz)
    End Sub
    Private Sub FormToko_Garment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initGrid()
    End Sub

    Private Sub dtView_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dtView.MouseDoubleClick
        If Label3.Text = "Store" Then
            For Each F As Form In MainForm.MdiChildren
                'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
                If TypeOf F Is FormAddToko Then
                    F.BringToFront()
                    Return
                End If
            Next
            Dim a As New FormAddToko
            a.MdiParent = MainForm
            a.txtnama.Text = dtView.CurrentRow.Cells(0).Value
            a.Show()
        Else
            For Each F As Form In MainForm.MdiChildren
                'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
                If TypeOf F Is FormAddGarment Then
                    F.BringToFront()
                    Return
                End If
            Next
            Dim a As New FormAddGarment
            a.MdiParent = MainForm
            a.txtnama.Text = dtView.CurrentRow.Cells(0).Value
            a.Show()
        End If
    End Sub
End Class