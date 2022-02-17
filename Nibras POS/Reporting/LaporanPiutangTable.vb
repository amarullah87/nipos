Imports MySql.Data.MySqlClient

Public Class LaporanPiutangTable
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call GetData()
    End Sub

    Private Sub LaporanPiutangTable_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date
        Call GetData()
    End Sub

    Sub GetData()
        Dim dataPiutang As New List(Of PiutangList)
        DGV.Rows.Clear()

        Dim total As Double = 0
        cekOpen()
        'CMD = New MySqlCommand("SELECT * FROM v2_piutang_beredar WHERE status = 0", Conn)
        CMD = New MySqlCommand("select no_faktur from piutang union select faktur_jual as no_transaksi from penjualan where cara_jual = 'KREDIT'", Conn)
        DR = CMD.ExecuteReader

        Dim faktur As New List(Of String)
        While DR.Read
            faktur.Add(DR.Item("no_faktur"))
        End While
        'Console.WriteLine(String.Join(",", faktur.ToArray))
        cekClose()

        For Each no_faktur As String In faktur
            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM pembayaran_hp WHERE no_faktur = '" & no_faktur & "' AND jenis = 'PIUTANG' AND `status` = 1 AND created < '" & DTPHarian.Value.ToString("yyyy-MM-dd") & "' ORDER BY created DESC LIMIT 1", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            Console.WriteLine("SELECT * FROM pembayaran_hp WHERE no_faktur = '" & no_faktur & "' AND jenis = 'PIUTANG' AND `status` = 1 AND created <= '" & DTPHarian.Value.ToString("yyyy-MM-dd") & "' ORDER BY created DESC LIMIT 1")

            If DR.HasRows Then

                Dim nofaktur As String = DR.Item("no_faktur")
                cekClose()

                cekOpen()
                CMD = New MySqlCommand("SELECT * FROM v2_piutang_beredar WHERE no_faktur = '" & nofaktur & "'", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                If DR.HasRows Then
                    Dim dateCari As Date = DTPHarian.Value.ToString("yyyy-MM-dd")
                    Dim dateJT As Date = DR.Item("tanggal_jt")
                    Dim days As Long = DateDiff(DateInterval.Day, dateCari, dateJT)


                    If DR.Item("status_lunas") = "1" Or DR.Item("status_lunas") = "LUNAS" Then
                        days = 0
                    End If

                    DGV.Rows.Add(
                        DR.Item("no_transaksi"),
                        DR.Item("no_faktur"),
                        DR.Item("kode_member") + " | " + DR.Item("nama_member"),
                        DR.Item("tanggal"),
                        DR.Item("tanggal_jt"),
                        CDec(DR.Item("potongan")),
                        CDec(DR.Item("total")),
                        CDec(DR.Item("sisa")),
                        DR.Item("keterangan"),
                        days.ToString + " Hari",
                        days.ToString
                    )

                    total += DR.Item("total")
                End If
                cekClose()

            Else
                cekClose()

                cekOpen()
                'CMD = New MySqlCommand("SELECT * FROM v2_piutang_beredar WHERE no_faktur = '" & no_faktur & "'", Conn)
                CMD = New MySqlCommand("SELECT * FROM v2_piutang_beredar WHERE no_faktur = '" & no_faktur & "' AND tanggal_jt <= '" & DTPHarian.Value.ToString("yyyy-MM-dd") & "' ", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                If DR.HasRows Then
                    Dim dateCari As Date = DTPHarian.Value.ToString("yyyy-MM-dd")
                    Dim dateJT As Date = DR.Item("tanggal_jt")
                    Dim days As Long = DateDiff(DateInterval.Day, dateCari, dateJT)


                    If DR.Item("status_lunas") = "1" Or DR.Item("status_lunas") = "LUNAS" Then
                        days = 0
                    End If

                    DGV.Rows.Add(
                        DR.Item("no_transaksi"),
                        DR.Item("no_faktur"),
                        DR.Item("kode_member") + " | " + DR.Item("nama_member"),
                        DR.Item("tanggal"),
                        DR.Item("tanggal_jt"),
                        CDec(DR.Item("potongan")),
                        CDec(DR.Item("total")),
                        CDec(DR.Item("sisa")),
                        DR.Item("keterangan"),
                        days.ToString + " Hari",
                        days.ToString
                    )

                    total += DR.Item("total")
                End If
                cekClose()
            End If
        Next

        'While DR.Read

        '    Dim dateCari As Date = DTPHarian.Value.ToString("yyyy-MM-dd")
        '    Dim dateJT As Date = DR.Item("tanggal_jt")
        '    Dim days As Long = DateDiff(DateInterval.Day, dateCari, dateJT)
        '    'dataPiutang.Add(New PiutangList() With {
        '    '    .no_transaksi = DR.Item("no_transaksi"),
        '    '    .no_faktur = DR.Item("no_faktur"),
        '    '    .kode_member = DR.Item("kode_member") + " | " + DR.Item("nama_member"),
        '    '    .tanggal = DR.Item("tanggal"),
        '    '    .tanggal_jt = DR.Item("tanggal_jt"),
        '    '    .potongan = DR.Item("potongan"),
        '    '    .total = DR.Item("total"),
        '    '    .sisa = DR.Item("sisa"),
        '    '    .keterangan = DR.Item("keterangan"),
        '    '    .umur_jt = days.ToString + " Hari",
        '    '    .jt = days.ToString
        '    '})

        '    If DR.Item("status_lunas") = "1" Then
        '        days = 0
        '    End If

        '    DGV.Rows.Add(
        '        DR.Item("no_transaksi"),
        '        DR.Item("no_faktur"),
        '        DR.Item("kode_member") + " | " + DR.Item("nama_member"),
        '        DR.Item("tanggal"),
        '        DR.Item("tanggal_jt"),
        '        CDec(DR.Item("potongan")),
        '        CDec(DR.Item("total")),
        '        CDec(DR.Item("sisa")),
        '        DR.Item("keterangan"),
        '        days.ToString + " Hari",
        '        days.ToString
        '    )

        '    total += DR.Item("total")
        'End While
        'cekClose()
        ''For Each p As System.Reflection.PropertyInfo In dataPiutang.GetType().GetProperties()
        ''    If p.CanRead Then
        ''        Console.WriteLine("{0}: {1}", p.Name, p.GetValue(dataPiutang, Nothing))
        ''    End If
        ''Next
        txtTotalData.Text = "Total Piutang: " + FormatCurrency(total, 0)
    End Sub

    Private Sub DGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV.CellFormatting

    End Sub
End Class