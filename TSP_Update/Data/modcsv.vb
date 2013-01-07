Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.OleDb

Public Module modCSV

    Public Function CSV2DataTable( _
                                   ByVal filename As String, _
                                   Optional ByVal header As Boolean = True _
                                 ) As DataTable

        Dim da As OleDbDataAdapter
        Dim connstr As String
        Dim sql As String
        Dim dt As New DataTable
        Dim fi As FileInfo
        Dim path As String

        fi = New FileInfo(filename)

        filename = fi.Name

        path = fi.DirectoryName

        sql = "SELECT * FROM " & filename

        If header Then '
            connstr = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                      "Data Source=" & path & ";" & _
                      "Extended Properties=""text;HDR=YES;FMT=Delimited"""
        Else
            connstr = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                      "Data Source=" & path & ";" & _
                      "Extended Properties=""text;HDR=NO;FMT=Delimited"""
        End If

        da = New OleDbDataAdapter(sql, connstr)
        da.AcceptChangesDuringFill = False
        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function

    Sub DataTable2CSV( _
                       ByVal table As DataTable, _
                       ByVal filename As String, _
                       ByVal sepChar As String _
                     )

        Dim value As Object

        Dim writer As System.IO.StreamWriter = Nothing

        Try
            File.Delete(filename)
        Finally

            Try
                writer = New System.IO.StreamWriter(filename)

                ' first write a line with the columns name
                Dim sep As String = ""
                Dim builder As New System.Text.StringBuilder
                For Each col As DataColumn In table.Columns
                    builder.Append(sep).Append(col.ColumnName)
                    sep = sepChar
                Next
                writer.WriteLine(builder.ToString())

                ' then write all the rows
                For Each row As DataRow In table.Rows
                    sep = ""
                    builder = New System.Text.StringBuilder

                    For Each col As DataColumn In table.Columns

                        If col.DataType Is GetType(System.DateTime) Then
                            value = CDate(row(col.ColumnName)).ToShortDateString
                        Else
                            value = row(col.ColumnName)
                        End If

                        builder.Append(sep).Append(value)
                        sep = sepChar
                    Next
                    writer.WriteLine(builder.ToString())
                Next
            Finally
                If Not writer Is Nothing Then writer.Close()
            End Try

        End Try

    End Sub


End Module
