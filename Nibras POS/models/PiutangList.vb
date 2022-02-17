Public Class PiutangList

    Private tNo_Transaksi As String
    Public Property no_transaksi() As String
        Get
            Return tNo_Transaksi
        End Get
        Set(ByVal value As String)
            tNo_Transaksi = value
        End Set
    End Property

    Private tNo_Faktur As String
    Public Property no_faktur() As String
        Get
            Return tNo_Faktur
        End Get
        Set(ByVal value As String)
            tNo_Faktur = value
        End Set
    End Property

    Private tKode_Member As String
    Public Property kode_member() As String
        Get
            Return tKode_Member
        End Get
        Set(ByVal value As String)
            tKode_Member = value
        End Set
    End Property

    Private tTanggal As String
    Public Property tanggal() As String
        Get
            Return tTanggal
        End Get
        Set(ByVal value As String)
            tTanggal = value
        End Set
    End Property

    Private tTanggal_JT As String
    Public Property tanggal_jt() As String
        Get
            Return tTanggal_JT
        End Get
        Set(ByVal value As String)
            tTanggal_JT = value
        End Set
    End Property

    Private tPotongan As String
    Public Property potongan() As String
        Get
            Return tPotongan
        End Get
        Set(ByVal value As String)
            tPotongan = value
        End Set
    End Property

    Private tTotal As String
    Public Property total() As String
        Get
            Return tTotal
        End Get
        Set(ByVal value As String)
            tTotal = value
        End Set
    End Property

    Private tSisa As String
    Public Property sisa() As String
        Get
            Return tSisa
        End Get
        Set(ByVal value As String)
            tSisa = value
        End Set
    End Property
    Private tKeterangan As String
    Public Property keterangan() As String
        Get
            Return tKeterangan
        End Get
        Set(ByVal value As String)
            tKeterangan = value
        End Set
    End Property

    Private tUmurJT As String
    Public Property umur_jt() As String
        Get
            Return tUmurJT
        End Get
        Set(ByVal value As String)
            tUmurJT = value
        End Set
    End Property

    Private tJT As String
    Public Property jt() As String
        Get
            Return tJT
        End Get
        Set(ByVal value As String)
            tJT = value
        End Set
    End Property
End Class
