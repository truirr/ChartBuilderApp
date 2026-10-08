using ChartBuilderApp.Products;

namespace ChartBuilderApp.Builders;

public interface IChartBuilder
{
    void Reset();

    void BuildTitle();

    void BuildData();

    void BuildStyle();

    void BuildLegend();

    void BuildLabels();

    void BuildAdditionalElements();

    ChartProduct GetResult();
}