using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FYP_Management.Classes;

namespace FYP_Management {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            uStudents1.FillTable();
            this.Text = "Manage Students - FYP Management";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.Modifiers == Keys.Control  && e.KeyCode == Keys.S) {
                this.uStudents1.Show();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A) {
                ShowAdvisors();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode==Keys.P) {
                ShowProject();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.G) {
                ShowGroup();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.E) {
                ShowEvalution();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R) {
                ShowReport();
            }

        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'projectADataSet.Person' table. You can move, or remove it, as needed.
            this.personTableAdapter.Fill(this.projectADataSet.Person);
            // TODO: This line of code loads data into the 'projectADataSet.Person' table. You can move, or remove it, as needed.
        }

        private void StudentsButton_Click(object sender, EventArgs e) {
            if (!this.uStudents1.Visible) {
                this.uStudents1.Show();
                try {
                    this.uAdvisors.Hide();
                    this.uProjects.Hide();
                    this.uGroups.Hide();
                }
                catch { }
            }
        }

        private void uStudents1_VisibleChanged(object sender, EventArgs e) {
            this.Text = "Manage Students - FYP Management";
        }

        private void AdvisorsButton_Click(object sender, EventArgs e) {
            ShowAdvisors();
        }
        private void ShowAdvisors() {
            this.uStudents1.Hide();
            try {
                this.uProjects.Hide();
            }
            catch { }
            try {
                this.uGroups.Hide();
            }
            catch { }
            try {
                this.uEvaluations.Hide();
            }
            catch { }
            try {
                this.uReports.Hide();
            }
            catch { }
            // Creating and adding user control to tablelayout
            if (this.uAdvisors == null) {
                this.uAdvisors = new UserControls.UAdvisors();
                tableLayoutPanel1.Controls.Add(this.uAdvisors);
                this.uAdvisors.Dock = DockStyle.Fill;
            }
            this.uAdvisors.Show();
            this.Text = "Manage Advisors - FYP Management";
        }
        private void ShowProject() {
            this.uStudents1.Hide();
            try {
                this.uAdvisors.Hide();
            }
            catch { }
            try {
                this.uGroups.Hide();
            }
            catch { }
            try {
                this.uEvaluations.Hide();
            }
            catch { }
            try {
                this.uReports.Hide();
            }
            catch { }
            // Creating and adding user control to tablelayout
            if (this.uProjects == null) {
                this.uProjects = new UserControls.UProjects();
                tableLayoutPanel1.Controls.Add(this.uProjects);
                this.uProjects.Dock = DockStyle.Fill;
            }
            this.uProjects.Show();
            this.Text = "Manage Projects - FYP Management";
        }
        private void ShowGroup() {
            this.uStudents1.Hide();
            try {
                this.uAdvisors.Hide();
            }
            catch { }
            try {
                this.uProjects.Hide();
            }
            catch { }
            try {
                this.uEvaluations.Hide();
            }
            catch { }
            try {
                this.uReports.Hide();
            }
            catch { }
            // Creating and adding user control to tablelayout
            if (this.uGroups == null) {
                this.uGroups = new UserControls.UGroups();
                tableLayoutPanel1.Controls.Add(this.uGroups);
                this.uGroups.Dock = DockStyle.Fill;
            }
            this.uGroups.Show();
            this.Text = "Manage Groups - FYP Management";
        }

        private void ShowEvalution() {
            this.uStudents1.Hide();
            try {
                this.uAdvisors.Hide();
            }
            catch { }
            try {
                this.uProjects.Hide();
            }
            catch { }
            try {
                this.uGroups.Hide();
            }
            catch { }
            try {
                this.uReports.Hide();
            }
            catch { }
            // Creating and adding user control to tablelayout
            if (this.uEvaluations == null) {
                this.uEvaluations = new UserControls.UEvaluations();
                tableLayoutPanel1.Controls.Add(this.uEvaluations);
                this.uEvaluations.Dock = DockStyle.Fill;
            }
            this.uEvaluations.Show();
            this.Text = "Manage Evaluations - FYP Management";
        }
        private void ShowReport() {
            this.uStudents1.Hide();
            try {
                this.uAdvisors.Hide();
            }
            catch { }
            try {
                this.uProjects.Hide();
            }
            catch { }
            try {
                this.uGroups.Hide();
            }
            catch { }
            try {
                this.uEvaluations.Hide();
            }
            catch { }
            // Creating and adding user control to tablelayout
            if (this.uReports == null) {
                this.uReports = new UserControls.UReports();
                tableLayoutPanel1.Controls.Add(this.uReports);
                this.uReports.Dock = DockStyle.Fill;
            }
            this.uReports.Show();
            this.Text = "Reports - FYP Management";
        }

        private void projectsButton_Click(object sender, EventArgs e) {
            ShowProject();
        }

        private void button1_Click(object sender, EventArgs e) {
            ShowGroup();
        }

        private void evaluationButton_Click(object sender, EventArgs e) {
            ShowEvalution();
        }

        private void reportsButton_Click(object sender, EventArgs e) {
            ShowReport();
        }
    }
}
