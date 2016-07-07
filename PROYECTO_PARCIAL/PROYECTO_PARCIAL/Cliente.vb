Imports System.Xml

Public Class Cliente
    Private idCliente As Integer
    Private numeroDocumento As String
    Private nombre As String
    Private telefono As String
    Private direccion As String
    Private email As String

    Public Property P_idCliente() As Integer
        Get
            Return Me.idCliente
        End Get
        Set(ByVal value As Integer)
            Me.idCliente = value
        End Set
    End Property

    Public Property P_numeroDocumento() As String
        Get
            Return Me.numeroDocumento
        End Get
        Set(ByVal value As String)
            Me.numeroDocumento = value
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

    'Public Sub New()
    '    Me.P_idCliente = 0
    '    Me.P_numeroDocumento = ""
    '    Me.P_nombre = ""
    '    Me.P_telefono = ""
    '    Me.P_direccion = ""
    '    Me.P_email = ""
    'End Sub

    Public Sub New()
        Me.P_idCliente = 0
        Console.WriteLine("INGRESE LOS DATOS DE CLIENTE")
        Console.Write("CI o RUC :")
        Me.P_numeroDocumento = Console.ReadLine
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
        Console.WriteLine("CI / RUC : " & Me.P_numeroDocumento & vbTab & vbTab & vbTab & vbTab & "TELEFONO: " & Me.P_telefono)
        Console.WriteLine("DIRECCION: " & Me.P_direccion & vbNewLine)
    End Sub

    Public Sub New(idCliente As Integer)
        Dim patch As String = "XML\CONFIGURACION\Clientes.xml"
        'CARGA DESDE CLIENTES.XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(patch)
        Dim lista_clientes As XmlNodeList = xmlDoc.GetElementsByTagName("cliente")
        For Each cliente As XmlNode In lista_clientes
            If idCliente = cliente.Attributes(0).Value Then
                Me.P_idCliente = cliente.Attributes(0).Value
                For Each datoCliente As XmlNode In cliente
                    Select Case datoCliente.Name
                        Case "numeroDocumento"
                            Me.P_numeroDocumento = CStr(datoCliente.InnerText)
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
End Class
