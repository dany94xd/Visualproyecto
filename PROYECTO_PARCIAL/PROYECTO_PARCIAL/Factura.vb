Public Class Factura
    Private cliente As Cliente
    Private numero As String
    Private detalles As ArrayList
    Private subTotal As Double
    Private ivaTotal As Double
    Private total As Double

    Public Property P_cliente() As Cliente
        Get
            Return Me.cliente
        End Get
        Set(ByVal value As Cliente)
            Me.cliente = value
        End Set
    End Property

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

    'Public Sub New()
    '    Me.P_cliente = New Cliente(1)
    '    Me.P_detalles = New ArrayList
    '    Me.subTotal = 0.0
    '    Me.ivaTotal = 0.0
    '    Me.total = 0.0
    'End Sub

    Public Sub New()
        Dim idCliente As Integer = 0
        Console.Write("INGRESE EL ID DEL CLIENTE: ")
        idCliente = Console.ReadLine()
        Me.P_cliente = New Cliente(idCliente)
        If Me.P_cliente.P_numeroDocumento Is Nothing Then
            MsgBox("el cliente no existe")
            Me.P_cliente = New Cliente()
            Me.P_detalles = New ArrayList
            Me.subTotal = 0.0
            Me.ivaTotal = 0.0
            Me.total = 0.0
        Else
            Me.P_detalles = New ArrayList
            Me.subTotal = 0.0
            Me.ivaTotal = 0.0
            Me.total = 0.0
        End If
    End Sub

    Public Sub Visualizar()
        Me.P_cliente.Mostrar_Datos()
        Console.WriteLine("CANT" & vbTab & "DETALLES" & vbTab & vbTab & vbTab & vbTab & "P. UNIT" & vbTab & vbTab & "P.TOTAL")
        For Each detalle As Detalle In Me.P_detalles
            detalle.Mostrar()
        Next
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "SUBTOTAL: " & vbTab & "$ " & P_subTotal)
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "IVA(14%): " & vbTab & "$ " & P_ivaTotal)
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "TOTAL   : " & vbTab & "$ " & P_total)
    End Sub
End Class
