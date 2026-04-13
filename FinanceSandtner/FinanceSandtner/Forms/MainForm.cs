using FinanceSandtner.Forms;
using FinanceSandtner.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using LiteDB;
using FinanceSandtner.Models;
using System.Collections.Generic;
using System.Drawing;

namespace FinanceSandtner
{
    public partial class MainForm : Form
    {
        private readonly TransactionService _transactionService = new();
        private readonly CategoryService _categoryService = new();
        private List<Transaction> _allTransactions = new();

        public MainForm()
        {
            InitializeComponent();

            pnlFilter.Visible = false;

            btnToggleFilter.Click += btnToggleFilter_Click;

            txtNameFilter.TextChanged += (_, __) => ApplyFilters();

            trkAmountMin.Scroll += trkAmountMin_Scroll;
            trkAmountMax.Scroll += trkAmountMax_Scroll;

            dtpFrom.ShowCheckBox = true;
            dtpTo.ShowCheckBox = true;
            dtpFrom.ValueChanged += (_, __) => ApplyFilters();
            dtpTo.ValueChanged += (_, __) => ApplyFilters();

            cmbCategoryFilter.SelectedIndexChanged += (_, __) => ApplyFilters();
            cmbTypeFilter.SelectedIndexChanged += (_, __) => ApplyFilters();

            InitAmountSliders();
            LoadFilterControls();
            LoadData();
            ApplyFilters();
        }

        private void btnToggleFilter_Click(object sender, EventArgs e)
        {
            pnlFilter.Visible = !pnlFilter.Visible;
        }

        private void LoadData()
        {
            _allTransactions = _transactionService.AllTransaction()
                .OrderBy(t => t.Date)
                .ToList();
        }

        private void InitAmountSliders()
        {
            trkAmountMin.Minimum = 0;
            trkAmountMin.Maximum = 100000;
            trkAmountMax.Minimum = 0;
            trkAmountMax.Maximum = 100000;

            trkAmountMin.Value = trkAmountMin.Minimum;
            trkAmountMax.Value = trkAmountMax.Maximum;

            lblAmountMin.Text = $"Min: {trkAmountMin.Value} Kč";
            lblAmountMax.Text = $"Max: {trkAmountMax.Value} Kč";
        }

        private void trkAmountMin_Scroll(object sender, EventArgs e)
        {
            if (trkAmountMin.Value > trkAmountMax.Value)
                trkAmountMin.Value = trkAmountMax.Value;

            lblAmountMin.Text = $"Min: {trkAmountMin.Value} Kč";
            ApplyFilters();
        }

        private void trkAmountMax_Scroll(object sender, EventArgs e)
        {
            if (trkAmountMax.Value < trkAmountMin.Value)
                trkAmountMax.Value = trkAmountMin.Value;

            lblAmountMax.Text = $"Max: {trkAmountMax.Value} Kč";
            ApplyFilters();
        }

        private void LoadFilterControls()
        {
            var categories = _categoryService.GetAll().ToList();

            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("Vše");
            foreach (var cat in categories)
                cmbCategoryFilter.Items.Add(cat);

            cmbCategoryFilter.DisplayMember = "Name";
            cmbCategoryFilter.SelectedIndex = 0;

            cmbTypeFilter.Items.Clear();
            cmbTypeFilter.Items.Add("Vše");
            cmbTypeFilter.Items.Add("Příjem");
            cmbTypeFilter.Items.Add("Výdaj");
            cmbTypeFilter.SelectedIndex = 0;

            dtpFrom.Checked = false;
            dtpTo.Checked = false;
        }

        private void ApplyFilters()
        {
            if (_allTransactions == null) return;

            var query = _allTransactions.AsEnumerable();

            var nameText = txtNameFilter.Text.Trim();
            if (!string.IsNullOrEmpty(nameText))
            {
                query = query.Where(t =>
                    (t.Member?.Name ?? string.Empty)
                        .IndexOf(nameText, StringComparison.OrdinalIgnoreCase) >= 0
                    ||
                    (t.Member?.ToString() ?? string.Empty)
                        .IndexOf(nameText, StringComparison.OrdinalIgnoreCase) >= 0
                );
            }

            var minAmount = (decimal)trkAmountMin.Value;
            var maxAmount = (decimal)trkAmountMax.Value;
            query = query.Where(t => t.Amount >= minAmount && t.Amount <= maxAmount);

            if (cmbCategoryFilter.SelectedItem is Category selectedCategory)
            {
                query = query.Where(t => t.Cat != null && t.Cat.Id == selectedCategory.Id);
            }

            var selectedType = cmbTypeFilter.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedType) && selectedType != "Vše")
            {
                query = query.Where(t => t.TypeOfTansaction == selectedType);
            }

            if (dtpFrom.Checked)
            {
                var fromDate = dtpFrom.Value.Date;
                query = query.Where(t => t.Date.Date >= fromDate);
            }

            if (dtpTo.Checked)
            {
                var toDate = dtpTo.Value.Date;
                query = query.Where(t => t.Date.Date <= toDate);
            }

            var filtered = query.OrderBy(t => t.Date).ToList();

            dataGridViewTransaction.DataSource = filtered.Select(t => new
            {
                t.Id,
                Datum = t.Date.ToShortDateString(),
                Člen = t.Member?.ToString() ?? "–",
                Kategorie = t.Cat?.Name ?? "–",
                Popis = t.Description,
                Částka = (t.TypeOfTansaction == "Příjem" ? "+" : "-") + $"{t.Amount:N2} Kč",
                Typ = t.TypeOfTansaction
            }).ToList();

            if (dataGridViewTransaction.Columns["Id"] != null)
                dataGridViewTransaction.Columns["Id"].Visible = false;

            _ = _transactionService.SumRemaining() < 0 ? labelLeftOver.ForeColor = Color.Red : labelLeftOver.ForeColor = Color.Black;
            var remaining = _transactionService.SumRemaining();
            labelLeftOver.Text = $"Celkový zůstatek:\n {remaining:N2} Kč";

            if (filtered.Any())
            {
                var incomes = filtered.Where(t => t.TypeOfTansaction == "Příjem").ToList();
                var expenses = filtered.Where(t => t.TypeOfTansaction == "Výdaj").ToList();

                var maxIncome = incomes.Any() ? incomes.Max(t => t.Amount) : 0;
                var maxExpense = expenses.Any() ? expenses.Max(t => t.Amount) : 0;

                var topCategory = expenses
                    .GroupBy(t => t.Cat?.Name ?? "Neznámá")
                    .OrderByDescending(g => g.Sum(t => t.Amount))
                    .FirstOrDefault()?.Key ?? "Žádná";

                var thisMonthTurnover = filtered
                    .Where(t => t.Date.Year == DateTime.Now.Year && t.Date.Month == DateTime.Now.Month)
                    .Sum(t => t.TypeOfTansaction == "Příjem" ? t.Amount : -t.Amount);

                var topSpender = expenses
                    .GroupBy(t => t.Member?.Name ?? "Neznámý")
                    .OrderByDescending(g => g.Sum(t => t.Amount))
                    .FirstOrDefault()?.Key ?? "Žádný";

                var topEarner = incomes
                    .GroupBy(t => t.Member?.Name ?? "Neznámý")
                    .OrderByDescending(g => g.Sum(t => t.Amount))
                    .FirstOrDefault()?.Key ?? "Žádný";

                var thisMonthExpenses = expenses
                    .Where(t => t.Date.Year == DateTime.Now.Year && t.Date.Month == DateTime.Now.Month)
                    .Sum(t => t.Amount);

                var averageExpense = expenses.Any() ? expenses.Average(t => t.Amount) : 0;

                lblTopIncome.Text = $"NEJVYŠŠÍ PŘÍJEM\n{maxIncome:N2} Kč";
                lblTopExpense.Text = $"NEJVYŠŠÍ VÝDAJ\n{maxExpense:N2} Kč";
                lblTopCat.Text = $"NEJVÍC UTRACENO ZA\n{topCategory}";
                lblTurnover.Text = $"MĚSÍČNÍ OBRAT\n{thisMonthTurnover:N2} Kč";
                lblTopSpender.Text = $"NEJVÍC UTRÁCÍ\n{topSpender}";
                lblTopEarner.Text = $"NEJVÍC PŘIJÍMÁ\n{topEarner}";
                lblThisMonthExp.Text = $"VÝDAJE TENTO MĚSÍC\n{thisMonthExpenses:N2} Kč";
                lblAvgExp.Text = $"PRŮMĚRNÝ VÝDAJ\n{averageExpense:N2} Kč";
            }
            else
            {
                lblTopIncome.Text = "NEJVYŠŠÍ PŘÍJEM\n0,00 Kč";
                lblTopExpense.Text = "NEJVYŠŠÍ VÝDAJ\n0,00 Kč";
                lblTopCat.Text = "NEJVÍC UTRACENO ZA\n–";
                lblTurnover.Text = "MĚSÍČNÍ OBRAT\n0,00 Kč";
                lblTopSpender.Text = "NEJVÍC UTRÁCÍ\n–";
                lblTopEarner.Text = "NEJVÍC PŘIJÍMÁ\n–";
                lblThisMonthExp.Text = "VÝDAJE TENTO MĚSÍC\n0,00 Kč";
                lblAvgExp.Text = $"PRŮMĚRNÝ VÝDAJ\n0,00 Kč";
            }
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            using var form = new TransactionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                ApplyFilters();
            }
        }

        private void btnHandleCategories_Click_1(object sender, EventArgs e)
        {
            new CategoryForm().ShowDialog();
        }

        private void btnCharts_Click_1(object sender, EventArgs e)
        {
            new ChartsForm().ShowDialog();
        }

        private void btnHandleMembers_Click_1(object sender, EventArgs e)
        {
            new MemberForm().ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransaction.SelectedRows.Count > 0)
            {
                var selectedId = (ObjectId)dataGridViewTransaction.SelectedRows[0].Cells["Id"].Value;
                if (MessageBox.Show("Smazat transakci?", "Smazat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _transactionService.Delete(selectedId);
                    LoadData();
                    ApplyFilters();
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridViewTransaction_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedId = (ObjectId)dataGridViewTransaction.Rows[e.RowIndex].Cells["Id"].Value;
                var transactionToEdit = _allTransactions.FirstOrDefault(t => t.Id == selectedId);
                if (transactionToEdit != null)
                {
                    using var form = new TransactionForm(transactionToEdit);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                        ApplyFilters();
                    }
                }
            }
        }

        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var res = MessageBox.Show("Opravdu chcete ukončit aplikaci?", "Konec", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) e.Cancel = true;
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtNameFilter.Text = string.Empty;

            trkAmountMin.Value = trkAmountMin.Minimum;
            trkAmountMax.Value = trkAmountMax.Maximum;
            lblAmountMin.Text = $"Min: {trkAmountMin.Value} Kč";
            lblAmountMax.Text = $"Max: {trkAmountMax.Value} Kč";

            cmbCategoryFilter.SelectedIndex = 0;
            cmbTypeFilter.SelectedIndex = 0;

            dtpFrom.Checked = false;
            dtpTo.Checked = false;

            LoadData();
            ApplyFilters();
        }
    }
}