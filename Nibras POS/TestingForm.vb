Imports MySql.Data.MySqlClient

Public Class TestingForm

    Private Products As New List(Of Product)()
    Private Categories As New List(Of Category)()

    Private Sub InitData()
        Products.Add(New Product() With {.ProductName = "Sir Rodney's Scones", .CategoryID = 3, .UnitPrice = 10})
        Products.Add(New Product() With {.ProductName = "Gustaf's Knäckebröd", .CategoryID = 5, .UnitPrice = 21})
        Products.Add(New Product() With {.ProductName = "Tunnbröd", .CategoryID = 5, .UnitPrice = 9})
        Products.Add(New Product() With {.ProductName = "Guaraná Fantástica", .CategoryID = 1, .UnitPrice = 4.5D})
        Products.Add(New Product() With {.ProductName = "NuNuCa Nuß-Nougat-Creme", .CategoryID = 3, .UnitPrice = 14})
        Products.Add(New Product() With {.ProductName = "Gumbär Gummibärchen", .CategoryID = 3, .UnitPrice = 31.23D})
        Products.Add(New Product() With {.ProductName = "Rössle Sauerkraut", .CategoryID = 7, .UnitPrice = 45.6D})
        Products.Add(New Product() With {.ProductName = "Thüringer Rostbratwurst", .CategoryID = 6, .UnitPrice = 123.79D})
        Products.Add(New Product() With {.ProductName = "Nord-Ost Matjeshering", .CategoryID = 8, .UnitPrice = 25.89D})
        Products.Add(New Product() With {.ProductName = "Gorgonzola Telino", .CategoryID = 4, .UnitPrice = 12.5D})

        Categories.Add(New Category() With {.ID = 1, .CategoryName = "Beverages", .Description = "Soft drinks, coffees, teas, beers, and ales"})
        Categories.Add(New Category() With {.ID = 2, .CategoryName = "Condiments", .Description = "Sweet and savory sauces, relishes, spreads, and seasonings"})
        Categories.Add(New Category() With {.ID = 3, .CategoryName = "Confections", .Description = "Desserts, candies, and sweet breads"})
        Categories.Add(New Category() With {.ID = 4, .CategoryName = "Dairy Products", .Description = "Cheeses"})
        Categories.Add(New Category() With {.ID = 5, .CategoryName = "Grains/Cereals", .Description = "Breads, crackers, pasta, and cereal"})
        Categories.Add(New Category() With {.ID = 6, .CategoryName = "Meat/Poultry", .Description = "Prepared meats"})
        Categories.Add(New Category() With {.ID = 7, .CategoryName = "Produce", .Description = "Dried fruit and bean curd"})
        Categories.Add(New Category() With {.ID = 8, .CategoryName = "Seafood", .Description = "Seaweed and fish"})
    End Sub

    Private dvMain, dvProducts As DataView
    Private Sub TestingForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call cekKoneksi()

        cekOpen()
        DA = New MySqlDataAdapter("select kode_item, nama_barang, hpp, hpj from barang_m", Conn)
        DS = New DataSet
        DA.Fill(DS)
        LookUpEdit1.Properties.DataSource = DS.Tables(0)
        LookUpEdit1.Properties.DisplayMember = "nama_barang"
        LookUpEdit1.Properties.ValueMember = "kode_item"
        cekClose()
    End Sub


    Public Class Product
        Public Property ProductName() As String
        Public Property UnitPrice() As Decimal
        Public Property CategoryID() As Integer
    End Class

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        MsgBox(LookUpEdit1.EditValue.ToString + " - Display " + LookUpEdit1.Text.ToString)
    End Sub

    Public Class Category
        Public Property ID() As Integer
        Public Property CategoryName() As String
        Public Property Description() As String
    End Class
End Class