using System;
using System.Windows.Forms;
using FinanceSandtner.Models;
using FinanceSandtner.Services;

namespace FinanceSandtner.Forms
{
    public partial class MemberForm : Form
    {
        private readonly FamilyMemberService _memberService = new();
        private FamilyMember? _selectedMember;
        private bool _isClosingViaButton = false;

        public MemberForm()
        {
            InitializeComponent();
            LoadMembers();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            listMembers.SelectedIndexChanged += ListMembers_SelectedIndexChanged;
        }

        private void LoadMembers()
        {
            listMembers.DataSource = null;
            listMembers.DataSource = _memberService.GetAll();
            listMembers.DisplayMember = "";
        }

        private void ListMembers_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listMembers.SelectedItem is FamilyMember member)
            {
                _selectedMember = member;

                txtName.Text = member.Name;
                txtLastName.Text = member.Surname;
                txtRole.Text = member.Role;

                if (member.BirthDate >= dtpBirthDate.MinDate && member.BirthDate <= dtpBirthDate.MaxDate)
                {
                    dtpBirthDate.Value = member.BirthDate;
                }
                else
                {
                    dtpBirthDate.Value = DateTime.Today;
                }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Jméno je povinné.");
                return;
            }

            var member = new FamilyMember
            {
                Name = txtName.Text,
                Surname = txtLastName.Text,
                Role = txtRole.Text,
                BirthDate = dtpBirthDate.Value.Date 
            };

            _memberService.Add(member);
            ClearForm();
            LoadMembers();
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (_selectedMember == null || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vyberte člena a zadejte jméno.");
                return;
            }

            _selectedMember.Name = txtName.Text;
            _selectedMember.Surname = txtLastName.Text;
            _selectedMember.Role = txtRole.Text;
            _selectedMember.BirthDate = dtpBirthDate.Value.Date;

            _memberService.Update(_selectedMember);

            ClearForm();
            LoadMembers();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedMember == null) return;

            var result = MessageBox.Show($"Opravdu smazat: {_selectedMember.Name}?", "Smazat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _memberService.Delete(_selectedMember.Id);
                ClearForm();
                LoadMembers();
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtLastName.Clear();
            txtRole.Clear();
            dtpBirthDate.Value = DateTime.Today;

            _selectedMember = null;
            listMembers.ClearSelected();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.FormClosing -= Form_FormClosing;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Opravdu chcete okno zavřít? Neuložené změny budou ztraceny.", "Zavřít okno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {

        }
    }
}