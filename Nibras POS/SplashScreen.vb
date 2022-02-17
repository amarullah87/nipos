Imports System.IO
Imports System.Reflection
Imports MySql.Data.MySqlClient

Public Class SplashScreen

    Dim lokasi As String = Application.StartupPath & "\Config.txt"
    Dim server As String
    Dim userServer As String
    Dim passServer As String
    Dim dbName As String
    Dim baris As String()

    Sub LoadProfileToko()
        baris = File.ReadAllLines(lokasi)
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM tblprofil LIMIT 1", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            MainMenu.PanelID.Text = DR.Item("idkey")
            MainMenu.PanelJenis.Text = DR.Item("jenis_nhs")
            MainMenu.PanelKode.Text = txtKodeUser.Text
            MainMenu.PanelUser.Text = txtUsername.Text
            MainMenu.PanelToko.Text = DR.Item("nama")

            Dim newData As String() = {baris(0), baris(1), baris(2), baris(3), DR.Item("idkey")}
            File.WriteAllLines(lokasi, newData)
        End If

        cekClose()
    End Sub

    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim currentVersion As String = Application.ProductVersion
        lblVersion.Text = "Nibras POS v." & currentVersion.ToString
        Timer1.Start()
        LoadProfileToko()
        'executeFile()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox2.Width += 25
        If PictureBox2.Width >= 470 Then
            If getVersion() = "1.10.1" Then
                LoadNewQuery()

                'Update new View 3 Juni 2021
                UpdateView()

                cekOpen()
                CMD = New MySqlCommand("SELECT * FROM config_system WHERE config_name = 'update_produk'", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                If DR.HasRows Then
                    Dim status As Integer = DR.Item("status")
                    cekClose()

                    If status = 1 Then
                        cekOpen()
                        CMD = New MySqlCommand("UPDATE config_system SET status = 0 WHERE config_name = 'update_produk'", Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()
                        UpdateItem()
                    End If
                Else
                    cekClose()

                    cekOpen()
                    CMD = New MySqlCommand("CALL AddNewTable('barang_m', 'updatedate', 'DATETIME NULL'); ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("UPDATE barang_m SET updatedate = '2020-05-01'", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("INSERT INTO config_system (`config_name`, `status`) VALUES ('update_produk', 0)", Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    UpdateItem()
                End If

                '5 Juli 2021 Add column Pembelian
                cekOpen()
                CMD = New MySqlCommand("SELECT*FROM config_system WHERE config_name = 'add_col_pembelian_keterangan'", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                If DR.HasRows Then

                Else
                    cekClose()

                    cekOpen()
                    CMD = New MySqlCommand("CALL AddNewTable('config_system', 'update_date', 'TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP'); ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("CALL AddNewTable('pembelian', 'keterangan', 'VARCHAR(150) NULL'); ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("CALL AddNewTable('pembelian', 'created_date', 'TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP'); ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("CALL AddNewTable('penjualan', 'keterangan', 'VARCHAR(150) NULL'); ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("CALL AddNewTable('penjualan', 'created_date', 'TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP'); ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("CALL AddNewTable('hutang', 'keterangan', 'VARCHAR(150) NULL'); ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("CALL AddNewTable('piutang', 'keterangan', 'VARCHAR(150) NULL'); ", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("INSERT INTO config_system (`config_name`, `status`, update_date) VALUES ('add_col_pembelian_keterangan', 0, NOW())", Conn)
                    CMD.ExecuteNonQuery()

                    CMD = New MySqlCommand("UPDATE config_system SET update_date = NOW()", Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()
                End If

            End If

            If getVersion() = "1.12" Then

                Dim status As String = ""
                cekOpen()
                CMD = New MySqlCommand("SELECT status FROM config_system WHERE config_name = 'update_v12'", Conn)
                DR = CMD.ExecuteReader
                DR.Read()

                If DR.HasRows Then
                    status = DR.Item("status")
                End If
                cekClose()

                If status = "" Or status = "1" Then
                    Call CommandUpdateSebelas()
                End If

            End If

            Timer1.Stop()
            Me.Visible = False
            MainMenu.Show()
            'Me.Close()
        End If
    End Sub

    Sub CommandUpdateSebelas()
        cekClose()
        Dim baris As String()
        baris = File.ReadAllLines(lokasi)
        Dim kolompenjualan As String = ""
        Dim tableMarket As String = ""
        Dim databaseName As String = baris(3)

        '' Add Column Jenis Member untuk menentukan penjualan member darimana (Offline/ Marketplace) | Diskon All (Persen & Rupiah) pada table penjualan
        cekOpen()
        CMD = New MySqlCommand("SELECT COLUMN_NAME FROM information_schema.COLUMNS WHERE  TABLE_SCHEMA = '" & databaseName & "' AND TABLE_NAME = 'penjualan' AND COLUMN_NAME = 'jenis_member'", Conn)
        kolompenjualan = CMD.ExecuteScalar
        cekClose()

        If kolompenjualan = "" Then
            'Console.WriteLine(DR.Item("COLUMN_NAME") & " penjualan masuk")
            cekOpen()
            CMD = New MySqlCommand("ALTER TABLE `penjualan`
  ADD COLUMN `diskon_all` DECIMAL (5, 2) DEFAULT 0.00 NULL AFTER `kembali_jual`,
  ADD COLUMN `diskon_all_rp` DOUBLE DEFAULT 0 NULL AFTER `diskon_all`,
  ADD COLUMN `jenis_member` VARCHAR (30) DEFAULT 'Offline' NULL AFTER `keterangan`; ", Conn)
            CMD.ExecuteNonQuery()
            cekClose()
        End If

        ' Add Table Market Place
        cekOpen()
        CMD = New MySqlCommand("SELECT COLUMN_NAME FROM information_schema.COLUMNS WHERE  TABLE_SCHEMA = '" & databaseName & "' AND TABLE_NAME = 'market_place' AND COLUMN_NAME = 'name'", Conn)
        tableMarket = CMD.ExecuteScalar
        cekClose()

        If tableMarket = "" Then
            cekOpen()
            CMD = New MySqlCommand("CREATE TABLE `market_place` (`id` SMALLINT NOT NULL AUTO_INCREMENT, `name` VARCHAR (100) NOT NULL, PRIMARY KEY (`id`));", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("INSERT INTO `market_place` (name) VALUES ('Offline'),('Tokopedia'),('Shopee'),('Lazada'),('Bukalapak'),('Blibli'),('Orami'),('Ralali'),('Zalora');", Conn)
            CMD.ExecuteNonQuery()
            cekClose()
        End If

        cekOpen()
        ''Add default config mysql Location
        CMD = New MySqlCommand("SELECT * FROM config_url WHERE config_name = 'mysql'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            cekClose()
            cekOpen()
            CMD = New MySqlCommand("INSERT INTO config_url (config_name, config_url) VALUES ('mysql', 'C:\\xampp\\mysql\\bin\\') ON DUPLICATE KEY UPDATE config_url = 'C:\\xampp\\mysql\\bin\\'; ", Conn)
            CMD.ExecuteNonQuery()
        End If
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("INSERT IGNORE INTO config_url (config_name, config_url) VALUES ('printer_kasir', '- Belum di Set -'); ", Conn)
        CMD.ExecuteNonQuery()
        CMD = New MySqlCommand("INSERT IGNORE INTO config_url (config_name, config_url) VALUES ('printer_laporan', '- Belum di Set -'); ", Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_kas_keluar; CREATE VIEW `v2_kas_keluar` AS 
SELECT
  `ak`.`no_transaksi` AS `no_transaksi`,
  `ak`.`tanggal`      AS `tanggal`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`ak`.`kodeacc`,'/',1),(LENGTH(SUBSTRING_INDEX(`ak`.`kodeacc`,'/',(1 - 1))) + 1)),'/','') AS `acc_awal`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`ak`.`kodeacc`,'/',2),(LENGTH(SUBSTRING_INDEX(`ak`.`kodeacc`,'/',(2 - 1))) + 1)),'/','') AS `nama_awal`,
  `ak`.`jumlah`       AS `jumlah`,
  `ak`.`kodeacc_tf`   AS `tujuan`,
  `ak`.`jenis`        AS `jenis`,
  `ad`.`kodeacc`      AS `acc_tujuan`,
  `ad`.`namaacc`      AS `nama_tujuan`,
  `ad`.`keterangan`   AS `keterangan`,
  `ad`.`total`        AS `total`,
  `ak`.`created_date` AS `created_date`
FROM (`arus_kas_detail` `ad`
   JOIN `arus_kas` `ak`
     ON ((`ak`.`no_transaksi` = `ad`.`no_transaksi`)))
WHERE (`ak`.`jenis` = 'keluar')
ORDER BY `ak`.`created_date` DESC", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_kas_masuk; CREATE VIEW `v2_kas_masuk` AS 
SELECT
  `ak`.`no_transaksi` AS `no_transaksi`,
  `ak`.`tanggal`      AS `tanggal`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`ak`.`kodeacc`,'/',1),(LENGTH(SUBSTRING_INDEX(`ak`.`kodeacc`,'/',(1 - 1))) + 1)),'/','') AS `acc_awal`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`ak`.`kodeacc`,'/',2),(LENGTH(SUBSTRING_INDEX(`ak`.`kodeacc`,'/',(2 - 1))) + 1)),'/','') AS `nama_awal`,
  `ak`.`jumlah`       AS `jumlah`,
  `ak`.`kodeacc_tf`   AS `tujuan`,
  `ak`.`jenis`        AS `jenis`,
  `ad`.`kodeacc`      AS `acc_tujuan`,
  `ad`.`namaacc`      AS `nama_tujuan`,
  `ad`.`keterangan`   AS `keterangan`,
  `ad`.`total`        AS `total`,
  `ak`.`created_date` AS `created_date`
FROM (`arus_kas_detail` `ad`
   JOIN `arus_kas` `ak`
     ON ((`ak`.`no_transaksi` = `ad`.`no_transaksi`)))
WHERE (`ak`.`jenis` = 'masuk')
ORDER BY `ak`.`created_date` DESC", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_kas_transfer; CREATE VIEW `v2_kas_transfer` AS 
SELECT
  `arus_kas`.`no_transaksi` AS `no_transaksi`,
  `arus_kas`.`tanggal`      AS `tanggal`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`arus_kas`.`kodeacc`,'/',1),(LENGTH(SUBSTRING_INDEX(`arus_kas`.`kodeacc`,'/',(1 - 1))) + 1)),'/','') AS `acc_awal`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`arus_kas`.`kodeacc`,'/',2),(LENGTH(SUBSTRING_INDEX(`arus_kas`.`kodeacc`,'/',(2 - 1))) + 1)),'/','') AS `nama_awal`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`arus_kas`.`kodeacc_tf`,'/',1),(LENGTH(SUBSTRING_INDEX(`arus_kas`.`kodeacc_tf`,'/',(1 - 1))) + 1)),'/','') AS `acc_akhir`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`arus_kas`.`kodeacc_tf`,'/',2),(LENGTH(SUBSTRING_INDEX(`arus_kas`.`kodeacc_tf`,'/',(2 - 1))) + 1)),'/','') AS `nama_akhir`,
  `arus_kas`.`keterangan`   AS `keterangan`,
  `arus_kas`.`jumlah`       AS `jumlah`,
  `arus_kas`.`jenis`        AS `jenis`,
  `arus_kas`.`created_by`   AS `created_by`,
  `arus_kas`.`created_date` AS `created_date`
FROM `arus_kas`
WHERE (`arus_kas`.`jenis` = 'transfer')
ORDER BY `arus_kas`.`created_date` DESC", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_profile; CREATE VIEW `v2_profile` AS (
SELECT
  `tblprofil`.`idkey`     AS `idkey`,
  `tblprofil`.`nama`      AS `nama`,
  `tblprofil`.`alamat`    AS `alamat`,
  `tblprofil`.`telepon`   AS `telepon`,
  `tblprofil`.`fax`       AS `fax`,
  `tblprofil`.`email`     AS `email`,
  `tblprofil`.`webSite`   AS `webSite`,
  `tblprofil`.`id_toko`   AS `id_toko`,
  `tblprofil`.`jenis_nhs` AS `jenis_nhs`
FROM `tblprofil`
LIMIT 1)", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_penjualan_grafik; CREATE VIEW `v2_penjualan_grafik` AS 
SELECT
  RIGHT(`p`.`tgl_jual`,2) AS `short_date`,
  `p`.`faktur_jual`    AS `faktur_jual`,
  `p`.`tgl_jual`       AS `tgl_jual`,
  `p`.`item_jual`      AS `item_jual`,
  `p`.`total_diskon`   AS `total_diskon`,
  `p`.`total_jual`     AS `total_jual`,
  `p`.`bayar_jual`     AS `bayar_jual`,
  `p`.`kembali_jual`   AS `kembali_jual`,
  `p`.`cara_jual`      AS `cara_jual`,
  `p`.`sisa_piutang`   AS `sisa_piutang`,
  `p`.`jth_tempo_jual` AS `jth_tempo_jual`,
  `p`.`status_jual`    AS `status_jual`,
  `p`.`tunai`          AS `tunai`,
  `p`.`kredit`         AS `kredit`,
  `p`.`debit_a`        AS `debit_a`,
  `p`.`bank_a`         AS `bank_a`,
  `p`.`kartu_a`        AS `kartu_a`,
  `p`.`debit_b`        AS `debit_b`,
  `p`.`bank_b`         AS `bank_b`,
  `p`.`kartu_b`        AS `kartu_b`,
  `p`.`credit_card`    AS `credit_card`,
  `p`.`bank_cc`        AS `bank_cc`,
  `p`.`kartu_cc`       AS `kartu_cc`,
  `p`.`emoney`         AS `emoney`,
  `p`.`bank_emoney`    AS `bank_emoney`,
  `p`.`kartu_emoney`   AS `kartu_emoney`,
  `p`.`kode_customer`  AS `kode_customer`,
  `p`.`kode_user`      AS `kode_user`,
  `p`.`transfer`       AS `transfer`,
  `p`.`ongkir`         AS `ongkir`,
  `p`.`deposit`        AS `deposit`,
  `p`.`keterangan`     AS `keterangan`,
  `p`.`created_date`   AS `created_date`
FROM `penjualan` `p`
WHERE (NOT((`p`.`faktur_jual` LIKE 'BTL%')))", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_piutang_beredar; CREATE VIEW `v2_piutang_beredar` AS 
SELECT
  `p`.`no_transaksi` AS `no_transaksi`,
  `p`.`no_faktur`    AS `no_faktur`,
  `p`.`kode_member`  AS `kode_member`,
  `p`.`tanggal`      AS `tanggal`,
  `p`.`tanggal_jt`   AS `tanggal_jt`,
  `p`.`kodeacc`      AS `kodeacc`,
  `p`.`potongan`     AS `potongan`,
  `p`.`total`        AS `total`,
  `p`.`jumlah_bayar` AS `jumlah_bayar`,
  `p`.`sisa`         AS `sisa`,
  `p`.`keterangan`   AS `keterangan`,
  `p`.`jenis`        AS `jenis`,
  `p`.`created_by`   AS `created_by`,
  `p`.`created_date` AS `created_date`,
  `p`.`status`       AS `status`,
  `p`.`mapping`      AS `mapping`,
  `p`.`cara_bayar`   AS `cara_bayar`,
  `p`.`status_lunas` AS `status_lunas`,
  `m`.`nama_member`  AS `nama_member`,
  (TO_DAYS(NOW()) - TO_DAYS(`p`.`tanggal_jt`)) AS `umur_jt`,
  `t`.`nama`         AS `nama`,
  `t`.`alamat`       AS `alamat`,
  `t`.`telepon`      AS `telepon`
FROM ((`piutang` `p`
    JOIN `member_m` `m`
      ON ((`m`.`kode_member` = `p`.`kode_member`)))
   LEFT JOIN `tblprofil` `t`
     ON ((`t`.`id_toko` = `t`.`id_toko`)))
WHERE (`p`.`status_lunas` = 0)UNION SELECT
                                `f`.`faktur_jual`    AS `no_transaksi`,
                                `f`.`faktur_jual`    AS `no_faktur`,
                                SUBSTRING_INDEX(`f`.`kode_customer`,'/',1) AS `kode_member`,
                                `f`.`tgl_jual`       AS `tanggal`,
                                `f`.`jth_tempo_jual` AS `tanggal_jt`,
                                '1-1210'             AS `kodeacc`,
                                0                    AS `potongan`,
                                `f`.`total_jual`     AS `total`,
                                `f`.`bayar_jual`     AS `jumlah_bayar`,
                                `f`.`sisa_piutang`   AS `sisa`,
                                ''                   AS `keterangan`,
                                'Penjualan'          AS `jenis`,
                                `f`.`kode_user`      AS `created_by`,
                                `f`.`tgl_jual`       AS `created_date`,
                                IF((`f`.`sisa_piutang` > 0),1,0) AS `status`,
                                ''                   AS `mapping`,
                                `f`.`cara_jual`      AS `cara_bayar`,
                                `f`.`status_jual`    AS `status_lunas`,
                                SUBSTRING_INDEX(`f`.`kode_customer`,'/',-(1)) AS `nama`,
                                (TO_DAYS(NOW()) - TO_DAYS(`f`.`jth_tempo_jual`)) AS `umur_jt`,
                                `t`.`nama`           AS `nama`,
                                `t`.`alamat`         AS `alamat`,
                                `t`.`telepon`        AS `telepon`
                              FROM (`penjualan` `f`
                                 LEFT JOIN `tblprofil` `t`
                                   ON ((`t`.`id_toko` = `t`.`id_toko`)))
                              WHERE ((`f`.`sisa_piutang` > 0)
                                     AND (NOT((`f`.`faktur_jual` LIKE 'BTL%'))))", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("CREATE TABLE IF NOT EXISTS `config_logs` (
  `created` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `no_transaksi` VARCHAR (30) NOT NULL,
  `operation` ENUM ('CREATE', 'UPDATE') NOT NULL,
  `creator` VARCHAR (30),
  `notes` VARCHAR (200),
  PRIMARY KEY (`created`)
);", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_penjualan_hari_grafik; CREATE VIEW `v2_penjualan_hari_grafik` AS 
SELECT
  tgl_jual, RIGHT(`penjualan`.`created_date`,8) AS `jam_jual`, `penjualan`.`total_jual` AS `total_jual`
FROM `penjualan`", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_penjualan_10_grafik; CREATE VIEW `v2_penjualan_10_grafik` AS 
SELECT
  `b`.`nama_barang` AS `nama_barang`,
  `p`.`tgl_jual`    AS `tgl_jual`,
  `d`.`qty_jual`    AS `qty_jual`
FROM ((`detailjual` `d`
    JOIN `penjualan` `p`
      ON ((`p`.`faktur_jual` = `d`.`faktur_jual`)))
   JOIN `barang_m` `b`
     ON ((`b`.`kode_item` = `d`.`kode_barang`)))
WHERE ((NOT((`p`.`faktur_jual` LIKE 'BTL%')))
       AND (NOT((`b`.`nama_barang` LIKE 'kartu%'))))", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("ALTER TABLE `returpembelian`
  CHANGE `faktur_beli` `faktur_beli` VARCHAR (20) CHARSET latin1 COLLATE latin1_swedish_ci NULL;", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v_laporan_penjualan; CREATE VIEW `v_laporan_penjualan` AS 
SELECT
  `p`.`faktur_jual`    AS `faktur_jual`,
  `p`.`tgl_jual`       AS `tgl_jual`,
  `p`.`item_jual`      AS `item_jual`,
  `p`.`total_jual`     AS `total_jual`,
  `p`.`bayar_jual`     AS `bayar_jual`,
  `p`.`kembali_jual`   AS `kembali_jual`,
  `p`.`cara_jual`      AS `cara_jual`,
  `p`.`sisa_piutang`   AS `sisa_piutang`,
  `p`.`jth_tempo_jual` AS `jth_tempo_jual`,
  `p`.`status_jual`    AS `status_jual`,
  `p`.`tunai`          AS `tunai`,
  `p`.`kredit`         AS `kredit`,
  `p`.`debit_a`        AS `debit_a`,
  `p`.`bank_a`         AS `bank_a`,
  `p`.`kartu_a`        AS `kartu_a`,
  `p`.`debit_b`        AS `debit_b`,
  `p`.`bank_b`         AS `bank_b`,
  `p`.`kartu_b`        AS `kartu_b`,
  `p`.`credit_card`    AS `credit_card`,
  `p`.`bank_cc`        AS `bank_cc`,
  `p`.`kartu_cc`       AS `kartu_cc`,
  `p`.`emoney`         AS `emoney`,
  `p`.`bank_emoney`    AS `bank_emoney`,
  `p`.`kartu_emoney`   AS `kartu_emoney`,
  `p`.`kode_customer`  AS `kode_customer`,
  `p`.`kode_user`      AS `kode_user`,
  `p`.`ongkir`         AS `ongkir`,
  `d`.`kode_barang`    AS `kode_barang`,
  `b`.`nama_barang`    AS `nama_barang`,
  `b`.`satuan`         AS `satuan`,
  `d`.`harga_jual`     AS `harga_jual`,
  `d`.`qty_jual`       AS `qty_jual`,
  `d`.`diskon`         AS `diskon`,
  `d`.`subtotal_jual`  AS `subtotal_jual`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`,'/',1),(LENGTH(SUBSTRING_INDEX(`p`.`kode_customer`,'/',(1 - 1))) + 1)),'/','') AS `kode_member`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`,'/',2),(LENGTH(SUBSTRING_INDEX(`p`.`kode_customer`,'/',(2 - 1))) + 1)),'/','') AS `member`,
  `p`.`jenis_member`   AS `jenis_member`
from (((`penjualan` `p`
     join `detailjual` `d`
       on ((`d`.`faktur_jual` = `p`.`faktur_jual`)))
    join `barang_m` `b`
      on ((`b`.`kode_item` = `d`.`kode_barang`))))
where (not((`p`.`faktur_jual` like 'BTL-%')))", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_laporan_persediaan; CREATE VIEW `v2_laporan_persediaan` AS 
SELECT tb.no_transaksi, tb.tanggal, td.kode_item, b.nama_barang, td.qty, b.satuan, tb.jenis_transaksi, tb.keterangan
FRom transaksi_barang_detail td
INNER JOIN transaksi_barang tb ON td.no_transaksi = tb.no_transaksi
INNER JOIN barang_m b ON b.kode_item = td.kode_item ORDER BY tb.no_transaksi DESC", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v_neraca; CREATE VIEW `v_neraca` AS 
select
  `j`.`nomor_transaksi`  AS `nomor_transaksi`,
  `j`.`tgl_transaksi`    AS `tgl_transaksi`,
  `j`.`kode_perkiraan`   AS `kode_perkiraan`,
  `j`.`uraian`           AS `uraian`,
  `j`.`debet`            AS `debet`,
  `j`.`kredit`           AS `kredit`,
  `p`.`parentacc`        AS `parentacc`,
  `p`.`mainparent`       AS `mainparent`,
  `p`.`mainparentname`   AS `mainparentname`,
  `p`.`secondparent`     AS `secondparent`,
  `p`.`secondparentname` AS `secondparentname`,
  `p`.`thirdparent`      AS `thirdparent`,
  `p`.`thirdparentname`  AS `thirdparentname`,
  `p`.`kelompok`         AS `kelompok`,
  `pf`.`nama`            AS `nama`,
  `pf`.`alamat`          AS `alamat`,
  `pf`.`telepon`         AS `telepon`
from ((`jurnal` `j`
    join `perkiraan` `p`
      on ((`j`.`kode_perkiraan` = `p`.`kodeacc`)))
   left join `tblprofil` `pf`
     on ((`pf`.`idkey` = `pf`.`idkey`)))
where (`p`.`kelompok` in(1,2,3))union select
                                        `j`.`nomor_transaksi`   AS `nomor_transaksi`,
                                        `j`.`tgl_transaksi`     AS `tgl_transaksi`,
                                        '3-3000'                AS `kode_perkiraan`,
                                        'LABA TAHUN BERJALAN'   AS `LABA TAHUN BERJALAN`,
                                        `j`.`kredit`            AS `debet`,
                                        `j`.`debet`             AS `kredit`,
                                        `p`.`parentacc`         AS `parentacc`,
                                        '3-0000'                AS `3-0000`,
                                        'EKUITAS'               AS `EKUITAS`,
                                        NULL                    AS `NULL`,
                                        NULL                    AS `NULL`,
                                        NULL                    AS `NULL`,
                                        NULL                    AS `NULL`,
                                        `p`.`kelompok`          AS `kelompok`,
                                        `pf`.`nama`             AS `nama`,
                                        `pf`.`alamat`           AS `alamat`,
                                        `pf`.`telepon`          AS `telepon`
                                      from ((`jurnal` `j`
                                          join `perkiraan` `p`
                                            on ((`p`.`kodeacc` = `j`.`kode_perkiraan`)))
                                         left join `tblprofil` `pf`
                                           on ((`pf`.`idkey` = `pf`.`idkey`)))
                                      where (`p`.`kelompok` in(4,5,6,7,8))", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_retur_penjualan; CREATE VIEW `v2_retur_penjualan` AS 
SELECT
  `rj`.`no_retur_jual`   AS `no_retur_jual`,
  `rj`.`tgl_retur_jual`  AS `tgl_retur_jual`,
  `rj`.`faktur_jual`     AS `faktur_jual`,
  `rj`.`item_retur_jual` AS `item_retur_jual`,
  `rj`.`kode_user`       AS `kode_user`,
  `rj`.`subtotal`        AS `subtotal`,
  `drj`.`kode_barang`    AS `kode_barang`,
  `drj`.`alasan_retur_jual`    AS `alasan_retur_jual`,
  `b`.`nama_barang`      AS `nama_barang`,
  `p`.`kode_customer`    AS `kode_customer`,
  `pf`.`nama`            AS `nama`,
  `pf`.`alamat`          AS `alamat`,
  `pf`.`telepon`         AS `telepon`
FROM ((((`returpenjualan` `rj`
      JOIN `detailreturjual` `drj`
        ON ((`drj`.`no_retur_jual` = `rj`.`no_retur_jual`)))
     JOIN `barang_m` `b`
       ON ((`b`.`kode_item` = `drj`.`kode_barang`)))
    JOIN `penjualan` `p`
      ON ((`p`.`faktur_jual` = `rj`.`faktur_jual`)))
   LEFT JOIN `tblprofil` `pf`
     ON ((`pf`.`idkey` = `pf`.`idkey`)))
ORDER BY `rj`.`no_retur_jual`", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DROP VIEW IF EXISTS v2_retur_pembelian; CREATE VIEW `v2_retur_pembelian` AS 
SELECT
  `rb`.`no_retur_beli`   AS `no_retur_beli`,
  `rb`.`tgl_retur_beli`  AS `tgl_retur_beli`,
  `rb`.`faktur_beli`     AS `faktur_beli`,
  `rb`.`item_retur_beli` AS `item_retur_beli`,
  `rb`.`kode_user`       AS `kode_user`,
  ((`db`.`subtotal_real` / `db`.`qty_real`) * `rb`.`item_retur_beli`) AS `subtotal`,
  `drb`.`kode_barang`    AS `kode_barang`,
  `b`.`nama_barang`      AS `nama_barang`,
  `p`.`nama_supplier`    AS `nama_supplier`
FROM ((((`returpembelian` `rb`
      JOIN `detailreturbeli` `drb`
        ON ((`drb`.`no_retur_beli` = `rb`.`no_retur_beli`)))
     JOIN `barang_m` `b`
       ON ((`b`.`kode_item` = `drb`.`kode_barang`)))
    JOIN `pembelian` `p`
      ON ((`p`.`faktur_beli` = `rb`.`faktur_beli`)))
   JOIN `detailbeli` `db`
     ON ((`db`.`faktur_beli` = `p`.`faktur_beli`) AND (`db`.`kode_barang` = `drb`.`kode_barang`)))
ORDER BY `rb`.`no_retur_beli` DESC", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("CREATE TABLE IF NOT EXISTS `group_usia_produk` (
  `nama_group` VARCHAR (100) NOT NULL,
  `diskon` INT,
  `urutan` SMALLINT,
  PRIMARY KEY (`nama_group`)
);", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("CREATE TABLE IF NOT EXISTS `pembayaran_hp` (
  `no_faktur` VARCHAR (30) NOT NULL,
  `total` DOUBLE DEFAULT 0,
  `diskon` DOUBLE DEFAULT 0,
  `sisa` DOUBLE DEFAULT 0,
  `jenis` VARCHAR (30) NOT NULL,
  `status` SMALLINT DEFAULT 0,
  `created` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`no_faktur`, `jenis`)
);", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("ALTER TABLE `config_logs` CHANGE `operation` `operation` ENUM ('CREATE', 'UPDATE', 'DELETE') NOT NULL;", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("ALTER TABLE `terimapiutang` CHANGE `faktur_jual` `faktur_jual` VARCHAR (30) NULL", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DELETE FROM mst_distributor WHERE nama LIKE '%test%'", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("UPDATE barang_m SET stok_min = 1", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("CREATE TABLE IF NOT EXISTS `member_poin` (
  `kode_member` VARCHAR (100) NOT NULL,
  `no_transaksi` VARCHAR (50) NOT NULL,
  `kelipatan` DOUBLE,
  `total_transaksi` DOUBLE,
  `poin` INT,
  `created` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`kode_member`, `no_transaksi`)
);", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("INSERT INTO `config_system` (`config_name`, `status`) VALUES ('update_v12', 0) ON DUPLICATE KEY UPDATE `status` = 0", Conn)
        CMD.ExecuteNonQuery()

        'CMD = New MySqlCommand("", Conn)
        'CMD.ExecuteNonQuery()
        cekClose()

        MsgBox("NiPOS Updated to version 1.1.12", MsgBoxStyle.Information, "Berhasil")
    End Sub

    Sub executeFile()
        Dim dbCreateScriptPath As String = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "produk.sql")
        MessageBox.Show("Trying to access DML script at:  {dbCreateScriptPath}.")

        If Not File.Exists(dbCreateScriptPath) Then
            MessageBox.Show("The DML script {dbCreateScriptPath} does not exist.")
            Return
        End If

        Dim script As String = File.ReadAllText(dbCreateScriptPath)
        MessageBox.Show(script)
        If String.IsNullOrEmpty(script) Then
            MessageBox.Show("Failed to load contents of the DML script:" & script)
            Return
        End If
        MessageBox.Show("Successfully loaded contents of the DML script:" & script)

        RunScript(script)
        MessageBox.Show("Successfully executed the DML script:" & script)
    End Sub

    Public Sub RunScript(script As String)
        Try
            MessageBox.Show("Attempting to run script on SQL Server.")
            MessageBox.Show(script)
            cekOpen()
            CMD = New MySqlCommand(script, Conn)
            CMD.ExecuteReader()
            MessageBox.Show("Successfully run script on SQL Server.")
        Catch ex As Exception
            MsgBox("ExecQuery Error:" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            'Close connection
            cekClose()
        End Try
    End Sub

    Sub UpdateItem()
        Console.WriteLine("Masuk ke Update!!!")

        cekOpen()
        CMD = New MySqlCommand("SET GLOBAL max_allowed_packet = 996870912", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem2, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem3, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem4, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem5, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem6, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem7, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem8, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem9, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem10, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem11, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem12, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem13, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem14, Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand(queryItem15, Conn)
        CMD.ExecuteNonQuery()
        cekClose()
    End Sub

    Sub LoadNewQuery()

        cekOpen()
        '###### 18 Januari 2020 #####'

        CMD = New MySqlCommand("CREATE TABLE IF NOT EXISTS `users` (`user_id` VARCHAR (30) NOT NULL,`password` VARCHAR (30),`nama_user` VARCHAR (50),`akses` VARCHAR (30),PRIMARY KEY (`user_id`)); INSERT IGNORE INTO `users` (`user_id`,`password`,`nama_user`,`akses`) VALUES ('ADMIN','admin','admin','ADMINISTRATOR');", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("INSERT INTO `db_pos`.`arus_kas_saldo` (`kodeacc`,`namaacc`,`saldo_akhir`,`updated_at`) VALUES('1-1110','KAS KECIL', 0,NOW()) ON DUPLICATE KEY UPDATE namaacc = 'KAS KECIL';
INSERT INTO `db_pos`.`arus_kas_saldo` (`kodeacc`,`namaacc`,`saldo_akhir`,`updated_at`) VALUES('1-1120','KAS BESAR', 0,NOW()) ON DUPLICATE KEY UPDATE namaacc = 'KAS BESAR';
INSERT INTO `db_pos`.`arus_kas_saldo` (`kodeacc`,`namaacc`,`saldo_akhir`,`updated_at`) VALUES('1-1121','BANK MANDIRI', 0,NOW()) ON DUPLICATE KEY UPDATE namaacc = 'BANK MANDIRI';
INSERT INTO `db_pos`.`arus_kas_saldo` (`kodeacc`,`namaacc`,`saldo_akhir`,`updated_at`) VALUES('1-1122','BANK BCA', 0,NOW()) ON DUPLICATE KEY UPDATE namaacc = 'BANK BCA';
INSERT INTO `db_pos`.`arus_kas_saldo` (`kodeacc`,`namaacc`,`saldo_akhir`,`updated_at`) VALUES('1-1123','BANK BRI', 0,NOW()) ON DUPLICATE KEY UPDATE namaacc = 'BANK BRI';
INSERT INTO `db_pos`.`arus_kas_saldo` (`kodeacc`,`namaacc`,`saldo_akhir`,`updated_at`) VALUES('1-1130','BANK BNI', 0,NOW()) ON DUPLICATE KEY UPDATE namaacc = 'BANK BNI';
INSERT INTO `db_pos`.`arus_kas_saldo` (`kodeacc`,`namaacc`,`saldo_akhir`,`updated_at`) VALUES('1-1140','KAS BIAYA PROMOSI', 0,NOW()) ON DUPLICATE KEY UPDATE namaacc = 'KAS BIAYA PROMOSI';
INSERT INTO `db_pos`.`arus_kas_saldo` (`kodeacc`,`namaacc`,`saldo_akhir`,`updated_at`) VALUES('1-1141','KAS DEPOSIT', 0,NOW()) ON DUPLICATE KEY UPDATE namaacc = 'KAS DEPOSIT';", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("INSERT INTO config_system (`config_name`, `status`) VALUES ('upload_member', 0) ON DUPLICATE KEY UPDATE `status` = 0", Conn)
        CMD.ExecuteNonQuery()

        Dim vFaktur As String = "DROP VIEW IF EXISTS v_faktur; CREATE VIEW `v_faktur` AS 
        SELECT
          `p`.`faktur_jual`    AS `faktur_jual`,
          `p`.`tgl_jual`       AS `tgl_jual`,
          `p`.`item_jual`      AS `item_jual`,
          `p`.`total_jual`     AS `total_jual`,
          `p`.`bayar_jual`     AS `bayar_jual`,
          `p`.`kembali_jual`   AS `kembali_jual`,
          `p`.`cara_jual`      AS `cara_jual`,
          `p`.`sisa_piutang`   AS `sisa_piutang`,
          `p`.`jth_tempo_jual` AS `jth_tempo_jual`,
          `p`.`status_jual`    AS `status_jual`,
          `p`.`tunai`          AS `tunai`,
          `p`.`kredit`         AS `kredit`,
          `p`.`debit_a`        AS `debit_a`,
          `p`.`bank_a`         AS `bank_a`,
          `p`.`kartu_a`        AS `kartu_a`,
          `p`.`debit_b`        AS `debit_b`,
          `p`.`bank_b`         AS `bank_b`,
          `p`.`kartu_b`        AS `kartu_b`,
          `p`.`credit_card`    AS `credit_card`,
          `p`.`bank_cc`        AS `bank_cc`,
          `p`.`kartu_cc`       AS `kartu_cc`,
          `p`.`emoney`         AS `emoney`,
          `p`.`bank_emoney`    AS `bank_emoney`,
          `p`.`kartu_emoney`   AS `kartu_emoney`,
          `p`.`transfer`       AS `transfer`,
          `p`.`ongkir`         AS `ongkir`,
          `p`.`deposit`        AS `deposit`,
          `p`.`kode_customer`  AS `kode_customer`,
          `p`.`kode_user`      AS `kode_user`,
          `p`.`kode_customer`  AS `member`,
          `d`.`kode_barang`    AS `kode_barang`,
          `d`.`harga_jual`     AS `harga_jual`,
          `d`.`qty_jual`       AS `qty_jual`,
          `d`.`subtotal_jual`  AS `subtotal_jual`,
          `d`.`ket_jual`       AS `ket_jual`,
          `d`.`diskon`         AS `diskon`,
          `b`.`nama_barang`    AS `nama_barang`,
          `pf`.`nama`          AS `nama`,
          `pf`.`alamat`        AS `alamat`,
          `pf`.`telepon`       AS `telepon`
        FROM (((`penjualan` `p`
             JOIN `detailjual` `d`
               ON ((`d`.`faktur_jual` = `p`.`faktur_jual`)))
            JOIN `barang_m` `b`
              ON ((`b`.`kode_item` = `d`.`kode_barang`)))
           LEFT JOIN `tblprofil` `pf`
             ON ((`pf`.`idkey` = `pf`.`idkey`)))"
        CMD = New MySqlCommand(vFaktur, Conn)
        CMD.ExecuteNonQuery()

        Dim vHutangBeredar As String = "DROP VIEW IF EXISTS v2_hutang_beredar; CREATE VIEW `v2_hutang_beredar` AS 
SELECT
  `h`.`no_transaksi`  AS `no_transaksi`,
  `h`.`no_faktur`     AS `no_faktur`,
  `h`.`kode_supplier` AS `kode_supplier`,
  `h`.`tanggal`       AS `tanggal`,
  `h`.`tanggal_jt`    AS `tanggal_jt`,
  `h`.`kodeacc`       AS `kodeacc`,
  `h`.`potongan`      AS `potongan`,
  `h`.`total`         AS `total`,
  `h`.`jumlah_bayar`  AS `jumlah_bayar`,
  `h`.`sisa`          AS `sisa`,
  `h`.`keterangan`    AS `keterangan`,
  `h`.`jenis`         AS `jenis`,
  `h`.`created_by`    AS `created_by`,
  `h`.`created_date`  AS `created_date`,
  `h`.`status`        AS `status`,
  `h`.`mapping`       AS `mapping`,
  `h`.`cara_bayar`    AS `cara_bayar`,
  `h`.`status_lunas`  AS `status_lunas`,
  `d`.`nama`          AS `nama`,
  (TO_DAYS(NOW()) - TO_DAYS(`h`.`tanggal_jt`)) AS `umur_jt`,
  `t`.`nama`          AS `nama_toko`,
  `t`.`alamat`        AS `alamat`,
  `t`.`telepon`       AS `telepon`
FROM ((`hutang` `h`
    JOIN `mst_distributor` `d`
      ON ((`h`.`kode_supplier` = `d`.`kode`)))
   LEFT JOIN `tblprofil` `t`
     ON ((`t`.`id_toko` = `t`.`id_toko`)))
WHERE ((`d`.`status` = 1)
       AND (`h`.`status_lunas` = 0))UNION SELECT
                                            `p`.`faktur_beli`    AS `no_transaksi`,
                                            `p`.`faktur_beli`    AS `no_faktur`,
                                            `p`.`kode_supplier`  AS `kode_supplier`,
                                            `p`.`tgl_beli`       AS `tanggal`,
                                            `p`.`jth_tempo_beli` AS `tanggal_jt`,
                                            '2-1101'             AS `kodeacc`,
                                            0                    AS `potongan`,
                                            `p`.`total_beli`     AS `total`,
                                            `p`.`bayar_beli`     AS `jumlah_bayar`,
                                            `p`.`sisa_hutang`    AS `sisa`,
                                            '-'                  AS `keterangan`,
                                            'Pembelian'          AS `jenis`,
                                            'ADMIN'              AS `created_by`,
                                            `p`.`tgl_beli`       AS `created_date`,
                                            1                    AS `status`,
                                            ''                   AS `mapping`,
                                            ''                   AS `cara_bayar`,
                                            IF((`p`.`sisa_hutang` = 0),1,0) AS `status_lunas`,
                                            `m`.`nama`           AS `nama`,
                                            (TO_DAYS(NOW()) - TO_DAYS(`p`.`jth_tempo_beli`)) AS `umur_jt`,
                                            `t`.`nama`           AS `nama_toko`,
                                            `t`.`alamat`         AS `alamat`,
                                            `t`.`telepon`        AS `telepon`
                                          FROM ((`pembelian` `p`
                                              JOIN `mst_distributor` `m`
                                                ON ((`m`.`kode` = `p`.`kode_supplier`)))
                                             LEFT JOIN `tblprofil` `t`
                                               ON ((`t`.`id_toko` = `t`.`id_toko`)))
                                          WHERE (`p`.`sisa_hutang` > 0 AND `p`.`faktur_beli` NOT LIKE 'BTL%')"
        CMD = New MySqlCommand(vHutangBeredar, Conn)
        CMD.ExecuteNonQuery()

        Dim vGetMutasi As String = "DROP VIEW IF EXISTS v2_get_mutasi; CREATE VIEW `v2_get_mutasi` AS 
SELECT `detailbeli`.`kode_barang` AS `kode`,0 AS `awal`,`detailbeli`.`qty_beli` AS `beli`,0 AS `stok`,0 AS `jual`,0 AS `masuk`,0 AS `keluar`,0 AS `rj`,0 AS `rb` FROM `detailbeli` WHERE (NOT((`detailbeli`.`faktur_beli` LIKE 'btl%'))) UNION SELECT `saldo_awal_persediaan`.`kode_item` AS `kode`,SUM(`saldo_awal_persediaan`.`qty`) AS `awal`,0 AS `beli`,0 AS `stok`,0 AS `jual`,0 AS `masuk`,0 AS `keluar`,0 AS `rj`,0 AS `rb` FROM `saldo_awal_persediaan` GROUP BY `saldo_awal_persediaan`.`kode_item` UNION SELECT `barang_m`.`kode_item` AS `kode`,0 AS `awal`,0 AS `beli`,SUM(`barang_m`.`stok`) AS `stok`,0 AS `jual`,0 AS `masuk`,0 AS `keluar`,0 AS `rj`,0 AS `rb` FROM `barang_m` GROUP BY `barang_m`.`kode_item` UNION SELECT `detailjual`.`kode_barang` AS `kode`,0 AS `awal`,0 AS `beli`,0 AS `stok`,SUM(`detailjual`.`qty_jual`) AS `jual`,0 AS `masuk`,0 AS `keluar`,0 AS `rj`,0 AS `rb` FROM `detailjual` WHERE (NOT((`detailjual`.`faktur_jual` LIKE 'btl%'))) GROUP BY `detailjual`.`kode_barang` UNION (SELECT `tbd`.`kode_item` AS `kode`,0 AS `awal`,0 AS `beli`,0 AS `stok`,0 AS `jual`,`tbd`.`qty` AS `masuk`,0 AS `keluar`,0 AS `rj`,0 AS `rb` FROM (`transaksi_barang_detail` `tbd` JOIN `transaksi_barang` `tb` ON((`tb`.`no_transaksi` = `tbd`.`no_transaksi`))) WHERE (`tb`.`jenis_transaksi` = '1')) UNION (SELECT `tbd`.`kode_item` AS `kode`,0 AS `awal`,0 AS `beli`,0 AS `stok`,0 AS `jual`,0 AS `masuk`,`tbd`.`qty` AS `keluar`,0 AS `rj`,0 AS `rb` FROM (`transaksi_barang_detail` `tbd` JOIN `transaksi_barang` `tb` ON((`tb`.`no_transaksi` = `tbd`.`no_transaksi`))) WHERE (`tb`.`jenis_transaksi` = '0')) UNION SELECT `detailreturjual`.`kode_barang` AS `kode`,0 AS `awal`,0 AS `beli`,0 AS `stok`,0 AS `jual`,0 AS `masuk`,0 AS `keluar`,SUM(`detailreturjual`.`qty_retur_jual`) AS `rj`,0 AS `rb` FROM `detailreturjual` GROUP BY `detailreturjual`.`kode_barang` UNION SELECT `detailreturbeli`.`kode_barang` AS `kode`,0 AS `awal`,0 AS `beli`,0 AS `stok`,0 AS `jual`,0 AS `masuk`,0 AS `keluar`,0 AS `rj`,SUM(`detailreturbeli`.`qty_retur_beli`) AS `rb` FROM `detailreturbeli` GROUP BY `detailreturbeli`.`kode_barang`"
        CMD = New MySqlCommand(vGetMutasi, Conn)
        CMD.ExecuteNonQuery()

        Dim vMutasiStok As String = "DROP VIEW IF EXISTS v2_mutasi_stok; CREATE VIEW `v2_mutasi_stok` AS 
SELECT
  `t`.`kode`        AS `kode`,
  `b`.`nama_barang` AS `nama_barang`,
  `b`.`hpp`         AS `hpp`,
  `b`.`satuan`         AS `satuan`,
  SUM(`t`.`awal`)   AS `awal`,
  ((SUM(`t`.`masuk`) + SUM(`t`.`beli`)) + SUM(`t`.`rj`)) AS `total_masuk`,
  ((SUM(`t`.`keluar`) + SUM(`t`.`jual`)) + SUM(`t`.`rb`)) AS `total_keluar`,
  SUM(`t`.`stok`)   AS `stokNIPOS`,
  (SUM((((`t`.`awal` + `t`.`masuk`) + `t`.`beli`) + `t`.`rj`)) - SUM(((`t`.`jual` + `t`.`keluar`) + `t`.`rb`))) AS `stokhit`,
  IF(((SUM((((`t`.`awal` + `t`.`masuk`) + `t`.`beli`) + `t`.`rj`)) - SUM(((`t`.`jual` + `t`.`keluar`) + `t`.`rb`))) < 0),0,(SUM((((`t`.`awal` + `t`.`masuk`) + `t`.`beli`) + `t`.`rj`)) - SUM(((`t`.`jual` + `t`.`keluar`) + `t`.`rb`)))) AS `stokreal`,
  ((SUM((((`t`.`awal` + `t`.`masuk`) + `t`.`beli`) + `t`.`rj`)) - SUM(((`t`.`jual` + `t`.`keluar`) + `t`.`rb`))) - SUM(`t`.`stok`)) AS `selisih`,
  `tp`.`nama`       AS `nama`,
  `tp`.`alamat`     AS `alamat`,
  `tp`.`telepon`    AS `telepon`
FROM ((`v2_get_mutasi` `t`
    JOIN `barang_m` `b`
      ON ((`t`.`kode` = `b`.`kode_item`)))
   LEFT JOIN `tblprofil` `tp`
     ON ((`tp`.`id_toko` = `tp`.`id_toko`)))
WHERE (`t`.`kode` IN(SELECT
                       `barang_m`.`kode_item`
                     FROM `barang_m`)
       AND ((`t`.`awal` > 0)
             OR (`t`.`masuk` > 0)
             OR (`t`.`beli` > 0)
             OR (`t`.`rj` > 0)
             OR (`t`.`keluar` > 0)
             OR (`t`.`jual` > 0)
             OR (`t`.`rb` > 0)))
GROUP BY `t`.`kode`
ORDER BY IF(((SUM((((`t`.`awal` + `t`.`masuk`) + `t`.`beli`) + `t`.`rj`)) - SUM(((`t`.`jual` + `t`.`keluar`) + `t`.`rb`))) < 0),0,(SUM((((`t`.`awal` + `t`.`masuk`) + `t`.`beli`) + `t`.`rj`)) - SUM(((`t`.`jual` + `t`.`keluar`) + `t`.`rb`))))DESC"
        CMD = New MySqlCommand(vMutasiStok, Conn)
        CMD.ExecuteNonQuery()

        Dim vPiutangBeredar As String = "DROP VIEW IF EXISTS v2_piutang_beredar; CREATE VIEW `v2_piutang_beredar` AS 
SELECT
  `p`.`no_transaksi` AS `no_transaksi`,
  `p`.`no_faktur`    AS `no_faktur`,
  `p`.`kode_member`  AS `kode_member`,
  `p`.`tanggal`      AS `tanggal`,
  `p`.`tanggal_jt`   AS `tanggal_jt`,
  `p`.`kodeacc`      AS `kodeacc`,
  `p`.`potongan`     AS `potongan`,
  `p`.`total`        AS `total`,
  `p`.`jumlah_bayar` AS `jumlah_bayar`,
  `p`.`sisa`         AS `sisa`,
  `p`.`keterangan`   AS `keterangan`,
  `p`.`jenis`        AS `jenis`,
  `p`.`created_by`   AS `created_by`,
  `p`.`created_date` AS `created_date`,
  `p`.`status`       AS `status`,
  `p`.`mapping`      AS `mapping`,
  `p`.`cara_bayar`   AS `cara_bayar`,
  `p`.`status_lunas` AS `status_lunas`,
  `m`.`nama_member`  AS `nama_member`,
  (TO_DAYS(NOW()) - TO_DAYS(`p`.`tanggal_jt`)) AS `umur_jt`,
  `t`.`nama`         AS `nama`,
  `t`.`alamat`       AS `alamat`,
  `t`.`telepon`      AS `telepon`
FROM ((`piutang` `p`
    JOIN `member_m` `m`
      ON ((`m`.`kode_member` = `p`.`kode_member`)))
   LEFT JOIN `tblprofil` `t`
     ON ((`t`.`id_toko` = `t`.`id_toko`)))
WHERE (`p`.`status` = 0)UNION SELECT
                                `f`.`faktur_jual`    AS `no_transaksi`,
                                `f`.`faktur_jual`    AS `no_faktur`,
                                SUBSTRING_INDEX(`f`.`kode_customer`,'/',1) AS `kode_member`,
                                `f`.`tgl_jual`       AS `tanggal`,
                                `f`.`jth_tempo_jual` AS `tanggal_jt`,
                                '1-1210'             AS `kodeacc`,
                                0                    AS `potongan`,
                                `f`.`total_jual`     AS `total`,
                                `f`.`bayar_jual`     AS `jumlah_bayar`,
                                `f`.`sisa_piutang`   AS `sisa`,
                                ''                   AS `keterangan`,
                                'Penjualan'          AS `jenis`,
                                `f`.`kode_user`      AS `created_by`,
                                `f`.`tgl_jual`       AS `created_date`,
                                IF((`f`.`sisa_piutang` > 0),1,0) AS `status`,
                                ''                   AS `mapping`,
                                `f`.`cara_jual`      AS `cara_bayar`,
                                `f`.`status_jual`    AS `status_lunas`,
                                SUBSTRING_INDEX(`f`.`kode_customer`,'/',-(1)) AS `nama`,
                                (TO_DAYS(NOW()) - TO_DAYS(`f`.`jth_tempo_jual`)) AS `umur_jt`,
                                `t`.`nama`           AS `nama`,
                                `t`.`alamat`         AS `alamat`,
                                `t`.`telepon`        AS `telepon`
                              FROM (`penjualan` `f`
                                 LEFT JOIN `tblprofil` `t`
                                   ON ((`t`.`id_toko` = `t`.`id_toko`)))
                              WHERE (`f`.`sisa_piutang` > 0 AND `f`.`faktur_jual` NOT LIKE 'BTL%')"
        CMD = New MySqlCommand(vPiutangBeredar, Conn)
        CMD.ExecuteNonQuery()

        Dim vReturPenjualan As String = "DROP VIEW IF EXISTS v2_retur_penjualan; CREATE VIEW `v2_retur_penjualan` AS 
SELECT
  `rj`.`no_retur_jual`   AS `no_retur_jual`,
  `rj`.`tgl_retur_jual`  AS `tgl_retur_jual`,
  `rj`.`faktur_jual`     AS `faktur_jual`,
  `rj`.`item_retur_jual` AS `item_retur_jual`,
  `rj`.`kode_user`       AS `kode_user`,
  `rj`.`subtotal`        AS `subtotal`,
  `drj`.`kode_barang`    AS `kode_barang`,
  `b`.`nama_barang`      AS `nama_barang`,
  `p`.`kode_customer`    AS `kode_customer`,
  `pf`.`nama`            AS `nama`,
  `pf`.`alamat`          AS `alamat`,
  `pf`.`telepon`         AS `telepon`
FROM ((((`returpenjualan` `rj`
      JOIN `detailreturjual` `drj`
        ON ((`drj`.`no_retur_jual` = `rj`.`no_retur_jual`)))
     JOIN `barang_m` `b`
       ON ((`b`.`kode_item` = `drj`.`kode_barang`)))
    JOIN `penjualan` `p`
      ON ((`p`.`faktur_jual` = `rj`.`faktur_jual`)))
   LEFT JOIN `tblprofil` `pf`
     ON ((`pf`.`idkey` = `pf`.`idkey`)))
ORDER BY `rj`.`no_retur_jual`"
        CMD = New MySqlCommand(vReturPenjualan, Conn)
        CMD.ExecuteNonQuery()

        Dim vRekapJualCust As String = "DROP VIEW IF EXISTS v2_rekap_penjualan_cust; CREATE VIEW `v2_rekap_penjualan_cust` AS 
SELECT `p`.`kode_customer` AS `kode_customer`,`p`.`tgl_jual` AS `tgl_jual`,`p`.`faktur_jual` AS `faktur_jual`,`p`.`tunai` AS `tunai`,`p`.`kredit` AS `kredit`,`p`.`debit_a` AS `debit_a`,`p`.`credit_card` AS `credit_card`,`m`.`group_member` AS `group_member`,`f`.`nama` AS `nama`,`f`.`alamat` AS `alamat`,`f`.`telepon` AS `telepon` FROM ((`penjualan` `p` JOIN `member_m` `m` ON((`m`.`kode_member` = REPLACE(SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`,'/',1),(LENGTH(SUBSTRING_INDEX(`p`.`kode_customer`,'/',(1 - 1))) + 1)),'/','')))) LEFT JOIN `tblprofil` `f` ON((`f`.`idkey` = `f`.`idkey`))) WHERE `p`.`faktur_jual` NOT LIKE 'BTL%'"
        CMD = New MySqlCommand(vRekapJualCust, Conn)
        CMD.ExecuteNonQuery()

        Dim vRekapJualCust10 As String = "DROP VIEW IF EXISTS v2_rekap_penjualan_cust10; CREATE VIEW `v2_rekap_penjualan_cust10` AS 
SELECT REPLACE(SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`,'/',1),(LENGTH(SUBSTRING_INDEX(`p`.`kode_customer`,'/',(1 - 1))) + 1)),'/','') AS `kode_member`,REPLACE(SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`,'/',2),(LENGTH(SUBSTRING_INDEX(`p`.`kode_customer`,'/',(2 - 1))) + 2)),'/','') AS `nama_member`,`m`.`alamat` AS `alamat_member`,`m`.`telepon` AS `telp_member`,`p`.`tgl_jual` AS `tgl_jual`,`p`.`faktur_jual` AS `faktur_jual`,`p`.`tunai` AS `tunai`,`p`.`kredit` AS `kredit`,`p`.`debit_a` AS `debit_a`,`p`.`credit_card` AS `credit_card`,`m`.`group_member` AS `group_member`,`f`.`nama` AS `nama`,`f`.`alamat` AS `alamat`,`f`.`telepon` AS `telepon` FROM ((`penjualan` `p` JOIN `member_m` `m` ON((`m`.`kode_member` = REPLACE(SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`,'/',1),(LENGTH(SUBSTRING_INDEX(`p`.`kode_customer`,'/',(1 - 1))) + 1)),'/','')))) LEFT JOIN `tblprofil` `f` ON((`f`.`idkey` = `f`.`idkey`))) WHERE (NOT((`p`.`faktur_jual` LIKE 'BTL%')))"
        CMD = New MySqlCommand(vRekapJualCust10, Conn)
        CMD.ExecuteNonQuery()

        Dim addColumnReturJual As String = "ALTER TABLE `returpenjualan` CHANGE `faktur_jual` `faktur_jual` VARCHAR (15) NULL;"
        CMD = New MySqlCommand(addColumnReturJual, Conn)
        CMD.ExecuteNonQuery()

        'Dim addColumnReturJual2 As String = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME  = 'returpenjualan' AND COLUMN_NAME = 'subtotal' ) ALTER TABLE `returpenjualan` ADD COLUMN `subtotal` DOUBLE DEFAULT 0 NULL AFTER `kode_user`;"
        Dim addColumnReturJual2 As String = "CALL AddNewTable('returpenjualan', 'subtotal', 'DOUBLE DEFAULT 0 NULL');"
        CMD = New MySqlCommand(addColumnReturJual2, Conn)
        CMD.ExecuteNonQuery()

        'Dim addColumnDetailReturJual As String = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME  = 'detailreturjual' AND COLUMN_NAME = 'harga_jual' ) ALTER TABLE `detailreturjual` ADD COLUMN `harga_jual` DOUBLE NULL AFTER `alasan_retur_jual`;"
        Dim addColumnDetailReturJual As String = "CALL AddNewTable('detailreturjual', 'harga_jual', 'DOUBLE DEFAULT 0 NULL');"
        CMD = New MySqlCommand(addColumnDetailReturJual, Conn)
        CMD.ExecuteNonQuery()

        cekClose()
    End Sub

    Sub UpdateView()
        cekOpen()

        'Dim addColumnMemberAktif As String = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME  = 'member_m' AND COLUMN_NAME = 'aktif' ) ALTER TABLE `member_m` ADD COLUMN `aktif` SMALLINT DEFAULT 0 NULL AFTER `masa_aktif`;"
        'CMD = New MySqlCommand(addColumnMemberAktif, Conn)
        'CMD.ExecuteNonQuery()
        Dim AddPerkiraanAceh As String = "insert IGNORE into `perkiraan` (`kodeacc`,`parentacc`,`kelompok`,`tipe`,`namaacc`,`matauang`,`dateupd`,`kasbank`,`defmuutm`,`mainparent`,`mainparentname`,`secondparent`,`secondparentname`,`thirdparent`,`thirdparentname`,`level`) values
('1-1240','1-1200','1','D','PIUTANG KARYAWAN','IDR',now(),0,0,'1-0000','AKTIVA','1-1000','AKTIVA LANCAR','1-1200','PIUTANG',3),
('6-3900','6-3000','6','D','BIAYA PAJAK','IDR',NOW(),0,0,'6-0000','BIAYA','6-3000','BIAYA UMUM',null,null,2),
('6-3001','6-3000','6','D','BIAYA PARKIR','IDR',NOW(),0,0,'6-0000','BIAYA','6-3000','BIAYA UMUM',null,null,2),
('6-3002','6-3000','6','D','BIAYA INFAQ','IDR',NOW(),0,0,'6-0000','BIAYA','6-3000','BIAYA UMUM',null,null,2),
('6-3003','6-3000','6','D','BIAYA KONSUMSI TOKO','IDR',NOW(),0,0,'6-0000','BIAYA','6-3000','BIAYA UMUM',null,null,2),
('6-3005','6-3000','6','D','BIAYA DANA SOSIAL','IDR',NOW(),0,0,'6-0000','BIAYA','6-3000','BIAYA UMUM',null,null,2),
('6-3006','6-3000','6','D','BIAYA REWARD','IDR',NOW(),0,0,'6-0000','BIAYA','6-3000','BIAYA UMUM',null,null,2),
('6-3007','6-3000','6','D','BIAYA PENDIDIKAN','IDR',NOW(),0,0,'6-0000','BIAYA','6-3000','BIAYA UMUM',null,null,2);"
        CMD = New MySqlCommand(AddPerkiraanAceh, Conn)
        CMD.ExecuteNonQuery()

        Dim vLabaRugi As String = "DROP VIEW IF EXISTS `v_labarugi`; CREATE VIEW `v_labarugi` AS 
SELECT
  `j`.`nomor_transaksi`  AS `nomor_transaksi`,
  `j`.`tgl_transaksi`    AS `tgl_transaksi`,
  `j`.`kode_perkiraan`   AS `kode_perkiraan`,
  `j`.`uraian`           AS `uraian`,
  `j`.`debet`            AS `debet`,
  `j`.`kredit`           AS `kredit`,
  `p`.`parentacc`        AS `parentacc`,
  `p`.`mainparent`       AS `mainparent`,
  `p`.`mainparentname`   AS `mainparentname`,
  `p`.`secondparent`     AS `secondparent`,
  `p`.`secondparentname` AS `secondparentname`,
  `p`.`thirdparent`      AS `thirdparent`,
  `p`.`thirdparentname`  AS `thirdparentname`,
  `p`.`kelompok`         AS `kelompok`,
  `pf`.`nama`            AS `nama`,
  `pf`.`alamat`          AS `alamat`,
  `pf`.`telepon`         AS `telepon`
FROM ((`jurnal` `j`
    JOIN `perkiraan` `p`
      ON ((`j`.`kode_perkiraan` = `p`.`kodeacc`)))
   LEFT JOIN `tblprofil` `pf`
     ON ((`pf`.`idkey` = `pf`.`idkey`)))
WHERE (`p`.`kelompok` IN(4,5,6,7,8))
ORDER BY `p`.`mainparent`"
        CMD = New MySqlCommand(vLabaRugi, Conn)
        CMD.ExecuteNonQuery()

        Dim v10Besar As String = "DROP VIEW IF EXISTS `v_10_besar_penjualan`; CREATE VIEW `v_10_besar_penjualan` AS 
SELECT
  `d`.`kode_barang`   AS `kode_barang`,
  `p`.`tgl_jual`      AS `tgl_jual`,
  `b`.`nama_barang`   AS `nama_barang`,
  `b`.`satuan`        AS `satuan`,
  `d`.`harga_jual`    AS `harga_jual`,
  `d`.`qty_jual`      AS `qty_jual`,
  `d`.`subtotal_jual` AS `subtotal_jual`,
  `pf`.`nama`         AS `nama`,
  `pf`.`alamat`       AS `alamat`,
  `pf`.`telepon`      AS `telepon`
FROM (((`detailjual` `d`
     JOIN `penjualan` `p`
       ON ((`p`.`faktur_jual` = `d`.`faktur_jual`)))
    JOIN `barang_m` `b`
      ON ((`b`.`kode_item` = `d`.`kode_barang`)))
   LEFT JOIN `tblprofil` `pf`
     ON ((`pf`.`idkey` = `pf`.`idkey`)))
     WHERE `p`.`faktur_jual` NOT LIKE 'BTL%'"
        CMD = New MySqlCommand(v10Besar, Conn)
        CMD.ExecuteNonQuery()

        Dim vPenjualanItem As String = "DROP VIEW IF EXISTS `v_penjualan_item`; CREATE VIEW `v_penjualan_item` AS 
select
  `dj`.`faktur_jual`   AS `faktur_jual`,
  `dj`.`kode_barang`   AS `kode_barang`,
  `dj`.`harga_jual`    AS `harga_jual`,
  `dj`.`qty_jual`      AS `qty_jual`,
  `dj`.`subtotal_jual` AS `subtotal_jual`,
  `dj`.`ket_jual`      AS `ket_jual`,
  `dj`.`diskon`        AS `diskon`,
  `dj`.`qty_retur`     AS `qty_retur`,
  `p`.`tgl_jual`       AS `tgl_jual`,
  `b`.`nama_barang`    AS `nama_barang`,
  `b`.`satuan`         AS `satuan`,
  `pf`.`nama`          AS `nama`,
  `pf`.`alamat`        AS `alamat`,
  `pf`.`telepon`       AS `telepon`
from (((`detailjual` `dj`
     join `penjualan` `p`
       on ((`p`.`faktur_jual` = `dj`.`faktur_jual`)))
    join `barang_m` `b`
      on ((`b`.`kode_item` = `dj`.`kode_barang`)))
   left join `tblprofil` `pf`
     on ((`pf`.`idkey` = `pf`.`idkey`)))
     WHERE `p`.`faktur_jual` NOT LIKE 'BTL%'"
        CMD = New MySqlCommand(vPenjualanItem, Conn)
        CMD.ExecuteNonQuery()

        Dim vPenjualanRekap As String = "DROP VIEW IF EXISTS `v_penjualan_rekap`; CREATE VIEW `v_penjualan_rekap` AS 
SELECT
  `p`.`faktur_jual`    AS `faktur_jual`,
  `p`.`tgl_jual`       AS `tgl_jual`,
  `p`.`item_jual`      AS `item_jual`,
  `p`.`total_jual`     AS `total_jual`,
  `p`.`bayar_jual`     AS `bayar_jual`,
  `p`.`kembali_jual`   AS `kembali_jual`,
  `p`.`cara_jual`      AS `cara_jual`,
  `p`.`sisa_piutang`   AS `sisa_piutang`,
  `p`.`jth_tempo_jual` AS `jth_tempo_jual`,
  `p`.`status_jual`    AS `status_jual`,
  `p`.`tunai`          AS `tunai`,
  `p`.`kredit`         AS `kredit`,
  `p`.`debit_a`        AS `debit_a`,
  `p`.`bank_a`         AS `bank_a`,
  `p`.`kartu_a`        AS `kartu_a`,
  `p`.`debit_b`        AS `debit_b`,
  `p`.`bank_b`         AS `bank_b`,
  `p`.`kartu_b`        AS `kartu_b`,
  `p`.`credit_card`    AS `credit_card`,
  `p`.`bank_cc`        AS `bank_cc`,
  `p`.`kartu_cc`       AS `kartu_cc`,
  `p`.`emoney`         AS `emoney`,
  `p`.`bank_emoney`    AS `bank_emoney`,
  `p`.`kartu_emoney`   AS `kartu_emoney`,
  `p`.`kode_customer`  AS `kode_customer`,
  `p`.`kode_user`      AS `kode_user`,
  `p`.`ongkir`         AS `ongkir`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`,'/',1),(LENGTH(SUBSTRING_INDEX(`p`.`kode_customer`,'/',(1 - 1))) + 1)),'/','') AS `kode_member`,
  REPLACE(SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`,'/',2),(LENGTH(SUBSTRING_INDEX(`p`.`kode_customer`,'/',(2 - 1))) + 1)),'/','') AS `member`,
  `pf`.`nama`          AS `nama_toko`,
  `pf`.`alamat`        AS `alamat_toko`,
  `pf`.`telepon`       AS `telp_toko`
FROM (`penjualan` `p`
   LEFT JOIN `tblprofil` `pf`
     ON ((`pf`.`idkey` = `pf`.`idkey`)))
WHERE (NOT((`p`.`faktur_jual` LIKE 'BTL-%')))"
        CMD = New MySqlCommand(vPenjualanRekap, Conn)
        CMD.ExecuteNonQuery()


        Dim vRekapCust As String = "DROP VIEW IF EXISTS v2_rekap_penjualan_cust10; CREATE VIEW `v2_rekap_penjualan_cust10` AS
  SELECT REPLACE (SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`, '/', 1),(LENGTH (SUBSTRING_INDEX(`p`.`kode_customer`, '/', (1 - 1))) + 1)),'/','') AS `kode_member`,
    REPLACE (SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`, '/', 2),(LENGTH (SUBSTRING_INDEX(`p`.`kode_customer`, '/', (2 - 1))) + 2)),'/','') AS `nama_member`,
    `m`.`alamat` AS `alamat_member`,
    `m`.`telepon` AS `telp_member`,
    `p`.`tgl_jual` AS `tgl_jual`,
    `p`.`faktur_jual` AS `faktur_jual`,
    `p`.`total_jual` AS `tunai`,
    `p`.`kredit` AS `kredit`,
    `p`.`debit_a` AS `debit_a`,
    `p`.`credit_card` AS `credit_card`,
    `m`.`group_member` AS `group_member`,
    `f`.`nama` AS `nama`,
    `f`.`alamat` AS `alamat`,
    `f`.`telepon` AS `telepon`
  FROM `penjualan` `p`
  
  JOIN `member_m` `m` ON  `m`.`kode_member` = REPLACE (SUBSTR(SUBSTRING_INDEX(`p`.`kode_customer`, '/', 1),(LENGTH(SUBSTRING_INDEX(`p`.`kode_customer`, '/', (1 - 1))) + 1)),'/','')
  LEFT JOIN `tblprofil` `f` ON `f`.`idkey` = `f`.`idkey`
  WHERE `p`.`faktur_jual` NOT LIKE 'BTL%'"
        CMD = New MySqlCommand(vRekapCust, Conn)
        CMD.ExecuteNonQuery()

        Dim vNetSales As String = "DROP VIEW IF EXISTS v_net_sales; CREATE VIEW `v_net_sales` AS
  select
    `penjualan`.`faktur_jual` AS `faktur`,
    `penjualan`.`tgl_jual` AS `tgl_transaksi`,
    `penjualan`.`total_diskon` AS `total_diskon`,
    `penjualan`.`total_jual` AS `total_jual`,
    `penjualan`.`ongkir` AS `ongkir`,
    `penjualan`.`tunai` AS `tunai`,
    `penjualan`.`kredit` AS `kredit`,
    `penjualan`.`debit_a` AS `debit_a`,
    `penjualan`.`credit_card` AS `credit_card`,
    `penjualan`.`emoney` AS `emoney`,
    `penjualan`.`deposit` AS `deposit`,
    `penjualan`.`kembali_jual` AS `kembali_jual`,
    0 AS `total_retur`,
    0 AS `jenis`
  from
    `penjualan`
  union
  select
    `returpenjualan`.`no_retur_jual` AS `faktur`,
    `returpenjualan`.`tgl_retur_jual` AS `tgl_transaksi`,
    0 AS `0`,
    0 AS `0`,
    0 AS `0`,
    0 AS `0`,
    0 AS `0`,
    0 AS `0`,
    0 AS `0`,
    0 AS `0`,
    0 AS `0`,
    0 AS `0`,
    `returpenjualan`.`subtotal` AS `total_retur`,
    1 AS `jenis`
  from
    `returpenjualan`"
        CMD = New MySqlCommand(vNetSales, Conn)
        CMD.ExecuteNonQuery()

        Dim vMasterItem As String = "DROP VIEW IF EXISTS v_master_item; CREATE VIEW `v_master_item` AS 
SELECT
  `b`.`kode_item`   AS `kode_item`,
  `b`.`nama_barang` AS `nama_barang`,
  `k`.`kategori`    AS `kategori`,
  `b`.`stok`        AS `stok`,
  `b`.`satuan`      AS `satuan`,
  `b`.`hpp`         AS `hpp`,
  `b`.`hpj`         AS `hpj`,
  `pf`.`nama`       AS `nama`,
  `pf`.`alamat`     AS `alamat`,
  `pf`.`telepon`    AS `telepon`
FROM ((`barang_m` `b`
    LEFT JOIN `mst_kategori` `k`
      ON ((`b`.`jenis` = `k`.`kode_kategori`)))
   LEFT JOIN `tblprofil` `pf`
     ON ((`pf`.`idkey` = `pf`.`idkey`)))
WHERE (`b`.`stok` <> 0)"
        CMD = New MySqlCommand(vMasterItem, Conn)
        CMD.ExecuteNonQuery()

        Dim vRekapNhs As String = "DROP VIEW IF EXISTS v2_rekap_penjualan_nhs; CREATE VIEW `v2_rekap_penjualan_nhs` AS
  SELECT
    `p`.`kode_customer` AS `kode_customer`,
    `p`.`tgl_jual` AS `tgl_jual`,
    `p`.`faktur_jual` AS `faktur_jual`,
    `p`.`tunai` AS `tunai`,
    `p`.`kredit` AS `kredit`,
    `p`.`debit_a` AS `debit_a`,
    `p`.`credit_card` AS `credit_card`,
    `f`.`nama` AS `nama`,
    `f`.`alamat` AS `alamat`,
    `f`.`telepon` AS `telepon`
FROM `db_pos`.`penjualan` `p`
LEFT JOIN `db_pos`.`tblprofil` `f` ON `f`.`idkey` = `f`.`idkey`
WHERE kode_customer LIKE 'P%';"
        CMD = New MySqlCommand(vRekapNhs, Conn)
        CMD.ExecuteNonQuery()

        Dim vNeracaNew As String = "DROP VIEW IF EXISTS v_neraca; CREATE VIEW `v_neraca` AS 
SELECT
  `j`.`nomor_transaksi`  AS `nomor_transaksi`,
  `j`.`tgl_transaksi`    AS `tgl_transaksi`,
  `j`.`kode_perkiraan`   AS `kode_perkiraan`,
  `j`.`uraian`           AS `uraian`,
  `j`.`debet`            AS `debet`,
  `j`.`kredit`           AS `kredit`,
  `p`.`parentacc`        AS `parentacc`,
  `p`.`mainparent`       AS `mainparent`,
  `p`.`mainparentname`   AS `mainparentname`,
  `p`.`secondparent`     AS `secondparent`,
  `p`.`secondparentname` AS `secondparentname`,
  `p`.`thirdparent`      AS `thirdparent`,
  `p`.`thirdparentname`  AS `thirdparentname`,
  `p`.`kelompok`         AS `kelompok`,
  `pf`.`nama`            AS `nama`,
  `pf`.`alamat`          AS `alamat`,
  `pf`.`telepon`         AS `telepon`
FROM ((`jurnal` `j`
    JOIN `perkiraan` `p`
      ON ((`j`.`kode_perkiraan` = `p`.`kodeacc`)))
   LEFT JOIN `tblprofil` `pf`
     ON ((`pf`.`idkey` = `pf`.`idkey`)))
WHERE (`p`.`kelompok` IN(1,2,3))UNION SELECT
                                        `j`.`nomor_transaksi`   AS `nomor_transaksi`,
                                        `j`.`tgl_transaksi`     AS `tgl_transaksi`,
                                        '3-3000'                AS `kode_perkiraan`,
                                        'LABA TAHUN BERJALAN'   AS `LABA TAHUN BERJALAN`,
                                        `j`.`kredit`            AS `debet`,
                                        `j`.`debet`             AS `kredit`,
                                        `p`.`parentacc`         AS `parentacc`,
                                        '3-0000'                AS `3-0000`,
                                        'EKUITAS'               AS `EKUITAS`,
                                        NULL                    AS `NULL`,
                                        NULL                    AS `NULL`,
                                        NULL                    AS `NULL`,
                                        NULL                    AS `NULL`,
                                        `p`.`kelompok`          AS `kelompok`,
                                        `pf`.`nama`             AS `nama`,
                                        `pf`.`alamat`           AS `alamat`,
                                        `pf`.`telepon`          AS `telepon`
                                      FROM ((`jurnal` `j`
                                          JOIN `perkiraan` `p`
                                            ON ((`p`.`kodeacc` = `j`.`kode_perkiraan`)))
                                         LEFT JOIN `tblprofil` `pf`
                                           ON ((`pf`.`idkey` = `pf`.`idkey`)))
                                      WHERE (`p`.`kelompok` IN(4,5,6,7))"
        CMD = New MySqlCommand(vNeracaNew, Conn)
        CMD.ExecuteNonQuery()

        Dim tablePending As String = "CREATE TABLE IF NOT EXISTS `pending_jual` (
  `faktur_jual` VARCHAR (30) NOT NULL,
  `tanggal` DATE,
  `kode_member` VARCHAR (30),
  `nama_member` VARCHAR (150),
  `qty` INT,
  `total` DOUBLE,
  `ongkir` DOUBLE,
  `created_by` VARCHAR (30),
  `created_date` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` INT DEFAULT 1,
  PRIMARY KEY (`faktur_jual`)
); "
        CMD = New MySqlCommand(tablePending, Conn)
        CMD.ExecuteNonQuery()

        Dim tablePendingDetail As String = "CREATE TABLE IF NOT EXISTS `pending_jual_detail` (
  `faktur_jual` VARCHAR (30) NOT NULL,
  `kode_item` VARCHAR (20) NOT NULL,
  `nama` VARCHAR (100),
  `satuan` VARCHAR (5),
  `jenis` VARCHAR (50),
  `harga` DOUBLE,
  `jumlah` INT DEFAULT 0,
  `disc_p` INT,
  `disc_rp` DOUBLE,
  `total` DOUBLE,
  `total_disc` DOUBLE,
  PRIMARY KEY (`faktur_jual`, `kode_item`)
); "
        CMD = New MySqlCommand(tablePendingDetail, Conn)
        CMD.ExecuteNonQuery()

        cekClose()
    End Sub
End Class