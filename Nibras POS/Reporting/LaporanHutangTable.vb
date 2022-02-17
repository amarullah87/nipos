Imports MySql.Data.MySqlClient

Public Class LaporanHutangTable
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call GetData()
    End Sub

    Private Sub LaporanHutangTable_Load(sender As Object, e As EventArgs) Handles Me.Load
        DTPHarian.Value = Now.Date
        Call GetData()
    End Sub

    Sub GetData()
        DGV.Rows.Clear()

        Dim total As Double = 0
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM v2_hutang_beredar WHERE status = 0", Conn)
        DR = CMD.ExecuteReader

        While DR.Read

            Dim dateCari As Date = DTPHarian.Value.ToString("yyyy-MM-dd")
            Dim dateJT As Date = DR.Item("tanggal_jt")
            Dim days As Long = DateDiff(DateInterval.Day, dateCari, dateJT)


            DGV.Rows.Add(
                DR.Item("no_transaksi"),
                DR.Item("no_faktur"),
                DR.Item("kode_supplier") + " | " + DR.Item("nama"),
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
        End While
        txtTotalData.Text = "Total Hutang: " + FormatCurrency(total, 0)
        cekClose()
    End Sub

    Private Sub DGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV.CellFormatting
        'For Each myRow As DataGridViewRow In DGV.Rows
        '    If Double.Parse(myRow.Cells(10).Value) > 0 Then
        '        myRow.DefaultCellStyle.ForeColor = Color.Red
        '    End If
        'Next
    End Sub
End Class