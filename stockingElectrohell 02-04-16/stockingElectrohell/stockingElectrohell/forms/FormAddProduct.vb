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
        Dim dr2 As MySqlDataReader
        For Each atx As Control In Me.Controls
            If TypeOf (atx) Is TextBox And atx.Text = "" Then
                MsgBox("Please fill all the data field")
                atx.Focus()
                Return
            End If
        Next
        Dim x As Integer
        Dim a As Boolean = Integer.TryParse(txthrgpokok.Text, x)
        If a = False Then
            MsgBox("Wrong Number")
            txthrgpokok.Focus()
            Return
        End If
        Dim b As Boolean = Integer.TryParse(txthrgjual.Text, x)
        If b = False Then
            MsgBox("Wrong Number")
            txthrgjual.Focus()
            Return
        End If

        dr2 = clasq.retDatareader("select * from tb_produk where kodeitem='" & txtkode.Text & "'")
        If dr2.Read Then

        Else
            clasq.insertQuery("insert into tb_produk values('" & txtkode.Text & "','" & _
                                         txtproduk.Text & "','" & cmbCategory.SelectedItem & "','" & _
                                         txthrgpokok.Text & "','" & txthrgjual.Text & "','" & _
                                         cmbColor.SelectedItem & "','" & cmbukuran.SelectedItem.ToString & "','')")

            dr = clasq.retDatareader("select count(warehouse) from tb_warehouse")
            If dr.Read() Then
                For xxa As Integer = 1 To Integer.Parse(dr(0).ToString())
                    clasq.insertQuery("insert into tb_stokgudang values(' " & xxa & "','" & txtkode.Text & "','0')")
                Next
            End If

            dr = clasq.retDatareader("select count(size) from tb_size where kode='" & cmbukuran.SelectedItem.ToString & _
                                     "'")
            Dim tempQuery As String = "insert into tb_subProduk (`barcode`, `kodeItem`, `kodeSize`) values "
            If dr.Read() Then
                For loops As Integer = 1 To Integer.Parse(dr(0).ToString())
                    tempQuery &= "('','" & txtkode.Text & "','" & loops.ToString & "'),"
                Next
                MsgBox(clasq.insertQuery(tempQuery.Substring(0, tempQuery.Length - 1)))
            End If
            End If

        For Each xz As Control In GroupBox1.Controls
            If TypeOf xz Is TextBox Then
                xz.Text = ""
            End If
        Next
        clearForm()
    End Sub

    Private Sub clearForm()
        For Each atx As Control In GroupBox1.Controls
            If TypeOf (atx) Is TextBox Then
                atx.Text = ""
            End If
            cmbukuran.SelectedIndex = -1
            cmbCategory.SelectedIndex = -1
            cmbColor.SelectedIndex = -1
            txtkode.Focus()
        Next
    End Sub
    Private Sub txtkode_Leave(sender As Object, e As EventArgs) Handles txtkode.Leave
        Try
            clas.cekKon()
            cmd = New MySqlCommand("select kodeItem from tb_produk where kodeItem='" & txtkode.Text & "'", conn)
            dr = cmd.ExecuteReader
            If dr.Read() Then
                MsgBox("Code Used, please use another code")
                txtkode.Clear()
                txtkode.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loadCom()
        'txtWarna.AutoCompleteCustomSource.Clear()
        'txtkategori.AutoCompleteCustomSource.Clear()
        cmbukuran.Items.Clear()
        'txtWarna.AutoCompleteCustomSource = com.retComplete("select color from tb_color")
        'txtkategori.AutoCompleteCustomSource = com.retComplete("select kategori from tb_itemkategori")
        cmbColor.Items.Clear()
        cmbCategory.Items.Clear()
        dr = clasq.retDatareader("select kategori from tb_itemkategori")
        While dr.Read
            cmbCategory.Items.Add(dr(0).ToString)
        End While
        dr = clasq.retDatareader("select color from tb_color")
        While dr.Read
            cmbColor.Items.Add(dr(0).ToString)
        End While
        dr = clasq.retDatareader("select kode from tb_size group by kode order by kode asc")
        While dr.Read
            cmbukuran.Items.Add(dr(0).ToString)
        End While
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
       
            For Each F As Form In MainForm.MdiChildren
                'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
                If TypeOf F Is FormColors_Category Then
                    F.BringToFront()
                    Return
                End If
            Next
            Dim x As New FormColors_Category
            x.MdiParent = MainForm
            x.Label3.Text = "Category"
            x.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormColors_Category Then
                F.BringToFront()
                Return
            End If
        Next
        Dim x As New FormColors_Category
        x.MdiParent = MainForm
        x.Label3.Text = "Color"
        x.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormAddSize Then
                F.BringToFront()
                Return
            End If
        Next
        Dim x As New FormAddSize
        x.MdiParent = MainForm
        x.txtkode.Text = cmbukuran.Text
        x.Show()
        x.Button1.PerformClick()
    End Sub

    Private Sub cmbukuran_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbukuran.SelectedIndexChanged
        dr = clasq.retDatareader("select keterangan from tb_size where kode='" & cmbukuran.SelectedItem & "'")
        If dr.Read Then
            Label5.Text = dr(0).ToString
        End If
    End Sub

    Private Sub FormAddProduct_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub FormAddProduct_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        loadCom()
    End Sub
End Class