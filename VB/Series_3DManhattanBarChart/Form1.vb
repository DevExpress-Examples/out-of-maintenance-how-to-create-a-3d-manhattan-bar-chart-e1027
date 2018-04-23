Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace Series_3DManhattanBarChart
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' Create a new chart.
            Dim ManhattanBarChart As New ChartControl()

            ' Add a bar series to it.
            Dim series1 As New Series("Series 1", ViewType.ManhattanBar)
            Dim series2 As New Series("Series 2", ViewType.ManhattanBar)

            ' Add points to the series.
            series1.Points.Add(New SeriesPoint("A", 10))
            series1.Points.Add(New SeriesPoint("B", 12))
            series1.Points.Add(New SeriesPoint("C", 14))
            series1.Points.Add(New SeriesPoint("D", 17))
            series2.Points.Add(New SeriesPoint("A", 5))
            series2.Points.Add(New SeriesPoint("B", 4))
            series2.Points.Add(New SeriesPoint("C", 10))
            series2.Points.Add(New SeriesPoint("D", 12))

            ' Add both series to the chart.
            ManhattanBarChart.Series.AddRange(New Series() {series1, series2})

            ' Access labels of the first series.
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
            CType(series1.Label, BarSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default

            ' Access the series options.
            series1.Label.PointOptions.PointView = PointView.ArgumentAndValues

            ' Customize the view-type-specific properties of the series.
            Dim myView As Bar3DSeriesView = CType(series2.View, Bar3DSeriesView)
            myView.BarDepthAuto = False
            myView.BarDepth = 1
            myView.Transparency = 80
            myView.ShowFacet = False
            myView.Model = Bar3DModel.Cylinder

            ' Access the diagram's options.
            CType(ManhattanBarChart.Diagram, XYDiagram3D).ZoomPercent = 110

            ' Add a title to the chart and hide the legend.
            Dim chartTitle1 As New ChartTitle()
            chartTitle1.Text = "Manhattan Bar Chart"
            ManhattanBarChart.Titles.Add(chartTitle1)
            ManhattanBarChart.Legend.Visible = False

            ' Add the chart to the form.
            ManhattanBarChart.Dock = DockStyle.Fill
            Me.Controls.Add(ManhattanBarChart)
        End Sub

    End Class
End Namespace