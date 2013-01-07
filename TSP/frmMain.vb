Imports ZedGraph

Public Class frmMain

    Public dtTSP As DataTable

    Private Sub frmMain_Load( _
                              ByVal sender As Object, _
                              ByVal e As System.EventArgs _
                            ) Handles Me.Load

        Me.Size = New Size(869, 700)

        cmbTimeSpan.SelectedIndex = 0

        With ZGC.GraphPane

            .Title.Text = "Thrift Savings Plan"
            .XAxis.Title.Text = "Date"
            .YAxis.Title.Text = "Fund Value ($)"

            .XAxis.Type = AxisType.DateAsOrdinal

        End With

        ZGC.PointDateFormat = "dd-MMM-yyyy"

        UpdateChart()

    End Sub

    Private Sub rbIndex_CheckedChanged( _
                                            ByVal sender As System.Object, _
                                            ByVal e As System.EventArgs _
                                          ) Handles rbIndex.CheckedChanged

        If cmbTimeSpan.SelectedIndex >= 0 Then
            UpdateChart()
        End If

    End Sub

    Private Sub btnRefresh_Click( _
                                  ByVal sender As System.Object, _
                                  ByVal e As System.EventArgs _
                                ) Handles btnRefresh.Click

        UpdateChart()

    End Sub

    Sub UpdateChart()

        Dim dte As Date
        Dim dsp() As DataSourcePointList
        Dim idx As Integer = 0
        Dim color_idx As Integer = 0
        Dim mode As Boolean = rbIndex.Checked
        Dim LFund As Boolean = False
        Dim mypane As GraphPane = ZGC.GraphPane
        Dim myCurve As LineItem = Nothing

        dte = CalculateDate()
        dtTSP = GetPriceData(dte)

        ReDim dsp(dtTSP.Columns.Count - 2)

        dgvZGC.DataSource = dtTSP
        dgvZGC.Refresh()

        mypane.CurveList.Clear()

        For idx = 0 To UBound(dsp)

            dsp(idx) = New DataSourcePointList
            dsp(idx).DataSource = dtTSP
            dsp(idx).XDataMember = dtTSP.Columns(0).ColumnName
            dsp(idx).YDataMember = dtTSP.Columns(idx + 1).ColumnName
            dsp(idx).ZDataMember = Nothing
            dsp(idx).TagDataMember = Nothing

            LFund = dtTSP.Columns(idx + 1).ColumnName.Contains("L")

            If mode Then

                If Not LFund Then
                    myCurve = mypane.AddCurve( _
                                               dtTSP.Columns(idx + 1).ColumnName, _
                                               dsp(idx), _
                                               GetLineColor(color_idx), _
                                               SymbolType.None _
                                             )
                    color_idx += 1
                    CType(dgvZGC.Columns(idx + 1), DataGridViewColumn).Visible = True
                Else
                    CType(dgvZGC.Columns(idx + 1), DataGridViewColumn).Visible = False
                End If

            Else

                If LFund Then
                    myCurve = mypane.AddCurve( _
                                               dtTSP.Columns(idx + 1).ColumnName, _
                                               dsp(idx), _
                                               GetLineColor(color_idx), _
                                               SymbolType.None _
                                             )
                    color_idx += 1
                    CType(dgvZGC.Columns(idx + 1), DataGridViewColumn).Visible = True
                Else
                    CType(dgvZGC.Columns(idx + 1), DataGridViewColumn).Visible = False
                End If

            End If

        Next

        ZGC.IsShowPointValues = False

        AdjustScale(dte)

        ZGC.AxisChange()

        ZGC.Refresh()

    End Sub

#Region "Utility Routines"

    Private Sub Form1_Resize( _
                              ByVal sender As System.Object, _
                              ByVal e As System.EventArgs _
                            ) Handles MyBase.Resize
        SetSize()
    End Sub

    Private Sub SetSize()

        TabControl.Location = New Point(10, 40)
        ' Leave a small margin around the outside of the control
        TabControl.Size = New Size( _
                             ClientRectangle.Width - 20, _
                             ClientRectangle.Height - StatusStrip.Height - 50 _
                           )

        btnRefresh.Location = New Point(ClientRectangle.Width - 10 - btnRefresh.Width, 10)
        cmbTimeSpan.Location = New Point(btnRefresh.Location.X - 10 - cmbTimeSpan.Width, 10)
        NumTimeSpan.Location = New Point(cmbTimeSpan.Location.X - 10 - NumTimeSpan.Width, 10)

    End Sub

    Function GetLineColor( _
                           ByVal color_idx As Integer _
                         ) As System.Drawing.Color

        Select Case color_idx
            Case 0
                Return Color.Red
            Case 1
                Return Color.Black
            Case 2
                Return Color.DarkOrange
            Case 3
                Return Color.Green
            Case 4
                Return Color.Blue
            Case Else
                Return RandomRGBColor()
        End Select

    End Function

    Function CalculateDate() As Date

        Dim dte As Date = DateTime.Now
        Dim value As Integer = NumTimeSpan.Value

        value = value * -1

        dte = CDate(dte.ToShortDateString)

        Select Case cmbTimeSpan.Text
            Case "Year(s)"
                dte = dte.AddYears(value)
            Case "Month(s)"
                dte = dte.AddMonths(value)
            Case "Week(s)"
                value = value * 7
                dte = dte.AddDays(value)
        End Select

        Return dte

    End Function

    Sub AdjustScale(ByVal dte As Date)

        Dim myPane As GraphPane = ZGC.GraphPane
        Dim XScale As Scale
        Dim YScale As Scale

        Dim MinValue As Double
        Dim MaxValue As Double

        If rbIndex.Checked Then
            MinValue = CDbl(GetValue(ScaleValue.MinValue, TickerType.IndexFund, dte))
            MaxValue = CDbl(GetValue(ScaleValue.MaxValue, TickerType.IndexFund, dte))
        Else

            MinValue = CDbl(GetValue(ScaleValue.MinValue, TickerType.MutualFund, dte))
            MaxValue = CDbl(GetValue(ScaleValue.MaxValue, TickerType.MutualFund, dte))
        End If

        XScale = myPane.XAxis.Scale
        YScale = myPane.YAxis.Scale

        YScale.MinAuto = False
        YScale.MaxAuto = False

        YScale.Min = Math.Truncate(MinValue)

        If MaxValue - Math.Truncate(MaxValue) > 0 Then
            YScale.Max = Math.Truncate(MaxValue) + 1
        Else
            YScale.Max = Math.Truncate(MaxValue)
        End If

    End Sub

#End Region
   
    Private Function ZGC_MouseMoveEvent( _
                                         ByVal sender As ZedGraph.ZedGraphControl, _
                                         ByVal e As System.Windows.Forms.MouseEventArgs _
                                       ) As Boolean _
                                         Handles ZGC.MouseMoveEvent




        Dim mousePt As New PointF(e.X, e.Y)
        Dim nearestCurve As CurveItem = Nothing
        Dim iNearest As Integer = 0
        Dim test As Boolean = False

        Dim Label As String
        Dim dte As Date
        Dim value As Double


        Dim pane As GraphPane = sender.MasterPane.FindChartRect(mousePt)

        If Not pane Is Nothing Then

            test = pane.FindNearestPoint(mousePt, nearestCurve, iNearest)

            If test Then
                Label = nearestCurve.Label.Text
                dte = Date.FromOADate(nearestCurve.Item(iNearest).X)
                value = nearestCurve.Item(iNearest).Y

                lblStatus.Text = Label & " - " & dte.ToShortDateString & " - " & value

            Else
                lblStatus.Text = String.Empty

            End If

        End If


        Return False

    End Function
    
End Class