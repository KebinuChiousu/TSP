<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.rbIndex = New System.Windows.Forms.RadioButton
        Me.rbMutual = New System.Windows.Forms.RadioButton
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.NumTimeSpan = New System.Windows.Forms.NumericUpDown
        Me.cmbTimeSpan = New System.Windows.Forms.ComboBox
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.TabControl = New System.Windows.Forms.TabControl
        Me.TabChart = New System.Windows.Forms.TabPage
        Me.ZGC = New ZedGraph.ZedGraphControl
        Me.TabData = New System.Windows.Forms.TabPage
        Me.dgvZGC = New System.Windows.Forms.DataGridView
        CType(Me.NumTimeSpan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabChart.SuspendLayout()
        Me.TabData.SuspendLayout()
        CType(Me.dgvZGC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbIndex
        '
        Me.rbIndex.AutoSize = True
        Me.rbIndex.Checked = True
        Me.rbIndex.Location = New System.Drawing.Point(10, 10)
        Me.rbIndex.Name = "rbIndex"
        Me.rbIndex.Size = New System.Drawing.Size(83, 17)
        Me.rbIndex.TabIndex = 1
        Me.rbIndex.TabStop = True
        Me.rbIndex.Text = "Index Funds"
        Me.rbIndex.UseVisualStyleBackColor = True
        '
        'rbMutual
        '
        Me.rbMutual.AutoSize = True
        Me.rbMutual.Location = New System.Drawing.Point(95, 10)
        Me.rbMutual.Name = "rbMutual"
        Me.rbMutual.Size = New System.Drawing.Size(89, 17)
        Me.rbMutual.TabIndex = 2
        Me.rbMutual.Text = "Mutual Funds"
        Me.rbMutual.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(382, 10)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'NumTimeSpan
        '
        Me.NumTimeSpan.Location = New System.Drawing.Point(244, 10)
        Me.NumTimeSpan.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumTimeSpan.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumTimeSpan.Name = "NumTimeSpan"
        Me.NumTimeSpan.Size = New System.Drawing.Size(57, 20)
        Me.NumTimeSpan.TabIndex = 4
        Me.NumTimeSpan.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmbTimeSpan
        '
        Me.cmbTimeSpan.FormattingEnabled = True
        Me.cmbTimeSpan.Items.AddRange(New Object() {"Year(s)", "Month(s)", "Week(s)"})
        Me.cmbTimeSpan.Location = New System.Drawing.Point(307, 10)
        Me.cmbTimeSpan.Name = "cmbTimeSpan"
        Me.cmbTimeSpan.Size = New System.Drawing.Size(69, 21)
        Me.cmbTimeSpan.TabIndex = 5
        Me.cmbTimeSpan.Text = "Year(s)"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 288)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(469, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabChart)
        Me.TabControl.Controls.Add(Me.TabData)
        Me.TabControl.Location = New System.Drawing.Point(10, 46)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(447, 239)
        Me.TabControl.TabIndex = 7
        '
        'TabChart
        '
        Me.TabChart.Controls.Add(Me.ZGC)
        Me.TabChart.Location = New System.Drawing.Point(4, 22)
        Me.TabChart.Name = "TabChart"
        Me.TabChart.Padding = New System.Windows.Forms.Padding(3)
        Me.TabChart.Size = New System.Drawing.Size(439, 213)
        Me.TabChart.TabIndex = 0
        Me.TabChart.Text = "Chart"
        Me.TabChart.UseVisualStyleBackColor = True
        '
        'ZGC
        '
        Me.ZGC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ZGC.Location = New System.Drawing.Point(3, 3)
        Me.ZGC.Name = "ZGC"
        Me.ZGC.ScrollGrace = 0
        Me.ZGC.ScrollMaxX = 0
        Me.ZGC.ScrollMaxY = 0
        Me.ZGC.ScrollMaxY2 = 0
        Me.ZGC.ScrollMinX = 0
        Me.ZGC.ScrollMinY = 0
        Me.ZGC.ScrollMinY2 = 0
        Me.ZGC.Size = New System.Drawing.Size(433, 207)
        Me.ZGC.TabIndex = 1
        '
        'TabData
        '
        Me.TabData.Controls.Add(Me.dgvZGC)
        Me.TabData.Location = New System.Drawing.Point(4, 22)
        Me.TabData.Name = "TabData"
        Me.TabData.Padding = New System.Windows.Forms.Padding(3)
        Me.TabData.Size = New System.Drawing.Size(439, 213)
        Me.TabData.TabIndex = 1
        Me.TabData.Text = "Data"
        Me.TabData.UseVisualStyleBackColor = True
        '
        'dgvZGC
        '
        Me.dgvZGC.AllowUserToAddRows = False
        Me.dgvZGC.AllowUserToDeleteRows = False
        Me.dgvZGC.AllowUserToResizeColumns = False
        Me.dgvZGC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvZGC.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvZGC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvZGC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvZGC.Location = New System.Drawing.Point(3, 3)
        Me.dgvZGC.Name = "dgvZGC"
        Me.dgvZGC.ReadOnly = True
        Me.dgvZGC.Size = New System.Drawing.Size(433, 207)
        Me.dgvZGC.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 310)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.cmbTimeSpan)
        Me.Controls.Add(Me.NumTimeSpan)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.rbMutual)
        Me.Controls.Add(Me.rbIndex)
        Me.MinimumSize = New System.Drawing.Size(477, 344)
        Me.Name = "frmMain"
        Me.Text = "Thrift Savings Plan"
        CType(Me.NumTimeSpan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabChart.ResumeLayout(False)
        Me.TabData.ResumeLayout(False)
        CType(Me.dgvZGC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbIndex As System.Windows.Forms.RadioButton
    Friend WithEvents rbMutual As System.Windows.Forms.RadioButton
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents NumTimeSpan As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbTimeSpan As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabChart As System.Windows.Forms.TabPage
    Friend WithEvents ZGC As ZedGraph.ZedGraphControl
    Friend WithEvents TabData As System.Windows.Forms.TabPage
    Friend WithEvents dgvZGC As System.Windows.Forms.DataGridView
End Class
