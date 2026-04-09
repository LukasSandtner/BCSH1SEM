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
            rbPanel.Controls.Add(new Label { Text = "Horizont:", AutoSize = true, Padding = new Padding(0, 3, 8, 0) });
            rbPanel.Controls.Add(_rbWeek);
            rbPanel.Controls.Add(_rbMonth);
            rbPanel.Controls.Add(_rbQuarter);
            rbPanel.Controls.Add(_rbYear);

            _rbWeek.CheckedChanged += (_, __) => { if (_rbWeek.Checked) TryRefreshPredictionIfVisible(); };
            _rbMonth.CheckedChanged += (_, __) => { if (_rbMonth.Checked) TryRefreshPredictionIfVisible(); };
            _rbQuarter.CheckedChanged += (_, __) => { if (_rbQuarter.Checked) TryRefreshPredictionIfVisible(); };
            _rbYear.CheckedChanged += (_, __) => { if (_rbYear.Checked) TryRefreshPredictionIfVisible(); };

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

            _pieChart = new PieChart
            {
                Dock = DockStyle.Fill,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right
            };

            _cartesianChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right
            };

            Controls.Clear();
            Controls.Add(_cartesianChart);
            Controls.Add(_pieChart);
            Controls.Add(topPanel);

            ShowPieByCategory();
        }

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
                MessageBox.Show("Nejsou dostupná žádná data pro predikci.", "Predikce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ordered = transactions.OrderBy(t => t.Date.Date).ToList();

            var history = BuildDailyBalanceSeries(ordered);
            if (history.Count == 0)
            {
                MessageBox.Show("Nejsou dostupná žádná data pro predikci.", "Predikce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var lastDate = history[^1].Date;
            var lastBalance = history[^1].Balance;

            var avgDailyChange = ComputeAverageDailyChange(history, lookbackDays: 90);

            var horizonDays = GetHorizonDays(GetSelectedHorizon());

            var startDate = lastDate;
            var endDate = lastDate.AddDays(horizonDays);

            var allDates = Enumerable.Range(0, horizonDays + 1).Select(i => startDate.AddDays(i)).ToList();
            var labels = allDates.Select(d => d.ToShortDateString()).ToArray();

            var yAll = new decimal[horizonDays + 1];
            yAll[0] = lastBalance;
            for (int i = 1; i <= horizonDays; i++)
                yAll[i] = lastBalance + avgDailyChange * i;

            var minY = yAll.Min();
            var maxY = yAll.Max();
            var range = maxY - minY;
            var pad = range == 0 ? Math.Max(100m, Math.Abs(maxY) * 0.1m) : range * 0.10m;

            var minYWithPad = minY - pad;
            var maxYWithPad = maxY + pad;

            _cartesianChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden;

            var series = new List<ISeries>();

            var upPaint = new SolidColorPaint(SKColors.ForestGreen, 3);
            var downPaint = new SolidColorPaint(SKColors.IndianRed, 3);
            var flatPaint = new SolidColorPaint(SKColors.Gray, 3);

            for (int i = 1; i <= horizonDays; i++)
            {
                var prev = yAll[i - 1];
                var cur = yAll[i];

                var paint = cur > prev ? upPaint : cur < prev ? downPaint : flatPaint;

                var segValues = new LiveChartsCore.Defaults.ObservablePoint[]
                {
                    new(i - 1, (double)prev),
                    new(i, (double)cur)
                };

                series.Add(new LineSeries<LiveChartsCore.Defaults.ObservablePoint>
                {
                    Name = null,
                    Values = segValues,
                    Fill = null,
                    GeometrySize = 0,
                    Stroke = paint
                });
            }

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
                Stroke = new SolidColorPaint(SKColors.Orange, 2)
            });

            series.AddRange(CreateVerticalMarkerLines(horizonDays, minYWithPad, maxYWithPad));

            _cartesianChart.Series = series.ToArray();

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

            _cartesianChart.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.CompareOnlyX;

            _cartesianChart.Visible = true;
            _pieChart.Visible = false;
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
                    new LiveChartsCore.Defaults.ObservablePoint(0, (double)maxY),
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
                    new LiveChartsCore.Defaults.ObservablePoint(horizonDays, (double)maxY),
                },
                Fill = null,
                GeometrySize = 0,
                Stroke = markerPaint
            };
        }

        private static List<(DateTime Date, decimal Balance)> BuildDailyBalanceSeries(List<FinanceSandtner.Models.Transaction> ordered)
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

        private static decimal ComputeAverageDailyChange(List<(DateTime Date, decimal Balance)> history, int lookbackDays)
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
            SetPredictionUiVisible(false);
            _cartesianChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;

            var transactions = _transactionService.AllTransaction();

            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu.", "Grafy", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Nejsou dostupné žádné výdaje pro zobrazení koláčového grafu.", "Grafy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _pieChart.Series = expensesByCategory
                .Select(x => new PieSeries<decimal> { Name = x.Category, Values = new[] { x.Sum } })
                .Cast<ISeries>()
                .ToArray();

            _pieChart.Visible = true;
            _cartesianChart.Visible = false;
        }

        private void ShowPieByCategoryType()
        {
            SetPredictionUiVisible(false);
            _cartesianChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;

            var transactions = _transactionService.AllTransaction();

            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu.", "Grafy", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Nejsou dostupné žádné výdaje pro zobrazení koláčového grafu podle typu.", "Grafy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _pieChart.Series = expensesByType
                .Select(x => new PieSeries<decimal> { Name = x.Type, Values = new[] { x.Sum } })
                .Cast<ISeries>()
                .ToArray();

            _pieChart.Visible = true;
            _cartesianChart.Visible = false;
        }

        private void ShowLineBalanceOverTime()
        {
            SetPredictionUiVisible(false);
            _cartesianChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;

            var transactions = _transactionService.AllTransaction();

            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu.", "Grafy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ordered = transactions.OrderBy(t => t.Date).ToList();

            var points = new List<(DateTime Date, decimal Balance)>();
            decimal running = 0;

            foreach (var t in ordered)
            {
                running += t.TypeOfTansaction == "Příjem" ? t.Amount : -t.Amount;
                points.Add((t.Date.Date, running));
            }

            var byDate = points
                .GroupBy(p => p.Date)
                .Select(g => new { Date = g.Key, Balance = g.Last().Balance })
                .OrderBy(x => x.Date)
                .ToList();

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
                new Axis
                {
                    Name = "Kč"
                }
            };

            _cartesianChart.Visible = true;
            _pieChart.Visible = false;
        }

        private void ShowStackedByMonth()
        {
            SetPredictionUiVisible(false);
            _cartesianChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;

            var transactions = _transactionService.AllTransaction();

            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu.", "Grafy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var byMonth = transactions
                .GroupBy(t => new { t.Date.Year, t.Date.Month })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .Select(g => new
                {
                    Label = $"{g.Key.Month:00}/{g.Key.Year}",
                    Income = g.Where(t => t.TypeOfTansaction == "Příjem").Sum(t => t.Amount),
                    Expense = g.Where(t => t.TypeOfTansaction == "Výdaj").Sum(t => t.Amount)
                })
                .ToList();

            if (!byMonth.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení měsíčního grafu.", "Grafy", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                new Axis
                {
                    Name = "Kč"
                }
            };

            _cartesianChart.Visible = true;
            _pieChart.Visible = false;
        }

        private void ShowMembersIncomeExpense()
        {
            SetPredictionUiVisible(false);
            _cartesianChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;

            var transactions = _transactionService.AllTransaction();

            if (!transactions.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu.", "Grafy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var byMember = transactions
                .GroupBy(t => t.Member?.Name ?? "Neznámý")
                .Select(g => new
                {
                    Member = g.Key,
                    Income = g.Where(t => t.TypeOfTansaction == "Příjem").Sum(t => t.Amount),
                    Expense = g.Where(t => t.TypeOfTansaction == "Výdaj").Sum(t => t.Amount)
                })
                .OrderByDescending(x => x.Income + x.Expense)
                .ToList();

            if (!byMember.Any())
            {
                MessageBox.Show("Nejsou dostupná žádná data pro zobrazení grafu podle členů.", "Grafy", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                new Axis
                {
                    Name = "Kč"
                }
            };

            _cartesianChart.Visible = true;
            _pieChart.Visible = false;
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