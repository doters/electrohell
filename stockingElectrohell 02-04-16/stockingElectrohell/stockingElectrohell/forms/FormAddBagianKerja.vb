Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FormAddBagianKerja
    Dim clasq As New publicQuery
    Dim clasg As New gridQueries
    Dim dr As MySqlDataReader
    Dim dt As DataTable

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        dr = clasq.retDatareader("select section from tb_usercategory where section ='" & TextBox1.Text & "'")
        If dr.Read Then
            MsgBox("Section Used")
            Return
        End If
        MsgBox(clasq.insertQuery("insert into tb_usercategory values('" & TextBox1.Text & "','" & ComboBox1.SelectedItem & "')"))
        For Each x As Control In Me.Controls
            If TypeOf x Is TextBox Then
                x.Text = ""
            End If
        Next
        ComboBox1.Text = ""
        loadView()
    End Sub

    Private Sub loadView()
        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        dt = clasg.loadDataTable(" Section,Privilege ", "tb_usercategory", "1")

        For Each col As DataColumn In dt.Columns
            ListView1.Columns.Add(col.ToString)
        Next
        For Each row As DataRow In dt.Rows
            Dim lst As ListViewItem
            lst = ListView1.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
            For a As Integer = 1 To dt.Columns.Count - 1
                lst.SubItems.Add(If(row(a) IsNot Nothing, row(a).ToString, ""))
            Next
        Next
        ListView1.Columns(0).Width = 120
    End Sub
    Private Sub FormAddBagianKerja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadView()
    End Sub

    Private Sub FormAddBagianKerja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim kosong As Boolean = False

        For Each x As Control In Me.Controls
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
        FormAddUser.Activate()
    End Sub
End Class