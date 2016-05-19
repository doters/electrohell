Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FormAddSUbProduct
    Dim clasg As New gridQueries
    Dim clasq As New publicQuery
    Dim a As MySqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim x As New FormColors_Category
        x.MdiParent = MainForm
        x.Show()
        FormColors_Category.Label3.Text = "Color"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x As New FormGridSearch
        x.MdiParent = MainForm
        x.getSource("produk")
        x.Show()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Button3.Focus()
        Dim gagal As Boolean = False

        For asd As Integer = 0 To dtgridsub.Rows.Count - 1
            a = clasq.retDatareader("select * from tb_subproduk where barcode='" & _
                                    dtgridsub.Rows(asd).Cells(0).Value & "'")
            If a.Read() Or dtgridsub.Rows(asd).Cells(0).Value = "" Then
                gagal = True
                dtgridsub.Rows(asd).Cells(0).Value = ""
            Else
                For asd2 As Integer = 0 To dtgridsub.Rows.Count - 1
                    If dtgridsub.Rows(asd).Cells(0).Value = dtgridsub.Rows(asd2).Cells(0).Value And dtgridsub.Rows(asd2).Cells(0).Value <> "" And asd <> asd2 Then
                        gagal = True
                        dtgridsub.Rows(asd2).Cells(0).Value = ""
                    End If
                Next
            End If
        Next
        If gagal = True Then
            MsgBox("Barcode Used or Empty")
            Return
        Else
            For asd3 As Integer = 0 To dtgridsub.Rows.Count - 1
                clasq.updateQuery("update tb_subProduk set barcode ='" & dtgridsub.Rows(asd3).Cells(0).Value & _
                                "' where kodeitem='" & txtkode.Text & "' and kodesize='" & (asd3 + 1).ToString & "'")
                clasq.insertQuery("insert into tb_stokgudangdetail values ('" & dtgridsub.Rows(asd3).Cells(0).Value & _
                                  "','" & txtkode.Text & "','" & asd3 + 1 & "','0') on duplicate key update barcode='" _
                                  & dtgridsub.Rows(asd3).Cells(0).Value & "'")
            Next
            MsgBox("Saved")
        End If
    End Sub

    Private Sub txtkode_Leave(sender As Object, e As EventArgs) Handles txtkode.Leave
        a = clasq.retDatareader("select Kategori, kodesize as Kode, hargaJual from tb_produk where kodeitem='" & txtkode.Text & "'")
        If a.Read Then
            txtkategori.Text = a(0).ToString()
            txtSize.Text = a(1).ToString()
            txthrgpokok.Text = a(2).ToString()
        End If
        dtgridsub.DataSource = clasg.loadDataTable("a.Barcode, b.Size", "tb_subproduk a, tb_size b", "a.kodeItem='" & _
                                                   txtkode.Text & "' and b.kode='" & txtSize.Text & "' and a.kodesize=b.value")
    End Sub

    Private Sub dtgridsub_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dtgridsub.CellLeave
        
    End Sub
End Class