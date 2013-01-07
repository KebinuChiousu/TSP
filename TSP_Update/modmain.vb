Imports System.IO
Imports ErrorsAndEvents
Imports System.Collections.Specialized

Module ModMain

    Public el As ErrorLogger
    Const ActionURL As String = "http://www.fedsmith.com/corners/tsp/" & _
                                "csv.dailyexport.db.php"

    Sub Main()

        el = New ErrorLogger

        Dim dte As String = Format(DateTime.Now, "yyyyMMdd")

        Dim dt As DataTable
        Dim filename As String = "TSP" & dte & ".csv"
        Dim upd_date As Date = GetLastUpdate()

        If Format(upd_date, "yyyyMMdd") = dte Then Exit Sub

        dt = DownloadData(upd_date, filename)

        If dt.Rows.Count > 0 Then
            UpdateTickerData(dt)
        End If


    End Sub

    Function DownloadData( _
                           ByVal upd_date As Date, _
                           ByVal filename As String _
                         ) As DataTable

        Dim Data As String = String.Empty
        Dim dte As Date = DateTime.Now
        Dim URL As String = ActionURL
        Dim post As WebRequest
        Dim dt As DataTable

        Dim tempfile As String

        Dim items As NameValueCollection
        Dim idx As Integer

        upd_date = upd_date.AddDays(1)

        post = New WebRequest(URL)

        post.FormItems.Add( _
                            "frommonth", _
                            CStr(upd_date.Month) _
                          )
        post.FormItems.Add( _
                            "fromday", _
                            CStr(upd_date.Day) _
                          )
        post.FormItems.Add( _
                            "fromyear", _
                            CStr(upd_date.Year) _
                          )

        post.FormItems.Add( _
                            "tomonth", _
                            CStr(dte.Month) _
                          )
        post.FormItems.Add( _
                            "today", _
                            CStr(dte.Day) _
                          )
        post.FormItems.Add( _
                            "toyear", _
                            CStr(dte.Year) _
                          )

        post.Type = WebRequest.Method.POST
        Data = post.Submit()

        Data = Replace(Data, vbTab, ",")



        tempfile = My.Application.Info.DirectoryPath & "\" & "temp.csv"
        filename = My.Application.Info.DirectoryPath & "\" & filename

        Try
            File.Delete(tempfile)
        Finally
            GenerateFile(Data, tempfile)
        End Try

        dt = CSV2DataTable(tempfile)

        Try
            File.Delete(tempfile)
        Finally
            dt = TransformData(dt)
        End Try

        If dt.Rows.Count = 0 Then

            items = post.FormItems
            Data = "Module: DownloadData" & vbCrLf
            Data += "URL=" & ActionURL & vbCrLf
            Data += "ActionMethod=" & post.Type.ToString & vbCrLf

            For idx = 0 To items.Count - 1

                Data += items.GetKey(idx)
                Data += "="
                Data += items(idx)
                Data += vbCrLf

            Next

            el.WriteToErrorLog("0 Records Returned", Data, "TSP_Update")

        Else
            Try
                File.Delete(filename)
            Finally
                DataTable2CSV(dt, filename, ",")
            End Try

        End If

        Return dt

    End Function

End Module
