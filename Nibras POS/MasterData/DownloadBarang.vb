Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class DownloadBarang

    Dim Raw As String
    Dim totalData As Integer

    Private Sub DownloadBarang_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        TXTCariBarang.Focus()
        TXTCariBarang.Select()
    End Sub

    Private Sub BTNTutup_Click(sender As Object, e As EventArgs) Handles BTNTutup.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        DGV.Rows.Clear()
        TXTCariBarang.Text = ""
        Raw = ""
        txtTotalData.Text = "Total: 0 Data"
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If Raw <> "" Then

            Dim jsonObject As JObject = JObject.Parse(Raw)
            If jsonObject.SelectToken("code").ToString = "200" Then

                Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)
                Dim totalData As Integer = JsonArray.Count
                Dim count As Integer = 0
                For Each item As JObject In JsonArray

                    Dim namabarang As String
                    If item.SelectToken("nama").ToString.Contains("'") Then
                        namabarang = item.SelectToken("nama").ToString.Replace("'", "''")
                    Else
                        namabarang = item.SelectToken("nama").ToString
                    End If

                    'Dim hpp As Double = Double.Parse(item.SelectToken("hargajual").ToString) - (Double.Parse(item.SelectToken("hargajual").ToString) * 35 / 100)
                    Dim hpp As Double = Double.Parse(item.SelectToken("hargajual").ToString) * 0.65

                    cekOpen()
                    Dim simpan2 As String = "INSERT INTO barang_m VALUES ('" &
                        item.SelectToken("kode").ToString & "', '" &
                        item.SelectToken("kode").ToString & "', '" &
                        namabarang & "', '" &
                        item.SelectToken("satuan").ToString & "', '" &
                        item.SelectToken("kode_kategori").ToString & "', '', '" &
                        hpp & "', '" &
                        item.SelectToken("hargajual").ToString & "', '0', '', '10', '0', '', '" & item.SelectToken("updatedate").ToString & "') ON DUPLICATE KEY UPDATE nama_barang = '" & namabarang & "', hpj = '" & item.SelectToken("hargajual").ToString & "', hpp = '" & hpp & "', updatedate = '" & item.SelectToken("updatedate").ToString & "' "
                    'Console.WriteLine(simpan2)

                    CMD = New MySqlCommand(simpan2, Conn)
                    CMD.ExecuteNonQuery()
                    cekClose()

                    count += 1
                Next

                If count = totalData Then
                    MsgBox("Data Sudah Tersimpan!")
                End If
            Else
                MsgBox(Oops_401)
            End If
        Else
            MsgBox("Tidak Data untuk di Download!")
        End If
    End Sub

    Private Sub TXTCariBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCariBarang.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            DGV.Rows.Clear()

            If CheckForInternetConnection() Then
                Try

                    'make HTTP Request
                    'Dim Request As HttpWebRequest = HttpWebRequest.Create(uri)
                    Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "cekBarang")
                    Request.Method = "POST"
                    Dim postbody As String = "nama=" + TXTCariBarang.Text
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
                    txtResponse.Text = Raw
                    Dim jsonObject As JObject = JObject.Parse(Raw)
                    If jsonObject.SelectToken("code").ToString = "200" Then

                        Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)
                        totalData = JsonArray.Count
                        txtTotalData.Text = "Total: " + totalData.ToString + " Data"

                        For Each item As JObject In JsonArray

                            DGV.Rows.Add(
                                item.SelectToken("kode").ToString,
                                item.SelectToken("kode").ToString,
                                item.SelectToken("nama").ToString,
                                CDec(Double.Parse(item.SelectToken("hargajual").ToString) * 0.65),
                                CDec(item.SelectToken("hargajual"))
                            )

                        Next
                    Else
                        MsgBox(Oops_401)
                    End If

                    DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
                Catch ex As WebException
                    If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                        MsgBox(ex.Message.ToString)
                    End If
                End Try

            Else
                MsgBox(Oops_noInternet)
            End If
        End If
    End Sub
End Class