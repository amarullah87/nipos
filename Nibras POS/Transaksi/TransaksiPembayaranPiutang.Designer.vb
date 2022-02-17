<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransaksiPembayaranPiutang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransaksiPembayaranPiutang))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbAkun = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbCaraBayar = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNoTransaksi = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtptanggal = New System.Windows.Forms.DateTimePicker()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.lblDepositHide = New System.Windows.Forms.Label()
        Me.panelDeposit = New DevExpress.XtraEditors.PanelControl()
        Me.lblDeposit = New System.Windows.Forms.Label()
        Me.lookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.checkAgen = New System.Windows.Forms.CheckBox()
        Me.cbSupplier = New System.Windows.Forms.ComboBox()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaAcc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Potongan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bayar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoTransaksi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.panelDeposit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelDeposit.SuspendLayout()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Keterangan, Me.NamaAcc, Me.Debet, Me.Kredit, Me.Potongan, Me.Total, Me.Bayar, Me.NoTransaksi})
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(0, 124)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(1153, 518)
        Me.DGV.TabIndex = 79
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
        Me.PanelControl2.TabIndex = 78
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
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 27)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Tanggal"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(406, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 27)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Member/ Pelanggan"
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
        'cbCaraBayar
        '
        Me.cbCaraBayar.FormattingEnabled = True
        Me.cbCaraBayar.Items.AddRange(New Object() {"Tunai", "Deposit", "Cek"})
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
        Me.txtNoTransaksi.Location = New System.Drawing.Point(154, 18)
        Me.txtNoTransaksi.Name = "txtNoTransaksi"
        Me.txtNoTransaksi.ReadOnly = True
        Me.txtNoTransaksi.Size = New System.Drawing.Size(229, 22)
        Me.txtNoTransaksi.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 27)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Nomor Transaksi"
        '
        'dtptanggal
        '
        Me.dtptanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptanggal.Location = New System.Drawing.Point(154, 47)
        Me.dtptanggal.Name = "dtptanggal"
        Me.dtptanggal.Size = New System.Drawing.Size(140, 22)
        Me.dtptanggal.TabIndex = 72
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.lblDepositHide)
        Me.PanelControl1.Controls.Add(Me.panelDeposit)
        Me.PanelControl1.Controls.Add(Me.lookUpEdit)
        Me.PanelControl1.Controls.Add(Me.checkAgen)
        Me.PanelControl1.Controls.Add(Me.cbSupplier)
        Me.PanelControl1.Controls.Add(Me.cbAkun)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.cbCaraBayar)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.txtNoTransaksi)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.dtptanggal)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1153, 124)
        Me.PanelControl1.TabIndex = 77
        '
        'lblDepositHide
        '
        Me.lblDepositHide.Location = New System.Drawing.Point(1016, 38)
        Me.lblDepositHide.Name = "lblDepositHide"
        Me.lblDepositHide.Size = New System.Drawing.Size(98, 27)
        Me.lblDepositHide.TabIndex = 98
        Me.lblDepositHide.Visible = False
        '
        'panelDeposit
        '
        Me.panelDeposit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelDeposit.Controls.Add(Me.lblDeposit)
        Me.panelDeposit.Location = New System.Drawing.Point(783, 42)
        Me.panelDeposit.Name = "panelDeposit"
        Me.panelDeposit.Size = New System.Drawing.Size(227, 53)
        Me.panelDeposit.TabIndex = 97
        '
        'lblDeposit
        '
        Me.lblDeposit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDeposit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeposit.Location = New System.Drawing.Point(0, 0)
        Me.lblDeposit.Name = "lblDeposit"
        Me.lblDeposit.Size = New System.Drawing.Size(227, 53)
        Me.lblDeposit.TabIndex = 91
        Me.lblDeposit.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lookUpEdit
        '
        Me.lookUpEdit.Location = New System.Drawing.Point(548, 14)
        Me.lookUpEdit.Name = "lookUpEdit"
        Me.lookUpEdit.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lookUpEdit.Properties.Appearance.Options.UseFont = True
        Me.lookUpEdit.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.Transparent
        Me.lookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lookUpEdit.Properties.AppearanceDropDown.Options.UseBorderColor = True
        Me.lookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.lookUpEdit.Properties.AppearanceDropDownHeader.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lookUpEdit.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.lookUpEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.lookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lookUpEdit.Properties.DropDownRows = 10
        Me.lookUpEdit.Properties.NullText = ""
        Me.lookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.lookUpEdit.Size = New System.Drawing.Size(462, 24)
        Me.lookUpEdit.TabIndex = 96
        '
        'checkAgen
        '
        Me.checkAgen.AutoSize = True
        Me.checkAgen.Location = New System.Drawing.Point(1016, 18)
        Me.checkAgen.Name = "checkAgen"
        Me.checkAgen.Size = New System.Drawing.Size(67, 17)
        Me.checkAgen.TabIndex = 95
        Me.checkAgen.Text = "List NHs"
        Me.checkAgen.UseVisualStyleBackColor = True
        '
        'cbSupplier
        '
        Me.cbSupplier.FormattingEnabled = True
        Me.cbSupplier.Location = New System.Drawing.Point(548, 97)
        Me.cbSupplier.Name = "cbSupplier"
        Me.cbSupplier.Size = New System.Drawing.Size(270, 21)
        Me.cbSupplier.TabIndex = 94
        Me.cbSupplier.Visible = False
        '
        'Keterangan
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Keterangan.DefaultCellStyle = DataGridViewCellStyle1
        Me.Keterangan.HeaderText = "No Faktur"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.ReadOnly = True
        '
        'NamaAcc
        '
        DataGridViewCellStyle2.Format = "D"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.NamaAcc.DefaultCellStyle = DataGridViewCellStyle2
        Me.NamaAcc.HeaderText = "Tanggal"
        Me.NamaAcc.Name = "NamaAcc"
        '
        'Debet
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.Format = "D"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Debet.DefaultCellStyle = DataGridViewCellStyle3
        Me.Debet.HeaderText = "Tanggal JT"
        Me.Debet.Name = "Debet"
        Me.Debet.ReadOnly = True
        '
        'Kredit
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.Format = "C0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.Kredit.DefaultCellStyle = DataGridViewCellStyle4
        Me.Kredit.HeaderText = "Sisa"
        Me.Kredit.Name = "Kredit"
        Me.Kredit.ReadOnly = True
        '
        'Potongan
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.Potongan.DefaultCellStyle = DataGridViewCellStyle5
        Me.Potongan.HeaderText = "Potongan"
        Me.Potongan.Name = "Potongan"
        '
        'Total
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.Total.DefaultCellStyle = DataGridViewCellStyle6
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'Bayar
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.Bayar.DefaultCellStyle = DataGridViewCellStyle7
        Me.Bayar.HeaderText = "Bayar"
        Me.Bayar.Name = "Bayar"
        '
        'NoTransaksi
        '
        Me.NoTransaksi.HeaderText = "No Transaksi"
        Me.NoTransaksi.Name = "NoTransaksi"
        Me.NoTransaksi.Visible = False
        '
        'TransaksiPembayaranPiutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 706)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TransaksiPembayaranPiutang"
        Me.Text = "Transaksi Pembayaran Piutang"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.panelDeposit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelDeposit.ResumeLayout(False)
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV As DataGridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbAkun As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbCaraBayar As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNoTransaksi As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtptanggal As DateTimePicker
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents checkAgen As CheckBox
    Friend WithEvents cbSupplier As ComboBox
    Friend WithEvents lookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents panelDeposit As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblDeposit As Label
    Friend WithEvents lblDepositHide As Label
    Friend WithEvents Keterangan As DataGridViewTextBoxColumn
    Friend WithEvents NamaAcc As DataGridViewTextBoxColumn
    Friend WithEvents Debet As DataGridViewTextBoxColumn
    Friend WithEvents Kredit As DataGridViewTextBoxColumn
    Friend WithEvents Potongan As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Bayar As DataGridViewTextBoxColumn
    Friend WithEvents NoTransaksi As DataGridViewTextBoxColumn
End Class
