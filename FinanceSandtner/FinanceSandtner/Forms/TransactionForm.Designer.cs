namespace FinanceSandtner.Forms
{
    partial class TransactionForm
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
            label1 = new Label();
            cmbMember = new ComboBox();
            label2 = new Label();
            cmbCategory = new ComboBox();
            label3 = new Label();
            cmbType = new ComboBox();
            label4 = new Label();
            numAmount = new NumericUpDown();
            label5 = new Label();
            dtpDate = new DateTimePicker();
            label6 = new Label();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(7, 40);
            label1.Name = "label1";
            label1.Size = new Size(107, 23);
            label1.TabIndex = 0;
            label1.Text = "Člen rodiny:";
            // 
            // cmbMember
            // 
            cmbMember.FormattingEnabled = true;
            cmbMember.Location = new Point(119, 29);
            cmbMember.Margin = new Padding(3, 4, 3, 4);
            cmbMember.Name = "cmbMember";
            cmbMember.Size = new Size(138, 29);
            cmbMember.TabIndex = 1;
            cmbMember.Text = "Výběr člena rodiny";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(7, 99);
            label2.Name = "label2";
            label2.Size = new Size(93, 23);
            label2.TabIndex = 2;
            label2.Text = "Kategorie:";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(117, 88);
            cmbCategory.Margin = new Padding(3, 4, 3, 4);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(138, 29);
            cmbCategory.TabIndex = 3;
            cmbCategory.Text = "Výběr kategorie";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(7, 151);
            label3.Name = "label3";
            label3.Size = new Size(45, 23);
            label3.TabIndex = 4;
            label3.Text = "Typ:";
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(117, 140);
            cmbType.Margin = new Padding(3, 4, 3, 4);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(138, 29);
            cmbType.TabIndex = 5;
            cmbType.Text = "Výběr typu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(7, 208);
            label4.Name = "label4";
            label4.Size = new Size(68, 23);
            label4.TabIndex = 6;
            label4.Text = "Částka:";
            // 
            // numAmount
            // 
            numAmount.Location = new Point(117, 197);
            numAmount.Margin = new Padding(3, 4, 3, 4);
            numAmount.Name = "numAmount";
            numAmount.Size = new Size(137, 28);
            numAmount.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(6, 260);
            label5.Name = "label5";
            label5.Size = new Size(70, 23);
            label5.TabIndex = 8;
            label5.Text = "Datum:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(117, 249);
            dtpDate.Margin = new Padding(3, 4, 3, 4);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(219, 28);
            dtpDate.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.Location = new Point(17, 308);
            label6.Name = "label6";
            label6.Size = new Size(58, 23);
            label6.TabIndex = 10;
            label6.Text = "Popis:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(128, 304);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(114, 27);
            txtDescription.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.InactiveCaption;
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(87, 29);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(86, 31);
            btnSave.TabIndex = 12;
            btnSave.Text = "Uložit";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.InactiveCaption;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(179, 29);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 31);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Zrušit";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.Gray;
            groupBox1.Location = new Point(11, 356);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(354, 76);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ovládací panel";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dtpDate);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cmbMember);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(numAmount);
            groupBox2.Controls.Add(cmbCategory);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(cmbType);
            groupBox2.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            groupBox2.ForeColor = Color.Gray;
            groupBox2.Location = new Point(11, 3);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(354, 345);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Atributy";
            // 
            // TransactionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 448);
            Controls.Add(groupBox1);
            Controls.Add(txtDescription);
            Controls.Add(label6);
            Controls.Add(groupBox2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TransactionForm";
            Text = "Transakce";
            Load += TransactionForm_Load;
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbMember;
        private Label label2;
        private ComboBox cmbCategory;
        private Label label3;
        private ComboBox cmbType;
        private Label label4;
        private NumericUpDown numAmount;
        private Label label5;
        private DateTimePicker dtpDate;
        private Label label6;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}