Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class formTerimaKirimJual1
    Dim clasQuery As New publicQuery
    Dim clasg As New setDefaultGrid
    Dim clasc As New autoComplete
    Dim dr As MySqlDataReader
    Dim kategori As String = ""
    Dim disc As String = "0"
    Dim autoNumber As String = ""

    Private Sub formTerimaKirimJual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Panel10.Height = SplitContainer1.Panel2.Height - 285
        loadSize()
        loadCom()
    End Sub

    Private Sub loadCom()
        txnama.AutoCompleteCustomSource = clasc.retComplete("select namagarmen from tb_garment")
        For Each a As String In clasc.retComplete("select namatoko from tb_stores")
            txnama.AutoCompleteCustomSource.Add(a)
        Next
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

    Private Sub loadAutoKode()
        Select Case Label2.Text
            Case "Penerimaan"
                dr = clasQuery.retDatareader("select kode from tb_penerimaan order by kode desc limit 1")
                If dr.Read Then
                    If Integer.Parse(dr(0).ToString.Substring(10)) >= 9999 Then
                        autoNumber = "FT" & Format(Now(), "MMddyyyy") & customNumber("0", 1, 4)
                    Else
                        autoNumber = "FT" & Format(Now(), "MMddyyyy") & customNumber("0", Integer.Parse(dr(0).ToString.Substring(10)) + 1, 4)
                    End If
                Else
                    autoNumber = "FT" & Format(Now(), "MMddyyyy") & customNumber("0", 1, 4)
                End If
            Case "Pengiriman"
                dr = clasQuery.retDatareader("select kode from tb_pengiriman order by kode desc limit 1")
                If dr.Read Then
                    If Integer.Parse(dr(0).ToString.Substring(10)) >= 9999 Then
                        txtresi.Text = "FK" & Format(Now(), "MMddyyyy") & customNumber("0", 1, 4)
                    Else
                        txtresi.Text = "FK" & Format(Now(), "MMddyyyy") & customNumber("0", Integer.Parse(dr(0).ToString.Substring(10)) + 1, 4)
                    End If
                Else
                    txtresi.Text = "FK" & Format(Now(), "MMddyyyy") & customNumber("0", 1, 4)
                End If
        End Select
    End Sub
    Private Sub Label2_TextChanged(sender As Object, e As EventArgs) Handles Label2.TextChanged
        If Label2.Text = "Pengiriman" Then
            lblAuto.Visible = True
            lblAuto.Text = "No. Pengiriman"
            txtresi.Visible = True
            txtresi.Enabled = False
            Me.Text = "Form " & Label2.Text
            lblNama.Text = "Toko"
            dGridAll.Columns(14).Visible = True
            TextBox7.Text = Environment.NewLine & Environment.NewLine & Environment.NewLine & "Cons."
            loadAutoKode()
        ElseIf Label2.Text = "Penerimaan" Then
            lblAuto.Visible = True
            TextBox8.Text = ""
            lblAuto.Text = "No. Nota"
            txtresi.Visible = True
            Me.Text = "Form " & Label2.Text
            lblNama.Text = "Garment"
            loadAutoKode()
        ElseIf Label2.Text = "Penjualan Toko" Then
            Me.Text = "Form " & Label2.Text
            dGridAll.Columns(14).Visible = True
            TextBox7.Text = Environment.NewLine & Environment.NewLine & Environment.NewLine & "Cons."
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

#Region "update grid"
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
            Case "Penerimaan", "Penjualan Gudang"
                Dim rows As String() = {dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, _
                                            "0", "0", "0", "0", "0", "0", "0", "0", "0", dr(5).ToString, "0", "0"}
                dGridAll.Rows.Add(rows)
            Case "Pengiriman", "Penjualan Toko"

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
            Case "Pengiriman", "Penjualan Toko", "Penjualan Gudang"
                output = "select a.kodeItem, a.nama,a.color,a.kodeSize,c.value, a.hargaJual, b.barcode " & _
                                     "from tb_produk a, tb_subproduk b, tb_size c where b.barcode ='" & txtbarkode.Text & "' and " & _
                                     "a.kodeItem=b.kodeitem and a.kodesize=c.kode and b.kodesize=c.value"
        End Select
        Return output
    End Function

    Private Sub rowTotalUpdate(value As String, row As String)
        Select Case Label2.Text
            Case "Penerimaan", "Penjualan Gudang"
                Dim subtotal As Integer = 0
                dGridAll.Rows(row).Cells(3 + (Integer.Parse(value))).Value = _
                        (Integer.Parse(dGridAll.Rows(row).Cells(3 + (Integer.Parse(value))).Value) + 1).ToString
                For x As Integer = 4 To 11
                    subtotal += Integer.Parse(dGridAll.Rows(row).Cells(x).Value)
                Next
                dGridAll.Rows(row).Cells(12).Value = subtotal.ToString
                dGridAll.Rows(row).Cells(15).Value = (subtotal * (Integer.Parse(dGridAll.Rows(row).Cells(13).Value)))
            Case "Pengiriman", "Penjualan Toko"
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
#End Region

#Region "save Query"
    Private Sub SimpanjualGudang()
        MsgBox(clasQuery.insertQuery("query"))
    End Sub
    'auto=kodetrans-nama(sponsor,toko,gudang)-tgl-operator-totalqty-totaljual-statjual-mediajual
    Private Sub SimpanjualToko()
        Dim pos As String = ""
        dr = clasQuery.retDatareader("select auto from tb_penjualan order by auto desc limit 1")
        If dr.Read Then
            pos = (Integer.Parse(dr(0).ToString) + 1).ToString
            clasQuery.insertQuery("insert into tb_penjualan values ('','" & pos & "','" & txnama.Text & "','" & DateTime.Now.ToMySql & _
                              "','" & MainForm.txUsername.Text & "','" & txtotQty.Text & "','" & txGrandtotal2.Text & "','Toko','-')")
        End If

        For a As Integer = 0 To dGridAll.Rows.Count - 1
            Dim tem As String = ""
            For b As Integer = 4 To 11
                MainForm.ProgressBar1.Value = ((b * (a + 1)) / (11 * dGridAll.Rows.Count) * 100)
                clasQuery.updateQuery("update tb_stoktokodetail set qty=qty-" & dGridAll.Rows(a).Cells(b).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & _
                                      "' and value='" & b - 3 & "' and namaToko='" & txnama.Text & "'")
                tem &= "('" & pos & "','" & dGridAll.Rows(a).Cells(0).Value _
                                      & "','" & b - 3 & "','" & dGridAll.Rows(a).Cells(b).Value & "'),"
            Next
            clasQuery.insertQuery("insert into tb_penjualandetail values " & tem.Substring(0, tem.Length - 1))
            clasQuery.updateQuery("update tb_stoktoko set qty=qty-" & dGridAll.Rows(a).Cells(12).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & _
                                  "' and namaToko='" & txnama.Text & "'")
        Next
        MsgBox("Saved")
    End Sub

    Private Sub SimpanPenerimaan()
        clasQuery.insertQuery("insert into tb_penerimaan values('" & autoNumber & "','" & txtresi.Text & "','" & _
                              DateTime.Now.ToMySql & "','" & txnama.Text & "','" & MainForm.txUsername.Text & "','" & txtotQty.Text & "','" & txGrandtotal1.Text & "')")
        For a As Integer = 0 To dGridAll.Rows.Count - 1
            Dim tem As String = ""
            For b As Integer = 4 To 11
                MainForm.ProgressBar1.Value = ((b * (a + 1)) / (11 * dGridAll.Rows.Count) * 100)
                clasQuery.updateQuery("update tb_stokgudangdetail set qty=qty+" & dGridAll.Rows(a).Cells(b).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & _
                                      "' and value='" & b - 3 & "'")
                tem &= "('" & autoNumber & "','" & dGridAll.Rows(a).Cells(0).Value _
                                      & "','" & b - 3 & "','" & dGridAll.Rows(a).Cells(b).Value & "'),"
            Next
            clasQuery.insertQuery("insert into tb_penerimaandetail values " & tem.Substring(0, tem.Length - 1))
            clasQuery.updateQuery("update tb_stokgudang set qty=qty+" & dGridAll.Rows(a).Cells(12).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & "'")
        Next
        MsgBox("Saved")
    End Sub

    Private Sub SimpanPengiriman()
        clasQuery.insertQuery("insert into tb_pengiriman values('" & txtresi.Text & "','" & txnama.Text & "','" & _
                              DateTime.Now.ToMySql & "','" & MainForm.txUsername.Text & "','" & txtotQty.Text & "','" & txGrandtotal2.Text & "')")
        For a As Integer = 0 To dGridAll.Rows.Count - 1
            Dim tem As String = ""
            Dim tem2 As String = ""
            dr = clasQuery.retDatareader("select * from tb_stoktoko where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & _
                                         "' and namatoko='" & txnama.Text & "'")
            If dr.Read Then
                clasQuery.updateQuery("update tb_stoktoko set qty=qty+" & dGridAll.Rows(a).Cells(12).Value & " where kodeitem='" & _
                                      dGridAll.Rows(a).Cells(0).Value & "' and namatoko='" & txnama.Text & "'")
            Else
                clasQuery.insertQuery("insert into tb_stoktoko values ('" & txnama.Text & "','" & dGridAll.Rows(a).Cells(0).Value & _
                                      "','" & txtotQty.Text & "')")
            End If
            For b As Integer = 4 To 11
                MainForm.ProgressBar1.Value = ((b * (a + 1)) / (11 * dGridAll.Rows.Count) * 100)
                clasQuery.updateQuery("update tb_stokgudangdetail set qty=qty-" & dGridAll.Rows(a).Cells(b).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & _
                                      "' and value='" & b - 3 & "'")
                tem2 &= "('" & txnama.Text & "','" & dGridAll.Rows(a).Cells(0).Value _
                                     & "','" & b - 3 & "','" & dGridAll.Rows(a).Cells(b).Value & "'),"
                tem &= "('" & txtresi.Text & "','" & dGridAll.Rows(a).Cells(0).Value _
                                     & "','" & b - 3 & "','" & dGridAll.Rows(a).Cells(b).Value & "'),"
            Next
            clasQuery.insertQuery("insert into tb_pengirimandetail values " & tem.Substring(0, tem.Length - 1))
            clasQuery.insertQuery("insert into tb_stoktokodetail values " & tem2.Substring(0, tem2.Length - 1))
            clasQuery.updateQuery("update tb_stokgudang set qty=qty-" & dGridAll.Rows(a).Cells(12).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & "'")
        Next
        MsgBox("Saved")
    End Sub
#End Region
    Private Sub txnama_TextChanged(sender As Object, e As EventArgs) Handles txnama.TextChanged
        If Label2.Text = "Pengiriman" Or Label2.Text = "Penjualan Toko" Then
            dr = clasQuery.retDatareader("select disc from tb_stores where namatoko='" & txnama.Text & "'")
            If dr.Read Then
                disc = dr(0).ToString
            End If
        End If
    End Sub

    Private Sub txtbarkode_TextChanged(sender As Object, e As EventArgs) Handles txtbarkode.TextChanged
        loadValuetoGrid()
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
        Dim dt3 As DataTable = dGridAll.DataSource
        MainForm.ProgressBar1.Value = 0
        clearForm()
    End Sub
    Private Sub clearForm()
        dGridAll.Rows.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Insert(0, "", "0", "0", "0", "0", "0", "0", "0", "0")
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        txtresi.Clear()
        txnama.Clear()
        txtotQty.Clear()
        txtotPrice.Clear()
        txGrandtotal1.Clear()
        txGrandtotal2.Clear()
    End Sub

    Private Sub dGridAll_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim x As DialogResult = MessageBox.Show("Hapus Row?", "INFO", MessageBoxButtons.YesNo)
        If x = Windows.Forms.DialogResult.Yes Then
            dGridAll.Rows.RemoveAt(e.RowIndex)
            updateGrand()
        End If
    End Sub
End Class