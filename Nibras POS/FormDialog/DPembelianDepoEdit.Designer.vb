﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DPembelianDepoEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DPembelianDepoEdit))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.cbAkun = New System.Windows.Forms.ComboBox()
        Me.txtSaldo = New DevExpress.XtraEditors.TextEdit()
        Me.txtPerkiraan = New DevExpress.XtraEditors.TextEdit()
        Me.txtNamaSupplier = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.txtSaldo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPerkiraan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaSupplier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.cbAkun)
        Me.PanelControl1.Controls.Add(Me.txtSaldo)
        Me.PanelControl1.Controls.Add(Me.txtPerkiraan)
        Me.PanelControl1.Controls.Add(Me.txtNamaSupplier)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Location = New System.Drawing.Point(12, 11)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(291, 147)
        Me.PanelControl1.TabIndex = 37
        '
        'cbAkun
        '
        Me.cbAkun.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.Location = New System.Drawing.Point(78, 47)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(171, 21)
        Me.cbAkun.TabIndex = 8
        '
        'txtSaldo
        '
        Me.txtSaldo.EditValue = "0"
        Me.txtSaldo.Location = New System.Drawing.Point(78, 105)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSaldo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtSaldo.Properties.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(112, 20)
        Me.txtSaldo.TabIndex = 7
        '
        'txtPerkiraan
        '
        Me.txtPerkiraan.Location = New System.Drawing.Point(78, 76)
        Me.txtPerkiraan.Name = "txtPerkiraan"
        Me.txtPerkiraan.Properties.ReadOnly = True
        Me.txtPerkiraan.Size = New System.Drawing.Size(171, 20)
        Me.txtPerkiraan.TabIndex = 6
        '
        'txtNamaSupplier
        '
        Me.txtNamaSupplier.Location = New System.Drawing.Point(78, 18)
        Me.txtNamaSupplier.Name = "txtNamaSupplier"
        Me.txtNamaSupplier.Properties.ReadOnly = True
        Me.txtNamaSupplier.Size = New System.Drawing.Size(171, 20)
        Me.txtNamaSupplier.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Saldo :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Perkiraan :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Kode :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nama :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(213, 164)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 39
        Me.btnBatal.Text = "Batal"
        '
        'btnSimpan
        '
        Me.btnSimpan.ImageOptions.Image = CType(resources.GetObject("btnSimpan.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(117, 164)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 38
        Me.btnSimpan.Text = "OK"
        '
        'DPembelianDepoEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 211)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnSimpan)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "DPembelianDepoEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kode Perkiraan Deposit"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.txtSaldo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPerkiraan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNamaSupplier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cbAkun As ComboBox
    Friend WithEvents txtSaldo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPerkiraan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNamaSupplier As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
End Class
