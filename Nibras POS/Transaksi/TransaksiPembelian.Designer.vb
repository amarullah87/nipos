<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransaksiPembelian
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransaksiPembelian))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.lbljumlahbarang_nis = New System.Windows.Forms.Label()
        Me.txtKeterangan = New DevExpress.XtraEditors.TextEdit()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbAkun = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbFromNHS = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtNoPesanan = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtJenisNhs = New System.Windows.Forms.TextBox()
        Me.cbosupplier = New System.Windows.Forms.TextBox()
        Me.txtnofaktur = New System.Windows.Forms.TextBox()
        Me.lblkodesupplier = New System.Windows.Forms.Label()
        Me.dtptanggal = New System.Windows.Forms.DateTimePicker()
        Me.lblstatusbeli = New System.Windows.Forms.Label()
        Me.lbljumlahbarang = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnImport = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.txtKredit = New DevExpress.XtraEditors.TextEdit()
        Me.txtBiayaLain = New DevExpress.XtraEditors.TextEdit()
        Me.txtTunai = New DevExpress.XtraEditors.TextEdit()
        Me.txtDeposit = New DevExpress.XtraEditors.TextEdit()
        Me.lblKodeKredit = New System.Windows.Forms.Label()
        Me.lblKodeTunai = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblKredit = New System.Windows.Forms.Label()
        Me.lblKodeDeposit = New System.Windows.Forms.Label()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbltotalharga = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbljatuhtempo = New System.Windows.Forms.Label()
        Me.txttempo = New System.Windows.Forms.TextBox()
        Me.lblsisahutang = New System.Windows.Forms.Label()
        Me.lblcarabeli = New System.Windows.Forms.Label()
        Me.txtdibayar = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jumlah = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyReal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diskon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblsisahutanghide = New System.Windows.Forms.Label()
        Me.lbltotalhargahide = New System.Windows.Forms.Label()
        Me.lblDeposit = New System.Windows.Forms.Label()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.lblTunai = New System.Windows.Forms.Label()
        Me.lblBiayaLain = New System.Windows.Forms.Label()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Nibras_POS.WaitForm1), True, True)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.txtKeterangan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.txtKredit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBiayaLain.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTunai.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeposit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.lbljumlahbarang_nis)
        Me.PanelControl1.Controls.Add(Me.txtKeterangan)
        Me.PanelControl1.Controls.Add(Me.Label13)
        Me.PanelControl1.Controls.Add(Me.lookUpEdit)
        Me.PanelControl1.Controls.Add(Me.cbAkun)
        Me.PanelControl1.Controls.Add(Me.Label15)
        Me.PanelControl1.Controls.Add(Me.cbFromNHS)
        Me.PanelControl1.Controls.Add(Me.PictureBox1)
        Me.PanelControl1.Controls.Add(Me.txtNoPesanan)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.txtJenisNhs)
        Me.PanelControl1.Controls.Add(Me.cbosupplier)
        Me.PanelControl1.Controls.Add(Me.txtnofaktur)
        Me.PanelControl1.Controls.Add(Me.lblkodesupplier)
        Me.PanelControl1.Controls.Add(Me.dtptanggal)
        Me.PanelControl1.Controls.Add(Me.lblstatusbeli)
        Me.PanelControl1.Controls.Add(Me.lbljumlahbarang)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label14)
        Me.PanelControl1.Controls.Add(Me.Label7)
        Me.PanelControl1.Controls.Add(Me.Label6)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.txtBarcode)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(992, 136)
        Me.PanelControl1.TabIndex = 1
        '
        'lbljumlahbarang_nis
        '
        Me.lbljumlahbarang_nis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbljumlahbarang_nis.Location = New System.Drawing.Point(720, 42)
        Me.lbljumlahbarang_nis.Name = "lbljumlahbarang_nis"
        Me.lbljumlahbarang_nis.Size = New System.Drawing.Size(86, 23)
        Me.lbljumlahbarang_nis.TabIndex = 98
        Me.lbljumlahbarang_nis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbljumlahbarang_nis.Visible = False
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(135, 72)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(423, 20)
        Me.txtKeterangan.TabIndex = 97
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(12, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 23)
        Me.Label13.TabIndex = 96
        Me.Label13.Text = "Barcode"
        '
        'lookUpEdit
        '
        Me.lookUpEdit.Location = New System.Drawing.Point(344, 12)
        Me.lookUpEdit.Name = "lookUpEdit"
        Me.lookUpEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lookUpEdit.Properties.Appearance.Options.UseFont = True
        Me.lookUpEdit.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.Transparent
        Me.lookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lookUpEdit.Properties.AppearanceDropDown.Options.UseBorderColor = True
        Me.lookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.lookUpEdit.Properties.AppearanceDropDownHeader.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lookUpEdit.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.lookUpEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.lookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lookUpEdit.Properties.DropDownRows = 10
        Me.lookUpEdit.Properties.NullText = ""
        Me.lookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.lookUpEdit.Size = New System.Drawing.Size(521, 22)
        Me.lookUpEdit.TabIndex = 95
        '
        'cbAkun
        '
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.Location = New System.Drawing.Point(853, 72)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(241, 21)
        Me.cbAkun.TabIndex = 94
        Me.cbAkun.Visible = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(748, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 23)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Dari Kode Akun"
        Me.Label15.Visible = False
        '
        'cbFromNHS
        '
        Me.cbFromNHS.AutoSize = True
        Me.cbFromNHS.Location = New System.Drawing.Point(871, 16)
        Me.cbFromNHS.Name = "cbFromNHS"
        Me.cbFromNHS.Size = New System.Drawing.Size(68, 17)
        Me.cbFromNHS.TabIndex = 92
        Me.cbFromNHS.Text = "Dari NHS"
        Me.cbFromNHS.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(509, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 91
        Me.PictureBox1.TabStop = False
        '
        'txtNoPesanan
        '
        Me.txtNoPesanan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoPesanan.Location = New System.Drawing.Point(344, 41)
        Me.txtNoPesanan.Name = "txtNoPesanan"
        Me.txtNoPesanan.Size = New System.Drawing.Size(156, 21)
        Me.txtNoPesanan.TabIndex = 90
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(276, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 23)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Pesanan"
        '
        'txtJenisNhs
        '
        Me.txtJenisNhs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJenisNhs.Location = New System.Drawing.Point(381, 16)
        Me.txtJenisNhs.Name = "txtJenisNhs"
        Me.txtJenisNhs.Size = New System.Drawing.Size(118, 21)
        Me.txtJenisNhs.TabIndex = 88
        Me.txtJenisNhs.Visible = False
        '
        'cbosupplier
        '
        Me.cbosupplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbosupplier.Location = New System.Drawing.Point(12, 14)
        Me.cbosupplier.Name = "cbosupplier"
        Me.cbosupplier.Size = New System.Drawing.Size(156, 21)
        Me.cbosupplier.TabIndex = 87
        Me.cbosupplier.Visible = False
        '
        'txtnofaktur
        '
        Me.txtnofaktur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnofaktur.Location = New System.Drawing.Point(135, 14)
        Me.txtnofaktur.Name = "txtnofaktur"
        Me.txtnofaktur.ReadOnly = True
        Me.txtnofaktur.Size = New System.Drawing.Size(116, 21)
        Me.txtnofaktur.TabIndex = 77
        '
        'lblkodesupplier
        '
        Me.lblkodesupplier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblkodesupplier.Location = New System.Drawing.Point(176, 14)
        Me.lblkodesupplier.Name = "lblkodesupplier"
        Me.lblkodesupplier.Size = New System.Drawing.Size(199, 23)
        Me.lblkodesupplier.TabIndex = 86
        Me.lblkodesupplier.Visible = False
        '
        'dtptanggal
        '
        Me.dtptanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptanggal.Location = New System.Drawing.Point(135, 43)
        Me.dtptanggal.Name = "dtptanggal"
        Me.dtptanggal.Size = New System.Drawing.Size(116, 21)
        Me.dtptanggal.TabIndex = 79
        '
        'lblstatusbeli
        '
        Me.lblstatusbeli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblstatusbeli.Location = New System.Drawing.Point(628, 18)
        Me.lblstatusbeli.Name = "lblstatusbeli"
        Me.lblstatusbeli.Size = New System.Drawing.Size(117, 23)
        Me.lblstatusbeli.TabIndex = 85
        Me.lblstatusbeli.Visible = False
        '
        'lbljumlahbarang
        '
        Me.lbljumlahbarang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbljumlahbarang.Location = New System.Drawing.Point(628, 41)
        Me.lbljumlahbarang.Name = "lbljumlahbarang"
        Me.lbljumlahbarang.Size = New System.Drawing.Size(86, 23)
        Me.lbljumlahbarang.TabIndex = 83
        Me.lbljumlahbarang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(530, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 23)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Jumlah Barang"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(276, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 23)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Supplier"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 23)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Tanggal"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(505, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 23)
        Me.Label14.TabIndex = 84
        Me.Label14.Text = "Status Beli"
        Me.Label14.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 23)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "No Faktur"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 23)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Keterangan"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(434, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 39)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "[ F12 ] Download Barang"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(135, 101)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(293, 21)
        Me.txtBarcode.TabIndex = 74
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btnImport)
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Controls.Add(Me.btnBatal)
        Me.PanelControl2.Controls.Add(Me.btnSimpan)
        Me.PanelControl2.Controls.Add(Me.btnTutup)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 504)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(992, 132)
        Me.PanelControl2.TabIndex = 2
        '
        'btnImport
        '
        Me.btnImport.ImageOptions.Image = CType(resources.GetObject("btnImport.ImageOptions.Image"), System.Drawing.Image)
        Me.btnImport.Location = New System.Drawing.Point(300, 88)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(90, 35)
        Me.btnImport.TabIndex = 130
        Me.btnImport.Text = "Import"
        Me.btnImport.Visible = False
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.txtKredit)
        Me.PanelControl3.Controls.Add(Me.txtBiayaLain)
        Me.PanelControl3.Controls.Add(Me.txtTunai)
        Me.PanelControl3.Controls.Add(Me.txtDeposit)
        Me.PanelControl3.Controls.Add(Me.lblKodeKredit)
        Me.PanelControl3.Controls.Add(Me.lblKodeTunai)
        Me.PanelControl3.Controls.Add(Me.PictureBox2)
        Me.PanelControl3.Controls.Add(Me.Label9)
        Me.PanelControl3.Controls.Add(Me.Label10)
        Me.PanelControl3.Controls.Add(Me.lblKredit)
        Me.PanelControl3.Controls.Add(Me.lblKodeDeposit)
        Me.PanelControl3.Controls.Add(Me.SimpleButton3)
        Me.PanelControl3.Controls.Add(Me.SimpleButton2)
        Me.PanelControl3.Controls.Add(Me.SimpleButton1)
        Me.PanelControl3.Controls.Add(Me.Label18)
        Me.PanelControl3.Controls.Add(Me.Label16)
        Me.PanelControl3.Controls.Add(Me.Label11)
        Me.PanelControl3.Controls.Add(Me.lbltotalharga)
        Me.PanelControl3.Controls.Add(Me.Label8)
        Me.PanelControl3.Controls.Add(Me.lbljatuhtempo)
        Me.PanelControl3.Controls.Add(Me.txttempo)
        Me.PanelControl3.Controls.Add(Me.lblsisahutang)
        Me.PanelControl3.Controls.Add(Me.lblcarabeli)
        Me.PanelControl3.Controls.Add(Me.txtdibayar)
        Me.PanelControl3.Controls.Add(Me.Label12)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(327, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(663, 128)
        Me.PanelControl3.TabIndex = 36
        '
        'txtKredit
        '
        Me.txtKredit.EditValue = "0"
        Me.txtKredit.Location = New System.Drawing.Point(500, 101)
        Me.txtKredit.Name = "txtKredit"
        Me.txtKredit.Properties.Appearance.Options.UseTextOptions = True
        Me.txtKredit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtKredit.Properties.Mask.BeepOnError = True
        Me.txtKredit.Properties.Mask.EditMask = "n0"
        Me.txtKredit.Properties.Mask.PlaceHolder = Global.Microsoft.VisualBasic.ChrW(48)
        Me.txtKredit.Properties.NullText = "0"
        Me.txtKredit.Properties.NullValuePrompt = "0"
        Me.txtKredit.Properties.ReadOnly = True
        Me.txtKredit.Size = New System.Drawing.Size(116, 20)
        Me.txtKredit.TabIndex = 110
        '
        'txtBiayaLain
        '
        Me.txtBiayaLain.EditValue = "0"
        Me.txtBiayaLain.Location = New System.Drawing.Point(303, 100)
        Me.txtBiayaLain.Name = "txtBiayaLain"
        Me.txtBiayaLain.Properties.Appearance.Options.UseTextOptions = True
        Me.txtBiayaLain.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtBiayaLain.Properties.Mask.BeepOnError = True
        Me.txtBiayaLain.Properties.Mask.EditMask = "n0"
        Me.txtBiayaLain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtBiayaLain.Properties.Mask.PlaceHolder = Global.Microsoft.VisualBasic.ChrW(48)
        Me.txtBiayaLain.Properties.NullText = "0"
        Me.txtBiayaLain.Properties.NullValuePrompt = "0"
        Me.txtBiayaLain.Size = New System.Drawing.Size(116, 20)
        Me.txtBiayaLain.TabIndex = 109
        '
        'txtTunai
        '
        Me.txtTunai.EditValue = "0"
        Me.txtTunai.Location = New System.Drawing.Point(500, 71)
        Me.txtTunai.Name = "txtTunai"
        Me.txtTunai.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTunai.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTunai.Properties.Mask.BeepOnError = True
        Me.txtTunai.Properties.Mask.EditMask = "n0"
        Me.txtTunai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTunai.Properties.Mask.PlaceHolder = Global.Microsoft.VisualBasic.ChrW(48)
        Me.txtTunai.Properties.NullText = "0"
        Me.txtTunai.Properties.NullValuePrompt = "0"
        Me.txtTunai.Size = New System.Drawing.Size(116, 20)
        Me.txtTunai.TabIndex = 108
        '
        'txtDeposit
        '
        Me.txtDeposit.EditValue = "0"
        Me.txtDeposit.Location = New System.Drawing.Point(501, 43)
        Me.txtDeposit.Name = "txtDeposit"
        Me.txtDeposit.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDeposit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtDeposit.Properties.Mask.BeepOnError = True
        Me.txtDeposit.Properties.Mask.EditMask = "n0"
        Me.txtDeposit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtDeposit.Properties.Mask.PlaceHolder = Global.Microsoft.VisualBasic.ChrW(48)
        Me.txtDeposit.Properties.NullText = "0"
        Me.txtDeposit.Properties.NullValuePrompt = "0"
        Me.txtDeposit.Size = New System.Drawing.Size(116, 20)
        Me.txtDeposit.TabIndex = 26
        '
        'lblKodeKredit
        '
        Me.lblKodeKredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKodeKredit.Location = New System.Drawing.Point(17, 107)
        Me.lblKodeKredit.Name = "lblKodeKredit"
        Me.lblKodeKredit.Size = New System.Drawing.Size(169, 23)
        Me.lblKodeKredit.TabIndex = 107
        Me.lblKodeKredit.Text = "2-1101/HUTANG USAHA"
        Me.lblKodeKredit.Visible = False
        '
        'lblKodeTunai
        '
        Me.lblKodeTunai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKodeTunai.Location = New System.Drawing.Point(17, 84)
        Me.lblKodeTunai.Name = "lblKodeTunai"
        Me.lblKodeTunai.Size = New System.Drawing.Size(169, 23)
        Me.lblKodeTunai.TabIndex = 106
        Me.lblKodeTunai.Text = "1-1120/KAS BESAR"
        Me.lblKodeTunai.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(192, 100)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 105
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(210, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 23)
        Me.Label9.TabIndex = 103
        Me.Label9.Text = "Biaya Lain-lain :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(207, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 23)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Tempo (Hari) :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKredit
        '
        Me.lblKredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKredit.Location = New System.Drawing.Point(141, 39)
        Me.lblKredit.Name = "lblKredit"
        Me.lblKredit.Size = New System.Drawing.Size(117, 23)
        Me.lblKredit.TabIndex = 102
        Me.lblKredit.Text = "0"
        Me.lblKredit.Visible = False
        '
        'lblKodeDeposit
        '
        Me.lblKodeDeposit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKodeDeposit.Location = New System.Drawing.Point(141, 11)
        Me.lblKodeDeposit.Name = "lblKodeDeposit"
        Me.lblKodeDeposit.Size = New System.Drawing.Size(278, 23)
        Me.lblKodeDeposit.TabIndex = 101
        Me.lblKodeDeposit.Text = "1-1801/DANA DEPOSIT DI SUPLIER"
        Me.lblKodeDeposit.Visible = False
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.SimpleButton3.Location = New System.Drawing.Point(622, 99)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(29, 23)
        Me.SimpleButton3.TabIndex = 97
        Me.SimpleButton3.Visible = False
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.SimpleButton2.Location = New System.Drawing.Point(622, 69)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(29, 23)
        Me.SimpleButton2.TabIndex = 96
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(622, 40)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(29, 23)
        Me.SimpleButton1.TabIndex = 95
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(424, 99)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 23)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Kredit :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(424, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 23)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Tunai/ DP :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(424, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 23)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Deposit :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbltotalharga
        '
        Me.lbltotalharga.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltotalharga.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalharga.Location = New System.Drawing.Point(501, 9)
        Me.lbltotalharga.Name = "lbltotalharga"
        Me.lbltotalharga.Size = New System.Drawing.Size(117, 23)
        Me.lbltotalharga.TabIndex = 22
        Me.lbltotalharga.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(408, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 23)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Total Harga :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbljatuhtempo
        '
        Me.lbljatuhtempo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbljatuhtempo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbljatuhtempo.Location = New System.Drawing.Point(302, 69)
        Me.lbljatuhtempo.Name = "lbljatuhtempo"
        Me.lbljatuhtempo.Size = New System.Drawing.Size(117, 23)
        Me.lbljatuhtempo.TabIndex = 25
        '
        'txttempo
        '
        Me.txttempo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempo.Location = New System.Drawing.Point(302, 43)
        Me.txttempo.Name = "txttempo"
        Me.txttempo.Size = New System.Drawing.Size(116, 21)
        Me.txttempo.TabIndex = 18
        Me.txttempo.Text = "7"
        Me.txttempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsisahutang
        '
        Me.lblsisahutang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsisahutang.Location = New System.Drawing.Point(17, 61)
        Me.lblsisahutang.Name = "lblsisahutang"
        Me.lblsisahutang.Size = New System.Drawing.Size(117, 23)
        Me.lblsisahutang.TabIndex = 24
        Me.lblsisahutang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblsisahutang.Visible = False
        '
        'lblcarabeli
        '
        Me.lblcarabeli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblcarabeli.Location = New System.Drawing.Point(18, 11)
        Me.lblcarabeli.Name = "lblcarabeli"
        Me.lblcarabeli.Size = New System.Drawing.Size(117, 23)
        Me.lblcarabeli.TabIndex = 23
        Me.lblcarabeli.Visible = False
        '
        'txtdibayar
        '
        Me.txtdibayar.Location = New System.Drawing.Point(18, 37)
        Me.txtdibayar.Name = "txtdibayar"
        Me.txtdibayar.Size = New System.Drawing.Size(116, 21)
        Me.txtdibayar.TabIndex = 16
        Me.txtdibayar.Text = "0"
        Me.txtdibayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtdibayar.Visible = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(210, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 23)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Jatuh Tempo :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(108, 89)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 34
        Me.btnBatal.Text = "Batal"
        '
        'btnSimpan
        '
        Me.btnSimpan.ImageOptions.Image = CType(resources.GetObject("btnSimpan.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(12, 89)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 33
        Me.btnSimpan.Text = "Simpan"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(204, 89)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 32
        Me.btnTutup.Text = "Tutup"
        '
        'DGV
        '
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Kode, Me.Nama, Me.Harga, Me.Jumlah, Me.QtyReal, Me.Diskon, Me.Total})
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(0, 136)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(992, 368)
        Me.DGV.TabIndex = 4
        '
        'Kode
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kode.DefaultCellStyle = DataGridViewCellStyle1
        Me.Kode.HeaderText = "Kode Barang"
        Me.Kode.Name = "Kode"
        '
        'Nama
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nama.DefaultCellStyle = DataGridViewCellStyle2
        Me.Nama.HeaderText = "Nama Barang"
        Me.Nama.Name = "Nama"
        Me.Nama.ReadOnly = True
        '
        'Harga
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        DataGridViewCellStyle3.Format = "C0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Harga.DefaultCellStyle = DataGridViewCellStyle3
        Me.Harga.HeaderText = "Harga Beli"
        Me.Harga.Name = "Harga"
        '
        'Jumlah
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!)
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Jumlah.DefaultCellStyle = DataGridViewCellStyle4
        Me.Jumlah.HeaderText = "Jumlah"
        Me.Jumlah.Name = "Jumlah"
        Me.Jumlah.ReadOnly = True
        '
        'QtyReal
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.QtyReal.DefaultCellStyle = DataGridViewCellStyle5
        Me.QtyReal.HeaderText = "Qty Real"
        Me.QtyReal.Name = "QtyReal"
        '
        'Diskon
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.75!)
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.Diskon.DefaultCellStyle = DataGridViewCellStyle6
        Me.Diskon.HeaderText = "Diskon (%)"
        Me.Diskon.Name = "Diskon"
        '
        'Total
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.75!)
        DataGridViewCellStyle7.Format = "C0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle7
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'lblsisahutanghide
        '
        Me.lblsisahutanghide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblsisahutanghide.Location = New System.Drawing.Point(576, 363)
        Me.lblsisahutanghide.Name = "lblsisahutanghide"
        Me.lblsisahutanghide.Size = New System.Drawing.Size(117, 23)
        Me.lblsisahutanghide.TabIndex = 15
        Me.lblsisahutanghide.Visible = False
        '
        'lbltotalhargahide
        '
        Me.lbltotalhargahide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltotalhargahide.Location = New System.Drawing.Point(279, 365)
        Me.lbltotalhargahide.Name = "lbltotalhargahide"
        Me.lbltotalhargahide.Size = New System.Drawing.Size(149, 23)
        Me.lbltotalhargahide.TabIndex = 16
        Me.lbltotalhargahide.Visible = False
        '
        'lblDeposit
        '
        Me.lblDeposit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDeposit.Location = New System.Drawing.Point(279, 413)
        Me.lblDeposit.Name = "lblDeposit"
        Me.lblDeposit.Size = New System.Drawing.Size(117, 23)
        Me.lblDeposit.TabIndex = 25
        Me.lblDeposit.Text = "0"
        Me.lblDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDeposit.Visible = False
        '
        'lblTunai
        '
        Me.lblTunai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTunai.Location = New System.Drawing.Point(279, 448)
        Me.lblTunai.Name = "lblTunai"
        Me.lblTunai.Size = New System.Drawing.Size(117, 23)
        Me.lblTunai.TabIndex = 26
        Me.lblTunai.Text = "0"
        Me.lblTunai.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTunai.Visible = False
        '
        'lblBiayaLain
        '
        Me.lblBiayaLain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBiayaLain.Location = New System.Drawing.Point(279, 481)
        Me.lblBiayaLain.Name = "lblBiayaLain"
        Me.lblBiayaLain.Size = New System.Drawing.Size(117, 23)
        Me.lblBiayaLain.TabIndex = 27
        Me.lblBiayaLain.Text = "0"
        Me.lblBiayaLain.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBiayaLain.Visible = False
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'TransaksiPembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 636)
        Me.Controls.Add(Me.lblBiayaLain)
        Me.Controls.Add(Me.lblTunai)
        Me.Controls.Add(Me.lblsisahutanghide)
        Me.Controls.Add(Me.lbltotalhargahide)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.lblDeposit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TransaksiPembelian"
        Me.Text = "Transaksi Pembelian"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.txtKeterangan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.txtKredit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBiayaLain.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTunai.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeposit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents cbFromNHS As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtNoPesanan As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtJenisNhs As TextBox
    Friend WithEvents cbosupplier As TextBox
    Friend WithEvents txtnofaktur As TextBox
    Friend WithEvents lblkodesupplier As Label
    Friend WithEvents dtptanggal As DateTimePicker
    Friend WithEvents lblstatusbeli As Label
    Friend WithEvents lbljumlahbarang As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lbltotalharga As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lbljatuhtempo As Label
    Friend WithEvents txttempo As TextBox
    Friend WithEvents lblsisahutang As Label
    Friend WithEvents lblcarabeli As Label
    Friend WithEvents txtdibayar As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DGV As DataGridView
    Friend WithEvents lblsisahutanghide As Label
    Friend WithEvents lbltotalhargahide As Label
    Friend WithEvents cbAkun As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblKodeDeposit As Label
    Friend WithEvents lblKredit As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblKodeTunai As Label
    Friend WithEvents lblKodeKredit As Label
    Friend WithEvents lblDeposit As Label
    Friend WithEvents txtDeposit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents txtBiayaLain As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTunai As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtKredit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblTunai As Label
    Friend WithEvents lblBiayaLain As Label
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents lookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtKeterangan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label13 As Label
    Friend WithEvents Kode As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Harga As DataGridViewTextBoxColumn
    Friend WithEvents Jumlah As DataGridViewTextBoxColumn
    Friend WithEvents QtyReal As DataGridViewTextBoxColumn
    Friend WithEvents Diskon As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents lbljumlahbarang_nis As Label
End Class
