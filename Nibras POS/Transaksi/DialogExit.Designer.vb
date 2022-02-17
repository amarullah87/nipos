<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DialogExit
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogExit))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnYes = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNo = New DevExpress.XtraEditors.SimpleButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 114)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(534, 20)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Apakah anda akan melakukan Backup Database Terlebih dahulu sebelum keluar?"
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(142, 148)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(111, 23)
        Me.btnYes.TabIndex = 1
        Me.btnYes.Text = "Ya, Backup"
        '
        'btnNo
        '
        Me.btnNo.Location = New System.Drawing.Point(290, 148)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(111, 23)
        Me.btnNo.TabIndex = 2
        Me.btnNo.Text = "Tidak, Tutup saja"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(230, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 79)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'DialogExit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 183)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.LabelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogExit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnYes As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents PictureBox1 As PictureBox
End Class
