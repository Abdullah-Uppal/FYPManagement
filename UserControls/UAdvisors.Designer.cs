
namespace FYP_Management.UserControls {
    partial class UAdvisors {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.projectADataSet = new FYP_Management.ProjectADataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.advisorsGrid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.salaryInfoLabel = new System.Windows.Forms.Label();
            this.idInfoLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.salaryField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.designationField = new System.Windows.Forms.ComboBox();
            this.lookupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.idField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lookupTableAdapter = new FYP_Management.ProjectADataSetTableAdapters.LookupTableAdapter();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.projectADataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advisorsGrid)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectADataSet
            // 
            this.projectADataSet.DataSetName = "ProjectADataSet";
            this.projectADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 510);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.advisorsGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1005, 510);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // advisorsGrid
            // 
            this.advisorsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advisorsGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.advisorsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.advisorsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.advisorsGrid.ColumnHeadersHeight = 20;
            this.advisorsGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.advisorsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advisorsGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.advisorsGrid.Location = new System.Drawing.Point(13, 263);
            this.advisorsGrid.Name = "advisorsGrid";
            this.advisorsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.advisorsGrid.RowHeadersVisible = false;
            this.advisorsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advisorsGrid.Size = new System.Drawing.Size(979, 234);
            this.advisorsGrid.TabIndex = 0;
            this.advisorsGrid.TabStop = false;
            this.advisorsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advisorsGrid_CellContentClick);
            this.advisorsGrid.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.advisorsGrid_CellContextMenuStripNeeded);
            this.advisorsGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.advisorsGrid_EditingControlShowing);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SaveChanges);
            this.panel2.Controls.Add(this.salaryInfoLabel);
            this.panel2.Controls.Add(this.idInfoLabel);
            this.panel2.Controls.Add(this.addButton);
            this.panel2.Controls.Add(this.salaryField);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.designationField);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.idField);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(13, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 244);
            this.panel2.TabIndex = 1;
            // 
            // salaryInfoLabel
            // 
            this.salaryInfoLabel.AutoSize = true;
            this.salaryInfoLabel.ForeColor = System.Drawing.Color.Red;
            this.salaryInfoLabel.Location = new System.Drawing.Point(311, 113);
            this.salaryInfoLabel.Name = "salaryInfoLabel";
            this.salaryInfoLabel.Size = new System.Drawing.Size(0, 13);
            this.salaryInfoLabel.TabIndex = 7;
            // 
            // idInfoLabel
            // 
            this.idInfoLabel.AutoSize = true;
            this.idInfoLabel.ForeColor = System.Drawing.Color.Red;
            this.idInfoLabel.Location = new System.Drawing.Point(311, 37);
            this.idInfoLabel.Name = "idInfoLabel";
            this.idInfoLabel.Size = new System.Drawing.Size(0, 13);
            this.idInfoLabel.TabIndex = 6;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(186, 151);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(99, 32);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add Advisor";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // salaryField
            // 
            this.salaryField.Location = new System.Drawing.Point(110, 110);
            this.salaryField.Name = "salaryField";
            this.salaryField.Size = new System.Drawing.Size(175, 20);
            this.salaryField.TabIndex = 3;
            this.salaryField.TextChanged += new System.EventHandler(this.salaryField_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Salary";
            // 
            // designationField
            // 
            this.designationField.DataSource = this.lookupBindingSource;
            this.designationField.DisplayMember = "Value";
            this.designationField.FormattingEnabled = true;
            this.designationField.Location = new System.Drawing.Point(110, 72);
            this.designationField.Name = "designationField";
            this.designationField.Size = new System.Drawing.Size(175, 21);
            this.designationField.TabIndex = 2;
            this.designationField.ValueMember = "Value";
            // 
            // lookupBindingSource
            // 
            this.lookupBindingSource.DataMember = "Lookup";
            this.lookupBindingSource.DataSource = this.projectADataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Designation";
            // 
            // idField
            // 
            this.idField.Location = new System.Drawing.Point(110, 34);
            this.idField.Name = "idField";
            this.idField.Size = new System.Drawing.Size(175, 20);
            this.idField.TabIndex = 1;
            this.idField.TextChanged += new System.EventHandler(this.idField_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // lookupTableAdapter
            // 
            this.lookupTableAdapter.ClearBeforeFill = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 70);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // SaveChanges
            // 
            this.SaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveChanges.Enabled = false;
            this.SaveChanges.Location = new System.Drawing.Point(877, 209);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(99, 32);
            this.SaveChanges.TabIndex = 8;
            this.SaveChanges.Text = "Save Changes";
            this.SaveChanges.UseVisualStyleBackColor = true;
            this.SaveChanges.Click += new System.EventHandler(this.SaveChanges_Click);
            // 
            // UAdvisors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UAdvisors";
            this.Size = new System.Drawing.Size(1005, 510);
            ((System.ComponentModel.ISupportInitialize)(this.projectADataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advisorsGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ProjectADataSet projectADataSet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView advisorsGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox designationField;
        private System.Windows.Forms.BindingSource lookupBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idField;
        private System.Windows.Forms.Label label1;
        private ProjectADataSetTableAdapters.LookupTableAdapter lookupTableAdapter;
        private System.Windows.Forms.TextBox salaryField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label salaryInfoLabel;
        private System.Windows.Forms.Label idInfoLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.Button SaveChanges;
    }
}
