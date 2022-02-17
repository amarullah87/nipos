<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TambahKasKeluar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TambahKasKeluar))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtSaldoHide = New System.Windows.Forms.TextBox()
        Me.txtTotalHide = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.txtNoTransaksi = New System.Windows.Forms.TextBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaAcc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAkun = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtptanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.txtJumlah = New DevExpress.XtraEditors.TextEdit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.txtJumlah.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSaldoHide
        '
        Me.txtSaldoHide.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSaldoHide.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoHide.Location = New System.Drawing.Point(783, 47)
        Me.txtSaldoHide.Name = "txtSaldoHide"
        Me.txtSaldoHide.Size = New System.Drawing.Size(229, 21)
        Me.txtSaldoHide.TabIndex = 91
        Me.txtSaldoHide.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldoHide.Visible = False
        '
        'txtTotalHide
        '
        Me.txtTotalHide.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalHide.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHide.Location = New System.Drawing.Point(783, 77)
        Me.txtTotalHide.Name = "txtTotalHide"
        Me.txtTotalHide.Size = New System.Drawing.Size(229, 21)
        Me.txtTotalHide.TabIndex = 90
        Me.txtTotalHide.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalHide.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(400, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 27)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Keterangan"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKeterangan
        '
        Me.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKeterangan.Location = New System.Drawing.Point(548, 77)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(229, 22)
        Me.txtKeterangan.TabIndex = 98
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(400, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 27)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Jumlah Keluar"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSaldo
        '
        Me.txtSaldo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSaldo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldo.Location = New System.Drawing.Point(783, 16)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(229, 21)
        Me.txtSaldo.TabIndex = 85
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoTransaksi
        '
        Me.txtNoTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoTransaksi.Location = New System.Drawing.Point(154, 16)
        Me.txtNoTransaksi.Name = "txtNoTransaksi"
        Me.txtNoTransaksi.ReadOnly = True
        Me.txtNoTransaksi.Size = New System.Drawing.Size(229, 22)
        Me.txtNoTransaksi.TabIndex = 84
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(250, 21)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(29, 27)
        Me.SimpleButton1.TabIndex = 91
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Keterangan, Me.NamaAcc, Me.Debet, Me.Kredit})
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(0, 168)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(1153, 474)
        Me.DGV.TabIndex = 71
        '
        'Keterangan
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Keterangan.DefaultCellStyle = DataGridViewCellStyle1
        Me.Keterangan.HeaderText = "Kode Akun"
        Me.Keterangan.Name = "Keterangan"
        '
        'NamaAcc
        '
        Me.NamaAcc.HeaderText = "Nama Akun"
        Me.NamaAcc.Name = "NamaAcc"
        Me.NamaAcc.ReadOnly = True
        '
        'Debet
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Debet.DefaultCellStyle = DataGridViewCellStyle2
        Me.Debet.HeaderText = "Keterangan Rincian"
        Me.Debet.Name = "Debet"
        '
        'Kredit
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.Format = "C0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Kredit.DefaultCellStyle = DataGridViewCellStyle3
        Me.Kredit.HeaderText = "Total"
        Me.Kredit.Name = "Kredit"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 27)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Nomor Transaksi"
        '
        'cbAkun
        '
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.Location = New System.Drawing.Point(548, 16)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(229, 21)
        Me.cbAkun.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(400, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 27)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Keluar dari Akun"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtptanggal
        '
        Me.dtptanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptanggal.Location = New System.Drawing.Point(154, 47)
        Me.dtptanggal.Name = "dtptanggal"
        Me.dtptanggal.Size = New System.Drawing.Size(140, 22)
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
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.lookUpEdit)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.txtTotal)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 110)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1153, 58)
        Me.GroupControl1.TabIndex = 70
        Me.GroupControl1.Text = "Untuk Dana:"
        '
        'lookUpEdit
        '
        Me.lookUpEdit.Location = New System.Drawing.Point(5, 23)
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
        Me.lookUpEdit.Size = New System.Drawing.Size(239, 24)
        Me.lookUpEdit.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(843, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 34)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Total"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTotal
        '
        Me.txtTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(922, 22)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(229, 21)
        Me.txtTotal.TabIndex = 95
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.PanelControl2.TabIndex = 69
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.txtJumlah)
        Me.PanelControl1.Controls.Add(Me.txtSaldoHide)
        Me.PanelControl1.Controls.Add(Me.txtTotalHide)
        Me.PanelControl1.Controls.Add(Me.Label6)
        Me.PanelControl1.Controls.Add(Me.txtKeterangan)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.txtSaldo)
        Me.PanelControl1.Controls.Add(Me.txtNoTransaksi)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.cbAkun)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.dtptanggal)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1153, 110)
        Me.PanelControl1.TabIndex = 68
        '
        'txtJumlah
        '
        Me.txtJumlah.EditValue = ""
        Me.txtJumlah.Location = New System.Drawing.Point(548, 45)
        Me.txtJumlah.Name = "txtJumlah"
        Me.txtJumlah.Properties.Appearance.BackColor = System.Drawing.Color.LightCoral
        Me.txtJumlah.Properties.Appearance.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJumlah.Properties.Appearance.Options.UseBackColor = True
        Me.txtJumlah.Properties.Appearance.Options.UseFont = True
        Me.txtJumlah.Properties.Appearance.Options.UseTextOptions = True
        Me.txtJumlah.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtJumlah.Properties.Mask.BeepOnError = True
        Me.txtJumlah.Properties.Mask.EditMask = "n0"
        Me.txtJumlah.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtJumlah.Properties.Mask.PlaceHolder = Global.Microsoft.VisualBasic.ChrW(48)
        Me.txtJumlah.Properties.NullText = "0"
        Me.txtJumlah.Properties.NullValuePrompt = "0"
        Me.txtJumlah.Size = New System.Drawing.Size(229, 24)
        Me.txtJumlah.TabIndex = 97
        '
        'TambahKasKeluar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 706)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TambahKasKeluar"
        Me.Text = "TambahKasKeluar"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.txtJumlah.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSaldoHide As TextBox
    Friend WithEvents txtTotalHide As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtKeterangan As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents txtNoTransaksi As TextBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DGV As DataGridView
    Friend WithEvents Keterangan As DataGridViewTextBoxColumn
    Friend WithEvents NamaAcc As DataGridViewTextBoxColumn
    Friend WithEvents Debet As DataGridViewTextBoxColumn
    Friend WithEvents Kredit As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents cbAkun As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtptanggal As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtJumlah As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lookUpEdit As DevExpress.XtraEditors.LookUpEdit
End Class
