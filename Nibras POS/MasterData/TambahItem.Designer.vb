<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TambahItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TambahItem))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BTNTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.txtStokMin = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtHpj = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtHpp = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbMerek = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbSatuan = New System.Windows.Forms.ComboBox()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKodeItem = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.btnBatal)
        Me.PanelControl2.Controls.Add(Me.SimpleButton1)
        Me.PanelControl2.Controls.Add(Me.BTNTutup)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 246)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(594, 63)
        Me.PanelControl2.TabIndex = 3
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(108, 16)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 50
        Me.btnBatal.Text = "Batal"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 16)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(90, 35)
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "Simpan"
        '
        'BTNTutup
        '
        Me.BTNTutup.ImageOptions.Image = CType(resources.GetObject("BTNTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.BTNTutup.Location = New System.Drawing.Point(204, 16)
        Me.BTNTutup.Name = "BTNTutup"
        Me.BTNTutup.Size = New System.Drawing.Size(90, 35)
        Me.BTNTutup.TabIndex = 1
        Me.BTNTutup.Text = "Tutup"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.btnRefresh)
        Me.PanelControl1.Controls.Add(Me.txtStokMin)
        Me.PanelControl1.Controls.Add(Me.Label8)
        Me.PanelControl1.Controls.Add(Me.txtHpj)
        Me.PanelControl1.Controls.Add(Me.Label7)
        Me.PanelControl1.Controls.Add(Me.txtHpp)
        Me.PanelControl1.Controls.Add(Me.Label6)
        Me.PanelControl1.Controls.Add(Me.cbMerek)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.cbSatuan)
        Me.PanelControl1.Controls.Add(Me.txtNama)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.txtBarcode)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.txtKodeItem)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(594, 246)
        Me.PanelControl1.TabIndex = 4
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(379, 128)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(59, 23)
        Me.btnRefresh.TabIndex = 96
        Me.btnRefresh.Text = "Refresh"
        '
        'txtStokMin
        '
        Me.txtStokMin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStokMin.Location = New System.Drawing.Point(135, 209)
        Me.txtStokMin.Name = "txtStokMin"
        Me.txtStokMin.Size = New System.Drawing.Size(63, 21)
        Me.txtStokMin.TabIndex = 94
        Me.txtStokMin.Text = "0"
        Me.txtStokMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 207)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 23)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "Stok Minimum"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHpj
        '
        Me.txtHpj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHpj.Location = New System.Drawing.Point(135, 182)
        Me.txtHpj.Name = "txtHpj"
        Me.txtHpj.Size = New System.Drawing.Size(185, 21)
        Me.txtHpj.TabIndex = 92
        Me.txtHpj.Text = "0"
        Me.txtHpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 23)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Harga Jual"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHpp
        '
        Me.txtHpp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHpp.Location = New System.Drawing.Point(135, 155)
        Me.txtHpp.Name = "txtHpp"
        Me.txtHpp.Size = New System.Drawing.Size(185, 21)
        Me.txtHpp.TabIndex = 90
        Me.txtHpp.Text = "0"
        Me.txtHpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 23)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Harga Pokok"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbMerek
        '
        Me.cbMerek.FormattingEnabled = True
        Me.cbMerek.Location = New System.Drawing.Point(135, 128)
        Me.cbMerek.Name = "cbMerek"
        Me.cbMerek.Size = New System.Drawing.Size(238, 21)
        Me.cbMerek.TabIndex = 89
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 23)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Merek"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 23)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Satuan"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbSatuan
        '
        Me.cbSatuan.FormattingEnabled = True
        Me.cbSatuan.Items.AddRange(New Object() {"pcs", "lusin", "kodi", "box", "bungkus"})
        Me.cbSatuan.Location = New System.Drawing.Point(135, 101)
        Me.cbSatuan.Name = "cbSatuan"
        Me.cbSatuan.Size = New System.Drawing.Size(99, 21)
        Me.cbSatuan.TabIndex = 85
        '
        'txtNama
        '
        Me.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNama.Location = New System.Drawing.Point(135, 74)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(238, 21)
        Me.txtNama.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 23)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Nama Item"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcode
        '
        Me.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcode.Location = New System.Drawing.Point(135, 47)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(185, 21)
        Me.txtBarcode.TabIndex = 61
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 23)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Barcode"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKodeItem
        '
        Me.txtKodeItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKodeItem.Location = New System.Drawing.Point(135, 20)
        Me.txtKodeItem.Name = "txtKodeItem"
        Me.txtKodeItem.Size = New System.Drawing.Size(185, 21)
        Me.txtKodeItem.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 23)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Kode Item"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TambahItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 309)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TambahItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tambah Item Non-Nibras"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BTNTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtNama As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtKodeItem As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStokMin As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtHpj As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtHpp As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbMerek As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbSatuan As ComboBox
    Friend WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
End Class
