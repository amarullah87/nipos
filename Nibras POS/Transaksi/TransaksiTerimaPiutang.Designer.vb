<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransaksiTerimaPiutang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransaksiTerimaPiutang))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbAkun = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnlnomorterima = New System.Windows.Forms.Label()
        Me.dtptanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbltanggaljual = New System.Windows.Forms.Label()
        Me.lblkodecustomer = New System.Windows.Forms.Label()
        Me.lblnamacustomer = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.txtjumlahterima = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbltotalharga = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbljatuhtempo = New System.Windows.Forms.Label()
        Me.txttempohari = New System.Windows.Forms.TextBox()
        Me.lblsisapiutang = New System.Windows.Forms.Label()
        Me.lblcarajual = New System.Windows.Forms.Label()
        Me.txtdibayar = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.LookUpEditFaktur = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditFaktur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LookUpEditFaktur)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.lookUpEdit)
        Me.PanelControl1.Controls.Add(Me.txtKeterangan)
        Me.PanelControl1.Controls.Add(Me.Label8)
        Me.PanelControl1.Controls.Add(Me.cbAkun)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.lnlnomorterima)
        Me.PanelControl1.Controls.Add(Me.dtptanggal)
        Me.PanelControl1.Controls.Add(Me.Label20)
        Me.PanelControl1.Controls.Add(Me.Label14)
        Me.PanelControl1.Controls.Add(Me.lbltanggaljual)
        Me.PanelControl1.Controls.Add(Me.lblkodecustomer)
        Me.PanelControl1.Controls.Add(Me.lblnamacustomer)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.GroupBox2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1209, 168)
        Me.PanelControl1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 23)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "No Faktur Penjualan"
        '
        'lookUpEdit
        '
        Me.lookUpEdit.Location = New System.Drawing.Point(135, 97)
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
        Me.lookUpEdit.Size = New System.Drawing.Size(206, 24)
        Me.lookUpEdit.TabIndex = 96
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(474, 128)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.ReadOnly = True
        Me.txtKeterangan.Size = New System.Drawing.Size(273, 22)
        Me.txtKeterangan.TabIndex = 74
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(351, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 23)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Keterangan"
        '
        'cbAkun
        '
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.Location = New System.Drawing.Point(135, 97)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(206, 21)
        Me.cbAkun.TabIndex = 82
        Me.cbAkun.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 23)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Kode Akun"
        '
        'lnlnomorterima
        '
        Me.lnlnomorterima.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lnlnomorterima.Location = New System.Drawing.Point(135, 71)
        Me.lnlnomorterima.Name = "lnlnomorterima"
        Me.lnlnomorterima.Size = New System.Drawing.Size(208, 23)
        Me.lnlnomorterima.TabIndex = 80
        '
        'dtptanggal
        '
        Me.dtptanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptanggal.Location = New System.Drawing.Point(135, 45)
        Me.dtptanggal.Name = "dtptanggal"
        Me.dtptanggal.Size = New System.Drawing.Size(139, 22)
        Me.dtptanggal.TabIndex = 78
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(12, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(117, 23)
        Me.Label20.TabIndex = 79
        Me.Label20.Text = "Nomor Terima"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(12, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 23)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "Tgl Terima"
        '
        'lbltanggaljual
        '
        Me.lbltanggaljual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltanggaljual.Location = New System.Drawing.Point(474, 45)
        Me.lbltanggaljual.Name = "lbltanggaljual"
        Me.lbltanggaljual.Size = New System.Drawing.Size(143, 23)
        Me.lbltanggaljual.TabIndex = 76
        '
        'lblkodecustomer
        '
        Me.lblkodecustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblkodecustomer.Location = New System.Drawing.Point(474, 71)
        Me.lblkodecustomer.Name = "lblkodecustomer"
        Me.lblkodecustomer.Size = New System.Drawing.Size(143, 23)
        Me.lblkodecustomer.TabIndex = 75
        '
        'lblnamacustomer
        '
        Me.lblnamacustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblnamacustomer.Location = New System.Drawing.Point(474, 99)
        Me.lblnamacustomer.Name = "lblnamacustomer"
        Me.lblnamacustomer.Size = New System.Drawing.Size(447, 23)
        Me.lblnamacustomer.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(351, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 23)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Nama Customer"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(351, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 23)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Kode Customer"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(350, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 23)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Tanggal Jual"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(1041, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(163, 127)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "No Faktur Penjualan"
        Me.GroupBox2.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(3, 18)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(157, 106)
        Me.ListBox1.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btnBatal)
        Me.PanelControl2.Controls.Add(Me.btnSimpan)
        Me.PanelControl2.Controls.Add(Me.btnTutup)
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 506)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1209, 100)
        Me.PanelControl2.TabIndex = 1
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(108, 14)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 40
        Me.btnBatal.Text = "Batal"
        '
        'btnSimpan
        '
        Me.btnSimpan.ImageOptions.Image = CType(resources.GetObject("btnSimpan.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(12, 14)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 39
        Me.btnSimpan.Text = "Simpan"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(204, 14)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 38
        Me.btnTutup.Text = "Tutup"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.txtjumlahterima)
        Me.PanelControl3.Controls.Add(Me.Label18)
        Me.PanelControl3.Controls.Add(Me.lbltotalharga)
        Me.PanelControl3.Controls.Add(Me.Label7)
        Me.PanelControl3.Controls.Add(Me.lbljatuhtempo)
        Me.PanelControl3.Controls.Add(Me.txttempohari)
        Me.PanelControl3.Controls.Add(Me.lblsisapiutang)
        Me.PanelControl3.Controls.Add(Me.lblcarajual)
        Me.PanelControl3.Controls.Add(Me.txtdibayar)
        Me.PanelControl3.Controls.Add(Me.Label13)
        Me.PanelControl3.Controls.Add(Me.Label12)
        Me.PanelControl3.Controls.Add(Me.Label11)
        Me.PanelControl3.Controls.Add(Me.Label10)
        Me.PanelControl3.Controls.Add(Me.Label9)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(563, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(644, 96)
        Me.PanelControl3.TabIndex = 3
        '
        'txtjumlahterima
        '
        Me.txtjumlahterima.Location = New System.Drawing.Point(509, 41)
        Me.txtjumlahterima.Name = "txtjumlahterima"
        Me.txtjumlahterima.Size = New System.Drawing.Size(116, 22)
        Me.txtjumlahterima.TabIndex = 29
        Me.txtjumlahterima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(509, 14)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(117, 23)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Jumlah Terima"
        '
        'lbltotalharga
        '
        Me.lbltotalharga.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltotalharga.Location = New System.Drawing.Point(138, 12)
        Me.lbltotalharga.Name = "lbltotalharga"
        Me.lbltotalharga.Size = New System.Drawing.Size(117, 23)
        Me.lbltotalharga.TabIndex = 24
        Me.lbltotalharga.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 23)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Total Harga"
        '
        'lbljatuhtempo
        '
        Me.lbljatuhtempo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbljatuhtempo.Location = New System.Drawing.Point(385, 63)
        Me.lbljatuhtempo.Name = "lbljatuhtempo"
        Me.lbljatuhtempo.Size = New System.Drawing.Size(117, 23)
        Me.lbljatuhtempo.TabIndex = 27
        '
        'txttempohari
        '
        Me.txttempohari.Location = New System.Drawing.Point(385, 40)
        Me.txttempohari.Name = "txttempohari"
        Me.txttempohari.Size = New System.Drawing.Size(116, 22)
        Me.txttempohari.TabIndex = 20
        '
        'lblsisapiutang
        '
        Me.lblsisapiutang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsisapiutang.Location = New System.Drawing.Point(385, 14)
        Me.lblsisapiutang.Name = "lblsisapiutang"
        Me.lblsisapiutang.Size = New System.Drawing.Size(117, 23)
        Me.lblsisapiutang.TabIndex = 26
        Me.lblsisapiutang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblcarajual
        '
        Me.lblcarajual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblcarajual.Location = New System.Drawing.Point(138, 61)
        Me.lblcarajual.Name = "lblcarajual"
        Me.lblcarajual.Size = New System.Drawing.Size(117, 23)
        Me.lblcarajual.TabIndex = 25
        '
        'txtdibayar
        '
        Me.txtdibayar.Location = New System.Drawing.Point(138, 38)
        Me.txtdibayar.Name = "txtdibayar"
        Me.txtdibayar.Size = New System.Drawing.Size(116, 22)
        Me.txtdibayar.TabIndex = 18
        Me.txtdibayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(262, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 23)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Sisa (Piutang)"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(262, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 23)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Jatuh Tempo"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(14, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 23)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Cara Jual"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(262, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 23)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Tempo (Hari)"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(14, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 23)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Dibayar (awal)"
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
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(0, 168)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.Size = New System.Drawing.Size(1209, 338)
        Me.DGV.TabIndex = 21
        '
        'LookUpEditFaktur
        '
        Me.LookUpEditFaktur.Location = New System.Drawing.Point(135, 11)
        Me.LookUpEditFaktur.Name = "LookUpEditFaktur"
        Me.LookUpEditFaktur.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LookUpEditFaktur.Properties.Appearance.Options.UseFont = True
        Me.LookUpEditFaktur.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.Transparent
        Me.LookUpEditFaktur.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LookUpEditFaktur.Properties.AppearanceDropDown.Options.UseBorderColor = True
        Me.LookUpEditFaktur.Properties.AppearanceDropDown.Options.UseFont = True
        Me.LookUpEditFaktur.Properties.AppearanceDropDownHeader.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LookUpEditFaktur.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.LookUpEditFaktur.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.LookUpEditFaktur.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.LookUpEditFaktur.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEditFaktur.Properties.DropDownRows = 10
        Me.LookUpEditFaktur.Properties.NullText = ""
        Me.LookUpEditFaktur.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LookUpEditFaktur.Size = New System.Drawing.Size(482, 24)
        Me.LookUpEditFaktur.TabIndex = 100
        '
        'TransaksiTerimaPiutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1209, 606)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TransaksiTerimaPiutang"
        Me.Text = "Penerimaan Piutang"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditFaktur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cbAkun As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lnlnomorterima As Label
    Friend WithEvents dtptanggal As DateTimePicker
    Friend WithEvents Label20 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lbltanggaljual As Label
    Friend WithEvents lblkodecustomer As Label
    Friend WithEvents lblnamacustomer As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtjumlahterima As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents lbltotalharga As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lbljatuhtempo As Label
    Friend WithEvents txttempohari As TextBox
    Friend WithEvents lblsisapiutang As Label
    Friend WithEvents lblcarajual As Label
    Friend WithEvents txtdibayar As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtKeterangan As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents DGV As DataGridView
    Friend WithEvents lookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents LookUpEditFaktur As DevExpress.XtraEditors.LookUpEdit
End Class
