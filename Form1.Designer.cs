
namespace FYP_Management {
    partial class Form1 {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.evaluationButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.projectsButton = new System.Windows.Forms.Button();
            this.AdvisorsButton = new System.Windows.Forms.Button();
            this.StudentsButton = new System.Windows.Forms.Button();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectADataSet = new FYP_Management.ProjectADataSet();
            this.StudentButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.personTableAdapter = new FYP_Management.ProjectADataSetTableAdapters.PersonTableAdapter();
            this.reportsButton = new System.Windows.Forms.Button();
            this.uStudents1 = new FYP_Management.UserControls.UStudents();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectADataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uStudents1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 515);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.reportsButton);
            this.panel1.Controls.Add(this.evaluationButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.projectsButton);
            this.panel1.Controls.Add(this.AdvisorsButton);
            this.panel1.Controls.Add(this.StudentsButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 509);
            this.panel1.TabIndex = 0;
            // 
            // evaluationButton
            // 
            this.evaluationButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.evaluationButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.evaluationButton.FlatAppearance.BorderSize = 0;
            this.evaluationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.evaluationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evaluationButton.Image = ((System.Drawing.Image)(resources.GetObject("evaluationButton.Image")));
            this.evaluationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.evaluationButton.Location = new System.Drawing.Point(9, 305);
            this.evaluationButton.Name = "evaluationButton";
            this.evaluationButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.evaluationButton.Size = new System.Drawing.Size(228, 47);
            this.evaluationButton.TabIndex = 4;
            this.evaluationButton.Text = "Evaluations";
            this.StudentButtonToolTip.SetToolTip(this.evaluationButton, "Manage Evaluations (Ctrl+E)");
            this.evaluationButton.UseVisualStyleBackColor = false;
            this.evaluationButton.Click += new System.EventHandler(this.evaluationButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(9, 252);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(228, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Groups";
            this.StudentButtonToolTip.SetToolTip(this.button1, "Manage Groups (Ctrl + G)");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // projectsButton
            // 
            this.projectsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.projectsButton.FlatAppearance.BorderSize = 0;
            this.projectsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.projectsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectsButton.Image = ((System.Drawing.Image)(resources.GetObject("projectsButton.Image")));
            this.projectsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.projectsButton.Location = new System.Drawing.Point(9, 199);
            this.projectsButton.Name = "projectsButton";
            this.projectsButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.projectsButton.Size = new System.Drawing.Size(228, 47);
            this.projectsButton.TabIndex = 2;
            this.projectsButton.Text = "Projects";
            this.StudentButtonToolTip.SetToolTip(this.projectsButton, "Manage Projects (Ctrl+P)");
            this.projectsButton.UseVisualStyleBackColor = false;
            this.projectsButton.Click += new System.EventHandler(this.projectsButton_Click);
            // 
            // AdvisorsButton
            // 
            this.AdvisorsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdvisorsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AdvisorsButton.FlatAppearance.BorderSize = 0;
            this.AdvisorsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdvisorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdvisorsButton.Image = ((System.Drawing.Image)(resources.GetObject("AdvisorsButton.Image")));
            this.AdvisorsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AdvisorsButton.Location = new System.Drawing.Point(9, 146);
            this.AdvisorsButton.Name = "AdvisorsButton";
            this.AdvisorsButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.AdvisorsButton.Size = new System.Drawing.Size(228, 47);
            this.AdvisorsButton.TabIndex = 1;
            this.AdvisorsButton.Text = "Advisors";
            this.StudentButtonToolTip.SetToolTip(this.AdvisorsButton, "Manage Advisors (Ctrl+A)");
            this.AdvisorsButton.UseVisualStyleBackColor = false;
            this.AdvisorsButton.Click += new System.EventHandler(this.AdvisorsButton_Click);
            // 
            // StudentsButton
            // 
            this.StudentsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StudentsButton.FlatAppearance.BorderSize = 0;
            this.StudentsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StudentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentsButton.Image = ((System.Drawing.Image)(resources.GetObject("StudentsButton.Image")));
            this.StudentsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StudentsButton.Location = new System.Drawing.Point(9, 93);
            this.StudentsButton.Name = "StudentsButton";
            this.StudentsButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.StudentsButton.Size = new System.Drawing.Size(228, 47);
            this.StudentsButton.TabIndex = 0;
            this.StudentsButton.Text = "Students";
            this.StudentButtonToolTip.SetToolTip(this.StudentsButton, "Manage Students. Shortcut key is Ctrl + S");
            this.StudentsButton.UseVisualStyleBackColor = false;
            this.StudentsButton.Click += new System.EventHandler(this.StudentsButton_Click);
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataMember = "Person";
            this.personBindingSource.DataSource = this.projectADataSet;
            // 
            // projectADataSet
            // 
            this.projectADataSet.DataSetName = "ProjectADataSet";
            this.projectADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personTableAdapter
            // 
            this.personTableAdapter.ClearBeforeFill = true;
            // 
            // reportsButton
            // 
            this.reportsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportsButton.FlatAppearance.BorderSize = 0;
            this.reportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsButton.Image = ((System.Drawing.Image)(resources.GetObject("reportsButton.Image")));
            this.reportsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportsButton.Location = new System.Drawing.Point(9, 358);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.reportsButton.Size = new System.Drawing.Size(228, 47);
            this.reportsButton.TabIndex = 5;
            this.reportsButton.Text = "Reports";
            this.StudentButtonToolTip.SetToolTip(this.reportsButton, "Manage Evaluations (Ctrl+E)");
            this.reportsButton.UseVisualStyleBackColor = false;
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click);
            // 
            // uStudents1
            // 
            this.uStudents1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uStudents1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uStudents1.Location = new System.Drawing.Point(253, 3);
            this.uStudents1.Name = "uStudents1";
            this.uStudents1.Size = new System.Drawing.Size(718, 509);
            this.uStudents1.TabIndex = 1;
            this.uStudents1.VisibleChanged += new System.EventHandler(this.uStudents1_VisibleChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(974, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FYP Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectADataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StudentsButton;
        private System.Windows.Forms.ToolTip StudentButtonToolTip;
        private ProjectADataSet projectADataSet;
        private System.Windows.Forms.BindingSource personBindingSource;
        private ProjectADataSetTableAdapters.PersonTableAdapter personTableAdapter;
        private UserControls.UStudents uStudents1;
        private System.Windows.Forms.Button AdvisorsButton;

        // Defined by my own hands.
        private UserControls.UAdvisors uAdvisors;
        private UserControls.UProjects uProjects;
        private UserControls.UGroups uGroups;
        private UserControls.UEvaluations uEvaluations;
        private UserControls.UReports uReports;
        private System.Windows.Forms.Button projectsButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button evaluationButton;
        private System.Windows.Forms.Button reportsButton;
    }
}

