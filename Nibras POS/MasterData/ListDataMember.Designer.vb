<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListDataMember
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListDataMember))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.LookUpEditBulan = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.lookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTotalMember = New System.Windows.Forms.Label()
        Me.txtCariMember = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.txtTotalDetail = New System.Windows.Forms.Label()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.BTNTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMemberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGV = New System.Windows.Forms.DataGridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LookUpEditBulan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtCariMember.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton5)
        Me.PanelControl1.Controls.Add(Me.LookUpEditBulan)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.lookUpEdit)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.Panel1)
        Me.PanelControl1.Controls.Add(Me.txtCariMember)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1160, 106)
        Me.PanelControl1.TabIndex = 1
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Location = New System.Drawing.Point(337, 69)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(73, 21)
        Me.SimpleButton5.TabIndex = 100
        Me.SimpleButton5.Text = "Reset"
        '
        'LookUpEditBulan
        '
        Me.LookUpEditBulan.Location = New System.Drawing.Point(125, 66)
        Me.LookUpEditBulan.Name = "LookUpEditBulan"
        Me.LookUpEditBulan.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LookUpEditBulan.Properties.Appearance.Options.UseFont = True
        Me.LookUpEditBulan.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.Transparent
        Me.LookUpEditBulan.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LookUpEditBulan.Properties.AppearanceDropDown.Options.UseBorderColor = True
        Me.LookUpEditBulan.Properties.AppearanceDropDown.Options.UseFont = True
        Me.LookUpEditBulan.Properties.AppearanceDropDownHeader.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LookUpEditBulan.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.LookUpEditBulan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.LookUpEditBulan.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.LookUpEditBulan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEditBulan.Properties.DropDownRows = 10
        Me.LookUpEditBulan.Properties.NullText = ""
        Me.LookUpEditBulan.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LookUpEditBulan.Size = New System.Drawing.Size(206, 24)
        Me.LookUpEditBulan.TabIndex = 99
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 72)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl4.TabIndex = 98
        Me.LabelControl4.Text = "Bulan Lahir"
        '
        'lookUpEdit
        '
        Me.lookUpEdit.Location = New System.Drawing.Point(125, 36)
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
        Me.lookUpEdit.Size = New System.Drawing.Size(206, 24)
        Me.lookUpEdit.TabIndex = 97
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 42)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl3.TabIndex = 12
        Me.LabelControl3.Text = "Jenis Member"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(416, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(170, 13)
        Me.LabelControl2.TabIndex = 11
        Me.LabelControl2.Text = "( F12 Download Member Online )"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtTotalMember)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(882, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(276, 102)
        Me.Panel1.TabIndex = 10
        '
        'txtTotalMember
        '
        Me.txtTotalMember.AutoSize = True
        Me.txtTotalMember.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMember.Location = New System.Drawing.Point(141, 8)
        Me.txtTotalMember.Name = "txtTotalMember"
        Me.txtTotalMember.Size = New System.Drawing.Size(117, 16)
        Me.txtTotalMember.TabIndex = 0
        Me.txtTotalMember.Text = "Total Member : 0"
        Me.txtTotalMember.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCariMember
        '
        Me.txtCariMember.Location = New System.Drawing.Point(125, 9)
        Me.txtCariMember.Name = "txtCariMember"
        Me.txtCariMember.Size = New System.Drawing.Size(285, 20)
        Me.txtCariMember.TabIndex = 9
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(97, 13)
        Me.LabelControl1.TabIndex = 8
        Me.LabelControl1.Text = "Cari Nama Member"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.txtTotalDetail)
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Controls.Add(Me.SimpleButton1)
        Me.PanelControl2.Controls.Add(Me.btnClear)
        Me.PanelControl2.Controls.Add(Me.BTNTutup)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 516)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1160, 63)
        Me.PanelControl2.TabIndex = 2
        '
        'txtTotalDetail
        '
        Me.txtTotalDetail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDetail.Location = New System.Drawing.Point(300, 3)
        Me.txtTotalDetail.Name = "txtTotalDetail"
        Me.txtTotalDetail.Size = New System.Drawing.Size(715, 58)
        Me.txtTotalDetail.TabIndex = 7
        Me.txtTotalDetail.Text = "Total Member Reguler: 10 | Yours: 20 |"
        Me.txtTotalDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.SimpleButton4)
        Me.PanelControl3.Controls.Add(Me.SimpleButton3)
        Me.PanelControl3.Controls.Add(Me.SimpleButton2)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(780, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(378, 59)
        Me.PanelControl3.TabIndex = 6
        '
        'SimpleButton4
        '
        Me.SimpleButton4.ImageOptions.Image = CType(resources.GetObject("SimpleButton4.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(264, 12)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(105, 35)
        Me.SimpleButton4.TabIndex = 128
        Me.SimpleButton4.Text = "Export to CSV"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(168, 12)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(90, 35)
        Me.SimpleButton3.TabIndex = 126
        Me.SimpleButton3.Text = "Import"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(18, 12)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(144, 35)
        Me.SimpleButton2.TabIndex = 2
        Me.SimpleButton2.Text = "Setting Kelipatan Point"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 14)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(90, 35)
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "Group"
        '
        'btnClear
        '
        Me.btnClear.ImageOptions.Image = CType(resources.GetObject("btnClear.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(108, 14)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 35)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Member"
        '
        'BTNTutup
        '
        Me.BTNTutup.ImageOptions.Image = CType(resources.GetObject("BTNTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.BTNTutup.Location = New System.Drawing.Point(204, 14)
        Me.BTNTutup.Name = "BTNTutup"
        Me.BTNTutup.Size = New System.Drawing.Size(90, 35)
        Me.BTNTutup.TabIndex = 1
        Me.BTNTutup.Text = "Tutup"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEdit, Me.DeleteMemberToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(156, 48)
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(155, 22)
        Me.btnEdit.Text = "Edit Member"
        '
        'DeleteMemberToolStripMenuItem
        '
        Me.DeleteMemberToolStripMenuItem.Image = CType(resources.GetObject("DeleteMemberToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteMemberToolStripMenuItem.Name = "DeleteMemberToolStripMenuItem"
        Me.DeleteMemberToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.DeleteMemberToolStripMenuItem.Text = "Delete Member"
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
        Me.DGV.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(0, 106)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.Size = New System.Drawing.Size(1160, 410)
        Me.DGV.TabIndex = 19
        '
        'ListDataMember
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1160, 579)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ListDataMember"
        Me.Text = "Data Member"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LookUpEditBulan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtCariMember.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtCariMember As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTNTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents btnEdit As ToolStripMenuItem
    Friend WithEvents DGV As DataGridView
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DeleteMemberToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtTotalMember As Label
    Friend WithEvents txtTotalDetail As Label
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEditBulan As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
End Class
