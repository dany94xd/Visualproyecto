Public Class Cajero
    Public Function Menu() As Byte
        Dim opc As Byte = 0
        Do While opc < 1 Or opc > 2
            Console.WriteLine("SELECCIONE UNA ACCION")
            Console.WriteLine("1.- ELABORAR UNA VENTA")
            Console.WriteLine("2.- SALIR")
            Try
                opc = Console.ReadLine()
            Catch ex As Exception
                opc = 0
            End Try
        Loop
        Return opc
    End Function

End Class
