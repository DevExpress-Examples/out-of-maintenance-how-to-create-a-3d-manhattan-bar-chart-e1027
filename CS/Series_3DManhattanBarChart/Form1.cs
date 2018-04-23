using System;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace Series_3DManhattanBarChart {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a new chart.
            ChartControl ManhattanBarChart = new ChartControl();

            // Add a bar series to it.
            Series series1 = new Series("Series 1", ViewType.ManhattanBar);
            Series series2 = new Series("Series 2", ViewType.ManhattanBar);

            // Add points to the series.
            series1.Points.Add(new SeriesPoint("A", 10));
            series1.Points.Add(new SeriesPoint("B", 12));
            series1.Points.Add(new SeriesPoint("C", 14));
            series1.Points.Add(new SeriesPoint("D", 17));
            series2.Points.Add(new SeriesPoint("A", 5));
            series2.Points.Add(new SeriesPoint("B", 4));
            series2.Points.Add(new SeriesPoint("C", 10));
            series2.Points.Add(new SeriesPoint("D", 12));

            // Add both series to the chart.
            ManhattanBarChart.Series.AddRange(new Series[] { series1, series2 });

            // Access labels of the first series.
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((BarSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the series options.
            series1.Label.TextPattern = "{A}: {V}";

            // Customize the view-type-specific properties of the series.
            Bar3DSeriesView myView = (Bar3DSeriesView)series2.View;
            myView.BarDepthAuto = false;
            myView.BarDepth = 1;
            myView.Transparency = 80;
            myView.ShowFacet = false;

            // Access the diagram's options.
            ((XYDiagram3D)ManhattanBarChart.Diagram).ZoomPercent = 110;

            // Add a title to the chart and hide the legend.
            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Manhattan Bar Chart";
            ManhattanBarChart.Titles.Add(chartTitle1);
            ManhattanBarChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Add the chart to the form.
            ManhattanBarChart.Dock = DockStyle.Fill;
            this.Controls.Add(ManhattanBarChart);
        }

    }
}