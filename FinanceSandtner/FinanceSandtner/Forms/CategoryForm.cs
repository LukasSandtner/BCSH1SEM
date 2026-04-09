using System;
using System.Windows.Forms;
using FinanceSandtner.Models;
using FinanceSandtner.Services;

namespace FinanceSandtner.Forms
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryService _categoryService = new();
        private bool _isClosingViaButton = false;

        public CategoryForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false; 
            cmbType.Items.AddRange(new string[]
            {
                "Jídlo", "Zábava", "Pojištění", "Energie", "Bydlení",
                "Doprava", "Oblečení", "Zdraví", "Rodina", "Spoření", "Ostatní"
            });
            cmbType.SelectedIndex = 0;

            btnAdd.Click += BtnAdd_Click;
            btnAlter.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnCancel.Click += BtnCancel_Click;

            listCategories.SelectedIndexChanged += ListCategories_SelectedIndexChanged;
            this.FormClosing += Form_FormClosing; 

            LoadCategories();
        }

        private void LoadCategories()
        {
            listCategories.DataSource = null;
            listCategories.DataSource = _categoryService.GetAll();
            listCategories.DisplayMember = "Name";
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) return;

            var cat = new Category
            {
                Name = txtName.Text,
                Type = cmbType.Text 
            };

            _categoryService.Add(cat);
            ClearInputs();
            LoadCategories();
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (listCategories.SelectedItem is Category selectedCategory && !string.IsNullOrWhiteSpace(txtName.Text))
            {
                selectedCategory.Name = txtName.Text;
                selectedCategory.Type = cmbType.Text;

                _categoryService.Update(selectedCategory);
                ClearInputs();
                LoadCategories();
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (listCategories.SelectedItem is Category selectedCategory)
            {
                var dialogResult = MessageBox.Show($"Smazat '{selectedCategory.Name}'?", "Smazat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    _categoryService.Delete(selectedCategory.Id);
                    ClearInputs();
                    LoadCategories();
                }
            }
        }

        private void ListCategories_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listCategories.SelectedItem is Category selectedCategory)
            {
                txtName.Text = selectedCategory.Name;
                cmbType.Text = selectedCategory.Type;
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            cmbType.SelectedIndex = 0;
            listCategories.ClearSelected();
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            _isClosingViaButton = true; 
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_isClosingViaButton && e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Opravdu chcete okno zavřít? Neuložené změny budou ztraceny.", "Zavřít okno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

    }
}