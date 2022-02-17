<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RestoreDatabase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RestoreDatabase))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImport = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBrowse = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(38, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 27)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "XAMPP/MySQL Location : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnImport
        '
        Me.btnImport.ImageOptions.Image = CType(resources.GetObject("btnImport.ImageOptions.Image"), System.Drawing.Image)
        Me.btnImport.Location = New System.Drawing.Point(185, 171)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(95, 28)
        Me.btnImport.TabIndex = 148
        Me.btnImport.Text = "Restore"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(286, 171)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(86, 28)
        Me.btnTutup.TabIndex = 147
        Me.btnTutup.Text = "Tutup"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(391, 109)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(70, 23)
        Me.btnBrowse.TabIndex = 146
        Me.btnBrowse.Text = "Browse"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(46, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 27)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "2."
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(45, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 27)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "1."
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(67, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(394, 27)
        Me.Label6.TabIndex = 143
        Me.Label6.Text = "Jika lokasi XAMPP tidak sesuai dengan yang tertera di bawah, silahkan hubungi IT " &
    "Nibras Pusat untuk dibantu pengaturannya."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(67, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(394, 27)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "Pastikan Lokasi XAMPP sesuai dengan hasil instalasi pada komputer anda."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(67, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(394, 27)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Beberapa Hal Penting yang harus diketahui adalah:"
        '
        'txtBrowse
        '
        Me.txtBrowse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBrowse.Location = New System.Drawing.Point(185, 111)
        Me.txtBrowse.Name = "txtBrowse"
        Me.txtBrowse.Size = New System.Drawing.Size(200, 21)
        Me.txtBrowse.TabIndex = 140
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(67, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(394, 27)
        Me.Label5.TabIndex = 151
        Me.Label5.Text = "Lokasi XAMPP/ MySQL secara default berada di: C:\xampp\mysql\bin"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(46, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 27)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "3."
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(67, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 27)
        Me.Label9.TabIndex = 152
        Me.Label9.Text = "Database :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(185, 138)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(100, 21)
        Me.txtDatabase.TabIndex = 153
        Me.txtDatabase.Text = "db_pos"
        '
        'RestoreDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 207)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnTutup)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBrowse)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RestoreDatabase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restore Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBrowse As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDatabase As TextBox
End Class
