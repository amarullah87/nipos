Imports MySql.Data.MySqlClient

Public Class DaftarPembayaranPiutang
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call TampilGrid()
    End Sub

    Sub TampilGrid()
        DGV.Rows.Clear()

        cekOpen()
        CMD = New MySqlCommand("SELECT CONCAT(p.kode_member, '/', m.nama_member) AS member, tanggal, tanggal_jt, SUM(sisa) AS sisa, SUM(potongan) AS potongan, SUM(total) AS total, SUM(jumlah_bayar) AS jumlah_bayar, created_by " &
                               " FROM piutang p INNER JOIN member_m m ON m.kode_member = p.kode_member WHERE status_lunas = 1 AND p.tanggal BETWEEN  '" & dtpAwal.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpAkhir.Value.ToString("yyyy-MM-dd") & "' GROUP BY p.kode_member " &
                               " UNION SELECT kode_customer, tgl_jual AS tanggal, jth_tempo_jual AS tanggal_jt, 0 AS sisa, 0 AS potongan, total_jual AS total, total_jual AS jumlah_bayar, kode_user AS created_by " &
                               " FROM penjualan WHERE cara_jual = 'KREDIT' AND status_jual = 'LUNAS' AND tgl_jual BETWEEN  '" & dtpAwal.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpAkhir.Value.ToString("yyyy-MM-dd") & "' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            DGV.Rows.Add(DR.Item("member"), DR.Item("tanggal"), DR.Item("tanggal_jt"), CDec(DR.Item("sisa")), CDec(DR.Item("potongan")), CDec(DR.Item("total")), CDec(DR.Item("jumlah_bayar")), DR.Item("created_by"))
        Loop
        cekClose()
    End Sub

    Private Sub DaftarKasMasuk_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        dtpAwal.Value = Now.Date.AddDays(-(Now.Day) + 1)
        dtpAkhir.Value = Now.Date.AddDays(-(Now.Day) + 30)


        Call TampilGrid()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        TransaksiPembayaranPiutang.MdiParent = MainMenu
        TransaksiPembayaranPiutang.Show()
        TransaksiPembayaranPiutang.Focus()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Call TampilGrid()
    End Sub
End Class