<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TambahDeposit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TambahDeposit))
        Me.lblJumlahKeluar = New System.Windows.Forms.Label()
        Me.lblJumlahDeposit = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.dtptanggal = New System.Windows.Forms.DateTimePicker()
        Me.cbKodeAkunDeposit = New System.Windows.Forms.ComboBox()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.cbAkun = New System.Windows.Forms.ComboBox()
        Me.lblAkunKeluar = New System.Windows.Forms.Label()
        Me.cbMember = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbJenisDeposit = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNoTransaksi = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblAkunMasuk = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.txtJumlah = New DevExpress.XtraEditors.TextEdit()
        Me.lookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.LookUpEditAkun = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.txtJumlah.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditAkun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblJumlahKeluar
        '
        Me.lblJumlahKeluar.Location = New System.Drawing.Point(404, 184)
        Me.lblJumlahKeluar.Name = "lblJumlahKeluar"
        Me.lblJumlahKeluar.Size = New System.Drawing.Size(117, 23)
        Me.lblJumlahKeluar.TabIndex = 84
        Me.lblJumlahKeluar.Text = "Jumlah Keluar"
        Me.lblJumlahKeluar.Visible = False
        '
        'lblJumlahDeposit
        '
        Me.lblJumlahDeposit.Location = New System.Drawing.Point(404, 181)
        Me.lblJumlahDeposit.Name = "lblJumlahDeposit"
        Me.lblJumlahDeposit.Size = New System.Drawing.Size(117, 23)
        Me.lblJumlahDeposit.TabIndex = 83
        Me.lblJumlahDeposit.Text = "Jumlah Deposit"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(404, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 23)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Sisa Saldo"
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(527, 149)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(140, 22)
        Me.txtSaldo.TabIndex = 81
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtptanggal
        '
        Me.dtptanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptanggal.Location = New System.Drawing.Point(135, 35)
        Me.dtptanggal.Name = "dtptanggal"
        Me.dtptanggal.Size = New System.Drawing.Size(170, 22)
        Me.dtptanggal.TabIndex = 80
        '
        'cbKodeAkunDeposit
        '
        Me.cbKodeAkunDeposit.FormattingEnabled = True
        Me.cbKodeAkunDeposit.Location = New System.Drawing.Point(135, 181)
        Me.cbKodeAkunDeposit.Name = "cbKodeAkunDeposit"
        Me.cbKodeAkunDeposit.Size = New System.Drawing.Size(263, 21)
        Me.cbKodeAkunDeposit.TabIndex = 79
        Me.cbKodeAkunDeposit.Visible = False
        '
        'txtKeterangan
        '
        Me.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKeterangan.Location = New System.Drawing.Point(135, 210)
        Me.txtKeterangan.Multiline = True
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(532, 56)
        Me.txtKeterangan.TabIndex = 78
        '
        'cbAkun
        '
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.Location = New System.Drawing.Point(135, 121)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(263, 21)
        Me.cbAkun.TabIndex = 77
        Me.cbAkun.Visible = False
        '
        'lblAkunKeluar
        '
        Me.lblAkunKeluar.Location = New System.Drawing.Point(12, 152)
        Me.lblAkunKeluar.Name = "lblAkunKeluar"
        Me.lblAkunKeluar.Size = New System.Drawing.Size(117, 23)
        Me.lblAkunKeluar.TabIndex = 76
        Me.lblAkunKeluar.Text = "Keluar dari Akun"
        Me.lblAkunKeluar.Visible = False
        '
        'cbMember
        '
        Me.cbMember.FormattingEnabled = True
        Me.cbMember.Location = New System.Drawing.Point(311, 6)
        Me.cbMember.Name = "cbMember"
        Me.cbMember.Size = New System.Drawing.Size(135, 21)
        Me.cbMember.TabIndex = 74
        Me.cbMember.Visible = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(12, 93)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 23)
        Me.Label15.TabIndex = 75
        Me.Label15.Text = "Member"
        '
        'cbJenisDeposit
        '
        Me.cbJenisDeposit.FormattingEnabled = True
        Me.cbJenisDeposit.Items.AddRange(New Object() {"Masuk", "Keluar"})
        Me.cbJenisDeposit.Location = New System.Drawing.Point(135, 64)
        Me.cbJenisDeposit.Name = "cbJenisDeposit"
        Me.cbJenisDeposit.Size = New System.Drawing.Size(170, 21)
        Me.cbJenisDeposit.TabIndex = 73
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(11, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 23)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Jenis Deposit"
        '
        'txtNoTransaksi
        '
        Me.txtNoTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoTransaksi.Location = New System.Drawing.Point(135, 6)
        Me.txtNoTransaksi.Name = "txtNoTransaksi"
        Me.txtNoTransaksi.Size = New System.Drawing.Size(170, 22)
        Me.txtNoTransaksi.TabIndex = 66
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 23)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Keterangan"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(11, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 23)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Kode Akun Deposit"
        Me.Label6.Visible = False
        '
        'lblAkunMasuk
        '
        Me.lblAkunMasuk.Location = New System.Drawing.Point(11, 155)
        Me.lblAkunMasuk.Name = "lblAkunMasuk"
        Me.lblAkunMasuk.Size = New System.Drawing.Size(117, 23)
        Me.lblAkunMasuk.TabIndex = 69
        Me.lblAkunMasuk.Text = "Masuk ke Akun"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(11, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 23)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Tanggal"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 23)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "No Transaksi"
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(231, 282)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 88
        Me.btnBatal.Text = "Batal"
        '
        'btnSimpan
        '
        Me.btnSimpan.ImageOptions.Image = CType(resources.GetObject("btnSimpan.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(135, 282)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 87
        Me.btnSimpan.Text = "Simpan"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(327, 282)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 86
        Me.btnTutup.Text = "Tutup"
        '
        'txtJumlah
        '
        Me.txtJumlah.EditValue = "0"
        Me.txtJumlah.Location = New System.Drawing.Point(527, 181)
        Me.txtJumlah.Name = "txtJumlah"
        Me.txtJumlah.Properties.Appearance.Options.UseTextOptions = True
        Me.txtJumlah.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtJumlah.Properties.Mask.BeepOnError = True
        Me.txtJumlah.Properties.Mask.EditMask = "n0"
        Me.txtJumlah.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtJumlah.Properties.Mask.PlaceHolder = Global.Microsoft.VisualBasic.ChrW(48)
        Me.txtJumlah.Properties.NullText = "0"
        Me.txtJumlah.Properties.NullValuePrompt = "0"
        Me.txtJumlah.Size = New System.Drawing.Size(138, 20)
        Me.txtJumlah.TabIndex = 89
        '
        'lookUpEdit
        '
        Me.lookUpEdit.Location = New System.Drawing.Point(135, 91)
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
        Me.lookUpEdit.Size = New System.Drawing.Size(386, 24)
        Me.lookUpEdit.TabIndex = 97
        '
        'LookUpEditAkun
        '
        Me.LookUpEditAkun.Location = New System.Drawing.Point(135, 149)
        Me.LookUpEditAkun.Name = "LookUpEditAkun"
        Me.LookUpEditAkun.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LookUpEditAkun.Properties.Appearance.Options.UseFont = True
        Me.LookUpEditAkun.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.Transparent
        Me.LookUpEditAkun.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LookUpEditAkun.Properties.AppearanceDropDown.Options.UseBorderColor = True
        Me.LookUpEditAkun.Properties.AppearanceDropDown.Options.UseFont = True
        Me.LookUpEditAkun.Properties.AppearanceDropDownHeader.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LookUpEditAkun.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.LookUpEditAkun.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.LookUpEditAkun.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.LookUpEditAkun.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEditAkun.Properties.DropDownRows = 10
        Me.LookUpEditAkun.Properties.NullText = ""
        Me.LookUpEditAkun.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LookUpEditAkun.Size = New System.Drawing.Size(263, 24)
        Me.LookUpEditAkun.TabIndex = 98
        '
        'TambahDeposit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 345)
        Me.Controls.Add(Me.LookUpEditAkun)
        Me.Controls.Add(Me.lookUpEdit)
        Me.Controls.Add(Me.txtJumlah)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.btnTutup)
        Me.Controls.Add(Me.lblJumlahKeluar)
        Me.Controls.Add(Me.lblJumlahDeposit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.dtptanggal)
        Me.Controls.Add(Me.cbKodeAkunDeposit)
        Me.Controls.Add(Me.txtKeterangan)
        Me.Controls.Add(Me.cbAkun)
        Me.Controls.Add(Me.lblAkunKeluar)
        Me.Controls.Add(Me.cbMember)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cbJenisDeposit)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNoTransaksi)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblAkunMasuk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TambahDeposit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tambah Deposit"
        CType(Me.txtJumlah.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditAkun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblJumlahKeluar As Label
    Friend WithEvents lblJumlahDeposit As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents dtptanggal As DateTimePicker
    Friend WithEvents cbKodeAkunDeposit As ComboBox
    Friend WithEvents txtKeterangan As TextBox
    Friend WithEvents cbAkun As ComboBox
    Friend WithEvents lblAkunKeluar As Label
    Friend WithEvents cbMember As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cbJenisDeposit As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNoTransaksi As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblAkunMasuk As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtJumlah As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEditAkun As DevExpress.XtraEditors.LookUpEdit
End Class
