Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class formTerimaKirimJual
    Dim clasQuery As New publicQuery
    Dim clasg As New setDefaultGrid
    Dim clasc As New autoComplete
    Dim dr As MySqlDataReader
    Dim kategori, disc As String

    'lblNama - nama toko, nama garmen,
    'kode item-nama-color-kodesize-(size1-8)-total qty-price-cons-total price
    Private Sub Label2_TextChanged(sender As Object, e As EventArgs) Handles Label2.TextChanged
        If Label2.Text = "Pengiriman" Then
            lblAuto.Visible = True
            lblAuto.Text = "No. Pengiriman"
            txtresi.Visible = True
            txtresi.Enabled = False
            Me.Text = "Form " & Label2.Text
            lblNama.Text = "Toko"
            TextBox7.Text = "Cons."
            loadAutoKode()
        ElseIf Label2.Text = "Penerimaan" Then
            lblAuto.Visible = True
            lblAuto.Text = "No. Nota"
            txtresi.Visible = True
            Me.Text = "Form " & Label2.Text
            lblNama.Text = "Garment"
        ElseIf Label2.Text = "Penjualan Toko" Then
            Me.Text = "Form " & Label2.Text
            TextBox7.Text = Environment.NewLine & Environment.NewLine & Environment.NewLine & "/r/nCons."
            dGridAll.Columns(14).Visible = True
            TextBox8.Visible = True
            lblNama.Text = "Toko"
        ElseIf Label2.Text = "Penjualan Gudang" Then
            Me.Text = "Form " & Label2.Text
            lblNama.Visible = False
            txnama.Visible = False
            cmbcatjual.Visible = True
            lblCatJual.Visible = True
        ElseIf Label2.Text = "Return Barang" Then
            Me.Text = "Form " & Label2.Text
            lblNama.Text = "Nama "
            cmbstat.Visible = True
            lblStatus.Visible = True
        End If
    End Sub

    Private Sub SimpanjualGudang()
        MsgBox(clasQuery.insertQuery("query"))
    End Sub

    Private Sub SimpanjualToko()

        clasQuery.insertQuery("query")
    End Sub

    Private Sub SimpanPenerimaan()
        clasQuery.insertQuery("insert into tb_penerimaan values('','" & txtresi.Text & "','" & _
                              DateTime.Now.ToMySql & "','" & txnama.Text & "','" & MainForm.txUsername.Text & "','" & txGrandtotal1.Text & "')")
        For a As Integer = 0 To dGridAll.Rows.Count - 1
            For b As Integer = 4 To 11
                clasQuery.updateQuery("update tb_stokgudangdetail set qty=qty+" & dGridAll.Rows(a).Cells(b).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & _
                                      "' and value='" & b - 3 & "'")
            Next
            clasQuery.updateQuery("update tb_stokgudang set qty=qty+" & dGridAll.Rows(a).Cells(12).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & "'")
        Next
        MsgBox("Saved")
    End Sub

    Private Sub SimpanPengiriman()
        clasQuery.insertQuery("insert into tb_pengiriman values('" & txtresi.Text & "','" & txnama.Text & "','" & _
                              DateTime.Now.ToMySql & "','" & MainForm.txUsername.Text & "','" & txtotQty.Text & "','" & txGrandtotal2.Text & "')")
        For a As Integer = 0 To dGridAll.Rows.Count - 1
            For b As Integer = 4 To 11
                clasQuery.updateQuery("update tb_stokgudangdetail set qty=qty-" & dGridAll.Rows(a).Cells(b).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & _
                                      "' and value='" & b - 3 & "'")
            Next
            clasQuery.updateQuery("update tb_stokgudang set qty=qty-" & dGridAll.Rows(a).Cells(12).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & "'")
        Next
        MsgBox("Saved")
    End Sub

    Private Sub updateStok(barcode As String, jumlah As Integer)
        clasQuery.updateQuery("update tb_stokgudangdetail set qty=qty +1 where barcode='" & barcode & "'")
    End Sub
    Private Sub loadValuetoGrid()
        dr = clasQuery.retDatareader(getQuery(Label2.Text))
        If dr.Read Then
            If dGridAll.Rows.Count = 0 Then
                initGrid(dr)
                rowTotalUpdate(dr(4).ToString, "0")
            Else
                For a As Integer = 0 To dGridAll.Rows.Count - 1
                    If dGridAll.Rows(a).Cells(0).Value = dr(0).ToString Then
                        rowTotalUpdate(dr(4).ToString, a)
                        txtbarkode.Clear()
                        Return
                    End If 
                Next
                initGrid(dr)
                rowTotalUpdate(dr(4).ToString, dGridAll.Rows.Count - 1)
            End If
            txtbarkode.Clear()
        End If
    End Sub

    Private Sub initGrid(dr As MySqlDataReader)
        Select Case Label2.Text
            Case "Penerimaan"
                Dim rows As String() = {dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, _
                                            "0", "0", "0", "0", "0", "0", "0", "0", "0", dr(5).ToString, "0", "0"}
                dGridAll.Rows.Add(rows)
            Case "Pengiriman"
                dGridAll.Columns(14).Visible = True
                Dim rows As String() = {dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, _
                                            "0", "0", "0", "0", "0", "0", "0", "0", "0", dr(5).ToString, disc, "0"}
                dGridAll.Rows.Add(rows)

                txGrandtotal1.Visible = False
                txGrandtotal2.Visible = True
        End Select
    End Sub
    Private Function getQuery(input As String) As String
        Dim output As String = ""
        Select Case input
            Case "Penerimaan"
                output = "select a.kodeItem, a.nama,a.color,a.kodeSize,c.value, a.hargaPokok, b.barcode " & _
                                     "from tb_produk a, tb_subproduk b, tb_size c where b.barcode ='" & txtbarkode.Text & "' and " & _
                                     "a.kodeItem=b.kodeitem and a.kodesize=c.kode and b.kodesize=c.value"
            Case "Pengiriman"
                output = "select a.kodeItem, a.nama,a.color,a.kodeSize,c.value, a.hargaJual, b.barcode " & _
                                     "from tb_produk a, tb_subproduk b, tb_size c where b.barcode ='" & txtbarkode.Text & "' and " & _
                                     "a.kodeItem=b.kodeitem and a.kodesize=c.kode and b.kodesize=c.value"
        End Select
        Return output
    End Function

    Private Sub rowTotalUpdate(value As String, row As String)
        Select Case Label2.Text
            Case "Penerimaan"
                Dim subtotal As Integer = 0
                dGridAll.Rows(row).Cells(3 + (Integer.Parse(value))).Value = _
                        (Integer.Parse(dGridAll.Rows(row).Cells(3 + (Integer.Parse(value))).Value) + 1).ToString
                For x As Integer = 4 To 11
                    subtotal += Integer.Parse(dGridAll.Rows(row).Cells(x).Value)
                Next
                dGridAll.Rows(row).Cells(12).Value = subtotal.ToString
                dGridAll.Rows(row).Cells(15).Value = (subtotal * (Integer.Parse(dGridAll.Rows(row).Cells(13).Value)))
            Case "Pengiriman"
                Dim subtotal As Integer = 0
                dGridAll.Rows(row).Cells(3 + (Integer.Parse(value))).Value = _
                        (Integer.Parse(dGridAll.Rows(row).Cells(3 + (Integer.Parse(value))).Value) + 1).ToString
                For x As Integer = 4 To 11
                    subtotal += Integer.Parse(dGridAll.Rows(row).Cells(x).Value)
                Next
                dGridAll.Rows(row).Cells(12).Value = subtotal.ToString
                dGridAll.Rows(row).Cells(15).Value = (subtotal * (Integer.Parse(dGridAll.Rows(row).Cells(13).Value) - _
                (Integer.Parse(dGridAll.Rows(row).Cells(13).Value) * (Integer.Parse(dGridAll.Rows(row).Cells(14).Value) / 100))))
        End Select
        updateGrand()
    End Sub
    Private Sub updateGrand()
        'MsgBox(DataGridView1.Rows(0).Cells(1).Value)
        For b As Integer = 1 To 8
            Dim gt1 As Integer = 0
            Dim gt2 As Integer = 0
            Dim gt3 As Integer = 0
            For a As Integer = 0 To dGridAll.Rows.Count - 1
                gt1 += Integer.Parse(dGridAll.Rows(a).Cells(b + 3).Value)
                gt2 += Integer.Parse(dGridAll.Rows(a).Cells(12).Value)
                gt3 += Integer.Parse(dGridAll.Rows(a).Cells(15).Value)
            Next
            DataGridView1.Rows(0).Cells(b).Value = gt1.ToString
            txtotQty.Text = gt2.ToString
            If Label2.Text = "Penjualan Toko" Or Label2.Text = "Pengiriman" Then
                txGrandtotal2.Text = gt3.ToString
            Else
                txGrandtotal1.Text = gt3.ToString
            End If
        Next
    End Sub
    Private Sub txtbarkode_TextChanged(sender As Object, e As EventArgs) Handles txtbarkode.TextChanged
        loadValuetoGrid()
    End Sub

    Private Sub cmbcatjual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcatjual.SelectedIndexChanged
        If cmbcatjual.SelectedIndex = -1 Then
            MsgBox("Pilih Kategori Penjualan")
            Return
        Else
            kategori = cmbcatjual.SelectedItem
        End If
    End Sub

    Private Sub cmbstat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstat.SelectedIndexChanged
        If cmbstat.SelectedIndex = -1 Then
            MsgBox("Pilih Kategori Return Barang")
            Return
        Else
            kategori = cmbstat.SelectedItem
            lblNama.Text = "Nama " & kategori
        End If
    End Sub

    Private Sub loadSize()
        Dim dt As DataTable = clasg.setSize()
        dGridSize.DataSource = dt
        dGridSize.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dGridSize.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows.Insert(0, "", "0", "0", "0", "0", "0", "0", "0", "0")
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub loadCom()
        txnama.AutoCompleteCustomSource = clasc.retComplete("select namagarmen from tb_garment")
        For Each a As String In clasc.retComplete("select namatoko from tb_stores")
            txnama.AutoCompleteCustomSource.Add(a)
        Next
    End Sub

    Private Sub formTerimaKirimJual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSize()
        loadCom()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Select Case Label2.Text
            Case "Penerimaan"
                SimpanPenerimaan()
            Case "Pengiriman"
                SimpanPengiriman()
            Case "Penjualan Toko"
                SimpanjualToko()
            Case "Penjualan Gudang"
                SimpanjualGudang()
        End Select
        clearForm()
    End Sub
    Private Sub clearForm()
        dGridAll.Rows.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Insert(0, "", "0", "0", "0", "0", "0", "0", "0", "0")
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        txtresi.Clear()
        txtresi.Enabled = True
        txnama.Clear()
        txtotQty.Clear()
        txtotPrice.Clear()
        txGrandtotal1.Clear()
        txGrandtotal2.Clear()
    End Sub

    Private Sub loadAutoKode()
        dr = clasQuery.retDatareader("select kode from tb_pengiriman order by kode desc limit 1")
        If dr.HasRows Then
            If Integer.Parse(dr(0).ToString.Substring(0, 4)) >= 9999 Then
                txtresi.Text = "FK" & Format(Now(), "MMddyyyy") & customNumber("0", 1, 4)
            Else
                txtresi.Text = "FK" & Format(Now(), "MMddyyyy") & customNumber("0", Integer.Parse(dr(0).ToString.Substring(10)), 4)
            End If
        Else
            txtresi.Text = "FK" & Format(Now(), "MMddyyyy") & customNumber("0", 1, 4)
        End If
    End Sub

    Private Sub txnama_TextChanged(sender As Object, e As EventArgs) Handles txnama.TextChanged
        If Label2.Text = "Pengiriman" Then
            dr = clasQuery.retDatareader("select disc from tb_stores where namatoko='" & txnama.Text & "'")
            If dr.Read Then
                disc = dr(0).ToString
            End If
        End If
    End Sub
End Class