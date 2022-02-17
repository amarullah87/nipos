Imports System.Net
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Text

Public Class MasterSupplier

    Sub Kosongkan()
        txtkodesupplier.Clear()
        txtnamasupplier.Clear()
        txtalamat.Clear()
        txttelepon.Clear()
        txtfax.Clear()
        txtcaridata.Clear()
        txtemail.Text = ""
        txtcontact.Text = ""
        txtkodesupplier.Focus()
        Call TampilGrid()
    End Sub

    Sub DataBaru()
        txtnamasupplier.Clear()
        txtalamat.Clear()
        txttelepon.Clear()
        txtfax.Clear()
        txtcaridata.Clear()
        txtnamasupplier.Focus()
        txtemail.Text = ""
        txtcontact.Text = ""
    End Sub

    Sub Ketemu()
        txtnamasupplier.Text = DR.Item("nama_supplier")
        txtalamat.Text = DR.Item("alamat_supplier")
        txttelepon.Text = DR.Item("telepon")
        txtfax.Text = DR.Item("fax")
        txtemail.Text = DR.Item("email")
        txtcontact.Text = DR.Item("person_supplier")
        txtnamasupplier.Focus()
    End Sub

    Sub TampilGrid()
        cekOpen()

        DA = New MySqlDataAdapter("SELECT kode, nama, nama_toko, alamat, kontak, kontak_toko, jenis_nhs, deposit FROM mst_distributor WHERE kode REGEXP('D|P') " &
                                    " AND nama NOT REGEXP ('DB Online|jangan|jgn|...SRGN|tidak|DB OTHER|GUDANG ONLINE|NBRS CORP|Internal|OTHER') AND nama <> '' ORDER BY nama ASC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True

        cekClose()

        DGV.Columns(0).HeaderText = "Kode"
        DGV.Columns(1).HeaderText = "Nama Terdaftar"
        DGV.Columns(2).HeaderText = "Nama Toko"
        DGV.Columns(3).HeaderText = "Alamat"
        DGV.Columns(4).HeaderText = "Kontak"
        DGV.Columns(5).HeaderText = "Kontak Toko"
        DGV.Columns(6).HeaderText = "Jenis"
        DGV.Columns(7).HeaderText = "Deposit"
        DGV.Columns(7).DefaultCellStyle.Format = "C2"
        DGV.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub MasterSupplier_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call Kosongkan()
        SetDoubleBuffered(DGV, True)
    End Sub

    Private Sub btntutup_Click(sender As Object, e As EventArgs) Handles btntutup.Click
        Me.Close()
    End Sub

    Private Sub btnbatal_Click_1(sender As Object, e As EventArgs) Handles btnbatal.Click
        Call Kosongkan()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If txtkodesupplier.Text = "" Then
            MsgBox("Kode Supplier harus diisi")
            txtkodesupplier.Focus()
            Exit Sub
        End If

        If txtkodesupplier.Text = "P000-D0000" Then
            MsgBox("Mohon Maaf, Kode Supplier ini Tidak Boleh dihapus!", MsgBoxStyle.Critical)
        Else
            cekOpen()
            If MessageBox.Show("yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim hapus As String = "delete from supplier_m where kode_supplier='" & txtkodesupplier.Text & "'"
                CMD = New MySqlCommand(hapus, Conn)
                CMD.ExecuteNonQuery()
                Call Kosongkan()
            Else
                Call Kosongkan()
            End If
            cekClose()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        cekOpen()

        CMD = New MySqlCommand("select * from supplier_m where kode_supplier='" & txtkodesupplier.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        cekClose()
        Try
            cekOpen()
            If Not DR.HasRows Then
                Dim simpan As String = "insert into supplier_m values ('" & txtkodesupplier.Text & "','" & txtnamasupplier.Text & "','" & txtalamat.Text & "','" & txttelepon.Text & "','" & txtfax.Text & "','" & txtemail.Text & "','" & txtcontact.Text & "', 'D', 0)"
                CMD = New MySqlCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
            Else
                Dim edit As String = "update supplier_m set nama_supplier='" & txtnamasupplier.Text & "',alamat_supplier='" & txtalamat.Text & "',telepon='" & txttelepon.Text & "',fax='" & txtfax.Text & "',email='" & txtemail.Text & "',person_supplier='" & txtcontact.Text & "' where kode_supplier_m='" & txtkodesupplier.Text & "'"
                CMD = New MySqlCommand(edit, Conn)
                CMD.ExecuteNonQuery()
            End If
            cekClose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Call Kosongkan()
    End Sub

    Private Sub txtcaridata_TextChanged(sender As Object, e As EventArgs)
        cekOpen()

        DA = New MySqlDataAdapter("SELECT kode, nama, nama_toko, alamat, kontak, kontak_toko, jenis_nhs, deposit FROM mst_distributor WHERE nama NOT LIKE '%DB Online%' AND STATUS = 1 ORDER BY nama ASC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True

        cekClose()
    End Sub

    Private Sub DGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        On Error Resume Next
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then
            txtkodesupplier.Text = DGV.Rows(e.RowIndex).Cells(0).Value
            txtnamasupplier.Text = DGV.Rows(e.RowIndex).Cells(1).Value
            txtalamat.Text = DGV.Rows(e.RowIndex).Cells(2).Value
            txttelepon.Text = DGV.Rows(e.RowIndex).Cells(3).Value
            txtfax.Text = DGV.Rows(e.RowIndex).Cells(4).Value
            txtemail.Text = DGV.Rows(e.RowIndex).Cells(5).Value
            txtcontact.Text = DGV.Rows(e.RowIndex).Cells(6).Value
        End If
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        ImportSupplier.Show()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        cekOpen()

        DA = New MySqlDataAdapter("SELECT kode, nama, nama_toko, alamat, kontak, kontak_toko, jenis_nhs, deposit FROM mst_distributor WHERE nama NOT LIKE '%DB Online%' AND nama LIKE '%" & txtCari.Text & "%' ORDER BY nama ASC", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True

        cekClose()

        DGV.Columns(0).HeaderText = "Kode"
        DGV.Columns(1).HeaderText = "Nama Terdaftar"
        DGV.Columns(2).HeaderText = "Nama Toko"
        DGV.Columns(3).HeaderText = "Alamat"
        DGV.Columns(4).HeaderText = "Kontak"
        DGV.Columns(5).HeaderText = "Kontak Toko"
        DGV.Columns(6).HeaderText = "Jenis"
        DGV.Columns(7).HeaderText = "Deposit"
        DGV.Columns(7).DefaultCellStyle.Format = "C2"
        DGV.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Dim Raw As String

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btnDownloadDB.Click
        If CheckForInternetConnection() Then
            Try

                SplashScreenManager1.ShowWaitForm()
                Threading.Thread.Sleep(2000)

                'make HTTP Request
                'Dim Request As HttpWebRequest = HttpWebRequest.Create(uri)
                Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "downloadDB")
                Request.Method = "POST"
                Dim postbody As String = "pencarian="
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                Request.ContentType = "application/x-www-form-urlencoded"
                Request.ContentLength = byteArray.Length
                Dim dataStream As Stream = Request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()

                'get HTTP Response
                Dim Response As WebResponse = Request.GetResponse()
                'Console.WriteLine((CType(Response, HttpWebResponse)).StatusDescription)

                'read HTTP response
                Dim Read = New StreamReader(Response.GetResponseStream())
                Raw = ""
                Raw = Read.ReadToEnd()
                'Console.WriteLine(Raw)
                'MsgBox(Raw)

                Dim jsonObject As JObject = JObject.Parse(Raw)
                If jsonObject.SelectToken("code").ToString = "200" Then

                    Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)

                    For Each item As JObject In JsonArray

                        Dim nama As String = item.SelectToken("nama").ToString.Replace("'", " ")
                        Dim alamat As String = item.SelectToken("alamat").ToString.Replace("'", " ")

                        cekOpen()
                        Dim query As String = "INSERT INTO mst_distributor VALUES ( " &
                            "'" & item.SelectToken("kode").ToString & "', " &
                            "'" & nama & "', " &
                            "'" & item.SelectToken("kontak").ToString & "', " &
                            "'" & alamat & "', " &
                            "'" & item.SelectToken("domisili").ToString & "', " &
                            "'" & item.SelectToken("nama_toko").ToString & "', " &
                            "'" & item.SelectToken("kontak_toko").ToString & "', " &
                            "'" & item.SelectToken("ekspedisi").ToString & "', " &
                            "'" & item.SelectToken("tanggal").ToString & "', " &
                            "'" & item.SelectToken("status").ToString & "', " &
                            "'" & item.SelectToken("id_level").ToString & "', " &
                            "'" & item.SelectToken("nip").ToString & "', " &
                            "'" & item.SelectToken("email").ToString & "', " &
                            "'" & item.SelectToken("foto").ToString & "', " &
                            "'" & item.SelectToken("id_provinsi").ToString & "', " &
                            "'" & item.SelectToken("id_kota").ToString & "', " &
                            "'" & item.SelectToken("id_kecamatan").ToString & "', " &
                            "'" & item.SelectToken("id_kelurahan").ToString & "', " &
                            "'" & item.SelectToken("jenis_nhs").ToString & "', " &
                            "'" & item.SelectToken("id_sementara").ToString & "', " &
                            "'" & item.SelectToken("prev_code").ToString & "', " &
                            "'" & item.SelectToken("spv").ToString & "', " &
                            "0" &
                            " ) ON DUPLICATE KEY UPDATE nama = '" & nama & "', alamat = '" & alamat & "' "
                        'Console.WriteLine(query)
                        CMD = New MySqlCommand(query, Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()
                    Next
                Else
                    MsgBox(Oops_401)
                End If

                Dim Request2 As WebRequest = WebRequest.Create(getBaseUrl() + "downloadOutlet")
                Request2.Method = "POST"
                Dim postbody2 As String = "pencarian="
                Dim byteArray2 As Byte() = Encoding.UTF8.GetBytes(postbody2)
                Request2.ContentType = "application/x-www-form-urlencoded"
                Request2.ContentLength = byteArray2.Length
                Dim dataStream2 As Stream = Request2.GetRequestStream()
                dataStream2.Write(byteArray2, 0, byteArray2.Length)
                dataStream2.Close()

                Dim Response2 As WebResponse = Request2.GetResponse()
                Dim Read2 = New StreamReader(Response2.GetResponseStream())
                Raw = ""
                Raw = Read2.ReadToEnd()

                Dim jsonObject2 As JObject = JObject.Parse(Raw)
                If jsonObject2.SelectToken("code").ToString = "200" Then

                    Dim JsonArray2 As JArray = JArray.Parse(jsonObject2.SelectToken("response").ToString)

                    For Each item As JObject In JsonArray2

                        cekOpen()
                        CMD = New MySqlCommand("INSERT INTO master_nhs VALUES ( " &
                            "'" & item.SelectToken("id").ToString & "', " &
                            "'" & item.SelectToken("nama").ToString & "', " &
                            "'" & item.SelectToken("alamat").ToString & "', " &
                            "'" & item.SelectToken("no_tlf").ToString & "', " &
                            "'" & item.SelectToken("email").ToString & "', " &
                            "'" & item.SelectToken("id_sementara").ToString & "', " &
                            "'" & item.SelectToken("jenis_nhs").ToString & "', " &
                            "'" & item.SelectToken("id_distributor").ToString & "', " &
                            "'" & item.SelectToken("foto").ToString & "', " &
                            "'" & item.SelectToken("id_provinsi").ToString & "', " &
                            "'" & item.SelectToken("id_kota").ToString & "', " &
                            "'" & item.SelectToken("id_kecamatan").ToString & "', " &
                            "'" & item.SelectToken("id_kelurahan").ToString & "', " &
                            "'" & item.SelectToken("spv").ToString & "' " &
                            " ) ON DUPLICATE KEY UPDATE nama = '" & item.SelectToken("nama").ToString & "', alamat = '" & item.SelectToken("alamat").ToString & "' ", Conn)
                        CMD.ExecuteNonQuery()
                        cekClose()
                    Next
                Else
                    MsgBox(Oops_401)
                End If


                MsgBox("Data Distributor Berhasil di Update", MsgBoxStyle.Information, "Sukses")
                SplashScreenManager1.CloseWaitForm()


            Catch ex As WebException
                If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                    MsgBox(ex.Message.ToString)
                End If
            End Try

        Else
            MsgBox(Oops_noInternet)
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        MainMenu.SplashScreenManager1.ShowWaitForm()
        Threading.Thread.Sleep(2000)

        Dim csv As String = String.Empty
        For Each column As DataGridViewColumn In DGV.Columns
            csv += column.HeaderText & ","c
        Next

        csv += vbCr & vbLf

        For Each row As DataGridViewRow In DGV.Rows
            For Each cell As DataGridViewCell In row.Cells
                csv += cell.Value.ToString().Replace(",", " ") & ","c
            Next

            csv += vbCr & vbLf
        Next

        Dim folderPath As String = "C:\NIPOS_EXPORT\"
        If (Not Directory.Exists(folderPath)) Then
            Directory.CreateDirectory(folderPath)
        End If

        Dim nameFile As String = "DaftarDistributor_" & DateTime.Now.ToString("yyyyMMdd-HHmmss") & ".csv"

        File.WriteAllText(folderPath & nameFile, csv)

        MsgBox("Data Berhasil di Export, Silahkan Periksa pada Folder " & folderPath & nameFile, MsgBoxStyle.Information, "Berhasil!")
        MainMenu.SplashScreenManager1.CloseWaitForm()
    End Sub
End Class