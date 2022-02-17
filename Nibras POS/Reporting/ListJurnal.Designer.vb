<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListJurnal
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
        Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListJurnal))
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DTPBulanan = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DTPHarian = New System.Windows.Forms.DateTimePicker()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colnomor_transaksi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colkode_perkiraan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coluraian = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colkredit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colketerangan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltgl_transaksi = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "localhost_db_pos_Connection"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        CustomSqlQuery1.Name = "jurnal"
        CustomSqlQuery1.Sql = resources.GetString("CustomSqlQuery1.Sql")
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.btnBatal)
        Me.PanelControl1.Controls.Add(Me.GroupBox2)
        Me.PanelControl1.Controls.Add(Me.GroupBox1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(827, 60)
        Me.PanelControl1.TabIndex = 4
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(351, 14)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 42
        Me.btnBatal.Text = "Cari"
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
        'GridControl1
        '
        Me.GridControl1.DataMember = "jurnal"
        Me.GridControl1.DataSource = Me.SqlDataSource1
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 60)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(827, 556)
        Me.GridControl1.TabIndex = 5
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colnomor_transaksi, Me.colkode_perkiraan, Me.coluraian, Me.coldebet, Me.colkredit, Me.colketerangan, Me.coltgl_transaksi})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colnomor_transaksi, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colnomor_transaksi
        '
        Me.colnomor_transaksi.Caption = "Nomor Transaksi"
        Me.colnomor_transaksi.FieldName = "nomor_transaksi"
        Me.colnomor_transaksi.Name = "colnomor_transaksi"
        Me.colnomor_transaksi.Visible = True
        Me.colnomor_transaksi.VisibleIndex = 0
        '
        'colkode_perkiraan
        '
        Me.colkode_perkiraan.Caption = "Kode Perkiraan"
        Me.colkode_perkiraan.FieldName = "kode_perkiraan"
        Me.colkode_perkiraan.Name = "colkode_perkiraan"
        Me.colkode_perkiraan.Visible = True
        Me.colkode_perkiraan.VisibleIndex = 1
        '
        'coluraian
        '
        Me.coluraian.Caption = "Uraian"
        Me.coluraian.FieldName = "uraian"
        Me.coluraian.Name = "coluraian"
        Me.coluraian.Visible = True
        Me.coluraian.VisibleIndex = 2
        '
        'coldebet
        '
        Me.coldebet.Caption = "Debet"
        Me.coldebet.DisplayFormat.FormatString = "C0"
        Me.coldebet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.coldebet.FieldName = "debet"
        Me.coldebet.Name = "coldebet"
        Me.coldebet.Visible = True
        Me.coldebet.VisibleIndex = 4
        '
        'colkredit
        '
        Me.colkredit.Caption = "Kredit"
        Me.colkredit.DisplayFormat.FormatString = "C0"
        Me.colkredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colkredit.FieldName = "kredit"
        Me.colkredit.Name = "colkredit"
        Me.colkredit.Visible = True
        Me.colkredit.VisibleIndex = 5
        '
        'colketerangan
        '
        Me.colketerangan.Caption = "Keterangan"
        Me.colketerangan.FieldName = "keterangan"
        Me.colketerangan.Name = "colketerangan"
        Me.colketerangan.Visible = True
        Me.colketerangan.VisibleIndex = 3
        '
        'coltgl_transaksi
        '
        Me.coltgl_transaksi.Caption = "Tanggal Transaksi"
        Me.coltgl_transaksi.DisplayFormat.FormatString = "M"
        Me.coltgl_transaksi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.coltgl_transaksi.FieldName = "tgl_transaksi"
        Me.coltgl_transaksi.Name = "coltgl_transaksi"
        Me.coltgl_transaksi.Visible = True
        Me.coltgl_transaksi.VisibleIndex = 0
        '
        'ListJurnal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 616)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ListJurnal"
        Me.Text = "Daftar Jurnal"
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DTPBulanan As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DTPHarian As DateTimePicker
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colnomor_transaksi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colkode_perkiraan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coluraian As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colkredit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colketerangan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltgl_transaksi As DevExpress.XtraGrid.Columns.GridColumn
End Class
