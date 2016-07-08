Imports System.Xml

Public Class Sistema
    Private usuario As Usuario
    Private categorias As ArrayList
    Dim categ As Categoria 'auxiliar de categorias

    Public Property P_usuario() As Usuario
        Get
            Return Me.usuario
        End Get
        Set(ByVal value As Usuario)
            Me.usuario = value
        End Set
    End Property

    Public Property P_categorias() As ArrayList
        Get
            Return Me.categorias
        End Get
        Set(ByVal value As ArrayList)
            Me.categorias = value
        End Set
    End Property

    'Public Sub New()
    '    Me.administrador = New Administrador
    '    Me.Administrar(administrador.Menu)
    'End Sub

    Public Sub Listar_Productos()

        Dim index As Byte = 1
        Dim i As Byte = 1
        Me.Cargar_Categorias()
        Console.WriteLine("ESCRIBA EL INDICE DE LA CATEGORIA")
        For Each categoria As Categoria In P_categorias
            Console.WriteLine(i & ".- " & categoria.P_nombre)
            i = i + 1
        Next
        index = Console.ReadLine()
        Me.Cargar_Articulos_Categoria(index - 1)
        Me.categ = Me.P_categorias.Item(index - 1)
        Me.categ.Listar_Articulos()


    End Sub

    Public Sub Cargar_Categorias()
        Me.P_categorias = New ArrayList
        Dim patch As String = "XML\ARTICULOS\Categorias.xml"
        'CARGA DESDE CATEGORIAS.XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(patch)
        Dim lista_categorias As XmlNodeList = xmlDoc.GetElementsByTagName("categoria")
        For Each categoria As XmlNode In lista_categorias
            Dim categ As Categoria = New Categoria
            categ.P_nombre = categoria.Attributes(0).Value
            For Each detalleCategoria As XmlNode In categoria
                Select Case detalleCategoria.Name
                    Case "descripcion"
                        categ.P_descripcion = CStr(detalleCategoria.InnerText)
                End Select
            Next
            Me.P_categorias.Add(categ)
        Next
    End Sub

    Public Sub Cargar_Articulos_Categoria(index As Byte)
        categ = Me.P_categorias.Item(index)
        Dim patch As String = "XML\ARTICULOS\" + categ.P_nombre + ".xml"
        Console.WriteLine(patch)
        'CARGA DESDE CATEGORIAS.XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(patch)
        Dim lista_articulo As XmlNodeList = xmlDoc.GetElementsByTagName("articulo")
        For Each articulo As XmlNode In lista_articulo
            Dim artic As Articulo = New Articulo
            For Each detalleArticulo As XmlNode In articulo
                Select Case detalleArticulo.Name
                    Case "codigo"
                        artic.P_codigo = CStr(detalleArticulo.InnerText)
                    Case "nombre"
                        artic.P_nombre = CStr(detalleArticulo.InnerText)
                    Case "precio"
                        artic.P_precio = CDbl(detalleArticulo.InnerText)
                    Case "pagoIva"
                        artic.P_pagoIva = CStr(detalleArticulo.InnerText)
                End Select
            Next
            Me.categ.P_articulos.Add(artic)
        Next
        'categ.Listar_Articulos()
        Me.P_categorias.Item(index) = categ
    End Sub

    Public Function Menu_Principal() As Byte
        Dim opc As Byte = 99
        Do While opc < 0 Or opc > 1
            Console.WriteLine("SELECCIONE UNA ACCION")
            Console.WriteLine("1.- LOGIN")
            Console.WriteLine("0.- SALIR")
            Try
                opc = Console.ReadLine()
            Catch ex As Exception
                opc = 0
            End Try
        Loop
        Return opc
    End Function

    Public Function login() As Usuario
        Dim user As String = ""
        Dim pass As String = ""
        Console.Write("USUARIO : ")
        user = Console.ReadLine()
        Console.Write("PASSWORD: ")
        pass = Console.ReadLine()
        Dim patch As String = "XML\CONFIGURACION\Usuarios.xml"
        'CARGA DESDE USUARIOS.XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(patch)
        Dim lista_usuarios As XmlNodeList = xmlDoc.GetElementsByTagName("usuario")
        For Each usuario As XmlNode In lista_usuarios
            If user = usuario.Attributes(0).Value And pass = usuario.Attributes(1).Value Then
                Me.usuario = New Usuario()
                Me.usuario.P_user = usuario.Attributes(0).Value
                Me.usuario.P_password = usuario.Attributes(1).Value
                For Each datoUsuario As XmlNode In usuario
                    Select Case datoUsuario.Name
                        Case "nombre"
                            Me.usuario.P_nombre = CStr(datoUsuario.InnerText)
                        Case "tipo"
                            Me.usuario.P_tipo = CStr(datoUsuario.InnerText)
                    End Select
                Next
                MsgBox("LOGIN CORRECTO")
                Return Me.P_usuario()
            End If
        Next
        MsgBox("USUARIO o CONTRASEÑA INCORRECTO")
        Return Me.usuario
    End Function

    Public Sub New()
        Do While Me.P_usuario Is Nothing
            Dim opc As Byte = 0
            opc = Menu_Principal()
            Select opc
                Case 1
                    While Me.P_usuario Is Nothing
                        Me.P_usuario = login()
                    End While
                    If Me.P_usuario.P_tipo = "ADMINISTRADOR" Then
                        Administrar()
                    Else
                        Facturar()
                    End If
                Case 0
                    Console.WriteLine("GRACIAS X SU VISITA")
                    Exit Do
            End Select
        Loop

    End Sub

    Public Function Administrar() As Byte
        Dim opc As Byte = 0
        'MsgBox("en administrar")
        While Not (Me.P_usuario Is Nothing)
            opc = Menu_Administrador()
            Select Case opc
                Case 1
                    Listar_Productos()
                Case 0
                    Me.P_usuario = Nothing
            End Select
        End While
        Return opc
    End Function

    Public Function Menu_Administrador() As Byte
        Dim opc As Byte = 99
        Do While opc < 0 Or opc > 1
            Console.WriteLine("SELECCIONE UNA ACCION")
            Console.WriteLine("1.- LISTAR PRODUCTOS X CATEGORIA")
            Console.WriteLine("0.- CERRAR SESION")
            Try
                opc = Console.ReadLine()
            Catch ex As Exception
                opc = 99
            End Try
        Loop
        Return opc
    End Function

    Public Function Facturar() As Byte
        Dim opc As Byte = 0
        'MsgBox("en administrar")
        While Not (Me.P_usuario Is Nothing)
            opc = Menu_Vendedor()
            Select Case opc
                Case 1
                    Dim factura As Factura = New Factura()
                    Cargar_Categorias()
                    factura.Agregar_Detalles(Me.P_categorias)
                    'factura.Visualizar()
                Case 0
                    Me.P_usuario = Nothing
            End Select
        End While
        Return opc
    End Function

    Public Function Menu_Vendedor() As Byte
        Dim opc As Byte = 99
        Do While opc < 0 Or opc > 1
            Console.WriteLine("SELECCIONE UNA ACCION")
            Console.WriteLine("1.- FACTURAR")
            Console.WriteLine("0.- CERRAR SESION")
            Try
                opc = Console.ReadLine()
            Catch ex As Exception
                opc = 99
            End Try
        Loop
        Return opc
    End Function
End Class
