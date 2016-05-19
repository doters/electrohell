Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FormColors_Category
    Dim clasq As New publicQuery
    Dim clasg As New gridQueries
    Dim dr As MySqlDataReader
    Public Function getInsertCase(input As String) As String
        Dim output As String = ""
        Select Case input
            Case "Color"
                dr = clasq.retDatareader("select * from tb_color where color='" & txtnama.Text & "'")
                If dr.Read Then
                    output = "Color Used"
                Else
                    output = clasq.insertQuery("insert into tb_color values('" & _
                                 txtkode.Text & "','" & txtnama.Text & "') on duplicate key update color='" & _
                                 txtnama.Text & "'")
                End If
            Case "Category"
                dr = clasq.retDatareader("select * from tb_itemkategori where kategori='" & txtnama.Text & "'")
                If dr.Read Then
                    output = "Category Used"
                Else
                    output = clasq.insertQuery("insert into tb_itemkategori values('" & _
                                 txtkode.Text & "','" & txtnama.Text & "') on duplicate key update kategori='" & _
                                 txtnama.Text & "'")
                End If 
        End Select
        Return output
    End Function

    Public Sub getGridCase(input As String)
        Select Case input
            Case "Color"
                DataGridView1.DataSource = clasg.loadAllData("Kode as Code, Color", "tb_color", "kode")
            Case "Category"
                DataGridView1.DataSource = clasg.loadAllData("Kode as Code, Kategori as Category", "tb_itemkategori", "kode")
        End Select
    End Sub
    Public Sub autoFill(input As String)
        Select Case input
            Case "Color"
                dr = clasq.retDatareader("select kode from tb_color order by kode desc limit 1")
                If dr.Read() Then
                    txtkode.Text = (Integer.Parse(dr(0).ToString) + 1).ToString
                End If
            Case "Category"
                dr = clasq.retDatareader("select kode from tb_itemkategori order by kode desc limit 1")
                If dr.Read() Then
                    txtkode.Text = (Integer.Parse(dr(0).ToString) + 1).ToString
                End If
        End Select
    End Sub

    Private Sub cekInput(input As String, value As String)
        Select Case input
            Case "Color"
                dr = clasq.retDatareader("select kode from tb_color where color='" & value & "'")
                If dr.Read() Then
                    txtkode.Text = dr(0).ToString
                End If
            Case "Category"
                dr = clasq.retDatareader("select kode from tb_itemkategori where kategori='" & value & "'")
                If dr.Read() Then
                    txtkode.Text = dr(0).ToString
                End If
        End Select
    End Sub

    Private Sub Label3_TextChanged(sender As Object, e As EventArgs) Handles Label3.TextChanged
        Me.Text = "Item " & Label3.Text
        lbCode.Text = Label3.Text & " Code"
        lbCodeDtl.Text = Label3.Text
    End Sub

    Private Sub FormColors_Category_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getGridCase(Label3.Text)
        autoFill(Label3.Text)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        MsgBox(getInsertCase(Label3.Text))
        For Each x As Control In Me.Controls
            If TypeOf x Is TextBox Then
                x.Text = ""
            End If
        Next
        FormAddProduct.Activate()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txtnama.Text = DataGridView1.CurrentRow.Cells(1).Value
        cekInput(Label3.Text, txtnama.Text)

    End Sub

    Private Sub FormColors_Category_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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