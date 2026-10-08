using ChartBuilderApp.Products;

namespace ChartBuilderApp.Builders;

public sealed class PieChartBuilder : IChartBuilder
{
    private PieChart _chart = new();

    public void Reset()
    {
        _chart = new PieChart();
    }

    public void BuildTitle()
    {
        _chart.Title =
            "Розподіл операційних систем";
    }

    public void BuildData()
    {
        _chart.Data = new List<double>
        {
            45,
            30,
            15,
            10
        };
    }

    public void BuildStyle()
    {
        _chart.Style =
            "Кольорові сектори";
    }

    public void BuildLegend()
    {
        _chart.ShowLegend = true;

        _chart.Legend =
            "Частка користувачів";
    }

    public void BuildLabels()
    {
        _chart.Labels = new List<string>
        {
            "Windows",
            "Linux",
            "macOS",
            "Інші"
        };
    }

    public void BuildAdditionalElements()
    {
        _chart.AdditionalElements =
            "Відсотки у секторах";
    }

    public ChartProduct GetResult()
    {
        return _chart;
    }
}