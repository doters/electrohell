<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.txStatus = New System.Windows.Forms.TextBox()
        Me.txSession = New System.Windows.Forms.TextBox()
        Me.txUsername = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'txStatus
        '
        Me.txStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txStatus.Enabled = False
        Me.txStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txStatus.Location = New System.Drawing.Point(0, 434)
        Me.txStatus.Name = "txStatus"
        Me.txStatus.Size = New System.Drawing.Size(632, 19)
        Me.txStatus.TabIndex = 9
        Me.txStatus.Text = "User : -"
        '
        'txSession
        '
        Me.txSession.Location = New System.Drawing.Point(106, 181)
        Me.txSession.Name = "txSession"
        Me.txSession.Size = New System.Drawing.Size(100, 20)
        Me.txSession.TabIndex = 11
        Me.txSession.Visible = False
        '
        'txUsername
        '
        Me.txUsername.Location = New System.Drawing.Point(106, 207)
        Me.txUsername.Name = "txUsername"
        Me.txUsername.Size = New System.Drawing.Size(100, 20)
        Me.txUsername.TabIndex = 13
        Me.txUsername.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ProgressBar1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ProgressBar1.Location = New System.Drawing.Point(453, 433)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(179, 19)
        Me.ProgressBar1.TabIndex = 15
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txUsername)
        Me.Controls.Add(Me.txSession)
        Me.Controls.Add(Me.txStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IsMdiContainer = True
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Stocking Home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents txStatus As System.Windows.Forms.TextBox
    Friend WithEvents txSession As System.Windows.Forms.TextBox
    Friend WithEvents txUsername As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class
