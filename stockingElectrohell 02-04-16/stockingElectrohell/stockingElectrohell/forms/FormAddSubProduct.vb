Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FormAddSUbProduct
    Dim clasg As New gridQueries
    Dim clasq As New publicQuery
    Dim dr As MySqlDataReader
    Dim a As MySqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormColors_Category Then
                F.BringToFront()
                Return
            End If
        Next
        Dim x As New FormColors_Category
        x.MdiParent = MainForm
        x.Show()
        FormColors_Category.Label3.Text = "Color"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormGridSearch Then
                F.BringToFront()
                Return
            End If
        Next
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
                dr = clasq.retDatareader("select count(warehouse) from tb_warehouse")
                If dr.Read() Then
                    For xxa As Integer = 1 To Integer.Parse(dr(0).ToString())
                        clasq.insertQuery("insert into tb_stokgudangdetail values ('" & xxa & "','" & dtgridsub.Rows(asd3).Cells(0).Value & _
                                  "','" & txtkode.Text & "','" & asd3 + 1 & "','0') on duplicate key update barcode='" _
                                  & dtgridsub.Rows(asd3).Cells(0).Value & "'")
                    Next
                End If
                clasq.updateQuery("update tb_produk set status ='Active' where kodeitem = '" & txtkode.Text & "'")
            Next
            MsgBox("Saved")
        End If
        For Each x As Control In GroupBox1.Controls
            If TypeOf x Is TextBox Then
                x.Text = ""
            End If
        Next
        dtgridsub.DataSource = Nothing
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

    Private Sub FormAddSUbProduct_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim kosong As Boolean = False

        For Each x As Control In GroupBox1.Controls
            If TypeOf x Is TextBox Then
                If x.Text <> "" Then
                    kosong = True
                End If
            End If
        Next
        If kosong Then
            Dim dr As DialogResult = MessageBox.Show("Data not saved, close anyway?", "INFO", MessageBoxButtons.OKCancel)
            If dr = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
                Return
            End If
        End If
    End Sub
End Class