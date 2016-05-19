<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.button3 = New System.Windows.Forms.Button()
        Me.txDatabase = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.txPass = New System.Windows.Forms.TextBox()
        Me.txUser = New System.Windows.Forms.TextBox()
        Me.txServer = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(542, 79)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(75, 23)
        Me.button3.TabIndex = 31
        Me.button3.Text = "Cancel"
        Me.button3.UseVisualStyleBackColor = True
        '
        'txDatabase
        '
        Me.txDatabase.Location = New System.Drawing.Point(133, 47)
        Me.txDatabase.Name = "txDatabase"
        Me.txDatabase.Size = New System.Drawing.Size(194, 20)
        Me.txDatabase.TabIndex = 1
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(11, 50)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(86, 13)
        Me.label4.TabIndex = 29
        Me.label4.Text = "database name :"
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(399, 50)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(137, 23)
        Me.button2.TabIndex = 28
        Me.button2.Text = "Test Connection"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(542, 50)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 27
        Me.button1.Text = "Save"
        Me.button1.UseVisualStyleBackColor = True
        '
        'txPass
        '
        Me.txPass.Location = New System.Drawing.Point(133, 102)
        Me.txPass.Name = "txPass"
        Me.txPass.Size = New System.Drawing.Size(194, 20)
        Me.txPass.TabIndex = 26
        '
        'txUser
        '
        Me.txUser.Location = New System.Drawing.Point(133, 74)
        Me.txUser.Name = "txUser"
        Me.txUser.Size = New System.Drawing.Size(194, 20)
        Me.txUser.TabIndex = 25
        '
        'txServer
        '
        Me.txServer.Location = New System.Drawing.Point(133, 21)
        Me.txServer.Name = "txServer"
        Me.txServer.Size = New System.Drawing.Size(484, 20)
        Me.txServer.TabIndex = 0
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(11, 105)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(105, 13)
        Me.label3.TabIndex = 23
        Me.label3.Text = "database password :"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(11, 77)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(88, 13)
        Me.label2.TabIndex = 22
        Me.label2.Text = "database admin :"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(11, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(89, 13)
        Me.label1.TabIndex = 21
        Me.label1.Text = "database server :"
        '
        'setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 135)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.txDatabase)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.txPass)
        Me.Controls.Add(Me.txUser)
        Me.Controls.Add(Me.txServer)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "setting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "setting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents txDatabase As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents txPass As System.Windows.Forms.TextBox
    Private WithEvents txUser As System.Windows.Forms.TextBox
    Private WithEvents txServer As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
