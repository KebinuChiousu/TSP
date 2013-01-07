Imports System
Imports System.IO.File
Imports System.IO
Imports System.Text
Imports System.Net

Module FileManipulation

    Public wsk As New Collection
    Public txtResponse As String
    Public blnConnected As Boolean

    Public Sub WriteFile(ByVal file As String, ByVal data As String)
        Dim path As String = file
        Dim fs As FileStream

        ' Delete the file if it exists.
        If Exists(path) = False Then
            ' Create the file.
            fs = Create(path)
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(data)

            ' Add some information to the file.
            fs.Write(info, 0, info.Length)
            fs.Close()
        End If
    End Sub

    '    Function DownloadPage(ByVal URL As String) As String

    'Retry:
    '        Try
    '            Dim sResult As String
    '            Dim oHttp As HttpWebRequest = System.Net.HttpWebRequest.Create(URL)
    '            Dim objResponse As HttpWebResponse

    '            oHttp.UserAgent = "Mozilla/5.0 " & _
    '                              "(Windows; U; Windows NT 5.1; en-US; rv:1.8.1.5) " & _
    '                              "Gecko/20070713 Firefox/2.0.0.5"

    '            oHttp.Method = "GET"
    '            oHttp.Timeout = 360000
    '            objResponse = oHttp.GetResponse

    '            Dim sr As StreamReader
    '            sr = New StreamReader( _
    '                                   objResponse.GetResponseStream(), _
    '                                   System.Text.Encoding.UTF8 _
    '                                 )


    '            sResult = sr.ReadToEnd()
    '            ' Close and clean up the StreamReader
    '            sr.Close()

    '            Return sResult
    '        Catch ex As System.Exception
    '            Select Case ex.Message
    '                Case "The remote server returned an error: (404) Not Found."
    '                    Return ""
    '                Case "The remote server returned an error: (500) Internal Server Error."
    '                    GoTo retry
    '                Case "The underlying connection was closed: The server committed an HTTP protocol violation."
    '                    GoTo retry
    '                Case Else
    '                    Throw New System.Exception(ex.Message, ex)
    '            End Select
    '        End Try

    '    End Function

End Module
