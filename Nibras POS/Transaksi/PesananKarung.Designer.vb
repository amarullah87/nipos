<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PesananKarung
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PesananKarung))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnCari = New System.Windows.Forms.PictureBox()
        Me.dtpakhir = New System.Windows.Forms.DateTimePicker()
        Me.dtpawal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalData = New System.Windows.Forms.Label()
        Me.lblNamaSupp = New System.Windows.Forms.Label()
        Me.lblKodeSupp = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalDiskon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.btnCari, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCari
        '
        Me.btnCari.Image = CType(resources.GetObject("btnCari.Image"), System.Drawing.Image)
        Me.btnCari.Location = New System.Drawing.Point(767, 20)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(20, 20)
        Me.btnCari.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnCari.TabIndex = 75
        Me.btnCari.TabStop = False
        '
        'dtpakhir
        '
        Me.dtpakhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpakhir.Location = New System.Drawing.Point(645, 19)
        Me.dtpakhir.Name = "dtpakhir"
        Me.dtpakhir.Size = New System.Drawing.Size(116, 21)
        Me.dtpakhir.TabIndex = 74
        '
        'dtpawal
        '
        Me.dtpawal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpawal.Location = New System.Drawing.Point(486, 19)
        Me.dtpawal.Name = "dtpawal"
        Me.dtpawal.Size = New System.Drawing.Size(116, 21)
        Me.dtpawal.TabIndex = 73
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(608, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "s / d"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(393, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Periode Awal :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalData
        '
        Me.txtTotalData.AutoSize = True
        Me.txtTotalData.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalData.Location = New System.Drawing.Point(719, 47)
        Me.txtTotalData.Name = "txtTotalData"
        Me.txtTotalData.Size = New System.Drawing.Size(68, 15)
        Me.txtTotalData.TabIndex = 70
        Me.txtTotalData.Text = "Total Data: "
        Me.txtTotalData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNamaSupp
        '
        Me.lblNamaSupp.AutoSize = True
        Me.lblNamaSupp.Location = New System.Drawing.Point(107, 47)
        Me.lblNamaSupp.Name = "lblNamaSupp"
        Me.lblNamaSupp.Size = New System.Drawing.Size(0, 13)
        Me.lblNamaSupp.TabIndex = 69
        '
        'lblKodeSupp
        '
        Me.lblKodeSupp.AutoSize = True
        Me.lblKodeSupp.Location = New System.Drawing.Point(107, 20)
        Me.lblKodeSupp.Name = "lblKodeSupp"
        Me.lblKodeSupp.Size = New System.Drawing.Size(0, 13)
        Me.lblKodeSupp.TabIndex = 68
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 15)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Kode Supplier :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 15)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Nama Supplier :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(10, 619)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 77
        Me.btnBatal.Text = "Refresh"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(106, 619)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 76
        Me.btnTutup.Text = "Tutup"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
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
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Kode, Me.Tanggal, Me.Qty, Me.Brand, Me.Total, Me.TotalDiskon})
        Me.DGV.Location = New System.Drawing.Point(10, 70)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DGV.RowTemplate.Height = 30
        Me.DGV.Size = New System.Drawing.Size(777, 533)
        Me.DGV.TabIndex = 78
        '
        'Kode
        '
        Me.Kode.HeaderText = "Nomor Transaksi"
        Me.Kode.Name = "Kode"
        Me.Kode.ReadOnly = True
        '
        'Tanggal
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "M"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Tanggal.DefaultCellStyle = DataGridViewCellStyle2
        Me.Tanggal.HeaderText = "Tanggal"
        Me.Tanggal.Name = "Tanggal"
        Me.Tanggal.ReadOnly = True
        '
        'Qty
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Qty.DefaultCellStyle = DataGridViewCellStyle3
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        '
        'Brand
        '
        Me.Brand.HeaderText = "Brand"
        Me.Brand.Name = "Brand"
        Me.Brand.ReadOnly = True
        '
        'Total
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.Total.DefaultCellStyle = DataGridViewCellStyle4
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'TotalDiskon
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.TotalDiskon.DefaultCellStyle = DataGridViewCellStyle5
        Me.TotalDiskon.HeaderText = "Total Diskon"
        Me.TotalDiskon.Name = "TotalDiskon"
        Me.TotalDiskon.ReadOnly = True
        '
        'PesananKarung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 666)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnTutup)
        Me.Controls.Add(Me.btnCari)
        Me.Controls.Add(Me.dtpakhir)
        Me.Controls.Add(Me.dtpawal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTotalData)
        Me.Controls.Add(Me.lblNamaSupp)
        Me.Controls.Add(Me.lblKodeSupp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PesananKarung"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesanan Karung"
        CType(Me.btnCari, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCari As PictureBox
    Friend WithEvents dtpakhir As DateTimePicker
    Friend WithEvents dtpawal As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTotalData As Label
    Friend WithEvents lblNamaSupp As Label
    Friend WithEvents lblKodeSupp As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DGV As DataGridView
    Friend WithEvents Kode As DataGridViewTextBoxColumn
    Friend WithEvents Tanggal As DataGridViewTextBoxColumn
    Friend WithEvents Qty As DataGridViewTextBoxColumn
    Friend WithEvents Brand As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents TotalDiskon As DataGridViewTextBoxColumn
End Class
