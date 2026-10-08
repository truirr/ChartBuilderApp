using ChartBuilderApp.Products;

namespace ChartBuilderApp.Builders;

public sealed class BarChartBuilder : IChartBuilder
{
    private BarChart _chart = new();

    public void Reset()
    {
        _chart = new BarChart();
    }

    public void BuildTitle()
    {
        _chart.Title = "Продажі за кварталами";
    }

    public void BuildData()
    {
        _chart.Data = new List<double>
        {
            35,
            50,
            75,
            60
        };
    }

    public void BuildStyle()
    {
        _chart.Style = "Сині стовпчики";
    }

    public void BuildLegend()
    {
        _chart.ShowLegend = true;

        _chart.Legend =
            "Обсяг продажів";
    }

    public void BuildLabels()
    {
        _chart.Labels = new List<string>
        {
            "I кв.",
            "II кв.",
            "III кв.",
            "IV кв."
        };
    }

    public void BuildAdditionalElements()
    {
        _chart.AdditionalElements =
            "Осі X/Y та горизонтальна сітка";
    }

    public ChartProduct GetResult()
    {
        return _chart;
    }
}