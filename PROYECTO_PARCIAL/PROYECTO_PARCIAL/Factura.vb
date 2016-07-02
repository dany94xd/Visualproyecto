Public Class Factura
    Private numero As String
    Private detalles As ArrayList
    Private subTotal As Double
    Private ivaTotal As Double
    Private total As Double

    Public ReadOnly Property P_numero() As String
        Get
            Return Me.numero
        End Get
    End Property

    Public Property P_detalles() As ArrayList
        Get
            Return Me.detalles
        End Get
        Set(ByVal value As ArrayList)
            Me.detalles = value
        End Set
    End Property

    Public ReadOnly Property P_subTotal() As Double
        Get
            Return Me.subTotal
        End Get
    End Property

    Public ReadOnly Property P_ivaTotal() As Double
        Get
            Return Me.ivaTotal
        End Get
    End Property

    Public ReadOnly Property P_total() As Double
        Get
            Return Me.total
        End Get
    End Property

    Public Sub CalcularSubTotal()
        For Each detalle As Detalle In Me.P_detalles
            Me.total = Me.total + detalle.P_precioTotal
        Next
    End Sub

    Public Sub CalcularIvaTotal()
        For Each detalle As Detalle In Me.P_detalles
            Me.ivaTotal = Me.ivaTotal + detalle.P_ivaCausado
        Next
    End Sub

    Public Sub CalcularTotal()
        Me.total = Me.P_subTotal + Me.P_ivaTotal
    End Sub
End Class
