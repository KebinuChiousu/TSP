Imports System.Diagnostics
Imports System.IO
Imports System.text

Module modFile

    Function ReadFile(ByVal filename As String) As String

        Dim temp As String = ""

        Dim sr As System.IO.StreamReader
        sr = New System.IO.StreamReader(filename)

        While Not sr.EndOfStream

            temp += sr.ReadLine() & "|"

        End While

        sr.Close()
        sr = Nothing

        Return temp

    End Function

    Sub GenerateFile(ByVal data As String, ByVal filename As String)

        Dim ecp1252 As Encoding = Encoding.GetEncoding(1252)
        Dim sr As StreamReader
        sr = New StreamReader(StringToStream(data))
        Dim sw As StreamWriter
        sw = New StreamWriter( _
                               filename, _
                               False, _
                               ecp1252 _
                             )

        sw.Write(sr.ReadToEnd)
        sr.Close()
        sw.Close()
        sr = Nothing
        sw = Nothing

    End Sub

    Function StringToStream(ByVal data As String) As Stream

        Dim bytes As Byte() = Nothing
        Dim ms As MemoryStream

        Try
            bytes = System.Text.Encoding.UTF8.GetBytes(data)
        Catch
            ReDim bytes(0)
        Finally
            ms = New MemoryStream(bytes)
        End Try

        Return CType(ms, Stream)

    End Function

    Sub OpenFile(ByVal Filename As String)

        Dim desktop As String
        desktop = Environment. _
                  GetFolderPath( _
                                 Environment. _
                                 SpecialFolder. _
                                 Desktop _
                               ) _
                  & "\"

        Dim psi As New ProcessStartInfo()
        psi.UseShellExecute = True
        psi.FileName = desktop & Filename
        Process.Start(psi)

    End Sub

    Sub ShowStatus(ByVal msg As String)
        Console.WriteLine(msg)
    End Sub

End Module
