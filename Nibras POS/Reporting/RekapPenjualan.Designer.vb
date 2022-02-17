<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RekapPenjualan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RekapPenjualan))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DTPBulanan = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DTPHarian = New System.Windows.Forms.DateTimePicker()
        Me.CRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbFromNHS = New System.Windows.Forms.CheckBox()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.GroupBox3)
        Me.PanelControl1.Controls.Add(Me.btnBatal)
        Me.PanelControl1.Controls.Add(Me.btnTutup)
        Me.PanelControl1.Controls.Add(Me.GroupBox2)
        Me.PanelControl1.Controls.Add(Me.GroupBox1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1025, 60)
        Me.PanelControl1.TabIndex = 6
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(480, 16)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 42
        Me.btnBatal.Text = "Preview"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(576, 16)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 41
        Me.btnTutup.Text = "Tutup"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTPBulanan)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox2.Location = New System.Drawing.Point(186, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(160, 60)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tanggal Akhir"
        '
        'DTPBulanan
        '
        Me.DTPBulanan.CustomFormat = "MMMM yyyy"
        Me.DTPBulanan.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPBulanan.Location = New System.Drawing.Point(5, 21)
        Me.DTPBulanan.Name = "DTPBulanan"
        Me.DTPBulanan.Size = New System.Drawing.Size(143, 21)
        Me.DTPBulanan.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DTPHarian)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 60)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tanggal Awal"
        '
        'DTPHarian
        '
        Me.DTPHarian.CustomFormat = "dd MMMM yyyy"
        Me.DTPHarian.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPHarian.Location = New System.Drawing.Point(10, 21)
        Me.DTPHarian.Name = "DTPHarian"
        Me.DTPHarian.Size = New System.Drawing.Size(161, 21)
        Me.DTPHarian.TabIndex = 0
        Me.DTPHarian.Value = New Date(2020, 1, 1, 0, 0, 0, 0)
        '
        'CRV
        '
        Me.CRV.ActiveViewIndex = -1
        Me.CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV.Location = New System.Drawing.Point(0, 60)
        Me.CRV.Name = "CRV"
        Me.CRV.Size = New System.Drawing.Size(1025, 649)
        Me.CRV.TabIndex = 8
        Me.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbFromNHS)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox3.Location = New System.Drawing.Point(346, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(128, 60)
        Me.GroupBox3.TabIndex = 44
        Me.GroupBox3.TabStop = False
        '
        'cbFromNHS
        '
        Me.cbFromNHS.AutoSize = True
        Me.cbFromNHS.Location = New System.Drawing.Point(6, 26)
        Me.cbFromNHS.Name = "cbFromNHS"
        Me.cbFromNHS.Size = New System.Drawing.Size(121, 17)
        Me.cbFromNHS.TabIndex = 98
        Me.cbFromNHS.Text = "Tampilkan Data NHs"
        Me.cbFromNHS.UseVisualStyleBackColor = True
        '
        'RekapPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 709)
        Me.Controls.Add(Me.CRV)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "RekapPenjualan"
        Me.Text = "Rekap Penjualan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DTPBulanan As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DTPHarian As DateTimePicker
    Friend WithEvents CRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbFromNHS As CheckBox
End Class
