<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MasterSupplier
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterSupplier))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDownloadDB = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImport = New DevExpress.XtraEditors.SimpleButton()
        Me.btnbatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnhapus = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btntutup = New DevExpress.XtraEditors.SimpleButton()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.txtcontact = New System.Windows.Forms.TextBox()
        Me.txtfax = New System.Windows.Forms.TextBox()
        Me.txttelepon = New System.Windows.Forms.TextBox()
        Me.txtalamat = New System.Windows.Forms.TextBox()
        Me.txtnamasupplier = New System.Windows.Forms.TextBox()
        Me.txtkodesupplier = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.txtcaridata = New System.Windows.Forms.TextBox()
        Me.txtCari = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Nibras_POS.WaitFormLoading), True, True)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.txtCari.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Panel1)
        Me.PanelControl1.Controls.Add(Me.btnImport)
        Me.PanelControl1.Controls.Add(Me.btnbatal)
        Me.PanelControl1.Controls.Add(Me.btnhapus)
        Me.PanelControl1.Controls.Add(Me.btnSimpan)
        Me.PanelControl1.Controls.Add(Me.btntutup)
        Me.PanelControl1.Controls.Add(Me.txtemail)
        Me.PanelControl1.Controls.Add(Me.txtcontact)
        Me.PanelControl1.Controls.Add(Me.txtfax)
        Me.PanelControl1.Controls.Add(Me.txttelepon)
        Me.PanelControl1.Controls.Add(Me.txtalamat)
        Me.PanelControl1.Controls.Add(Me.txtnamasupplier)
        Me.PanelControl1.Controls.Add(Me.txtkodesupplier)
        Me.PanelControl1.Controls.Add(Me.Label7)
        Me.PanelControl1.Controls.Add(Me.Label6)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 555)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1203, 55)
        Me.PanelControl1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SimpleButton3)
        Me.Panel1.Controls.Add(Me.btnDownloadDB)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(928, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(273, 51)
        Me.Panel1.TabIndex = 78
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(158, 7)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(105, 35)
        Me.SimpleButton3.TabIndex = 128
        Me.SimpleButton3.Text = "Export to CSV"
        '
        'btnDownloadDB
        '
        Me.btnDownloadDB.ImageOptions.Image = CType(resources.GetObject("btnDownloadDB.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDownloadDB.Location = New System.Drawing.Point(35, 7)
        Me.btnDownloadDB.Name = "btnDownloadDB"
        Me.btnDownloadDB.Size = New System.Drawing.Size(117, 35)
        Me.btnDownloadDB.TabIndex = 74
        Me.btnDownloadDB.Text = "Download Master"
        '
        'btnImport
        '
        Me.btnImport.ImageOptions.Image = CType(resources.GetObject("btnImport.ImageOptions.Image"), System.Drawing.Image)
        Me.btnImport.Location = New System.Drawing.Point(536, 133)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(90, 35)
        Me.btnImport.TabIndex = 77
        Me.btnImport.Text = "Import"
        '
        'btnbatal
        '
        Me.btnbatal.ImageOptions.Image = CType(resources.GetObject("btnbatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnbatal.Location = New System.Drawing.Point(15, 9)
        Me.btnbatal.Name = "btnbatal"
        Me.btnbatal.Size = New System.Drawing.Size(90, 35)
        Me.btnbatal.TabIndex = 76
        Me.btnbatal.Text = "Refresh"
        '
        'btnhapus
        '
        Me.btnhapus.ImageOptions.Image = CType(resources.GetObject("btnhapus.ImageOptions.Image"), System.Drawing.Image)
        Me.btnhapus.Location = New System.Drawing.Point(236, 133)
        Me.btnhapus.Name = "btnhapus"
        Me.btnhapus.Size = New System.Drawing.Size(90, 35)
        Me.btnhapus.TabIndex = 75
        Me.btnhapus.Text = "Hapus"
        '
        'btnSimpan
        '
        Me.btnSimpan.ImageOptions.Image = CType(resources.GetObject("btnSimpan.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(136, 133)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 74
        Me.btnSimpan.Text = "Simpan"
        '
        'btntutup
        '
        Me.btntutup.ImageOptions.Image = CType(resources.GetObject("btntutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btntutup.Location = New System.Drawing.Point(115, 9)
        Me.btntutup.Name = "btntutup"
        Me.btntutup.Size = New System.Drawing.Size(90, 35)
        Me.btntutup.TabIndex = 73
        Me.btntutup.Text = "Tutup"
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(536, 96)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(232, 22)
        Me.txtemail.TabIndex = 63
        Me.txtemail.Visible = False
        '
        'txtcontact
        '
        Me.txtcontact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontact.Location = New System.Drawing.Point(136, 96)
        Me.txtcontact.Name = "txtcontact"
        Me.txtcontact.Size = New System.Drawing.Size(140, 22)
        Me.txtcontact.TabIndex = 65
        Me.txtcontact.Visible = False
        '
        'txtfax
        '
        Me.txtfax.Location = New System.Drawing.Point(536, 67)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(232, 22)
        Me.txtfax.TabIndex = 62
        Me.txtfax.Visible = False
        '
        'txttelepon
        '
        Me.txttelepon.Location = New System.Drawing.Point(536, 38)
        Me.txttelepon.Name = "txttelepon"
        Me.txttelepon.Size = New System.Drawing.Size(232, 22)
        Me.txttelepon.TabIndex = 60
        Me.txttelepon.Visible = False
        '
        'txtalamat
        '
        Me.txtalamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtalamat.Location = New System.Drawing.Point(136, 67)
        Me.txtalamat.Name = "txtalamat"
        Me.txtalamat.Size = New System.Drawing.Size(307, 22)
        Me.txtalamat.TabIndex = 57
        Me.txtalamat.Visible = False
        '
        'txtnamasupplier
        '
        Me.txtnamasupplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnamasupplier.Location = New System.Drawing.Point(136, 38)
        Me.txtnamasupplier.Name = "txtnamasupplier"
        Me.txtnamasupplier.Size = New System.Drawing.Size(307, 22)
        Me.txtnamasupplier.TabIndex = 55
        Me.txtnamasupplier.Visible = False
        '
        'txtkodesupplier
        '
        Me.txtkodesupplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtkodesupplier.Location = New System.Drawing.Point(136, 9)
        Me.txtkodesupplier.Name = "txtkodesupplier"
        Me.txtkodesupplier.Size = New System.Drawing.Size(140, 22)
        Me.txtkodesupplier.TabIndex = 53
        Me.txtkodesupplier.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 23)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Contact Person"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(449, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 23)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Email"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(449, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 23)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Fax"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(449, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 23)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Telepon"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 23)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Alamat"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 23)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Nama"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 23)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Kode"
        Me.Label1.Visible = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.txtcaridata)
        Me.PanelControl2.Controls.Add(Me.txtCari)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1203, 51)
        Me.PanelControl2.TabIndex = 7
        '
        'txtcaridata
        '
        Me.txtcaridata.Location = New System.Drawing.Point(523, 8)
        Me.txtcaridata.Multiline = True
        Me.txtcaridata.Name = "txtcaridata"
        Me.txtcaridata.Size = New System.Drawing.Size(157, 38)
        Me.txtcaridata.TabIndex = 72
        Me.txtcaridata.Visible = False
        '
        'txtCari
        '
        Me.txtCari.Location = New System.Drawing.Point(115, 16)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(285, 20)
        Me.txtCari.TabIndex = 7
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(7, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "Cari Nama Supplier"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(0, 51)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.Size = New System.Drawing.Size(1203, 504)
        Me.DGV.TabIndex = 8
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'MasterSupplier
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1203, 610)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MasterSupplier"
        Me.Text = "Master Supplier Nibras"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.txtCari.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtemail As TextBox
    Friend WithEvents txtcontact As TextBox
    Friend WithEvents txtfax As TextBox
    Friend WithEvents txttelepon As TextBox
    Friend WithEvents txtalamat As TextBox
    Friend WithEvents txtnamasupplier As TextBox
    Friend WithEvents txtkodesupplier As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnbatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnhapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btntutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtCari As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DGV As DataGridView
    Friend WithEvents txtcaridata As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDownloadDB As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
End Class
