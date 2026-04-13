using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FinanceSandtner.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace FinanceSandtner.Forms
{
    public partial class ChartsForm : Form
    {
        private readonly TransactionService _transactionService = new();

        private readonly RadioButton _rbWeek;
        private readonly RadioButton _rbMonth;
        private readonly RadioButton _rbQuarter;
        private readonly RadioButton _rbYear;

        private readonly PieChart _pieChart;
        private readonly CartesianChart _cartesianChart;

        public ChartsForm()
        {
            InitializeComponent();
            Width = 1450;

            _rbWeek = new RadioButton { Text = "Týden", AutoSize = true };
            _rbMonth = new RadioButton { Text = "Měsíc", AutoSize = true };
            _rbQuarter = new RadioButton { Text = "Čtvrtletí", AutoSize = true };
            _rbYear = new RadioButton { Text = "Rok", AutoSize = true };

            _rbWeek.Checked = true;

            InitializeRadioPanel();
            var topPanel = CreateTopPanel();

            _pieChart = CreatePieChart();
            _cartesianChart = CreateCartesianChart();

            Controls.Clear();
            Controls.Add(_cartesianChart);
            Controls.Add(_pieChart);
            Controls.Add(topPanel);

            ShowPieByCategory();

            btnPrediction.BackColor = SystemColors.InactiveCaption;
        }

        private void InitializeRadioPanel()
        {
            rbPanel.Controls.Add(new Label
            {
                Text = "Horizont:",
                AutoSize = true,
                Padding = new Padding(0, 3, 8, 0)
            });
            rbPanel.Controls.Add(_rbWeek);
            rbPanel.Controls.Add(_rbMonth);
            rbPanel.Controls.Add(_rbQuarter);
            rbPanel.Controls.Add(_rbYear);

            _rbWeek.CheckedChanged += (_, __) => { if (_rbWeek.Checked) TryRefreshPredictionIfVisible(); };
            _rbMonth.CheckedChanged += (_, __) => { if (_rbMonth.Checked) TryRefreshPredictionIfVisible(); };
            _rbQuarter.CheckedChanged += (_, __) => { if (_rbQuarter.Checked) TryRefreshPredictionIfVisible(); };
            _rbYear.CheckedChanged += (_, __) => { if (_rbYear.Checked) TryRefreshPredictionIfVisible(); };
        }

        private Panel CreateTopPanel()
        {
            var topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 45
            };

            topPanel.Controls.Add(rbPanel);
            topPanel.Controls.Add(btnLineBalanceOverTime);
            topPanel.Controls.Add(btnMembersIncomeExpense);
            topPanel.Controls.Add(btnPieByCategory);
            topPanel.Controls.Add(btnPieByCategoryType);
            topPanel.Controls.Add(btnStackedByMonth);
            topPanel.Controls.Add(btnPrediction);

            return topPanel;
        }

        private static PieChart CreatePieChart() =>
            new PieChart
            {
                Dock = DockStyle.Fill,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right
            };

        private static CartesianChart CreateCartesianChart() =>
            new CartesianChart
            {
                Dock = DockStyle.Fill,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right
            };

        private void SetPredictionUiVisible(bool visible) => rbPanel.Visible = visible;

        private void TryRefreshPredictionIfVisible()
        {
            if (_cartesianChart.Visible && !_pieChart.Visible && rbPanel.Visible)
            {
                ShowPrediction();
            }
        }

        private PredictionHorizon GetSelectedHorizon()
        {
            if (_rbYear.Checked) return PredictionHorizon.Year;
            if (_rbQuarter.Checked) return PredictionHorizon.Quarter;
            if (_rbMonth.Checked) return PredictionHorizon.Month;
            return PredictionHorizon.Week;
        }

        private int GetHorizonDays(PredictionHorizon h) => h switch
        {
            PredictionHorizon.Week => 7,
            PredictionHorizon.Month => 30,
            PredictionHorizon.Quarter => 90,
            PredictionHorizon.Year => 365,
            _ => 30
        };

        private void ShowPrediction()
        {
            SetPredictionUiVisible(true);

            var transactions = _transactionService.AllTransaction();
            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro predikci.", "Predikce",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ordered = transactions.OrderBy(t => t.Date.Date).ToList();

            var history = BuildDailyBalanceSeries(ordered);
            if (history.Count == 0)
            {
                MessageBox.Show("Nejsou dostupná žádná data pro predikci.", "Predikce",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var lastPoint = history[^1];
            var avgDailyChange = ComputeAverageDailyChange(history, lookbackDays: 90);
            var horizonDays = GetHorizonDays(GetSelectedHorizon());

            var labels = BuildPredictionDateLabels(lastPoint.Date, horizonDays);
            var yAll = BuildPredictionValues(lastPoint.Balance, avgDailyChange, horizonDays);

            var (minYWithPad, maxYWithPad) = ComputeYRangeWithPadding(yAll);

            ConfigurePredictionChart(labels, yAll, horizonDays, minYWithPad, maxYWithPad);
        }

        private static string[] BuildPredictionDateLabels(DateTime lastDate, int horizonDays)
        {
            var startDate = lastDate;
            var allDates = Enumerable.Range(0, horizonDays + 1)
                .Select(i => startDate.AddDays(i))
                .ToList();

            return allDates.Select(d => d.ToShortDateString()).ToArray();
        }

        private static decimal[] BuildPredictionValues(decimal lastBalance, decimal avgDailyChange, int horizonDays)
        {
            var yAll = new decimal[horizonDays + 1];
            yAll[0] = lastBalance;

            for (int i = 1; i <= horizonDays; i++)
            {
                yAll[i] = Math.Round(lastBalance + avgDailyChange * i, 2);
            }

            return yAll;
        }

        private static (decimal Min, decimal Max) ComputeYRangeWithPadding(decimal[] values)
        {
            var minY = values.Min();
            var maxY = values.Max();
            var range = maxY - minY;
            var pad = range == 0 ? Math.Max(100m, Math.Abs(maxY) * 0.1m) : range * 0.10m;

            return (minY - pad, maxY + pad);
        }

        private void ConfigurePredictionChart(
            string[] labels,
            decimal[] yAll,
            int horizonDays,
            decimal minYWithPad,
            decimal maxYWithPad)
        {
            _cartesianChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden;

            var series = new List<ISeries>();
            var predictionPoints = BuildPredictionPoints(horizonDays, yAll);

            var mainSeries = CreateMainPredictionSeries(predictionPoints, labels);
            series.Add(mainSeries);

            AddColoredSegments(series, horizonDays, yAll);
            AddZeroLine(series, horizonDays);
            AddVerticalMarkerLines(series, horizonDays, minYWithPad, maxYWithPad);

            ConfigurePredictionAxes(labels, minYWithPad, maxYWithPad);

            _cartesianChart.Series = series.ToArray();
            _cartesianChart.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.CompareOnlyX;

            _cartesianChart.Visible = true;
            _pieChart.Visible = false;
        }

        private static LiveChartsCore.Defaults.ObservablePoint[] BuildPredictionPoints(int horizonDays, decimal[] yAll) =>
            Enumerable.Range(0, horizonDays + 1)
                .Select(i => new LiveChartsCore.Defaults.ObservablePoint(i, (double)yAll[i]))
                .ToArray();

        private static LineSeries<LiveChartsCore.Defaults.ObservablePoint> CreateMainPredictionSeries(
            LiveChartsCore.Defaults.ObservablePoint[] predictionPoints,
            string[] dateLabels)
        {
            return new LineSeries<LiveChartsCore.Defaults.ObservablePoint>
            {
                Name = "Predikce",
                Values = predictionPoints,
                Fill = null,
                GeometrySize = 8,
                Stroke = new SolidColorPaint(SKColors.DodgerBlue, 2),
                XToolTipLabelFormatter = cp =>
                {
                    int index = (int)Math.Round((double)cp.Model.X);
                    if (index < 0 || index >= dateLabels.Length) return string.Empty;

                    var dateText = dateLabels[index];

                    if (index == 0)
                        return $"{dateText} (počáteční)";
                    if (index == dateLabels.Length - 1)
                        return $"{dateText} (konečná)";

                    return $"{dateText}";
                }
            };
        }

        private static void AddColoredSegments(List<ISeries> series, int horizonDays, decimal[] yAll)
        {
            var upPaint = new SolidColorPaint(SKColors.ForestGreen, 3);
            var downPaint = new SolidColorPaint(SKColors.IndianRed, 3);
            var flatPaint = new SolidColorPaint(SKColors.Gray, 3);

            for (int i = 1; i <= horizonDays; i++)
            {
                var prev = yAll[i - 1];
                var cur = yAll[i];

                var paint = cur > prev ? upPaint : cur < prev ? downPaint : flatPaint;

                var segValues = new[]
                {
                    new LiveChartsCore.Defaults.ObservablePoint(i - 1, (double)prev),
                    new LiveChartsCore.Defaults.ObservablePoint(i, (double)cur)
                };

                series.Add(new LineSeries<LiveChartsCore.Defaults.ObservablePoint>
                {
                    Name = null,
                    Values = segValues,
                    Fill = null,
                    GeometrySize = 0,
                    Stroke = paint,
                    XToolTipLabelFormatter = null,
                    IsHoverable = false
                });
            }
        }

        private static void AddZeroLine(List<ISeries> series, int horizonDays)
        {
            series.Add(new LineSeries<LiveChartsCore.Defaults.ObservablePoint>
            {
                Name = null,
                Values = new[]
                {
                    new LiveChartsCore.Defaults.ObservablePoint(0, 0),
                    new LiveChartsCore.Defaults.ObservablePoint(horizonDays, 0)
                },
                Fill = null,
                GeometrySize = 0,
                Stroke = new SolidColorPaint(SKColors.Orange, 2),
                XToolTipLabelFormatter = null,
                IsHoverable = false
            });
        }

        private static void AddVerticalMarkerLines(
            List<ISeries> series,
            int horizonDays,
            decimal minYWithPad,
            decimal maxYWithPad)
        {
            foreach (var s in CreateVerticalMarkerLines(horizonDays, minYWithPad, maxYWithPad))
            {
                if (s is LineSeries<LiveChartsCore.Defaults.ObservablePoint> ls)
                {
                    ls.XToolTipLabelFormatter = null;
                    ls.IsHoverable = false;
                }
                series.Add(s);
            }
        }

        private void ConfigurePredictionAxes(string[] labels, decimal minYWithPad, decimal maxYWithPad)
        {
            _cartesianChart.XAxes = new[]
            {
                new Axis
                {
                    Name = "Datum",
                    Labels = labels,
                    LabelsRotation = 0,
                    MinStep = 1
                }
            };

            _cartesianChart.YAxes = new[]
            {
                new Axis
                {
                    Name = "Kč",
                    MinLimit = (double)minYWithPad,
                    MaxLimit = (double)maxYWithPad
                }
            };
        }

        private static IEnumerable<ISeries> CreateVerticalMarkerLines(int horizonDays, decimal minY, decimal maxY)
        {
            var markerPaint = new SolidColorPaint(new SKColor(120, 120, 120), 1);

            yield return new LineSeries<LiveChartsCore.Defaults.ObservablePoint>
            {
                Name = null,
                Values = new[]
                {
                    new LiveChartsCore.Defaults.ObservablePoint(0, (double)minY),
                    new LiveChartsCore.Defaults.ObservablePoint(0, (double)maxY)
                },
                Fill = null,
                GeometrySize = 0,
                Stroke = markerPaint
            };

            yield return new LineSeries<LiveChartsCore.Defaults.ObservablePoint>
            {
                Name = null,
                Values = new[]
                {
                    new LiveChartsCore.Defaults.ObservablePoint(horizonDays, (double)minY),
                    new LiveChartsCore.Defaults.ObservablePoint(horizonDays, (double)maxY)
                },
                Fill = null,
                GeometrySize = 0,
                Stroke = markerPaint
            };
        }

        private static List<(DateTime Date, decimal Balance)> BuildDailyBalanceSeries(
            List<FinanceSandtner.Models.Transaction> ordered)
        {
            var points = new List<(DateTime Date, decimal Balance)>();
            decimal running = 0;

            foreach (var t in ordered)
            {
                running += t.TypeOfTansaction == "Příjem" ? t.Amount : -t.Amount;
                points.Add((t.Date.Date, running));
            }

            return points
                .GroupBy(p => p.Date)
                .Select(g => (Date: g.Key, Balance: g.Last().Balance))
                .OrderBy(x => x.Date)
                .ToList();
        }

        private static decimal ComputeAverageDailyChange(
            List<(DateTime Date, decimal Balance)> history,
            int lookbackDays)
        {
            if (history.Count < 2) return 0m;

            var lastDate = history[^1].Date;
            var cutoff = lastDate.AddDays(-lookbackDays);

            var window = history.Where(p => p.Date >= cutoff).ToList();
            if (window.Count < 2) window = history;
            if (window.Count < 2) return 0m;

            decimal sumPerDay = 0m;
            int segments = 0;

            for (int i = 1; i < window.Count; i++)
            {
                var dDays = (window[i].Date - window[i - 1].Date).Days;
                if (dDays <= 0) continue;

                var delta = window[i].Balance - window[i - 1].Balance;
                sumPerDay += delta / dDays;
                segments++;
            }

            return segments == 0 ? 0m : sumPerDay / segments;
        }

        private void ShowPieByCategory()
        {
            PrepareChartForPie();

            var transactions = _transactionService.AllTransaction();
            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu.", "Grafy",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var expensesByCategory = transactions
                .Where(t => t.TypeOfTansaction == "Výdaj")
                .GroupBy(t => t.Cat?.Name ?? "Neznámá")
                .Select(g => new { Category = g.Key, Sum = g.Sum(t => t.Amount) })
                .Where(x => x.Sum > 0)
                .ToList();

            if (!expensesByCategory.Any())
            {
                MessageBox.Show("Nejsou dostupné žádné výdaje pro zobrazení koláčového grafu.", "Grafy",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _pieChart.Series = expensesByCategory
                .Select(x => new PieSeries<decimal> { Name = x.Category, Values = new[] { x.Sum } })
                .Cast<ISeries>()
                .ToArray();

            ShowPieChart();
        }

        private void ShowPieByCategoryType()
        {
            PrepareChartForPie();

            var transactions = _transactionService.AllTransaction();
            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu.", "Grafy",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var expensesByType = transactions
                .Where(t => t.TypeOfTansaction == "Výdaj")
                .GroupBy(t => t.Cat?.Type ?? "Neznámý typ")
                .Select(g => new { Type = g.Key, Sum = g.Sum(t => t.Amount) })
                .Where(x => x.Sum > 0)
                .ToList();

            if (!expensesByType.Any())
            {
                MessageBox.Show("Nejsou dostupné žádné výdaje pro zobrazení koláčového grafu podle typu.", "Grafy",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _pieChart.Series = expensesByType
                .Select(x => new PieSeries<decimal> { Name = x.Type, Values = new[] { x.Sum } })
                .Cast<ISeries>()
                .ToArray();

            ShowPieChart();
        }

        private void PrepareChartForPie()
        {
            SetPredictionUiVisible(false);
            _cartesianChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
        }

        private void ShowPieChart()
        {
            _pieChart.Visible = true;
            _cartesianChart.Visible = false;
        }

        private void ShowLineBalanceOverTime()
        {
            PrepareCartesianChart();

            var transactions = _transactionService.AllTransaction();
            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu.", "Grafy",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var byDate = BuildBalanceByDate(transactions);

            _cartesianChart.Series = new ISeries[]
            {
                new LineSeries<decimal>
                {
                    Name = "Zůstatek",
                    Values = byDate.Select(x => x.Balance).ToArray(),
                    Fill = null
                }
            };

            _cartesianChart.XAxes = new[]
            {
                new Axis
                {
                    Name = "Datum",
                    Labels = byDate.Select(x => x.Date.ToShortDateString()).ToArray()
                }
            };

            _cartesianChart.YAxes = new[]
            {
                new Axis { Name = "Kč" }
            };

            ShowCartesianChart();
        }

        private void ShowStackedByMonth()
        {
            PrepareCartesianChart();

            var transactions = _transactionService.AllTransaction();
            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu.", "Grafy",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var byMonth = BuildMonthlyAggregation(transactions);
            if (!byMonth.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení měsíčního grafu.", "Grafy",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var incomeValues = byMonth.Select(x => x.Income).ToArray();
            var expenseValues = byMonth.Select(x => x.Expense).ToArray();

            _cartesianChart.Series = new ISeries[]
            {
                new StackedColumnSeries<decimal> { Name = "Příjmy", Values = incomeValues },
                new StackedColumnSeries<decimal> { Name = "Výdaje", Values = expenseValues }
            };

            _cartesianChart.XAxes = new[]
            {
                new Axis
                {
                    Name = "Měsíc",
                    Labels = byMonth.Select(x => x.Label).ToArray()
                }
            };

            _cartesianChart.YAxes = new[]
            {
                new Axis { Name = "Kč" }
            };

            ShowCartesianChart();
        }

        private void ShowMembersIncomeExpense()
        {
            PrepareCartesianChart();

            var transactions = _transactionService.AllTransaction();
            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu podle členů.", "Grafy",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var byMember = BuildMemberAggregation(transactions);
            if (!byMember.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu podle členů.", "Grafy",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var labels = byMember.Select(x => x.Member).ToArray();
            var incomeValues = byMember.Select(x => x.Income).ToArray();
            var expenseValues = byMember.Select(x => x.Expense).ToArray();

            _cartesianChart.Series = new ISeries[]
            {
                new ColumnSeries<decimal> { Name = "Příjmy", Values = incomeValues },
                new ColumnSeries<decimal> { Name = "Výdaje", Values = expenseValues }
            };

            _cartesianChart.XAxes = new[]
            {
                new Axis
                {
                    Name = "Členové",
                    Labels = labels
                }
            };

            _cartesianChart.YAxes = new[]
            {
                new Axis { Name = "Kč" }
            };

            ShowCartesianChart();
        }

        private void PrepareCartesianChart()
        {
            SetPredictionUiVisible(false);
            _cartesianChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
        }

        private void ShowCartesianChart()
        {
            _cartesianChart.Visible = true;
            _pieChart.Visible = false;
        }

        private static List<(DateTime Date, decimal Balance)> BuildBalanceByDate(
            IEnumerable<FinanceSandtner.Models.Transaction> transactions)
        {
            var ordered = transactions.OrderBy(t => t.Date).ToList();
            var points = new List<(DateTime Date, decimal Balance)>();
            decimal running = 0;

            foreach (var t in ordered)
            {
                running += t.TypeOfTansaction == "Příjem" ? t.Amount : -t.Amount;
                points.Add((t.Date.Date, running));
            }

            return points
                .GroupBy(p => p.Date)
                .Select(g => (Date: g.Key, Balance: g.Last().Balance))
                .OrderBy(x => x.Date)
                .ToList();
        }

        private static List<(string Label, decimal Income, decimal Expense)> BuildMonthlyAggregation(
            IEnumerable<FinanceSandtner.Models.Transaction> transactions)
        {
            return transactions
                .GroupBy(t => new { t.Date.Year, t.Date.Month })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month)
                .Select(g => (
                    Label: $"{g.Key.Month:00}/{g.Key.Year}",
                    Income: g.Where(t => t.TypeOfTansaction == "Příjem").Sum(t => t.Amount),
                    Expense: g.Where(t => t.TypeOfTansaction == "Výdaj").Sum(t => t.Amount)
                ))
                .ToList();
        }

        private static List<(string Member, decimal Income, decimal Expense)> BuildMemberAggregation(
            IEnumerable<FinanceSandtner.Models.Transaction> transactions)
        {
            return transactions
                .GroupBy(t => t.Member?.Name ?? "Neznámý")
                .Select(g => (
                    Member: g.Key,
                    Income: g.Where(t => t.TypeOfTansaction == "Příjem").Sum(t => t.Amount),
                    Expense: g.Where(t => t.TypeOfTansaction == "Výdaj").Sum(t => t.Amount)
                ))
                .OrderByDescending(x => x.Income + x.Expense)
                .ToList();
        }

        private void btnPieCategory_Click(object sender, EventArgs e)
        {
            ShowPieByCategory();
        }

        private void btnPieByCategoryType_Click(object sender, EventArgs e)
        {
            ShowPieByCategoryType();
        }

        private void btnLineBalanceOverTime_Click(object sender, EventArgs e)
        {
            ShowLineBalanceOverTime();
        }

        private void btnStackedByMonth_Click(object sender, EventArgs e)
        {
            ShowStackedByMonth();
        }

        private void btnMembersIncomeExpense_Click(object sender, EventArgs e)
        {
            ShowMembersIncomeExpense();
        }

        private void btnPrediction_Click(object sender, EventArgs e)
        {
            ShowPrediction();
        }
    }
}