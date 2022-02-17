Imports MySql.Data.MySqlClient

Public Class TransaksiStokOpname
    Sub Kosongkan()
        txtBarcode.Focus()
        txtBarcode.Text = ""
        txtNama.Text = ""
        txtQtyReal.Text = ""
        txtQtySistem.Text = ""
        txtSelisih.Text = ""
        txtKeterangan.Text = ""

        Call TampilGrid()
        Call CallAkun()
        Call Hitungtransaksi()
    End Sub

    Sub CallAkun()
        'cekOpen()
        'CMD = New MySqlCommand("SELECT*FROM perkiraan", Conn)
        'DR = CMD.ExecuteReader
        'Do While DR.Read
        '    If DR.Item("level") = 0 Then
        '        cbAkun.Items.Add("----------------------------------")
        '    Else
        '        If DR.Item("tipe") = "H" Then
        '            cbAkun.Items.Add("")
        '        Else
        '            cbAkun.Items.Add(DR.Item("kodeacc") & "/" & DR.Item("namaacc"))
        '        End If
        '    End If
        'Loop
        'cekClose()
        cbAkun.Items.Add("5-2203/PENYESUAIAN STOK")
        cbAkun.SelectedIndex = 0
    End Sub

    Sub firstQuery()
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("CREATE TABLE IF NOT EXISTS `barang_m2` (
      `kode_item` varchar(15) NOT NULL,
      `barcode` varchar(15) NOT NULL,
      `nama_barang` varchar(100) DEFAULT NULL,
      `satuan` varchar(10) DEFAULT NULL,
      `jenis` varchar(20) DEFAULT NULL,
      `merek` varchar(10) DEFAULT NULL,
      `hpp` double DEFAULT NULL,
      `hpj` double DEFAULT NULL,
      `hpp_avg` double DEFAULT NULL,
      `tipe` varchar(20) DEFAULT NULL,
      `stok_min` smallint(6) DEFAULT NULL,
      `stok` smallint(6) DEFAULT NULL,
      `keterangan` varchar(200) DEFAULT NULL,
      `updatedate` time DEFAULT NULL,
      PRIMARY KEY (`kode_item`,`barcode`)
    ) ENGINE=MyISAM DEFAULT CHARSET=latin1 ", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("DELETE FROM barang_m2", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("CREATE TABLE IF NOT EXISTS `so_temp` (
        `id_barang` varchar(15) NOT NULL,
        `qty` int(11) DEFAULT NULL,
        `hpj` double(12,0) DEFAULT NULL,
        `hpp` double(12,0) DEFAULT NULL,
        `tanggal` date DEFAULT NULL,
        `tanggal_time` datetime DEFAULT NULL,
        `nama_produk` varchar(100) DEFAULT NULL,
        PRIMARY KEY (`id_barang`)
      ) ENGINE=MyISAM DEFAULT CHARSET=latin1", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("CREATE TABLE IF NOT EXISTS `stok_opname_berkala` (
        `id_barang` varchar(15) NOT NULL,
        `qty` int(11) DEFAULT NULL,
        `hpj` double(12,0) DEFAULT NULL,
        `hpp` double(12,0) DEFAULT NULL,
        `tanggal` date NOT NULL,
        `tanggal_time` datetime DEFAULT NULL,
        `nama_produk` varchar(100) DEFAULT NULL,
        `qty_so` double(12,0) DEFAULT NULL,
        `adj` double(12,0) DEFAULT NULL,
        `kode_adj` varchar(100) DEFAULT NULL,
        PRIMARY KEY (`id_barang`,`tanggal`)
      ) ENGINE=MyISAM DEFAULT CHARSET=latin1", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("INSERT INTO perkiraan (kodeacc,parentacc,kelompok,tipe,namaacc,matauang,dateupd,kasbank,defmuutm,mainparent,mainparentname,secondparent,secondparentname,thirdparent,thirdparentname,`level`)
    VALUES('5-2203','5-2000','5','D','PENYESUAIAN STOK','IDR','2011-01-23 01:41:45','0','0','5-0000','HPP','5-2000','LAIN-LAIN','-','-','2') ON DUPLICATE KEY UPDATE kodeacc = '5-2203' ", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("insert ignore barang_m2(kode_item,barcode,nama_barang,satuan,jenis,merek,hpp,hpj,hpp_avg,tipe,stok_min,stok,keterangan)
    SELECT kode_item,barcode,nama_barang,satuan,jenis,merek,hpp,hpj,hpp_avg,tipe,stok_min,stok,keterangan FROM barang_m", Conn)
        CMD.ExecuteNonQuery()

        CMD = New MySqlCommand("CREATE TABLE IF NOT EXISTS `stok_awal` (
        `id_barang` VARCHAR( 15 ) NOT NULL ,
        `tanggal` DATE NOT NULL ,
        `stok_awal` INT NOT NULL ,
        `qty` INT NOT NULL ,
        `hpp` DOUBLE NOT NULL ,
        PRIMARY KEY ( `id_barang` , `tanggal` )
        ) ENGINE = MYISAM", Conn)
        CMD.ExecuteNonQuery()

        cekClose()
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call Kosongkan()
    End Sub

    Private Sub TransaksiStokOpname_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call firstQuery()

        Call Kosongkan()
        SetDoubleBuffered(DGV, True)
        Call TampilGrid()
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        'On ENTER
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then

            cekOpen()
            CMD = New MySqlCommand("SELECT * FROM barang_m WHERE kode_item = '" & txtBarcode.Text & "'", Conn)
        DR = CMD.ExecuteReader
            DR.Read()


            If (DR.HasRows) Then
                txtNama.Text = DR.Item("nama_barang")
                txtQtySistem.Text = DR.Item("stok")
                txtHpp.Text = DR.Item("hpp")
                txtHpj.Text = DR.Item("hpj")

                txtQtyReal.Focus()
                cekClose()
            Else
                'txtBarcode.Clear()
                'MsgBox("Data Barang Tidak Ditemukan!")
                'cekClose()
                'DownloadBarang.Show()

                PencarianBarangSO.ShowDialog()
                PencarianBarangSO.TXTCariBarang.Text = txtBarcode.Text
            End If
        End If
    End Sub

    Private Sub txtQtyReal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQtyReal.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Dim selisih As Integer
            Dim qtyReal As Integer = 0
            Dim qtySistem As Integer = 0

            If txtQtyReal.Text = "" Then
                qtyReal = 0
            Else
                qtyReal = Integer.Parse(txtQtyReal.Text)
            End If

            If txtQtySistem.Text = "" Then
                qtySistem = 0
            Else
                qtySistem = Integer.Parse(txtQtySistem.Text)
            End If

            selisih = qtyReal - qtySistem

            txtSelisih.Text = FormatNumber(selisih, 0).ToString
            SaveToTemp()
        End If
    End Sub

    Sub DeleteItem()
        cekOpen()
        CMD = New MySqlCommand("DELETE FROM temp_stok_opname WHERE kode_item = '" & DGV.CurrentRow.Cells(0).Value & "' ", Conn)
        CMD.ExecuteNonQuery()
        cekClose()

        Call Kosongkan()
    End Sub

    Private Sub txtKeterangan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKeterangan.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            SaveToTemp()
        End If
    End Sub

    Sub SaveToTemp()
        If txtBarcode.Text = "" Or txtNama.Text = "" Or txtQtyReal.Text = "" Or txtSelisih.Text = "" Then
            MsgBox("Lengkapi Data!")
        Else
            cekClose()

            cekOpen()
            'Dim simpan1 As String = "INSERT INTO temp_stok_opname VALUES ('" & txtBarcode.Text & "','" & Format(dtptanggal.Value, "yyyy-MM-dd") & "','" & txtQtyReal.Text & "','" & txtQtySistem.Text & "','" & txtSelisih.Text & "', '" & txtKeterangan.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & MainMenu.PanelUser.Text & "', 0)"
            Dim simpan1 As String = "INSERT INTO  `so_temp`  (`id_barang`, `qty`, `hpj`,  `hpp`,  `tanggal`, `tanggal_time`,`nama_produk`)
VALUES ('" & txtBarcode.Text & "',  '" & txtQtyReal.Text & "', '" & txtHpj.Text & "', '" & txtHpp.Text & "', NOW(), NOW(),'" & txtNama.Text & "')
on duplicate key update qty = " & txtQtyReal.Text & ", tanggal_time=NOW()"
            CMD = New MySqlCommand(simpan1, Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            Call Kosongkan()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SaveToTemp()
    End Sub

    Sub TampilGrid()
        cekClose()

        cekOpen()
        'DA = New MySqlDataAdapter("SELECT so.`kode_item`, b.`nama_barang`, b.`hpp`, b.`satuan`, so.`qty_buku`, so.`qty_fisik`, so.`qty_selisih`, so.`keterangan` " &
        '        " FROM temp_stok_opname so " &
        '        " INNER JOIN barang_m b ON b.kode_item = so.kode_item ", Conn)
        DA = New MySqlDataAdapter("SELECT kode_item AS id_barang,nama_barang AS nama, hpp, hpj, SUM(stok) AS stok,SUM(so) AS so,SUM(so-stok) AS selisih  
FROM (
      SELECT kode_item,nama_barang,stok, 0 AS so, hpp, hpj FROM barang_m2 
      UNION 
      SELECT id_barang AS kode_item,nama_produk AS nama_barang, 0 AS stok, qty AS so, hpp, hpj  FROM so_temp
     ) AS t 
WHERE LENGTH(kode_item)>10 AND (stok > 0 OR so > 0) GROUP BY kode_item
HAVING kode_item<>'' ORDER BY so DESC ", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
        cekClose()

        DGV.Columns(0).HeaderText = "KODE ITEM"
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)

        DGV.Columns(1).HeaderText = "NAMA BARANG"
        DGV.Columns(1).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)

        DGV.Columns(2).HeaderText = "HPP"
        DGV.Columns(2).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(2).DefaultCellStyle.Format = "c0"
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(3).HeaderText = "HPJ"
        DGV.Columns(3).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(3).DefaultCellStyle.Format = "c0"
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(4).HeaderText = "STOK AWAL"
        DGV.Columns(4).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(4).DefaultCellStyle.Format = "n0"
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(5).HeaderText = "HASIL SO"
        DGV.Columns(5).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(5).DefaultCellStyle.Format = "n0"
        DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(6).HeaderText = "SELISIH"
        DGV.Columns(6).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(6).DefaultCellStyle.Format = "n0"
        DGV.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 252, 252)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        Dim count As Integer = 0

        cekOpen()
        CMD = New MySqlCommand("SELECT COUNT(id_barang) AS hitung FROM stok_opname_berkala WHERE tanggal = '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "' ", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            count = DR.Item("hitung")
            cekClose()
        End If

        If count > 0 Then
            If MessageBox.Show("Sistem mendeteksi Adanya Data Stok Opname pada tanggal " & Format(dtptanggal.Value, "D") &
                               vbCrLf & vbCrLf & "Jika anda melanjutkan tanpa merubah stok yang ada, maka Stok akan ditambahkan sesuai dengan Nilai Stok Awal (kemungkinan akan terjadi Double Stok). Lanjutkan??", "Perhatian",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.Yes Then
                Call saveTransaksiSO()
            End If
        Else
                Call saveTransaksiSO()
        End If

    End Sub

    Sub saveTransaksiSO()
        Dim result As DialogResult = MessageBox.Show("Anda yakin akan menyimpan Transaksi Stok Opname?", "Perhatian!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.No Then
            MessageBox.Show("OK! Silahkan Periksa Kembali Hasil SO yang sudah dilakukan.")
        ElseIf result = DialogResult.Yes Then
            cekClose()

            Dim tanggal As String = Format(dtptanggal.Value, "yyyy-MM-dd")
            Dim debit As String = "1-1510"
            Dim kredit As String = "5-2203"
            Dim kode_adj As String = Format(dtptanggal.Value, "yyyyMMddHHmmss")

            cekOpen()
            CMD = New MySqlCommand("INSERT ignore  `stok_opname_berkala`
(`id_barang`,  `qty`,  `hpj`,  `hpp`,   `tanggal`,  `tanggal_time`,  `nama_produk`,  `qty_so`,  `adj`,kode_adj) 
SELECT kode_item AS id_barang,SUM(stok) AS stok,hpj,hpp, '" & tanggal & "', NOW(),nama_barang,SUM(so) AS so,SUM(so-stok) AS adj,'" & kode_adj & "' FROM (
SELECT kode_item,nama_barang,stok , 0 AS so,hpj,hpp FROM barang_m2 
UNION 
SELECT id_barang AS kode_item,nama_produk AS nama_barang,0 AS stok,qty AS so,hpj,hpp  FROM so_temp
) AS t WHERE LENGTH(kode_item)>10 GROUP BY kode_item
HAVING kode_item<>'' ORDER BY adj DESC", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("update barang_m set stok=0", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("update barang_m as m , so_temp as b set m.stok=b.qty,updatedate=NOW() where m.kode_item=b.id_barang", Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            cekOpen()
            CMD = New MySqlCommand("SELECT SUM(adj*hpp) AS nilai FROM  stok_opname_berkala WHERE tanggal='" & tanggal & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                Dim nilai As Double = DR.Item("nilai")
                cekClose()

                cekOpen()
                If nilai < 0 Then
                    nilai = -nilai

                    CMD = New MySqlCommand("INSERT INTO jurnal(nomor_transaksi,tgl_transaksi,kode_perkiraan,uraian,debet,kredit,keterangan,jenis,urutan)
    VALUES('" & kode_adj & "','" & tanggal & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & debit & "','PERSEDIAAN BARANG','0','" & nilai & "','so_berkala tanggal " & tanggal & "','7','1')", Conn)
                    CMD.ExecuteNonQuery()
                    CMD = New MySqlCommand("INSERT INTO jurnal(nomor_transaksi,tgl_transaksi,kode_perkiraan,uraian,debet,kredit,keterangan,jenis,urutan)
     VALUES('" & kode_adj & "','" & tanggal & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & kredit & "','PENYESUAIAN STOK','" & nilai & "','0','so_berkala tanggal " & tanggal & "','7','2')", Conn)
                    CMD.ExecuteNonQuery()
                Else
                    CMD = New MySqlCommand("INSERT INTO jurnal(nomor_transaksi,tgl_transaksi,kode_perkiraan,uraian,debet,kredit,keterangan,jenis,urutan)
    VALUES('" & kode_adj & "','" & tanggal & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & debit & "','PERSEDIAAN BARANG','" & nilai & "','0','so_berkala tanggal " & tanggal & "','7','1')", Conn)
                    CMD.ExecuteNonQuery()
                    CMD = New MySqlCommand("INSERT INTO jurnal(nomor_transaksi,tgl_transaksi,kode_perkiraan,uraian,debet,kredit,keterangan,jenis,urutan)
     VALUES('" & kode_adj & "','" & tanggal & " " & DateTime.Now.ToString("HH:mm:ss") & "','" & kredit & "','PENYESUAIAN STOK','0','" & nilai & "','so_berkala tanggal " & tanggal & "','7','2')", Conn)
                    CMD.ExecuteNonQuery()
                End If
                cekClose()

            End If

            cekOpen()
            CMD = New MySqlCommand("replace into stok_awal (id_barang,tanggal,qty,hpp)select kode_item,'" & tanggal & "',stok,hpp from barang_m2", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("delete from so_temp", Conn)
            CMD.ExecuteNonQuery()

            CMD = New MySqlCommand("delete from barang_m2", Conn)
            CMD.ExecuteNonQuery()
            cekClose()

            Call getHitungStokAwal()
        End If
    End Sub

    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        DeleteItem()
    End Sub

    Sub Hitungtransaksi()
        Dim x As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            x = x + DGV.Rows(baris).Cells(5).Value
            txtTqty.Text = x
        Next

        Dim y As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 1
            y = y + (DGV.Rows(baris).Cells(5).Value * DGV.Rows(baris).Cells(2).Value)
            txtTtot.Text = y
        Next

    End Sub

    Public Sub getFocus()
        txtQtyReal.Focus()
        txtQtyReal.Select()
    End Sub

    Private Sub txtPencarian_TextChanged(sender As Object, e As EventArgs) Handles txtPencarian.TextChanged
        cekClose()

        cekOpen()
        'DA = New MySqlDataAdapter("SELECT so.`kode_item`, b.`nama_barang`, b.`satuan`, so.`qty_buku`, so.`qty_fisik`, so.`qty_selisih`, so.`keterangan` " &
        '        " FROM temp_stok_opname so " &
        '        " INNER JOIN barang_m b ON b.kode_item = so.kode_item " &
        '        " WHERE b.`nama_barang` LIKE '%" & txtPencarian.Text & "%' ", Conn)
        DA = New MySqlDataAdapter("SELECT kode_item AS id_barang,nama_barang AS nama, hpp, hpj, SUM(stok) AS stok,SUM(so) AS so,SUM(so-stok) AS selisih  
FROM (
      SELECT kode_item,nama_barang,stok, 0 AS so, hpp, hpj FROM barang_m2 
      UNION 
      SELECT id_barang AS kode_item,nama_produk AS nama_barang, 0 AS stok, qty AS so, hpp, hpj  FROM so_temp
     ) AS t 
WHERE LENGTH(kode_item)>10 AND (nama_barang LIKE '%" & txtPencarian.Text & "%' OR kode_item LIKE '%" & txtPencarian.Text & "%') AND (stok > 0 OR so > 0) GROUP BY kode_item
HAVING kode_item<>'' ORDER BY so DESC ", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
        cekClose()

        DGV.Columns(0).HeaderText = "KODE ITEM"
        DGV.Columns(0).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)

        DGV.Columns(1).HeaderText = "NAMA BARANG"
        DGV.Columns(1).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)

        DGV.Columns(2).HeaderText = "HPP"
        DGV.Columns(2).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(2).DefaultCellStyle.Format = "c0"
        DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(3).HeaderText = "HPJ"
        DGV.Columns(3).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(3).DefaultCellStyle.Format = "c0"
        DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(4).HeaderText = "STOK AWAL"
        DGV.Columns(4).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(4).DefaultCellStyle.Format = "n0"
        DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(5).HeaderText = "HASIL SO"
        DGV.Columns(5).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(5).DefaultCellStyle.Format = "n0"
        DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.Columns(6).HeaderText = "SELISIH"
        DGV.Columns(6).DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular)
        DGV.Columns(6).DefaultCellStyle.Format = "n0"
        DGV.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 252, 252)

    End Sub

    Sub getHitungStokAwal()
        Dim tanggal As String = Format(dtptanggal.Value, "yyyy-MM-dd")
        Dim sampai As String = DateTime.Now.ToString("yyyy-MM-dd")

        cekClose()
        cekOpen()

        CMD = New MySqlCommand("UPDATE barang_m AS m ,( 

SELECT kode, SUM(stok_awal+beli-rb-jual+rj+adj) AS sisa FROM (
	
SELECT s.id_barang AS kode,0 AS awal, 0 AS beli, 0 AS stok,0 AS jual,0 AS masuk,0 AS keluar, 0 AS rj,0 AS rb,0 AS adj,SUM(s.qty) AS stok_awal FROM stok_awal	AS s 
WHERE s.tanggal ='" & tanggal & "'    GROUP BY id_barang
 
UNION 
 
 
 		
SELECT b.kode_barang AS kode,0 AS awal,b.qty_beli AS beli, 0 AS  stok, 0 AS jual,0 AS masuk,0 AS keluar, 0 AS rj, 0 AS rb,0 AS adj,0 AS stok_awal    FROM detailbeli AS b 
INNER JOIN pembelian AS p ON 
(p.faktur_beli=b.faktur_beli)
WHERE p.faktur_beli 
NOT LIKE 'btl%' AND p.tgl_beli BETWEEN '" & tanggal & " 00:00:00' AND '" & sampai & " 23:59:59' GROUP BY b.kode_barang


UNION 


SELECT d.kode_barang AS kode,0 AS awal, 0 AS beli, 0 AS stok,0 AS jual,0 AS masuk,0 AS keluar, 0 AS rj, SUM(d.qty_retur_beli) AS rb,0 AS adj,0 AS stok_awal    FROM detailreturbeli  AS d 
INNER JOIN returpembelian AS r ON 
(d.no_retur_beli=r.no_retur_beli) 
WHERE r.tgl_retur_beli  BETWEEN '" & tanggal & " 00:00:00' AND '" & sampai & " 23:59:59'
GROUP BY d.kode_barang
 
 UNION 

 
SELECT d.kode_barang AS kode,0 AS awal,0 AS beli, 0 AS  stok,SUM(d.qty_jual) AS jual,0 AS masuk,0 AS keluar, 0 AS rj, 0 AS rb, 0 AS adj,0 AS stok_awal     FROM detailjual AS d 
INNER JOIN penjualan AS p ON 
(d.faktur_jual=p.faktur_jual)
WHERE p.faktur_jual NOT LIKE 'btl%' 
AND p.tgl_jual   BETWEEN '" & tanggal & " 00:00:00' AND '" & sampai & " 23:59:59'
GROUP BY d.kode_barang

 UNION 


SELECT d.kode_barang AS kode,0 AS awal, 0 AS beli, 0 AS stok,0 AS jual,0 AS masuk,0 AS keluar, SUM(d.qty_retur_jual) AS rj,0 AS rb,0 AS adj,0 AS stok_awal  FROM detailreturjual AS d 
INNER JOIN returpenjualan AS r ON 
(d.no_retur_jual=r.no_retur_jual)
WHERE r.tgl_retur_jual BETWEEN '" & tanggal & " 00:00:00' AND '" & sampai & " 23:59:59'
GROUP BY d.kode_barang
 
UNION 

 
SELECT b.id_barang AS kode,0 AS awal, 0 AS beli, 0 AS stok,0 AS jual,0 AS masuk,0 AS keluar, 0 AS rj,0 AS rb,SUM(adj) AS adj ,0 AS stok_awal  FROM stok_opname_berkala AS b 
WHERE tanggal BETWEEN '" & tanggal & " 00:00:00' AND '" & sampai & " 23:59:59'  
GROUP BY id_barang 
) AS t GROUP BY t.kode  
) AS b SET 
m.stok=b.sisa WHERE 
m.kode_item=b.kode", Conn)
        CMD.ExecuteNonQuery()

        cekClose()

        MsgBox("Data SO Berhasil Disimpan, Silahkan periksa Data Stok pada Menu Master Barang", MsgBoxStyle.Information, "Berhasil!")
        Me.Close()
    End Sub

    Private Sub txtQtyReal_TextChanged(sender As Object, e As EventArgs) Handles txtQtyReal.TextChanged
        Dim selisih As Integer
        Dim qtyReal As Integer = 0
        Dim qtySistem As Integer = 0

        If txtQtyReal.Text = "" Then
            qtyReal = 0
        Else
            qtyReal = Integer.Parse(txtQtyReal.Text)
        End If

        If txtQtySistem.Text = "" Then
            qtySistem = 0
        Else
            qtySistem = Integer.Parse(txtQtySistem.Text)
        End If

        selisih = qtyReal - qtySistem

        txtSelisih.Text = FormatNumber(selisih, 0).ToString
    End Sub
End Class