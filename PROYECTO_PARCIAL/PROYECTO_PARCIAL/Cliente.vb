Imports System.Xml

Public Class Cliente
    Private identificacion As String
    Private nombre As String
    Private telefono As String
    Private direccion As String
    Private email As String

    Public Property P_identificacion() As String
        Get
            Return Me.identificacion
        End Get
        Set(ByVal value As String)
            Me.identificacion = value
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

    Public Property P_telefono() As String
        Get
            Return Me.telefono
        End Get
        Set(ByVal value As String)
            Me.telefono = value
        End Set
    End Property

    Public Property P_direccion() As String
        Get
            Return Me.direccion
        End Get
        Set(ByVal value As String)
            Me.direccion = value
        End Set
    End Property

    Public Property P_email() As String
        Get
            Return Me.email
        End Get
        Set(ByVal value As String)
            Me.email = value
        End Set
    End Property

    Public Sub New()
        Me.P_identificacion = ""
        Me.P_nombre = ""
        Me.P_telefono = ""
        Me.P_direccion = ""
        Me.P_email = ""
    End Sub

    Public Sub New(identificacion As String)
        Me.P_identificacion = identificacion
        Console.WriteLine("INGRESE LOS DATOS DE CLIENTE")
        Console.Write("NOMBRE   :")
        Me.P_nombre = Console.ReadLine
        Console.Write("TELEFONO :")
        Me.P_telefono = Console.ReadLine
        Console.Write("DIRECCION:")
        Me.P_direccion = Console.ReadLine
        Console.Write("EMAIL    :")
        Me.P_email = Console.ReadLine
    End Sub

    Public Sub Mostrar_Datos()
        Console.WriteLine("CLIENTE  : " & Me.P_nombre)
        Console.WriteLine("CI / RUC : " & Me.P_identificacion & vbTab & vbTab & vbTab & vbTab & "TELEFONO: " & Me.P_telefono)
        Console.WriteLine("DIRECCION: " & Me.P_direccion & vbNewLine)
    End Sub

    Public Sub Cargar(identificacion As String)
        Dim patch As String = "XML\CONFIGURACION\Clientes.xml"
        'CARGA DESDE CLIENTES.XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(patch)
        Dim lista_clientes As XmlNodeList = xmlDoc.GetElementsByTagName("cliente")
        For Each cliente As XmlNode In lista_clientes
            If identificacion = cliente.Attributes(0).Value Then
                Me.P_identificacion = cliente.Attributes(0).Value
                For Each datoCliente As XmlNode In cliente
                    Select Case datoCliente.Name
                        Case "nombre"
                            Me.P_nombre = CStr(datoCliente.InnerText)
                        Case "telefono"
                            Me.P_telefono = CStr(datoCliente.InnerText)
                        Case "direccion"
                            Me.P_direccion = CStr(datoCliente.InnerText)
                        Case "email"
                            Me.P_email = CStr(datoCliente.InnerText)
                    End Select
                Next
                MsgBox("carga de Cliente correcta")
            End If
        Next
    End Sub

    Public Sub Grabar_Cliente()
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load("XML\CONFIGURACION\Clientes.xml")
        Dim nodo As XmlElement
        Dim nodo_hijo As XmlNode
        Dim escriba As XmlNode
       
        escriba = xmlDoc.DocumentElement

        nodo = xmlDoc.CreateElement("cliente")
        nodo.SetAttribute("identificacion", "", Me.P_identificacion)
        'xmlDoc.AppendChild(nodo)
        nodo_hijo = xmlDoc.CreateElement("nombre")
        nodo_hijo.InnerText = Me.P_nombre
        nodo.AppendChild(nodo_hijo)
        nodo_hijo = xmlDoc.CreateElement("telefono")
        nodo_hijo.InnerText = Me.P_telefono
        nodo.AppendChild(nodo_hijo)
        nodo_hijo = xmlDoc.CreateElement("direccion")
        nodo_hijo.InnerText = Me.P_direccion
        nodo.AppendChild(nodo_hijo)
        nodo_hijo = xmlDoc.CreateElement("email")
        nodo_hijo.InnerText = Me.P_email
        nodo.AppendChild(nodo_hijo)

        escriba.AppendChild(nodo)

        xmlDoc.Save("XML\CONFIGURACION\Clientes.xml")

        'xmlDoc.Save("XML\CONFIGURACION\Clientesv2.xml")
        'MsgBox("Archivo generado con ÉXITO")
    End Sub
End Class
