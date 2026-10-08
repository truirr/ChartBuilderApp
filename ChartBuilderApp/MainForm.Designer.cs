namespace ChartBuilderApp;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel panelHeader;

    private Label lblTitle;
    private Label lblSubtitle;

    private Panel panelLeft;

    private Label lblChartType;

    private ComboBox cmbChartType;

    private Button btnStart;
    private Button btnNext;
    private Button btnBuildAll;
    private Button btnReset;

    private Label lblSteps;

    private ListBox lstSteps;

    private ProgressBar progressBuild;

    private Label lblCurrentStep;

    private Label lblPreview;

    private Panel pnlPreview;

    private Label lblProduct;

    private TextBox txtProductInfo;

    private Label lblLog;

    private TextBox txtLog;

    private Label lblStatus;

    protected override void Dispose(
        bool disposing)
    {
        if (disposing &&
            components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelHeader =
            new Panel();

        lblTitle =
            new Label();

        lblSubtitle =
            new Label();

        panelLeft =
            new Panel();

        lblChartType =
            new Label();

        cmbChartType =
            new ComboBox();

        btnStart =
            new Button();

        btnNext =
            new Button();

        btnBuildAll =
            new Button();

        btnReset =
            new Button();

        lblSteps =
            new Label();

        lstSteps =
            new ListBox();

        progressBuild =
            new ProgressBar();

        lblCurrentStep =
            new Label();

        lblPreview =
            new Label();

        pnlPreview =
            new Panel();

        lblProduct =
            new Label();

        txtProductInfo =
            new TextBox();

        lblLog =
            new Label();

        txtLog =
            new TextBox();

        lblStatus =
            new Label();

        panelHeader.SuspendLayout();
        panelLeft.SuspendLayout();

        SuspendLayout();

        // HEADER

        panelHeader.BackColor =
            Color.FromArgb(
                30,
                35,
                46);

        panelHeader.Controls.Add(
            lblTitle);

        panelHeader.Controls.Add(
            lblSubtitle);

        panelHeader.Dock =
            DockStyle.Top;

        panelHeader.Height =
            100;

        // TITLE

        lblTitle.AutoSize =
            true;

        lblTitle.Font =
            new Font(
                "Segoe UI",
                21F,
                FontStyle.Bold);

        lblTitle.ForeColor =
            Color.White;

        lblTitle.Location =
            new Point(
                28,
                15);

        lblTitle.Text =
            "Будівельник різних діаграм";

        // SUBTITLE

        lblSubtitle.AutoSize =
            true;

        lblSubtitle.Font =
            new Font(
                "Segoe UI",
                10F);

        lblSubtitle.ForeColor =
            Color.LightGray;

        lblSubtitle.Location =
            new Point(
                31,
                65);

        lblSubtitle.Text =
            "Builder — покрокове створення складного об'єкта";

        // LEFT PANEL

        panelLeft.BackColor =
            Color.FromArgb(
                245,
                246,
                248);

        panelLeft.Location =
            new Point(
                0,
                100);

        panelLeft.Size =
            new Size(
                320,
                720);

        panelLeft.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Bottom |
            AnchorStyles.Left;

        // TYPE

        lblChartType.AutoSize =
            true;

        lblChartType.Font =
            new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

        lblChartType.Location =
            new Point(
                25,
                25);

        lblChartType.Text =
            "Тип діаграми";

        // COMBO

        cmbChartType.DropDownStyle =
            ComboBoxStyle.DropDownList;

        cmbChartType.Location =
            new Point(
                25,
                55);

        cmbChartType.Size =
            new Size(
                270,
                28);

        // START

        btnStart.Location =
            new Point(
                25,
                105);

        btnStart.Size =
            new Size(
                270,
                45);

        btnStart.Text =
            "Почати";

        btnStart.BackColor =
            Color.RoyalBlue;

        btnStart.ForeColor =
            Color.White;

        btnStart.FlatStyle =
            FlatStyle.Flat;

        btnStart.Click +=
            btnStart_Click;

        // NEXT

        btnNext.Location =
            new Point(
                25,
                165);

        btnNext.Size =
            new Size(
                130,
                40);

        btnNext.Text =
            "Наступний крок";

        btnNext.Click +=
            btnNext_Click;

        // ALL

        btnBuildAll.Location =
            new Point(
                165,
                165);

        btnBuildAll.Size =
            new Size(
                130,
                40);

        btnBuildAll.Text =
            "Побудувати все";

        btnBuildAll.Click +=
            btnBuildAll_Click;

        // RESET

        btnReset.Location =
            new Point(
                25,
                218);

        btnReset.Size =
            new Size(
                270,
                38);

        btnReset.Text =
            "Скинути";

        btnReset.Click +=
            btnReset_Click;

        // STEPS LABEL

        lblSteps.AutoSize =
            true;

        lblSteps.Font =
            new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

        lblSteps.Location =
            new Point(
                25,
                280);

        lblSteps.Text =
            "Кроки побудови";

        // STEPS LIST

        lstSteps.Location =
            new Point(
                25,
                315);

        lstSteps.Size =
            new Size(
                270,
                150);

        lstSteps.Font =
            new Font(
                "Segoe UI",
                9F);

        // PROGRESS

        progressBuild.Location =
            new Point(
                25,
                490);

        progressBuild.Size =
            new Size(
                270,
                22);

        progressBuild.Minimum = 0;

        progressBuild.Maximum = 6;

        // CURRENT STEP

        lblCurrentStep.Location =
            new Point(
                25,
                530);

        lblCurrentStep.Size =
            new Size(
                270,
                60);

        // ADD TO LEFT

        panelLeft.Controls.Add(
            lblChartType);

        panelLeft.Controls.Add(
            cmbChartType);

        panelLeft.Controls.Add(
            btnStart);

        panelLeft.Controls.Add(
            btnNext);

        panelLeft.Controls.Add(
            btnBuildAll);

        panelLeft.Controls.Add(
            btnReset);

        panelLeft.Controls.Add(
            lblSteps);

        panelLeft.Controls.Add(
            lstSteps);

        panelLeft.Controls.Add(
            progressBuild);

        panelLeft.Controls.Add(
            lblCurrentStep);

        // PREVIEW LABEL

        lblPreview.AutoSize =
            true;

        lblPreview.Font =
            new Font(
                "Segoe UI",
                11F,
                FontStyle.Bold);

        lblPreview.Location =
            new Point(
                345,
                120);

        lblPreview.Text =
            "Попередній вигляд";

        // PREVIEW PANEL

        pnlPreview.Location =
            new Point(
                345,
                155);

        pnlPreview.Size =
            new Size(
                865,
                385);

        pnlPreview.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Left |
            AnchorStyles.Right;

        pnlPreview.BackColor =
            Color.White;

        pnlPreview.BorderStyle =
            BorderStyle.FixedSingle;

        pnlPreview.Paint +=
            pnlPreview_Paint;

        // PRODUCT LABEL

        lblProduct.AutoSize =
            true;

        lblProduct.Font =
            new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

        lblProduct.Location =
            new Point(
                345,
                555);

        lblProduct.Text =
            "Стан продукту";

        // PRODUCT INFO

        txtProductInfo.Location =
            new Point(
                345,
                585);

        txtProductInfo.Size =
            new Size(
                430,
                170);

        txtProductInfo.Multiline =
            true;

        txtProductInfo.ReadOnly =
            true;

        txtProductInfo.Font =
            new Font(
                "Consolas",
                9F);

        txtProductInfo.ScrollBars =
            ScrollBars.Vertical;

        // LOG LABEL

        lblLog.AutoSize =
            true;

        lblLog.Font =
            new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

        lblLog.Location =
            new Point(
                800,
                555);

        lblLog.Text =
            "Журнал виконання";

        // LOG

        txtLog.Location =
            new Point(
                800,
                585);

        txtLog.Size =
            new Size(
                410,
                170);

        txtLog.Multiline =
            true;

        txtLog.ReadOnly =
            true;

        txtLog.Font =
            new Font(
                "Consolas",
                9F);

        txtLog.ScrollBars =
            ScrollBars.Vertical;

        // STATUS

        lblStatus.Location =
            new Point(
                320,
                780);

        lblStatus.Size =
            new Size(
                920,
                40);

        lblStatus.Anchor =
            AnchorStyles.Bottom |
            AnchorStyles.Left |
            AnchorStyles.Right;

        lblStatus.BackColor =
            Color.FromArgb(
                30,
                35,
                46);

        lblStatus.ForeColor =
            Color.White;

        lblStatus.Padding =
            new Padding(
                20,
                0,
                0,
                0);

        lblStatus.Text =
            "Очікування побудови";

        lblStatus.TextAlign =
            ContentAlignment.MiddleLeft;

        // MAIN FORM

        AutoScaleDimensions =
            new SizeF(
                8F,
                20F);

        AutoScaleMode =
            AutoScaleMode.Font;

        ClientSize =
            new Size(
                1240,
                820);

        MinimumSize =
            new Size(
                1100,
                760);

        StartPosition =
            FormStartPosition.CenterScreen;

        Text =
            "Builder — Будівельник діаграм";

        BackColor =
            Color.White;

        Controls.Add(
            panelHeader);

        Controls.Add(
            panelLeft);

        Controls.Add(
            lblPreview);

        Controls.Add(
            pnlPreview);

        Controls.Add(
            lblProduct);

        Controls.Add(
            txtProductInfo);

        Controls.Add(
            lblLog);

        Controls.Add(
            txtLog);

        Controls.Add(
            lblStatus);

        panelHeader.ResumeLayout(
            false);

        panelHeader.PerformLayout();

        panelLeft.ResumeLayout(
            false);

        panelLeft.PerformLayout();

        ResumeLayout(
            false);

        PerformLayout();
    }
}