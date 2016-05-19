<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormColors_Category
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
        Me.lbCodeDtl = New System.Windows.Forms.Label()
        Me.lbCode = New System.Windows.Forms.Label()
        Me.txtnama = New System.Windows.Forms.TextBox()
        Me.txtkode = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbCodeDtl
        '
        Me.lbCodeDtl.AutoSize = True
        Me.lbCodeDtl.Location = New System.Drawing.Point(12, 72)
        Me.lbCodeDtl.Name = "lbCodeDtl"
        Me.lbCodeDtl.Size = New System.Drawing.Size(16, 13)
        Me.lbCodeDtl.TabIndex = 97
        Me.lbCodeDtl.Text = "..."
        '
        'lbCode
        '
        Me.lbCode.AutoSize = True
        Me.lbCode.Location = New System.Drawing.Point(12, 46)
        Me.lbCode.Name = "lbCode"
        Me.lbCode.Size = New System.Drawing.Size(16, 13)
        Me.lbCode.TabIndex = 96
        Me.lbCode.Text = "..."
        '
        'txtnama
        '
        Me.txtnama.Location = New System.Drawing.Point(92, 69)
        Me.txtnama.Name = "txtnama"
        Me.txtnama.Size = New System.Drawing.Size(184, 20)
        Me.txtnama.TabIndex = 1
        '
        'txtkode
        '
        Me.txtkode.Enabled = False
        Me.txtkode.Location = New System.Drawing.Point(92, 43)
        Me.txtkode.Name = "txtkode"
        Me.txtkode.Size = New System.Drawing.Size(184, 20)
        Me.txtkode.TabIndex = 0
        Me.txtkode.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 123)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(355, 196)
        Me.DataGridView1.TabIndex = 98
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(338, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 55)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Tittle"
        Me.Label3.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(378, 24)
        Me.MenuStrip1.TabIndex = 100
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'FormColors_Category
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(378, 331)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lbCodeDtl)
        Me.Controls.Add(Me.lbCode)
        Me.Controls.Add(Me.txtnama)
        Me.Controls.Add(Me.txtkode)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormColors_Category"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "..."
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbCodeDtl As System.Windows.Forms.Label
    Friend WithEvents lbCode As System.Windows.Forms.Label
    Friend WithEvents txtnama As System.Windows.Forms.TextBox
    Friend WithEvents txtkode As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
