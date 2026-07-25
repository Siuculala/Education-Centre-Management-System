namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlToolbar = new Panel();
            cmbFilterRole = new ComboBox();
            label2 = new Label();
            txtSearch = new TextBox();
            label1 = new Label();
            fileSystemWatcher1 = new FileSystemWatcher();
            splitContainer1 = new SplitContainer();
            dgvRecords = new DataGridView();
            gbDetail = new GroupBox();
            gbDynamicFields = new GroupBox();
            lblStatus = new Label();
            btnExit = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cmbExtra3 = new ComboBox();
            txtExtra3 = new TextBox();
            txtExtra2 = new TextBox();
            txtExtra1 = new TextBox();
            lblExtra3 = new Label();
            lblExtra2 = new Label();
            lblExtra1 = new Label();
            cmbRole = new ComboBox();
            lblRole = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtTelephone = new TextBox();
            lblTelephone = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtRecordId = new TextBox();
            lblRecordId = new Label();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).BeginInit();
            gbDetail.SuspendLayout();
            gbDynamicFields.SuspendLayout();
            SuspendLayout();
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = SystemColors.ControlDark;
            pnlToolbar.Controls.Add(cmbFilterRole);
            pnlToolbar.Controls.Add(label2);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Controls.Add(label1);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1062, 50);
            pnlToolbar.TabIndex = 0;
            // 
            // cmbFilterRole
            // 
            cmbFilterRole.BackColor = Color.SeaShell;
            cmbFilterRole.FormattingEnabled = true;
            cmbFilterRole.Location = new Point(580, 11);
            cmbFilterRole.Name = "cmbFilterRole";
            cmbFilterRole.Size = new Size(121, 23);
            cmbFilterRole.TabIndex = 3;
            cmbFilterRole.SelectedIndexChanged += cmbFilterRole_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.SeaShell;
            label2.Location = new Point(541, 14);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 1;
            label2.Text = "Role:";
            label2.Click += label2_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.SeaShell;
            txtSearch.Location = new Point(63, 11);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(415, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.SeaShell;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Search:";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 50);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvRecords);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(gbDetail);
            splitContainer1.Size = new Size(1062, 400);
            splitContainer1.SplitterDistance = 530;
            splitContainer1.TabIndex = 1;
            // 
            // dgvRecords
            // 
            dgvRecords.BackgroundColor = SystemColors.Control;
            dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecords.Dock = DockStyle.Fill;
            dgvRecords.Location = new Point(0, 0);
            dgvRecords.Name = "dgvRecords";
            dgvRecords.Size = new Size(530, 400);
            dgvRecords.TabIndex = 0;
            dgvRecords.CellClick += dgvRecords_CellClick;
            // 
            // gbDetail
            // 
            gbDetail.BackColor = SystemColors.ActiveCaption;
            gbDetail.Controls.Add(gbDynamicFields);
            gbDetail.Controls.Add(cmbRole);
            gbDetail.Controls.Add(lblRole);
            gbDetail.Controls.Add(txtEmail);
            gbDetail.Controls.Add(lblEmail);
            gbDetail.Controls.Add(txtTelephone);
            gbDetail.Controls.Add(lblTelephone);
            gbDetail.Controls.Add(txtName);
            gbDetail.Controls.Add(lblName);
            gbDetail.Controls.Add(txtRecordId);
            gbDetail.Controls.Add(lblRecordId);
            gbDetail.Dock = DockStyle.Fill;
            gbDetail.Location = new Point(0, 0);
            gbDetail.Name = "gbDetail";
            gbDetail.Size = new Size(528, 400);
            gbDetail.TabIndex = 0;
            gbDetail.TabStop = false;
            gbDetail.Text = "Profile";
            gbDetail.Enter += gbDetail_Enter;
            // 
            // gbDynamicFields
            // 
            gbDynamicFields.BackColor = Color.Ivory;
            gbDynamicFields.Controls.Add(lblStatus);
            gbDynamicFields.Controls.Add(btnExit);
            gbDynamicFields.Controls.Add(btnClear);
            gbDynamicFields.Controls.Add(btnDelete);
            gbDynamicFields.Controls.Add(btnUpdate);
            gbDynamicFields.Controls.Add(btnAdd);
            gbDynamicFields.Controls.Add(cmbExtra3);
            gbDynamicFields.Controls.Add(txtExtra3);
            gbDynamicFields.Controls.Add(txtExtra2);
            gbDynamicFields.Controls.Add(txtExtra1);
            gbDynamicFields.Controls.Add(lblExtra3);
            gbDynamicFields.Controls.Add(lblExtra2);
            gbDynamicFields.Controls.Add(lblExtra1);
            gbDynamicFields.Location = new Point(0, 195);
            gbDynamicFields.Name = "gbDynamicFields";
            gbDynamicFields.Size = new Size(548, 205);
            gbDynamicFields.TabIndex = 10;
            gbDynamicFields.TabStop = false;
            gbDynamicFields.Text = "Role Details";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(23, 183);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(268, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status: 0 records — 0 Teacher, 0 Admin, 0 Student";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(430, 152);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(328, 152);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(224, 152);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(120, 152);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(19, 152);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbExtra3
            // 
            cmbExtra3.BackColor = SystemColors.Menu;
            cmbExtra3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExtra3.FormattingEnabled = true;
            cmbExtra3.Location = new Point(138, 87);
            cmbExtra3.Name = "cmbExtra3";
            cmbExtra3.Size = new Size(100, 23);
            cmbExtra3.TabIndex = 1;
            cmbExtra3.Visible = false;
            // 
            // txtExtra3
            // 
            txtExtra3.BackColor = SystemColors.Menu;
            txtExtra3.Location = new Point(137, 87);
            txtExtra3.Name = "txtExtra3";
            txtExtra3.Size = new Size(100, 23);
            txtExtra3.TabIndex = 5;
            // 
            // txtExtra2
            // 
            txtExtra2.BackColor = SystemColors.Menu;
            txtExtra2.Location = new Point(137, 58);
            txtExtra2.Name = "txtExtra2";
            txtExtra2.Size = new Size(100, 23);
            txtExtra2.TabIndex = 4;
            // 
            // txtExtra1
            // 
            txtExtra1.BackColor = SystemColors.Menu;
            txtExtra1.Location = new Point(137, 29);
            txtExtra1.Name = "txtExtra1";
            txtExtra1.Size = new Size(100, 23);
            txtExtra1.TabIndex = 1;
            // 
            // lblExtra3
            // 
            lblExtra3.AutoSize = true;
            lblExtra3.Location = new Point(19, 95);
            lblExtra3.Name = "lblExtra3";
            lblExtra3.Size = new Size(44, 15);
            lblExtra3.TabIndex = 3;
            lblExtra3.Text = "Extra 3:";
            // 
            // lblExtra2
            // 
            lblExtra2.AutoSize = true;
            lblExtra2.Location = new Point(19, 66);
            lblExtra2.Name = "lblExtra2";
            lblExtra2.Size = new Size(44, 15);
            lblExtra2.TabIndex = 2;
            lblExtra2.Text = "Extra 2:";
            // 
            // lblExtra1
            // 
            lblExtra1.AutoSize = true;
            lblExtra1.Location = new Point(19, 37);
            lblExtra1.Name = "lblExtra1";
            lblExtra1.Size = new Size(44, 15);
            lblExtra1.TabIndex = 1;
            lblExtra1.Text = "Extra 1:";
            // 
            // cmbRole
            // 
            cmbRole.BackColor = SystemColors.Menu;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(73, 152);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(107, 23);
            cmbRole.TabIndex = 9;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(22, 159);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(33, 15);
            lblRole.TabIndex = 8;
            lblRole.Text = "Role:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.Menu;
            txtEmail.Location = new Point(69, 122);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(22, 129);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtTelephone
            // 
            txtTelephone.BackColor = SystemColors.Menu;
            txtTelephone.Location = new Point(89, 91);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(100, 23);
            txtTelephone.TabIndex = 5;
            // 
            // lblTelephone
            // 
            lblTelephone.AutoSize = true;
            lblTelephone.Location = new Point(19, 97);
            lblTelephone.Name = "lblTelephone";
            lblTelephone.Size = new Size(65, 15);
            lblTelephone.TabIndex = 4;
            lblTelephone.Text = "Telephone:";
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.Menu;
            txtName.Location = new Point(69, 60);
            txtName.Name = "txtName";
            txtName.Size = new Size(169, 23);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 67);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Name:";
            // 
            // txtRecordId
            // 
            txtRecordId.BackColor = SystemColors.ButtonFace;
            txtRecordId.Location = new Point(68, 31);
            txtRecordId.Name = "txtRecordId";
            txtRecordId.ReadOnly = true;
            txtRecordId.Size = new Size(37, 23);
            txtRecordId.TabIndex = 1;
            // 
            // lblRecordId
            // 
            lblRecordId.AutoSize = true;
            lblRecordId.Location = new Point(19, 36);
            lblRecordId.Name = "lblRecordId";
            lblRecordId.Size = new Size(21, 15);
            lblRecordId.TabIndex = 0;
            lblRecordId.Text = "ID:";
            lblRecordId.UseWaitCursor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 450);
            Controls.Add(splitContainer1);
            Controls.Add(pnlToolbar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Electronic Records";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecords).EndInit();
            gbDetail.ResumeLayout(false);
            gbDetail.PerformLayout();
            gbDynamicFields.ResumeLayout(false);
            gbDynamicFields.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlToolbar;
        private Label label2;
        private Label label1;
        private TextBox txtSearch;
        private FileSystemWatcher fileSystemWatcher1;
        private SplitContainer splitContainer1;
        private DataGridView dgvRecords;
        private GroupBox gbDetail;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label lblRecordId;
        private TextBox textBox1;
        private Label lblName;
        private TextBox txtRecordId;
        private ComboBox cmbRole;
        private Label lblRole;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtTelephone;
        private Label lblTelephone;
        private TextBox txtName;
        private GroupBox gbDynamicFields;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label lblExtra3;
        private Label lblExtra2;
        private Label lblExtra1;
        private ComboBox cmbExtra3;
        private TextBox txtExtra3;
        private TextBox txtExtra2;
        private TextBox txtExtra1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button btnExit;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label lblStatus;
        private ComboBox cmbFilterRole;
    }
}
