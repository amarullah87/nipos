<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistoryPenjualan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistoryPenjualan))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbFromNHS = New System.Windows.Forms.CheckBox()
        Me.lookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtpTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNoTransaksi = New System.Windows.Forms.TextBox()
        Me.dtptanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnCetakUlang = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCetakFakturBesar = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGV = New System.Windows.Forms.DataGridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.cbFromNHS)
        Me.PanelControl1.Controls.Add(Me.lookUpEdit)
        Me.PanelControl1.Controls.Add(Me.dtpTanggalAkhir)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.btnSimpan)
        Me.PanelControl1.Controls.Add(Me.txtNoTransaksi)
        Me.PanelControl1.Controls.Add(Me.dtptanggal)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1257, 127)
        Me.PanelControl1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(95, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(357, 27)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "** Faktur, Keterangan, Nama Barang"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 27)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Member/ NHs"
        '
        'cbFromNHS
        '
        Me.cbFromNHS.AutoSize = True
        Me.cbFromNHS.Location = New System.Drawing.Point(349, 41)
        Me.cbFromNHS.Name = "cbFromNHS"
        Me.cbFromNHS.Size = New System.Drawing.Size(68, 17)
        Me.cbFromNHS.TabIndex = 97
        Me.cbFromNHS.Text = "List NHS"
        Me.cbFromNHS.UseVisualStyleBackColor = True
        '
        'lookUpEdit
        '
        Me.lookUpEdit.Location = New System.Drawing.Point(95, 37)
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
        Me.lookUpEdit.Size = New System.Drawing.Size(248, 24)
        Me.lookUpEdit.TabIndex = 96
        '
        'dtpTanggalAkhir
        '
        Me.dtpTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalAkhir.Location = New System.Drawing.Point(317, 8)
        Me.dtpTanggalAkhir.Name = "dtpTanggalAkhir"
        Me.dtpTanggalAkhir.Size = New System.Drawing.Size(135, 22)
        Me.dtpTanggalAkhir.TabIndex = 38
        Me.dtpTanggalAkhir.Value = New Date(2021, 3, 14, 23, 36, 18, 0)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(236, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 27)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Tanggal Akhir"
        '
        'btnSimpan
        '
        Me.btnSimpan.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.btnSimpan.ImageOptions.Image = CType(resources.GetObject("btnSimpan.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSimpan.Location = New System.Drawing.Point(458, 63)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(37, 35)
        Me.btnSimpan.TabIndex = 36
        '
        'txtNoTransaksi
        '
        Me.txtNoTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoTransaksi.Location = New System.Drawing.Point(95, 71)
        Me.txtNoTransaksi.Name = "txtNoTransaksi"
        Me.txtNoTransaksi.Size = New System.Drawing.Size(357, 22)
        Me.txtNoTransaksi.TabIndex = 3
        '
        'dtptanggal
        '
        Me.dtptanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptanggal.Location = New System.Drawing.Point(95, 8)
        Me.dtptanggal.Name = "dtptanggal"
        Me.dtptanggal.Size = New System.Drawing.Size(135, 22)
        Me.dtptanggal.TabIndex = 5
        Me.dtptanggal.Value = New Date(2021, 3, 14, 23, 36, 27, 0)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 27)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tanggal Awal"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 27)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Pencarian"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.SimpleButton3)
        Me.PanelControl2.Controls.Add(Me.SimpleButton2)
        Me.PanelControl2.Controls.Add(Me.lblTotal)
        Me.PanelControl2.Controls.Add(Me.btnRefresh)
        Me.PanelControl2.Controls.Add(Me.btnTutup)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 618)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1257, 66)
        Me.PanelControl2.TabIndex = 1
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(206, 15)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(105, 35)
        Me.SimpleButton3.TabIndex = 128
        Me.SimpleButton3.Text = "Export to CSV"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(110, 15)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(90, 35)
        Me.SimpleButton2.TabIndex = 52
        Me.SimpleButton2.Text = "Detail"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTotal.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(1092, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(165, 39)
        Me.lblTotal.TabIndex = 43
        Me.lblTotal.Text = "Total: Rp. 0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRefresh
        '
        Me.btnRefresh.ImageOptions.Image = CType(resources.GetObject("btnRefresh.ImageOptions.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(15, 15)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 35)
        Me.btnRefresh.TabIndex = 41
        Me.btnRefresh.Text = "Refresh"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(317, 15)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 40
        Me.btnTutup.Text = "Tutup"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCetakUlang, Me.btnCetakFakturBesar})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(176, 56)
        '
        'btnCetakUlang
        '
        Me.btnCetakUlang.Image = CType(resources.GetObject("btnCetakUlang.Image"), System.Drawing.Image)
        Me.btnCetakUlang.Name = "btnCetakUlang"
        Me.btnCetakUlang.Size = New System.Drawing.Size(175, 26)
        Me.btnCetakUlang.Text = "Cetak Ulang Struk"
        '
        'btnCetakFakturBesar
        '
        Me.btnCetakFakturBesar.Image = CType(resources.GetObject("btnCetakFakturBesar.Image"), System.Drawing.Image)
        Me.btnCetakFakturBesar.Name = "btnCetakFakturBesar"
        Me.btnCetakFakturBesar.Size = New System.Drawing.Size(175, 26)
        Me.btnCetakFakturBesar.Text = "Cetak Faktur Besar"
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
        Me.DGV.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(0, 127)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.Size = New System.Drawing.Size(1257, 491)
        Me.DGV.TabIndex = 20
        '
        'HistoryPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1257, 684)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HistoryPenjualan"
        Me.Text = "History Penjualan"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtNoTransaksi As TextBox
    Friend WithEvents dtptanggal As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTotal As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents btnCetakUlang As ToolStripMenuItem
    Friend WithEvents DGV As DataGridView
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtpTanggalAkhir As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents cbFromNHS As CheckBox
    Friend WithEvents btnCetakFakturBesar As ToolStripMenuItem
    Friend WithEvents Label5 As Label
End Class
