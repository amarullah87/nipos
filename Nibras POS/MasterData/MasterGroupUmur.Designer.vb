﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterGroupUmur
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterGroupUmur))
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DGV = New DevExpress.XtraGrid.GridControl()
        Me.btnTutup = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DGV
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'DGV
        '
        Me.DGV.Location = New System.Drawing.Point(12, 12)
        Me.DGV.MainView = Me.GridView1
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(530, 336)
        Me.DGV.TabIndex = 4
        Me.DGV.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'btnTutup
        '
        Me.btnTutup.ImageOptions.Image = CType(resources.GetObject("btnTutup.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTutup.Location = New System.Drawing.Point(12, 354)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(90, 35)
        Me.btnTutup.TabIndex = 3
        Me.btnTutup.Text = "Tutup"
        '
        'MasterGroupUmur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 401)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.btnTutup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MasterGroupUmur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Group Diskon by Umur"
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DGV As DevExpress.XtraGrid.GridControl
    Friend WithEvents btnTutup As DevExpress.XtraEditors.SimpleButton
End Class
