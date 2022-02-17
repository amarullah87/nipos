Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports System.Net
Imports System.Text
Imports System.IO
Module UploadMember

    Dim today As Date = Date.Today
    Dim tgl_awal As String = Format(today, "yyyy-MM-dd")

    Public Function GetMember() As String
        Dim dataMember As New List(Of ModelMember)()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM member_m WHERE kode_member <> '00000' ", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            dataMember.Add(New ModelMember() With {
                        .kode_member = DR.Item("kode_member"),
                        .nama_member = DR.Item("nama_member"),
                        .alamat = DR.Item("alamat"),
                        .kota = DR.Item("kota"),
                        .provinsi = DR.Item("provinsi"),
                        .kode_pos = DR.Item("kode_pos"),
                        .telp = DR.Item("telepon"),
                        .email = DR.Item("email"),
                        .tgl_lahir = DR.Item("tgl_lahir"),
                        .kontak = DR.Item("kontak"),
                        .limit_piutang = DR.Item("limit_piutang"),
                        .limit_hari_piutang = DR.Item("limit_hari_piutang"),
                        .jatuh_tempo = DR.Item("jatuh_tempo"),
                        .group_member = DR.Item("group_member"),
                        .tipe_diskon = DR.Item("tipe_diskon"),
                        .deposit = DR.Item("deposit"),
                        .tgl_daftar = DR.Item("tgl_daftar"),
                        .masa_aktif = DR.Item("masa_aktif")
            })
        Loop
        cekClose()

        Return JsonConvert.SerializeObject(dataMember)
    End Function

    Public Sub uploadMembers()

        Dim dataInput As String = GetMember()

        Dim Raw As String
        If CheckForInternetConnection() Then
            Try
                Dim Request As WebRequest = WebRequest.Create(getBaseUrl() + "uploadMember")
                Request.Method = "POST"
                Request.Timeout = 60000

                Dim postbody As String = "data=" & dataInput & "&id_outlet=" & MainMenu.PanelID.Text

                'Console.WriteLine(postbody)
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postbody)
                Request.ContentType = "application/x-www-form-urlencoded"
                Request.ContentLength = byteArray.Length

                Dim dataStream As Stream = Request.GetRequestStream()

                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()

                Dim Response As WebResponse = Request.GetResponse()
                Dim Read = New StreamReader(Response.GetResponseStream())
                Raw = ""
                Raw = Read.ReadToEnd()
                'Console.WriteLine(Raw)

            Catch ex As WebException
                If ex.Status = WebExceptionStatus.ProtocolError Or ex.Status = WebExceptionStatus.ConnectFailure Or ex.Status = WebExceptionStatus.Timeout Then
                    MsgBox("Upload Member Failed with Message : " + ex.Message.ToString)
                End If
            End Try
        End If
    End Sub

    Public Class ModelMember
        Private t_kode_member As String
        Public Property kode_member() As String
            Get
                Return t_kode_member
            End Get
            Set(ByVal value As String)
                t_kode_member = value
            End Set
        End Property

        Private t_nama_member As String
        Public Property nama_member() As String
            Get
                Return t_nama_member
            End Get
            Set(ByVal value As String)
                t_nama_member = value
            End Set
        End Property

        Private t_alamat As String
        Public Property alamat() As String
            Get
                Return t_alamat
            End Get
            Set(ByVal value As String)
                t_alamat = value
            End Set
        End Property

        Private t_provinsi As String
        Public Property provinsi() As String
            Get
                Return t_provinsi
            End Get
            Set(ByVal value As String)
                t_provinsi = value
            End Set
        End Property

        Private t_kota As String
        Public Property kota() As String
            Get
                Return t_kota
            End Get
            Set(ByVal value As String)
                t_kota = value
            End Set
        End Property

        Private t_kode_pos As String
        Public Property kode_pos() As String
            Get
                Return t_kode_pos
            End Get
            Set(ByVal value As String)
                t_kode_pos = value
            End Set
        End Property

        Private t_telp As String
        Public Property telp() As String
            Get
                Return t_telp
            End Get
            Set(ByVal value As String)
                t_telp = value
            End Set
        End Property

        Private t_email As String
        Public Property email() As String
            Get
                Return t_email
            End Get
            Set(ByVal value As String)
                t_email = value
            End Set
        End Property

        Private t_tgl_lahir As String
        Public Property tgl_lahir() As String
            Get
                Return t_tgl_lahir
            End Get
            Set(ByVal value As String)
                t_tgl_lahir = value
            End Set
        End Property

        Private t_kontak As String
        Public Property kontak() As String
            Get
                Return t_kontak
            End Get
            Set(ByVal value As String)
                t_kontak = value
            End Set
        End Property

        Private t_limit_piutang As String
        Public Property limit_piutang() As String
            Get
                Return t_limit_piutang
            End Get
            Set(ByVal value As String)
                t_limit_piutang = value
            End Set
        End Property

        Private t_limit_hari_piutang As String
        Public Property limit_hari_piutang() As String
            Get
                Return t_limit_hari_piutang
            End Get
            Set(ByVal value As String)
                t_limit_hari_piutang = value
            End Set
        End Property

        Private t_jatuh_tempo As String
        Public Property jatuh_tempo() As String
            Get
                Return t_jatuh_tempo
            End Get
            Set(ByVal value As String)
                t_jatuh_tempo = value
            End Set
        End Property

        Private t_group_member As String
        Public Property group_member() As String
            Get
                Return t_group_member
            End Get
            Set(ByVal value As String)
                t_group_member = value
            End Set
        End Property

        Private t_tipe_diskon As String
        Public Property tipe_diskon() As String
            Get
                Return t_tipe_diskon
            End Get
            Set(ByVal value As String)
                t_tipe_diskon = value
            End Set
        End Property

        Private t_deposit As String
        Public Property deposit() As String
            Get
                Return t_deposit
            End Get
            Set(ByVal value As String)
                t_deposit = value
            End Set
        End Property

        Private t_tgl_daftar As String
        Public Property tgl_daftar() As String
            Get
                Return t_tgl_daftar
            End Get
            Set(ByVal value As String)
                t_tgl_daftar = value
            End Set
        End Property

        Private t_masa_aktif As String
        Public Property masa_aktif() As String
            Get
                Return t_masa_aktif
            End Get
            Set(ByVal value As String)
                t_masa_aktif = value
            End Set
        End Property

    End Class
End Module
