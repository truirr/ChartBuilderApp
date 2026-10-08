namespace ChartBuilderApp.Products;

public abstract class ChartProduct
{
    public string TypeName { get; protected set; } = "";

    public string Title { get; set; } = "";

    public List<double> Data { get; set; } = new();

    public string Style { get; set; } = "";

    public bool ShowLegend { get; set; }

    public string Legend { get; set; } = "";

    public List<string> Labels { get; set; } = new();

    public string AdditionalElements { get; set; } = "";
}