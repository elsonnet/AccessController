Public Class Security
    Public Shared Function getHashOf(ByVal value As String) As String
        Dim result As String = ""
        Dim bytes As Byte()
        Dim hash As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
        bytes = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value))

        Dim i, icount As Integer
        icount = bytes.Length
        For i = 0 To icount - 1
            result += Hex(bytes(i)).ToString
        Next

        Return result
    End Function
End Class
