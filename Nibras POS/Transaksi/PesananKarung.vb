Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class PesananKarung
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Dim Raw As String
    Dim totalData As Integer

    Sub TampilGrid()
        DGV.Rows.Clear()

        If CheckForInternetConnection() Then

            If TransaksiPembelian.cbFromNHS.Checked = True Then
                Try
                    Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "getPenjualanNhs")
                    Request.Method = "POST"
                    Request.Timeout = 3600000


                    Dim postbody As String = "idoutlet=" + MainMenu.PanelID.Text + "&distributor=" + TransaksiPembelian.lookUpEdit.EditValue.ToString + "&tgl_awal=" + Format(dtpawal.Value, "yyyy-MM-dd") + "&tgl_akhir=" + Format(dtpakhir.Value, "yyyy-MM-dd")
                    'Dim postbody As String = "idoutlet=P035-N0056&distributor=" + TransaksiPembelian.lookUpEdit.EditValue.ToString + "&tgl_awal=" + Format(dtpawal.Value, "yyyy-MM-dd") + "&tgl_akhir=" + Format(dtpakhir.Value, "yyyy-MM-dd")
                    MsgBox(postbody)
                    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                    Request.ContentType = "application/x-www-form-urlencoded"
                    Request.ContentLength = byteArray.Length

                    Dim dataStream As Stream = Request.GetRequestStream()

                    dataStream.Write(byteArray, 0, byteArray.Length)
                    dataStream.Close()

                    'get HTTP Response
                    Dim Response As WebResponse = Request.GetResponse()
                    Console.WriteLine((CType(Response, HttpWebResponse)).StatusDescription)

                    'read HTTP response
                    Dim Read = New StreamReader(Response.GetResponseStream())
                    Raw = ""
                    Raw = Read.ReadToEnd()
                    Console.WriteLine(Raw)

                    Dim jsonObject As JObject = JObject.Parse(Raw)
                    If jsonObject.SelectToken("code").ToString = "200" Then

                        Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)
                        totalData = JsonArray.Count
                        txtTotalData.Text = "Total: " + totalData.ToString + " Data"

                        For Each item As JObject In JsonArray

                            Dim iDate As String = item.SelectToken("tanggal").ToString
                            Dim oDate As DateTime = Convert.ToDateTime(iDate)

                            DGV.Rows.Add(
                                item.SelectToken("kode").ToString,
                                Format(oDate, "dd MMMM yyyy"),
                                item.SelectToken("jml_item").ToString,
                                item.SelectToken("brand_name").ToString,
                                CDec(item.SelectToken("total").ToString),
                                CDec(item.SelectToken("total_diskon").ToString)
                            )
                            'String.Format("{0:N0}", item.SelectToken("hargadasar").ToString),
                            'String.Format("{0:N0}", item.SelectToken("hargajual").ToString)
                        Next

                        'DGV.Columns(1).DefaultCellStyle.Format = "M"
                        'DGV.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        'DGV.Columns(2).DefaultCellStyle.Format = "N0"
                        'DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'DGV.Columns(3).DefaultCellStyle.Format = "C0"
                        'DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'DGV.Columns(4).DefaultCellStyle.Format = "C0"
                        'DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'DGV.Columns(5).DefaultCellStyle.Format = "C0"
                        'DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    ElseIf jsonObject.SelectToken("code").ToString = "401" Then
                        MsgBox(jsonObject.SelectToken("message").ToString)
                    Else
                        MsgBox(Oops_401)
                    End If

                Catch ex As WebException
                    If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                        MsgBox(ex.Message.ToString)
                    End If
                End Try
            Else
                Try
                    Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "getPenjualanDB")
                    Request.Method = "POST"
                    Request.Timeout = 3600000


                    Dim postbody As String = "distributor=" + MainMenu.PanelID.Text + "&tgl_awal=" + Format(dtpawal.Value, "yyyy-MM-dd") + "&tgl_akhir=" + Format(dtpakhir.Value, "yyyy-MM-dd")
                    'MsgBox(postbody)
                    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                    Request.ContentType = "application/x-www-form-urlencoded"
                    Request.ContentLength = byteArray.Length

                    Dim dataStream As Stream = Request.GetRequestStream()

                    dataStream.Write(byteArray, 0, byteArray.Length)
                    dataStream.Close()

                    'get HTTP Response
                    Dim Response As WebResponse = Request.GetResponse()
                    Console.WriteLine((CType(Response, HttpWebResponse)).StatusDescription)

                    'read HTTP response
                    Dim Read = New StreamReader(Response.GetResponseStream())
                    Raw = ""
                    Raw = Read.ReadToEnd()
                    'Console.WriteLine(Raw)

                    Dim jsonObject As JObject = JObject.Parse(Raw)
                    If jsonObject.SelectToken("code").ToString = "200" Then

                        Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)
                        totalData = JsonArray.Count
                        txtTotalData.Text = "Total: " + totalData.ToString + " Data"

                        For Each item As JObject In JsonArray

                            Dim iDate As String = item.SelectToken("tanggal").ToString
                            Dim oDate As DateTime = Convert.ToDateTime(iDate)

                            DGV.Rows.Add(
                                item.SelectToken("kode").ToString,
                                Format(oDate, "dd MMMM yyyy"),
                                item.SelectToken("jml_item").ToString,
                                item.SelectToken("brand_name").ToString,
                                CDec(item.SelectToken("total").ToString),
                                CDec(item.SelectToken("total_diskon").ToString)
                            )
                            'String.Format("{0:N0}", item.SelectToken("hargadasar").ToString),
                            'String.Format("{0:N0}", item.SelectToken("hargajual").ToString)
                        Next

                        'DGV.Columns(1).DefaultCellStyle.Format = "M"
                        'DGV.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        'DGV.Columns(2).DefaultCellStyle.Format = "N0"
                        'DGV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'DGV.Columns(3).DefaultCellStyle.Format = "C0"
                        'DGV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'DGV.Columns(4).DefaultCellStyle.Format = "C0"
                        'DGV.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'DGV.Columns(5).DefaultCellStyle.Format = "C0"
                        'DGV.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    ElseIf jsonObject.SelectToken("code").ToString = "401" Then
                        MsgBox(jsonObject.SelectToken("message").ToString)
                    Else
                        MsgBox(Oops_401)
                    End If

                Catch ex As WebException
                    If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                        MsgBox(ex.Message.ToString)
                    End If
                End Try
            End If
        Else
            MsgBox(Oops_noInternet)
        End If
        DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        DGV.Rows.Clear()
    End Sub

    Private Sub DGV_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        If Not IsDBNull(DGV.Rows(e.RowIndex).Cells(0).Value) Then
            Dim nopesanan As String = DGV.Rows(e.RowIndex).Cells(0).Value
            TransaksiPembelian.txtNoPesanan.Text = nopesanan
            TransaksiPembelian.DGV.Rows.Clear()

            If CheckForInternetConnection() Then
                Try
                    Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "getPenjualanDBDetail")
                    Request.Method = "POST"
                    Request.Timeout = 3600000


                    Dim postbody As String = "kode=" + nopesanan + "&idoutlet=" + TransaksiPembelian.lookUpEdit.EditValue.ToString
                    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                    Request.ContentType = "application/x-www-form-urlencoded"
                    Request.ContentLength = byteArray.Length

                    Dim dataStream As Stream = Request.GetRequestStream()

                    dataStream.Write(byteArray, 0, byteArray.Length)
                    dataStream.Close()

                    'get HTTP Response
                    Dim Response As WebResponse = Request.GetResponse()
                    Console.WriteLine((CType(Response, HttpWebResponse)).StatusDescription)

                    'read HTTP response
                    Dim Read = New StreamReader(Response.GetResponseStream())
                    Raw = ""
                    Raw = Read.ReadToEnd()
                    'Console.WriteLine(Raw)

                    Dim jsonObject As JObject = JObject.Parse(Raw)
                    If jsonObject.SelectToken("code").ToString = "200" Then

                        Dim JsonArray As JArray = JArray.Parse(jsonObject.SelectToken("response").ToString)
                        For Each item As JObject In JsonArray

                            'TransaksiPembelian.DGV.Rows.Add(
                            '    item.SelectToken("id_barang").ToString,
                            '    item.SelectToken("nama").ToString,
                            '    CDec(item.SelectToken("hpj").ToString),
                            '    item.SelectToken("qty").ToString,
                            '    item.SelectToken("qty").ToString,
                            '    item.SelectToken("diskon").ToString,
                            '    CDec(item.SelectToken("nominal_diskon").ToString)
                            ')

                            Dim diskon As Double = item.SelectToken("diskon").ToString / 100
                            Dim diskonRupiah As Double = (item.SelectToken("hpj").ToString * item.SelectToken("qty").ToString) * diskon

                            TransaksiPembelian.DGV.Rows.Add(
                                item.SelectToken("id_barang").ToString,
                                item.SelectToken("nama").ToString,
                                CDec(item.SelectToken("hpj").ToString),
                                item.SelectToken("qty").ToString,
                                item.SelectToken("qty").ToString,
                                item.SelectToken("diskon").ToString,
                                ((item.SelectToken("hpj").ToString * item.SelectToken("qty").ToString) - diskonRupiah)
                            )
                        Next

                        Call TransaksiPembelian.Hitungtransaksi()

                    ElseIf jsonObject.SelectToken("code").ToString = "401" Then
                        MsgBox(jsonObject.SelectToken("message").ToString)
                    Else
                        MsgBox(Oops_401)
                    End If

                Catch ex As WebException
                    If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                        MsgBox(ex.Message.ToString)
                    End If
                End Try

            Else
                MsgBox(Oops_noInternet)
            End If

            TransaksiPembelian.Hitungtransaksi()
            Me.Close()
        End If
    End Sub

    Private Sub PesananKarung_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        dtpawal.Value = Now.Date.AddDays(-(Now.Day) + 1)
        dtpakhir.Value = Now.Date.AddDays(-(Now.Day) + 30)
        Call TampilGrid()
        'lblKodeSupp.Text = TransaksiPembelianDB.lblkodesupplier.Text
        'lblNamaSupp.Text = TransaksiPembelianDB.cbosupplier.Text
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Call TampilGrid()
    End Sub
End Class