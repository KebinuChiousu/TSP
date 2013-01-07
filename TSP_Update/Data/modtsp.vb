Imports System.Data

Module modTSP

    Function TransformData(ByVal source As DataTable) As DataTable

        Dim dest As DataTable
        Dim values As String

        Dim row_idx As Integer
        Dim col_idx As Integer
        Dim price As Object

        Dim colname As String

        dest = New DataTable
        dest.Columns.Add("Ticker", GetType(String))
        dest.Columns.Add("Ticker_Dt", GetType(Date))
        dest.Columns.Add("Price", GetType(Decimal))


        For row_idx = 0 To (source.Rows.Count - 1)

            For col_idx = 1 To source.Columns.Count - 1

                colname = source.Columns(col_idx).ColumnName
                If colname.Length = 1 Then
                    colname = "TSP" & colname & "F"
                Else
                    If InStr(colname, "Income") > 0 Then
                        colname = "TSPLIF"
                    Else
                        colname = Left(colname, 1) & Right(colname, 4)
                        colname = "TSP" & colname & "F"
                    End If
                End If

                values = colname
                values += ","
                values += CDate(source.Rows(row_idx).Item(0).ToString)
                values += ","

                price = source.Rows(row_idx).Item(col_idx).ToString
                If price = "" Then
                    price = 0
                Else
                    price = CStr(CDec(price))
                End If

                values += CStr(price)

                dest.Rows.Add(Split(values, ","))

            Next

        Next


        Return dest

    End Function

End Module
