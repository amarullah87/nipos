<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransaksiItemMasuk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransaksiItemMasuk))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.cbUbahHpp = New System.Windows.Forms.CheckBox()
        Me.txtNoTransaksi = New System.Windows.Forms.TextBox()
        Me.cbAkun = New System.Windows.Forms.ComboBox()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.txtnofaktur = New System.Windows.Forms.TextBox()
        Me.dtptanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.txtTotalQty = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.txtTotalHarga = New System.Windows.Forms.Label()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Satuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jenis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jumlah = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.cbUbahHpp)
        Me.PanelControl1.Controls.Add(Me.txtNoTransaksi)
        Me.PanelControl1.Controls.Add(Me.cbAkun)
        Me.PanelControl1.Controls.Add(Me.txtKeterangan)
        Me.PanelControl1.Controls.Add(Me.txtnofaktur)
        Me.PanelControl1.Controls.Add(Me.dtptanggal)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(867, 85)
        Me.PanelControl1.TabIndex = 0
        '
        'cbUbahHpp
        '
        Me.cbUbahHpp.AutoSize = True
        Me.cbUbahHpp.Location = New System.Drawing.Point(520, 46)
        Me.cbUbahHpp.Name = "cbUbahHpp"
        Me.cbUbahHpp.Size = New System.Drawing.Size(77, 17)
        Me.cbUbahHpp.TabIndex = 28
        Me.cbUbahHpp.Text = "Ubah HPP"
        Me.cbUbahHpp.UseVisualStyleBackColor = True
        '
        'txtNoTransaksi
        '
        Me.txtNoTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoTransaksi.Location = New System.Drawing.Point(657, 16)
        Me.txtNoTransaksi.Name = "txtNoTransaksi"
        Me.txtNoTransaksi.Size = New System.Drawing.Size(104, 22)
        Me.txtNoTransaksi.TabIndex = 26
        Me.txtNoTransaksi.Visible = False
        '
        'cbAkun
        '
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.Location = New System.Drawing.Point(806, 17)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(49, 21)
        Me.cbAkun.TabIndex = 25
        Me.cbAkun.Visible = False
        '
        'txtKeterangan
        '
        Me.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKeterangan.Location = New System.Drawing.Point(520, 16)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(241, 22)
        Me.txtKeterangan.TabIndex = 24
        '
        'txtnofaktur
        '
        Me.txtnofaktur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnofaktur.Location = New System.Drawing.Point(135, 16)
        Me.txtnofaktur.Name = "txtnofaktur"
        Me.txtnofaktur.ReadOnly = True
        Me.txtnofaktur.Size = New System.Drawing.Size(166, 22)
        Me.txtnofaktur.TabIndex = 18
        '
        'dtptanggal
        '
        Me.dtptanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptanggal.Location = New System.Drawing.Point(135, 47)
        Me.dtptanggal.Name = "dtptanggal"
        Me.dtptanggal.Size = New System.Drawing.Size(116, 22)
        Me.dtptanggal.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(803, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 23)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Kode Akun"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(395, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 23)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Keterangan"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 23)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Tanggal"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 23)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "No Transaksi"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.txtTotalQty)
        Me.PanelControl2.Controls.Add(Me.txtTotal)
        Me.PanelControl2.Controls.Add(Me.txtTotalHarga)
        Me.PanelControl2.Controls.Add(Me.btnBatal)
        Me.PanelControl2.Controls.Add(Me.btnSimpan)
        Me.PanelControl2.Controls.Add(Me.btnTutup)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 507)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(867, 61)
        Me.PanelControl2.TabIndex = 1
        '
        'txtTotalQty
        '
        Me.txtTotalQty.AutoSize = True
        Me.txtTotalQty.Location = New System.Drawing.Point(441, 32)
        Me.txtTotalQty.Name = "txtTotalQty"
        Me.txtTotalQty.Size = New System.Drawing.Size(0, 13)
        Me.txtTotalQty.TabIndex = 49
        Me.txtTotalQty.Visible = False
        '
        'txtTotal
        '
        Me.txtTotal.AutoSize = True
        Me.txtTotal.Location = New System.Drawing.Point(433, 24)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(0, 13)
        Me.txtTotal.TabIndex = 48
        Me.txtTotal.Visible = False
        '
        'txtTotalHarga
        '
        Me.txtTotalHarga.AutoSize = True
        Me.txtTotalHarga.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtTotalHarga.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHarga.Location = New System.Drawing.Point(797, 2)
        Me.txtTotalHarga.Name = "txtTotalHarga"
        Me.txtTotalHarga.Size = New System.Drawing.Size(68, 33)
        Me.txtTotalHarga.TabIndex = 47
        Me.txtTotalHarga.Text = "Total"
        Me.txtTotalHarga.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(108, 13)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 46
        Me.btnBatal.Text = "Batal"
        '
        'btnSimpan
        '
        Me.btnSimpan.ImageOptions.Image = CType(resources.GetObject("btnSimpan.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(12, 13)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 45
        Me.btnSimpan.Text = "Simpan"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(204, 13)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 44
        Me.btnTutup.Text = "Tutup"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.txtBarcode)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 85)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(867, 61)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Barcode"
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(15, 25)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(293, 22)
        Me.txtBarcode.TabIndex = 1
        '
        'DGV
        '
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Kode, Me.Nama, Me.Satuan, Me.Jenis, Me.Harga, Me.Jumlah, Me.Subtotal})
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(0, 146)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(867, 361)
        Me.DGV.TabIndex = 7
        '
        'Kode
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kode.DefaultCellStyle = DataGridViewCellStyle1
        Me.Kode.HeaderText = "Kode Barang"
        Me.Kode.Name = "Kode"
        '
        'Nama
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nama.DefaultCellStyle = DataGridViewCellStyle2
        Me.Nama.HeaderText = "Nama Barang"
        Me.Nama.Name = "Nama"
        '
        'Satuan
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Satuan.DefaultCellStyle = DataGridViewCellStyle3
        Me.Satuan.HeaderText = "Satuan"
        Me.Satuan.Name = "Satuan"
        '
        'Jenis
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Jenis.DefaultCellStyle = DataGridViewCellStyle4
        Me.Jenis.HeaderText = "Jenis"
        Me.Jenis.Name = "Jenis"
        '
        'Harga
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.Format = "C0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.Harga.DefaultCellStyle = DataGridViewCellStyle5
        Me.Harga.HeaderText = "Harga"
        Me.Harga.Name = "Harga"
        '
        'Jumlah
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.Jumlah.DefaultCellStyle = DataGridViewCellStyle6
        Me.Jumlah.HeaderText = "Jumlah"
        Me.Jumlah.Name = "Jumlah"
        Me.Jumlah.ToolTipText = "Tekan Enter/ TAB untuk mengubah"
        '
        'Subtotal
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.Format = "C0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.Subtotal.DefaultCellStyle = DataGridViewCellStyle7
        Me.Subtotal.HeaderText = "Subtotal"
        Me.Subtotal.Name = "Subtotal"
        Me.Subtotal.ReadOnly = True
        '
        'TransaksiItemMasuk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 568)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TransaksiItemMasuk"
        Me.Text = "Tambah Item Masuk"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cbAkun As ComboBox
    Friend WithEvents txtKeterangan As TextBox
    Friend WithEvents txtnofaktur As TextBox
    Friend WithEvents dtptanggal As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents DGV As DataGridView
    Friend WithEvents Kode As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Satuan As DataGridViewTextBoxColumn
    Friend WithEvents Jenis As DataGridViewTextBoxColumn
    Friend WithEvents Harga As DataGridViewTextBoxColumn
    Friend WithEvents Jumlah As DataGridViewTextBoxColumn
    Friend WithEvents Subtotal As DataGridViewTextBoxColumn
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtTotalHarga As Label
    Friend WithEvents txtTotal As Label
    Friend WithEvents txtTotalQty As Label
    Friend WithEvents txtNoTransaksi As TextBox
    Friend WithEvents cbUbahHpp As CheckBox
End Class
