Public Class Factura
    Private baseIva As Byte
    Private fecha As Date
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
        Dim identificacion As String = ""
        Console.Write("INGRESE EL ID DEL CLIENTE: ")
        identificacion = Console.ReadLine()
        Me.P_cliente = New Cliente()
        Me.P_cliente.Cargar(identificacion)
        If Me.P_cliente.P_identificacion = "" Then
            MsgBox("el cliente no existe")
            Me.P_cliente = New Cliente(identificacion)
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
        Console.Clear()
        Me.fecha = Today
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "FECHA   : " & Me.fecha)
        Me.P_cliente.Mostrar_Datos()
        Console.WriteLine("CANT" & vbTab & "DETALLES" & vbTab & vbTab & vbTab & vbTab & "P. UNIT" & vbTab & vbTab & "P.TOTAL")
        For Each detalle As Detalle In Me.P_detalles
            detalle.Mostrar()
        Next
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "SUBTOTAL: " & vbTab & "$ " & P_subTotal)
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "IVA(" & baseIva & "%): " & vbTab & "$ " & P_ivaTotal)
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "TOTAL   : " & vbTab & "$ " & P_total)
    End Sub

    Public Sub Agregar_Detalles(categorias As ArrayList)
        Dim agregar As Boolean = True
        Dim index As Byte = 1
        While agregar
            Dim categ As Categoria = New Categoria
            Console.WriteLine("SELECCIONE UNA CATEGORIA")
            For Each categoria As Categoria In categorias
                Console.WriteLine(index & ".- " & categoria.P_nombre)
                index = index + 1
            Next
            Do
                Try
                    index = Console.ReadLine()
                Catch ex As Exception
                    index = 0
                    Console.WriteLine("INGRESE UN NUMERO VALIDO")
                End Try
            Loop While index < 1 Or index > categorias.Count
            categ = categorias.Item(index - 1)
            categ.Cargar_Articulos(categ.P_nombre)
            Dim articulo As Articulo = New Articulo()
            Dim codigo As String = ""
            Do
                Console.WriteLine("ESCRIBA EL CODIGO DEL ARTICULO")
                categ.Listar_Articulos()
                codigo = Console.ReadLine()
                articulo = categ.Consultar_Articulo(codigo.ToUpper)
                'Console.WriteLine(articulo.P_nombre + "AQUIIII")
            Loop While articulo.P_nombre Is Nothing
            Dim cantidad As Integer = 0
            Do
                Console.Write("CANTIDAD DE ARTICULOS: ")
                Try
                    cantidad = Console.ReadLine()
                Catch ex As Exception
                    index = 0
                    Console.WriteLine("INGRESE UNA CIFRA VALIDA")
                End Try
            Loop While cantidad < 1
            Dim detalle As Detalle = New Detalle(cantidad, articulo)
            detalle.CalcularPrecioTotal()
            detalle.CalcularIvaCausado(baseIva)
            Me.P_detalles.Add(detalle)
            Generar_Totales()
            Visualizar()
            Dim opc As Byte = 99
            Do
                Console.WriteLine("NUEVO DETALLE: 1.- SI    0.- NO")
                Try
                    opc = Console.ReadLine()
                Catch ex As Exception
                    opc = 99
                    Console.WriteLine("INGRESE UNA OPCION VALIDA")
                End Try
            Loop While opc > 1
            Select Case opc
                Case 1
                    agregar = True
                Case 0
                    agregar = False
            End Select
        End While
    End Sub

    Public Sub Parametros(provincias As ArrayList, formasPago As ArrayList)
        Dim opc_fp As Byte = 1
        Do
            Console.WriteLine("Elija una forma de pago")
            For Each forma As FormaPago In formasPago
                Console.WriteLine(opc_fp & ".- " & forma.P_nombre)
                opc_fp = opc_fp + 1
            Next
            Try
                opc_fp = Console.ReadLine
            Catch ex As Exception
                opc_fp = 0
            End Try
        Loop While opc_fp < 1 Or opc_fp > formasPago.Count
        Dim formaPago As FormaPago = formasPago.Item(opc_fp - 1)

        Dim opc_pr As Byte = 1
        Do
            Console.WriteLine("Elija una provincia:")
            For Each prov As Provincia In provincias
                Console.WriteLine(opc_pr & ".- " & prov.P_nombre)
                opc_pr = opc_pr + 1
            Next
            Try
                opc_pr = Console.ReadLine
            Catch ex As Exception
                opc_pr = 0
            End Try
        Loop While opc_pr < 1 Or opc_pr > provincias.Count
        Dim provincia As Provincia = provincias.Item(opc_pr - 1)

        If provincia.P_nombre = "ESMERALDAS" Or provincia.P_nombre = "MANABI" Then
            Me.baseIva = 12 - formaPago.P_beneficio
        Else
            Me.baseIva = 14 - formaPago.P_beneficio
        End If
    End Sub

    Public Sub Generar_Totales()
        Me.subTotal = 0.0
        Me.ivaTotal = 0.0
        For Each detalle As Detalle In Me.P_detalles
            Me.subTotal = Me.subTotal + detalle.P_precioTotal
            Me.ivaTotal = Me.ivaTotal + detalle.P_ivaCausado
        Next
        Me.total = Me.P_subTotal + Me.P_ivaTotal
    End Sub
End Class
