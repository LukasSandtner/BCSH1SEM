namespace FinanceSandtner.Forms
{
    partial class CategoryForm
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
            listCategories = new ListBox();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            cmbType = new ComboBox();
            btnAdd = new Button();
            btnAlter = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listCategories
            // 
            listCategories.BackColor = SystemColors.ScrollBar;
            listCategories.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            listCategories.FormattingEnabled = true;
            listCategories.Location = new Point(12, 12);
            listCategories.Name = "listCategories";
            listCategories.Size = new Size(318, 123);
            listCategories.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            label1.Location = new Point(12, 144);
            label1.Name = "label1";
            label1.Size = new Size(49, 17);
            label1.TabIndex = 1;
            label1.Text = "Název:";
            // 
            // txtName
            // 
            txtName.Location = new Point(80, 143);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            label2.Location = new Point(12, 177);
            label2.Name = "label2";
            label2.Size = new Size(35, 17);
            label2.TabIndex = 3;
            label2.Text = "Typ:";
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(80, 176);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(121, 23);
            cmbType.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.InactiveCaption;
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(4, 18);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Přidat";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnAlter
            // 
            btnAlter.BackColor = SystemColors.InactiveCaption;
            btnAlter.ForeColor = Color.Black;
            btnAlter.Location = new Point(85, 18);
            btnAlter.Name = "btnAlter";
            btnAlter.Size = new Size(75, 23);
            btnAlter.TabIndex = 6;
            btnAlter.Text = "Upravit";
            btnAlter.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.InactiveCaption;
            btnDelete.ForeColor = Color.Black;
            btnDelete.Location = new Point(166, 18);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Smazat";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.InactiveCaption;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(247, 18);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Zrušit";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAlter);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.Gray;
            groupBox1.Location = new Point(12, 205);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 50);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ovládací panel";
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 258);
            Controls.Add(cmbType);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(listCategories);
            Controls.Add(groupBox1);
            Name = "CategoryForm";
            Text = "Kategorie";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listCategories;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private ComboBox cmbType;
        private Button btnAdd;
        private Button btnAlter;
        private Button btnDelete;
        private Button btnCancel;
        private GroupBox groupBox1;
    }
}