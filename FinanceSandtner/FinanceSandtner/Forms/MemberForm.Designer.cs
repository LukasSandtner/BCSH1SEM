namespace FinanceSandtner.Forms
{
    partial class MemberForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listMembers = new ListBox();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtLastName = new TextBox();
            label3 = new Label();
            txtRole = new TextBox();
            label4 = new Label();
            dtpBirthDate = new DateTimePicker();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listMembers
            // 
            listMembers.BackColor = SystemColors.ScrollBar;
            listMembers.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            listMembers.FormattingEnabled = true;
            listMembers.Location = new Point(12, 12);
            listMembers.Name = "listMembers";
            listMembers.Size = new Size(345, 106);
            listMembers.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(14, 29);
            label1.Name = "label1";
            label1.Size = new Size(53, 17);
            label1.TabIndex = 1;
            label1.Text = "Jméno:";
            // 
            // txtName
            // 
            txtName.Location = new Point(133, 26);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 24);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(14, 66);
            label2.Name = "label2";
            label2.Size = new Size(64, 17);
            label2.TabIndex = 3;
            label2.Text = "Příjmení:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(133, 58);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 24);
            txtLastName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(14, 98);
            label3.Name = "label3";
            label3.Size = new Size(39, 17);
            label3.TabIndex = 5;
            label3.Text = "Role:";
            // 
            // txtRole
            // 
            txtRole.Location = new Point(133, 90);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(100, 24);
            txtRole.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(14, 126);
            label4.Name = "label4";
            label4.Size = new Size(111, 17);
            label4.TabIndex = 7;
            label4.Text = "Datum narození:";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(131, 120);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(200, 24);
            dtpBirthDate.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.InactiveCaption;
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(21, 22);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Přidat";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.InactiveCaption;
            btnEdit.ForeColor = Color.Black;
            btnEdit.Location = new Point(102, 22);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Upravit";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.InactiveCaption;
            btnDelete.ForeColor = Color.Black;
            btnDelete.Location = new Point(183, 22);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.InactiveCaption;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(264, 22);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Zrušit";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.Gray;
            groupBox1.Location = new Point(12, 288);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(345, 57);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ovládací panel";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpBirthDate);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtRole);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtLastName);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtName);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            groupBox2.ForeColor = Color.Gray;
            groupBox2.Location = new Point(12, 127);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(345, 155);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Atributy";
            // 
            // MemberForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 357);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(listMembers);
            Name = "MemberForm";
            Text = " Členové";
            Load += MemberForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listMembers;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtLastName;
        private Label label3;
        private TextBox txtRole;
        private Label label4;
        private DateTimePicker dtpBirthDate;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnCancel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}