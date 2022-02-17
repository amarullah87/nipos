Imports MySql.Data.MySqlClient

Public Class MasterPerkiraan

    Sub LoadData()
        'Creating the root node
        Dim root = New TreeNode("Daftar Kode Perkiraan")
        tvData.Nodes.Add(root)

        '## Kode Parent 1 ##'
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE kodeacc = '1-0000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        Dim kode1 As String = DR.Item("kodeacc") + " " + DR.Item("namaacc")
        tvData.Nodes(0).Nodes.Add(New TreeNode(kode1))
        cekClose()

        tvData.Nodes(0).Nodes(0).Nodes.Add(New _
               TreeNode("1-1000 AKTIVA LANCAR"))

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '1-1000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        Dim count11 As Integer = 0
        Do While DR.Read
            tvData.Nodes(0).Nodes(0).Nodes(0).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
            count11 += 1
        Loop
        cekClose()

        tvData.Nodes(0).Nodes(0).Nodes.Add(New _
               TreeNode("1-5000 AKTIVA TETAP"))

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '1-5000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()

        Dim count12 As Integer = 0
        Do While DR.Read
            tvData.Nodes(0).Nodes(0).Nodes(1).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
            count12 += 1
        Loop
        cekClose()
        '## Kode Parent 1 ##'

        '## Kode Parent 2 ##'
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE kodeacc = '2-0000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        Dim kode2 As String = DR.Item("kodeacc") + " " + DR.Item("namaacc")
        tvData.Nodes(0).Nodes.Add(New TreeNode(kode2))
        cekClose()

        tvData.Nodes(0).Nodes(1).Nodes.Add(New _
               TreeNode("2-1000 KEWAJIBAN LANCAR"))
        tvData.Nodes(0).Nodes(1).Nodes.Add(New _
               TreeNode("2-2000 HUTANG NON OPERASIONAL" + " [D]"))
        tvData.Nodes(0).Nodes(1).Nodes.Add(New _
               TreeNode("2-3000 PENDAPATAN DITERIMA DIMUKA"))
        tvData.Nodes(0).Nodes(1).Nodes.Add(New _
               TreeNode("2-4000 HUTANG PAJAK"))
        tvData.Nodes(0).Nodes(1).Nodes.Add(New _
               TreeNode("2-6000 BARANG KONSINYASI MASUK"))

        tvData.Nodes(0).Nodes(1).Nodes(0).Nodes.Add(New _
               TreeNode("2-1100 HUTANG"))
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '2-1100'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(1).Nodes(0).Nodes(0).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()

        tvData.Nodes(0).Nodes(1).Nodes(0).Nodes.Add(New _
               TreeNode("2-1200 HUTANG GAJI" + " [D]"))
        tvData.Nodes(0).Nodes(1).Nodes(0).Nodes.Add(New _
               TreeNode("2-1300 HUTANG SALES" + " [D]"))
        tvData.Nodes(0).Nodes(1).Nodes(0).Nodes.Add(New _
               TreeNode("2-1500 PROSES PERAKITAN"))
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '2-1500'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(1).Nodes(0).Nodes(3).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '2-3000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(1).Nodes(2).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '2-4000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(1).Nodes(3).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '2-6000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(1).Nodes(4).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()
        '## Kode Parent 2 ##'

        '## Kode Parent 3 ##'
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE kodeacc = '3-0000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        Dim kode3 As String = DR.Item("kodeacc") + " " + DR.Item("namaacc")
        tvData.Nodes(0).Nodes.Add(New TreeNode(kode3))
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '3-0000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(2).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()
        '## Kode Parent 3 ##'

        '## Kode Parent 4 ##'
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE kodeacc = '4-0000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        Dim kode4 As String = DR.Item("kodeacc") + " " + DR.Item("namaacc")
        tvData.Nodes(0).Nodes.Add(New TreeNode(kode4))
        cekClose()

        tvData.Nodes(0).Nodes(3).Nodes.Add(New _
               TreeNode("4-1000 PENDAPATAN DAGANG"))
        tvData.Nodes(0).Nodes(3).Nodes.Add(New _
               TreeNode("4-2000 PENDAPATAN JASA" + " [D]"))

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '4-1000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(3).Nodes(0).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()
        '## Kode Parent 4 ##'

        '## Kode Parent 5 ##'
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE kodeacc = '5-0000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        Dim kode5 As String = DR.Item("kodeacc") + " " + DR.Item("namaacc")
        tvData.Nodes(0).Nodes.Add(New TreeNode(kode5))
        cekClose()

        tvData.Nodes(0).Nodes(4).Nodes.Add(New _
               TreeNode("5-1000 HPP"))
        tvData.Nodes(0).Nodes(4).Nodes.Add(New _
               TreeNode("5-2000 LAIN-LAIN"))

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '5-1000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(4).Nodes(0).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '5-2000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(4).Nodes(1).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()
        '## Kode Parent 5 ##'

        '## Kode Parent 6 ##'
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE kodeacc = '6-0000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        Dim kode6 As String = DR.Item("kodeacc") + " " + DR.Item("namaacc")
        tvData.Nodes(0).Nodes.Add(New TreeNode(kode6))
        cekClose()

        tvData.Nodes(0).Nodes(5).Nodes.Add(New _
               TreeNode("6-1000 BIAYA UMUM"))
        tvData.Nodes(0).Nodes(5).Nodes.Add(New _
               TreeNode("6-2000 BIAYA PEMASARAN"))
        tvData.Nodes(0).Nodes(5).Nodes.Add(New _
               TreeNode("6-3000 BIAYA GAJI DAN UPAH"))
        tvData.Nodes(0).Nodes(5).Nodes.Add(New _
               TreeNode("6-4000 BIAYA OPERASIONAL"))
        tvData.Nodes(0).Nodes(5).Nodes.Add(New _
               TreeNode("6-5000 BIAYA PENYUSUTAN"))
        tvData.Nodes(0).Nodes(5).Nodes.Add(New _
               TreeNode("6-9000 BIAYA NON INVENTORY"))

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '6-1000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(5).Nodes(0).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '6-2000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(5).Nodes(1).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '6-3000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(5).Nodes(2).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '6-4000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(5).Nodes(3).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '6-5000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(5).Nodes(4).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '6-9000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(5).Nodes(5).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()
        '## Kode Parent 6 ##'

        '## Kode Parent 7 ##'
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE kodeacc = '7-0000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        Dim kode7 As String = DR.Item("kodeacc") + " " + DR.Item("namaacc")
        tvData.Nodes(0).Nodes.Add(New TreeNode(kode7))
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '7-0000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(6).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()
        '## Kode Parent 7 ##'

        '## Kode Parent 8 ##'
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE kodeacc = '8-0000'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        Dim kode8 As String = DR.Item("kodeacc") + " " + DR.Item("namaacc")
        tvData.Nodes(0).Nodes.Add(New TreeNode(kode8))
        cekClose()

        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM perkiraan WHERE parentacc = '8-0000'", Conn)
        DR = CMD.ExecuteReader

        Do While DR.Read
            tvData.Nodes(0).Nodes(7).Nodes.Add(New _
               TreeNode(DR.Item("kodeacc") + " " + DR.Item("namaacc") + " [D]"))
        Loop
        cekClose()
        '## Kode Parent 8 ##'

    End Sub

    Private Sub MasterPerkiraan_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call LoadData()
    End Sub
End Class