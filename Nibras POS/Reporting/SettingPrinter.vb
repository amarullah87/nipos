Imports DevExpress.XtraEditors
Imports MySql.Data.MySqlClient

Public Class SettingPrinter
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Sub PrinterConfig()
        Me.cboPrinterKasir.Items.Clear()
        Me.cboPrinterLaporan.Items.Clear()

        cekClose()
        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM config_url WHERE config_name = 'printer_kasir'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Me.cboPrinterKasir.Items.Add(DR.Item("config_url"))
        Else
            Me.cboPrinterKasir.Items.Add("- Belum di Set -")
        End If
        cekClose()

        For Each strPrinterName As String In Printing.PrinterSettings.InstalledPrinters
            Me.cboPrinterKasir.Items.Add(strPrinterName)
        Next

        Me.cboPrinterKasir.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboPrinterKasir.SelectedIndex = 0

        cekClose()
        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM config_url WHERE config_name = 'printer_laporan'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Me.cboPrinterLaporan.Items.Add(DR.Item("config_url"))
        Else
            Me.cboPrinterLaporan.Items.Add("- Belum di Set -")
        End If
        cekClose()

        For Each strPrinterName2 As String In Printing.PrinterSettings.InstalledPrinters
            Me.cboPrinterLaporan.Items.Add(strPrinterName2)
        Next

        Me.cboPrinterLaporan.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboPrinterLaporan.SelectedIndex = 0
    End Sub

    Private Sub SettingPrinter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call PrinterConfig()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("INSERT INTO config_url (config_name, config_url) VALUES ('printer_kasir', '" & cboPrinterKasir.Text & "') ON DUPLICATE KEY UPDATE config_url = '" & cboPrinterKasir.Text & "' ", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("INSERT INTO config_url (config_name, config_url) VALUES ('printer_laporan', '" & cboPrinterLaporan.Text & "') ON DUPLICATE KEY UPDATE config_url = '" & cboPrinterLaporan.Text & "' ", Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        XtraMessageBox.Show("Pengaturan Berhasil Disimpan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Call PrinterConfig()
    End Sub
End Class