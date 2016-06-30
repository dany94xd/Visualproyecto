Public Class Administrador

    Public Function Menu() As Byte
        Dim opc As Byte = 0
        Do While opc <> 1
            Console.WriteLine("SELECCIONE UNA ACCION")
            Console.WriteLine("1.- LISTAR PRODUCTOS X CATEGORIA")
            Try
                opc = Console.ReadLine()
            Catch ex As Exception
                opc = 0
            End Try
        Loop
        Return opc
    End Function


End Class
