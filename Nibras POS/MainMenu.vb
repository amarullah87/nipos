Imports System.IO
Imports System.Net
Imports System.Text
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json.Linq

Public Class MainMenu

    Inherits DevExpress.XtraBars.Ribbon.RibbonForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Dim hkr As New HotKeyRegistryClass(Me.Handle)
    Dim btnLogout As Boolean = False

    Private Sub BarButtonItem38_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mDaftarItem.ItemClick
        DaftarItem.MdiParent = Me
        DaftarItem.Show()
        DaftarItem.Focus()
    End Sub



    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call PengaturanMenu()

        Me.Text = ".:: Nibra's POS - " & PanelUser.Text & " - " & PanelID.Text & " - " & PanelToko.Text & " ::."
        Me.WindowState = FormWindowState.Maximized
        Home.MdiParent = Me
        Home.Show()

        If PanelUser.Text <> "superadmin" Then
            panelSuper.Visible = False
        End If

        Timer1.Start()
        'Register Global Shortcut
        'hkr.Register(HotKeyRegistryClass.Modifiers.MOD_CTRL, Keys.L).ToString()
        hkr.Register(HotKeyRegistryClass.Modifiers.MOD_CTRL, Keys.F9).ToString()
        hkr.Register(HotKeyRegistryClass.Modifiers.MOD_CTRL, Keys.F10).ToString()
        hkr.Register(HotKeyRegistryClass.Modifiers.MOD_CTRL, Keys.F11).ToString()
        hkr.Register(HotKeyRegistryClass.Modifiers.MOD_CTRL, Keys.F12).ToString()

        Call GetLeads()
        'Call UpdateUtility()
        Call checkVersion()

        PanelVersion.Text = "NiPOS ver. " & Application.ProductVersion.ToString
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If CheckForInternetConnection() Then
            Me.Text = ".:: Nibra's POS - " & PanelUser.Text & " - " & PanelID.Text & " - " & PanelToko.Text & " ::."
        Else
            Me.Text = ".:: Nibra's POS ::. ----- POS anda dalam keadaan Offline! -----"
        End If

        Dim time As DateTime = DateTime.Now
        Dim format As String = "dd MMM yyyy HH:mm:ss"
        PanelTime.Text = " - " + time.ToString(format) + " - "

        Dim hour As Integer = DateTime.Now.TimeOfDay.Hours
        Dim minute As Integer = DateTime.Now.TimeOfDay.Minutes
        Dim second As Integer = DateTime.Now.TimeOfDay.Seconds

        If hour = 9 And minute = 0 And second = 1 Then
            Call uploadStok()
        ElseIf hour = 12 And minute = 0 And second = 1 Then
            Call uploadStok()
        ElseIf hour = 15 And minute = 0 And second = 1 Then
            Call uploadStok()
        ElseIf hour = 18 And minute = 0 And second = 1 Then
            Call uploadStok()
        End If
        'Console.WriteLine(minute)
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mMember.ItemClick
        ListDataMember.MdiParent = Me
        ListDataMember.Show()
        ListDataMember.Focus()
    End Sub

    Private Sub BarButtonItem39_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem39.ItemClick
        Home.MdiParent = Me
        Home.Show()
        Home.Focus()
    End Sub

    Private Sub BarDockingMenuItem1_ListItemClick(sender As Object, e As DevExpress.XtraBars.ListItemClickEventArgs) Handles BarDockingMenuItem1.ListItemClick
        MasterGroup.Show()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mDistributor.ItemClick
        MasterSupplier.MdiParent = Me
        MasterSupplier.Show()
        MasterSupplier.Focus()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mProfil.ItemClick
        MasterProfil.ShowDialog()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If PanelID.Text <> "" Then
            PesananPembelian.MdiParent = Me
            PesananPembelian.Show()
            PesananPembelian.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        If PanelID.Text <> "" Then
            TransaksiPembelianOld.MdiParent = Me
            TransaksiPembelianOld.Show()
            TransaksiPembelianOld.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        If PanelID.Text <> "" Then
            HistoryPembelian.MdiParent = Me
            HistoryPembelian.Show()
            HistoryPembelian.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        If PanelID.Text <> "" Then
            TransaksiReturPembelian.MdiParent = Me
            TransaksiReturPembelian.Show()
            TransaksiReturPembelian.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem40_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem40.ItemClick
        If PanelID.Text <> "" Then
            cekClose()
            cekOpen()
            CMD = New MySqlCommand("SELECT COUNT(*) AS total FROM pembelian WHERE status_beli='BELUM LUNAS' ", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If Integer.Parse(DR.Item("total")) > 0 Then
                TransaksiBayarUtang.MdiParent = Me
                TransaksiBayarUtang.Show()
                TransaksiBayarUtang.Focus()
            Else
                MsgBox("Semua Hutang Sudah Lunas", MsgBoxStyle.Information)
            End If
            cekClose()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        If PanelID.Text <> "" Then
            If PanelJenis.Text <> "D" Then
                DaftarPenjualan.MdiParent = Me
                DaftarPenjualan.Show()
                DaftarPenjualan.Focus()
            Else
                'TransaksiPenjualan.MdiParent = Me
                'TransaksiPenjualan.Show()
                'TransaksiPenjualan.Focus()
                DaftarPenjualan.MdiParent = Me
                DaftarPenjualan.Show()
                DaftarPenjualan.Focus()
            End If
        Else
            MsgBox("Silahkan Lengkapi Data Toko Terlebih Dahulu!")
        End If
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If PanelID.Text <> "" Then
            PesananPenjualan.MdiParent = Me
            PesananPenjualan.Show()
            PesananPenjualan.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        If PanelID.Text <> "" Then
            HistoryPenjualan.MdiParent = Me
            HistoryPenjualan.Show()
            HistoryPenjualan.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        If PanelID.Text <> "" Then
            DaftarReturJual.MdiParent = Me
            DaftarReturJual.Show()
            DaftarReturJual.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem41_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mBayarPiutang.ItemClick
        If PanelID.Text <> "" Then
            cekOpen()
            CMD = New MySqlCommand("SELECT COUNT(*) AS total FROM penjualan WHERE status_jual='BELUM LUNAS' ", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If Integer.Parse(DR.Item("total")) > 0 Then
                TransaksiTerimaPiutang.MdiParent = Me
                TransaksiTerimaPiutang.Show()
                TransaksiTerimaPiutang.Focus()
            Else
                MsgBox("Tidak Ada Data Piutang!", MsgBoxStyle.Information)
            End If
            cekClose()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        If PanelID.Text <> "" Then
            SaldoAwalPersediaan.MdiParent = Me
            SaldoAwalPersediaan.Show()
            SaldoAwalPersediaan.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        If PanelID.Text <> "" Then
            DaftarSO.MdiParent = Me
            DaftarSO.Show()
            DaftarSO.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
        'MsgBox("Oops! Mohon Maaf Sedang dalam Perbaikan", MsgBoxStyle.Information, "Perhatian")
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        If PanelID.Text <> "" Then
            DaftarItemMasuk.MdiParent = Me
            DaftarItemMasuk.Show()
            DaftarItemMasuk.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        If PanelID.Text <> "" Then
            DaftarItemKeluar.MdiParent = Me
            DaftarItemKeluar.Show()
            DaftarItemKeluar.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        'MasterPerkiraan.MdiParent = Me
        'MasterPerkiraan.Show()
        'MasterPerkiraan.Focus()
        MasterPerkiraanNew.MdiParent = Me
        MasterPerkiraanNew.Show()
        MasterPerkiraanNew.Focus()
    End Sub

    Private Sub BarButtonItem21_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        If PanelID.Text <> "" Then
            DepositPelanggan.MdiParent = Me
            DepositPelanggan.Show()
            DepositPelanggan.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick
        If PanelID.Text <> "" Then
            SaldoAwalHutangForm.MdiParent = Me
            SaldoAwalHutangForm.Show()
            SaldoAwalHutangForm.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem26_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem26.ItemClick
        If PanelID.Text <> "" Then
            SaldoAwalPiutangForm.MdiParent = Me
            SaldoAwalPiutangForm.Show()
            SaldoAwalPiutangForm.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        If PanelID.Text <> "" Then
            DaftarJurnal.MdiParent = Me
            DaftarJurnal.Show()
            DaftarJurnal.Focus()
            'ListJurnal.MdiParent = Me
            'ListJurnal.Show()
            'ListJurnal.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem30_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem30.ItemClick
        If PanelID.Text <> "" Then
            'ReportJurnal.MdiParent = Me
            ReportJurnal.Show()
            ReportJurnal.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
        'Process.Start("report\JurnalUmum.rpt")
    End Sub

    Private Sub BarButtonItem31_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem31.ItemClick
        'Process.Start("report\BukuBesar.rpt")
        If PanelID.Text <> "" Then
            'ReportBukuBesar.MdiParent = Me
            ReportBukuBesar.Show()
            ReportBukuBesar.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem32_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem32.ItemClick
        'Process.Start("report\Neraca.rpt")
        If PanelID.Text <> "" Then
            'ReportNeraca.MdiParent = Me
            ReportNeraca.Show()
            ReportNeraca.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem33_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem33.ItemClick
        'Process.Start("report\LabaRugi.rpt")
        If PanelID.Text <> "" Then
            'ReportLabaRugi.MdiParent = Me
            ReportLabaRugi.Show()
            ReportLabaRugi.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem28_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick
        TambahDepositSupplier.ShowDialog()
    End Sub

    Private Sub BarButtonItem24_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        If PanelID.Text <> "" Then
            SaldoAwalPerkiraan.MdiParent = Me
            SaldoAwalPerkiraan.Show()
            SaldoAwalPerkiraan.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem42_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem42.ItemClick
        If MessageBox.Show("hapus semua data transaksi...?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            cekClose()
            cekOpen()
            CMD = New MySqlCommand("DELETE FROM arus_kas", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("DELETE FROM arus_kas_detail", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("UPDATE arus_kas_saldo SET saldo_akhir = 0", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("DELETE FROM arus_kas_saldo_history", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("DELETE FROM hutang", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("DELETE FROM piutang", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("DELETE FROM leads", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("DELETE FROM member_m WHERE kode_member <> '00000' ", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("DELETE FROM pending_jual", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("DELETE FROM pending_jual_detail", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("DELETE FROM stok_awal", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("DELETE FROM stok_opname_berkala", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("UPDATE barang_m SET stok = 0", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("UPDATE config_point SET nominal = 0", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("delete from pembelian", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from pembelian_order", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from detailbeli", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from detailbeli_order", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from returpembelian", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from detailreturbeli", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("delete from penjualan", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from penjualan_order", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from detailjual", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from detailjual_order", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from returpenjualan", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from detailreturjual", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("delete from terimapiutang", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from bayarutang", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from jurnal", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("UPDATE member_m SET deposit = 0", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from member_deposit", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("UPDATE supplier_m SET deposit = 0", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from supplier_deposit", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("UPDATE mst_distributor SET deposit = 0", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("delete from history_stok", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from history_hpp", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from history_saldo_persediaan", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("delete from saldo_awal", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from saldo_awal_hutang", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from saldo_awal_persediaan", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from saldo_awal_piutang", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from stok_opname", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("delete from transaksi_barang", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from transaksi_barang_detail", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("delete from tblprofil", Conn)
            CMD.ExecuteNonQuery()
            CMD = New MySqlCommand("delete from temp_stok_opname", Conn)
            CMD.ExecuteNonQuery()

            cekClose()

            Call InsertLogTrans("-", "DELETE", PanelUser.Text, "Clear All Transaksi")

            MsgBox("Data transaksi berhasil dihapus", MsgBoxStyle.Information)
            btnLogout = True
            Application.Restart()

        End If
    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        If PanelID.Text <> "" Then
            DaftarKasMasuk.MdiParent = Me
            DaftarKasMasuk.Show()
            DaftarKasMasuk.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        If PanelID.Text <> "" Then
            DaftarKasKeluar.MdiParent = Me
            DaftarKasKeluar.Show()
            DaftarKasKeluar.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem29_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick
        If PanelID.Text <> "" Then
            DaftarKasTransfer.MdiParent = Me
            DaftarKasTransfer.Show()
            DaftarKasTransfer.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem51_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem51.ItemClick
        If PanelID.Text <> "" Then
            DaftarPembayaranHutang.MdiParent = Me
            DaftarPembayaranHutang.Show()
            DaftarPembayaranHutang.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem52_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mPenjualanPembayaran.ItemClick
        If PanelID.Text <> "" Then
            DaftarPembayaranPiutang.MdiParent = Me
            DaftarPembayaranPiutang.Show()
            DaftarPembayaranPiutang.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem53_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem53.ItemClick
        Call CheckForUpdate()
    End Sub

    Sub CheckForUpdate()
        Try
            Dim url As String
            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM config_url WHERE config_name = 'version' ", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                url = DR.Item("config_url")
            Else
                url = "http://nibrasonline.id/pos_update/version.txt"
            End If
            cekClose()

            Dim request As HttpWebRequest = HttpWebRequest.Create(url)
            Dim response As HttpWebResponse = request.GetResponse
            Dim sr As StreamReader = New StreamReader(response.GetResponseStream)
            Dim newestVersion As String = sr.ReadToEnd
            'Dim newestVersion As String = sr.ReadLine

            'Dim list As New List(Of String)
            'Do While (Not newestVersion Is Nothing)
            '    list.Add(newestVersion)
            '    'Console.WriteLine(newestVersion)
            '    newestVersion = sr.ReadLine
            '    Console.Write(newestVersion + "-")
            'Loop

            Dim currentVersion As String = getVersion()

            If newestVersion.ToString <> currentVersion.ToString Then
                MsgBox("Terdapat Update di Server. Silahkan Lakukan Update Aplikasi.", MsgBoxStyle.Exclamation)
            Else
                MsgBox("POS dalam Versi Terbaru!", MsgBoxStyle.Information)
            End If

            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Call uploadStok()
    End Sub

    Sub UpdateUtility()
        SplashScreenManager1.ShowWaitForm()
        Threading.Thread.Sleep(2000)
        Dim url As String
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM config_url WHERE config_name = 'update_utils' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        'If DR.HasRows Then
        '    url = DR.Item("config_url")
        'Else
        '    url = "ftp://iix10.cloudhost.id/public_html/pos_update/files/utils/"
        'End If
        cekClose()
        url = "ftp://117.53.45.237/files/utility/"

        Dim myProcesses() As Process
        Dim myProcess As Process

        myProcesses = Process.GetProcessesByName("Nibras POS Utility")

        Try

            If myProcesses.Length > 0 Then
                For Each myProcess In myProcesses
                    If myProcess IsNot Nothing Then
                        myProcess.Kill()
                    End If

                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Call downloadFile(url)
        'Call downloadFile()

        SplashScreenManager1.CloseWaitForm()

        Call openUtility()
    End Sub

    Sub downloadFile(ByVal url As String)
        If CheckForInternetConnection() Then
            Dim ftpRequest As FtpWebRequest = DirectCast(WebRequest.Create(url), FtpWebRequest)
            ftpRequest.Credentials = New NetworkCredential("baba", "N4n4un4n4!@#")
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory
            Dim response As FtpWebResponse = DirectCast(ftpRequest.GetResponse(), FtpWebResponse)
            Dim streamReader As New StreamReader(response.GetResponseStream())
            Dim directories As New List(Of String)()

            Dim line As String = streamReader.ReadLine()
            While Not String.IsNullOrEmpty(line)
                directories.Add(line)
                line = streamReader.ReadLine()
            End While
            streamReader.Close()


            Using ftpClient As New WebClient()
                ftpClient.Credentials = New NetworkCredential("baba", "N4n4un4n4!@#")
                Console.WriteLine("Connected")

                Dim count As Integer = 1
                For i As Integer = 0 To directories.Count - 1
                    If directories(i).Contains(".") Then

                        Dim path As String = url + directories(i).ToString()
                        Dim trnsfrpth As String = directories(i).ToString()
                        ftpClient.DownloadFile(path, trnsfrpth)
                    End If
                Next
            End Using
            MsgBox("Download Selesai", MsgBoxStyle.Information)
        Else
            MsgBox(Oops_noInternet, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub BarButtonItem54_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem54.ItemClick
        Call UpdateUtility()
    End Sub

    'Private Sub downloadFile()
    '    If CheckForInternetConnection() Then

    '        Try
    '            Dim Port As Integer = 22
    '            Dim Host As String = "117.53.45.237"
    '            Dim Username As String = "root"
    '            Dim Password As String = "N4n4un4n4!"
    '            Dim RemotePath As String = "/var/www/html/utility/"
    '            Dim FileName As String = "Nibras POS Utility.exe"
    '            Dim SourceFilePath As String = FileName
    '            Dim finalDir As String = ""

    '            Using stream = New FileStream(SourceFilePath, FileMode.Create)

    '                Using client = New SftpClient(Host, Port, Username, Password)
    '                    Console.WriteLine("Connecting to " & Host & " as " & Username)
    '                    client.Connect()
    '                    Console.WriteLine("Connected!")


    '                    Dim RemoteFilePath As String = RemotePath & FileName
    '                    Dim attrs As SftpFileAttributes = client.GetAttributes(RemoteFilePath)
    '                    Dim max As Integer = CInt(attrs.Size)
    '                    client.DownloadFile(RemoteFilePath, stream)
    '                    MsgBox("Download Selesai", MsgBoxStyle.Information, "Utility")
    '                End Using
    '            End Using
    '        Catch e As Exception
    '            MessageBox.Show(e.Message)
    '        End Try

    '    Else
    '        MsgBox(Oops_noInternet, MsgBoxStyle.Exclamation)
    '    End If
    'End Sub

    Private Sub openUtility()
        Dim myProcesses() As Process
        myProcesses = Process.GetProcessesByName("Nibras POS Utility")

        Try

            If myProcesses.Length > 0 Then
            Else
                Dim strPath As String = Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().CodeBase)
                Process.Start(strPath + "\Nibras POS Utility.exe")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub menuLogout_ItemClick(sender As Object, e As ItemClickEventArgs) Handles menuLogout.ItemClick
        'Me.MainMenu_FormClosing = False
        btnLogout = True
        Application.Restart()
        'Environment.Exit(1)
    End Sub

    Private Sub lapPembelianAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapPembelianAll.ItemClick
        If PanelID.Text <> "" Then
            'LaporanPembelian.MdiParent = Me
            LaporanPembelian.Show()
            LaporanPembelian.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapPembelianItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapPembelianItem.ItemClick
        If PanelID.Text <> "" Then
            'LaporanPembelianItem.MdiParent = Me
            LaporanPembelianItem.Show()
            LaporanPembelianItem.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapPenjualanAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapPenjualanAll.ItemClick
        If PanelID.Text <> "" Then
            'LaporanPenjualan.MdiParent = Me
            LaporanPenjualan.Show()
            LaporanPenjualan.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapPenjualanItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapPenjualanItem.ItemClick
        If PanelID.Text <> "" Then
            'PenjualanItem.MdiParent = Me
            PenjualanItem.Show()
            PenjualanItem.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapPenjualanCustomer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapPenjualanCustomer.ItemClick
        If PanelID.Text <> "" Then
            'PenjualanMember.MdiParent = Me
            PenjualanMember.Show()
            PencarianMember.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapPenjualan10_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapPenjualan10.ItemClick
        If PanelID.Text <> "" Then
            'Penjualan10Terbanyak.MdiParent = Me
            Penjualan10Terbanyak.Show()
            Penjualan10Terbanyak.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapPenjualanRekap_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapPenjualanRekap.ItemClick
        If PanelID.Text <> "" Then
            RekapPenjualan.Show()
            RekapPenjualan.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapMasterCust_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapMasterCust.ItemClick
        If PanelID.Text <> "" Then
            LaporanMasterCust.Show()
            LaporanMasterCust.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapMasterItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapMasterItem.ItemClick
        If PanelID.Text <> "" Then
            LaporanMasterItem.Show()
            LaporanMasterItem.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapNettSales_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapNettSales.ItemClick
        'MsgBox("Mohon Maaf, Fasilitas dalam tahap pengembangan.", MsgBoxStyle.Information, "Perhatian")
        If PanelID.Text <> "" Then
            ReportNetSales.Show()
            ReportNetSales.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnLapHutangBeredar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapHutangBeredar.ItemClick
        If PanelID.Text <> "" Then
            LaporanHutangTable.MdiParent = Me
            LaporanHutangTable.Show()
            LaporanHutangBeredar.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnLapPiutangBeredar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapPiutangBeredar.ItemClick
        If PanelID.Text <> "" Then
            LaporanPiutangTable.MdiParent = Me
            LaporanPiutangTable.Show()
            LaporanPiutangTable.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnLapMutasiStok_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapMutasiStok.ItemClick
        If PanelID.Text <> "" Then
            LaporanMutasiItem.Show()
            LaporanMutasiItem.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapRekapCust_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapRekapCust.ItemClick
        If PanelID.Text <> "" Then
            LaporanRekapCustomer.Show()
            LaporanRekapCustomer.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnLapReturJual_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapReturJual.ItemClick
        If PanelID.Text <> "" Then
            LaporanReturPenjualan.Show()
            LaporanReturPenjualan.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnLapItemMasuk_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapItemMasuk.ItemClick
        If PanelID.Text <> "" Then
            LaporanPersediaan.Show()
            LaporanPersediaan.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnLapItemKeluar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapItemKeluar.ItemClick
        If PanelID.Text <> "" Then
            LaporanPersediaanKeluar.Show()
            LaporanPersediaanKeluar.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnLapKasKeluar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapKasKeluar.ItemClick
        'MsgBox(Oops_Progress, MsgBoxStyle.Information, "Informasi")
        If PanelID.Text <> "" Then
            LaporanKasKeluar.Show()
            LaporanKasKeluar.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnLapKasMasuk_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapKasMasuk.ItemClick
        'MsgBox(Oops_Progress, MsgBoxStyle.Information, "Informasi")
        If PanelID.Text <> "" Then
            LaporanKasMasuk.Show()
            LaporanKasMasuk.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnLapKasTransfer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapKasTransfer.ItemClick
        'MsgBox(Oops_Progress, MsgBoxStyle.Information, "Informasi")
        If PanelID.Text <> "" Then
            LaporanKasTransfer.Show()
            LaporanKasTransfer.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapRekapCust10_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapRekapCust10.ItemClick
        If PanelID.Text <> "" Then
            LaporanRekapCustomer10.Show()
            LaporanRekapCustomer10.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Sub AddLeads(ByVal jenis As Integer)
        Dim where As String
        If jenis = 1 Then
            where = "ON DUPLICATE KEY UPDATE total = total + 1"
        Else
            where = "ON DUPLICATE KEY UPDATE total = total - 1"
        End If
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("INSERT INTO leads (tanggal, jenis, total) VALUES ('" & DateTime.Now.ToString("yyyy-MM-dd") & "', 'retail', 1) " & where, Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        Call GetLeads()
    End Sub

    Sub AddLeadsJaringan(ByVal jenis As Integer)
        Dim where As String
        If jenis = 1 Then
            where = "ON DUPLICATE KEY UPDATE total = total + 1"
        Else
            where = "ON DUPLICATE KEY UPDATE total = total - 1"
        End If
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("INSERT INTO leads (tanggal, jenis, total) VALUES ('" & DateTime.Now.ToString("yyyy-MM-dd") & "', 'jaringan', 1) " & where, Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        Call GetLeads()
    End Sub

    Sub GetLeads()
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM leads WHERE tanggal ='" & DateTime.Now.ToString("yyyy-MM-dd") & "' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            If DR.Item("jenis") = "retail" Then
                PanelLeads.Text = "Total Leads Retail : " & DR.Item("total")
            Else
                PanelLeadsJ.Text = "Total Leads Jaringan : " & DR.Item("total")
            End If
        Loop
        cekClose()
        'Call GetLeadsJaringan()
    End Sub

    Sub GetLeadsX()
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM leads WHERE tanggal ='" & DateTime.Now.ToString("yyyy-MM-dd") & "' AND jenis = 'retail'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            PanelLeads.Text = "Total Leads Retail : " & DR.Item("total")
            cekClose()
        Else
            PanelLeads.Text = "Total Leads Retail : 0"
        End If

        'Call GetLeadsJaringan()
    End Sub

    Sub GetLeadsJaringan()
        cekClose()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM leads WHERE tanggal ='" & DateTime.Now.ToString("yyyy-MM-dd") & "' AND jenis = 'jaringan'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            PanelLeadsJ.Text = "Total Leads Jaringan : " & DR.Item("total")
            cekClose()
        Else
            PanelLeadsJ.Text = "Total Leads Jaringan : 0"
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = HotKeyRegistryClass.Messages.WM_HOTKEY Then 'NOT THE ACTUAL WINDOWS NAMESPACE
            Dim ID As String = m.WParam.ToString()
            Select Case ID
                Case 0 : AddLeads(0)
                Case 1 : AddLeads(1)
                Case 2 : AddLeadsJaringan(0)
                Case 3 : AddLeadsJaringan(1)
                Case 4 : MessageBox.Show("G")
                Case 5 : MessageBox.Show("H")
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub menuKelompokUser_ItemClick(sender As Object, e As ItemClickEventArgs) Handles menuKelompokUser.ItemClick
        MsgBox("Mohon Maaf, Sedang dalam tahap Pengembangan.", MsgBoxStyle.Information, "Oops")
    End Sub

    Private Sub menuDaftarUser_ItemClick(sender As Object, e As ItemClickEventArgs) Handles menuDaftarUser.ItemClick
        If PanelID.Text <> "" Then
            DaftarUser.ShowDialog()
            DaftarUser.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Sub PengaturanMenu()
        If PanelKode.Text = "MANAGER" Then

            groupUser.Visible = False

        ElseIf PanelKode.Text = "KASIR" Then

            Pembelian.Visible = False
            Persediaan.Visible = False
            Akuntansi.Visible = False
            groupProfil.Visible = False
            groupPiutang.Visible = False
            groupKeuangan.Visible = False
            groupPembelian.Visible = False
            groupMaster.Visible = False
            groupPersediaan.Visible = False
            groupKas.Visible = False
            groupUser.Visible = False

            btnLapPiutangBeredar.Enabled = False
        End If
    End Sub

    Private Sub lapRekapNHs_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapRekapNHs.ItemClick
        If PanelID.Text <> "" Then
            LaporanRekapCustNHs.Show()
            LaporanRekapCustNHs.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnBackup_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnBackup.ItemClick
        If PanelID.Text <> "" Then
            BackupDatabase.ShowDialog()
            BackupDatabase.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnRestore_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRestore.ItemClick
        If PanelID.Text <> "" Then
            RestoreDatabase.ShowDialog()
            RestoreDatabase.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BarButtonItem62_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem62.ItemClick
        If PanelID.Text <> "" Then
            UploadTransaksiForm.ShowDialog()
            UploadTransaksiForm.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Sub checkVersion()

        Call cekKoneksi()
        Dim Raw As String = ""
        If CheckForInternetConnection() Then
            Try
                Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "command")
                Request.Method = "POST"
                Request.Timeout = 3600000
                Request.Proxy = Nothing

                Dim postbody As String = "idoutlet=" & PanelID.Text & "&version=" & getVersion()
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                Request.ContentType = "application/x-www-form-urlencoded"
                Request.ContentLength = byteArray.Length

                Console.WriteLine(postbody)

                Dim dataStream As Stream = Request.GetRequestStream()

                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()

                Dim Response As WebResponse = Request.GetResponse()
                Dim Read = New StreamReader(Response.GetResponseStream())
                Raw = ""
                Raw = Read.ReadToEnd()
                Console.WriteLine(Raw)
                'MsgBox(Raw)

                Dim jsonObject As JObject = JObject.Parse(Raw)
                If jsonObject.SelectToken("code").ToString = "200" Then
                    Call cekKoneksi()
                    Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)

                    For Each item As JObject In JsonArray
                        If item.SelectToken("status").ToString = 1 Then

                        ElseIf item.SelectToken("status").ToString = 2 Then

                            Dim jenis As String = item.SelectToken("keterangan").ToString
                            If jenis = "utility" Then
                                Call UpdateUtility()
                            End If

                        End If

                    Next
                Else
                    'MsgBox(Oops_401)
                End If

            Catch ex As WebException
                If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                    'MsgBox(ex.Message.ToString)
                    MsgBox("Tidak dapat terhubung dengan Server!")
                End If
            End Try
        Else
            MsgBox("POS Dalam Keadaan Offline!")
        End If

    End Sub

    Private Sub BarButtonItem3_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        If PanelID.Text <> "" Then
            TransaksiPembelian.MdiParent = Me
            TransaksiPembelian.Show()
            TransaksiPembelian.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub MainMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False

        If btnLogout = False Then
            DialogExit.Show()
        End If


        'Application.Exit()
        'Dim result As DialogResult = XtraMessageBox.Show("Apakah anda akan melakukan Backup Database Terlebih dahulu sebelum keluar?" & vbCrLf & "Hal ini dilakukan untuk mencegah kejadian tidak terduga", "Konfirmasi", MessageBoxButtons.YesNo)
        'If result = DialogResult.Yes Then

        '    e.Cancel = False
        '    Dim mysqlLocation As String
        '    cekClose()
        '    cekOpen()
        '    CMD = New MySqlCommand("SELECT * FROM config_url WHERE config_name = 'mysql'", Conn)
        '    DR = CMD.ExecuteReader
        '    DR.Read()
        '    If DR.HasRows Then
        '        mysqlLocation = DR.Item("config_url")
        '    Else
        '        mysqlLocation = "C:\xampp\mysql\bin\"
        '    End If

        '    cekClose()


        '    Dim dbFile As String
        '    Try
        '        SaveFileDialog1.Filter = "SQL Backup File (*.sql)|*.sql|All Files (*.*)|*.*"
        '        SaveFileDialog1.FileName = "NiPOS Database Backup " + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".sql"

        '        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
        '            cekOpen()
        '            dbFile = SaveFileDialog1.FileName
        '            Dim BackupProcess As New Process
        '            BackupProcess.StartInfo.FileName = "cmd.exe"
        '            BackupProcess.StartInfo.UseShellExecute = False
        '            BackupProcess.StartInfo.WorkingDirectory = mysqlLocation
        '            BackupProcess.StartInfo.RedirectStandardInput = True
        '            BackupProcess.StartInfo.RedirectStandardOutput = True
        '            BackupProcess.Start()

        '            Dim BackupStream As StreamWriter = BackupProcess.StandardInput
        '            Dim myStream As StreamReader = BackupProcess.StandardOutput
        '            BackupStream.WriteLine("mysqldump --user=root --password= -h localhost --databases db_pos > """ + dbFile + """")

        '            BackupStream.Close()
        '            BackupProcess.WaitForExit()
        '            BackupProcess.Close()
        '            cekClose()

        '            'MsgBox("Data Berhasil di backup!", MsgBoxStyle.Information, "NiPOS Backup")
        '        End If

        '    Catch ex As Exception
        '        MsgBox("Oops! Nothing to do!")
        '    End Try

        '    Environment.Exit(1)
        'Else
        '    SplashScreenManager1.ShowWaitForm()

        '    e.Cancel = False
        '    Environment.Exit(1)
        '    'Application.Exit()
        'End If
    End Sub

    Private Sub BarButtonItem41_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem41.ItemClick
        If PanelID.Text <> "" Then
            SettingPrinter.ShowDialog()
            SettingPrinter.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub chartJualBulan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles chartJualBulan.ItemClick
        If PanelID.Text <> "" Then
            LaporanGrafikBulan.ShowDialog()
            LaporanGrafikBulan.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub chartJualHari_ItemClick(sender As Object, e As ItemClickEventArgs) Handles chartJualHari.ItemClick
        If PanelID.Text <> "" Then
            LaporanGrafikHari.ShowDialog()
            LaporanGrafikHari.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub chartLabaJualItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles chartLabaJualItem.ItemClick
        If PanelID.Text <> "" Then
            LaporanGrafik10.ShowDialog()
            LaporanGrafik10.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub PanelVersion_DoubleClick(sender As Object, e As EventArgs) Handles PanelVersion.DoubleClick
        Call CheckForUpdate()
    End Sub

    Private Sub btnLapReturBeli_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapReturBeli.ItemClick
        If PanelID.Text <> "" Then
            LaporanReturBeli.ShowDialog()
            LaporanReturBeli.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnHelp_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnHelp.ItemClick
        Dim help As New Process
        help.StartInfo.UseShellExecute = True
        help.StartInfo.FileName = "c:\windows\hh.exe"
        help.StartInfo.Arguments = "manual.chm"
        help.Start()
    End Sub

    Private Sub BarButtonItem52_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem52.ItemClick
        If PanelID.Text <> "" Then
            LogAktivitas.ShowDialog()
            LogAktivitas.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lapKasir_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lapKasir.ItemClick
        If PanelID.Text <> "" Then
            LaporanKasir.Show()
            LaporanKasir.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnLapKasir_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLapKasir.ItemClick
        If PanelID.Text <> "" Then
            LaporanKasir.Show()
            LaporanKasir.Focus()
        Else
            MsgBox(Oops_isiProfil, MsgBoxStyle.Critical)
        End If
    End Sub
End Class