<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportSaldoHutang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportSaldoHutang))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.imgLoading = New System.Windows.Forms.PictureBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
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
        Me.cbAkun = New System.Windows.Forms.ComboBox()
        Me.dtptanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBrowse = New System.Windows.Forms.TextBox()
        Me.txtNoTransaksi = New System.Windows.Forms.TextBox()
        CType(Me.imgLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'imgLoading
        '
        Me.imgLoading.BackColor = System.Drawing.Color.Transparent
        Me.imgLoading.Location = New System.Drawing.Point(605, 240)
        Me.imgLoading.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.imgLoading.Name = "imgLoading"
        Me.imgLoading.Size = New System.Drawing.Size(117, 123)
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
        Me.DGV.Location = New System.Drawing.Point(164, 20)
        Me.DGV.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(274, 238)
        Me.DGV.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.imgLoading)
        Me.GroupBox2.Controls.Add(Me.DGV)
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 341)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(441, 262)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data Excel"
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(3, 20)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(161, 238)
        Me.ListBox1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(352, 277)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(105, 43)
        Me.SimpleButton1.TabIndex = 109
        Me.SimpleButton1.Text = "Contoh File"
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(128, 277)
        Me.btnBatal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(105, 43)
        Me.btnBatal.TabIndex = 108
        Me.btnBatal.Text = "Batal"
        '
        'btnImport
        '
        Me.btnImport.ImageOptions.Image = CType(resources.GetObject("btnImport.ImageOptions.Image"), System.Drawing.Image)
        Me.btnImport.Location = New System.Drawing.Point(16, 277)
        Me.btnImport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(105, 43)
        Me.btnImport.TabIndex = 107
        Me.btnImport.Text = "PROSES"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(240, 277)
        Me.btnTutup.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(105, 43)
        Me.btnTutup.TabIndex = 106
        Me.btnTutup.Text = "Tutup"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(370, 228)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(87, 28)
        Me.btnBrowse.TabIndex = 105
        Me.btnBrowse.Text = "Browse"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(21, 33)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "2."
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 33)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "1."
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(40, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(460, 33)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Kolom-kolom dalam File Excel tidak boleh di Hide atau di Merge"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(40, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(460, 33)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "Kolom pada Excel harus sama dan sesuai dengan Format Program" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Format file Excel d" &
    "apat diambil dari tombol Contoh File dibawah ini."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(460, 33)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Beberapa Hal Penting yang harus diketahui adalah:"
        '
        'cbAkun
        '
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.Items.AddRange(New Object() {"2-1101/HUTANG USAHA"})
        Me.cbAkun.Location = New System.Drawing.Point(68, 327)
        Me.cbAkun.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(277, 24)
        Me.cbAkun.TabIndex = 97
        Me.cbAkun.Visible = False
        '
        'dtptanggal
        '
        Me.dtptanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptanggal.Location = New System.Drawing.Point(180, 142)
        Me.dtptanggal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtptanggal.Name = "dtptanggal"
        Me.dtptanggal.Size = New System.Drawing.Size(165, 23)
        Me.dtptanggal.TabIndex = 94
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 33)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Tanggal"
        '
        'txtBrowse
        '
        Me.txtBrowse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBrowse.Location = New System.Drawing.Point(17, 230)
        Me.txtBrowse.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBrowse.Name = "txtBrowse"
        Me.txtBrowse.ReadOnly = True
        Me.txtBrowse.Size = New System.Drawing.Size(345, 23)
        Me.txtBrowse.TabIndex = 93
        '
        'txtNoTransaksi
        '
        Me.txtNoTransaksi.Location = New System.Drawing.Point(192, 108)
        Me.txtNoTransaksi.Name = "txtNoTransaksi"
        Me.txtNoTransaksi.Size = New System.Drawing.Size(170, 23)
        Me.txtNoTransaksi.TabIndex = 111
        Me.txtNoTransaksi.Visible = False
        '
        'ImportSaldoHutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 337)
        Me.Controls.Add(Me.txtNoTransaksi)
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
        Me.Controls.Add(Me.cbAkun)
        Me.Controls.Add(Me.dtptanggal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBrowse)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "ImportSaldoHutang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Saldo Awal Hutang"
        CType(Me.imgLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents imgLoading As PictureBox
    Friend WithEvents DGV As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
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
    Friend WithEvents cbAkun As ComboBox
    Friend WithEvents dtptanggal As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBrowse As TextBox
    Friend WithEvents txtNoTransaksi As TextBox
End Class
