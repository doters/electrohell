Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FormAddProduct
    Dim clas As New publicKoneksi
    Dim clasq As New publicQuery
    Dim com As New autoComplete
    Dim conn As MySqlConnection = clas.retKon
    Dim cmd As MySqlCommand
    Dim dr As MySqlDataReader
    Dim active As String = "0"


    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        For Each atx As Control In Me.Controls
            If TypeOf (atx) Is TextBox And atx.Text = "" Then
                MsgBox("Data Belum Lengkap")
                atx.Focus()
                Return
            End If
        Next
        Dim x As Integer
        Dim a As Boolean = Integer.TryParse(txthrgpokok.Text, x)
        If a = False Then
            MsgBox("Format Angka salah")
            txthrgpokok.Focus()
            Return
        End If
        Dim b As Boolean = Integer.TryParse(txthrgjual.Text, x)
        If b = False Then
            MsgBox("Format Angka salah")
            txthrgjual.Focus()
            Return
        End If
        clasq.insertQuery("insert into tb_produk values('" & txtkode.Text & "','" & _
                                         txtproduk.Text & "','" & txtkategori.Text & "','" & _
                                         txthrgpokok.Text & "','" & txthrgjual.Text & "','" & _
                                         txtWarna.Text & "','" & cmbukuran.SelectedItem.ToString & "','" & active & _
                                         "')")
        clasq.insertQuery("insert into tb_stokgudang values('" & txtkode.Text & "','0')")
        dr = clasq.retDatareader("select count(size) from tb_size where kode='" & cmbukuran.SelectedItem.ToString & _
                                 "'")
        Dim tempQuery As String = "insert into tb_subProduk (`barcode`, `kodeItem`, `kodeSize`) values "
        If dr.Read() Then
            For loops As Integer = 1 To Integer.Parse(dr(0).ToString())
                tempQuery &= "('','" & txtkode.Text & "','" & loops.ToString & "'),"
            Next
            MsgBox(clasq.insertQuery(tempQuery.Substring(0, tempQuery.Length - 1)))
        End If
        
    End Sub

    Private Sub txtkode_Leave(sender As Object, e As EventArgs) Handles txtkode.Leave
        Try
            clas.cekKon()
            cmd = New MySqlCommand("select kodeItem from tb_produk where kodeItem='" & txtkode.Text & "'", conn)
            dr = cmd.ExecuteReader
            If dr.Read() Then
                MsgBox("Kode Sudah digunakan")
                txtkode.Clear()
                txtkode.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loadCom()
        txtWarna.AutoCompleteCustomSource = com.retComplete("select color from tb_color")
        txtkategori.AutoCompleteCustomSource = com.retComplete("select kategori from tb_itemkategori")
        dr = clasq.retDatareader("select kode from tb_size group by kode order by kode asc")
        While dr.Read
            cmbukuran.Items.Add(dr(0).ToString)
        End While
    End Sub
    Private Sub FormAddProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCom()
    End Sub

    Private Sub cbaktif_CheckedChanged(sender As Object, e As EventArgs) Handles cbaktif.CheckedChanged
        If cbaktif.Checked = True Then
            active = "Aktif"
        Else
            active = "Tidak Aktif"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dr = clasq.retDatareader("select * from tb_itemkategori where kategori='" & txtkategori.Text & "'")
        If dr.Read Then
            MsgBox("Kategori sudah terdaftar")
            Return
        ElseIf txtkategori.Text <> "" Then
            txtkategori.AutoCompleteCustomSource.Add(txtkategori.Text)
            Dim x As New FormColors_Category
            x.MdiParent = MainForm
            x.Label3.Text = "Category"
            x.txtnama.Text = txtkategori.Text
            x.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dr = clasq.retDatareader("select * from tb_color where color='" & txtWarna.Text & "'")
        If dr.Read Then
            MsgBox("Warna sudah terdaftar")
            Return
        ElseIf txtWarna.Text <> "" Then
            txtWarna.AutoCompleteCustomSource.Add(txtWarna.Text)
            Dim x As New FormColors_Category
            x.MdiParent = MainForm
            x.Label3.Text = "Color"
            x.txtnama.Text = txtWarna.Text
            x.Show()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dr = clasq.retDatareader("select * from tb_size where kode='" & cmbukuran.Text & "'")
        If dr.Read Then
            MsgBox("Size sudah terdaftar")
            Return
        ElseIf cmbukuran.Text <> "" Then
            cmbukuran.Items.Add(cmbukuran.Text)
            Dim x As New FormAddSize
            x.MdiParent = MainForm
            x.txtkode.Text = cmbukuran.Text
            x.Show()
            x.Button1.PerformClick()
        End If
    End Sub
End Class