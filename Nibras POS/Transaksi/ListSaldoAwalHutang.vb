Public Class ListSaldoAwalHutang
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        SaldoAwalHutangForm.MdiParent = MainMenu
        SaldoAwalHutangForm.Show()
        SaldoAwalHutangForm.Focus()
    End Sub
End Class