Imports System.IO
Imports System.Net
Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient

Module ConfigModule

    Public Conn As New MySqlConnection
    Public DA As MySqlDataAdapter
    Public DS As DataSet
    Public CMD As MySqlCommand
    Public DR As MySqlDataReader

    Public cryRpt As New ReportDocument
    Public crtableLogoninfos As New TableLogOnInfos
    Public crtableLogoninfo As New TableLogOnInfo
    Public crConnectionInfo As New ConnectionInfo
    Public CrTables As Tables
    Public MyDb As String

    'STRING DATA'
    'Public BaseURL As String = "http://206.189.151.152/ncp_api/public/api/"
    Public BaseURLParent As String = "nibrasonline.id"
    Public Oops_kesalahan As String = "Oops! Terjadi Kesalahan, Silahkan Hubungi IT"
    Public Oops_404 As String = "Oops! Server tidak ditemukan, Silahkan Hubungi IT (404)"
    Public Oops_401 As String = "Oops! Terjadi Kesalahan Pada Server, Silahkan Hubungi IT (401)"
    Public Oops_noInternet As String = "Oops! Komputer tidak terhubung dengan Internet!"
    Public Oops_isiProfil As String = "Silahkan Lengkapi Data Toko Terlebih Dahulu!"
    Public Oops_Progress As String = "Oops! Maaf menu ini masih belum Rilis. Mohon Tunggu yaa..."

    Public qKasOnly As String = "SELECT*FROM perkiraan WHERE parentacc = '1-1100' AND kodeacc NOT IN ('1-1140', '1-1141')"

    Public Sub seting_laporan()
        With crConnectionInfo
            .ServerName = "db_pos"
            .UserID = "root"
            .Password = ""
        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
    End Sub

    Dim lokasi As String = Application.StartupPath & "\Config.txt"
    Dim lokasiVersion As String = Application.StartupPath & "\version.txt"

    Dim server As String
    Dim userServer As String
    Dim passServer As String
    Dim dbName As String
    Dim baris As String()
    Dim barisVersion As String()

    Public Sub Koneksi()

        'MyDb = "Driver={Mysql ODBC 8.0 ANSI Driver};Database=jualbelidb;server=localhost;uid=root"
        'Conn = New OdbcConnection(MyDb)
        'If Conn.State = ConnectionState.Closed Then Conn.Open()

        Try
            baris = File.ReadAllLines(lokasi)
            Conn.ConnectionString = "server=" & baris(0) & ";user=" & baris(1) & ";password=" & baris(2)

            cekOpen()
            CMD = New MySqlCommand("SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '" & baris(3) & "' ", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If (DR.HasRows) Then
                cekClose()

                Conn.ConnectionString = "server=" & baris(0) & ";database=" & baris(3) & ";user=" &
                    baris(1) & ";password=" & baris(2)

                cekOpen()
                If Conn.State = ConnectionState.Open Then
                    'MsgBox("Connected!")
                Else
                    MsgBox("Oops! Terjadi Kesalahan, Silahkan hubungi tim IT")
                End If
                cekClose()

            Else
                cekClose()
                MsgBox("Maaf! Tidak Ditemukan Database dengan Nama: " & baris(3) & "!! Silahkan Lakukan Pengaturan Terlebih Dahulu")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub cekKoneksi()
        Try
            baris = File.ReadAllLines(lokasi)
            Conn.ConnectionString = "server=" & baris(0) & ";database=" & baris(3) & ";user=" &
                    baris(1) & ";password=" & baris(2)
            If Conn.State <> ConnectionState.Open Then Conn.Open() Else Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub cekOpen()
        If Conn.State <> ConnectionState.Open Then
            Conn.Open()
        End If
    End Sub

    Public Sub cekClose()
        If Conn.State <> ConnectionState.Closed Then
            Conn.Close()
        End If
    End Sub

    Public Function CheckForInternetConnection() As Boolean
        If My.Computer.Network.IsAvailable Then
            Try
                Dim IPHost As IPHostEntry = Dns.GetHostEntry("www.google.com")
                Return True
            Catch
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    Public Sub SetDoubleBuffered(ByVal dgv As DataGridView, ByVal setting As Boolean)
        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, setting, Nothing)
    End Sub

    Friend Sub ShowForm(ByVal _childForm As Form, ByVal frm_master As Form)
        Dim objForms As Form
        Dim _parentForm As Form = frm_master
        For Each objForms In _parentForm.MdiChildren
            If objForms.Name = _childForm.Name Then
                _childForm.Dispose()
                _childForm = Nothing
                objForms.Show()
                objForms.Visible = True
                objForms.Focus()
                Return
            End If
        Next
        With _childForm
            .MdiParent = _parentForm
            .Show()
        End With
    End Sub

    Public Function getVersion()
        barisVersion = File.ReadAllLines(lokasiVersion)

        Return barisVersion(0)
    End Function

    Public Function getIDToko()
        baris = File.ReadAllLines(lokasi)

        Return baris(4)
    End Function

    Public Function getBaseUrl()
        Dim BASE_URL As String

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM config_url WHERE config_name = 'BASE_URL'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            BASE_URL = DR.Item("config_url")
        Else
            BASE_URL = "http://68.183.190.216/ncp_api/public/api/"
        End If
        cekClose()

        Return BASE_URL
    End Function

    Public Function GetPrinterKasir()
        Dim printerName As String

        cekClose()
        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM config_url WHERE config_name = 'printer_kasir'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            printerName = DR.Item("config_url")
        Else
            printerName = "empty"
        End If
        cekClose()

        Return printerName
    End Function

    Public Function GetPrinterLaporan()
        Dim printerName As String

        cekClose()
        cekOpen()
        CMD = New MySqlCommand("SELECT*FROM config_url WHERE config_name = 'printer_laporan'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            printerName = DR.Item("config_url")
        Else
            printerName = "empty"
        End If
        cekClose()

        Return printerName
    End Function

    Public Sub InsertLogTrans(ByVal notrans As String, ByVal operation As String,
                                   ByVal creator As String, ByVal notes As String)

        cekClose()
        cekOpen()
        CMD = New MySqlCommand("INSERT INTO `config_logs` (`no_transaksi`,`operation`,`creator`,`notes`) VALUES('" & notrans & "', '" & operation & "', '" & creator & "', '" & notes & "');", Conn)
        CMD.ExecuteNonQuery()
        cekClose()
    End Sub

    Public Function GetMonthInt(ByVal name As String)
        Dim intMonth As String = "01"

        Select Case name
            Case "JANUARI"
                intMonth = "01"
            Case "FEBRUARI"
                intMonth = "02"
            Case "MARET"
                intMonth = "03"
            Case "APRIL"
                intMonth = "04"
            Case "MEI"
                intMonth = "05"
            Case "JUNI"
                intMonth = "06"
            Case "JULI"
                intMonth = "07"
            Case "AGUSTUS"
                intMonth = "08"
            Case "SEPTEMBER"
                intMonth = "09"
            Case "OKTOBER"
                intMonth = "10"
            Case "NOVEMBER"
                intMonth = "11"
            Case "DESEMBER"
                intMonth = "12"
        End Select

        Return intMonth
    End Function
End Module
