Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class formReturn
    Dim clasQuery As New publicQuery
    Dim clasg As New setDefaultGrid
    Dim clasc As New autoComplete
    Dim grid As New gridQueries
    Dim dr As MySqlDataReader
    Dim kategori As String = "", tempBarcode As String = "", tempPrice As String = "", tmpBarcode As String = ""
    Dim disc As String = "0"
    Dim autoNumber As String = ""
    Dim dt As DataTable


    Private Sub formTerimaKirimJual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel10.Height = SplitContainer1.Panel2.Height - 285
        Me.Text = "Items Return"
        TextBox8.Text = ""
        lblNama.Text = "Name "
        cmbstat.Visible = True
        lblStatus.Visible = True
        lblAuto.Visible = True
        lblAuto.Text = "Bill Number"
        txtresi.Visible = True
        txtresi.Enabled = False
        loadAutoKode()
        loadSize()
        loadCom()
    End Sub

    Private Sub loadCom()
        txnama.AutoCompleteCustomSource.Clear()
        If cmbstat.SelectedItem = "Garment" Then
            txnama.AutoCompleteCustomSource = clasc.retComplete("select namagarmen from tb_garment")
        ElseIf cmbstat.SelectedItem = "Store" Then
            For Each a As String In clasc.retComplete("select namatoko from tb_stores")
                txnama.AutoCompleteCustomSource.Add(a)
            Next
        End If

        cmbGudang.Items.Clear()
        For Each a As String In clasc.retComplete("select warehousename from tb_warehouse")
            cmbGudang.Items.Add(a)
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
        
                dr = clasQuery.retDatareader("select kode from tb_return order by kode desc limit 1")
                If dr.Read Then
                    If Integer.Parse(dr(0).ToString.Substring(10)) >= 9999 Then
                        txtresi.Text = "FR" & Format(Now(), "MMddyyyy") & customNumber("0", 1, 4)
                    Else
                        txtresi.Text = "FR" & Format(Now(), "MMddyyyy") & customNumber("0", Integer.Parse(dr(0).ToString.Substring(10)) + 1, 4)
                    End If
                Else
                    txtresi.Text = "FR" & Format(Now(), "MMddyyyy") & customNumber("0", 1, 4)
                End If
    End Sub

#Region "update grid"
    Private Sub loadValuetoGrid()
        dr = clasQuery.retDatareader(getQuery())
        If dr.Read Then
            If dGridAll.Rows.Count = 0 Then
                initGrid(dr)
                'rowTotalUpdate(dr(4).ToString, "0")
            Else
                For a As Integer = 0 To dGridAll.Rows.Count - 1
                    If dGridAll.Rows(a).Cells(0).Value = dr(0).ToString Then
                        'rowTotalUpdate(dr(4).ToString, a)
                        txtbarkode.Clear()
                        Return
                    End If
                Next
                initGrid(dr)
                'rowTotalUpdate(dr(4).ToString, dGridAll.Rows.Count - 1)
            End If
            txtbarkode.Clear()
        End If
    End Sub

    Private Sub initGrid(dr As MySqlDataReader)
        If cmbstat.SelectedItem = "Store" Then
            Dim rows As String() = {dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, _
                                    "0", "0", "0", "0", "0", "0", "0", "0", "0", tempPrice, disc, "0"}
            dGridAll.Rows.Add(rows)
            dGridAll.Columns(14).Visible = True
        Else
            Dim rows As String() = {dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString(), _
                                    "0", "0", "0", "0", "0", "0", "0", "0", "0", tempPrice, "0", "0"}
            dGridAll.Rows.Add(rows)
            dGridAll.Columns(14).Visible = False
        End If

    End Sub
    Private Function getQuery() As String
        Dim output As String = ""
        If cmbstat.SelectedItem = "Store" Then
            output = "select a.kodeItem, a.nama,a.color,a.kodeSize,c.value, b.barcode " & _
                            "from tb_produk a, tb_subproduk b, tb_size c where b.kodeitem ='" & tempBarcode & "' and " & _
                            "a.kodeItem=b.kodeitem and a.kodesize=c.kode and b.kodesize=c.value and a.status='Active'" ' and nomor nota
        Else
            output = "select a.kodeItem, a.nama,a.color,a.kodeSize,c.value, a.hargaPokok, b.barcode " & _
                             "from tb_produk a, tb_subproduk b, tb_size c where b.kodeitem ='" & tempBarcode & "' and " & _
                             "a.kodeItem=b.kodeitem and a.kodesize=c.kode and b.kodesize=c.value and a.status='Active'"
        End If
        Return output
    End Function

    Private Sub rowTotalUpdate(value As String, row As String)
        If cmbstat.SelectedItem = "Store" Then
            Dim subtotal As Integer = 0
            dGridAll.Rows(row).Cells(3 + (Integer.Parse(value))).Value = _
                    (Integer.Parse(dGridAll.Rows(row).Cells(3 + (Integer.Parse(value))).Value) + 1).ToString
            For x As Integer = 4 To 11
                subtotal += Integer.Parse(dGridAll.Rows(row).Cells(x).Value)
            Next
            dGridAll.Rows(row).Cells(12).Value = subtotal.ToString
            dGridAll.Rows(row).Cells(15).Value = (subtotal * (Integer.Parse(dGridAll.Rows(row).Cells(13).Value) - _
            (Integer.Parse(dGridAll.Rows(row).Cells(13).Value) * (Integer.Parse(dGridAll.Rows(row).Cells(14).Value) / 100))))
        ElseIf cmbstat.SelectedItem = "Garment" Then
            Dim subtotal As Integer = 0
            dGridAll.Rows(row).Cells(3 + (Integer.Parse(value))).Value = _
                    (Integer.Parse(dGridAll.Rows(row).Cells(3 + (Integer.Parse(value))).Value) + 1).ToString
            For x As Integer = 4 To 11
                subtotal += Integer.Parse(dGridAll.Rows(row).Cells(x).Value)
            Next
            dGridAll.Rows(row).Cells(12).Value = subtotal.ToString
            dGridAll.Rows(row).Cells(15).Value = (subtotal * (Integer.Parse(dGridAll.Rows(row).Cells(13).Value)))
        End If
        updateGrand()
    End Sub
    Private Sub updateGrand()
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Insert(0, "", "0", "0", "0", "0", "0", "0", "0", "0")
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        txtotQty.Clear()
        txtotPrice.Clear()
        txGrandtotal1.Clear()
        txGrandtotal2.Clear()

        If dGridAll.Rows.Count >= 1 Then
            For b As Integer = 1 To 8
                Dim gt1 As Double = 0
                Dim gt2 As Double = 0
                Dim gt3 As Double = 0
                For a As Integer = 0 To dGridAll.Rows.Count - 1
                    gt1 += Double.Parse(dGridAll.Rows(a).Cells(b + 3).Value)
                    gt2 += Double.Parse(dGridAll.Rows(a).Cells(12).Value)
                    gt3 += Double.Parse(dGridAll.Rows(a).Cells(15).Value)
                Next
                DataGridView1.Rows(0).Cells(b).Value = gt1.ToString
                txtotQty.Text = gt2.ToString
                If cmbstat.SelectedItem = "Toko" Then
                    txGrandtotal2.Text = gt3.ToString
                Else
                    txGrandtotal1.Text = gt3.ToString
                End If
            Next
        End If
    End Sub
#End Region

#Region "save Query"
    Private Sub returnBarang()
        Select Case cmbstat.SelectedItem
            Case "Store"
                clasQuery.insertQuery("insert into tb_return values('" & txtresi.Text & "','" & cmbGudang.SelectedIndex + 1 & _
                              "','" & DateTime.Now.ToMySql & "','Toko','" & txnama.Text & "','" & _
                              disc & "','" & MainForm.txUsername.Text & _
                              "','" & txtotQty.Text & "','" & txGrandtotal2.Text & "',0)")
                For a As Integer = 0 To dGridAll.Rows.Count - 1
                    Dim tem As String = ""
                    For b As Integer = 4 To 11
                        MainForm.ProgressBar1.Value = ((b * (a + 1)) / (11 * dGridAll.Rows.Count) * 100)
                        clasQuery.updateQuery("update tb_stoktokodetail set qty=qty-" & dGridAll.Rows(a).Cells(b).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & _
                                              "' and value='" & b - 3 & "' and namatoko='" & txnama.Text & "'")
                        clasQuery.updateQuery("update tb_stokgudangdetail set qty=qty+" & dGridAll.Rows(a).Cells(b).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & _
                                              "' and value='" & b - 3 & "' and warehouse='" & cmbGudang.SelectedIndex + 1 & "'")
                        tem &= "('" & txtresi.Text & "','" & dGridAll.Rows(a).Cells(0).Value _
                                              & "','" & b - 3 & "','" & dGridAll.Rows(a).Cells(b).Value & _
                                             "','" & dGridAll.Rows(a).Cells(14).Value & "','" & dGridAll.Rows(a).Cells(13).Value & "'),"
                    Next
                    clasQuery.insertQuery("insert into tb_returndetail values " & tem.Substring(0, tem.Length - 1))
                    clasQuery.updateQuery("update tb_stoktoko set qty=qty-" & dGridAll.Rows(a).Cells(12).Value & " where kodeitem='" & _
                                          dGridAll.Rows(a).Cells(0).Value & _
                                          "' and namatoko='" & txnama.Text & "'")
                    clasQuery.updateQuery("update tb_stokgudang set qty=qty-" & dGridAll.Rows(a).Cells(12).Value & " where kodeitem='" & _
                                          dGridAll.Rows(a).Cells(0).Value & "' and warehouse='" & cmbGudang.SelectedIndex + 1 & "'")
                Next
                MsgBox("Saved")
            Case "Garment"
                clasQuery.insertQuery("insert into tb_return values('" & txtresi.Text & "','" & cmbGudang.SelectedIndex + 1 & _
                              "','" & DateTime.Now.ToMySql & "','Garmen','" & txnama.Text & "','0','" & MainForm.txUsername.Text & _
                              "','" & txtotQty.Text & "','" & txGrandtotal1.Text & "',0)")
                For a As Integer = 0 To dGridAll.Rows.Count - 1
                    Dim tem As String = ""
                    For b As Integer = 4 To 11
                        MainForm.ProgressBar1.Value = ((b * (a + 1)) / (11 * dGridAll.Rows.Count) * 100)
                        clasQuery.updateQuery("update tb_stokgudangdetail set qty=qty-" & dGridAll.Rows(a).Cells(b).Value & " where kodeitem='" & dGridAll.Rows(a).Cells(0).Value & _
                                              "' and value='" & b - 3 & "' and warehouse='" & cmbGudang.SelectedIndex + 1 & "'")
                        tem &= "('" & txtresi.Text & "','" & dGridAll.Rows(a).Cells(0).Value _
                                              & "','" & b - 3 & "','" & dGridAll.Rows(a).Cells(b).Value & _
                                               "','" & dGridAll.Rows(a).Cells(14).Value & "','" & dGridAll.Rows(a).Cells(13).Value & "'),"
                    Next
                    clasQuery.insertQuery("insert into tb_returndetail values " & tem.Substring(0, tem.Length - 1))
                    clasQuery.updateQuery("update tb_stokgudang set qty=qty-" & dGridAll.Rows(a).Cells(12).Value & " where kodeitem='" & _
                                          dGridAll.Rows(a).Cells(0).Value & "' and warehouse='" & cmbGudang.SelectedIndex + 1 & "'")
                Next
                MsgBox("Saved")
        End Select
    End Sub
   
#End Region
    Private Sub txnama_TextChanged(sender As Object, e As EventArgs) Handles txnama.TextChanged

    End Sub

    Private Sub txtbarkode_TextChanged(sender As Object, e As EventArgs) Handles txtbarkode.TextChanged
        Try
            dr = clasQuery.retDatareader("select kodeitem, disc, price from tb_pengirimandetail where kode='" & txtbarkode.Text & "' group by kodeitem")
            While (dr.Read())
                tmpBarcode = txtbarkode.Text
                disc = dr(1).ToString()
                tempPrice = dr(2).ToString()
                tempBarcode = dr(0).ToString()
                loadValuetoGrid()
            End While
            'gridformat(dGridAll, 13)
            gridformat(dGridAll, 15)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        returnBarang()

        clearForm()
        txtresi.Focus()
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
        cmbstat.SelectedIndex = -1
        cmbstat.Text = ""
        loadAutoKode()
    End Sub

    Private Sub dGridAll_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGridAll.CellDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Dim x As DialogResult = MessageBox.Show("Delete Row?", "INFO", MessageBoxButtons.YesNo)
            If x = Windows.Forms.DialogResult.Yes Then
                dGridAll.Rows.RemoveAt(e.RowIndex)
                updateGrand()
            End If
        End If
    End Sub

    Private Sub dGridAll_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dGridAll.CellValueChanged
        Try
            'tampung datatable
            dt = grid.loadFilteredDataTable("select kodeItem, value, qty from tb_pengirimandetail where kode='" & tmpBarcode & "'")
            Dim drs() As DataRow = dt.Select("kodeItem = '" & dGridAll.Rows(e.RowIndex).Cells(0).Value & "' and " & _
                                             "value ='" & e.ColumnIndex - 3 & "'")

            If dGridAll.Rows(e.RowIndex).Cells(e.ColumnIndex).Value > drs(0)("qty") Then
                MsgBox("Value biger than items can returned")
                dGridAll.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                Return
            End If

            If cmbstat.SelectedItem = "Store" Then
                Dim subtotal As Integer = 0
                For x As Integer = 4 To 11
                    subtotal += Integer.Parse(dGridAll.Rows(e.RowIndex).Cells(x).Value)
                Next
                dGridAll.Rows(e.RowIndex).Cells(12).Value = subtotal.ToString
                dGridAll.Rows(e.RowIndex).Cells(15).Value = (subtotal * (Integer.Parse(dGridAll.Rows(e.RowIndex).Cells(13).Value) - _
                (Integer.Parse(dGridAll.Rows(e.RowIndex).Cells(13).Value) * (Integer.Parse(dGridAll.Rows(e.RowIndex).Cells(14).Value) / 100))))
            ElseIf cmbstat.SelectedItem = "Garment" Then
                Dim subtotal As Integer = 0
                For x As Integer = 4 To 11
                    subtotal += Integer.Parse(dGridAll.Rows(e.RowIndex).Cells(x).Value)
                Next
                dGridAll.Rows(e.RowIndex).Cells(12).Value = subtotal.ToString
                dGridAll.Rows(e.RowIndex).Cells(15).Value = (subtotal * (Integer.Parse(dGridAll.Rows(e.RowIndex).Cells(13).Value)))
            End If
            updateGrand()
        Catch ex As Exception

        End Try

        updateGrand()
    End Sub

    Private Sub dGridAll_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGridAll.CellClick
        If ((e.ColumnIndex >= 4 And e.ColumnIndex <= 11) Or (e.ColumnIndex = 13 Or e.ColumnIndex = 14)) And e.RowIndex >= 0 Then
            dGridAll.CurrentCell = dGridAll.Rows(e.RowIndex).Cells(e.ColumnIndex)
            dGridAll.BeginEdit(True)
        End If

    End Sub

    Private Sub cmbstat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstat.SelectedIndexChanged
        dGridAll.Rows.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Insert(0, "", "0", "0", "0", "0", "0", "0", "0", "0")
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        txnama.Clear()
        txGrandtotal1.Clear()
        txGrandtotal2.Clear()
        If cmbstat.SelectedItem = "Store" Then
            TextBox7.Text = Environment.NewLine & Environment.NewLine & Environment.NewLine & "Cons."
            TextBox8.Text = Environment.NewLine & Environment.NewLine & Environment.NewLine & "Total Price"
        Else
            TextBox7.Text = Environment.NewLine & Environment.NewLine & Environment.NewLine & "Total Price"
            TextBox8.Text = ""
        End If
        loadCom()
    End Sub

    Private Sub formTerimaKirimJual_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If dGridAll.Rows.Count >= 1 Then
            Dim dr As DialogResult = MessageBox.Show("Data not saved, close anyway?", "INFO", MessageBoxButtons.OKCancel)
            If dr = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
                Return
            End If
        End If
    End Sub
    Private Sub print()
        Dim tgl As String = Now.ToShortDateString
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim rpt As New rpttrans
        Dim rpt1 As New rptkirim
        Dim rpt2 As New rptukuran
        Dim kategori As String = Me.Text
        With dt
            .Columns.Add("tanggal")
            .Columns.Add("bill")
            .Columns.Add("nama") 'nama garmen / toko
            .Columns.Add("kategori")
            .Columns.Add("statretur")
            .Columns.Add("kode")
            .Columns.Add("produk")
            .Columns.Add("warna")
            .Columns.Add("size")
            .Columns.Add("s1")
            .Columns.Add("s2")
            .Columns.Add("s3")
            .Columns.Add("s4")
            .Columns.Add("s5")
            .Columns.Add("s6")
            .Columns.Add("s7")
            .Columns.Add("s8")
            .Columns.Add("ttlqty")
            .Columns.Add("hrg")
            .Columns.Add("cons")
            .Columns.Add("total")
            .Columns.Add("tot1")
            .Columns.Add("tot2")
            .Columns.Add("tot3")
            .Columns.Add("tot4")
            .Columns.Add("tot5")
            .Columns.Add("tot6")
            .Columns.Add("tot7")
            .Columns.Add("tot8")
            .Columns.Add("totqty")
            .Columns.Add("grand")
        End With

        With dt2
            .Columns.Add("s1")
            .Columns.Add("s2")
            .Columns.Add("s3")
            .Columns.Add("s4")
            .Columns.Add("s5")
            .Columns.Add("s6")
            .Columns.Add("s7")
            .Columns.Add("s8")
        End With

        For Each dr As DataGridViewRow In Me.dGridAll.Rows
            dt.Rows.Add(tgl, txtresi.Text, txnama.Text, "", cmbstat, dr.Cells(0).Value, dr.Cells(1).Value, dr.Cells(2).Value, _
                        dr.Cells(3).Value, dr.Cells(4).Value, dr.Cells(5).Value, dr.Cells(6).Value, dr.Cells(7).Value, dr.Cells(8).Value, dr.Cells(9).Value, _
                        dr.Cells(10).Value, dr.Cells(11).Value, dr.Cells(12).Value, dr.Cells(13).Value, dr.Cells(14).Value, dr.Cells(15).Value, _
                        DataGridView1.Rows(0).Cells(1).Value, DataGridView1.Rows(0).Cells(2).Value, DataGridView1.Rows(0).Cells(3).Value, _
                        DataGridView1.Rows(0).Cells(4).Value, DataGridView1.Rows(0).Cells(5).Value, DataGridView1.Rows(0).Cells(6).Value, _
                        DataGridView1.Rows(0).Cells(7).Value, DataGridView1.Rows(0).Cells(8).Value, txtotQty.Text, txGrandtotal1.Text)
        Next
        For Each dr2 As DataGridViewRow In Me.dGridSize.Rows
            dt2.Rows.Add(dr2.Cells(1).Value, dr2.Cells(2).Value, dr2.Cells(3).Value, dr2.Cells(4).Value, dr2.Cells(5).Value, _
            dr2.Cells(6).Value, dr2.Cells(7).Value, dr2.Cells(8).Value)
        Next
        If Label2.Text = "Pengiriman" Or Label2.Text = "Penjualan Toko" Then
            rpt1.SetDataSource(dt)
            'rpt2.SetDataSource(dt2)
            rpt1.Subreports("rptukuran.rpt").SetDataSource(dt2)
            viewreport.CrystalReportViewer1.ReportSource = rpt1
        Else
            rpt.SetDataSource(dt)
            'rpt2.SetDataSource(dt2)
            rpt.Subreports("rptukuran.rpt").SetDataSource(dt2)
            viewreport.CrystalReportViewer1.ReportSource = rpt
        End If
        viewreport.ShowDialog()

    End Sub

    Private Sub cmbcatjual_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        print()
        Dim dt3 As DataTable = dGridAll.DataSource
        MainForm.ProgressBar1.Value = 0
        clearForm()
    End Sub

    Private Sub cmbGudang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGudang.SelectedIndexChanged
        cmbGudang.Enabled = False
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        cmbGudang.Enabled = True
    End Sub
End Class