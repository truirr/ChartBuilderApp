using ChartBuilderApp.Products;

namespace ChartBuilderApp.Builders;

public sealed class LineChartBuilder : IChartBuilder
{
    private LineChart _chart = new();

    public void Reset()
    {
        _chart = new LineChart();
    }

    public void BuildTitle()
    {
        _chart.Title =
            "Кількість користувачів за місяцями";
    }

    public void BuildData()
    {
        _chart.Data = new List<double>
        {
            20,
            35,
            30,
            55,
            65,
            80
        };
    }

    public void BuildStyle()
    {
        _chart.Style =
            "Лінія з маркерами";
    }

    public void BuildLegend()
    {
        _chart.ShowLegend = true;

        _chart.Legend =
            "Активні користувачі";
    }

    public void BuildLabels()
    {
        _chart.Labels = new List<string>
        {
            "Січ",
            "Лют",
            "Бер",
            "Кві",
            "Тра",
            "Чер"
        };
    }

    public void BuildAdditionalElements()
    {
        _chart.AdditionalElements =
            "Осі, сітка та маркери точок";
    }

    public ChartProduct GetResult()
    {
        return _chart;
    }
}