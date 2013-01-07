Imports System
Imports System.Text
Imports System.IO
Imports System.Web
Imports System.Web.HttpUtility
Imports System.Net
Imports System.Collections.Specialized

Public Class WebRequest

    Public Enum Method
        [GET] = 0
        POST = 1
    End Enum

    Private m_url As String = String.Empty
    Private m_values As NameValueCollection = New NameValueCollection()
    Private m_type As Method = Method.GET

    Sub New()
    End Sub

    ''' <summary>
    ''' URL for the Web Request.
    ''' </summary>
    ''' <param name="URL">Action URL for the Form</param>
    ''' <remarks></remarks>
    Sub New(ByVal URL As String)

        m_url = URL

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value>Action URL for the Form</value>
    ''' <returns>Action URL for the Form</returns>
    ''' <remarks></remarks>
    Property Url() As String

        Get
            Return m_url
        End Get

        Set(ByVal value As String)
            m_url = value
        End Set

    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value>Collection of Form Parameters</value>
    ''' <returns>Collection of Form Parameters</returns>
    ''' <remarks></remarks>
    Property FormItems() As NameValueCollection

        Get
            Return m_values
        End Get

        Set(ByVal value As NameValueCollection)
            m_values = value
        End Set

    End Property

    Property Type() As Method
        Get
            Return m_type
        End Get
        Set(ByVal value As Method)
            m_type = value
        End Set
    End Property

    ''' <summary>
    ''' Submits the Form Request to the form URL.
    ''' </summary>
    ''' <returns>Returns the Form Response</returns>
    ''' <remarks></remarks>
    Function Submit() As String

        Dim idx As Integer
        Dim parameters As StringBuilder = Nothing
        Dim result As String = String.Empty

        For idx = 0 To (m_values.Count - 1)
            EncodeAndAddItem( _
                              parameters, _
                              m_values.GetKey(idx), _
                              m_values(idx) _
                            )
        Next


        result = SubmitData( _
                             m_url, _
                             parameters.ToString _
                           )

        Return result

    End Function

    Private Function SubmitData( _
                                 ByVal URL As String, _
                                 ByVal postData As String _
                               )

        Dim request As HttpWebRequest = Nothing
        Dim uri As Uri = Nothing
        Dim result As String = String.Empty

        Try

            Select Case m_type
                Case Method.POST

                    uri = New Uri(URL)
                    request = HttpWebRequest.Create(uri)
                    request.Method = "POST"
                    request.ContentType = "application/x-www-form-urlencoded"
                    request.ContentLength = postData.Length

                    Using WriteStream As Stream = request.GetRequestStream

                        Dim encoding As UTF8Encoding = New UTF8Encoding
                        Dim bytes As Byte() = encoding.GetBytes(postData)

                        WriteStream.Write(bytes, 0, bytes.Length)

                    End Using

                Case Method.GET

                    uri = New Uri(m_url & "?" & postData)
                    request = HttpWebRequest.Create(uri)
                    request.Method = "GET"

            End Select

            Using response As HttpWebResponse = request.GetResponse
                Using responseStream As Stream = response.GetResponseStream
                    Using readStream As StreamReader = New StreamReader(responseStream, Encoding.UTF8)
                        result = readStream.ReadToEnd
                    End Using
                End Using
            End Using

        Catch ex As Exception
            el.WriteToErrorLog( _
                                ex.Message, _
                                ex.StackTrace, _
                                My.Application.Info.AssemblyName _
                              )
            Return result
        End Try

        Return result

    End Function

    Private Sub EncodeAndAddItem( _
                                  ByRef baseRequest As StringBuilder, _
                                  ByVal key As String, _
                                  ByVal value As String _
                                )

        If IsNothing(baseRequest) Then
            baseRequest = New StringBuilder()
        End If

        If baseRequest.Length > 0 Then
            baseRequest.Append("&")
        End If

        baseRequest.Append(key)
        baseRequest.Append("=")
        baseRequest.Append(HttpUtility.UrlEncode(value))

    End Sub


End Class
