Imports MySql.Data.MySqlClient

Public Class PencarianMember
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub TampilGrid()
        DGV.ReadOnly = True
        'DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        DGV.Rows.Clear()
        TXTCariBarang.Text = ""
        txtTotalData.Text = "Total: 0 Data"
    End Sub

    Private Sub TXTCariBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCariBarang.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            DGV.Rows.Clear()

            Dim total As Integer = 0
            Dim query As String

            cekOpen()

            If TransaksiPenjualanNhs.cbMemberInternal.Checked = False Then
                query = "SELECT kode_member AS kode, nama_member AS nama, alamat, telepon FROM member_m WHERE nama_member LIKE '%" & TXTCariBarang.Text & "%'"
            Else
                query = "SELECT id AS kode, nama, alamat, no_tlf AS telepon FROM master_nhs WHERE nama LIKE '%" & TXTCariBarang.Text & "%' UNION SELECT kode, nama, alamat, kontak AS telepon FROM mst_distributor WHERE nama LIKE '%" & TXTCariBarang.Text & "%' AND jenis_nhs = 'M'"
            End If


            CMD = New MySqlCommand(query, Conn)
            DR = CMD.ExecuteReader

            While DR.Read
                DGV.Rows.Add(
                    DR.Item("kode"),
                    DR.Item("nama"),
                    DR.Item("alamat"),
                    DR.Item("telepon")
                )

                total += 1
            End While
            txtTotalData.Text = "Total Data: " + FormatNumber(total, 0)
            cekClose()
        End If
    End Sub

    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then
            TransaksiPenjualanNhs.txtMember.Text = DGV.Rows(e.RowIndex).Cells(0).Value
            TransaksiPenjualanNhs.lblkodecustomer.Text = DGV.Rows(e.RowIndex).Cells(1).Value
            TransaksiPenjualanNhs.txtBarcode.Focus()
            TransaksiPenjualanNhs.txtBarcode.Text = ""
            Me.Close()
        End If
    End Sub

    Private Sub PencarianMember_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()

        If TransaksiPenjualanNhs.cbMemberInternal.Checked = False Then
            Me.Text = "Pencarian Member"
            lblPencarian.Text = "Cari Nama Member"
        Else
            Me.Text = "Pencarian NHs"
            lblPencarian.Text = "Cari Nama NHs"
        End If

        Call TampilGrid()

        TXTCariBarang.Text = TransaksiPenjualanNhs.txtMember.Text
        TXTCariBarang.Focus()
        TXTCariBarang.Select()

        SetDoubleBuffered(DGV, True)
        Call Pencarian()
    End Sub

    Sub Pencarian()
        DGV.Rows.Clear()

        Dim total As Integer = 0
        Dim query As String

        cekOpen()

        If TransaksiPenjualanNhs.cbMemberInternal.Checked = False Then
            query = "SELECT kode_member AS kode, nama_member AS nama, alamat, telepon FROM member_m WHERE nama_member LIKE '%" & TXTCariBarang.Text & "%'"
        Else
            query = "SELECT id AS kode, nama, alamat, no_tlf AS telepon FROM master_nhs WHERE nama LIKE '%" & TXTCariBarang.Text & "%' UNION SELECT kode, nama, alamat, kontak AS telepon FROM mst_distributor WHERE nama LIKE '%" & TXTCariBarang.Text & "%'"
        End If


        CMD = New MySqlCommand(query, Conn)
        DR = CMD.ExecuteReader

        While DR.Read
            DGV.Rows.Add(
                DR.Item("kode"),
                DR.Item("nama"),
                DR.Item("alamat"),
                DR.Item("telepon")
            )

            total += 1
        End While
        txtTotalData.Text = "Total Data: " + FormatNumber(total, 0)
        cekClose()
    End Sub
End Class