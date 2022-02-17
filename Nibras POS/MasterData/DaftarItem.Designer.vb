<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DaftarItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DaftarItem))
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.btnDiscUmur = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.panelItemBaru = New DevExpress.XtraEditors.PanelControl()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BTNTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TXTCariBarang = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DGVX = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DGV = New System.Windows.Forms.DataGridView()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.panelItemBaru, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelItemBaru.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TXTCariBarang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl2
        '
        Me.GroupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.GroupControl2.Controls.Add(Me.btnDiscUmur)
        Me.GroupControl2.Controls.Add(Me.SimpleButton3)
        Me.GroupControl2.Controls.Add(Me.SimpleButton1)
        Me.GroupControl2.Controls.Add(Me.panelItemBaru)
        Me.GroupControl2.Controls.Add(Me.BTNTutup)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl2.Location = New System.Drawing.Point(0, 541)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1104, 52)
        Me.GroupControl2.TabIndex = 4
        '
        'btnDiscUmur
        '
        Me.btnDiscUmur.ImageOptions.Image = CType(resources.GetObject("btnDiscUmur.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDiscUmur.Location = New System.Drawing.Point(229, 10)
        Me.btnDiscUmur.Name = "btnDiscUmur"
        Me.btnDiscUmur.Size = New System.Drawing.Size(99, 35)
        Me.btnDiscUmur.TabIndex = 128
        Me.btnDiscUmur.Text = "Diskon Umur"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(118, 10)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(105, 35)
        Me.SimpleButton3.TabIndex = 127
        Me.SimpleButton3.Text = "Export to CSV"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(5, 10)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(107, 35)
        Me.SimpleButton1.TabIndex = 7
        Me.SimpleButton1.Text = "Download Item"
        '
        'panelItemBaru
        '
        Me.panelItemBaru.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelItemBaru.Controls.Add(Me.btnAdd)
        Me.panelItemBaru.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelItemBaru.Location = New System.Drawing.Point(904, 0)
        Me.panelItemBaru.Name = "panelItemBaru"
        Me.panelItemBaru.Size = New System.Drawing.Size(200, 52)
        Me.panelItemBaru.TabIndex = 6
        '
        'btnAdd
        '
        Me.btnAdd.ImageOptions.Image = CType(resources.GetObject("btnAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(43, 10)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(145, 35)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Item Baru non Nibras"
        '
        'BTNTutup
        '
        Me.BTNTutup.ImageOptions.Image = CType(resources.GetObject("BTNTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.BTNTutup.Location = New System.Drawing.Point(334, 10)
        Me.BTNTutup.Name = "BTNTutup"
        Me.BTNTutup.Size = New System.Drawing.Size(90, 35)
        Me.BTNTutup.TabIndex = 0
        Me.BTNTutup.Text = "Tutup"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TXTCariBarang)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1104, 51)
        Me.PanelControl1.TabIndex = 6
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(435, 19)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(107, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "( F12 Download Item )"
        '
        'TXTCariBarang
        '
        Me.TXTCariBarang.Location = New System.Drawing.Point(144, 16)
        Me.TXTCariBarang.Name = "TXTCariBarang"
        Me.TXTCariBarang.Size = New System.Drawing.Size(285, 20)
        Me.TXTCariBarang.TabIndex = 7
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(133, 13)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "Cari Nama Barang/ Kategori"
        '
        'DGVX
        '
        Me.DGVX.Location = New System.Drawing.Point(704, 322)
        Me.DGVX.MainView = Me.GridView1
        Me.DGVX.Name = "DGVX"
        Me.DGVX.Size = New System.Drawing.Size(400, 200)
        Me.DGVX.TabIndex = 7
        Me.DGVX.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DGVX
        Me.GridView1.Name = "GridView1"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
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
        Me.DGV.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.Size = New System.Drawing.Size(1104, 490)
        Me.DGV.TabIndex = 20
        '
        'DaftarItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 593)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.DGVX)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DaftarItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Daftar Item"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.panelItemBaru, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelItemBaru.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TXTCariBarang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BTNTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TXTCariBarang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents panelItemBaru As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DGVX As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DGV As DataGridView
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDiscUmur As DevExpress.XtraEditors.SimpleButton
End Class
