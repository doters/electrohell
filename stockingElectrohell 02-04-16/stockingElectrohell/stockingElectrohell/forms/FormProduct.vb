Public Class FormProduct
    Dim clsg As New gridQueries
    Dim col1, col2 As AutoCompleteStringCollection
    Dim com As New autoComplete
    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem.Click
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormAddProduct Then
                F.BringToFront()
                Return
            End If
        Next
        Dim x As New FormAddProduct
        x.MdiParent = MainForm
        x.Show()
    End Sub
    Private Sub SubProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubProductsToolStripMenuItem.Click
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormAddSUbProduct Then
                F.BringToFront()
                Return
            End If
        Next
        Dim x As New FormAddSUbProduct
        x.MdiParent = MainForm
        x.Show()
    End Sub
    Private Sub txtChanged(sender As Object, e As EventArgs) Handles txKode.TextChanged, txNama.TextChanged, txKategori.TextChanged, cmbstatus.SelectedIndexChanged
        Dim columns As String = "KodeItem as Product_Code, nama as Product_Name, Kategori as Category, " & _
            "hargaPokok as Price, hargaJual as Sell_Price, Color, kodeSize as Size" & _
                                                   ", Status"
        Dim src As String = ""
        Try
            Dim txt = DirectCast(sender, TextBox)
            If txt.Name = "txKode" Then
                src = "lower(kodeItem) like'%" & txt.Text.ToLower() & "%'"
            ElseIf txt.Name = "txNama" Then
                src = "lower(nama) like'%" & txt.Text.ToLower() & "%'"
            ElseIf txt.Name = "txKategori" Then
                src = "lower(kategori) like '%" & txt.Text.ToLower() & "%'"
            End If
        Catch ex As Exception
            Dim txt = DirectCast(sender, ComboBox)
            src = "lower(status)='" & txt.SelectedItem.ToString.ToLower() & "'"
        End Try
        dtgridproduk.DataSource = clsg.loadDataTable(columns, "tb_produk", src)
        dtgridproduk.AutoResizeColumns()
    End Sub

    Private Sub loadCom()
        txKode.AutoCompleteCustomSource = com.retComplete("select kodeItem from tb_produk")
        txNama.AutoCompleteCustomSource = com.retComplete("select nama from tb_produk")
        txKategori.AutoCompleteCustomSource = com.retComplete("select kategori from tb_itemkategori")
    End Sub
    Private Sub FormProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCom()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dtgridproduk.DataSource = clsg.loadAllData("KodeItem as Product_Code, nama as Product_Name," & _
                                                   "Kategori as Category,hargaPokok as Price, hargaJual as Sell_Price, Color," & _
                                                   "kodeSize as Size" & _
                                                   ", Status", "tb_produk ", "kodeItem")
    End Sub

    
    Private Sub dtgridproduk_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgridproduk.CellClick
        dtgridsub.DataSource = clsg.loadDataTable("a.Barcode, c.kodeItem as Product_Code, b.Size", "tb_subproduk a, tb_size b, tb_produk c", "a.kodeItem='" & _
                                                   dtgridproduk.CurrentRow.Cells(0).Value & "' and b.kode='" & _
                                                   dtgridproduk.CurrentRow.Cells(6).Value & "' and a.kodesize=b.value" & _
                                                   " and c.kodeitem=a.kodeitem")
        dtgridsub.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub dtgridproduk_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dtgridproduk.MouseDoubleClick
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormEditProduct Then
                F.BringToFront()
                Return
            End If
        Next
        Dim x As New FormEditProduct
        x.MdiParent = MainForm
        x.txtkode.Text = dtgridproduk.CurrentRow.Cells(0).Value
        If dtgridsub.Rows(0).Cells(0).Value = "" Then
            x.cbaktif.Enabled = False
        Else
            x.cbaktif.Enabled = True
        End If
        x.Show()
    End Sub
End Class