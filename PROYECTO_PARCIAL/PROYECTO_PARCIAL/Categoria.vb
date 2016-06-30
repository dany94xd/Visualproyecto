Public Class Categoria
    Private nombre As String
    Private descripcion As String
    Private articulos As ArrayList

    Public Property P_nombre() As String
        Get
            Return Me.nombre
        End Get
        Set(ByVal value As String)
            Me.nombre = value
        End Set
    End Property

    Public Property P_descripcion() As String
        Get
            Return Me.descripcion
        End Get
        Set(ByVal value As String)
            Me.descripcion = value
        End Set
    End Property

    Public Property P_articulos() As ArrayList
        Get
            Return Me.articulos
        End Get
        Set(ByVal value As ArrayList)
            Me.articulos = value
        End Set
    End Property

    Public Sub New()
        Me.P_nombre = ""
        Me.P_descripcion = ""
        Me.P_articulos = New ArrayList
    End Sub

    Public Sub Listar_Articulos()
        Console.WriteLine(vbTab & "CODPROD" & vbTab & vbTab & "DESCRIPCION" & vbTab & vbTab & "PRECIO")
        For Each articulo As Articulo In Me.P_articulos
            articulo.Mostrar_Datos()
        Next
    End Sub
End Class
