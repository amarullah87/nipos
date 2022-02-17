<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogPembayaran
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogPembayaran))
        Me.cbDeposit = New System.Windows.Forms.CheckBox()
        Me.txtDepositHide = New System.Windows.Forms.TextBox()
        Me.txtAccEmoney = New System.Windows.Forms.TextBox()
        Me.txtAccCC = New System.Windows.Forms.TextBox()
        Me.txtAccBankA = New System.Windows.Forms.TextBox()
        Me.txtKembalianHide = New System.Windows.Forms.TextBox()
        Me.txtTotalBayarHide = New System.Windows.Forms.TextBox()
        Me.lblKembalian = New System.Windows.Forms.Label()
        Me.txtMember = New System.Windows.Forms.TextBox()
        Me.txtNoEMoney = New System.Windows.Forms.TextBox()
        Me.txtNoCC = New System.Windows.Forms.TextBox()
        Me.txtNoBankA = New System.Windows.Forms.TextBox()
        Me.cbEMoney = New System.Windows.Forms.ComboBox()
        Me.cbCC = New System.Windows.Forms.ComboBox()
        Me.cbBankA = New System.Windows.Forms.ComboBox()
        Me.txtDeposit = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtKembalian = New System.Windows.Forms.TextBox()
        Me.txtTotalBayar = New System.Windows.Forms.TextBox()
        Me.txtEMoney = New System.Windows.Forms.TextBox()
        Me.txtCC = New System.Windows.Forms.TextBox()
        Me.txtDebitA = New System.Windows.Forms.TextBox()
        Me.txtKredit = New System.Windows.Forms.TextBox()
        Me.txtTunai = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblKurang = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBatal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpanCetak = New DevExpress.XtraEditors.SimpleButton()
        Me.txtAccBankB = New System.Windows.Forms.TextBox()
        Me.txtNoBankB = New System.Windows.Forms.TextBox()
        Me.cbBankB = New System.Windows.Forms.ComboBox()
        Me.txtDebitB = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cbDeposit
        '
        Me.cbDeposit.AutoSize = True
        Me.cbDeposit.Location = New System.Drawing.Point(572, 130)
        Me.cbDeposit.Name = "cbDeposit"
        Me.cbDeposit.Size = New System.Drawing.Size(15, 14)
        Me.cbDeposit.TabIndex = 176
        Me.cbDeposit.UseVisualStyleBackColor = True
        '
        'txtDepositHide
        '
        Me.txtDepositHide.Location = New System.Drawing.Point(487, 12)
        Me.txtDepositHide.Name = "txtDepositHide"
        Me.txtDepositHide.Size = New System.Drawing.Size(153, 21)
        Me.txtDepositHide.TabIndex = 175
        Me.txtDepositHide.Text = "0"
        Me.txtDepositHide.Visible = False
        '
        'txtAccEmoney
        '
        Me.txtAccEmoney.Location = New System.Drawing.Point(602, 240)
        Me.txtAccEmoney.Name = "txtAccEmoney"
        Me.txtAccEmoney.Size = New System.Drawing.Size(52, 21)
        Me.txtAccEmoney.TabIndex = 174
        '
        'txtAccCC
        '
        Me.txtAccCC.Location = New System.Drawing.Point(602, 211)
        Me.txtAccCC.Name = "txtAccCC"
        Me.txtAccCC.Size = New System.Drawing.Size(52, 21)
        Me.txtAccCC.TabIndex = 173
        '
        'txtAccBankA
        '
        Me.txtAccBankA.Location = New System.Drawing.Point(602, 184)
        Me.txtAccBankA.Name = "txtAccBankA"
        Me.txtAccBankA.Size = New System.Drawing.Size(52, 21)
        Me.txtAccBankA.TabIndex = 172
        '
        'txtKembalianHide
        '
        Me.txtKembalianHide.Location = New System.Drawing.Point(462, 328)
        Me.txtKembalianHide.Name = "txtKembalianHide"
        Me.txtKembalianHide.Size = New System.Drawing.Size(146, 21)
        Me.txtKembalianHide.TabIndex = 171
        Me.txtKembalianHide.Text = "0"
        Me.txtKembalianHide.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtKembalianHide.Visible = False
        '
        'txtTotalBayarHide
        '
        Me.txtTotalBayarHide.Location = New System.Drawing.Point(462, 281)
        Me.txtTotalBayarHide.Name = "txtTotalBayarHide"
        Me.txtTotalBayarHide.Size = New System.Drawing.Size(146, 21)
        Me.txtTotalBayarHide.TabIndex = 170
        Me.txtTotalBayarHide.Text = "0"
        Me.txtTotalBayarHide.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalBayarHide.Visible = False
        '
        'lblKembalian
        '
        Me.lblKembalian.AutoSize = True
        Me.lblKembalian.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKembalian.Location = New System.Drawing.Point(11, 332)
        Me.lblKembalian.Name = "lblKembalian"
        Me.lblKembalian.Size = New System.Drawing.Size(89, 19)
        Me.lblKembalian.TabIndex = 169
        Me.lblKembalian.Text = "Kembalian :"
        Me.lblKembalian.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblKembalian.Visible = False
        '
        'txtMember
        '
        Me.txtMember.Location = New System.Drawing.Point(374, 155)
        Me.txtMember.Name = "txtMember"
        Me.txtMember.ReadOnly = True
        Me.txtMember.Size = New System.Drawing.Size(280, 21)
        Me.txtMember.TabIndex = 146
        '
        'txtNoEMoney
        '
        Me.txtNoEMoney.Location = New System.Drawing.Point(462, 240)
        Me.txtNoEMoney.Name = "txtNoEMoney"
        Me.txtNoEMoney.Size = New System.Drawing.Size(192, 21)
        Me.txtNoEMoney.TabIndex = 152
        '
        'txtNoCC
        '
        Me.txtNoCC.Location = New System.Drawing.Point(462, 211)
        Me.txtNoCC.Name = "txtNoCC"
        Me.txtNoCC.Size = New System.Drawing.Size(192, 21)
        Me.txtNoCC.TabIndex = 150
        '
        'txtNoBankA
        '
        Me.txtNoBankA.Location = New System.Drawing.Point(462, 184)
        Me.txtNoBankA.Name = "txtNoBankA"
        Me.txtNoBankA.Size = New System.Drawing.Size(192, 21)
        Me.txtNoBankA.TabIndex = 148
        '
        'cbEMoney
        '
        Me.cbEMoney.FormattingEnabled = True
        Me.cbEMoney.Location = New System.Drawing.Point(374, 240)
        Me.cbEMoney.Name = "cbEMoney"
        Me.cbEMoney.Size = New System.Drawing.Size(82, 21)
        Me.cbEMoney.TabIndex = 151
        '
        'cbCC
        '
        Me.cbCC.FormattingEnabled = True
        Me.cbCC.Location = New System.Drawing.Point(374, 211)
        Me.cbCC.Name = "cbCC"
        Me.cbCC.Size = New System.Drawing.Size(82, 21)
        Me.cbCC.TabIndex = 149
        '
        'cbBankA
        '
        Me.cbBankA.FormattingEnabled = True
        Me.cbBankA.Location = New System.Drawing.Point(374, 184)
        Me.cbBankA.Name = "cbBankA"
        Me.cbBankA.Size = New System.Drawing.Size(82, 21)
        Me.cbBankA.TabIndex = 147
        '
        'txtDeposit
        '
        Me.txtDeposit.Location = New System.Drawing.Point(374, 126)
        Me.txtDeposit.Name = "txtDeposit"
        Me.txtDeposit.ReadOnly = True
        Me.txtDeposit.Size = New System.Drawing.Size(192, 21)
        Me.txtDeposit.TabIndex = 145
        Me.txtDeposit.Text = "0"
        Me.txtDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(301, 126)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 19)
        Me.Label15.TabIndex = 168
        Me.Label15.Text = "Deposit :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(322, 242)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 19)
        Me.Label14.TabIndex = 167
        Me.Label14.Text = "Prod :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(319, 213)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 19)
        Me.Label13.TabIndex = 166
        Me.Label13.Text = "Bank :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(319, 184)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 19)
        Me.Label11.TabIndex = 165
        Me.Label11.Text = "Bank :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(331, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 19)
        Me.Label9.TabIndex = 164
        Me.Label9.Text = "Pel :"
        '
        'txtKembalian
        '
        Me.txtKembalian.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtKembalian.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKembalian.ForeColor = System.Drawing.Color.White
        Me.txtKembalian.Location = New System.Drawing.Point(106, 318)
        Me.txtKembalian.Multiline = True
        Me.txtKembalian.Name = "txtKembalian"
        Me.txtKembalian.ReadOnly = True
        Me.txtKembalian.Size = New System.Drawing.Size(350, 41)
        Me.txtKembalian.TabIndex = 163
        Me.txtKembalian.Text = "0"
        Me.txtKembalian.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBayar
        '
        Me.txtTotalBayar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBayar.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBayar.ForeColor = System.Drawing.Color.White
        Me.txtTotalBayar.Location = New System.Drawing.Point(106, 271)
        Me.txtTotalBayar.Multiline = True
        Me.txtTotalBayar.Name = "txtTotalBayar"
        Me.txtTotalBayar.ReadOnly = True
        Me.txtTotalBayar.Size = New System.Drawing.Size(350, 41)
        Me.txtTotalBayar.TabIndex = 162
        Me.txtTotalBayar.Text = "0"
        Me.txtTotalBayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEMoney
        '
        Me.txtEMoney.Location = New System.Drawing.Point(106, 242)
        Me.txtEMoney.Name = "txtEMoney"
        Me.txtEMoney.Size = New System.Drawing.Size(192, 21)
        Me.txtEMoney.TabIndex = 144
        Me.txtEMoney.Text = "0"
        Me.txtEMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCC
        '
        Me.txtCC.Location = New System.Drawing.Point(106, 213)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.Size = New System.Drawing.Size(192, 21)
        Me.txtCC.TabIndex = 143
        Me.txtCC.Text = "0"
        Me.txtCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebitA
        '
        Me.txtDebitA.Location = New System.Drawing.Point(106, 184)
        Me.txtDebitA.Name = "txtDebitA"
        Me.txtDebitA.Size = New System.Drawing.Size(192, 21)
        Me.txtDebitA.TabIndex = 142
        Me.txtDebitA.Text = "0"
        Me.txtDebitA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtKredit
        '
        Me.txtKredit.Location = New System.Drawing.Point(106, 155)
        Me.txtKredit.Name = "txtKredit"
        Me.txtKredit.Size = New System.Drawing.Size(192, 21)
        Me.txtKredit.TabIndex = 141
        Me.txtKredit.Text = "0"
        Me.txtKredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTunai
        '
        Me.txtTunai.Location = New System.Drawing.Point(106, 126)
        Me.txtTunai.Name = "txtTunai"
        Me.txtTunai.Size = New System.Drawing.Size(192, 21)
        Me.txtTunai.TabIndex = 140
        Me.txtTunai.Text = "0"
        Me.txtTunai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Yellow
        Me.txtTotal.Font = New System.Drawing.Font("Calibri", 38.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Black
        Me.txtTotal.Location = New System.Drawing.Point(106, 41)
        Me.txtTotal.Multiline = True
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(548, 66)
        Me.txtTotal.TabIndex = 161
        Me.txtTotal.Text = "0"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblKurang
        '
        Me.lblKurang.AutoSize = True
        Me.lblKurang.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKurang.Location = New System.Drawing.Point(1, 332)
        Me.lblKurang.Name = "lblKurang"
        Me.lblKurang.Size = New System.Drawing.Size(99, 19)
        Me.lblKurang.TabIndex = 160
        Me.lblKurang.Text = "Kekurangan :"
        Me.lblKurang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 281)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 19)
        Me.Label7.TabIndex = 159
        Me.Label7.Text = "Total Bayar :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 19)
        Me.Label6.TabIndex = 158
        Me.Label6.Text = "e-Money :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 19)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "Kartu Kredit :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 19)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "Kartu Debit :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 19)
        Me.Label3.TabIndex = 155
        Me.Label3.Text = "Kredit :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 19)
        Me.Label2.TabIndex = 154
        Me.Label2.Text = "Tunai :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 29)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "Total :"
        '
        'btnSimpan
        '
        Me.btnSimpan.ImageOptions.Image = CType(resources.GetObject("btnSimpan.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(249, 374)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(100, 35)
        Me.btnSimpan.TabIndex = 179
        Me.btnSimpan.Text = "Simpan (F5)"
        '
        'btnBatal
        '
        Me.btnBatal.ImageOptions.Image = CType(resources.GetObject("btnBatal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBatal.Location = New System.Drawing.Point(355, 374)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 178
        Me.btnBatal.Text = "Batal"
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(451, 374)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 177
        Me.btnTutup.Text = "Tutup"
        '
        'btnSimpanCetak
        '
        Me.btnSimpanCetak.ImageOptions.Image = CType(resources.GetObject("btnSimpanCetak.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSimpanCetak.Location = New System.Drawing.Point(106, 373)
        Me.btnSimpanCetak.Name = "btnSimpanCetak"
        Me.btnSimpanCetak.Size = New System.Drawing.Size(137, 35)
        Me.btnSimpanCetak.TabIndex = 180
        Me.btnSimpanCetak.Text = "Simpan+Cetak (F9)"
        '
        'txtAccBankB
        '
        Me.txtAccBankB.Location = New System.Drawing.Point(429, 12)
        Me.txtAccBankB.Name = "txtAccBankB"
        Me.txtAccBankB.Size = New System.Drawing.Size(52, 21)
        Me.txtAccBankB.TabIndex = 183
        '
        'txtNoBankB
        '
        Me.txtNoBankB.Location = New System.Drawing.Point(289, 12)
        Me.txtNoBankB.Name = "txtNoBankB"
        Me.txtNoBankB.Size = New System.Drawing.Size(192, 21)
        Me.txtNoBankB.TabIndex = 182
        Me.txtNoBankB.Visible = False
        '
        'cbBankB
        '
        Me.cbBankB.FormattingEnabled = True
        Me.cbBankB.Location = New System.Drawing.Point(201, 12)
        Me.cbBankB.Name = "cbBankB"
        Me.cbBankB.Size = New System.Drawing.Size(82, 21)
        Me.cbBankB.TabIndex = 181
        Me.cbBankB.Visible = False
        '
        'txtDebitB
        '
        Me.txtDebitB.Location = New System.Drawing.Point(3, 12)
        Me.txtDebitB.Name = "txtDebitB"
        Me.txtDebitB.Size = New System.Drawing.Size(192, 21)
        Me.txtDebitB.TabIndex = 184
        Me.txtDebitB.Text = "0"
        Me.txtDebitB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDebitB.Visible = False
        '
        'DialogPembayaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 421)
        Me.Controls.Add(Me.txtDebitB)
        Me.Controls.Add(Me.txtAccBankB)
        Me.Controls.Add(Me.txtNoBankB)
        Me.Controls.Add(Me.cbBankB)
        Me.Controls.Add(Me.btnSimpanCetak)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnTutup)
        Me.Controls.Add(Me.cbDeposit)
        Me.Controls.Add(Me.txtDepositHide)
        Me.Controls.Add(Me.txtAccEmoney)
        Me.Controls.Add(Me.txtAccCC)
        Me.Controls.Add(Me.txtAccBankA)
        Me.Controls.Add(Me.txtKembalianHide)
        Me.Controls.Add(Me.txtTotalBayarHide)
        Me.Controls.Add(Me.lblKembalian)
        Me.Controls.Add(Me.txtMember)
        Me.Controls.Add(Me.txtNoEMoney)
        Me.Controls.Add(Me.txtNoCC)
        Me.Controls.Add(Me.txtNoBankA)
        Me.Controls.Add(Me.cbEMoney)
        Me.Controls.Add(Me.cbCC)
        Me.Controls.Add(Me.cbBankA)
        Me.Controls.Add(Me.txtDeposit)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtKembalian)
        Me.Controls.Add(Me.txtTotalBayar)
        Me.Controls.Add(Me.txtEMoney)
        Me.Controls.Add(Me.txtCC)
        Me.Controls.Add(Me.txtDebitA)
        Me.Controls.Add(Me.txtKredit)
        Me.Controls.Add(Me.txtTunai)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblKurang)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "DialogPembayaran"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pembayaran"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbDeposit As CheckBox
    Friend WithEvents txtDepositHide As TextBox
    Friend WithEvents txtAccEmoney As TextBox
    Friend WithEvents txtAccCC As TextBox
    Friend WithEvents txtAccBankA As TextBox
    Friend WithEvents txtKembalianHide As TextBox
    Friend WithEvents txtTotalBayarHide As TextBox
    Friend WithEvents lblKembalian As Label
    Friend WithEvents txtMember As TextBox
    Friend WithEvents txtNoEMoney As TextBox
    Friend WithEvents txtNoCC As TextBox
    Friend WithEvents txtNoBankA As TextBox
    Friend WithEvents cbEMoney As ComboBox
    Friend WithEvents cbCC As ComboBox
    Friend WithEvents cbBankA As ComboBox
    Friend WithEvents txtDeposit As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtKembalian As TextBox
    Friend WithEvents txtTotalBayar As TextBox
    Friend WithEvents txtEMoney As TextBox
    Friend WithEvents txtCC As TextBox
    Friend WithEvents txtDebitA As TextBox
    Friend WithEvents txtKredit As TextBox
    Friend WithEvents txtTunai As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lblKurang As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpanCetak As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtAccBankB As TextBox
    Friend WithEvents txtNoBankB As TextBox
    Friend WithEvents cbBankB As ComboBox
    Friend WithEvents txtDebitB As TextBox
End Class
