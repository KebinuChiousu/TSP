Imports System.Data
Imports System.Data.OleDb

Module modOleDb

    Function ConnStr() As String

        Dim ret As String
        Dim path As String

        path = My.Application.Info.DirectoryPath & "\"

        ret = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
              "Data Source=" & path & "TSP.mdb"

        Return ret

    End Function

    Function GetPriceData( _
                           ByVal Ticker_Dt As Date _
                         ) As DataTable

        Dim OleDA As New OleDbDataAdapter
        Dim OleConn As New OleDbConnection
        Dim OleSelect As New OleDbCommand
        Dim OleParam As New OleDbParameter

        Dim dt As New DataTable
        Dim sql As String

        sql = "SELECT * " & _
              "FROM TSP_Price_Data " & _
              "WHERE Ticker_Dt >= ?;"

        OleConn.ConnectionString = ConnStr()

        OleSelect.CommandType = CommandType.Text
        OleSelect.CommandText = sql
        OleSelect.Connection = OleConn

        OleParam.DbType = DbType.DateTime
        OleParam.OleDbType = OleDbType.Date
        OleParam.Value = Ticker_Dt

        OleSelect.Parameters.Add(OleParam)

        OleDA.SelectCommand = OleSelect

        OleDA.Fill(dt)

        OleDA.Dispose()
        OleSelect.Dispose()
        OleConn.Dispose()

        Return dt

    End Function

    Enum ScaleValue
        MinValue = 0
        MinDate = 1
        MaxValue = 2
        MaxDate = 3
    End Enum

    Enum TickerType
        IndexFund = 0
        MutualFund = 1
    End Enum

    Function GetValue( _
                       ByVal mode As ScaleValue, _
                       ByVal type As TickerType, _
                       ByVal dte As Date _
                     ) As String

        Dim OleDA As New OleDbDataAdapter
        Dim OleConn As New OleDbConnection
        Dim OleSelect As New OleDbCommand
        Dim OleParam As New OleDbParameter

        Dim dt As New DataTable
        Dim sql As String = String.Empty
        Dim ret As Object


        Select Case mode
            Case ScaleValue.MinDate
                sql = "SELECT Max(Ticker_Dt) AS Ticker_Dt " & _
                      "FROM TSP_Data "
            Case ScaleValue.MinValue
                sql = "SELECT Min(Price) as Price " & _
                      "FROM TSP_Data "
            Case ScaleValue.MaxDate
                sql = "SELECT Max(Ticker_Dt) AS Ticker_Dt " & _
                      "FROM TSP_Data "
            Case ScaleValue.MaxValue
                sql = "SELECT Max(Price) as Price " & _
                      "FROM TSP_Data "
        End Select

        sql += "WHERE Ticker_Dt >= ? "

        Select Case type
            Case TickerType.IndexFund
                sql += "AND Ticker Not Like '%L%';"
            Case TickerType.MutualFund
                sql += "AND Ticker Like '%L%' "
                sql += "AND Price > 0;"
        End Select

        OleConn.ConnectionString = ConnStr()

        OleSelect.CommandType = CommandType.Text
        OleSelect.CommandText = sql
        OleSelect.Connection = OleConn

        OleParam.DbType = DbType.DateTime
        OleParam.OleDbType = OleDbType.Date
        OleParam.Value = dte

        OleSelect.Parameters.Add(OleParam)

        OleDA.SelectCommand = OleSelect

        OleDA.Fill(dt)

        OleDA.Dispose()
        OleSelect.Dispose()
        OleConn.Dispose()

        ret = dt.Rows(0).Item(0).ToString()

        dt = Nothing

        Return ret

    End Function


End Module
