using System.Drawing.Drawing2D;
using ChartBuilderApp.Builders;
using ChartBuilderApp.Director;
using ChartBuilderApp.Products;

namespace ChartBuilderApp;

public partial class MainForm : Form
{
    private readonly ChartDirector _director =
        new();

    private ChartProduct? _currentProduct;

    private int _currentStep;

    private readonly string[] _steps =
    {
        "1. Заголовок",
        "2. Дані",
        "3. Стиль",
        "4. Легенда",
        "5. Підписи",
        "6. Додаткові елементи"
    };

    public MainForm()
    {
        InitializeComponent();

        cmbChartType.Items.Add(
            "Гістограма");

        cmbChartType.Items.Add(
            "Кругова діаграма");

        cmbChartType.Items.Add(
            "Лінійна діаграма");

        cmbChartType.SelectedIndex = 0;

        ResetSteps();

        btnNext.Enabled = false;
        btnBuildAll.Enabled = false;

        txtProductInfo.Text =
            "Продукт ще не створено.";

        lblCurrentStep.Text =
            "Натисніть «Почати».";
    }

    private void btnStart_Click(
        object sender,
        EventArgs e)
    {
        IChartBuilder builder;

        switch (cmbChartType.SelectedIndex)
        {
            case 0:
                builder =
                    new BarChartBuilder();
                break;

            case 1:
                builder =
                    new PieChartBuilder();
                break;

            case 2:
                builder =
                    new LineChartBuilder();
                break;

            default:
                builder =
                    new BarChartBuilder();
                break;
        }

        _director.SetBuilder(
            builder);

        _currentProduct =
            _director.GetCurrentProduct();

        _currentStep = 0;

        ResetSteps();

        progressBuild.Value = 0;

        btnNext.Enabled = true;
        btnBuildAll.Enabled = true;

        btnStart.Enabled = false;
        cmbChartType.Enabled = false;

        lblStatus.Text =
            $"Створюється: {_currentProduct.TypeName}";

        lblCurrentStep.Text =
            "Наступний крок: 1 із 6";

        txtLog.Clear();

        AddLog(
            $"Створено Builder для продукту: {_currentProduct.TypeName}");

        UpdateProductInfo();

        pnlPreview.Invalidate();
    }

    private void btnNext_Click(
        object sender,
        EventArgs e)
    {
        ExecuteNextStep();
    }

    private void btnBuildAll_Click(
        object sender,
        EventArgs e)
    {
        while (_currentStep <
               _director.StepCount)
        {
            ExecuteNextStep();
        }
    }

    private void ExecuteNextStep()
    {
        if (_currentProduct == null)
            return;

        if (_currentStep >=
            _director.StepCount)
            return;

        string stepName =
            _director.GetStepName(
                _currentStep);

        _currentProduct =
            _director.BuildStep(
                _currentStep);

        lstSteps.Items[_currentStep] =
            $"✓ {_steps[_currentStep]}";

        AddLog(
            $"Крок {_currentStep + 1}: {stepName}");

        _currentStep++;

        progressBuild.Value =
            _currentStep;

        UpdateProductInfo();

        pnlPreview.Invalidate();

        if (_currentStep >=
            _director.StepCount)
        {
            lblCurrentStep.Text =
                "Усі кроки виконано.";

            lblStatus.Text =
                $"Готово: {_currentProduct.TypeName}";

            btnNext.Enabled = false;
            btnBuildAll.Enabled = false;

            AddLog(
                "Діаграму повністю побудовано.");
        }
        else
        {
            lblCurrentStep.Text =
                $"Наступний крок: " +
                $"{_currentStep + 1} із " +
                $"{_director.StepCount}";
        }
    }

    private void btnReset_Click(
        object sender,
        EventArgs e)
    {
        _currentProduct = null;

        _currentStep = 0;

        progressBuild.Value = 0;

        ResetSteps();

        txtProductInfo.Text =
            "Продукт ще не створено.";

        txtLog.Clear();

        lblCurrentStep.Text =
            "Натисніть «Почати».";

        lblStatus.Text =
            "Очікування побудови";

        btnStart.Enabled = true;
        btnNext.Enabled = false;
        btnBuildAll.Enabled = false;

        cmbChartType.Enabled = true;

        pnlPreview.Invalidate();
    }

    private void ResetSteps()
    {
        lstSteps.Items.Clear();

        foreach (string step in _steps)
        {
            lstSteps.Items.Add(
                $"○ {step}");
        }
    }

    private void AddLog(
        string message)
    {
        txtLog.AppendText(
            $"[{DateTime.Now:HH:mm:ss}] " +
            $"{message}" +
            Environment.NewLine);
    }

    private void UpdateProductInfo()
    {
        if (_currentProduct == null)
            return;

        string data =
            _currentProduct.Data.Count == 0
                ? "—"
                : string.Join(
                    ", ",
                    _currentProduct.Data);

        string labels =
            _currentProduct.Labels.Count == 0
                ? "—"
                : string.Join(
                    ", ",
                    _currentProduct.Labels);

        txtProductInfo.Text =
            $"Тип: {_currentProduct.TypeName}" +
            Environment.NewLine +

            $"Заголовок: " +
            $"{ValueOrDash(_currentProduct.Title)}" +
            Environment.NewLine +

            $"Дані: {data}" +
            Environment.NewLine +

            $"Стиль: " +
            $"{ValueOrDash(_currentProduct.Style)}" +
            Environment.NewLine +

            $"Легенда: " +
            $"{ValueOrDash(_currentProduct.Legend)}" +
            Environment.NewLine +

            $"Підписи: {labels}" +
            Environment.NewLine +

            $"Додатково: " +
            $"{ValueOrDash(_currentProduct.AdditionalElements)}";
    }

    private static string ValueOrDash(
        string value)
    {
        return string.IsNullOrWhiteSpace(
            value)
            ? "—"
            : value;
    }

    private void pnlPreview_Paint(
        object sender,
        PaintEventArgs e)
    {
        Graphics g =
            e.Graphics;

        g.SmoothingMode =
            SmoothingMode.AntiAlias;

        g.Clear(Color.White);

        if (_currentProduct == null)
        {
            g.DrawString(
                "Тут буде відображено діаграму",
                new Font(
                    "Segoe UI",
                    12F),
                Brushes.Gray,
                30,
                30);

            return;
        }

        DrawChart(
            g,
            _currentProduct);
    }

    private void DrawChart(
        Graphics g,
        ChartProduct chart)
    {
        if (!string.IsNullOrWhiteSpace(
            chart.Title))
        {
            g.DrawString(
                chart.Title,
                new Font(
                    "Segoe UI",
                    15F,
                    FontStyle.Bold),
                Brushes.Black,
                30,
                20);
        }

        if (chart.Data.Count == 0)
        {
            g.DrawString(
                "Дані ще не додані.",
                new Font(
                    "Segoe UI",
                    10F),
                Brushes.Gray,
                30,
                80);

            return;
        }

        Rectangle area =
            new(
                60,
                90,
                pnlPreview.Width - 120,
                pnlPreview.Height - 150);

        if (chart is BarChart)
        {
            DrawBarChart(
                g,
                chart,
                area);
        }
        else if (chart is PieChart)
        {
            DrawPieChart(
                g,
                chart,
                area);
        }
        else if (chart is LineChart)
        {
            DrawLineChart(
                g,
                chart,
                area);
        }

        if (chart.ShowLegend)
        {
            g.FillRectangle(
                Brushes.RoyalBlue,
                30,
                pnlPreview.Height - 40,
                15,
                15);

            g.DrawString(
                chart.Legend,
                new Font(
                    "Segoe UI",
                    9F),
                Brushes.Black,
                55,
                pnlPreview.Height - 43);
        }
    }

    private void DrawBarChart(
        Graphics g,
        ChartProduct chart,
        Rectangle area)
    {
        double max =
            chart.Data.Max();

        int count =
            chart.Data.Count;

        int gap = 20;

        int width =
            (area.Width -
             gap * (count + 1)) /
            count;

        Brush brush =
            string.IsNullOrEmpty(
                chart.Style)
                ? Brushes.LightGray
                : Brushes.RoyalBlue;

        for (int i = 0;
             i < count;
             i++)
        {
            int height =
                (int)(
                    chart.Data[i] /
                    max *
                    area.Height);

            int x =
                area.Left +
                gap +
                i *
                (width + gap);

            int y =
                area.Bottom -
                height;

            g.FillRectangle(
                brush,
                x,
                y,
                width,
                height);

            if (chart.Labels.Count ==
                count)
            {
                g.DrawString(
                    chart.Labels[i],
                    new Font(
                        "Segoe UI",
                        8F),
                    Brushes.Black,
                    x,
                    area.Bottom + 5);
            }
        }

        if (!string.IsNullOrWhiteSpace(
            chart.AdditionalElements))
        {
            g.DrawLine(
                Pens.Black,
                area.Left,
                area.Top,
                area.Left,
                area.Bottom);

            g.DrawLine(
                Pens.Black,
                area.Left,
                area.Bottom,
                area.Right,
                area.Bottom);
        }
    }

    private void DrawPieChart(
        Graphics g,
        ChartProduct chart,
        Rectangle area)
    {
        int diameter =
            Math.Min(
                area.Width,
                area.Height);

        Rectangle rect =
            new(
                area.Left,
                area.Top,
                diameter,
                diameter);

        double total =
            chart.Data.Sum();

        float start = 0;

        Color[] colors =
        {
            Color.RoyalBlue,
            Color.SeaGreen,
            Color.Orange,
            Color.IndianRed,
            Color.MediumPurple
        };

        for (int i = 0;
             i < chart.Data.Count;
             i++)
        {
            float sweep =
                (float)(
                    chart.Data[i] /
                    total *
                    360);

            Brush brush =
                new SolidBrush(
                    colors[
                        i %
                        colors.Length]);

            g.FillPie(
                brush,
                rect,
                start,
                sweep);

            start += sweep;

            brush.Dispose();
        }
    }

    private void DrawLineChart(
        Graphics g,
        ChartProduct chart,
        Rectangle area)
    {
        double max =
            chart.Data.Max();

        int count =
            chart.Data.Count;

        if (count < 2)
            return;

        PointF[] points =
            new PointF[count];

        for (int i = 0;
             i < count;
             i++)
        {
            float x =
                area.Left +
                i *
                (area.Width /
                 (float)(count - 1));

            float y =
                area.Bottom -
                (float)(
                    chart.Data[i] /
                    max *
                    area.Height);

            points[i] =
                new PointF(
                    x,
                    y);
        }

        Pen pen =
            string.IsNullOrEmpty(
                chart.Style)
                ? Pens.Gray
                : new Pen(
                    Color.RoyalBlue,
                    3);

        g.DrawLines(
            pen,
            points);

        if (!string.IsNullOrEmpty(
            chart.AdditionalElements))
        {
            foreach (PointF point
                     in points)
            {
                g.FillEllipse(
                    Brushes.RoyalBlue,
                    point.X - 5,
                    point.Y - 5,
                    10,
                    10);
            }
        }

        if (pen != Pens.Gray)
        {
            pen.Dispose();
        }
    }
}