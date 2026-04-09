using System;
using System.Linq;
using System.Windows.Forms;
using FinanceSandtner.Models;
using FinanceSandtner.Services;

namespace FinanceSandtner.Forms
{
    public partial class TransactionForm : Form
    {
        private readonly TransactionService _transactionService = new();
        private readonly CategoryService _categoryService = new();
        private readonly FamilyMemberService _memberService = new();
        private readonly Transaction? _transactionToEdit;

        public TransactionForm(Transaction? transactionToEdit = null)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            _transactionToEdit = transactionToEdit;

            numAmount.Maximum = 10000000000m;
            numAmount.DecimalPlaces = 2;

            cmbCategory.DataSource = _categoryService.GetAll();
            cmbCategory.DisplayMember = "Name";

            cmbMember.DataSource = _memberService.GetAll();
            cmbMember.DisplayMember = "Name";

            cmbType.Items.AddRange(new string[] { "Výdaj", "Příjem" });
            cmbType.SelectedIndex = 0;

            dtpDate.Value = DateTime.Today;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            this.FormClosing += Form_FormClosing;

            if (_transactionToEdit != null)
            {
                numAmount.Value = _transactionToEdit.Amount;
                txtDescription.Text = _transactionToEdit.Description;
                cmbType.Text = _transactionToEdit.TypeOfTansaction;

                cmbCategory.SelectedItem = ((System.Collections.Generic.List<Category>)cmbCategory.DataSource)
                    .FirstOrDefault(c => c.Id == _transactionToEdit.CategoryId);

                cmbMember.SelectedItem = ((System.Collections.Generic.List<FamilyMember>)cmbMember.DataSource)
                    .FirstOrDefault(m => m.Id == _transactionToEdit.FamilyMemberId);

                dtpDate.Value = _transactionToEdit.Date;

                this.Text = "Úprava transakce";
            }
            else
            {
                numAmount.Value = 0;
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            var selectedMember = cmbMember.SelectedItem as FamilyMember;
            var selectedCategory = cmbCategory.SelectedItem as Category;

            if (selectedMember == null || selectedCategory == null)
            {
                MessageBox.Show("Vyberte člena a kategorii!");
                return;
            }

            if (_transactionToEdit == null)
            {
                var newTransaction = new Transaction
                {
                    Amount = numAmount.Value,
                    Description = txtDescription.Text,
                    FamilyMemberId = selectedMember.Id,
                    CategoryId = selectedCategory.Id,
                    Date = dtpDate.Value,
                    TypeOfTansaction = cmbType.Text
                };

                _transactionService.Add(newTransaction);
            }
            else
            {
                _transactionToEdit.Amount = numAmount.Value;
                _transactionToEdit.Description = txtDescription.Text;
                _transactionToEdit.FamilyMemberId = selectedMember.Id;
                _transactionToEdit.CategoryId = selectedCategory.Id;
                _transactionToEdit.TypeOfTansaction = cmbType.Text;
                _transactionToEdit.Date = dtpDate.Value; 

                _transactionService.Alter(_transactionToEdit);
            }

            this.FormClosing -= Form_FormClosing;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.FormClosing -= Form_FormClosing;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    "Opravdu chcete okno zavřít? Neuložené změny budou ztraceny.",
                    "Zavřít okno",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}