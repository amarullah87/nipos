<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadMember
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DownloadMember))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.txtTotalData = New DevExpress.XtraEditors.LabelControl()
        Me.TXTCariBarang = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.txtResponse = New System.Windows.Forms.TextBox()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDownload = New DevExpress.XtraEditors.SimpleButton()
        Me.BTNTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HPP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HPJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TXTCariBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.txtTotalData)
        Me.PanelControl1.Controls.Add(Me.TXTCariBarang)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(862, 43)
        Me.PanelControl1.TabIndex = 18
        '
        'txtTotalData
        '
        Me.txtTotalData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalData.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalData.Appearance.Options.UseFont = True
        Me.txtTotalData.Location = New System.Drawing.Point(766, 13)
        Me.txtTotalData.Name = "txtTotalData"
        Me.txtTotalData.Size = New System.Drawing.Size(84, 16)
        Me.txtTotalData.TabIndex = 10
        Me.txtTotalData.Text = "Total: 0 Data"
        '
        'TXTCariBarang
        '
        Me.TXTCariBarang.Location = New System.Drawing.Point(138, 9)
        Me.TXTCariBarang.Name = "TXTCariBarang"
        Me.TXTCariBarang.Size = New System.Drawing.Size(285, 20)
        Me.TXTCariBarang.TabIndex = 9
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(120, 13)
        Me.LabelControl1.TabIndex = 8
        Me.LabelControl1.Text = "Cari / Scan Kode Member"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.txtResponse)
        Me.PanelControl2.Controls.Add(Me.btnClear)
        Me.PanelControl2.Controls.Add(Me.btnDownload)
        Me.PanelControl2.Controls.Add(Me.BTNTutup)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 603)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(862, 63)
        Me.PanelControl2.TabIndex = 19
        '
        'txtResponse
        '
        Me.txtResponse.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtResponse.ForeColor = System.Drawing.Color.Transparent
        Me.txtResponse.Location = New System.Drawing.Point(650, 0)
        Me.txtResponse.Multiline = True
        Me.txtResponse.Name = "txtResponse"
        Me.txtResponse.Size = New System.Drawing.Size(212, 63)
        Me.txtResponse.TabIndex = 5
        '
        'btnClear
        '
        Me.btnClear.ImageOptions.Image = CType(resources.GetObject("btnClear.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(121, 14)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 35)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        '
        'btnDownload
        '
        Me.btnDownload.ImageOptions.Image = CType(resources.GetObject("btnDownload.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDownload.Location = New System.Drawing.Point(12, 14)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(103, 35)
        Me.btnDownload.TabIndex = 2
        Me.btnDownload.Text = "Download All"
        '
        'BTNTutup
        '
        Me.BTNTutup.ImageOptions.Image = CType(resources.GetObject("BTNTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.BTNTutup.Location = New System.Drawing.Point(217, 14)
        Me.BTNTutup.Name = "BTNTutup"
        Me.BTNTutup.Size = New System.Drawing.Size(90, 35)
        Me.BTNTutup.TabIndex = 1
        Me.BTNTutup.Text = "Tutup"
        '
        'DGV
        '
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Kode, Me.Barcode, Me.Nama, Me.HPP, Me.HPJ})
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.Location = New System.Drawing.Point(0, 43)
        Me.DGV.Name = "DGV"
        Me.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DGV.RowTemplate.Height = 30
        Me.DGV.Size = New System.Drawing.Size(862, 560)
        Me.DGV.TabIndex = 21
        '
        'Kode
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kode.DefaultCellStyle = DataGridViewCellStyle2
        Me.Kode.HeaderText = "Kode Member"
        Me.Kode.Name = "Kode"
        '
        'Barcode
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Barcode.DefaultCellStyle = DataGridViewCellStyle3
        Me.Barcode.HeaderText = "Outlet Terdaftar"
        Me.Barcode.Name = "Barcode"
        '
        'Nama
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nama.DefaultCellStyle = DataGridViewCellStyle4
        Me.Nama.HeaderText = "Nama Member"
        Me.Nama.Name = "Nama"
        '
        'HPP
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HPP.DefaultCellStyle = DataGridViewCellStyle5
        Me.HPP.HeaderText = "Alamat"
        Me.HPP.Name = "HPP"
        '
        'HPJ
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HPJ.DefaultCellStyle = DataGridViewCellStyle6
        Me.HPJ.HeaderText = "Telp/ HP"
        Me.HPJ.Name = "HPJ"
        '
        'DownloadMember
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 666)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DownloadMember"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Download Member"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TXTCariBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtTotalData As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TXTCariBarang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtResponse As TextBox
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDownload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTNTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents DGV As DataGridView
    Friend WithEvents Kode As DataGridViewTextBoxColumn
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents HPP As DataGridViewTextBoxColumn
    Friend WithEvents HPJ As DataGridViewTextBoxColumn
End Class
