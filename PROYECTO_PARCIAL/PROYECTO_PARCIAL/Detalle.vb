Public Class Detalle
    Private cantidad As Integer
    Private articulo As Articulo
    Private precioTotal As Double
    Private ivaCausado As Double

    Public Property P_cantidad() As Integer
        Get
            Return Me.cantidad
        End Get
        Set(ByVal value As Integer)
            Me.cantidad = value
        End Set
    End Property

    Public Property P_articulo() As Articulo
        Get
            Return Me.articulo
        End Get
        Set(ByVal value As Articulo)
            Me.articulo = value
        End Set
    End Property

    Public ReadOnly Property P_precioTotal() As Double
        Get
            Return Me.precioTotal
        End Get
    End Property

    Public ReadOnly Property P_ivaCausado() As Double
        Get
            Return Me.ivaCausado
        End Get
    End Property

    Public Sub New(cantidad As Integer, articulo As Articulo)
        P_cantidad = cantidad
        P_articulo = articulo
        CalcularPrecioTotal()
        Me.ivaCausado = 0.0
    End Sub

    Public Sub CalcularPrecioTotal()
        Me.precioTotal = Me.P_cantidad * Me.P_articulo.P_precio
    End Sub

    Public Sub CalcularIvaCausado(factor As Byte)
        If Me.P_articulo.P_pagoIva Then
            Me.ivaCausado = Me.precioTotal * factor / 100
        End If
    End Sub

    Public Sub Llenar()
        Console.WriteLine()
    End Sub

    Public Sub Mostrar()
        Console.WriteLine(Me.P_cantidad & vbTab & Me.P_articulo.P_nombre & vbTab & vbTab & vbTab & vbTab & Me.P_articulo.P_precio & vbTab & Me.P_precioTotal)
    End Sub
End Class
