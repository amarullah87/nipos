<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterCustomer))
        Me.dtpTglLahir = New System.Windows.Forms.DateTimePicker()
        Me.txtTipeDiskon = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtGroup = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtJatuhTempo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtHariPiutang = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLimitPiutang = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtProvinsi = New System.Windows.Forms.TextBox()
        Me.txtKota = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.txtKodepos = New System.Windows.Forms.TextBox()
        Me.txtTelepon = New System.Windows.Forms.TextBox()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.txtKodeMember = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTNTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.dtpTglDaftar = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpMasaAktif = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtpTglLahir
        '
        Me.dtpTglLahir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglLahir.Location = New System.Drawing.Point(369, 204)
        Me.dtpTglLahir.Name = "dtpTglLahir"
        Me.dtpTglLahir.Size = New System.Drawing.Size(140, 21)
        Me.dtpTglLahir.TabIndex = 86
        '
        'txtTipeDiskon
        '
        Me.txtTipeDiskon.FormattingEnabled = True
        Me.txtTipeDiskon.Location = New System.Drawing.Point(699, 143)
        Me.txtTipeDiskon.Name = "txtTipeDiskon"
        Me.txtTipeDiskon.Size = New System.Drawing.Size(207, 21)
        Me.txtTipeDiskon.TabIndex = 81
        Me.txtTipeDiskon.Visible = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(541, 146)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(143, 23)
        Me.Label15.TabIndex = 85
        Me.Label15.Text = "Tipe Diskon"
        Me.Label15.Visible = False
        '
        'txtGroup
        '
        Me.txtGroup.FormattingEnabled = True
        Me.txtGroup.Location = New System.Drawing.Point(699, 114)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Size = New System.Drawing.Size(207, 21)
        Me.txtGroup.TabIndex = 79
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(541, 117)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(143, 23)
        Me.Label14.TabIndex = 84
        Me.Label14.Text = "Group Member"
        '
        'txtJatuhTempo
        '
        Me.txtJatuhTempo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJatuhTempo.Location = New System.Drawing.Point(699, 85)
        Me.txtJatuhTempo.Name = "txtJatuhTempo"
        Me.txtJatuhTempo.Size = New System.Drawing.Size(50, 21)
        Me.txtJatuhTempo.TabIndex = 78
        Me.txtJatuhTempo.Text = "7"
        Me.txtJatuhTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(541, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(143, 23)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Jatuh Tempo (Hari)"
        '
        'txtHariPiutang
        '
        Me.txtHariPiutang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHariPiutang.Location = New System.Drawing.Point(699, 53)
        Me.txtHariPiutang.Name = "txtHariPiutang"
        Me.txtHariPiutang.Size = New System.Drawing.Size(50, 21)
        Me.txtHariPiutang.TabIndex = 77
        Me.txtHariPiutang.Text = "7"
        Me.txtHariPiutang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(541, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(143, 23)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "Limit Hari Piutang"
        '
        'txtLimitPiutang
        '
        Me.txtLimitPiutang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLimitPiutang.Location = New System.Drawing.Point(699, 24)
        Me.txtLimitPiutang.Name = "txtLimitPiutang"
        Me.txtLimitPiutang.Size = New System.Drawing.Size(140, 21)
        Me.txtLimitPiutang.TabIndex = 75
        Me.txtLimitPiutang.Text = "0"
        Me.txtLimitPiutang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(541, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(143, 23)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "Limit Jumlah Piutang"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(292, 207)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 23)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "Tgl Lahir"
        '
        'txtProvinsi
        '
        Me.txtProvinsi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvinsi.Location = New System.Drawing.Point(369, 149)
        Me.txtProvinsi.Name = "txtProvinsi"
        Me.txtProvinsi.Size = New System.Drawing.Size(140, 21)
        Me.txtProvinsi.TabIndex = 66
        '
        'txtKota
        '
        Me.txtKota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKota.Location = New System.Drawing.Point(146, 147)
        Me.txtKota.Name = "txtKota"
        Me.txtKota.Size = New System.Drawing.Size(140, 21)
        Me.txtKota.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(292, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 23)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "Provinsi"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(22, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 23)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "Kota"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(146, 207)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(140, 21)
        Me.txtEmail.TabIndex = 72
        '
        'txtContact
        '
        Me.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContact.Location = New System.Drawing.Point(146, 236)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(140, 21)
        Me.txtContact.TabIndex = 73
        '
        'txtKodepos
        '
        Me.txtKodepos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKodepos.Location = New System.Drawing.Point(369, 178)
        Me.txtKodepos.Name = "txtKodepos"
        Me.txtKodepos.Size = New System.Drawing.Size(140, 21)
        Me.txtKodepos.TabIndex = 69
        '
        'txtTelepon
        '
        Me.txtTelepon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelepon.Location = New System.Drawing.Point(146, 176)
        Me.txtTelepon.Name = "txtTelepon"
        Me.txtTelepon.Size = New System.Drawing.Size(140, 21)
        Me.txtTelepon.TabIndex = 68
        '
        'txtAlamat
        '
        Me.txtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlamat.Location = New System.Drawing.Point(146, 85)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(363, 56)
        Me.txtAlamat.TabIndex = 62
        '
        'txtNama
        '
        Me.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNama.Location = New System.Drawing.Point(146, 56)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(363, 21)
        Me.txtNama.TabIndex = 60
        '
        'txtKodeMember
        '
        Me.txtKodeMember.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKodeMember.Location = New System.Drawing.Point(146, 27)
        Me.txtKodeMember.Name = "txtKodeMember"
        Me.txtKodeMember.Size = New System.Drawing.Size(140, 21)
        Me.txtKodeMember.TabIndex = 57
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(23, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 23)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "Contact Person"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(23, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 23)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Email"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(292, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 23)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Kode POS"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(22, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 23)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Telepon"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(22, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 23)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Alamat"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(22, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 23)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Nama"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(23, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 23)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Kode Member"
        '
        'BTNTutup
        '
        Me.BTNTutup.ImageOptions.Image = CType(resources.GetObject("BTNTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.BTNTutup.Location = New System.Drawing.Point(217, 285)
        Me.BTNTutup.Name = "BTNTutup"
        Me.BTNTutup.Size = New System.Drawing.Size(90, 35)
        Me.BTNTutup.TabIndex = 87
        Me.BTNTutup.Text = "Tutup"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(25, 285)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(90, 35)
        Me.SimpleButton1.TabIndex = 88
        Me.SimpleButton1.Text = "Simpan"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(121, 285)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(90, 35)
        Me.SimpleButton2.TabIndex = 89
        Me.SimpleButton2.Text = "Batal"
        '
        'dtpTglDaftar
        '
        Me.dtpTglDaftar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglDaftar.Location = New System.Drawing.Point(699, 176)
        Me.dtpTglDaftar.Name = "dtpTglDaftar"
        Me.dtpTglDaftar.Size = New System.Drawing.Size(140, 21)
        Me.dtpTglDaftar.TabIndex = 91
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(541, 176)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 23)
        Me.Label16.TabIndex = 90
        Me.Label16.Text = "Tanggal Daftar"
        '
        'dtpMasaAktif
        '
        Me.dtpMasaAktif.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMasaAktif.Location = New System.Drawing.Point(699, 204)
        Me.dtpMasaAktif.Name = "dtpMasaAktif"
        Me.dtpMasaAktif.Size = New System.Drawing.Size(140, 21)
        Me.dtpMasaAktif.TabIndex = 93
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(541, 204)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(117, 23)
        Me.Label17.TabIndex = 92
        Me.Label17.Text = "Masa Aktif s.d"
        '
        'MasterCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 332)
        Me.Controls.Add(Me.dtpMasaAktif)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.dtpTglDaftar)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.BTNTutup)
        Me.Controls.Add(Me.dtpTglLahir)
        Me.Controls.Add(Me.txtTipeDiskon)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtGroup)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtJatuhTempo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtHariPiutang)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtLimitPiutang)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtProvinsi)
        Me.Controls.Add(Me.txtKota)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.txtKodepos)
        Me.Controls.Add(Me.txtTelepon)
        Me.Controls.Add(Me.txtAlamat)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.txtKodeMember)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MasterCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tambah Data Pelanggan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpTglLahir As DateTimePicker
    Friend WithEvents txtTipeDiskon As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtGroup As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtJatuhTempo As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtHariPiutang As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtLimitPiutang As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtProvinsi As TextBox
    Friend WithEvents txtKota As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtKodepos As TextBox
    Friend WithEvents txtTelepon As TextBox
    Friend WithEvents txtAlamat As TextBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtKodeMember As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BTNTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtpTglDaftar As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents dtpMasaAktif As DateTimePicker
    Friend WithEvents Label17 As Label
End Class
