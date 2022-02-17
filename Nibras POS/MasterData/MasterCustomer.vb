Imports MySql.Data.MySqlClient

Public Class MasterCustomer

    Sub Kosongkan()
        txtKodeMember.Clear()
        txtKodeMember.ReadOnly = False
        txtNama.Clear()
        txtAlamat.Clear()
        txtTelepon.Clear()
        txtKodepos.Clear()
        txtEmail.Text = ""
        txtContact.Text = ""
        txtKota.Clear()
        txtProvinsi.Clear()
        txtLimitPiutang.Text = "0"
        txtHariPiutang.Text = "7"
        txtJatuhTempo.Text = "7"

        txtKodeMember.Focus()
        Call TampilGroup()
    End Sub

    Private Sub MasterCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        cekClose()
        Call Kosongkan()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Call Kosongkan()
        txtGroup.SelectedIndex = 0
    End Sub

    Private Sub BTNTutup_Click(sender As Object, e As EventArgs) Handles BTNTutup.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        cekOpen()
        CMD = New MySqlCommand("select * from member_m where kode_member='" & txtKodeMember.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        Try
            If DR.HasRows Then
                cekClose()

                cekOpen()
                Dim edit As String = "UPDATE member_m SET nama_member='" & txtNama.Text &
                    "',alamat='" & txtAlamat.Text &
                    "',kota='" & txtKota.Text &
                    "',provinsi='" & txtProvinsi.Text &
                    "',kode_pos='" & txtKodepos.Text &
                    "',telepon='" & txtTelepon.Text &
                    "',email='" & txtEmail.Text &
                    "',tgl_lahir='" & Format(dtpTglLahir.Value, "yyyy-MM-dd") &
                    "',kontak='" & txtContact.Text &
                    "',limit_piutang='" & txtLimitPiutang.Text &
                    "',limit_hari_piutang='" & txtHariPiutang.Text &
                    "',jatuh_tempo='" & txtJatuhTempo.Text &
                    "',group_member='" & txtGroup.Text &
                    "',tipe_diskon='" & txtTipeDiskon.Text &
                    "',tgl_daftar='" & Format(dtpTglDaftar.Value, "yyyy-MM-dd") &
                    "',masa_aktif='" & Format(dtpMasaAktif.Value, "yyyy-MM-dd") &
                    "' WHERE kode_member='" & txtKodeMember.Text & "'"
                CMD = New MySqlCommand(edit, Conn)
                CMD.ExecuteNonQuery()
                cekClose()
            Else
                cekClose()

                cekOpen()
                Dim simpan As String = "INSERT INTO member_m VALUES ('" &
                    txtKodeMember.Text &
                    "','" & txtNama.Text &
                    "','" & txtAlamat.Text &
                    "','" & txtKota.Text &
                    "','" & txtProvinsi.Text &
                    "','" & txtKodepos.Text &
                    "','" & txtTelepon.Text &
                    "','" & txtEmail.Text &
                    "','" & Format(dtpTglLahir.Value, "yyyy-MM-dd") &
                    "','" & txtContact.Text &
                    "','" & txtLimitPiutang.Text &
                    "','" & txtHariPiutang.Text &
                    "','" & txtJatuhTempo.Text &
                    "','" & txtGroup.Text &
                    "','" & txtTipeDiskon.Text &
                    "', 0, '" & Format(dtpTglDaftar.Value, "yyyy-MM-dd") &
                    "','" & Format(dtpMasaAktif.Value, "yyyy-MM-dd") &
                    "')"
                CMD = New MySqlCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                cekClose()
            End If
            MsgBox("Data Berhasil Disimpan!")
            ListDataMember.TampilGrid()
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Call Kosongkan()
    End Sub

    Private Sub txtLimitPiutang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimitPiutang.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If e.KeyChar = ChrW(Keys.Return) Then
            txtHariPiutang.Focus()
        End If
    End Sub

    Private Sub txtHariPiutang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHariPiutang.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If e.KeyChar = ChrW(Keys.Return) Then
            txtJatuhTempo.Focus()
        End If
    End Sub

    Private Sub txtJatuhTempo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJatuhTempo.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If e.KeyChar = ChrW(Keys.Return) Then
            txtGroup.Focus()
        End If
    End Sub

    Sub TampilGroup()
        cekOpen()
        CMD = New MySqlCommand("SELECT * FROM group_member ORDER BY nama_group ASC", Conn)
        DR = CMD.ExecuteReader
        txtGroup.Items.Clear()
        Do While DR.Read
            'txtGroup.Items.Add(DR.Item("id_group") & "-" & DR.Item("nama_group"))
            txtGroup.Items.Add(DR.Item("kode_group"))
        Loop
        cekClose()
    End Sub

    Private Sub dtpTglDaftar_ValueChanged(sender As Object, e As EventArgs) Handles dtpTglDaftar.ValueChanged
        Dim tambahhari As Integer = 365
        dtpMasaAktif.Value = DateAdd(DateInterval.Day, tambahhari, dtpTglDaftar.Value)
    End Sub

    Private Sub txtKodeMember_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeMember.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            txtNama.Focus()
        End If
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            txtAlamat.Focus()
        End If
    End Sub

    Private Sub txtAlamat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlamat.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            txtKota.Focus()
        End If
    End Sub

    Private Sub txtKota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKota.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            txtProvinsi.Focus()
        End If
    End Sub

    Private Sub txtProvinsi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProvinsi.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            txtTelepon.Focus()
        End If
    End Sub

    Private Sub txtTelepon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelepon.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            txtKodepos.Focus()
        End If
    End Sub


    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            dtpTglLahir.Focus()
        End If
    End Sub

    Private Sub txtKodepos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodepos.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            txtEmail.Focus()
        End If
    End Sub

    Private Sub dtpTglLahir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpTglLahir.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            txtContact.Focus()
        End If
    End Sub

    Private Sub txtContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContact.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            txtLimitPiutang.Focus()
        End If
    End Sub

    Private Sub txtGroup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGroup.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            dtpTglDaftar.Focus()
        End If
    End Sub

    Private Sub txtTipeDiskon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTipeDiskon.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            dtpTglDaftar.Focus()
        End If
    End Sub

    Private Sub dtpTglDaftar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpTglDaftar.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            dtpMasaAktif.Focus()
        End If
    End Sub

    Private Sub dtpMasaAktif_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpMasaAktif.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            SimpleButton1.Focus()
        End If
    End Sub

End Class