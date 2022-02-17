<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportSupplier
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportSupplier))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.imgLoading = New System.Windows.Forms.PictureBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
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
        Me.GroupBox2.SuspendLayout()
        CType(Me.imgLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.imgLoading)
        Me.GroupBox2.Controls.Add(Me.DGV)
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 277)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(378, 213)
        Me.GroupBox2.TabIndex = 126
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data Excel"
        '
        'imgLoading
        '
        Me.imgLoading.BackColor = System.Drawing.Color.Transparent
        Me.imgLoading.Location = New System.Drawing.Point(519, 195)
        Me.imgLoading.Name = "imgLoading"
        Me.imgLoading.Size = New System.Drawing.Size(100, 100)
        Me.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLoading.TabIndex = 19
        Me.imgLoading.TabStop = False
        Me.imgLoading.Visible = False
        '
        'DGV
        '
        Me.DGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.Location = New System.Drawing.Point(142, 17)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(233, 193)
        Me.DGV.TabIndex = 1
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(3, 17)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(139, 193)
        Me.ListBox1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(303, 166)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(90, 35)
        Me.SimpleButton1.TabIndex = 125
        Me.SimpleButton1.Text = "Contoh File"
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(111, 166)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 124
        Me.btnBatal.Text = "Batal"
        '
        'btnImport
        '
        Me.btnImport.ImageOptions.Image = CType(resources.GetObject("btnImport.ImageOptions.Image"), System.Drawing.Image)
        Me.btnImport.Location = New System.Drawing.Point(15, 166)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(90, 35)
        Me.btnImport.TabIndex = 123
        Me.btnImport.Text = "PROSES"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(207, 166)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 122
        Me.btnTutup.Text = "Tutup"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(318, 126)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 121
        Me.btnBrowse.Text = "Browse"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(13, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 27)
        Me.Label8.TabIndex = 120
        Me.Label8.Text = "2."
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 27)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "1."
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(34, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(394, 27)
        Me.Label6.TabIndex = 118
        Me.Label6.Text = "Kolom-kolom dalam File Excel tidak boleh di Hide atau di Merge"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(34, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(394, 27)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "Kolom pada Excel harus sama dan sesuai dengan Format Program" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Format file Excel d" &
    "apat diambil dari tombol Contoh File dibawah ini."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(34, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(394, 27)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "Beberapa Hal Penting yang harus diketahui adalah:"
        '
        'txtBrowse
        '
        Me.txtBrowse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBrowse.Location = New System.Drawing.Point(16, 128)
        Me.txtBrowse.Name = "txtBrowse"
        Me.txtBrowse.ReadOnly = True
        Me.txtBrowse.Size = New System.Drawing.Size(296, 21)
        Me.txtBrowse.TabIndex = 111
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ImportSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 274)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnTutup)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBrowse)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ImportSupplier"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Supplier"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.imgLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents imgLoading As PictureBox
    Friend WithEvents DGV As DataGridView
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
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
End Class
