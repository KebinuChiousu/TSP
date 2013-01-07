Imports System.Data
Imports System.Data.OleDb

Module modOleDB

    Function GetLastUpdate() As Date

        Dim lastupdate As Date

        Dim path As String = My.Application.Info.DirectoryPath & "\"

        Dim OleDA As New OleDbDataAdapter
        Dim OleConn As New OleDbConnection
        Dim OleSelect As New OleDbCommand

        Dim sql As String = ""

        OleConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                                   "Data Source=" & path & "TSP.mdb"

        sql = "SELECT DISTINCT Ticker_Dt " & _
              "FROM TSP_Data " & _
              "ORDER BY Ticker_Dt DESC"

        OleSelect.CommandType = CommandType.Text
        OleSelect.CommandText = sql
        OleSelect.Connection = OleConn

        OleDA.SelectCommand = OleSelect

        Dim ds As New DataSet
        Dim dt As New DataTable

        ds.EnforceConstraints = False
        ds.Tables.Clear()
        ds.Tables.Add(dt)

        OleDA.Fill(dt)

        Try
            lastupdate = dt.Rows(0).Item("Ticker_Dt")
        Catch
            lastupdate = CDate("12/31/2002")
        End Try

        Return lastupdate

    End Function

    Function UpdateTickerData(ByVal dt As DataTable) As Integer

        Dim path As String = My.Application.Info.DirectoryPath & "\"
        Dim m_conn As New OleDbConnection

        m_conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                                  "Data Source=" & path & "TSP.mdb"

        Dim tran As OleDbTransaction
        Dim da As New OleDbDataAdapter
        Dim build As OleDbCommandBuilder
        Dim sql As String = "SELECT * FROM TSP_Data"

        Dim ret As Integer

        m_conn.Open()

        da = New OleDbDataAdapter(sql, m_conn)
        build = New OleDbCommandBuilder(da)
        da.InsertCommand = build.GetInsertCommand

        tran = m_conn.BeginTransaction()

        da.InsertCommand.Transaction = tran

        ret = da.Update(dt)

        tran.Commit()
        tran.Dispose()

        da.Dispose()
        m_conn.Close()
        m_conn.Dispose()

        Return ret

    End Function

End Module
