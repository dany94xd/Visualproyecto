Public Class Articulo
    Private codigo As String
    Private nombre As String
    Private precio As Double
    Private pagoIva As Boolean

    Public Property P_codigo() As String
        Get
            Return Me.codigo
        End Get
        Set(ByVal value As String)
            Me.codigo = value
        End Set
    End Property

    Public Property P_nombre() As String
        Get
            Return Me.nombre
        End Get
        Set(ByVal value As String)
            Me.nombre = value
        End Set
    End Property

    Public Property P_precio() As Double
        Get
            Return Me.precio
        End Get
        Set(ByVal value As Double)
            Me.precio = value
        End Set
    End Property

    Public Property P_pagoIva() As Boolean
        Get
            Return Me.pagoIva
        End Get
        Set(ByVal value As Boolean)
            Me.pagoIva = value
        End Set
    End Property

    Public Sub Mostrar_Datos()
        Console.WriteLine(vbTab & Me.P_codigo & vbTab & vbTab & Me.P_nombre & vbTab & vbTab & Me.P_precio)
    End Sub
End Class
