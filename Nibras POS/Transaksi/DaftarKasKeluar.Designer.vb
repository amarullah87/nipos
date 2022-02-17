﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DaftarKasKeluar
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DaftarKasKeluar))
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dibuat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.dtpAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpAwal = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Kode, Me.Nama, Me.Keterangan, Me.Debet, Me.Kredit, Me.Dibuat})
        Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(0, 58)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.Size = New System.Drawing.Size(835, 481)
        Me.DGV.TabIndex = 69
        '
        'Kode
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kode.DefaultCellStyle = DataGridViewCellStyle6
        Me.Kode.HeaderText = "Nomor Transaksi"
        Me.Kode.Name = "Kode"
        Me.Kode.ReadOnly = True
        Me.Kode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Nama
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.Format = "D"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Nama.DefaultCellStyle = DataGridViewCellStyle7
        Me.Nama.HeaderText = "Tanggal"
        Me.Nama.Name = "Nama"
        Me.Nama.ReadOnly = True
        '
        'Keterangan
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Keterangan.DefaultCellStyle = DataGridViewCellStyle8
        Me.Keterangan.HeaderText = "Keluar dari Akun"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.ReadOnly = True
        '
        'Debet
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Debet.DefaultCellStyle = DataGridViewCellStyle9
        Me.Debet.HeaderText = "Keterangan"
        Me.Debet.Name = "Debet"
        Me.Debet.ReadOnly = True
        '
        'Kredit
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.Format = "C0"
        DataGridViewCellStyle10.NullValue = "0"
        Me.Kredit.DefaultCellStyle = DataGridViewCellStyle10
        Me.Kredit.HeaderText = "Jumlah"
        Me.Kredit.Name = "Kredit"
        Me.Kredit.ReadOnly = True
        '
        'Dibuat
        '
        Me.Dibuat.HeaderText = "Dibuat Oleh"
        Me.Dibuat.Name = "Dibuat"
        Me.Dibuat.ReadOnly = True
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(111, 11)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 49
        Me.btnBatal.Text = "Refresh"
        '
        'btnSimpan
        '
        Me.btnSimpan.ImageOptions.Image = CType(resources.GetObject("btnSimpan.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(15, 11)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 48
        Me.btnSimpan.Text = "Tambah"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(318, 11)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 47
        Me.btnTutup.Text = "Tutup"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(410, 11)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(37, 35)
        Me.SimpleButton1.TabIndex = 40
        '
        'dtpAkhir
        '
        Me.dtpAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAkhir.Location = New System.Drawing.Point(276, 20)
        Me.dtpAkhir.Name = "dtpAkhir"
        Me.dtpAkhir.Size = New System.Drawing.Size(128, 22)
        Me.dtpAkhir.TabIndex = 39
        Me.dtpAkhir.Value = New Date(2020, 8, 10, 11, 41, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(226, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "s/d"
        '
        'dtpAwal
        '
        Me.dtpAwal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAwal.Location = New System.Drawing.Point(70, 20)
        Me.dtpAwal.Name = "dtpAwal"
        Me.dtpAwal.Size = New System.Drawing.Size(128, 22)
        Me.dtpAwal.TabIndex = 37
        Me.dtpAwal.Value = New Date(2020, 8, 10, 11, 41, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Periode:"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SimpleButton3)
        Me.PanelControl2.Controls.Add(Me.btnBatal)
        Me.PanelControl2.Controls.Add(Me.btnSimpan)
        Me.PanelControl2.Controls.Add(Me.btnTutup)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 539)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(835, 61)
        Me.PanelControl2.TabIndex = 68
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(207, 11)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(105, 35)
        Me.SimpleButton3.TabIndex = 131
        Me.SimpleButton3.Text = "Export to CSV"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Controls.Add(Me.dtpAkhir)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.dtpAwal)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(835, 58)
        Me.PanelControl1.TabIndex = 67
        '
        'DaftarKasKeluar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 600)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DaftarKasKeluar"
        Me.Text = "Daftar Kas Keluar"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV As DataGridView
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtpAkhir As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpAwal As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Kode As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Keterangan As DataGridViewTextBoxColumn
    Friend WithEvents Debet As DataGridViewTextBoxColumn
    Friend WithEvents Kredit As DataGridViewTextBoxColumn
    Friend WithEvents Dibuat As DataGridViewTextBoxColumn
End Class
