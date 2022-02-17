<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TambahPembayaranHutang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TambahPembayaranHutang))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.cbCaraBayar = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNoTransaksi = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbSupplier = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtptanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaAcc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Potongan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bayar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbAkun = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.cbAkun)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.cbCaraBayar)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.txtNoTransaksi)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.cbSupplier)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.dtptanggal)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1153, 124)
        Me.PanelControl1.TabIndex = 72
        '
        'cbCaraBayar
        '
        Me.cbCaraBayar.FormattingEnabled = True
        Me.cbCaraBayar.Items.AddRange(New Object() {"Tunai", "Cek"})
        Me.cbCaraBayar.Location = New System.Drawing.Point(548, 44)
        Me.cbCaraBayar.Name = "cbCaraBayar"
        Me.cbCaraBayar.Size = New System.Drawing.Size(115, 21)
        Me.cbCaraBayar.TabIndex = 91
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(406, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 27)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Cara Bayar"
        '
        'txtNoTransaksi
        '
        Me.txtNoTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoTransaksi.Location = New System.Drawing.Point(154, 16)
        Me.txtNoTransaksi.Name = "txtNoTransaksi"
        Me.txtNoTransaksi.ReadOnly = True
        Me.txtNoTransaksi.Size = New System.Drawing.Size(229, 21)
        Me.txtNoTransaksi.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 27)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Nomor Transaksi"
        '
        'cbSupplier
        '
        Me.cbSupplier.FormattingEnabled = True
        Me.cbSupplier.Location = New System.Drawing.Point(548, 16)
        Me.cbSupplier.Name = "cbSupplier"
        Me.cbSupplier.Size = New System.Drawing.Size(229, 21)
        Me.cbSupplier.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(406, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 27)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Supplier"
        '
        'dtptanggal
        '
        Me.dtptanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptanggal.Location = New System.Drawing.Point(154, 47)
        Me.dtptanggal.Name = "dtptanggal"
        Me.dtptanggal.Size = New System.Drawing.Size(140, 21)
        Me.dtptanggal.TabIndex = 72
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 27)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Tanggal"
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(108, 15)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 46
        Me.btnBatal.Text = "Batal"
        '
        'btnSimpan
        '
        Me.btnSimpan.ImageOptions.Image = CType(resources.GetObject("btnSimpan.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(12, 15)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 45
        Me.btnSimpan.Text = "Simpan"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(204, 15)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 44
        Me.btnTutup.Text = "Tutup"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btnBatal)
        Me.PanelControl2.Controls.Add(Me.btnSimpan)
        Me.PanelControl2.Controls.Add(Me.btnTutup)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 642)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1153, 64)
        Me.PanelControl2.TabIndex = 73
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Keterangan, Me.NamaAcc, Me.Debet, Me.Kredit, Me.Potongan, Me.Total, Me.Bayar})
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(0, 124)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(1153, 518)
        Me.DGV.TabIndex = 76
        '
        'Keterangan
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Keterangan.DefaultCellStyle = DataGridViewCellStyle7
        Me.Keterangan.HeaderText = "No Transaksi"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.ReadOnly = True
        '
        'NamaAcc
        '
        Me.NamaAcc.HeaderText = "Tanggal"
        Me.NamaAcc.Name = "NamaAcc"
        '
        'Debet
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Debet.DefaultCellStyle = DataGridViewCellStyle8
        Me.Debet.HeaderText = "Tanggal JT"
        Me.Debet.Name = "Debet"
        Me.Debet.ReadOnly = True
        '
        'Kredit
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.Format = "C0"
        DataGridViewCellStyle9.NullValue = "0"
        Me.Kredit.DefaultCellStyle = DataGridViewCellStyle9
        Me.Kredit.HeaderText = "Sisa"
        Me.Kredit.Name = "Kredit"
        Me.Kredit.ReadOnly = True
        '
        'Potongan
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "C0"
        DataGridViewCellStyle10.NullValue = "0"
        Me.Potongan.DefaultCellStyle = DataGridViewCellStyle10
        Me.Potongan.HeaderText = "Potongan"
        Me.Potongan.Name = "Potongan"
        '
        'Total
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C0"
        DataGridViewCellStyle11.NullValue = "0"
        Me.Total.DefaultCellStyle = DataGridViewCellStyle11
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'Bayar
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "C0"
        DataGridViewCellStyle12.NullValue = "0"
        Me.Bayar.DefaultCellStyle = DataGridViewCellStyle12
        Me.Bayar.HeaderText = "Bayar"
        Me.Bayar.Name = "Bayar"
        '
        'cbAkun
        '
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.Location = New System.Drawing.Point(548, 74)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(229, 21)
        Me.cbAkun.TabIndex = 93
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(406, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 27)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Kode Akun"
        '
        'TambahPembayaranHutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 706)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TambahPembayaranHutang"
        Me.Text = "Tambah Pembayaran Hutang"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cbCaraBayar As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNoTransaksi As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbSupplier As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtptanggal As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DGV As DataGridView
    Friend WithEvents Keterangan As DataGridViewTextBoxColumn
    Friend WithEvents NamaAcc As DataGridViewTextBoxColumn
    Friend WithEvents Debet As DataGridViewTextBoxColumn
    Friend WithEvents Kredit As DataGridViewTextBoxColumn
    Friend WithEvents Potongan As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Bayar As DataGridViewTextBoxColumn
    Friend WithEvents cbAkun As ComboBox
    Friend WithEvents Label5 As Label
End Class
