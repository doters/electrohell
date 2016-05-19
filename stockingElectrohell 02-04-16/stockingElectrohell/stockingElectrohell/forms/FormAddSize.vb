Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FormAddSize
    Dim clasg As New setDefaultGrid
    Dim clasquer As New publicQuery
    Dim dt As DataTable
    Dim dr As MySqlDataReader
    Dim added As Boolean = False
    Private Sub ViewAllSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewAllSizeToolStripMenuItem.Click
        added = False
        dt = clasg.setSize
        dGridView.DataSource = dt
        dGridView.AutoResizeColumns()
        dGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dr = clasquer.retDatareader("select * from tb_size where kode='" & txtkode.Text & "'")
        If dr.Read Then
            MsgBox("Code Used")
        Else
            dt = clasg.setGrid()
            dt.Rows.Add(txtkode.Text, "", "", "", "", "", "", "", "")
            dGridView.DataSource = dt
            dGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            added = True
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If txtKeterangan.Text = "" Then
            MsgBox("Please fill Item Description")
            Return
        End If
        Dim emp As String = "0"
        Dim tempQuery As String = "insert into tb_size values "
        Button1.Focus()
        If dGridView.Rows.Count >= 1 And added = True Then
            For a As Integer = 1 To dGridView.ColumnCount - 1
                If dGridView.Rows(0).Cells(a).Value = "" Then
                    emp = "emp"
                Else
                    tempQuery &= "('" & txtkode.Text & "','" & dGridView.Rows(0).Cells(a).Value & _
                                "','" & a & "','" & txtKeterangan.Text & "'),"
                    For x As Integer = 1 To dGridView.ColumnCount - 1
                        If dGridView.Rows(0).Cells(a).Value = dGridView.Rows(0).Cells(x).Value And x <> a And dGridView.Rows(0).Cells(a).Value <> "" Then
                            emp = "dup"
                            dGridView.Rows(0).Cells(a).Value = ""
                        End If
                    Next
                End If
            Next
        End If
        If emp = "emp" Then
            MsgBox("Empty Field found")
            tempQuery = "insert into tb_size values "
            Return
        ElseIf emp = "dup" Then
            MsgBox("Duplicate Size")
            tempQuery = "insert into tb_size values "
            Return
        Else
            If added = True Then
                MsgBox(clasquer.insertQuery(tempQuery.Substring(0, tempQuery.Length - 1)))
            End If
        End If
        For Each x As Control In Me.Controls
            If TypeOf x Is TextBox Then
                x.Text = ""
            End If
        Next
        FormAddProduct.Activate()
        Close()
    End Sub

    Private Sub FormAddSize_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    End Sub
End Class