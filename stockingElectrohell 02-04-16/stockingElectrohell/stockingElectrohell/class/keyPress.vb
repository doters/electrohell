Imports System.Reflection

Public Class keyPress
    'Save button
    'edit/update button
    'shortcut

    Public Function callForm(x As String, t As String, n As String, o As DockStyle) As Form
        For Each F As Form In MainForm.MdiChildren
            If F.Name Is x Then
                F.BringToFront()
                Return F
            End If
        Next
        Dim link As New Form
        link = (DirectCast(CreateObjectInstance(x), Form))
        link.MdiParent = MainForm
        If o <> vbNull Then
            link.Dock = o
        End If
        If t <> "" Then
            link.Controls.Find(t, True).First().Text = n
        End If
        Return link
    End Function

    Public Function CreateObjectInstance(ByVal objectName As String) As Object
        Dim obj As Object
        Try
            If objectName.LastIndexOf(".") = -1 Then
                objectName = [Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If

            obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)

        Catch ex As Exception
            obj = Nothing
        End Try
        Return obj
        End Function
End Class
