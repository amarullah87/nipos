<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterPerkiraan
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterPerkiraan))
        Me.tvData = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'tvData
        '
        Me.tvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvData.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvData.Location = New System.Drawing.Point(0, 0)
        Me.tvData.Name = "tvData"
        Me.tvData.Size = New System.Drawing.Size(693, 535)
        Me.tvData.TabIndex = 37
        '
        'MasterPerkiraan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 535)
        Me.Controls.Add(Me.tvData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MasterPerkiraan"
        Me.Text = "Master Perkiraan"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tvData As TreeView
End Class
