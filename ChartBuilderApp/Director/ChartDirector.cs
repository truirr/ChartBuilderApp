using ChartBuilderApp.Builders;
using ChartBuilderApp.Products;

namespace ChartBuilderApp.Director;

public sealed class ChartDirector
{
    private IChartBuilder? _builder;

    private readonly string[] _stepNames =
    {
        "Створення заголовка",
        "Додавання даних",
        "Налаштування стилю",
        "Додавання легенди",
        "Додавання підписів",
        "Додавання додаткових елементів"
    };

    public int StepCount =>
        _stepNames.Length;

    public void SetBuilder(
        IChartBuilder builder)
    {
        _builder = builder;

        _builder.Reset();
    }

    public string GetStepName(
        int stepIndex)
    {
        return _stepNames[stepIndex];
    }

    public ChartProduct BuildStep(
        int stepIndex)
    {
        if (_builder == null)
        {
            throw new InvalidOperationException(
                "Будівельник не вибраний.");
        }

        switch (stepIndex)
        {
            case 0:
                _builder.BuildTitle();
                break;

            case 1:
                _builder.BuildData();
                break;

            case 2:
                _builder.BuildStyle();
                break;

            case 3:
                _builder.BuildLegend();
                break;

            case 4:
                _builder.BuildLabels();
                break;

            case 5:
                _builder.BuildAdditionalElements();
                break;

            default:
                throw new ArgumentOutOfRangeException(
                    nameof(stepIndex));
        }

        return _builder.GetResult();
    }

    public ChartProduct GetCurrentProduct()
    {
        if (_builder == null)
        {
            throw new InvalidOperationException(
                "Будівельник не вибраний.");
        }

        return _builder.GetResult();
    }
}