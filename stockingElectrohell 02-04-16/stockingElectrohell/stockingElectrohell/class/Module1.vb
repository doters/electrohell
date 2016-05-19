Imports System.Runtime.CompilerServices

Public Module MyExtensions
    <Extension()>
    Public Function ToMySql(d As Date) As String
        Return d.ToString("yyyy-MM-dd HH:mm:ss")
    End Function

    Public Function customNumber(Formats As Char, Number As Integer, Digits As Integer) As String
        Return Number.ToString().PadLeft(Digits, Formats)
    End Function
    Public Function numberformat(ByVal text As TextBox)
        If Len(text.Text) > 0 Then
            Try
                text.Text = FormatNumber(CDbl(text.Text), 0)
                Dim x As Integer = text.SelectionStart.ToString
                If x = 0 Then
                    text.SelectionStart = Len(text.Text)
                    text.SelectionLength = 0
                Else
                    text.SelectionStart = x
                    text.SelectionLength = 0
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
        Return text
    End Function
    Public Function gridformat(ByVal col As DataGridView, i As Integer)
        col.Columns(i).DefaultCellStyle.Format = "N2"
        Return col
    End Function

End Module
