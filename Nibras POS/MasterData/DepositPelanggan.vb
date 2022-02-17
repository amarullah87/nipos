Imports MySql.Data.MySqlClient

Public Class DepositPelanggan

    Sub Kosongkan()
        txtNamaMember.Text = ""
        Call TampilGrid()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Sub TampilGrid()
        cekOpen()
        DA = New MySqlDataAdapter("SELECT md.`no_transaksi` AS `No Transaksi`, m.`nama_member` AS `Nama Member`, md.`tgl_transaksi` AS `Tanggal`, md.`jenis` AS `Jenis`, " &
                                  " (SELECT CONCAT(kode_perkiraan, ' | ', uraian) FROM jurnal WHERE nomor_transaksi = md.no_transaksi AND uraian <> 'DEPOSIT PELANGGAN') AS `Ke/ Dari Akun`, " &
                                  " md.`jumlah` AS `Jumlah`, md.keterangan AS `Keterangan`, md.`created_by` AS `Dibuat Oleh`, md.`created_date` AS `Tgl Dibuat` FROM member_deposit md " &
                                    " INNER JOIN member_m m ON md.`kode_member` = m.`kode_member` ORDER BY created_date DESC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        cekClose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        cekOpen()
        DA = New MySqlDataAdapter("SELECT md.`no_transaksi` AS `No Transaksi`, m.`nama_member` AS `Nama Member`, md.`tgl_transaksi` AS `Tanggal`, md.`jenis` AS `Jenis`, " &
                                  " (SELECT CONCAT(kode_perkiraan, ' | ', uraian) FROM jurnal WHERE nomor_transaksi = md.no_transaksi AND uraian <> 'DEPOSIT PELANGGAN') AS `Ke/ Dari Akun`, " &
                                  " md.`jumlah` AS `Jumlah`, md.keterangan AS `Keterangan`, md.`created_by` AS `Dibuat Oleh`, md.`created_date` AS `Tgl Dibuat` FROM member_deposit md " &
                                    " INNER JOIN member_m m ON md.`kode_member` = m.`kode_member` WHERE m.`nama_member` Like '%" & txtNamaMember.Text & "%' ORDER BY created_date DESC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        cekClose()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        TambahDeposit.ShowDialog()
    End Sub

    Private Sub DepositPelanggan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call TampilGrid()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        MainMenu.SplashScreenManager1.ShowWaitForm()
        Threading.Thread.Sleep(2000)

        Dim nameFile As String = "C:\NIPOS_EXPORT\Deposit_Pelanggan_" & DateTime.Now.ToString("yyyyMMdd-HHmmss") & ".csv"

        DGV.ExportToCsv(nameFile)

        MsgBox("Data Berhasil di Export, Silahkan Periksa pada Folder " & nameFile, MsgBoxStyle.Information, "Berhasil!")
        MainMenu.SplashScreenManager1.CloseWaitForm()
    End Sub
End Class