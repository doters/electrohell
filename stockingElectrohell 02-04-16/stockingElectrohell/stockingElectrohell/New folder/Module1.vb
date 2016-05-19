Imports System.Runtime.CompilerServices

Public Module MyExtensions
    <Extension()>
    Public Function ToMySql(d As Date) As String
        Return d.ToString("yyyy-MM-dd HH:mm:ss")
    End Function

    Public Function customNumber(Formats As Char, Number As Integer, Digits As Integer) As String
        Return Number.ToString().PadLeft(Digits, Formats)
    End Function

End Module
