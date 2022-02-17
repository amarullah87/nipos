<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportLabaRugi
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportLabaRugi))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpYTD = New System.Windows.Forms.DateTimePicker()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DTPBulanan = New System.Windows.Forms.DateTimePicker()
        Me.CRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ReportGenerator1 = New DevExpress.XtraReports.ReportGeneration.ReportGenerator(Me.components)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.GroupBox2)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Controls.Add(Me.btnBatal)
        Me.PanelControl1.Controls.Add(Me.btnTutup)
        Me.PanelControl1.Controls.Add(Me.GroupBox1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(952, 63)
        Me.PanelControl1.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpYTD)
        Me.GroupBox2.Location = New System.Drawing.Point(359, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(185, 52)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periode"
        '
        'dtpYTD
        '
        Me.dtpYTD.CustomFormat = "dd/MM/yyyy"
        Me.dtpYTD.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpYTD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpYTD.Location = New System.Drawing.Point(3, 17)
        Me.dtpYTD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpYTD.Name = "dtpYTD"
        Me.dtpYTD.ShowUpDown = True
        Me.dtpYTD.Size = New System.Drawing.Size(179, 21)
        Me.dtpYTD.TabIndex = 1
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(550, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(90, 35)
        Me.SimpleButton1.TabIndex = 45
        Me.SimpleButton1.Text = "YTD"
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(191, 12)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(162, 35)
        Me.btnBatal.TabIndex = 42
        Me.btnBatal.Text = "Current Month"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(646, 12)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 41
        Me.btnTutup.Text = "Tutup"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DTPBulanan)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 55)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periode"
        '
        'DTPBulanan
        '
        Me.DTPBulanan.CustomFormat = "MMMM yyyy"
        Me.DTPBulanan.Dock = System.Windows.Forms.DockStyle.Top
        Me.DTPBulanan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPBulanan.Location = New System.Drawing.Point(3, 17)
        Me.DTPBulanan.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DTPBulanan.Name = "DTPBulanan"
        Me.DTPBulanan.ShowUpDown = True
        Me.DTPBulanan.Size = New System.Drawing.Size(179, 21)
        Me.DTPBulanan.TabIndex = 1
        '
        'CRV
        '
        Me.CRV.ActiveViewIndex = -1
        Me.CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV.Location = New System.Drawing.Point(0, 63)
        Me.CRV.Name = "CRV"
        Me.CRV.Size = New System.Drawing.Size(952, 673)
        Me.CRV.TabIndex = 7
        Me.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReportLabaRugi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 736)
        Me.Controls.Add(Me.CRV)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ReportLabaRugi"
        Me.Text = "Laba Rugi"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DTPBulanan As DateTimePicker
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtpYTD As DateTimePicker
    Friend WithEvents CRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ReportGenerator1 As DevExpress.XtraReports.ReportGeneration.ReportGenerator
End Class
